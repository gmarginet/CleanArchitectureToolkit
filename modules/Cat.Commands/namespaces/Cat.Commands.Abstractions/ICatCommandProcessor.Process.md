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
  
##### >> [Cat\.Commands\.Abstractions Assembly](index.md 'index') >> [Cat\.Commands\.Abstractions Namespace](Cat.Commands.Abstractions.md 'Cat\.Commands\.Abstractions') >> [ICatCommandProcessor Interface](ICatCommandProcessor.md 'Cat\.Commands\.Abstractions\.ICatCommandProcessor')

## ICatCommandProcessor\.Process Method

| Overloads | |
| :--- | :--- |
| [Process\(ICatCommand\)](ICatCommandProcessor.Process.md#Cat.Commands.Abstractions.ICatCommandProcessor.Process(Cat.Commands.Abstractions.ICatCommand) 'Cat\.Commands\.Abstractions\.ICatCommandProcessor\.Process\(Cat\.Commands\.Abstractions\.ICatCommand\)') | Runs a command and blocks until it finishes\. Prefer [ProcessAsync\(ICatCommand, CancellationToken\)](ICatCommandProcessor.ProcessAsync.md#Cat.Commands.Abstractions.ICatCommandProcessor.ProcessAsync(Cat.Commands.Abstractions.ICatCommand,System.Threading.CancellationToken) 'Cat\.Commands\.Abstractions\.ICatCommandProcessor\.ProcessAsync\(Cat\.Commands\.Abstractions\.ICatCommand, System\.Threading\.CancellationToken\)') when you can\. |
| [Process&lt;TResult&gt;\(ICatCommand&lt;TResult&gt;\)](ICatCommandProcessor.Process.md#Cat.Commands.Abstractions.ICatCommandProcessor.Process_TResult_(Cat.Commands.Abstractions.ICatCommand_TResult_) 'Cat\.Commands\.Abstractions\.ICatCommandProcessor\.Process\<TResult\>\(Cat\.Commands\.Abstractions\.ICatCommand\<TResult\>\)') | Runs a command that returns a result and blocks until it finishes\. Prefer [ProcessAsync&lt;TResult&gt;\(ICatCommand&lt;TResult&gt;, CancellationToken\)](ICatCommandProcessor.ProcessAsync.md#Cat.Commands.Abstractions.ICatCommandProcessor.ProcessAsync_TResult_(Cat.Commands.Abstractions.ICatCommand_TResult_,System.Threading.CancellationToken) 'Cat\.Commands\.Abstractions\.ICatCommandProcessor\.ProcessAsync\<TResult\>\(Cat\.Commands\.Abstractions\.ICatCommand\<TResult\>, System\.Threading\.CancellationToken\)') when you can\. |

<a name='Cat.Commands.Abstractions.ICatCommandProcessor.Process(Cat.Commands.Abstractions.ICatCommand)'></a>

## ICatCommandProcessor\.Process\(ICatCommand\) Method

Runs a command and blocks until it finishes\.
Prefer [ProcessAsync\(ICatCommand, CancellationToken\)](ICatCommandProcessor.ProcessAsync.md#Cat.Commands.Abstractions.ICatCommandProcessor.ProcessAsync(Cat.Commands.Abstractions.ICatCommand,System.Threading.CancellationToken) 'Cat\.Commands\.Abstractions\.ICatCommandProcessor\.ProcessAsync\(Cat\.Commands\.Abstractions\.ICatCommand, System\.Threading\.CancellationToken\)') when you can\.

```csharp
Cat.Responses.Abstractions.ICatResponse Process(Cat.Commands.Abstractions.ICatCommand catCommand);
```
#### Parameters

<a name='Cat.Commands.Abstractions.ICatCommandProcessor.Process(Cat.Commands.Abstractions.ICatCommand).catCommand'></a>

`catCommand` [ICatCommand](ICatCommand.md 'Cat\.Commands\.Abstractions\.ICatCommand')

The command to run\.

#### Returns
[ICatResponse](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse')  
The response of the handler\.

<a name='Cat.Commands.Abstractions.ICatCommandProcessor.Process_TResult_(Cat.Commands.Abstractions.ICatCommand_TResult_)'></a>

## ICatCommandProcessor\.Process\<TResult\>\(ICatCommand\<TResult\>\) Method

Runs a command that returns a result and blocks until it finishes\.
Prefer [ProcessAsync&lt;TResult&gt;\(ICatCommand&lt;TResult&gt;, CancellationToken\)](ICatCommandProcessor.ProcessAsync.md#Cat.Commands.Abstractions.ICatCommandProcessor.ProcessAsync_TResult_(Cat.Commands.Abstractions.ICatCommand_TResult_,System.Threading.CancellationToken) 'Cat\.Commands\.Abstractions\.ICatCommandProcessor\.ProcessAsync\<TResult\>\(Cat\.Commands\.Abstractions\.ICatCommand\<TResult\>, System\.Threading\.CancellationToken\)') when you can\.

```csharp
Cat.Responses.Abstractions.ICatResponse<TResult> Process<TResult>(Cat.Commands.Abstractions.ICatCommand<TResult> catCommand);
```
#### Type parameters

<a name='Cat.Commands.Abstractions.ICatCommandProcessor.Process_TResult_(Cat.Commands.Abstractions.ICatCommand_TResult_).TResult'></a>

`TResult`

The type of the data the command returns\.
#### Parameters

<a name='Cat.Commands.Abstractions.ICatCommandProcessor.Process_TResult_(Cat.Commands.Abstractions.ICatCommand_TResult_).catCommand'></a>

`catCommand` [Cat\.Commands\.Abstractions\.ICatCommand&lt;](ICatCommand_TResult_.md 'Cat\.Commands\.Abstractions\.ICatCommand\<TResult\>')[TResult](ICatCommandProcessor.Process.md#Cat.Commands.Abstractions.ICatCommandProcessor.Process_TResult_(Cat.Commands.Abstractions.ICatCommand_TResult_).TResult 'Cat\.Commands\.Abstractions\.ICatCommandProcessor\.Process\<TResult\>\(Cat\.Commands\.Abstractions\.ICatCommand\<TResult\>\)\.TResult')[&gt;](ICatCommand_TResult_.md 'Cat\.Commands\.Abstractions\.ICatCommand\<TResult\>')

The command to run\.

#### Returns
[Cat\.Responses\.Abstractions\.ICatResponse&lt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[TResult](ICatCommandProcessor.Process.md#Cat.Commands.Abstractions.ICatCommandProcessor.Process_TResult_(Cat.Commands.Abstractions.ICatCommand_TResult_).TResult 'Cat\.Commands\.Abstractions\.ICatCommandProcessor\.Process\<TResult\>\(Cat\.Commands\.Abstractions\.ICatCommand\<TResult\>\)\.TResult')[&gt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')  
The response of the handler, with the result when it succeeded\.