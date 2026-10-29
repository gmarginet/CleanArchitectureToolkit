<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules')

## PropertyStringMatchesRegexWithPatternValidatorRule\<TModel\> Class

Passes when the text matches the regular expression pattern\. A `null` string passes\.
Fails with [MatchesRegex](CatValidatorErrorDefinitions.MatchesRegex.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.MatchesRegex') otherwise\.

```csharp
internal class PropertyStringMatchesRegexWithPatternValidatorRule<TModel> : Cat.Validators.CatValidatorPropertyRuleBase<TModel, string>
    where TModel : class
```
#### Type parameters

<a name='Cat.Validators.Rules.PropertyStringMatchesRegexWithPatternValidatorRule_TModel_.TModel'></a>

`TModel`

The type being validated\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [Cat\.Validators\.CatValidatorModelRuleAsyncBase&lt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>')[TModel](PropertyStringMatchesRegexWithPatternValidatorRule_TModel_.md#Cat.Validators.Rules.PropertyStringMatchesRegexWithPatternValidatorRule_TModel_.TModel 'Cat\.Validators\.Rules\.PropertyStringMatchesRegexWithPatternValidatorRule\<TModel\>\.TModel')[&gt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>') &#129106; [Cat\.Validators\.CatValidatorPropertyRuleAsyncBase&lt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[TModel](PropertyStringMatchesRegexWithPatternValidatorRule_TModel_.md#Cat.Validators.Rules.PropertyStringMatchesRegexWithPatternValidatorRule_TModel_.TModel 'Cat\.Validators\.Rules\.PropertyStringMatchesRegexWithPatternValidatorRule\<TModel\>\.TModel')[,](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>') &#129106; [Cat\.Validators\.CatValidatorPropertyRuleBase&lt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>')[TModel](PropertyStringMatchesRegexWithPatternValidatorRule_TModel_.md#Cat.Validators.Rules.PropertyStringMatchesRegexWithPatternValidatorRule_TModel_.TModel 'Cat\.Validators\.Rules\.PropertyStringMatchesRegexWithPatternValidatorRule\<TModel\>\.TModel')[,](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>') &#129106; PropertyStringMatchesRegexWithPatternValidatorRule\<TModel\>

| Constructors | |
| :--- | :--- |
| [PropertyStringMatchesRegexWithPatternValidatorRule\(string, RegexOptions\)](PropertyStringMatchesRegexWithPatternValidatorRule_TModel_..ctor.ZNAW54AJIBGOJZ1QODQ16BWL4.md 'Cat\.Validators\.Rules\.PropertyStringMatchesRegexWithPatternValidatorRule\<TModel\>\.PropertyStringMatchesRegexWithPatternValidatorRule\(string, System\.Text\.RegularExpressions\.RegexOptions\)') | Passes when the text matches the regular expression pattern\. A `null` string passes\. Fails with [MatchesRegex](CatValidatorErrorDefinitions.MatchesRegex.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.MatchesRegex') otherwise\. |

| Methods | |
| :--- | :--- |
| [Validate\(string, string, TModel\)](PropertyStringMatchesRegexWithPatternValidatorRule_TModel_.Validate.XCY4K1J7AC8TVNHPK38T063L.md 'Cat\.Validators\.Rules\.PropertyStringMatchesRegexWithPatternValidatorRule\<TModel\>\.Validate\(string, string, TModel\)') | |
