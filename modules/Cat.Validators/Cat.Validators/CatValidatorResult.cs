using System.Collections.Generic;
using Cat.Validators.Abstractions;

namespace Cat.Validators;

/// <summary>
/// Helpers for returning the outcome of a rule.
/// </summary>
public class CatValidatorResult
{
    /// <summary>
    /// Creates the outcome of a rule that found nothing wrong.
    /// </summary>
    /// <returns>An empty list.</returns>
    public static List<ICatValidatorError> Valid() => [];

    /// <summary>
    /// Creates the outcome of a rule that found failures.
    /// </summary>
    /// <param name="errorDetails">The failures found.</param>
    /// <returns>A list holding the failures.</returns>
    public static List<ICatValidatorError> Invalid(params ICatValidatorError[] errorDetails) => [..errorDetails];
}