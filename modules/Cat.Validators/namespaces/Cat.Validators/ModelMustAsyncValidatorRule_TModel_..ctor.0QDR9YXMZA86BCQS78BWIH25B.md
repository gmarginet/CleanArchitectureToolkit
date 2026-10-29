<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules') > [ModelMustAsyncValidatorRule&lt;TModel&gt;](ModelMustAsyncValidatorRule_TModel_.md 'Cat\.Validators\.Rules\.ModelMustAsyncValidatorRule\<TModel\>')

## ModelMustAsyncValidatorRule\(Func\<TModel,CancellationToken,Task\<List\<ICatValidatorError\>\>\>\) Constructor

Checks the whole model with your own async code\.

```csharp
public ModelMustAsyncValidatorRule(System.Func<TModel,System.Threading.CancellationToken,System.Threading.Tasks.Task<System.Collections.Generic.List<Cat.Validators.Abstractions.ICatValidatorError>>> predicate);
```
#### Parameters

<a name='Cat.Validators.Rules.ModelMustAsyncValidatorRule_TModel_.ModelMustAsyncValidatorRule(System.Func_TModel,System.Threading.CancellationToken,System.Threading.Tasks.Task_System.Collections.Generic.List_Cat.Validators.Abstractions.ICatValidatorError___).predicate'></a>

`predicate` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')[TModel](ModelMustAsyncValidatorRule_TModel_.md#Cat.Validators.Rules.ModelMustAsyncValidatorRule_TModel_.TModel 'Cat\.Validators\.Rules\.ModelMustAsyncValidatorRule\<TModel\>\.TModel')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')[System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[ICatValidatorError](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorError.md 'Cat\.Validators\.Abstractions\.ICatValidatorError')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')