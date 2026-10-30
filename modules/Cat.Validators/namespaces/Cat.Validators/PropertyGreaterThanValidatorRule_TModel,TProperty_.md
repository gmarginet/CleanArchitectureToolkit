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

|&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[CAT.VALIDATORS](../../README.md)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Validators Assembly](index.md 'index') >> [Cat\.Validators\.Rules Namespace](Cat.Validators.Rules.md 'Cat\.Validators\.Rules')

## PropertyGreaterThanValidatorRule\<TModel,TProperty\> Class

Passes when the value is greater than the given value\.
Fails with [GreaterThan](CatValidatorErrorDefinitions.GreaterThan.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.GreaterThan') otherwise\.

```csharp
internal class PropertyGreaterThanValidatorRule<TModel,TProperty> : Cat.Validators.CatValidatorPropertyRuleBase<TModel, TProperty>
    where TModel : class
    where TProperty : System.IComparable<TProperty>, System.IComparable
```
#### Type parameters

<a name='Cat.Validators.Rules.PropertyGreaterThanValidatorRule_TModel,TProperty_.TModel'></a>

`TModel`

The type being validated\.

<a name='Cat.Validators.Rules.PropertyGreaterThanValidatorRule_TModel,TProperty_.TProperty'></a>

`TProperty`

The type of the property\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [Cat\.Validators\.CatValidatorModelRuleAsyncBase&lt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>')[TModel](PropertyGreaterThanValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyGreaterThanValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyGreaterThanValidatorRule\<TModel,TProperty\>\.TModel')[&gt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>') → [Cat\.Validators\.CatValidatorPropertyRuleAsyncBase&lt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[TModel](PropertyGreaterThanValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyGreaterThanValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyGreaterThanValidatorRule\<TModel,TProperty\>\.TModel')[,](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[TProperty](PropertyGreaterThanValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyGreaterThanValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyGreaterThanValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>') → [Cat\.Validators\.CatValidatorPropertyRuleBase&lt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>')[TModel](PropertyGreaterThanValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyGreaterThanValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyGreaterThanValidatorRule\<TModel,TProperty\>\.TModel')[,](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>')[TProperty](PropertyGreaterThanValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyGreaterThanValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyGreaterThanValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>') → PropertyGreaterThanValidatorRule\<TModel,TProperty\>

| Constructors | |
| :--- | :--- |
| [PropertyGreaterThanValidatorRule\(TProperty\)](PropertyGreaterThanValidatorRule_TModel,TProperty_..ctor.1S1GXDFZB4LZOP8R495080CLE.md 'Cat\.Validators\.Rules\.PropertyGreaterThanValidatorRule\<TModel,TProperty\>\.PropertyGreaterThanValidatorRule\(TProperty\)') | Passes when the value is greater than the given value\. Fails with [GreaterThan](CatValidatorErrorDefinitions.GreaterThan.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.GreaterThan') otherwise\. |

| Methods | |
| :--- | :--- |
| [Validate\(TProperty, string, TModel\)](PropertyGreaterThanValidatorRule_TModel,TProperty_.Validate.CR6WMBKZNPL2U97DXNGARWS77.md 'Cat\.Validators\.Rules\.PropertyGreaterThanValidatorRule\<TModel,TProperty\>\.Validate\(TProperty, string, TModel\)') | |
