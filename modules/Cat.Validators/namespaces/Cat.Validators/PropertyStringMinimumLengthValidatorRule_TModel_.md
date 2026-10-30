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

## PropertyStringMinimumLengthValidatorRule\<TModel\> Class

Passes when the text is not shorter than the minimum\. A `null` string passes\.
Fails with [MinimumLength](CatValidatorErrorDefinitions.MinimumLength.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.MinimumLength') otherwise\.

```csharp
internal class PropertyStringMinimumLengthValidatorRule<TModel> : Cat.Validators.CatValidatorPropertyRuleBase<TModel, string>
    where TModel : class
```
#### Type parameters

<a name='Cat.Validators.Rules.PropertyStringMinimumLengthValidatorRule_TModel_.TModel'></a>

`TModel`

The type being validated\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [Cat\.Validators\.CatValidatorModelRuleAsyncBase&lt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>')[TModel](PropertyStringMinimumLengthValidatorRule_TModel_.md#Cat.Validators.Rules.PropertyStringMinimumLengthValidatorRule_TModel_.TModel 'Cat\.Validators\.Rules\.PropertyStringMinimumLengthValidatorRule\<TModel\>\.TModel')[&gt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>') → [Cat\.Validators\.CatValidatorPropertyRuleAsyncBase&lt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[TModel](PropertyStringMinimumLengthValidatorRule_TModel_.md#Cat.Validators.Rules.PropertyStringMinimumLengthValidatorRule_TModel_.TModel 'Cat\.Validators\.Rules\.PropertyStringMinimumLengthValidatorRule\<TModel\>\.TModel')[,](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>') → [Cat\.Validators\.CatValidatorPropertyRuleBase&lt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>')[TModel](PropertyStringMinimumLengthValidatorRule_TModel_.md#Cat.Validators.Rules.PropertyStringMinimumLengthValidatorRule_TModel_.TModel 'Cat\.Validators\.Rules\.PropertyStringMinimumLengthValidatorRule\<TModel\>\.TModel')[,](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>') → PropertyStringMinimumLengthValidatorRule\<TModel\>

| Constructors | |
| :--- | :--- |
| [PropertyStringMinimumLengthValidatorRule\(int\)](PropertyStringMinimumLengthValidatorRule_TModel_..ctor.2EJ6VLPI864HXLA21TSKTU5DE.md 'Cat\.Validators\.Rules\.PropertyStringMinimumLengthValidatorRule\<TModel\>\.PropertyStringMinimumLengthValidatorRule\(int\)') | Passes when the text is not shorter than the minimum\. A `null` string passes\. Fails with [MinimumLength](CatValidatorErrorDefinitions.MinimumLength.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.MinimumLength') otherwise\. |

| Methods | |
| :--- | :--- |
| [Validate\(string, string, TModel\)](PropertyStringMinimumLengthValidatorRule_TModel_.Validate.HAJQRN3XRLY3IQB9DY4W0Q1O1.md 'Cat\.Validators\.Rules\.PropertyStringMinimumLengthValidatorRule\<TModel\>\.Validate\(string, string, TModel\)') | |
