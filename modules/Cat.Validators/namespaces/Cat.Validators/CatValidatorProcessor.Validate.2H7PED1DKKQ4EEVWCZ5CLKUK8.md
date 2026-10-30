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
            <img src='../../../../resources/logo/CatLogo-RoundedCorners-320x160.png' alt='' width='200' style='float: right;'/>
        </td>
    </tr>
    <tr>
        <td colspan='6' markdown='1' style='padding-left: 0; padding-right: 0; padding-top: 15px; padding-bottom: 0; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>

|&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[CAT.VALIDATORS](../../README.md)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Validators Assembly](index.md 'index') >> [Cat\.Validators Namespace](Cat.Validators.md 'Cat\.Validators') >> [CatValidatorProcessor Class](CatValidatorProcessor.md 'Cat\.Validators\.CatValidatorProcessor')

## CatValidatorProcessor\.Validate\<T\>\(T, bool\) Method

Validates a model and blocks until it finishes\.
Prefer [ValidateAsync&lt;TModel&gt;\(TModel, bool, CancellationToken\)](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorProcessor.ValidateAsync.YX1OQX8RMH8LA0B43AUVR45T5.md 'Cat\.Validators\.Abstractions\.ICatValidatorProcessor\.ValidateAsync\`\`1\(\`\`0,System\.Boolean,System\.Threading\.CancellationToken\)') when you can\.

```csharp
public Cat.Responses.Abstractions.ICatResponse Validate<T>(T model, bool validatorRequired=true)
    where T : class;
```
#### Type parameters

<a name='Cat.Validators.CatValidatorProcessor.Validate_T_(T,bool).T'></a>

`T`
#### Parameters

<a name='Cat.Validators.CatValidatorProcessor.Validate_T_(T,bool).model'></a>

`model` [T](CatValidatorProcessor.Validate.2H7PED1DKKQ4EEVWCZ5CLKUK8.md#Cat.Validators.CatValidatorProcessor.Validate_T_(T,bool).T 'Cat\.Validators\.CatValidatorProcessor\.Validate\<T\>\(T, bool\)\.T')

The model to validate\.

<a name='Cat.Validators.CatValidatorProcessor.Validate_T_(T,bool).validatorRequired'></a>

`validatorRequired` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

When `true`, a missing validator throws\. When `false`, the model counts as valid\.

Implements [Validate&lt;TModel&gt;\(TModel, bool\)](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorProcessor.Validate.52NC1J5TS1ISOCK1DV4W8K0P2.md 'Cat\.Validators\.Abstractions\.ICatValidatorProcessor\.Validate\`\`1\(\`\`0,System\.Boolean\)')

#### Returns
[ICatResponse](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse')  
An Ok response when the model is valid, or a BadRequest response with one error per failure\.