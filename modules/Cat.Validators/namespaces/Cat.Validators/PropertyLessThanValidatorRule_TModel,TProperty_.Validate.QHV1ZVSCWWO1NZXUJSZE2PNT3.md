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
  
##### >> [Cat\.Validators Assembly](index.md 'index') >> [Cat\.Validators\.Rules Namespace](Cat.Validators.Rules.md 'Cat\.Validators\.Rules') >> [PropertyLessThanValidatorRule&lt;TModel,TProperty&gt; Class](PropertyLessThanValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyLessThanValidatorRule\<TModel,TProperty\>')

## PropertyLessThanValidatorRule\<TModel,TProperty\>\.Validate\(TProperty, string, TModel\) Method

```csharp
protected override System.Collections.Generic.List<Cat.Validators.Abstractions.ICatValidatorError> Validate(TProperty value, string fieldName, TModel model);
```
#### Parameters

<a name='Cat.Validators.Rules.PropertyLessThanValidatorRule_TModel,TProperty_.Validate(TProperty,string,TModel).value'></a>

`value` [TProperty](PropertyLessThanValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyLessThanValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyLessThanValidatorRule\<TModel,TProperty\>\.TProperty')

<a name='Cat.Validators.Rules.PropertyLessThanValidatorRule_TModel,TProperty_.Validate(TProperty,string,TModel).fieldName'></a>

`fieldName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='Cat.Validators.Rules.PropertyLessThanValidatorRule_TModel,TProperty_.Validate(TProperty,string,TModel).model'></a>

`model` [TModel](PropertyLessThanValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyLessThanValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyLessThanValidatorRule\<TModel,TProperty\>\.TModel')

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[ICatValidatorError](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorError.md 'Cat\.Validators\.Abstractions\.ICatValidatorError')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')