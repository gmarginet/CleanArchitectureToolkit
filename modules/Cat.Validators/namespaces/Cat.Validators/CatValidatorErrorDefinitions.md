<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators](Cat.Validators.md 'Cat\.Validators')

## CatValidatorErrorDefinitions Class

The codes and message templates of the built\-in rules\.
A message template has named placeholders\. The values come in order, with the field name always first\.

```csharp
public static class CatValidatorErrorDefinitions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; CatValidatorErrorDefinitions

| Constructors | |
| :--- | :--- |
| [CatValidatorErrorDefinitions\(\)](CatValidatorErrorDefinitions.CatValidatorErrorDefinitions().md 'Cat\.Validators\.CatValidatorErrorDefinitions\.CatValidatorErrorDefinitions\(\)') | |

| Fields | |
| :--- | :--- |
| [Empty](CatValidatorErrorDefinitions.Empty.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.Empty') | The value should be empty but isn't\. Code `CAT-VAL-1004`\. |
| [Equal](CatValidatorErrorDefinitions.Equal.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.Equal') | The value doesn't equal the comparison value\. Code `CAT-VAL-1011`\. |
| [ExactLength](CatValidatorErrorDefinitions.ExactLength.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.ExactLength') | The text length isn't the exact length\. Code `CAT-VAL-1006`\. |
| [ExclusiveBetween](CatValidatorErrorDefinitions.ExclusiveBetween.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.ExclusiveBetween') | The value isn't between the bounds, bounds excluded\. Code `CAT-VAL-1017`\. |
| [GreaterThan](CatValidatorErrorDefinitions.GreaterThan.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.GreaterThan') | The value isn't greater than the comparison value\. Code `CAT-VAL-1014`\. |
| [GreaterThanOrEqualTo](CatValidatorErrorDefinitions.GreaterThanOrEqualTo.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.GreaterThanOrEqualTo') | The value isn't greater than or equal to the comparison value\. Code `CAT-VAL-1015`\. |
| [InclusiveBetween](CatValidatorErrorDefinitions.InclusiveBetween.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.InclusiveBetween') | The value isn't between the bounds, bounds included\. Code `CAT-VAL-1016`\. |
| [Length](CatValidatorErrorDefinitions.Length.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.Length') | The text length is outside the allowed range\. Code `CAT-VAL-1005`\. |
| [LessThan](CatValidatorErrorDefinitions.LessThan.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.LessThan') | The value isn't less than the comparison value\. Code `CAT-VAL-1012`\. |
| [LessThanOrEqualTo](CatValidatorErrorDefinitions.LessThanOrEqualTo.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.LessThanOrEqualTo') | The value isn't less than or equal to the comparison value\. Code `CAT-VAL-1013`\. |
| [MatchesRegex](CatValidatorErrorDefinitions.MatchesRegex.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.MatchesRegex') | The text doesn't match the regular expression\. Code `CAT-VAL-1009`\. |
| [MaximumLength](CatValidatorErrorDefinitions.MaximumLength.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.MaximumLength') | The text is longer than the maximum\. Code `CAT-VAL-1007`\. |
| [MinimumLength](CatValidatorErrorDefinitions.MinimumLength.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.MinimumLength') | The text is shorter than the minimum\. Code `CAT-VAL-1008`\. |
| [NotEmpty](CatValidatorErrorDefinitions.NotEmpty.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.NotEmpty') | The value is empty but shouldn't be\. Code `CAT-VAL-1003`\. |
| [NotEqual](CatValidatorErrorDefinitions.NotEqual.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.NotEqual') | The value equals the comparison value but shouldn't\. Code `CAT-VAL-1010`\. |
| [NotNull](CatValidatorErrorDefinitions.NotNull.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.NotNull') | The value is `null` but shouldn't be\. Code `CAT-VAL-1001`\. |
| [Null](CatValidatorErrorDefinitions.Null.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.Null') | The value should be `null` but isn't\. Code `CAT-VAL-1002`\. |
| [Unknown](CatValidatorErrorDefinitions.Unknown.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.Unknown') | An unknown failure\. Code `CAT-VAL-1000`\. |
| [ValidatorErrorCodePrefix](CatValidatorErrorDefinitions.ValidatorErrorCodePrefix.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.ValidatorErrorCodePrefix') | |
