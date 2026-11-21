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
            <img src='../../../../resources/logo/CatLogo.svg' alt='' width='200' style='padding: 15px; float: right; background: #121314; border-radius: 10px'/>
        </td>
    </tr>
    <tr>
        <td colspan='6' markdown='1' style='padding-left: 0; padding-right: 0; padding-top: 15px; padding-bottom: 0; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.RESILIENCE](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Resilience\.Commands Assembly](index.md 'index') >> [Cat\.Resilience\.Commands Namespace](Cat.Resilience.Commands.md 'Cat\.Resilience\.Commands') >> [CatRetryCommandProcessor Class](CatRetryCommandProcessor.md 'Cat\.Resilience\.Commands\.CatRetryCommandProcessor')

## CatRetryCommandProcessor\.RunAsync\<TResponse\>\(CatRetryRule, Func\<CancellationToken,Task\<TResponse\>\>, CancellationToken\) Method

```csharp
private System.Threading.Tasks.Task<TResponse> RunAsync<TResponse>(Cat.Resilience.Commands.CatRetryRule rule, System.Func<System.Threading.CancellationToken,System.Threading.Tasks.Task<TResponse>> attempt, System.Threading.CancellationToken cancellationToken)
    where TResponse : Cat.Responses.Abstractions.ICatResponse;
```
#### Type parameters

<a name='Cat.Resilience.Commands.CatRetryCommandProcessor.RunAsync_TResponse_(Cat.Resilience.Commands.CatRetryRule,System.Func_System.Threading.CancellationToken,System.Threading.Tasks.Task_TResponse__,System.Threading.CancellationToken).TResponse'></a>

`TResponse`
#### Parameters

<a name='Cat.Resilience.Commands.CatRetryCommandProcessor.RunAsync_TResponse_(Cat.Resilience.Commands.CatRetryRule,System.Func_System.Threading.CancellationToken,System.Threading.Tasks.Task_TResponse__,System.Threading.CancellationToken).rule'></a>

`rule` [CatRetryRule](CatRetryRule.md 'Cat\.Resilience\.Commands\.CatRetryRule')

<a name='Cat.Resilience.Commands.CatRetryCommandProcessor.RunAsync_TResponse_(Cat.Resilience.Commands.CatRetryRule,System.Func_System.Threading.CancellationToken,System.Threading.Tasks.Task_TResponse__,System.Threading.CancellationToken).attempt'></a>

`attempt` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[TResponse](CatRetryCommandProcessor.RunAsync.CQL9PKK0H5IW462N1PHT6LQMD.md#Cat.Resilience.Commands.CatRetryCommandProcessor.RunAsync_TResponse_(Cat.Resilience.Commands.CatRetryRule,System.Func_System.Threading.CancellationToken,System.Threading.Tasks.Task_TResponse__,System.Threading.CancellationToken).TResponse 'Cat\.Resilience\.Commands\.CatRetryCommandProcessor\.RunAsync\<TResponse\>\(Cat\.Resilience\.Commands\.CatRetryRule, System\.Func\<System\.Threading\.CancellationToken,System\.Threading\.Tasks\.Task\<TResponse\>\>, System\.Threading\.CancellationToken\)\.TResponse')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

<a name='Cat.Resilience.Commands.CatRetryCommandProcessor.RunAsync_TResponse_(Cat.Resilience.Commands.CatRetryRule,System.Func_System.Threading.CancellationToken,System.Threading.Tasks.Task_TResponse__,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[TResponse](CatRetryCommandProcessor.RunAsync.CQL9PKK0H5IW462N1PHT6LQMD.md#Cat.Resilience.Commands.CatRetryCommandProcessor.RunAsync_TResponse_(Cat.Resilience.Commands.CatRetryRule,System.Func_System.Threading.CancellationToken,System.Threading.Tasks.Task_TResponse__,System.Threading.CancellationToken).TResponse 'Cat\.Resilience\.Commands\.CatRetryCommandProcessor\.RunAsync\<TResponse\>\(Cat\.Resilience\.Commands\.CatRetryRule, System\.Func\<System\.Threading\.CancellationToken,System\.Threading\.Tasks\.Task\<TResponse\>\>, System\.Threading\.CancellationToken\)\.TResponse')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')