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
  
##### >> [Cat\.Commands\.Decorators\.Logging Assembly](index.md 'index') >> [Cat\.Commands\.Decorators\.Logging Namespace](Cat.Commands.Decorators.Logging.md 'Cat\.Commands\.Decorators\.Logging') >> [LoggingDecorator Class](LoggingDecorator.md 'Cat\.Commands\.Decorators\.Logging\.LoggingDecorator')

## LoggingDecorator\.CatCommandHandler\<TCommand\> Class

Logs the start and end of a command handler\.

```csharp
internal sealed class LoggingDecorator.CatCommandHandler<TCommand> : Cat.Commands.Abstractions.ICatCommandHandler<TCommand>
    where TCommand : class, Cat.Commands.Abstractions.ICatCommand
```
#### Type parameters

<a name='Cat.Commands.Decorators.Logging.LoggingDecorator.CatCommandHandler_TCommand_.TCommand'></a>

`TCommand`

The command being handled\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatCommandHandler\<TCommand\>

Implements [Cat\.Commands\.Abstractions\.ICatCommandHandler&lt;](../../../Cat.Commands/namespaces/Cat.Commands.Abstractions/ICatCommandHandler_TCommand_.md 'Cat\.Commands\.Abstractions\.ICatCommandHandler\`1')[TCommand](LoggingDecorator.CatCommandHandler_TCommand_.md#Cat.Commands.Decorators.Logging.LoggingDecorator.CatCommandHandler_TCommand_.TCommand 'Cat\.Commands\.Decorators\.Logging\.LoggingDecorator\.CatCommandHandler\<TCommand\>\.TCommand')[&gt;](../../../Cat.Commands/namespaces/Cat.Commands.Abstractions/ICatCommandHandler_TCommand_.md 'Cat\.Commands\.Abstractions\.ICatCommandHandler\`1')

| Constructors | |
| :--- | :--- |
| [CatCommandHandler\(ICatCommandHandler&lt;TCommand&gt;, ILogger&lt;CatCommandHandler&lt;TCommand&gt;&gt;\)](LoggingDecorator.CatCommandHandler_TCommand_..ctor.AVTZ7WGEBJ7Z153K0DTVHEVNC.md 'Cat\.Commands\.Decorators\.Logging\.LoggingDecorator\.CatCommandHandler\<TCommand\>\.CatCommandHandler\(Cat\.Commands\.Abstractions\.ICatCommandHandler\<TCommand\>, Microsoft\.Extensions\.Logging\.ILogger\<Cat\.Commands\.Decorators\.Logging\.LoggingDecorator\.CatCommandHandler\<TCommand\>\>\)') | Creates the decorator\. |

| Fields | |
| :--- | :--- |
| [\_innerHandler](LoggingDecorator.CatCommandHandler_TCommand_._innerHandler.md 'Cat\.Commands\.Decorators\.Logging\.LoggingDecorator\.CatCommandHandler\<TCommand\>\.\_innerHandler') | |
| [\_logger](LoggingDecorator.CatCommandHandler_TCommand_._logger.md 'Cat\.Commands\.Decorators\.Logging\.LoggingDecorator\.CatCommandHandler\<TCommand\>\.\_logger') | |

| Methods | |
| :--- | :--- |
| [HandleAsync\(TCommand, CancellationToken\)](LoggingDecorator.CatCommandHandler_TCommand_.HandleAsync.CBT0B0F3QAWO93YN8WOVYH7W8.md 'Cat\.Commands\.Decorators\.Logging\.LoggingDecorator\.CatCommandHandler\<TCommand\>\.HandleAsync\(TCommand, System\.Threading\.CancellationToken\)') | Runs the command\. |
