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

## ICatValidatorProcessor Interface

Single entry point for validating a model\.
It finds the validator for the model, runs its rules and returns the outcome as a response\.

```csharp
public interface ICatValidatorProcessor
```

| Methods | |
| :--- | :--- |
| [Validate&lt;TModel&gt;\(TModel, bool\)](ICatValidatorProcessor.Validate.52NC1J5TS1ISOCK1DV4W8K0P2.md 'Cat\.Validators\.Abstractions\.ICatValidatorProcessor\.Validate\<TModel\>\(TModel, bool\)') | Validates a model and blocks until it finishes\. Prefer [ValidateAsync&lt;TModel&gt;\(TModel, bool, CancellationToken\)](ICatValidatorProcessor.ValidateAsync.YX1OQX8RMH8LA0B43AUVR45T5.md 'Cat\.Validators\.Abstractions\.ICatValidatorProcessor\.ValidateAsync\<TModel\>\(TModel, bool, System\.Threading\.CancellationToken\)') when you can\. |
| [ValidateAsync&lt;TModel&gt;\(TModel, bool, CancellationToken\)](ICatValidatorProcessor.ValidateAsync.YX1OQX8RMH8LA0B43AUVR45T5.md 'Cat\.Validators\.Abstractions\.ICatValidatorProcessor\.ValidateAsync\<TModel\>\(TModel, bool, System\.Threading\.CancellationToken\)') | Validates a model\. |
