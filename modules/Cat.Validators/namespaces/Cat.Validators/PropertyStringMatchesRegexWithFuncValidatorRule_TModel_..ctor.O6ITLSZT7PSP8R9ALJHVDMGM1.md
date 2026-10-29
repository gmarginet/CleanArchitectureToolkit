<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules') > [PropertyStringMatchesRegexWithFuncValidatorRule&lt;TModel&gt;](PropertyStringMatchesRegexWithFuncValidatorRule_TModel_.md 'Cat\.Validators\.Rules\.PropertyStringMatchesRegexWithFuncValidatorRule\<TModel\>')

## PropertyStringMatchesRegexWithFuncValidatorRule\(Func\<TModel,Regex\>\) Constructor

Passes when the text matches a regular expression taken from the model\. A `null` string passes\.
Fails with [MatchesRegex](CatValidatorErrorDefinitions.MatchesRegex.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.MatchesRegex') otherwise\.

```csharp
public PropertyStringMatchesRegexWithFuncValidatorRule(System.Func<TModel,System.Text.RegularExpressions.Regex> regexFunc);
```
#### Parameters

<a name='Cat.Validators.Rules.PropertyStringMatchesRegexWithFuncValidatorRule_TModel_.PropertyStringMatchesRegexWithFuncValidatorRule(System.Func_TModel,System.Text.RegularExpressions.Regex_).regexFunc'></a>

`regexFunc` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TModel](PropertyStringMatchesRegexWithFuncValidatorRule_TModel_.md#Cat.Validators.Rules.PropertyStringMatchesRegexWithFuncValidatorRule_TModel_.TModel 'Cat\.Validators\.Rules\.PropertyStringMatchesRegexWithFuncValidatorRule\<TModel\>\.TModel')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Text\.RegularExpressions\.Regex](https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex 'System\.Text\.RegularExpressions\.Regex')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')