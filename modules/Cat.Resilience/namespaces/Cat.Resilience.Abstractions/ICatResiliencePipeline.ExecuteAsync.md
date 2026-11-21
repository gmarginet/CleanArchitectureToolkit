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
  
##### >> [Cat\.Resilience\.Abstractions Assembly](index.md 'index') >> [Cat\.Resilience\.Abstractions Namespace](Cat.Resilience.Abstractions.md 'Cat\.Resilience\.Abstractions') >> [ICatResiliencePipeline Interface](ICatResiliencePipeline.md 'Cat\.Resilience\.Abstractions\.ICatResiliencePipeline')

## ICatResiliencePipeline\.ExecuteAsync Method

| Overloads | |
| :--- | :--- |
| [ExecuteAsync\(Func&lt;CancellationToken,Task&gt;, CancellationToken\)](ICatResiliencePipeline.ExecuteAsync.md#Cat.Resilience.Abstractions.ICatResiliencePipeline.ExecuteAsync(System.Func_System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Threading.CancellationToken) 'Cat\.Resilience\.Abstractions\.ICatResiliencePipeline\.ExecuteAsync\(System\.Func\<System\.Threading\.CancellationToken,System\.Threading\.Tasks\.Task\>, System\.Threading\.CancellationToken\)') | Runs the callback and tries it again on an exception, as the profile says\. |
| [ExecuteAsync&lt;TResult&gt;\(Func&lt;CancellationToken,Task&lt;TResult&gt;&gt;, CancellationToken\)](ICatResiliencePipeline.ExecuteAsync.md#Cat.Resilience.Abstractions.ICatResiliencePipeline.ExecuteAsync_TResult_(System.Func_System.Threading.CancellationToken,System.Threading.Tasks.Task_TResult__,System.Threading.CancellationToken) 'Cat\.Resilience\.Abstractions\.ICatResiliencePipeline\.ExecuteAsync\<TResult\>\(System\.Func\<System\.Threading\.CancellationToken,System\.Threading\.Tasks\.Task\<TResult\>\>, System\.Threading\.CancellationToken\)') | Runs the callback and tries it again on an exception, as the profile says\. |

<a name='Cat.Resilience.Abstractions.ICatResiliencePipeline.ExecuteAsync(System.Func_System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Threading.CancellationToken)'></a>

## ICatResiliencePipeline\.ExecuteAsync\(Func\<CancellationToken,Task\>, CancellationToken\) Method

Runs the callback and tries it again on an exception, as the profile says\.

```csharp
System.Threading.Tasks.Task ExecuteAsync(System.Func<System.Threading.CancellationToken,System.Threading.Tasks.Task> callback, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Cat.Resilience.Abstractions.ICatResiliencePipeline.ExecuteAsync(System.Func_System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Threading.CancellationToken).callback'></a>

`callback` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Threading\.Tasks\.Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task 'System\.Threading\.Tasks\.Task')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

The call to run\.

<a name='Cat.Resilience.Abstractions.ICatResiliencePipeline.ExecuteAsync(System.Func_System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Cancels the call and its retries\.

#### Returns
[System\.Threading\.Tasks\.Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task 'System\.Threading\.Tasks\.Task')  
A task that ends when the call succeeded or the pipeline gave up\.

<a name='Cat.Resilience.Abstractions.ICatResiliencePipeline.ExecuteAsync_TResult_(System.Func_System.Threading.CancellationToken,System.Threading.Tasks.Task_TResult__,System.Threading.CancellationToken)'></a>

## ICatResiliencePipeline\.ExecuteAsync\<TResult\>\(Func\<CancellationToken,Task\<TResult\>\>, CancellationToken\) Method

Runs the callback and tries it again on an exception, as the profile says\.

```csharp
System.Threading.Tasks.Task<TResult> ExecuteAsync<TResult>(System.Func<System.Threading.CancellationToken,System.Threading.Tasks.Task<TResult>> callback, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Type parameters

<a name='Cat.Resilience.Abstractions.ICatResiliencePipeline.ExecuteAsync_TResult_(System.Func_System.Threading.CancellationToken,System.Threading.Tasks.Task_TResult__,System.Threading.CancellationToken).TResult'></a>

`TResult`

The type of the result\.
#### Parameters

<a name='Cat.Resilience.Abstractions.ICatResiliencePipeline.ExecuteAsync_TResult_(System.Func_System.Threading.CancellationToken,System.Threading.Tasks.Task_TResult__,System.Threading.CancellationToken).callback'></a>

`callback` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[TResult](ICatResiliencePipeline.ExecuteAsync.md#Cat.Resilience.Abstractions.ICatResiliencePipeline.ExecuteAsync_TResult_(System.Func_System.Threading.CancellationToken,System.Threading.Tasks.Task_TResult__,System.Threading.CancellationToken).TResult 'Cat\.Resilience\.Abstractions\.ICatResiliencePipeline\.ExecuteAsync\<TResult\>\(System\.Func\<System\.Threading\.CancellationToken,System\.Threading\.Tasks\.Task\<TResult\>\>, System\.Threading\.CancellationToken\)\.TResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

The call to run\.

<a name='Cat.Resilience.Abstractions.ICatResiliencePipeline.ExecuteAsync_TResult_(System.Func_System.Threading.CancellationToken,System.Threading.Tasks.Task_TResult__,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Cancels the call and its retries\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[TResult](ICatResiliencePipeline.ExecuteAsync.md#Cat.Resilience.Abstractions.ICatResiliencePipeline.ExecuteAsync_TResult_(System.Func_System.Threading.CancellationToken,System.Threading.Tasks.Task_TResult__,System.Threading.CancellationToken).TResult 'Cat\.Resilience\.Abstractions\.ICatResiliencePipeline\.ExecuteAsync\<TResult\>\(System\.Func\<System\.Threading\.CancellationToken,System\.Threading\.Tasks\.Task\<TResult\>\>, System\.Threading\.CancellationToken\)\.TResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The result of the first call that succeeded\.