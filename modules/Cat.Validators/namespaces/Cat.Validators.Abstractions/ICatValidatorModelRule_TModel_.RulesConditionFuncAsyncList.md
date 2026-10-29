<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators\.Abstractions](index.md 'index') > [Cat\.Validators\.Abstractions](Cat.Validators.Abstractions.md 'Cat\.Validators\.Abstractions') > [ICatValidatorModelRule&lt;TModel&gt;](ICatValidatorModelRule_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorModelRule\<TModel\>')

## ICatValidatorModelRule\<TModel\>\.RulesConditionFuncAsyncList Property

Conditions that decide whether the rule runs\. The rule is skipped when any of them returns `false`\.

```csharp
System.Collections.Concurrent.ConcurrentBag<System.Func<TModel,System.Threading.CancellationToken,System.Threading.Tasks.Task<bool>>> RulesConditionFuncAsyncList { get; }
```

#### Property Value
[System\.Collections\.Concurrent\.ConcurrentBag&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.concurrent.concurrentbag-1 'System\.Collections\.Concurrent\.ConcurrentBag\`1')[System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')[TModel](ICatValidatorModelRule_TModel_.md#Cat.Validators.Abstractions.ICatValidatorModelRule_TModel_.TModel 'Cat\.Validators\.Abstractions\.ICatValidatorModelRule\<TModel\>\.TModel')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')[System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.concurrent.concurrentbag-1 'System\.Collections\.Concurrent\.ConcurrentBag\`1')