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
  
##### >> [Cat\.Validators\.Abstractions Assembly](index.md 'index') >> [Cat\.Validators\.Abstractions Namespace](Cat.Validators.Abstractions.md 'Cat\.Validators\.Abstractions')

## ICatValidator\<TModel\> Interface

Describes the rules for one model type\.
Implement it once per model\. The module finds and registers it for you\.

```csharp
public interface ICatValidator<TModel>
    where TModel : class
```
#### Type parameters

<a name='Cat.Validators.Abstractions.ICatValidator_TModel_.TModel'></a>

`TModel`

The type being validated\.

| Methods | |
| :--- | :--- |
| [Build\(ICatValidatorBuilder&lt;TModel&gt;\)](ICatValidator_TModel_.Build.KH5JMOMCH87CLWU32S59B0UE1.md 'Cat\.Validators\.Abstractions\.ICatValidator\<TModel\>\.Build\(Cat\.Validators\.Abstractions\.ICatValidatorBuilder\<TModel\>\)') | Adds the rules for the model\. |
