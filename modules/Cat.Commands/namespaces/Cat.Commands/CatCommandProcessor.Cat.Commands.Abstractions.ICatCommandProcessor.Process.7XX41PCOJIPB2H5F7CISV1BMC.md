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

|&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[CAT.COMMANDS](../../README.md)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Commands Assembly](index.md 'index') >> [Cat\.Commands Namespace](Cat.Commands.md 'Cat\.Commands') >> [CatCommandProcessor Class](CatCommandProcessor.md 'Cat\.Commands\.CatCommandProcessor')

## Cat\.Commands\.Abstractions\.ICatCommandProcessor\.Process\(ICatCommand\) Method

Runs a command and blocks until it finishes\.
Prefer [ProcessAsync\(ICatCommand, CancellationToken\)](../../../Cat.Commands/namespaces/Cat.Commands.Abstractions/ICatCommandProcessor.ProcessAsync.VVA0QGJV7BSKJ1729JAXLLQT8.md 'Cat\.Commands\.Abstractions\.ICatCommandProcessor\.ProcessAsync\(Cat\.Commands\.Abstractions\.ICatCommand,System\.Threading\.CancellationToken\)') when you can\.

```csharp
Cat.Responses.Abstractions.ICatResponse Cat.Commands.Abstractions.ICatCommandProcessor.Process(Cat.Commands.Abstractions.ICatCommand catCommand);
```
#### Parameters

<a name='Cat.Commands.CatCommandProcessor.Cat.Commands.Abstractions.ICatCommandProcessor.Process(Cat.Commands.Abstractions.ICatCommand).catCommand'></a>

`catCommand` [ICatCommand](../../../Cat.Commands/namespaces/Cat.Commands.Abstractions/ICatCommand.md 'Cat\.Commands\.Abstractions\.ICatCommand')

The command to run\.

Implements [Process\(ICatCommand\)](../../../Cat.Commands/namespaces/Cat.Commands.Abstractions/ICatCommandProcessor.Process.9MU4QN6WCH1S6MMMR76OOR6KE.md 'Cat\.Commands\.Abstractions\.ICatCommandProcessor\.Process\(Cat\.Commands\.Abstractions\.ICatCommand\)')