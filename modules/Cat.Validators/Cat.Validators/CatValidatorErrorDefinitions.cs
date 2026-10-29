using Cat.Responses;

namespace Cat.Validators;

/// <summary>
/// The codes and message templates of the built-in rules.
/// A message template has named placeholders. The values come in order, with the field name always first.
/// </summary>
public static class CatValidatorErrorDefinitions
{
    private const string ValidatorErrorCodePrefix = "CAT-VAL-";

    /// <summary>
    /// An unknown failure. Code <c>CAT-VAL-1000</c>.
    /// </summary>
    public static readonly CatErrorDefinition Unknown = CatErrorDefinition.Create($"{ValidatorErrorCodePrefix}1000", "Unknown validation error occurred.");

    /// <summary>
    /// The value is <c>null</c> but shouldn't be. Code <c>CAT-VAL-1001</c>.
    /// </summary>
    public static readonly CatErrorDefinition NotNull = CatErrorDefinition.Create($"{ValidatorErrorCodePrefix}1001", "'{propertyName}' should not be Null (Empty).");
    
    /// <summary>
    /// The value should be <c>null</c> but isn't. Code <c>CAT-VAL-1002</c>.
    /// </summary>
    public static readonly CatErrorDefinition Null = CatErrorDefinition.Create($"{ValidatorErrorCodePrefix}1002", "'{propertyName}' should be Null (Empty).");
    
    /// <summary>
    /// The value is empty but shouldn't be. Code <c>CAT-VAL-1003</c>.
    /// </summary>
    public static readonly CatErrorDefinition NotEmpty = CatErrorDefinition.Create($"{ValidatorErrorCodePrefix}1003", "'{propertyName}' should not be empty.");
    
    /// <summary>
    /// The value should be empty but isn't. Code <c>CAT-VAL-1004</c>.
    /// </summary>
    public static readonly CatErrorDefinition Empty = CatErrorDefinition.Create($"{ValidatorErrorCodePrefix}1004", "'{propertyName}' should be empty.");
    
    /// <summary>
    /// The text length is outside the allowed range. Code <c>CAT-VAL-1005</c>.
    /// </summary>
    public static readonly CatErrorDefinition Length = CatErrorDefinition.Create($"{ValidatorErrorCodePrefix}1005", "'{propertyName}' should be between '{minLength}' and '{maxLength}' characters. You entered '{length}' characters.");
    
    /// <summary>
    /// The text length isn't the exact length. Code <c>CAT-VAL-1006</c>.
    /// </summary>
    public static readonly CatErrorDefinition ExactLength = CatErrorDefinition.Create($"{ValidatorErrorCodePrefix}1006", "'{propertyName}' should be '{exactLength}' characters in length. You entered '{length}' characters.");
    
    /// <summary>
    /// The text is longer than the maximum. Code <c>CAT-VAL-1007</c>.
    /// </summary>
    public static readonly CatErrorDefinition MaximumLength = CatErrorDefinition.Create($"{ValidatorErrorCodePrefix}1007", "The length of '{propertyName}' should be '{maxLength}' characters or fewer. You entered '{length}' characters.");
    
    /// <summary>
    /// The text is shorter than the minimum. Code <c>CAT-VAL-1008</c>.
    /// </summary>
    public static readonly CatErrorDefinition MinimumLength = CatErrorDefinition.Create($"{ValidatorErrorCodePrefix}1008", "The length of '{propertyName}' should be at least '{minLength}' characters. You entered '{length}' characters.");
    
    /// <summary>
    /// The text doesn't match the regular expression. Code <c>CAT-VAL-1009</c>.
    /// </summary>
    public static readonly CatErrorDefinition MatchesRegex = CatErrorDefinition.Create($"{ValidatorErrorCodePrefix}1009", "'{propertyName}' is not in the correct format. [regex: {regexPattern}]");
    
    /// <summary>
    /// The value equals the comparison value but shouldn't. Code <c>CAT-VAL-1010</c>.
    /// </summary>
    public static readonly CatErrorDefinition NotEqual = CatErrorDefinition.Create($"{ValidatorErrorCodePrefix}1010", "'{propertyName}' should not be equal to '{comparisonValue}.'");
    
    /// <summary>
    /// The value doesn't equal the comparison value. Code <c>CAT-VAL-1011</c>.
    /// </summary>
    public static readonly CatErrorDefinition Equal = CatErrorDefinition.Create($"{ValidatorErrorCodePrefix}1011", "'{propertyName}' should be equal to '{comparisonValue}'");
    
    /// <summary>
    /// The value isn't less than the comparison value. Code <c>CAT-VAL-1012</c>.
    /// </summary>
    public static readonly CatErrorDefinition LessThan = CatErrorDefinition.Create($"{ValidatorErrorCodePrefix}1012", "'{propertyName}' should be less than '{comparisonValue}'.");
    
    /// <summary>
    /// The value isn't less than or equal to the comparison value. Code <c>CAT-VAL-1013</c>.
    /// </summary>
    public static readonly CatErrorDefinition LessThanOrEqualTo = CatErrorDefinition.Create($"{ValidatorErrorCodePrefix}1013", "'{propertyName}' should be less than or equal to '{comparisonValue}'.");
    
    /// <summary>
    /// The value isn't greater than the comparison value. Code <c>CAT-VAL-1014</c>.
    /// </summary>
    public static readonly CatErrorDefinition GreaterThan = CatErrorDefinition.Create($"{ValidatorErrorCodePrefix}1014", "'{propertyName}' should be greater than '{comparisonValue}'.");
    
    /// <summary>
    /// The value isn't greater than or equal to the comparison value. Code <c>CAT-VAL-1015</c>.
    /// </summary>
    public static readonly CatErrorDefinition GreaterThanOrEqualTo = CatErrorDefinition.Create($"{ValidatorErrorCodePrefix}1015", "'{propertyName}' should be greater than or equal to '{comparisonValue}'.");
    
    /// <summary>
    /// The value isn't between the bounds, bounds included. Code <c>CAT-VAL-1016</c>.
    /// </summary>
    public static readonly CatErrorDefinition InclusiveBetween = CatErrorDefinition.Create($"{ValidatorErrorCodePrefix}1016", "'{propertyName}' should be between '{lowerBound}' and '{upperBound}' (inclusive). You entered '{propertyValue}'.");
    
    /// <summary>
    /// The value isn't between the bounds, bounds excluded. Code <c>CAT-VAL-1017</c>.
    /// </summary>
    public static readonly CatErrorDefinition ExclusiveBetween = CatErrorDefinition.Create($"{ValidatorErrorCodePrefix}1017", "'{propertyName}' should be between '{lowerBound}' and '{upperBound}' (exclusive). You entered '{propertyValue}'.");
}