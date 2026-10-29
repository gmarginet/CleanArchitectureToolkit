<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules') > [PropertyStringMatchesRegexWithPatternValidatorRule&lt;TModel&gt;](PropertyStringMatchesRegexWithPatternValidatorRule_TModel_.md 'Cat\.Validators\.Rules\.PropertyStringMatchesRegexWithPatternValidatorRule\<TModel\>')

## PropertyStringMatchesRegexWithPatternValidatorRule\(string, RegexOptions\) Constructor

Passes when the text matches the regular expression pattern\. A `null` string passes\.
Fails with [MatchesRegex](CatValidatorErrorDefinitions.MatchesRegex.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.MatchesRegex') otherwise\.

```csharp
public PropertyStringMatchesRegexWithPatternValidatorRule(string regexPattern, System.Text.RegularExpressions.RegexOptions options=System.Text.RegularExpressions.RegexOptions.None);
```
#### Parameters

<a name='Cat.Validators.Rules.PropertyStringMatchesRegexWithPatternValidatorRule_TModel_.PropertyStringMatchesRegexWithPatternValidatorRule(string,System.Text.RegularExpressions.RegexOptions).regexPattern'></a>

`regexPattern` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='Cat.Validators.Rules.PropertyStringMatchesRegexWithPatternValidatorRule_TModel_.PropertyStringMatchesRegexWithPatternValidatorRule(string,System.Text.RegularExpressions.RegexOptions).options'></a>

`options` [System\.Text\.RegularExpressions\.RegexOptions](https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regexoptions 'System\.Text\.RegularExpressions\.RegexOptions')