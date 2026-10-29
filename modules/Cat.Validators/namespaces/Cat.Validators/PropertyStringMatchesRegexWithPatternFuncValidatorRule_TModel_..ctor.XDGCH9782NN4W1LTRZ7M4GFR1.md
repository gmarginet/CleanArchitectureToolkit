<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules') > [PropertyStringMatchesRegexWithPatternFuncValidatorRule&lt;TModel&gt;](PropertyStringMatchesRegexWithPatternFuncValidatorRule_TModel_.md 'Cat\.Validators\.Rules\.PropertyStringMatchesRegexWithPatternFuncValidatorRule\<TModel\>')

## PropertyStringMatchesRegexWithPatternFuncValidatorRule\(Func\<TModel,string\>, RegexOptions\) Constructor

Passes when the text matches a regular expression pattern taken from the model\. A `null` string passes\.
Fails with [MatchesRegex](CatValidatorErrorDefinitions.MatchesRegex.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.MatchesRegex') otherwise\.

```csharp
public PropertyStringMatchesRegexWithPatternFuncValidatorRule(System.Func<TModel,string> regexPatternFunc, System.Text.RegularExpressions.RegexOptions options=System.Text.RegularExpressions.RegexOptions.None);
```
#### Parameters

<a name='Cat.Validators.Rules.PropertyStringMatchesRegexWithPatternFuncValidatorRule_TModel_.PropertyStringMatchesRegexWithPatternFuncValidatorRule(System.Func_TModel,string_,System.Text.RegularExpressions.RegexOptions).regexPatternFunc'></a>

`regexPatternFunc` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TModel](PropertyStringMatchesRegexWithPatternFuncValidatorRule_TModel_.md#Cat.Validators.Rules.PropertyStringMatchesRegexWithPatternFuncValidatorRule_TModel_.TModel 'Cat\.Validators\.Rules\.PropertyStringMatchesRegexWithPatternFuncValidatorRule\<TModel\>\.TModel')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

<a name='Cat.Validators.Rules.PropertyStringMatchesRegexWithPatternFuncValidatorRule_TModel_.PropertyStringMatchesRegexWithPatternFuncValidatorRule(System.Func_TModel,string_,System.Text.RegularExpressions.RegexOptions).options'></a>

`options` [System\.Text\.RegularExpressions\.RegexOptions](https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regexoptions 'System\.Text\.RegularExpressions\.RegexOptions')