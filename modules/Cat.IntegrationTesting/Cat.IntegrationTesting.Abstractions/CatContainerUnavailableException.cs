using System;

namespace Cat.IntegrationTesting;

/// <summary>
/// Thrown when the test container cannot start because Docker is not available.
/// </summary>
public sealed class CatContainerUnavailableException : Exception
{
    /// <summary>
    /// Creates the exception.
    /// </summary>
    /// <param name="message">What went wrong.</param>
    /// <param name="innerException">The error that Docker or the container library reported.</param>
    public CatContainerUnavailableException(string message, Exception? innerException = null)
        : base(message, innerException)
    {
    }
}
