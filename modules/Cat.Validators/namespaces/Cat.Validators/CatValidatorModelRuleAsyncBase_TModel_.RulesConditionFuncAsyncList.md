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
  
##### >> [Cat\.Validators Assembly](index.md 'index') >> [Cat\.Validators Namespace](Cat.Validators.md 'Cat\.Validators') >> [CatValidatorModelRuleAsyncBase&lt;TModel&gt; Class](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>')

## CatValidatorModelRuleAsyncBase\<TModel\>\.RulesConditionFuncAsyncList Property

Conditions that decide whether the rule runs\. The rule is skipped when any of them returns `false`\.

```csharp
public System.Collections.Concurrent.ConcurrentBag<System.Func<TModel,System.Threading.CancellationToken,System.Threading.Tasks.Task<bool>>> RulesConditionFuncAsyncList { get; }
```

Implements [RulesConditionFuncAsyncList](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorModelRule_TModel_.RulesConditionFuncAsyncList.md 'Cat\.Validators\.Abstractions\.ICatValidatorModelRule\`1\.RulesConditionFuncAsyncList')

#### Property Value
[System\.Collections\.Concurrent\.ConcurrentBag&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.concurrent.concurrentbag-1 'System\.Collections\.Concurrent\.ConcurrentBag\`1')[System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')[TModel](CatValidatorModelRuleAsyncBase_TModel_.md#Cat.Validators.CatValidatorModelRuleAsyncBase_TModel_.TModel 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>\.TModel')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')[System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.concurrent.concurrentbag-1 'System\.Collections\.Concurrent\.ConcurrentBag\`1')