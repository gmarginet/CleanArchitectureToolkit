<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators](Cat.Validators.md 'Cat\.Validators') > [CatValidatorProcessor](CatValidatorProcessor.md 'Cat\.Validators\.CatValidatorProcessor')

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