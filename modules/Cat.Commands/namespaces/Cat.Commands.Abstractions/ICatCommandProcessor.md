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
  
##### >> [Cat\.Commands\.Abstractions Assembly](index.md 'index') >> [Cat\.Commands\.Abstractions Namespace](Cat.Commands.Abstractions.md 'Cat\.Commands\.Abstractions')

## ICatCommandProcessor Interface

Single entry point for running commands\.
It finds the handler for a command, runs it through the registered decorators and returns the response\.

```csharp
public interface ICatCommandProcessor
```

| Methods | |
| :--- | :--- |
| [Process\(ICatCommand\)](ICatCommandProcessor.Process.md#Cat.Commands.Abstractions.ICatCommandProcessor.Process(Cat.Commands.Abstractions.ICatCommand) 'Cat\.Commands\.Abstractions\.ICatCommandProcessor\.Process\(Cat\.Commands\.Abstractions\.ICatCommand\)') | Runs a command and blocks until it finishes\. Prefer [ProcessAsync\(ICatCommand, CancellationToken\)](ICatCommandProcessor.ProcessAsync.md#Cat.Commands.Abstractions.ICatCommandProcessor.ProcessAsync(Cat.Commands.Abstractions.ICatCommand,System.Threading.CancellationToken) 'Cat\.Commands\.Abstractions\.ICatCommandProcessor\.ProcessAsync\(Cat\.Commands\.Abstractions\.ICatCommand, System\.Threading\.CancellationToken\)') when you can\. |
| [Process&lt;TResult&gt;\(ICatCommand&lt;TResult&gt;\)](ICatCommandProcessor.Process.md#Cat.Commands.Abstractions.ICatCommandProcessor.Process_TResult_(Cat.Commands.Abstractions.ICatCommand_TResult_) 'Cat\.Commands\.Abstractions\.ICatCommandProcessor\.Process\<TResult\>\(Cat\.Commands\.Abstractions\.ICatCommand\<TResult\>\)') | Runs a command that returns a result and blocks until it finishes\. Prefer [ProcessAsync&lt;TResult&gt;\(ICatCommand&lt;TResult&gt;, CancellationToken\)](ICatCommandProcessor.ProcessAsync.md#Cat.Commands.Abstractions.ICatCommandProcessor.ProcessAsync_TResult_(Cat.Commands.Abstractions.ICatCommand_TResult_,System.Threading.CancellationToken) 'Cat\.Commands\.Abstractions\.ICatCommandProcessor\.ProcessAsync\<TResult\>\(Cat\.Commands\.Abstractions\.ICatCommand\<TResult\>, System\.Threading\.CancellationToken\)') when you can\. |
| [ProcessAsync\(ICatCommand, CancellationToken\)](ICatCommandProcessor.ProcessAsync.md#Cat.Commands.Abstractions.ICatCommandProcessor.ProcessAsync(Cat.Commands.Abstractions.ICatCommand,System.Threading.CancellationToken) 'Cat\.Commands\.Abstractions\.ICatCommandProcessor\.ProcessAsync\(Cat\.Commands\.Abstractions\.ICatCommand, System\.Threading\.CancellationToken\)') | Runs a command\. |
| [ProcessAsync&lt;TResult&gt;\(ICatCommand&lt;TResult&gt;, CancellationToken\)](ICatCommandProcessor.ProcessAsync.md#Cat.Commands.Abstractions.ICatCommandProcessor.ProcessAsync_TResult_(Cat.Commands.Abstractions.ICatCommand_TResult_,System.Threading.CancellationToken) 'Cat\.Commands\.Abstractions\.ICatCommandProcessor\.ProcessAsync\<TResult\>\(Cat\.Commands\.Abstractions\.ICatCommand\<TResult\>, System\.Threading\.CancellationToken\)') | Runs a command that returns a result\. |
