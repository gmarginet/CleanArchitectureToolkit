using System.Collections.Generic;
using Cat.Responses.Abstractions;

namespace Cat.Responses;

/// <summary>
/// The default <see cref="ICatError"/> implementation. Create instances through its static <c>Create</c> overloads,
/// or build one from a reusable <see cref="CatErrorDefinition"/> instead.
/// </summary>
public record CatError : ICatError
{
    /// <summary>
    /// Creates an error with the given code, message, and arguments.
    /// </summary>
    /// <param name="code">The stable code identifying this kind of error.</param>
    /// <param name="message">The error message. Can contain placeholders filled in by <paramref name="arguments"/>.</param>
    /// <param name="arguments">The values to substitute into the message's placeholders, in order.</param>
    private CatError(string code, string message, object?[] arguments)
    {
        Code = code;
        Message = message;
        Arguments = [.. arguments];
    }

    /// <inheritdoc />
    public string Code { get; private set; }

    /// <inheritdoc />
    public string Message { get; private set; }

    /// <inheritdoc />
    public IList<object?> Arguments { get; private set; }

    /// <summary>
    /// Creates an error with the given code, message, and arguments.
    /// </summary>
    /// <param name="code">The stable code identifying this kind of error.</param>
    /// <param name="message">The error message. Can contain placeholders filled in by <paramref name="arguments"/>.</param>
    /// <param name="arguments">The values to substitute into the message's placeholders, in order.</param>
    /// <returns>The new error.</returns>
    public static CatError Create(string code, string message, params object?[] arguments)
    {
        var temp = new CatError(code, message, arguments);
        return temp;
    }

    /// <summary>
    /// Creates an error with the given code, message, and arguments.
    /// </summary>
    /// <param name="code">The stable code identifying this kind of error.</param>
    /// <param name="message">The error message. Can contain placeholders filled in by <paramref name="argumentList"/>.</param>
    /// <param name="argumentList">The values to substitute into the message's placeholders, in order.</param>
    /// <returns>The new error.</returns>
    public static CatError Create(string code, string message, List<object?> argumentList)
    {
        return new CatError(code, message, [.. argumentList]);
    }
}