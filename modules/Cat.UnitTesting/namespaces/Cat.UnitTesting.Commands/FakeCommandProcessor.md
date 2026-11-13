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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.UNITTESTING](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.UnitTesting\.Commands Assembly](index.md 'index') >> [Cat\.UnitTesting\.Commands Namespace](Cat.UnitTesting.Commands.md 'Cat\.UnitTesting\.Commands')

## FakeCommandProcessor Class

A command processor for unit tests\. It records every command and returns what the test says\.
It fills no ids and sets no timestamps, the test decides the whole answer\.

```csharp
public class FakeCommandProcessor : Cat.Commands.Abstractions.ICatCommandProcessor
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → FakeCommandProcessor

Implements [ICatCommandProcessor](../../../Cat.Commands/namespaces/Cat.Commands.Abstractions/ICatCommandProcessor.md 'Cat\.Commands\.Abstractions\.ICatCommandProcessor')

| Fields | |
| :--- | :--- |
| [\_responses](FakeCommandProcessor._responses.md 'Cat\.UnitTesting\.Commands\.FakeCommandProcessor\.\_responses') | |

| Properties | |
| :--- | :--- |
| [Commands](FakeCommandProcessor.Commands.md 'Cat\.UnitTesting\.Commands\.FakeCommandProcessor\.Commands') | Every command that was processed, in order\. It holds commands with and without a result\. |
| [DefaultResponse](FakeCommandProcessor.DefaultResponse.md 'Cat\.UnitTesting\.Commands\.FakeCommandProcessor\.DefaultResponse') | The response of a command without a result when the test set up nothing for its type\. It starts as [Ok\(\)](../../../Cat.Responses/namespaces/Cat.Responses/CatResponse.Ok.md#Cat.Responses.CatResponse.Ok() 'Cat\.Responses\.CatResponse\.Ok')\. |

| Methods | |
| :--- | :--- |
| [Of&lt;T&gt;\(\)](FakeCommandProcessor.Of_T_().md 'Cat\.UnitTesting\.Commands\.FakeCommandProcessor\.Of\<T\>\(\)') | Gives the processed commands of one type, in order\. |
| [Process\(ICatCommand\)](FakeCommandProcessor.Process.md#Cat.UnitTesting.Commands.FakeCommandProcessor.Process(Cat.Commands.Abstractions.ICatCommand) 'Cat\.UnitTesting\.Commands\.FakeCommandProcessor\.Process\(Cat\.Commands\.Abstractions\.ICatCommand\)') | Runs a command and blocks until it finishes\. Prefer [ProcessAsync\(ICatCommand, CancellationToken\)](../../../Cat.Commands/namespaces/Cat.Commands.Abstractions/ICatCommandProcessor.ProcessAsync.md#Cat.Commands.Abstractions.ICatCommandProcessor.ProcessAsync(Cat.Commands.Abstractions.ICatCommand,System.Threading.CancellationToken) 'Cat\.Commands\.Abstractions\.ICatCommandProcessor\.ProcessAsync\(Cat\.Commands\.Abstractions\.ICatCommand,System\.Threading\.CancellationToken\)') when you can\. |
| [Process&lt;TResult&gt;\(ICatCommand&lt;TResult&gt;\)](FakeCommandProcessor.Process.md#Cat.UnitTesting.Commands.FakeCommandProcessor.Process_TResult_(Cat.Commands.Abstractions.ICatCommand_TResult_) 'Cat\.UnitTesting\.Commands\.FakeCommandProcessor\.Process\<TResult\>\(Cat\.Commands\.Abstractions\.ICatCommand\<TResult\>\)') | Runs a command that returns a result and blocks until it finishes\. Prefer [ProcessAsync&lt;TResult&gt;\(ICatCommand&lt;TResult&gt;, CancellationToken\)](../../../Cat.Commands/namespaces/Cat.Commands.Abstractions/ICatCommandProcessor.ProcessAsync.md#Cat.Commands.Abstractions.ICatCommandProcessor.ProcessAsync_TResult_(Cat.Commands.Abstractions.ICatCommand_TResult_,System.Threading.CancellationToken) 'Cat\.Commands\.Abstractions\.ICatCommandProcessor\.ProcessAsync\`\`1\(Cat\.Commands\.Abstractions\.ICatCommand\{\`\`0\},System\.Threading\.CancellationToken\)') when you can\. |
| [ProcessAsync\(ICatCommand, CancellationToken\)](FakeCommandProcessor.ProcessAsync.md#Cat.UnitTesting.Commands.FakeCommandProcessor.ProcessAsync(Cat.Commands.Abstractions.ICatCommand,System.Threading.CancellationToken) 'Cat\.UnitTesting\.Commands\.FakeCommandProcessor\.ProcessAsync\(Cat\.Commands\.Abstractions\.ICatCommand, System\.Threading\.CancellationToken\)') | Runs a command\. |
| [ProcessAsync&lt;TResult&gt;\(ICatCommand&lt;TResult&gt;, CancellationToken\)](FakeCommandProcessor.ProcessAsync.md#Cat.UnitTesting.Commands.FakeCommandProcessor.ProcessAsync_TResult_(Cat.Commands.Abstractions.ICatCommand_TResult_,System.Threading.CancellationToken) 'Cat\.UnitTesting\.Commands\.FakeCommandProcessor\.ProcessAsync\<TResult\>\(Cat\.Commands\.Abstractions\.ICatCommand\<TResult\>, System\.Threading\.CancellationToken\)') | Runs a command that returns a result\. |
| [Reset\(\)](FakeCommandProcessor.Reset().md 'Cat\.UnitTesting\.Commands\.FakeCommandProcessor\.Reset\(\)') | Clears the recorded commands, the set up responses and the default response\. |
| [Respond&lt;TCommand,TResult&gt;\(ICatResponse&lt;TResult&gt;\)](FakeCommandProcessor.Respond.md#Cat.UnitTesting.Commands.FakeCommandProcessor.Respond_TCommand,TResult_(Cat.Responses.Abstractions.ICatResponse_TResult_) 'Cat\.UnitTesting\.Commands\.FakeCommandProcessor\.Respond\<TCommand,TResult\>\(Cat\.Responses\.Abstractions\.ICatResponse\<TResult\>\)') | Sets the response for a command with a result\. |
| [Respond&lt;TCommand,TResult&gt;\(Func&lt;TCommand,ICatResponse&lt;TResult&gt;&gt;\)](FakeCommandProcessor.Respond.md#Cat.UnitTesting.Commands.FakeCommandProcessor.Respond_TCommand,TResult_(System.Func_TCommand,Cat.Responses.Abstractions.ICatResponse_TResult__) 'Cat\.UnitTesting\.Commands\.FakeCommandProcessor\.Respond\<TCommand,TResult\>\(System\.Func\<TCommand,Cat\.Responses\.Abstractions\.ICatResponse\<TResult\>\>\)') | Sets the response for a command with a result, built from the command\. |
| [Respond&lt;TCommand&gt;\(ICatResponse\)](FakeCommandProcessor.Respond.md#Cat.UnitTesting.Commands.FakeCommandProcessor.Respond_TCommand_(Cat.Responses.Abstractions.ICatResponse) 'Cat\.UnitTesting\.Commands\.FakeCommandProcessor\.Respond\<TCommand\>\(Cat\.Responses\.Abstractions\.ICatResponse\)') | Sets the response for a command without a result\. |
| [Respond&lt;TCommand&gt;\(Func&lt;TCommand,ICatResponse&gt;\)](FakeCommandProcessor.Respond.md#Cat.UnitTesting.Commands.FakeCommandProcessor.Respond_TCommand_(System.Func_TCommand,Cat.Responses.Abstractions.ICatResponse_) 'Cat\.UnitTesting\.Commands\.FakeCommandProcessor\.Respond\<TCommand\>\(System\.Func\<TCommand,Cat\.Responses\.Abstractions\.ICatResponse\>\)') | Sets the response for a command without a result, built from the command\. |
