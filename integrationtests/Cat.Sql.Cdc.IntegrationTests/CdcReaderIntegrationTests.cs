using System.Collections.Concurrent;
using Cat.IntegrationTesting.SqlServer.NUnit;
using Cat.Sql.Cdc.Abstractions;
using Cat.Sql.Cdc.Extensions;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Cat.Sql.Cdc.IntegrationTests;

/// <summary>
/// Runs the change data capture reader on a real SQL Server with the Agent on. The Agent runs the capture job that fills the change tables.
/// </summary>
[TestFixture]
public class CdcReaderIntegrationTests : SqlServerAgentDatabaseTests
{
    private sealed class RecordingSink : ICatChangeSink
    {
        public ConcurrentQueue<CatChange> Changes { get; } = new();

        public Task SendAsync(CatChange change, object message, CancellationToken cancellationToken = default)
        {
            Changes.Enqueue(change);
            return Task.CompletedTask;
        }
    }

    private static readonly TimeSpan Timeout = TimeSpan.FromSeconds(90);

    [OneTimeSetUp]
    public async Task EnableCapture() => await ExecuteAsync("EXEC sys.sp_cdc_enable_db;");

    private async Task ExecuteAsync(string sql)
    {
        await using var connection = new SqlConnection(ConnectionString);
        await connection.OpenAsync();
        await using var command = new SqlCommand(sql, connection);
        await command.ExecuteNonQueryAsync();
    }

    /// <summary>
    /// Creates the table and switches capture on. The container starts the Agent a little after SQL Server accepts connections,
    /// and the first capture needs the Agent to add its job. SQL Server answers error 14258, "SQLServerAgent is starting",
    /// until it is ready, so the call is repeated for a while. It is safe to repeat, because the enable runs only for a table that is not tracked yet.
    /// </summary>
    private async Task CreateCapturedTableAsync(string table)
    {
        await ExecuteAsync($"CREATE TABLE dbo.{table} (Id int NOT NULL PRIMARY KEY, Title nvarchar(50) NOT NULL);");

        var enable = $"IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = N'{table}' AND is_tracked_by_cdc = 1) " +
                     $"EXEC sys.sp_cdc_enable_table @source_schema = N'dbo', @source_name = N'{table}', @role_name = NULL, @supports_net_changes = 0;";
        var until = DateTime.UtcNow + TimeSpan.FromSeconds(60);
        while (true)
        {
            try
            {
                await ExecuteAsync(enable);
                return;
            }
            catch (SqlException exception) when (DateTime.UtcNow < until && exception.ToString().Contains("SQLServerAgent is starting"))
            {
                await Task.Delay(1000);
            }
        }
    }

    private async Task<(ServiceProvider Provider, RecordingSink Sink, IHostedService Reader)> StartReaderAsync(string table, TimeSpan? claimLease = null)
    {
        var values = new Dictionary<string, string?>
        {
            ["CatSqlCdc:ConnectionString"] = ConnectionString,
            ["CatSqlCdc:PollInterval"] = "00:00:00.200"
        };
        if (claimLease.HasValue) values["CatSqlCdc:ClaimLease"] = claimLease.Value.ToString("c");
        var configuration = new ConfigurationBuilder().AddInMemoryCollection(values).Build();
        var sink = new RecordingSink();
        var services = new ServiceCollection();
        services.AddLogging();
        services.AddSingleton<ICatChangeSink>(sink);
        services.AddCatSqlCdc(configuration, cdc => cdc.AddTable($"dbo_{table}"));
        var provider = services.BuildServiceProvider();
        var reader = provider.GetServices<IHostedService>().Single();
        await reader.StartAsync(CancellationToken.None);
        return (provider, sink, reader);
    }

    private static async Task WaitForAsync(Func<bool> condition, string what)
    {
        var until = DateTime.UtcNow + Timeout;
        while (!condition())
        {
            if (DateTime.UtcNow > until) Assert.Fail("Timed out waiting for " + what + ".");
            await Task.Delay(250);
        }
    }

    [Test]
    public async Task Reader_DeliversInsertsUpdatesAndDeletesInOrder()
    {
        await CreateCapturedTableAsync("BookA");
        var (provider, sink, reader) = await StartReaderAsync("BookA");
        try
        {
            await ExecuteAsync("INSERT INTO dbo.BookA (Id, Title) VALUES (1, N'first');");
            await ExecuteAsync("UPDATE dbo.BookA SET Title = N'changed' WHERE Id = 1;");
            await ExecuteAsync("DELETE FROM dbo.BookA WHERE Id = 1;");

            await WaitForAsync(() => sink.Changes.Count >= 3, "three changes");

            var changes = sink.Changes.ToList();
            Assert.That(changes.Select(c => c.Operation), Is.EqualTo(new[] { CatChangeOperation.Insert, CatChangeOperation.Update, CatChangeOperation.Delete }));
            Assert.That(changes.All(c => Convert.ToInt32(c.Keys["Id"]) == 1), Is.True);
            Assert.That(changes[0].New!["Title"], Is.EqualTo("first"));
            Assert.That(changes[1].Old!["Title"], Is.EqualTo("first"));
            Assert.That(changes[1].New!["Title"], Is.EqualTo("changed"));
            Assert.That(changes[2].Old!["Title"], Is.EqualTo("changed"));
        }
        finally
        {
            await reader.StopAsync(CancellationToken.None);
            await provider.DisposeAsync();
        }
    }

    [Test]
    public async Task Reader_AfterARestart_CarriesOnWhereItStopped()
    {
        await CreateCapturedTableAsync("BookB");
        var (firstProvider, firstSink, firstReader) = await StartReaderAsync("BookB");
        try
        {
            await ExecuteAsync("INSERT INTO dbo.BookB (Id, Title) VALUES (1, N'one'), (2, N'two');");
            await WaitForAsync(() => firstSink.Changes.Count >= 2, "the first two changes");
        }
        finally
        {
            await firstReader.StopAsync(CancellationToken.None);
            await firstProvider.DisposeAsync();
        }

        await ExecuteAsync("INSERT INTO dbo.BookB (Id, Title) VALUES (3, N'three');");
        var (secondProvider, secondSink, secondReader) = await StartReaderAsync("BookB");
        try
        {
            await WaitForAsync(() => secondSink.Changes.Count >= 1, "the change after the restart");
            await Task.Delay(2000);

            Assert.That(secondSink.Changes.Select(c => Convert.ToInt32(c.Keys["Id"])), Is.EqualTo(new[] { 3 }));
        }
        finally
        {
            await secondReader.StopAsync(CancellationToken.None);
            await secondProvider.DisposeAsync();
        }
    }

    private static IEnumerable<int> Ids(RecordingSink sink) => sink.Changes.Select(c => Convert.ToInt32(c.Keys["Id"]));

    [Test]
    public async Task Reader_TwoInstancesOnOneTable_OnlyTheClaimHolderDeliversTheChanges()
    {
        await CreateCapturedTableAsync("BookC");
        var (firstProvider, firstSink, firstReader) = await StartReaderAsync("BookC", TimeSpan.FromSeconds(3));
        var (secondProvider, secondSink, secondReader) = await StartReaderAsync("BookC", TimeSpan.FromSeconds(3));
        try
        {
            await ExecuteAsync("INSERT INTO dbo.BookC (Id, Title) VALUES (1, N'one'), (2, N'two'), (3, N'three');");
            await WaitForAsync(() => firstSink.Changes.Count + secondSink.Changes.Count >= 3, "three changes");
            await ExecuteAsync("INSERT INTO dbo.BookC (Id, Title) VALUES (4, N'four');");
            await WaitForAsync(() => firstSink.Changes.Count + secondSink.Changes.Count >= 4, "the fourth change");

            // Longer than the lease, so a second claim would have shown up by now.
            await Task.Delay(TimeSpan.FromSeconds(5));

            var holder = firstSink.Changes.IsEmpty ? secondSink : firstSink;
            var other = holder == firstSink ? secondSink : firstSink;
            Assert.That(Ids(holder), Is.EqualTo(new[] { 1, 2, 3, 4 }));
            Assert.That(other.Changes, Is.Empty);
        }
        finally
        {
            await firstReader.StopAsync(CancellationToken.None);
            await secondReader.StopAsync(CancellationToken.None);
            await firstProvider.DisposeAsync();
            await secondProvider.DisposeAsync();
        }
    }

    [Test]
    public async Task Reader_WhenTheClaimHolderStops_TheOtherTakesOverAfterTheLeaseWhereTheHolderStopped()
    {
        await CreateCapturedTableAsync("BookD");
        var lease = TimeSpan.FromSeconds(3);
        var first = await StartReaderAsync("BookD", lease);
        var second = await StartReaderAsync("BookD", lease);
        var stopped = new List<(ServiceProvider Provider, IHostedService Reader)>();
        try
        {
            await ExecuteAsync("INSERT INTO dbo.BookD (Id, Title) VALUES (1, N'one'), (2, N'two');");
            await WaitForAsync(() => first.Sink.Changes.Count + second.Sink.Changes.Count >= 2, "the first two changes");

            var (holder, other) = first.Sink.Changes.IsEmpty ? (second, first) : (first, second);
            await holder.Reader.StopAsync(CancellationToken.None);
            stopped.Add((holder.Provider, holder.Reader));
            var stoppedAt = DateTime.UtcNow;

            await ExecuteAsync("INSERT INTO dbo.BookD (Id, Title) VALUES (3, N'three');");
            await WaitForAsync(() => !other.Sink.Changes.IsEmpty, "the other instance to take over");
            var tookOverAfter = DateTime.UtcNow - stoppedAt;
            await Task.Delay(2000);

            Assert.That(Ids(holder.Sink), Is.EqualTo(new[] { 1, 2 }));
            Assert.That(Ids(other.Sink), Is.EqualTo(new[] { 3 }));
            // The holder renewed its claim on its last round, so the other waits for most of a lease.
            Assert.That(tookOverAfter, Is.GreaterThan(lease - TimeSpan.FromSeconds(1)));
        }
        finally
        {
            foreach (var instance in new[] { first, second })
            {
                if (!stopped.Any(s => s.Reader == instance.Reader)) await instance.Reader.StopAsync(CancellationToken.None);
                await instance.Provider.DisposeAsync();
            }
        }
    }
}
