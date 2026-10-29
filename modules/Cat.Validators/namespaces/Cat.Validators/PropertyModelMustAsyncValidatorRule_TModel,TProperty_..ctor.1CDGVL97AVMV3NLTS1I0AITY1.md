<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules') > [PropertyModelMustAsyncValidatorRule&lt;TModel,TProperty&gt;](PropertyModelMustAsyncValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyModelMustAsyncValidatorRule\<TModel,TProperty\>')

## PropertyModelMustAsyncValidatorRule\(Func\<TProperty,string,TModel,CancellationToken,Task\<List\<ICatValidatorError\>\>\>\) Constructor

Checks a property with your own async code that can also look at the whole model\.

```csharp
public PropertyModelMustAsyncValidatorRule(System.Func<TProperty,string,TModel,System.Threading.CancellationToken,System.Threading.Tasks.Task<System.Collections.Generic.List<Cat.Validators.Abstractions.ICatValidatorError>>> predicate);
```
#### Parameters

<a name='Cat.Validators.Rules.PropertyModelMustAsyncValidatorRule_TModel,TProperty_.PropertyModelMustAsyncValidatorRule(System.Func_TProperty,string,TModel,System.Threading.CancellationToken,System.Threading.Tasks.Task_System.Collections.Generic.List_Cat.Validators.Abstractions.ICatValidatorError___).predicate'></a>

`predicate` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-5 'System\.Func\`5')[TProperty](PropertyModelMustAsyncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyModelMustAsyncValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyModelMustAsyncValidatorRule\<TModel,TProperty\>\.TProperty')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-5 'System\.Func\`5')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-5 'System\.Func\`5')[TModel](PropertyModelMustAsyncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyModelMustAsyncValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyModelMustAsyncValidatorRule\<TModel,TProperty\>\.TModel')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-5 'System\.Func\`5')[System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-5 'System\.Func\`5')[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[ICatValidatorError](..\Cat.Validators.Abstractions\ICatValidatorError.md 'Cat\.Validators\.Abstractions\.ICatValidatorError')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-5 'System\.Func\`5')