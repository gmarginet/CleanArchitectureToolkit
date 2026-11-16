using System.Data.Common;

namespace Cat.Dapper.Abstractions;

/// <summary>
/// Creates database connections. A database project registers one factory, as a singleton, with the connection string.
/// </summary>
public interface ICatDbConnectionFactory
{
    /// <summary>
    /// Creates a new connection. The connection is closed, and the caller owns it and disposes it.
    /// </summary>
    /// <returns>A new, closed connection.</returns>
    DbConnection CreateConnection();
}
