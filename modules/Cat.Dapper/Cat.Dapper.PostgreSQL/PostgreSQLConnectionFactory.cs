using System;
using System.Data.Common;
using Cat.Dapper.Abstractions;
using Npgsql;

namespace Cat.Dapper.PostgreSQL;

/// <summary>
/// Creates PostgreSQL connections for one connection string.
/// </summary>
public sealed class PostgreSQLConnectionFactory : ICatDbConnectionFactory
{
    private readonly string _connectionString;

    /// <summary>
    /// Creates the factory.
    /// </summary>
    /// <param name="connectionString">The connection string of the database.</param>
    /// <exception cref="ArgumentException">Thrown when <paramref name="connectionString"/> is <c>null</c> or empty.</exception>
    public PostgreSQLConnectionFactory(string connectionString)
    {
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new ArgumentException("The connection string is empty.", nameof(connectionString));
        }

        _connectionString = connectionString;
    }

    /// <inheritdoc />
    public DbConnection CreateConnection() => new NpgsqlConnection(_connectionString);
}
