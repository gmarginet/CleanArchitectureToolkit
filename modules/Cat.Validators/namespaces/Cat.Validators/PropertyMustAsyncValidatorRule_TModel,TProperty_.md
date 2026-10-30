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

## PropertyMustAsyncValidatorRule\<TModel,TProperty\> Class

Checks a property with your own async code\.

```csharp
internal class PropertyMustAsyncValidatorRule<TModel,TProperty> : Cat.Validators.CatValidatorPropertyRuleAsyncBase<TModel, TProperty>
    where TModel : class
```
#### Type parameters

<a name='Cat.Validators.Rules.PropertyMustAsyncValidatorRule_TModel,TProperty_.TModel'></a>

`TModel`

The type being validated\.

<a name='Cat.Validators.Rules.PropertyMustAsyncValidatorRule_TModel,TProperty_.TProperty'></a>

`TProperty`

The type of the property\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [Cat\.Validators\.CatValidatorModelRuleAsyncBase&lt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>')[TModel](PropertyMustAsyncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyMustAsyncValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyMustAsyncValidatorRule\<TModel,TProperty\>\.TModel')[&gt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>') → [Cat\.Validators\.CatValidatorPropertyRuleAsyncBase&lt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[TModel](PropertyMustAsyncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyMustAsyncValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyMustAsyncValidatorRule\<TModel,TProperty\>\.TModel')[,](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[TProperty](PropertyMustAsyncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyMustAsyncValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyMustAsyncValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>') → PropertyMustAsyncValidatorRule\<TModel,TProperty\>

| Constructors | |
| :--- | :--- |
| [PropertyMustAsyncValidatorRule\(Func&lt;TProperty,string,CancellationToken,Task&lt;List&lt;ICatValidatorError&gt;&gt;&gt;\)](PropertyMustAsyncValidatorRule_TModel,TProperty_..ctor.W4O1ARFYUZUWT94BK977WOLC6.md 'Cat\.Validators\.Rules\.PropertyMustAsyncValidatorRule\<TModel,TProperty\>\.PropertyMustAsyncValidatorRule\(System\.Func\<TProperty,string,System\.Threading\.CancellationToken,System\.Threading\.Tasks\.Task\<System\.Collections\.Generic\.List\<Cat\.Validators\.Abstractions\.ICatValidatorError\>\>\>\)') | Checks a property with your own async code\. |

| Methods | |
| :--- | :--- |
| [ValidateAsync\(TProperty, string, TModel, CancellationToken\)](PropertyMustAsyncValidatorRule_TModel,TProperty_.ValidateAsync.2HPBN0Q4KLBR4NAXJN7M5RA7E.md 'Cat\.Validators\.Rules\.PropertyMustAsyncValidatorRule\<TModel,TProperty\>\.ValidateAsync\(TProperty, string, TModel, System\.Threading\.CancellationToken\)') | |
