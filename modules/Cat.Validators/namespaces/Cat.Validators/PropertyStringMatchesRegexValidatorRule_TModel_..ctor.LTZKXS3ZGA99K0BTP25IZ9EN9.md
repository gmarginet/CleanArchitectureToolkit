<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules') > [PropertyStringMatchesRegexValidatorRule&lt;TModel&gt;](PropertyStringMatchesRegexValidatorRule_TModel_.md 'Cat\.Validators\.Rules\.PropertyStringMatchesRegexValidatorRule\<TModel\>')

## PropertyStringMatchesRegexValidatorRule\(Regex\) Constructor

Passes when the text matches the regular expression\. A `null` string passes\.
Fails with [MatchesRegex](CatValidatorErrorDefinitions.MatchesRegex.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.MatchesRegex') otherwise\.

```csharp
public PropertyStringMatchesRegexValidatorRule(System.Text.RegularExpressions.Regex regex);
```
#### Parameters

<a name='Cat.Validators.Rules.PropertyStringMatchesRegexValidatorRule_TModel_.PropertyStringMatchesRegexValidatorRule(System.Text.RegularExpressions.Regex).regex'></a>

`regex` [System\.Text\.RegularExpressions\.Regex](https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex 'System\.Text\.RegularExpressions\.Regex')