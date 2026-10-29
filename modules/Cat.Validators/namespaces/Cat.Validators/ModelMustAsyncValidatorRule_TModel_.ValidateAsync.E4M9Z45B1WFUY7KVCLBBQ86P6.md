<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules') > [ModelMustAsyncValidatorRule&lt;TModel&gt;](ModelMustAsyncValidatorRule_TModel_.md 'Cat\.Validators\.Rules\.ModelMustAsyncValidatorRule\<TModel\>')

## ModelMustAsyncValidatorRule\<TModel\>\.ValidateAsync\(TModel, CancellationToken\) Method

```csharp
public override System.Threading.Tasks.Task<System.Collections.Generic.List<Cat.Validators.Abstractions.ICatValidatorError>> ValidateAsync(TModel model, System.Threading.CancellationToken ct);
```
#### Parameters

<a name='Cat.Validators.Rules.ModelMustAsyncValidatorRule_TModel_.ValidateAsync(TModel,System.Threading.CancellationToken).model'></a>

`model` [TModel](ModelMustAsyncValidatorRule_TModel_.md#Cat.Validators.Rules.ModelMustAsyncValidatorRule_TModel_.TModel 'Cat\.Validators\.Rules\.ModelMustAsyncValidatorRule\<TModel\>\.TModel')

<a name='Cat.Validators.Rules.ModelMustAsyncValidatorRule_TModel_.ValidateAsync(TModel,System.Threading.CancellationToken).ct'></a>

`ct` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Implements [ValidateAsync\(TModel, CancellationToken\)](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorModelRule_TModel_.ValidateAsync.OP5PLME0CZWG5EGZ8QRKTRTC6.md 'Cat\.Validators\.Abstractions\.ICatValidatorModelRule\`1\.ValidateAsync\(\`0,System\.Threading\.CancellationToken\)')

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[ICatValidatorError](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorError.md 'Cat\.Validators\.Abstractions\.ICatValidatorError')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')