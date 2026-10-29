using System.Linq;
using Cat.Responses.Abstractions;

namespace Cat.Responses;

/// <summary>
/// A reusable definition for one kind of error: a stable code and a message template. Define these once, as static
/// fields, and call <see cref="CreateCatError"/> wherever that error needs to be raised with specific argument values.
/// </summary>
public record CatErrorDefinition
{
    /// <summary>
    /// Creates a definition with the given code and message template.
    /// </summary>
    /// <param name="code">The stable code identifying this kind of error.</param>
    /// <param name="message">The message template. Can contain placeholders filled in when <see cref="CreateCatError"/> is called.</param>
    private CatErrorDefinition(string code, string message)
    {
        Code = code;
        Message = message;
    }

    /// <inheritdoc cref="ICatError.Code" />
    public string Code { get; private set; }

    /// <inheritdoc cref="ICatError.Message" />
    public string Message { get; private set; }

    /// <summary>
    /// Creates an <see cref="ICatError"/> from this definition, with the given values filled into the message's placeholders.
    /// </summary>
    /// <param name="arguments">The values to substitute into the message's placeholders, in order.</param>
    /// <returns>An error carrying this definition's code and message, with <paramref name="arguments"/> attached.</returns>
    public ICatError CreateCatError(params object?[] arguments)
    {
        return CatError.Create(Code, Message, arguments.ToList());
    }

    /// <summary>
    /// Creates a new error definition.
    /// </summary>
    /// <param name="code">The stable code identifying this kind of error.</param>
    /// <param name="message">The message template. Can contain placeholders filled in when <see cref="CreateCatError"/> is called.</param>
    /// <returns>The new error definition.</returns>
    public static CatErrorDefinition Create(string code, string message)
    {
        return new CatErrorDefinition(code, message);
    }
}