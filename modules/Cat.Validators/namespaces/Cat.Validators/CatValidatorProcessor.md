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
  
##### >> [Cat\.Validators Assembly](index.md 'index') >> [Cat\.Validators Namespace](Cat.Validators.md 'Cat\.Validators')

## CatValidatorProcessor Class

Default [ICatValidatorProcessor](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorProcessor.md 'Cat\.Validators\.Abstractions\.ICatValidatorProcessor')\.
Gets the validator for a model, builds its rules and runs each one whose conditions allow it\.
Every rule runs, so one call reports all the failures\.

```csharp
public class CatValidatorProcessor : Cat.Validators.Abstractions.ICatValidatorProcessor
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatValidatorProcessor

Implements [ICatValidatorProcessor](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorProcessor.md 'Cat\.Validators\.Abstractions\.ICatValidatorProcessor')

| Constructors | |
| :--- | :--- |
| [CatValidatorProcessor\(IServiceProvider\)](CatValidatorProcessor..ctor.43C8DSYDHUK4I0O708NO4UYBD.md 'Cat\.Validators\.CatValidatorProcessor\.CatValidatorProcessor\(System\.IServiceProvider\)') | Default [ICatValidatorProcessor](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorProcessor.md 'Cat\.Validators\.Abstractions\.ICatValidatorProcessor')\. Gets the validator for a model, builds its rules and runs each one whose conditions allow it\. Every rule runs, so one call reports all the failures\. |

| Methods | |
| :--- | :--- |
| [InternalValidateAsync&lt;T&gt;\(T, bool, CancellationToken\)](CatValidatorProcessor.InternalValidateAsync.MW5UEA8ND8VDCLPLEI3DJBJ38.md 'Cat\.Validators\.CatValidatorProcessor\.InternalValidateAsync\<T\>\(T, bool, System\.Threading\.CancellationToken\)') | Runs the rules and returns the raw failures\. Nested validation uses this to get at the field names\. The [validatorRequired](CatValidatorProcessor.InternalValidateAsync.MW5UEA8ND8VDCLPLEI3DJBJ38.md#Cat.Validators.CatValidatorProcessor.InternalValidateAsync_T_(T,bool,System.Threading.CancellationToken).validatorRequired 'Cat\.Validators\.CatValidatorProcessor\.InternalValidateAsync\<T\>\(T, bool, System\.Threading\.CancellationToken\)\.validatorRequired') flag also goes to the nested rules, so they follow the top level\. |
| [Validate&lt;T&gt;\(T, bool\)](CatValidatorProcessor.Validate.2H7PED1DKKQ4EEVWCZ5CLKUK8.md 'Cat\.Validators\.CatValidatorProcessor\.Validate\<T\>\(T, bool\)') | Validates a model and blocks until it finishes\. Prefer [ValidateAsync&lt;TModel&gt;\(TModel, bool, CancellationToken\)](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorProcessor.ValidateAsync.YX1OQX8RMH8LA0B43AUVR45T5.md 'Cat\.Validators\.Abstractions\.ICatValidatorProcessor\.ValidateAsync\`\`1\(\`\`0,System\.Boolean,System\.Threading\.CancellationToken\)') when you can\. |
| [ValidateAsync&lt;T&gt;\(T, bool, CancellationToken\)](CatValidatorProcessor.ValidateAsync.9TMCP2XJPJ3T7VARXR8W30BP3.md 'Cat\.Validators\.CatValidatorProcessor\.ValidateAsync\<T\>\(T, bool, System\.Threading\.CancellationToken\)') | Validates a model\. |
