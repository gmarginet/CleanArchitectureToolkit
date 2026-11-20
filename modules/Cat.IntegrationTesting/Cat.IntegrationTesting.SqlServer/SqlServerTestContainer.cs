using System;
using System.Threading;
using System.Threading.Tasks;
using DotNet.Testcontainers.Builders;
using Microsoft.Data.SqlClient;
using Testcontainers.MsSql;

namespace Cat.IntegrationTesting.SqlServer;

/// <summary>
/// A SQL Server in a container. The tests of one run share it, and every test class gets its own empty database.
/// </summary>
public sealed class SqlServerTestContainer : IAsyncDisposable
{
    /// <summary>
    /// The image that the container starts. The bulk operations of <c>Cat.Dapper.SqlServer</c> were first checked by hand on this version.
    /// </summary>
    public const string DefaultImage = "mcr.microsoft.com/mssql/server:2022-latest";

    private static readonly Lazy<SqlServerTestContainer> SharedContainer = new Lazy<SqlServerTestContainer>(() => new SqlServerTestContainer());

    private static readonly Lazy<SqlServerTestContainer> SharedAgentContainer =
        new Lazy<SqlServerTestContainer>(() => new SqlServerTestContainer(DefaultImage, enableAgent: true));

    private readonly string _image;
    private readonly bool _enableAgent;
    private readonly object _gate = new object();
    private Task<MsSqlContainer>? _start;

    /// <summary>
    /// Creates a container that starts on the first use.
    /// </summary>
    /// <param name="image">The SQL Server image to start.</param>
    /// <param name="enableAgent">Starts the SQL Server Agent in the container. Change data capture needs it, and it makes the start a little slower.</param>
    public SqlServerTestContainer(string image = DefaultImage, bool enableAgent = false)
    {
        _image = image ?? throw new ArgumentNullException(nameof(image));
        _enableAgent = enableAgent;
    }

    /// <summary>
    /// Gets the container that every test of the run shares. The first use starts it, and Testcontainers removes it when the run ends.
    /// </summary>
    public static SqlServerTestContainer Shared => SharedContainer.Value;

    /// <summary>
    /// Gets the container with the SQL Server Agent on, which every test that needs it shares. Use it for change data capture only,
    /// because the other tests start faster on <see cref="Shared"/>.
    /// </summary>
    public static SqlServerTestContainer SharedWithAgent => SharedAgentContainer.Value;

    /// <summary>
    /// Creates an empty database with a unique name.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>The database. Dispose it to drop it.</returns>
    /// <exception cref="CatContainerUnavailableException">Docker is not available.</exception>
    public async Task<ICatTestDatabase> CreateDatabaseAsync(CancellationToken cancellationToken = default)
    {
        var container = await StartAsync().ConfigureAwait(false);
        var name = CatTestEnvironment.NewDatabaseName();
        var master = container.GetConnectionString();

        using (var connection = new SqlConnection(master))
        {
            await connection.OpenAsync(cancellationToken).ConfigureAwait(false);
            using var command = connection.CreateCommand();
            command.CommandText = "CREATE DATABASE [" + name + "];";
            await command.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false);
        }

        var builder = new SqlConnectionStringBuilder(master) { InitialCatalog = name };
        return new Database(name, builder.ConnectionString, master);
    }

    /// <summary>
    /// Stops and removes the container.
    /// </summary>
    /// <returns>A task that completes when the container is gone.</returns>
    public async ValueTask DisposeAsync()
    {
        Task<MsSqlContainer>? start;
        lock (_gate) start = _start;
        if (start is null) return;

        try
        {
            var container = await start.ConfigureAwait(false);
            await container.DisposeAsync().ConfigureAwait(false);
        }
        catch (CatContainerUnavailableException)
        {
            // It never started, so there is nothing to remove.
        }
    }

    private Task<MsSqlContainer> StartAsync()
    {
        lock (_gate)
        {
            // The first caller starts it and the others wait for the same task, also when it failed.
            return _start ??= StartContainerAsync();
        }
    }

    private async Task<MsSqlContainer> StartContainerAsync()
    {
        try
        {
            var builder = new MsSqlBuilder(_image);
            if (_enableAgent) builder = builder.WithEnvironment("MSSQL_AGENT_ENABLED", "true");
            var container = builder.Build();
            await container.StartAsync().ConfigureAwait(false);
            if (_enableAgent) await WaitForAgentAsync(container.GetConnectionString()).ConfigureAwait(false);
            return container;
        }
        catch (DockerUnavailableException exception)
        {
            throw new CatContainerUnavailableException("The SQL Server container could not start. " + exception.Message, exception);
        }
    }

    // The Agent starts after SQL Server accepts connections. It refuses new jobs until it is ready, and change data capture needs to add a job.
    private static async Task WaitForAgentAsync(string connectionString)
    {
        var until = DateTime.UtcNow + TimeSpan.FromMinutes(2);
        while (true)
        {
            try
            {
                using var connection = new SqlConnection(connectionString);
                await connection.OpenAsync().ConfigureAwait(false);
                using var command = connection.CreateCommand();
                command.CommandText = "EXEC msdb.dbo.sp_add_job @job_name = N'cat_agent_probe'; EXEC msdb.dbo.sp_delete_job @job_name = N'cat_agent_probe';";
                await command.ExecuteNonQueryAsync().ConfigureAwait(false);
                return;
            }
            catch (SqlException) when (DateTime.UtcNow < until)
            {
                await Task.Delay(1000).ConfigureAwait(false);
            }
        }
    }

    private sealed class Database : ICatTestDatabase
    {
        private readonly string _master;

        public Database(string name, string connectionString, string master)
        {
            Name = name;
            ConnectionString = connectionString;
            _master = master;
        }

        public string Name { get; }

        public string ConnectionString { get; }

        public async ValueTask DisposeAsync()
        {
            // Pooled connections would keep the database busy.
            SqlConnection.ClearAllPools();
            using var connection = new SqlConnection(_master);
            await connection.OpenAsync().ConfigureAwait(false);
            using var command = connection.CreateCommand();
            command.CommandText = "ALTER DATABASE [" + Name + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE; DROP DATABASE [" + Name + "];";
            await command.ExecuteNonQueryAsync().ConfigureAwait(false);
        }
    }
}
