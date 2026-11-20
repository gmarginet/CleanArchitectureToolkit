using System;
using System.Threading;
using System.Threading.Tasks;
using DotNet.Testcontainers.Builders;
using MySqlConnector;
using Testcontainers.MySql;

namespace Cat.IntegrationTesting.MySql;

/// <summary>
/// A MySQL in a container. The tests of one run share it, and every test class gets its own empty database.
/// </summary>
public sealed class MySqlTestContainer : IAsyncDisposable
{
    /// <summary>
    /// The image that the container starts. The paging and the error checks of the MySQL modules are tested on this version.
    /// </summary>
    public const string DefaultImage = "mysql:8.4";

    private static readonly Lazy<MySqlTestContainer> SharedContainer = new Lazy<MySqlTestContainer>(() => new MySqlTestContainer());

    private readonly string _image;
    private readonly object _gate = new object();
    private Task<MySqlContainer>? _start;

    /// <summary>
    /// Creates a container that starts on the first use.
    /// </summary>
    /// <param name="image">The MySQL image to start.</param>
    public MySqlTestContainer(string image = DefaultImage)
    {
        _image = image ?? throw new ArgumentNullException(nameof(image));
    }

    /// <summary>
    /// Gets the container that every test of the run shares. The first use starts it, and Testcontainers removes it when the run ends.
    /// </summary>
    public static MySqlTestContainer Shared => SharedContainer.Value;

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

        using (var connection = new MySqlConnection(master))
        {
            await connection.OpenAsync(cancellationToken).ConfigureAwait(false);
            using var command = connection.CreateCommand();
            command.CommandText = "CREATE DATABASE `" + name + "`;";
            await command.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false);
        }

        var builder = new MySqlConnectionStringBuilder(master) { Database = name };
        return new Database(name, builder.ConnectionString, master);
    }

    /// <summary>
    /// Stops and removes the container.
    /// </summary>
    /// <returns>A task that completes when the container is gone.</returns>
    public async ValueTask DisposeAsync()
    {
        Task<MySqlContainer>? start;
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

    private Task<MySqlContainer> StartAsync()
    {
        lock (_gate)
        {
            // The first caller starts it and the others wait for the same task, also when it failed.
            return _start ??= StartContainerAsync();
        }
    }

    private async Task<MySqlContainer> StartContainerAsync()
    {
        try
        {
            // The root user can create and drop the databases of the test classes. The container is thrown away after the run.
            var container = new MySqlBuilder(_image).WithUsername("root").WithPassword("mysql").Build();
            await container.StartAsync().ConfigureAwait(false);
            return container;
        }
        catch (DockerUnavailableException exception)
        {
            throw new CatContainerUnavailableException("The MySQL container could not start. " + exception.Message, exception);
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
            MySqlConnection.ClearAllPools();
            using var connection = new MySqlConnection(_master);
            await connection.OpenAsync().ConfigureAwait(false);
            using var command = connection.CreateCommand();
            command.CommandText = "DROP DATABASE `" + Name + "`;";
            await command.ExecuteNonQueryAsync().ConfigureAwait(false);
        }
    }
}
