<link href="../../../../resources/styles/style.css" rel="stylesheet"/>
<table>
    <tr>
        <td colspan='6' style='text-align: center; font-weight: bold; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>
             Clean Architecture Toolkit for .NET
        </td>
    </tr>
    <tr>
        <td colspan='5' style='padding: 0; vertical-align: middle; border: none;'>
            Clean Architecture Toolkit is a clean, modular architecture foundation for .NET applications.<br>
            It embraces SOLID principles and focuses on maintainability, testability, and scalability through clear boundaries and pluggable design.</td>
        <td style='padding: 0; border: none;' width='220'>
            <img src='../../../../resources/logo/CatLogo.svg' alt='' width='200' style='padding: 15px; float: right; background: #121314; border-radius: 10px'/>
        </td>
    </tr>
    <tr>
        <td colspan='6' markdown='1' style='padding-left: 0; padding-right: 0; padding-top: 15px; padding-bottom: 0; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.VALIDATORS](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Validators Assembly](index.md 'index') >> [Cat\.Validators\.Rules Namespace](Cat.Validators.Rules.md 'Cat\.Validators\.Rules')

## PropertyStringMatchesRegexWithFuncValidatorRule\<TModel,TProperty\> Class

Passes when the text matches a regular expression taken from the model\. A `null` string passes\.
Fails with [MatchesRegex](CatValidatorErrorDefinitions.MatchesRegex.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.MatchesRegex') otherwise\.

```csharp
internal class PropertyStringMatchesRegexWithFuncValidatorRule<TModel,TProperty> : Cat.Validators.CatValidatorPropertyRuleBase<TModel, TProperty>
    where TModel : class
    where TProperty : System.Collections.Generic.IEnumerable<char>?
```
#### Type parameters

<a name='Cat.Validators.Rules.PropertyStringMatchesRegexWithFuncValidatorRule_TModel,TProperty_.TModel'></a>

`TModel`

The type being validated\.

<a name='Cat.Validators.Rules.PropertyStringMatchesRegexWithFuncValidatorRule_TModel,TProperty_.TProperty'></a>

`TProperty`

The type of the property, a string or a sequence of characters\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [Cat\.Validators\.CatValidatorModelRuleAsyncBase&lt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>')[TModel](PropertyStringMatchesRegexWithFuncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyStringMatchesRegexWithFuncValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyStringMatchesRegexWithFuncValidatorRule\<TModel,TProperty\>\.TModel')[&gt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>') → [Cat\.Validators\.CatValidatorPropertyRuleAsyncBase&lt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[TModel](PropertyStringMatchesRegexWithFuncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyStringMatchesRegexWithFuncValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyStringMatchesRegexWithFuncValidatorRule\<TModel,TProperty\>\.TModel')[,](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[TProperty](PropertyStringMatchesRegexWithFuncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyStringMatchesRegexWithFuncValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyStringMatchesRegexWithFuncValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>') → [Cat\.Validators\.CatValidatorPropertyRuleBase&lt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>')[TModel](PropertyStringMatchesRegexWithFuncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyStringMatchesRegexWithFuncValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyStringMatchesRegexWithFuncValidatorRule\<TModel,TProperty\>\.TModel')[,](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>')[TProperty](PropertyStringMatchesRegexWithFuncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyStringMatchesRegexWithFuncValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyStringMatchesRegexWithFuncValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>') → PropertyStringMatchesRegexWithFuncValidatorRule\<TModel,TProperty\>

| Constructors | |
| :--- | :--- |
| [PropertyStringMatchesRegexWithFuncValidatorRule\(Func&lt;TModel,Regex&gt;\)](PropertyStringMatchesRegexWithFuncValidatorRule_TModel,TProperty_..ctor.7W8UQOBD4DV3EC8A29ZJY5DOD.md 'Cat\.Validators\.Rules\.PropertyStringMatchesRegexWithFuncValidatorRule\<TModel,TProperty\>\.PropertyStringMatchesRegexWithFuncValidatorRule\(System\.Func\<TModel,System\.Text\.RegularExpressions\.Regex\>\)') | Passes when the text matches a regular expression taken from the model\. A `null` string passes\. Fails with [MatchesRegex](CatValidatorErrorDefinitions.MatchesRegex.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.MatchesRegex') otherwise\. |

| Methods | |
| :--- | :--- |
| [Validate\(TProperty, string, TModel\)](PropertyStringMatchesRegexWithFuncValidatorRule_TModel,TProperty_.Validate.2IARFMHO66KAYZ7S5ODONNHYA.md 'Cat\.Validators\.Rules\.PropertyStringMatchesRegexWithFuncValidatorRule\<TModel,TProperty\>\.Validate\(TProperty, string, TModel\)') | |
