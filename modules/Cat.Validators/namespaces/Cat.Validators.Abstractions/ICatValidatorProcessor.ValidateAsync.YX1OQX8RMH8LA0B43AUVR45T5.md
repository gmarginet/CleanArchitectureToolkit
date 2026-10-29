<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Validators\.Abstractions](index.md 'index') > [Cat\.Validators\.Abstractions](Cat.Validators.Abstractions.md 'Cat\.Validators\.Abstractions') > [ICatValidatorProcessor](ICatValidatorProcessor.md 'Cat\.Validators\.Abstractions\.ICatValidatorProcessor')

## ICatValidatorProcessor\.ValidateAsync\<TModel\>\(TModel, bool, CancellationToken\) Method

Validates a model\.

```csharp
System.Threading.Tasks.Task<Cat.Responses.Abstractions.ICatResponse> ValidateAsync<TModel>(TModel model, bool validatorRequired=true, System.Threading.CancellationToken ct=default(System.Threading.CancellationToken))
    where TModel : class;
```
#### Type parameters

<a name='Cat.Validators.Abstractions.ICatValidatorProcessor.ValidateAsync_TModel_(TModel,bool,System.Threading.CancellationToken).TModel'></a>

`TModel`

The type being validated\.
#### Parameters

<a name='Cat.Validators.Abstractions.ICatValidatorProcessor.ValidateAsync_TModel_(TModel,bool,System.Threading.CancellationToken).model'></a>

`model` [TModel](ICatValidatorProcessor.ValidateAsync.YX1OQX8RMH8LA0B43AUVR45T5.md#Cat.Validators.Abstractions.ICatValidatorProcessor.ValidateAsync_TModel_(TModel,bool,System.Threading.CancellationToken).TModel 'Cat\.Validators\.Abstractions\.ICatValidatorProcessor\.ValidateAsync\<TModel\>\(TModel, bool, System\.Threading\.CancellationToken\)\.TModel')

The model to validate\.

<a name='Cat.Validators.Abstractions.ICatValidatorProcessor.ValidateAsync_TModel_(TModel,bool,System.Threading.CancellationToken).validatorRequired'></a>

`validatorRequired` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

When `true`, a missing validator throws\. When `false`, the model counts as valid\.

<a name='Cat.Validators.Abstractions.ICatValidatorProcessor.ValidateAsync_TModel_(TModel,bool,System.Threading.CancellationToken).ct'></a>

`ct` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Token to cancel the work\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[ICatResponse](..\Cat.Responses.Abstractions\ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
An Ok response when the model is valid, or a BadRequest response with one error per failure\.