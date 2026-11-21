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
  
##### >> [Cat\.Resilience Assembly](index.md 'index') >> [Cat\.Resilience Namespace](Cat.Resilience.md 'Cat\.Resilience') >> [CatResiliencePipelines Class](CatResiliencePipelines.md 'Cat\.Resilience\.CatResiliencePipelines') >> [CatResiliencePipeline Class](CatResiliencePipelines.CatResiliencePipeline.md 'Cat\.Resilience\.CatResiliencePipelines\.CatResiliencePipeline')

## CatResiliencePipelines\.CatResiliencePipeline\.ExecuteAsync Method

| Overloads | |
| :--- | :--- |
| [ExecuteAsync\(Func&lt;CancellationToken,Task&gt;, CancellationToken\)](CatResiliencePipelines.CatResiliencePipeline.ExecuteAsync.md#Cat.Resilience.CatResiliencePipelines.CatResiliencePipeline.ExecuteAsync(System.Func_System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Threading.CancellationToken) 'Cat\.Resilience\.CatResiliencePipelines\.CatResiliencePipeline\.ExecuteAsync\(System\.Func\<System\.Threading\.CancellationToken,System\.Threading\.Tasks\.Task\>, System\.Threading\.CancellationToken\)') | |
| [ExecuteAsync&lt;TResult&gt;\(Func&lt;CancellationToken,Task&lt;TResult&gt;&gt;, CancellationToken\)](CatResiliencePipelines.CatResiliencePipeline.ExecuteAsync.md#Cat.Resilience.CatResiliencePipelines.CatResiliencePipeline.ExecuteAsync_TResult_(System.Func_System.Threading.CancellationToken,System.Threading.Tasks.Task_TResult__,System.Threading.CancellationToken) 'Cat\.Resilience\.CatResiliencePipelines\.CatResiliencePipeline\.ExecuteAsync\<TResult\>\(System\.Func\<System\.Threading\.CancellationToken,System\.Threading\.Tasks\.Task\<TResult\>\>, System\.Threading\.CancellationToken\)') | |

<a name='Cat.Resilience.CatResiliencePipelines.CatResiliencePipeline.ExecuteAsync(System.Func_System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Threading.CancellationToken)'></a>

## CatResiliencePipelines\.CatResiliencePipeline\.ExecuteAsync\(Func\<CancellationToken,Task\>, CancellationToken\) Method

```csharp
public System.Threading.Tasks.Task ExecuteAsync(System.Func<System.Threading.CancellationToken,System.Threading.Tasks.Task> callback, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Cat.Resilience.CatResiliencePipelines.CatResiliencePipeline.ExecuteAsync(System.Func_System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Threading.CancellationToken).callback'></a>

`callback` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Threading\.Tasks\.Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task 'System\.Threading\.Tasks\.Task')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

<a name='Cat.Resilience.CatResiliencePipelines.CatResiliencePipeline.ExecuteAsync(System.Func_System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Implements [ExecuteAsync\(Func&lt;CancellationToken,Task&gt;, CancellationToken\)](../../../Cat.Resilience/namespaces/Cat.Resilience.Abstractions/ICatResiliencePipeline.ExecuteAsync.md#Cat.Resilience.Abstractions.ICatResiliencePipeline.ExecuteAsync(System.Func_System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Threading.CancellationToken) 'Cat\.Resilience\.Abstractions\.ICatResiliencePipeline\.ExecuteAsync\(System\.Func\{System\.Threading\.CancellationToken,System\.Threading\.Tasks\.Task\},System\.Threading\.CancellationToken\)')

#### Returns
[System\.Threading\.Tasks\.Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task 'System\.Threading\.Tasks\.Task')

<a name='Cat.Resilience.CatResiliencePipelines.CatResiliencePipeline.ExecuteAsync_TResult_(System.Func_System.Threading.CancellationToken,System.Threading.Tasks.Task_TResult__,System.Threading.CancellationToken)'></a>

## CatResiliencePipelines\.CatResiliencePipeline\.ExecuteAsync\<TResult\>\(Func\<CancellationToken,Task\<TResult\>\>, CancellationToken\) Method

```csharp
public System.Threading.Tasks.Task<TResult> ExecuteAsync<TResult>(System.Func<System.Threading.CancellationToken,System.Threading.Tasks.Task<TResult>> callback, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Type parameters

<a name='Cat.Resilience.CatResiliencePipelines.CatResiliencePipeline.ExecuteAsync_TResult_(System.Func_System.Threading.CancellationToken,System.Threading.Tasks.Task_TResult__,System.Threading.CancellationToken).TResult'></a>

`TResult`
#### Parameters

<a name='Cat.Resilience.CatResiliencePipelines.CatResiliencePipeline.ExecuteAsync_TResult_(System.Func_System.Threading.CancellationToken,System.Threading.Tasks.Task_TResult__,System.Threading.CancellationToken).callback'></a>

`callback` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[TResult](CatResiliencePipelines.CatResiliencePipeline.ExecuteAsync.md#Cat.Resilience.CatResiliencePipelines.CatResiliencePipeline.ExecuteAsync_TResult_(System.Func_System.Threading.CancellationToken,System.Threading.Tasks.Task_TResult__,System.Threading.CancellationToken).TResult 'Cat\.Resilience\.CatResiliencePipelines\.CatResiliencePipeline\.ExecuteAsync\<TResult\>\(System\.Func\<System\.Threading\.CancellationToken,System\.Threading\.Tasks\.Task\<TResult\>\>, System\.Threading\.CancellationToken\)\.TResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

<a name='Cat.Resilience.CatResiliencePipelines.CatResiliencePipeline.ExecuteAsync_TResult_(System.Func_System.Threading.CancellationToken,System.Threading.Tasks.Task_TResult__,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Implements [ExecuteAsync&lt;TResult&gt;\(Func&lt;CancellationToken,Task&lt;TResult&gt;&gt;, CancellationToken\)](../../../Cat.Resilience/namespaces/Cat.Resilience.Abstractions/ICatResiliencePipeline.ExecuteAsync.md#Cat.Resilience.Abstractions.ICatResiliencePipeline.ExecuteAsync_TResult_(System.Func_System.Threading.CancellationToken,System.Threading.Tasks.Task_TResult__,System.Threading.CancellationToken) 'Cat\.Resilience\.Abstractions\.ICatResiliencePipeline\.ExecuteAsync\`\`1\(System\.Func\{System\.Threading\.CancellationToken,System\.Threading\.Tasks\.Task\{\`\`0\}\},System\.Threading\.CancellationToken\)')

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[TResult](CatResiliencePipelines.CatResiliencePipeline.ExecuteAsync.md#Cat.Resilience.CatResiliencePipelines.CatResiliencePipeline.ExecuteAsync_TResult_(System.Func_System.Threading.CancellationToken,System.Threading.Tasks.Task_TResult__,System.Threading.CancellationToken).TResult 'Cat\.Resilience\.CatResiliencePipelines\.CatResiliencePipeline\.ExecuteAsync\<TResult\>\(System\.Func\<System\.Threading\.CancellationToken,System\.Threading\.Tasks\.Task\<TResult\>\>, System\.Threading\.CancellationToken\)\.TResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')