using System.Collections.Generic;

namespace Cat.Validators.Abstractions;

/// <summary>
/// One validation failure.
/// </summary>
public interface ICatValidatorError
{
    /// <summary>
    /// The stable code of this kind of failure, like <c>CAT-VAL-1001</c>.
    /// </summary>
    string Code { get; }

    /// <summary>
    /// The name of the field that failed. Nested validation prefixes it, like <c>Todo.Title</c> or <c>Items[0].Title</c>.
    /// </summary>
    string FieldName { get; set; }

    /// <summary>
    /// The message template. Its placeholders match <see cref="Arguments"/>.
    /// </summary>
    string Message { get; }

    /// <summary>
    /// The values for the message placeholders, in order.
    /// </summary>
    IList<object?> Arguments { get; }
}