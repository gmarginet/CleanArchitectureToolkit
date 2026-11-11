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

    /// <summary>
    /// Creates a new error definition and builds the code from a prefix and a number, as <c>prefix-number</c>.
    /// The prefix is not checked, so you are free to choose your own. CAT itself uses <c>APPLICATION-AREA</c>, like <c>CAT-VAL</c>.
    /// </summary>
    /// <param name="prefix">The prefix of the code, without the closing dash, such as <c>DEM-ORD</c>.</param>
    /// <param name="number">The number of the error. Keep it unique within the prefix.</param>
    /// <param name="message">The message template. Can contain placeholders filled in when <see cref="CreateCatError"/> is called.</param>
    /// <returns>The new error definition, with the code <c>prefix-number</c>.</returns>
    public static CatErrorDefinition Create(string prefix, int number, string message)
    {
        return new CatErrorDefinition($"{prefix}-{number}", message);
    }
}