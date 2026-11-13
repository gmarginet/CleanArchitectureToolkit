using System;

namespace Cat.Sql.Cdc;

/// <summary>
/// The change tables were cleaned up past the position of the reader, so changes may be lost.
/// The reader of the table stops and reports unhealthy. See <see cref="CatCdcGapBehavior"/>.
/// </summary>
public class CatCdcGapException : InvalidOperationException
{
    /// <summary>
    /// Creates the exception.
    /// </summary>
    /// <param name="message">What happened.</param>
    public CatCdcGapException(string message) : base(message)
    {
    }
}
