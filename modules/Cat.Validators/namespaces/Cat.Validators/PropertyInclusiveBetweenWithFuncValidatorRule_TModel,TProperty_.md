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

## PropertyInclusiveBetweenWithFuncValidatorRule\<TModel,TProperty\> Class

Passes when the value is between the bounds, bounds included\.
Both bounds come from the model\.
Fails with [InclusiveBetween](CatValidatorErrorDefinitions.InclusiveBetween.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.InclusiveBetween') otherwise\.

```csharp
internal class PropertyInclusiveBetweenWithFuncValidatorRule<TModel,TProperty> : Cat.Validators.CatValidatorPropertyRuleBase<TModel, TProperty>
    where TModel : class
    where TProperty : System.IComparable<TProperty>, System.IComparable
```
#### Type parameters

<a name='Cat.Validators.Rules.PropertyInclusiveBetweenWithFuncValidatorRule_TModel,TProperty_.TModel'></a>

`TModel`

The type being validated\.

<a name='Cat.Validators.Rules.PropertyInclusiveBetweenWithFuncValidatorRule_TModel,TProperty_.TProperty'></a>

`TProperty`

The type of the property\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [Cat\.Validators\.CatValidatorModelRuleAsyncBase&lt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>')[TModel](PropertyInclusiveBetweenWithFuncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyInclusiveBetweenWithFuncValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyInclusiveBetweenWithFuncValidatorRule\<TModel,TProperty\>\.TModel')[&gt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>') → [Cat\.Validators\.CatValidatorPropertyRuleAsyncBase&lt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[TModel](PropertyInclusiveBetweenWithFuncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyInclusiveBetweenWithFuncValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyInclusiveBetweenWithFuncValidatorRule\<TModel,TProperty\>\.TModel')[,](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[TProperty](PropertyInclusiveBetweenWithFuncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyInclusiveBetweenWithFuncValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyInclusiveBetweenWithFuncValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>') → [Cat\.Validators\.CatValidatorPropertyRuleBase&lt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>')[TModel](PropertyInclusiveBetweenWithFuncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyInclusiveBetweenWithFuncValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyInclusiveBetweenWithFuncValidatorRule\<TModel,TProperty\>\.TModel')[,](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>')[TProperty](PropertyInclusiveBetweenWithFuncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyInclusiveBetweenWithFuncValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyInclusiveBetweenWithFuncValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>') → PropertyInclusiveBetweenWithFuncValidatorRule\<TModel,TProperty\>

| Constructors | |
| :--- | :--- |
| [PropertyInclusiveBetweenWithFuncValidatorRule\(Func&lt;TModel,TProperty&gt;, Func&lt;TModel,TProperty&gt;\)](PropertyInclusiveBetweenWithFuncValidatorRule_TModel,TProperty_..ctor.E7UOW1C1JV8PGA9BPTOF466A.md 'Cat\.Validators\.Rules\.PropertyInclusiveBetweenWithFuncValidatorRule\<TModel,TProperty\>\.PropertyInclusiveBetweenWithFuncValidatorRule\(System\.Func\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>\)') | Passes when the value is between the bounds, bounds included\. Both bounds come from the model\. Fails with [InclusiveBetween](CatValidatorErrorDefinitions.InclusiveBetween.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.InclusiveBetween') otherwise\. |

| Methods | |
| :--- | :--- |
| [Validate\(TProperty, string, TModel\)](PropertyInclusiveBetweenWithFuncValidatorRule_TModel,TProperty_.Validate.4DQHDJPPK58X23OL6MYG3MZ7A.md 'Cat\.Validators\.Rules\.PropertyInclusiveBetweenWithFuncValidatorRule\<TModel,TProperty\>\.Validate\(TProperty, string, TModel\)') | |
