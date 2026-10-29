<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules')

## PropertyStringMatchesRegexWithPatternFuncValidatorRule\<TModel\> Class

Passes when the text matches a regular expression pattern taken from the model\. A `null` string passes\.
Fails with [MatchesRegex](CatValidatorErrorDefinitions.MatchesRegex.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.MatchesRegex') otherwise\.

```csharp
internal class PropertyStringMatchesRegexWithPatternFuncValidatorRule<TModel> : Cat.Validators.CatValidatorPropertyRuleBase<TModel, string>
    where TModel : class
```
#### Type parameters

<a name='Cat.Validators.Rules.PropertyStringMatchesRegexWithPatternFuncValidatorRule_TModel_.TModel'></a>

`TModel`

The type being validated\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [Cat\.Validators\.CatValidatorModelRuleAsyncBase&lt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>')[TModel](PropertyStringMatchesRegexWithPatternFuncValidatorRule_TModel_.md#Cat.Validators.Rules.PropertyStringMatchesRegexWithPatternFuncValidatorRule_TModel_.TModel 'Cat\.Validators\.Rules\.PropertyStringMatchesRegexWithPatternFuncValidatorRule\<TModel\>\.TModel')[&gt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>') &#129106; [Cat\.Validators\.CatValidatorPropertyRuleAsyncBase&lt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[TModel](PropertyStringMatchesRegexWithPatternFuncValidatorRule_TModel_.md#Cat.Validators.Rules.PropertyStringMatchesRegexWithPatternFuncValidatorRule_TModel_.TModel 'Cat\.Validators\.Rules\.PropertyStringMatchesRegexWithPatternFuncValidatorRule\<TModel\>\.TModel')[,](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>') &#129106; [Cat\.Validators\.CatValidatorPropertyRuleBase&lt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>')[TModel](PropertyStringMatchesRegexWithPatternFuncValidatorRule_TModel_.md#Cat.Validators.Rules.PropertyStringMatchesRegexWithPatternFuncValidatorRule_TModel_.TModel 'Cat\.Validators\.Rules\.PropertyStringMatchesRegexWithPatternFuncValidatorRule\<TModel\>\.TModel')[,](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>') &#129106; PropertyStringMatchesRegexWithPatternFuncValidatorRule\<TModel\>

| Constructors | |
| :--- | :--- |
| [PropertyStringMatchesRegexWithPatternFuncValidatorRule\(Func&lt;TModel,string&gt;, RegexOptions\)](PropertyStringMatchesRegexWithPatternFuncValidatorRule_TModel_..ctor.XDGCH9782NN4W1LTRZ7M4GFR1.md 'Cat\.Validators\.Rules\.PropertyStringMatchesRegexWithPatternFuncValidatorRule\<TModel\>\.PropertyStringMatchesRegexWithPatternFuncValidatorRule\(System\.Func\<TModel,string\>, System\.Text\.RegularExpressions\.RegexOptions\)') | Passes when the text matches a regular expression pattern taken from the model\. A `null` string passes\. Fails with [MatchesRegex](CatValidatorErrorDefinitions.MatchesRegex.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.MatchesRegex') otherwise\. |

| Methods | |
| :--- | :--- |
| [Validate\(string, string, TModel\)](PropertyStringMatchesRegexWithPatternFuncValidatorRule_TModel_.Validate.8YXVHTHDKK3D5KTIJT42VWBG1.md 'Cat\.Validators\.Rules\.PropertyStringMatchesRegexWithPatternFuncValidatorRule\<TModel\>\.Validate\(string, string, TModel\)') | |
