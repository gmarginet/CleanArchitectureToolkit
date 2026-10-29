<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators](Cat.Validators.md 'Cat\.Validators') > [CatValidatorModelRuleBase&lt;TModel&gt;](CatValidatorModelRuleBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleBase\<TModel\>')

## CatValidatorModelRuleBase\<TModel\>\.ValidateAsync\(TModel, CancellationToken\) Method

Runs the rule\.

```csharp
public override System.Threading.Tasks.Task<System.Collections.Generic.List<Cat.Validators.Abstractions.ICatValidatorError>> ValidateAsync(TModel model, System.Threading.CancellationToken ct);
```
#### Parameters

<a name='Cat.Validators.CatValidatorModelRuleBase_TModel_.ValidateAsync(TModel,System.Threading.CancellationToken).model'></a>

`model` [TModel](CatValidatorModelRuleBase_TModel_.md#Cat.Validators.CatValidatorModelRuleBase_TModel_.TModel 'Cat\.Validators\.CatValidatorModelRuleBase\<TModel\>\.TModel')

The model to check\.

<a name='Cat.Validators.CatValidatorModelRuleBase_TModel_.ValidateAsync(TModel,System.Threading.CancellationToken).ct'></a>

`ct` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Token to cancel the work\.

Implements [ValidateAsync\(TModel, CancellationToken\)](..\Cat.Validators.Abstractions\ICatValidatorModelRule_TModel_.ValidateAsync.OP5PLME0CZWG5EGZ8QRKTRTC6.md 'Cat\.Validators\.Abstractions\.ICatValidatorModelRule\`1\.ValidateAsync\(\`0,System\.Threading\.CancellationToken\)')

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[ICatValidatorError](..\Cat.Validators.Abstractions\ICatValidatorError.md 'Cat\.Validators\.Abstractions\.ICatValidatorError')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The failures found\. The list is empty when the model is valid\.