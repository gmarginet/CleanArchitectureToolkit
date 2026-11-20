using System;

namespace Cat.IntegrationTesting;

/// <summary>
/// An empty database in a test container. It belongs to one test class. Disposing it drops the database.
/// </summary>
public interface ICatTestDatabase : IAsyncDisposable
{
    /// <summary>
    /// Gets the name of the database.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Gets the connection string of the database.
    /// </summary>
    string ConnectionString { get; }
}
