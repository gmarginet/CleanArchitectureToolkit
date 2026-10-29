using System.Collections.Generic;

namespace Cat.Responses.Abstractions;

/// <summary>
/// Describes one error that caused a response to fail.
/// </summary>
public interface ICatError
{
    /// <summary>
    /// A stable code identifying the kind of error, independent of its message text.
    /// </summary>
    string Code { get; }

    /// <summary>
    /// A human-readable message describing the error. Can contain placeholders filled in by <see cref="Arguments"/>.
    /// </summary>
    string Message { get; }

    /// <summary>
    /// The values to substitute into the message's placeholders, in order.
    /// </summary>
    IList<object?> Arguments { get; }
}