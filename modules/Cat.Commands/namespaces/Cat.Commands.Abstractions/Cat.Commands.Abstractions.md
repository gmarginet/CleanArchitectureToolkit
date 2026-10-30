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
            <img src='../../../../resources/logo/CatLogo-RoundedCorners-320x160.png' alt='' width='200' style='float: right;'/>
        </td>
    </tr>
    <tr>
        <td colspan='6' markdown='1' style='padding-left: 0; padding-right: 0; padding-top: 15px; padding-bottom: 0; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>

|&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[CAT.COMMANDS](../../README.md)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Commands\.Abstractions Assembly](index.md 'index')

## Cat\.Commands\.Abstractions Namespace

Defines the contracts for commands: the command marker, the handlers that run them,
and the processor that finds the right handler and returns an [ICatResponse](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse')\.

| Interfaces | |
| :--- | :--- |
| [ICatCommand](ICatCommand.md 'Cat\.Commands\.Abstractions\.ICatCommand') | Marks a command that changes state and returns a response without a payload\. Handle it with [ICatCommandHandler&lt;TCommand&gt;](ICatCommandHandler_TCommand_.md 'Cat\.Commands\.Abstractions\.ICatCommandHandler\<TCommand\>')\. |
| [ICatCommandHandler&lt;TCommand&gt;](ICatCommandHandler_TCommand_.md 'Cat\.Commands\.Abstractions\.ICatCommandHandler\<TCommand\>') | Handles one kind of command\. Implement it once per command type\. The module finds and registers it for you\. |
| [ICatCommandProcessor](ICatCommandProcessor.md 'Cat\.Commands\.Abstractions\.ICatCommandProcessor') | Single entry point for running commands\. It finds the handler for a command, runs it through the registered decorators and returns the response\. |
