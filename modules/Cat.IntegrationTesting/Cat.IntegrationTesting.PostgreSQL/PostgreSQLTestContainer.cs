using System;
using System.Threading;
using System.Threading.Tasks;
using DotNet.Testcontainers.Builders;
using Npgsql;
using Testcontainers.PostgreSql;

namespace Cat.IntegrationTesting.PostgreSQL;

/// <summary>
/// A PostgreSQL in a container. The tests of one run share it, and every test class gets its own empty database.
/// </summary>
public sealed class PostgreSQLTestContainer : IAsyncDisposable
{
    /// <summary>
    /// The image that the container starts. The base entities of <c>Cat.EFCore.Extensions.PostgreSQL</c> were first checked by hand on this version.
    /// </summary>
    public const string DefaultImage = "postgres:17";

    private static readonly Lazy<PostgreSQLTestContainer> SharedContainer = new Lazy<PostgreSQLTestContainer>(() => new PostgreSQLTestContainer());

    private readonly string _image;
    private readonly object _gate = new object();
    private Task<PostgreSqlContainer>? _start;

    /// <summary>
    /// Creates a container that starts on the first use.
    /// </summary>
    /// <param name="image">The PostgreSQL image to start.</param>
    public PostgreSQLTestContainer(string image = DefaultImage)
    {
        _image = image ?? throw new ArgumentNullException(nameof(image));
    }

    /// <summary>
    /// Gets the container that every test of the run shares. The first use starts it, and Testcontainers removes it when the run ends.
    /// </summary>
    public static PostgreSQLTestContainer Shared => SharedContainer.Value;

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

        using (var connection = new NpgsqlConnection(master))
        {
            await connection.OpenAsync(cancellationToken).ConfigureAwait(false);
            using var command = connection.CreateCommand();
            command.CommandText = "CREATE DATABASE \"" + name + "\";";
            await command.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false);
        }

        var builder = new NpgsqlConnectionStringBuilder(master) { Database = name };
        return new Database(name, builder.ConnectionString, master);
    }

    /// <summary>
    /// Stops and removes the container.
    /// </summary>
    /// <returns>A task that completes when the container is gone.</returns>
    public async ValueTask DisposeAsync()
    {
        Task<PostgreSqlContainer>? start;
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

    private Task<PostgreSqlContainer> StartAsync()
    {
        lock (_gate)
        {
            // The first caller starts it and the others wait for the same task, also when it failed.
            return _start ??= StartContainerAsync();
        }
    }

    private async Task<PostgreSqlContainer> StartContainerAsync()
    {
        try
        {
            var container = new PostgreSqlBuilder(_image).Build();
            await container.StartAsync().ConfigureAwait(false);
            return container;
        }
        catch (DockerUnavailableException exception)
        {
            throw new CatContainerUnavailableException("The PostgreSQL container could not start. " + exception.Message, exception);
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
            NpgsqlConnection.ClearAllPools();
            using var connection = new NpgsqlConnection(_master);
            await connection.OpenAsync().ConfigureAwait(false);
            using var command = connection.CreateCommand();
            command.CommandText = "DROP DATABASE \"" + Name + "\" WITH (FORCE);";
            await command.ExecuteNonQueryAsync().ConfigureAwait(false);
        }
    }
}
