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

## PropertyStringLengthValidatorRule\<TModel,TProperty\> Class

Passes when the text length is between the minimum and the maximum\. A `null` string passes\.
Fails with [Length](CatValidatorErrorDefinitions.Length.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.Length') otherwise\.

```csharp
internal class PropertyStringLengthValidatorRule<TModel,TProperty> : Cat.Validators.CatValidatorPropertyRuleBase<TModel, TProperty>
    where TModel : class
    where TProperty : System.Collections.Generic.IEnumerable<char>?
```
#### Type parameters

<a name='Cat.Validators.Rules.PropertyStringLengthValidatorRule_TModel,TProperty_.TModel'></a>

`TModel`

The type being validated\.

<a name='Cat.Validators.Rules.PropertyStringLengthValidatorRule_TModel,TProperty_.TProperty'></a>

`TProperty`

The type of the property, a string or a sequence of characters\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [Cat\.Validators\.CatValidatorModelRuleAsyncBase&lt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>')[TModel](PropertyStringLengthValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyStringLengthValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyStringLengthValidatorRule\<TModel,TProperty\>\.TModel')[&gt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>') → [Cat\.Validators\.CatValidatorPropertyRuleAsyncBase&lt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[TModel](PropertyStringLengthValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyStringLengthValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyStringLengthValidatorRule\<TModel,TProperty\>\.TModel')[,](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[TProperty](PropertyStringLengthValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyStringLengthValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyStringLengthValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>') → [Cat\.Validators\.CatValidatorPropertyRuleBase&lt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>')[TModel](PropertyStringLengthValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyStringLengthValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyStringLengthValidatorRule\<TModel,TProperty\>\.TModel')[,](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>')[TProperty](PropertyStringLengthValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyStringLengthValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyStringLengthValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>') → PropertyStringLengthValidatorRule\<TModel,TProperty\>

| Constructors | |
| :--- | :--- |
| [PropertyStringLengthValidatorRule\(int, int\)](PropertyStringLengthValidatorRule_TModel,TProperty_..ctor.ZADHCKGFM84WF33O95Z90O4J9.md 'Cat\.Validators\.Rules\.PropertyStringLengthValidatorRule\<TModel,TProperty\>\.PropertyStringLengthValidatorRule\(int, int\)') | Passes when the text length is between the minimum and the maximum\. A `null` string passes\. Fails with [Length](CatValidatorErrorDefinitions.Length.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.Length') otherwise\. |

| Methods | |
| :--- | :--- |
| [Validate\(TProperty, string, TModel\)](PropertyStringLengthValidatorRule_TModel,TProperty_.Validate.BK98QGAFXMFYOVADNR5AOSI33.md 'Cat\.Validators\.Rules\.PropertyStringLengthValidatorRule\<TModel,TProperty\>\.Validate\(TProperty, string, TModel\)') | |
