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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.COMMANDS](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Commands Assembly](index.md 'index') >> [Cat\.Commands Namespace](Cat.Commands.md 'Cat\.Commands') >> [CatCommandProcessor Class](CatCommandProcessor.md 'Cat\.Commands\.CatCommandProcessor')

## CatCommandProcessor\.RunHandlerAsync Method

| Overloads | |
| :--- | :--- |
| [RunHandlerAsync\(IServiceProvider, ICatCommand, CancellationToken\)](CatCommandProcessor.RunHandlerAsync.md#Cat.Commands.CatCommandProcessor.RunHandlerAsync(System.IServiceProvider,Cat.Commands.Abstractions.ICatCommand,System.Threading.CancellationToken) 'Cat\.Commands\.CatCommandProcessor\.RunHandlerAsync\(System\.IServiceProvider, Cat\.Commands\.Abstractions\.ICatCommand, System\.Threading\.CancellationToken\)') | |
| [RunHandlerAsync&lt;TResult&gt;\(IServiceProvider, ICatCommand&lt;TResult&gt;, CancellationToken\)](CatCommandProcessor.RunHandlerAsync.md#Cat.Commands.CatCommandProcessor.RunHandlerAsync_TResult_(System.IServiceProvider,Cat.Commands.Abstractions.ICatCommand_TResult_,System.Threading.CancellationToken) 'Cat\.Commands\.CatCommandProcessor\.RunHandlerAsync\<TResult\>\(System\.IServiceProvider, Cat\.Commands\.Abstractions\.ICatCommand\<TResult\>, System\.Threading\.CancellationToken\)') | |

<a name='Cat.Commands.CatCommandProcessor.RunHandlerAsync(System.IServiceProvider,Cat.Commands.Abstractions.ICatCommand,System.Threading.CancellationToken)'></a>

## CatCommandProcessor\.RunHandlerAsync\(IServiceProvider, ICatCommand, CancellationToken\) Method

```csharp
private System.Threading.Tasks.Task<Cat.Responses.Abstractions.ICatResponse> RunHandlerAsync(System.IServiceProvider provider, Cat.Commands.Abstractions.ICatCommand catCommand, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='Cat.Commands.CatCommandProcessor.RunHandlerAsync(System.IServiceProvider,Cat.Commands.Abstractions.ICatCommand,System.Threading.CancellationToken).provider'></a>

`provider` [System\.IServiceProvider](https://learn.microsoft.com/en-us/dotnet/api/system.iserviceprovider 'System\.IServiceProvider')

<a name='Cat.Commands.CatCommandProcessor.RunHandlerAsync(System.IServiceProvider,Cat.Commands.Abstractions.ICatCommand,System.Threading.CancellationToken).catCommand'></a>

`catCommand` [ICatCommand](../../../Cat.Commands/namespaces/Cat.Commands.Abstractions/ICatCommand.md 'Cat\.Commands\.Abstractions\.ICatCommand')

<a name='Cat.Commands.CatCommandProcessor.RunHandlerAsync(System.IServiceProvider,Cat.Commands.Abstractions.ICatCommand,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[ICatResponse](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')

<a name='Cat.Commands.CatCommandProcessor.RunHandlerAsync_TResult_(System.IServiceProvider,Cat.Commands.Abstractions.ICatCommand_TResult_,System.Threading.CancellationToken)'></a>

## CatCommandProcessor\.RunHandlerAsync\<TResult\>\(IServiceProvider, ICatCommand\<TResult\>, CancellationToken\) Method

```csharp
private System.Threading.Tasks.Task<Cat.Responses.Abstractions.ICatResponse<TResult>> RunHandlerAsync<TResult>(System.IServiceProvider provider, Cat.Commands.Abstractions.ICatCommand<TResult> catCommand, System.Threading.CancellationToken cancellationToken);
```
#### Type parameters

<a name='Cat.Commands.CatCommandProcessor.RunHandlerAsync_TResult_(System.IServiceProvider,Cat.Commands.Abstractions.ICatCommand_TResult_,System.Threading.CancellationToken).TResult'></a>

`TResult`
#### Parameters

<a name='Cat.Commands.CatCommandProcessor.RunHandlerAsync_TResult_(System.IServiceProvider,Cat.Commands.Abstractions.ICatCommand_TResult_,System.Threading.CancellationToken).provider'></a>

`provider` [System\.IServiceProvider](https://learn.microsoft.com/en-us/dotnet/api/system.iserviceprovider 'System\.IServiceProvider')

<a name='Cat.Commands.CatCommandProcessor.RunHandlerAsync_TResult_(System.IServiceProvider,Cat.Commands.Abstractions.ICatCommand_TResult_,System.Threading.CancellationToken).catCommand'></a>

`catCommand` [Cat\.Commands\.Abstractions\.ICatCommand&lt;](../../../Cat.Commands/namespaces/Cat.Commands.Abstractions/ICatCommand_TResult_.md 'Cat\.Commands\.Abstractions\.ICatCommand\`1')[TResult](CatCommandProcessor.RunHandlerAsync.md#Cat.Commands.CatCommandProcessor.RunHandlerAsync_TResult_(System.IServiceProvider,Cat.Commands.Abstractions.ICatCommand_TResult_,System.Threading.CancellationToken).TResult 'Cat\.Commands\.CatCommandProcessor\.RunHandlerAsync\<TResult\>\(System\.IServiceProvider, Cat\.Commands\.Abstractions\.ICatCommand\<TResult\>, System\.Threading\.CancellationToken\)\.TResult')[&gt;](../../../Cat.Commands/namespaces/Cat.Commands.Abstractions/ICatCommand_TResult_.md 'Cat\.Commands\.Abstractions\.ICatCommand\`1')

<a name='Cat.Commands.CatCommandProcessor.RunHandlerAsync_TResult_(System.IServiceProvider,Cat.Commands.Abstractions.ICatCommand_TResult_,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Cat\.Responses\.Abstractions\.ICatResponse&lt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[TResult](CatCommandProcessor.RunHandlerAsync.md#Cat.Commands.CatCommandProcessor.RunHandlerAsync_TResult_(System.IServiceProvider,Cat.Commands.Abstractions.ICatCommand_TResult_,System.Threading.CancellationToken).TResult 'Cat\.Commands\.CatCommandProcessor\.RunHandlerAsync\<TResult\>\(System\.IServiceProvider, Cat\.Commands\.Abstractions\.ICatCommand\<TResult\>, System\.Threading\.CancellationToken\)\.TResult')[&gt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')