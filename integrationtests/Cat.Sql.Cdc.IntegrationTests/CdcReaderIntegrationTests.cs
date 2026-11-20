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

    private async Task CreateCapturedTableAsync(string table) => await ExecuteAsync(
        $"CREATE TABLE dbo.{table} (Id int NOT NULL PRIMARY KEY, Title nvarchar(50) NOT NULL); " +
        $"EXEC sys.sp_cdc_enable_table @source_schema = N'dbo', @source_name = N'{table}', @role_name = NULL, @supports_net_changes = 0;");

    private async Task<(ServiceProvider Provider, RecordingSink Sink, IHostedService Reader)> StartReaderAsync(string table)
    {
        var configuration = new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string, string?>
        {
            ["CatSqlCdc:ConnectionString"] = ConnectionString,
            ["CatSqlCdc:PollInterval"] = "00:00:00.200"
        }).Build();
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
}
