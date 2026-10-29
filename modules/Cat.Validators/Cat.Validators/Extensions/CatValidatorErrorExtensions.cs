using System.Linq;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Cat.Validators.Abstractions;

namespace Cat.Validators.Extensions;

/// <summary>
/// Conversion helpers for validator errors.
/// </summary>
public static class CatValidatorErrorExtensions
{
    /// <summary>
    /// Converts a validator error to a response error.
    /// The field name becomes the first argument, so the message placeholders line up.
    /// </summary>
    /// <param name="error">The error to convert.</param>
    /// <returns>The response error.</returns>
    public static ICatError ToCatError(this ICatValidatorError error)
    {
        var args = error.Arguments.Prepend(error.FieldName).ToList();
        return CatError.Create(error.Code, error.Message, args);
    }
}