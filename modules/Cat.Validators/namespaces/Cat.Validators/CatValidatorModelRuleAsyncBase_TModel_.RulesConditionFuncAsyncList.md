<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators](Cat.Validators.md 'Cat\.Validators') > [CatValidatorModelRuleAsyncBase&lt;TModel&gt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>')

## CatValidatorModelRuleAsyncBase\<TModel\>\.RulesConditionFuncAsyncList Property

Conditions that decide whether the rule runs\. The rule is skipped when any of them returns `false`\.

```csharp
public System.Collections.Concurrent.ConcurrentBag<System.Func<TModel,System.Threading.CancellationToken,System.Threading.Tasks.Task<bool>>> RulesConditionFuncAsyncList { get; }
```

Implements [RulesConditionFuncAsyncList](../Cat.Validators.Abstractions/ICatValidatorModelRule_TModel_.RulesConditionFuncAsyncList.md 'Cat\.Validators\.Abstractions\.ICatValidatorModelRule\`1\.RulesConditionFuncAsyncList')

#### Property Value
[System\.Collections\.Concurrent\.ConcurrentBag&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.concurrent.concurrentbag-1 'System\.Collections\.Concurrent\.ConcurrentBag\`1')[System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')[TModel](CatValidatorModelRuleAsyncBase_TModel_.md#Cat.Validators.CatValidatorModelRuleAsyncBase_TModel_.TModel 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>\.TModel')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')[System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.concurrent.concurrentbag-1 'System\.Collections\.Concurrent\.ConcurrentBag\`1')