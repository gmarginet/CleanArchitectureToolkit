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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.VALIDATORS](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Validators\.Abstractions Assembly](index.md 'index') >> [Cat\.Validators\.Abstractions Namespace](Cat.Validators.Abstractions.md 'Cat\.Validators\.Abstractions')

## ICatValidatorPropertyRule\<TModel,TProperty\> Interface

A rule that checks one property of a model\.

```csharp
public interface ICatValidatorPropertyRule<TModel,TProperty> : Cat.Validators.Abstractions.ICatValidatorModelRule<TModel>
    where TModel : class
```
#### Type parameters

<a name='Cat.Validators.Abstractions.ICatValidatorPropertyRule_TModel,TProperty_.TModel'></a>

`TModel`

The type being validated\.

<a name='Cat.Validators.Abstractions.ICatValidatorPropertyRule_TModel,TProperty_.TProperty'></a>

`TProperty`

The type of the property\.

Implements [Cat\.Validators\.Abstractions\.ICatValidatorModelRule&lt;](ICatValidatorModelRule_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorModelRule\<TModel\>')[TModel](ICatValidatorPropertyRule_TModel,TProperty_.md#Cat.Validators.Abstractions.ICatValidatorPropertyRule_TModel,TProperty_.TModel 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRule\<TModel,TProperty\>\.TModel')[&gt;](ICatValidatorModelRule_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorModelRule\<TModel\>')

| Properties | |
| :--- | :--- |
| [ErrorCode](ICatValidatorPropertyRule_TModel,TProperty_.ErrorCode.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRule\<TModel,TProperty\>\.ErrorCode') | Replaces the error code\. Leave it `null` to use the code of the rule\. |
| [ErrorMessage](ICatValidatorPropertyRule_TModel,TProperty_.ErrorMessage.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRule\<TModel,TProperty\>\.ErrorMessage') | Replaces the error message\. Leave it `null` to use the message of the rule\. |
| [FieldName](ICatValidatorPropertyRule_TModel,TProperty_.FieldName.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRule\<TModel,TProperty\>\.FieldName') | Replaces the field name in the errors\. Leave it `null` to use the property name\. |
