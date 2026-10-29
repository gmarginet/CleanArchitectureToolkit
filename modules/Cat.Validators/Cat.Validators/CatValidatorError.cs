using System.Collections.Generic;
using Cat.Validators.Abstractions;

namespace Cat.Validators;

/// <summary>
/// Default <see cref="ICatValidatorError"/>.
/// </summary>
public class CatValidatorError : ICatValidatorError
{
    /// <summary>
    /// Creates the error.
    /// </summary>
    /// <param name="code">The stable code of this kind of failure.</param>
    /// <param name="fieldName">The name of the field that failed.</param>
    /// <param name="message">The message template.</param>
    /// <param name="arguments">The values for the message placeholders, in order.</param>
    public CatValidatorError(string code, string fieldName, string message, IList<object?> arguments)
    {
        Code = code;
        FieldName = fieldName;
        Message = message;
        Arguments = arguments;
    }
    
    /// <inheritdoc />
    public string Code { get; }

    /// <inheritdoc />
    public string FieldName { get; set; }

    /// <inheritdoc />
    public string Message { get; }

    /// <inheritdoc />
    public IList<object?> Arguments { get; }

    /// <summary>
    /// Creates an error.
    /// </summary>
    /// <param name="code">The stable code of this kind of failure.</param>
    /// <param name="fieldName">The name of the field that failed.</param>
    /// <param name="message">The message template.</param>
    /// <param name="arguments">The values for the message placeholders, in order.</param>
    /// <returns>The new error.</returns>
    public static CatValidatorError Create(string code, string fieldName, string message, params object?[] arguments)
    {
        return new CatValidatorError(
            code: code,
            fieldName: fieldName,
            message: message,
            arguments: arguments);
    }
}