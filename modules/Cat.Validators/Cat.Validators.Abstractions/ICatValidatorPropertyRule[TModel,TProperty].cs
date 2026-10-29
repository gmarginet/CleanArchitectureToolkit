namespace Cat.Validators.Abstractions;

/// <summary>
/// A rule that checks one property of a model.
/// </summary>
/// <typeparam name="TModel">The type being validated.</typeparam>
/// <typeparam name="TProperty">The type of the property.</typeparam>
public interface ICatValidatorPropertyRule<TModel, TProperty>
    : ICatValidatorModelRule<TModel>
    where TModel : class
{
    /// <summary>
    /// Replaces the field name in the errors. Leave it <c>null</c> to use the property name.
    /// </summary>
    string? FieldName { get; set; }

    /// <summary>
    /// Replaces the error code. Leave it <c>null</c> to use the code of the rule.
    /// </summary>
    string? ErrorCode { get; set; }

    /// <summary>
    /// Replaces the error message. Leave it <c>null</c> to use the message of the rule.
    /// </summary>
    string? ErrorMessage { get; set; }
}