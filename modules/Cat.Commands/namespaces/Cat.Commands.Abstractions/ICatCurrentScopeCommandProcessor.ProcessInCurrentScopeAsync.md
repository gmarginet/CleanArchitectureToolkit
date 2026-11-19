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
  
##### >> [Cat\.Commands\.Abstractions Assembly](index.md 'index') >> [Cat\.Commands\.Abstractions Namespace](Cat.Commands.Abstractions.md 'Cat\.Commands\.Abstractions') >> [ICatCurrentScopeCommandProcessor Interface](ICatCurrentScopeCommandProcessor.md 'Cat\.Commands\.Abstractions\.ICatCurrentScopeCommandProcessor')

## ICatCurrentScopeCommandProcessor\.ProcessInCurrentScopeAsync Method

| Overloads | |
| :--- | :--- |
| [ProcessInCurrentScopeAsync\(ICatCommand, CancellationToken\)](ICatCurrentScopeCommandProcessor.ProcessInCurrentScopeAsync.md#Cat.Commands.Abstractions.ICatCurrentScopeCommandProcessor.ProcessInCurrentScopeAsync(Cat.Commands.Abstractions.ICatCommand,System.Threading.CancellationToken) 'Cat\.Commands\.Abstractions\.ICatCurrentScopeCommandProcessor\.ProcessInCurrentScopeAsync\(Cat\.Commands\.Abstractions\.ICatCommand, System\.Threading\.CancellationToken\)') | Runs a command in the scope of the caller\. |
| [ProcessInCurrentScopeAsync&lt;TResult&gt;\(ICatCommand&lt;TResult&gt;, CancellationToken\)](ICatCurrentScopeCommandProcessor.ProcessInCurrentScopeAsync.md#Cat.Commands.Abstractions.ICatCurrentScopeCommandProcessor.ProcessInCurrentScopeAsync_TResult_(Cat.Commands.Abstractions.ICatCommand_TResult_,System.Threading.CancellationToken) 'Cat\.Commands\.Abstractions\.ICatCurrentScopeCommandProcessor\.ProcessInCurrentScopeAsync\<TResult\>\(Cat\.Commands\.Abstractions\.ICatCommand\<TResult\>, System\.Threading\.CancellationToken\)') | Runs a command that returns a result, in the scope of the caller\. |

<a name='Cat.Commands.Abstractions.ICatCurrentScopeCommandProcessor.ProcessInCurrentScopeAsync(Cat.Commands.Abstractions.ICatCommand,System.Threading.CancellationToken)'></a>

## ICatCurrentScopeCommandProcessor\.ProcessInCurrentScopeAsync\(ICatCommand, CancellationToken\) Method

Runs a command in the scope of the caller\.

```csharp
System.Threading.Tasks.Task<Cat.Responses.Abstractions.ICatResponse> ProcessInCurrentScopeAsync(Cat.Commands.Abstractions.ICatCommand catCommand, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Cat.Commands.Abstractions.ICatCurrentScopeCommandProcessor.ProcessInCurrentScopeAsync(Cat.Commands.Abstractions.ICatCommand,System.Threading.CancellationToken).catCommand'></a>

`catCommand` [ICatCommand](ICatCommand.md 'Cat\.Commands\.Abstractions\.ICatCommand')

The command to run\.

<a name='Cat.Commands.Abstractions.ICatCurrentScopeCommandProcessor.ProcessInCurrentScopeAsync(Cat.Commands.Abstractions.ICatCommand,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Token to cancel the work\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[ICatResponse](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The response of the handler\.

<a name='Cat.Commands.Abstractions.ICatCurrentScopeCommandProcessor.ProcessInCurrentScopeAsync_TResult_(Cat.Commands.Abstractions.ICatCommand_TResult_,System.Threading.CancellationToken)'></a>

## ICatCurrentScopeCommandProcessor\.ProcessInCurrentScopeAsync\<TResult\>\(ICatCommand\<TResult\>, CancellationToken\) Method

Runs a command that returns a result, in the scope of the caller\.

```csharp
System.Threading.Tasks.Task<Cat.Responses.Abstractions.ICatResponse<TResult>> ProcessInCurrentScopeAsync<TResult>(Cat.Commands.Abstractions.ICatCommand<TResult> catCommand, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Type parameters

<a name='Cat.Commands.Abstractions.ICatCurrentScopeCommandProcessor.ProcessInCurrentScopeAsync_TResult_(Cat.Commands.Abstractions.ICatCommand_TResult_,System.Threading.CancellationToken).TResult'></a>

`TResult`

The type of the data the command returns\.
#### Parameters

<a name='Cat.Commands.Abstractions.ICatCurrentScopeCommandProcessor.ProcessInCurrentScopeAsync_TResult_(Cat.Commands.Abstractions.ICatCommand_TResult_,System.Threading.CancellationToken).catCommand'></a>

`catCommand` [Cat\.Commands\.Abstractions\.ICatCommand&lt;](ICatCommand_TResult_.md 'Cat\.Commands\.Abstractions\.ICatCommand\<TResult\>')[TResult](ICatCurrentScopeCommandProcessor.ProcessInCurrentScopeAsync.md#Cat.Commands.Abstractions.ICatCurrentScopeCommandProcessor.ProcessInCurrentScopeAsync_TResult_(Cat.Commands.Abstractions.ICatCommand_TResult_,System.Threading.CancellationToken).TResult 'Cat\.Commands\.Abstractions\.ICatCurrentScopeCommandProcessor\.ProcessInCurrentScopeAsync\<TResult\>\(Cat\.Commands\.Abstractions\.ICatCommand\<TResult\>, System\.Threading\.CancellationToken\)\.TResult')[&gt;](ICatCommand_TResult_.md 'Cat\.Commands\.Abstractions\.ICatCommand\<TResult\>')

The command to run\.

<a name='Cat.Commands.Abstractions.ICatCurrentScopeCommandProcessor.ProcessInCurrentScopeAsync_TResult_(Cat.Commands.Abstractions.ICatCommand_TResult_,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Token to cancel the work\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Cat\.Responses\.Abstractions\.ICatResponse&lt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[TResult](ICatCurrentScopeCommandProcessor.ProcessInCurrentScopeAsync.md#Cat.Commands.Abstractions.ICatCurrentScopeCommandProcessor.ProcessInCurrentScopeAsync_TResult_(Cat.Commands.Abstractions.ICatCommand_TResult_,System.Threading.CancellationToken).TResult 'Cat\.Commands\.Abstractions\.ICatCurrentScopeCommandProcessor\.ProcessInCurrentScopeAsync\<TResult\>\(Cat\.Commands\.Abstractions\.ICatCommand\<TResult\>, System\.Threading\.CancellationToken\)\.TResult')[&gt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The response of the handler, with the result when it succeeded\.