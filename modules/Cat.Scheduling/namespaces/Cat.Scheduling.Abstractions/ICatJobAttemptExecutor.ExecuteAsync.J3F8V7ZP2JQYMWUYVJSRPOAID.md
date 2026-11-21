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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.SCHEDULING](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Scheduling\.Abstractions Assembly](index.md 'index') >> [Cat\.Scheduling\.Abstractions Namespace](Cat.Scheduling.Abstractions.md 'Cat\.Scheduling\.Abstractions') >> [ICatJobAttemptExecutor Interface](ICatJobAttemptExecutor.md 'Cat\.Scheduling\.Abstractions\.ICatJobAttemptExecutor')

## ICatJobAttemptExecutor\.ExecuteAsync\(string, Func\<CancellationToken,Task\<CatJobAttemptResult\>\>, CancellationToken\) Method

Calls [attempt](ICatJobAttemptExecutor.ExecuteAsync.J3F8V7ZP2JQYMWUYVJSRPOAID.md#Cat.Scheduling.Abstractions.ICatJobAttemptExecutor.ExecuteAsync(string,System.Func_System.Threading.CancellationToken,System.Threading.Tasks.Task_Cat.Scheduling.Abstractions.CatJobAttemptResult__,System.Threading.CancellationToken).attempt 'Cat\.Scheduling\.Abstractions\.ICatJobAttemptExecutor\.ExecuteAsync\(string, System\.Func\<System\.Threading\.CancellationToken,System\.Threading\.Tasks\.Task\<Cat\.Scheduling\.Abstractions\.CatJobAttemptResult\>\>, System\.Threading\.CancellationToken\)\.attempt') once or more, as the implementation decides, and returns the result of the last call\.
Every call is a whole try, with its own scope and its own system user\.

```csharp
System.Threading.Tasks.Task<Cat.Scheduling.Abstractions.CatJobAttemptResult> ExecuteAsync(string jobName, System.Func<System.Threading.CancellationToken,System.Threading.Tasks.Task<Cat.Scheduling.Abstractions.CatJobAttemptResult>> attempt, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='Cat.Scheduling.Abstractions.ICatJobAttemptExecutor.ExecuteAsync(string,System.Func_System.Threading.CancellationToken,System.Threading.Tasks.Task_Cat.Scheduling.Abstractions.CatJobAttemptResult__,System.Threading.CancellationToken).jobName'></a>

`jobName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the job\.

<a name='Cat.Scheduling.Abstractions.ICatJobAttemptExecutor.ExecuteAsync(string,System.Func_System.Threading.CancellationToken,System.Threading.Tasks.Task_Cat.Scheduling.Abstractions.CatJobAttemptResult__,System.Threading.CancellationToken).attempt'></a>

`attempt` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[CatJobAttemptResult](CatJobAttemptResult.md 'Cat\.Scheduling\.Abstractions\.CatJobAttemptResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

Runs one try\. A result with [CanRetry](CatJobAttemptResult.CanRetry.md 'Cat\.Scheduling\.Abstractions\.CatJobAttemptResult\.CanRetry') says that a new try can help\.

<a name='Cat.Scheduling.Abstractions.ICatJobAttemptExecutor.ExecuteAsync(string,System.Func_System.Threading.CancellationToken,System.Threading.Tasks.Task_Cat.Scheduling.Abstractions.CatJobAttemptResult__,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Cancels the work\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[CatJobAttemptResult](CatJobAttemptResult.md 'Cat\.Scheduling\.Abstractions\.CatJobAttemptResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The result of the last try\.