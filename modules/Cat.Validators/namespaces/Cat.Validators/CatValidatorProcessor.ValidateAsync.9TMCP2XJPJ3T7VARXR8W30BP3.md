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

## CatValidatorProcessor\.ValidateAsync\<T\>\(T, bool, CancellationToken\) Method

Validates a model\.

```csharp
public System.Threading.Tasks.Task<Cat.Responses.Abstractions.ICatResponse> ValidateAsync<T>(T model, bool validatorRequired=true, System.Threading.CancellationToken ct=default(System.Threading.CancellationToken))
    where T : class;
```
#### Type parameters

<a name='Cat.Validators.CatValidatorProcessor.ValidateAsync_T_(T,bool,System.Threading.CancellationToken).T'></a>

`T`
#### Parameters

<a name='Cat.Validators.CatValidatorProcessor.ValidateAsync_T_(T,bool,System.Threading.CancellationToken).model'></a>

`model` [T](CatValidatorProcessor.ValidateAsync.9TMCP2XJPJ3T7VARXR8W30BP3.md#Cat.Validators.CatValidatorProcessor.ValidateAsync_T_(T,bool,System.Threading.CancellationToken).T 'Cat\.Validators\.CatValidatorProcessor\.ValidateAsync\<T\>\(T, bool, System\.Threading\.CancellationToken\)\.T')

The model to validate\.

<a name='Cat.Validators.CatValidatorProcessor.ValidateAsync_T_(T,bool,System.Threading.CancellationToken).validatorRequired'></a>

`validatorRequired` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

When `true`, a missing validator throws\. When `false`, the model counts as valid\.

<a name='Cat.Validators.CatValidatorProcessor.ValidateAsync_T_(T,bool,System.Threading.CancellationToken).ct'></a>

`ct` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Token to cancel the work\.

Implements [ValidateAsync&lt;TModel&gt;\(TModel, bool, CancellationToken\)](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorProcessor.ValidateAsync.YX1OQX8RMH8LA0B43AUVR45T5.md 'Cat\.Validators\.Abstractions\.ICatValidatorProcessor\.ValidateAsync\`\`1\(\`\`0,System\.Boolean,System\.Threading\.CancellationToken\)')

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[ICatResponse](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
An Ok response when the model is valid, or a BadRequest response with one error per failure\.