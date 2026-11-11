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
  
##### >> [Cat\.Commands\.Decorators\.Logging Assembly](index.md 'index') >> [Cat\.Commands\.Decorators\.Logging Namespace](Cat.Commands.Decorators.Logging.md 'Cat\.Commands\.Decorators\.Logging') >> [LoggingDecorator Class](LoggingDecorator.md 'Cat\.Commands\.Decorators\.Logging\.LoggingDecorator')

## LoggingDecorator\.CatCommandHandler\<TCommand,TResult\> Class

Logs the start and end of a command handler that returns a result\.

```csharp
internal sealed class LoggingDecorator.CatCommandHandler<TCommand,TResult> : Cat.Commands.Abstractions.ICatCommandHandler<TCommand, TResult>
    where TCommand : class, Cat.Commands.Abstractions.ICatCommand<TResult>
```
#### Type parameters

<a name='Cat.Commands.Decorators.Logging.LoggingDecorator.CatCommandHandler_TCommand,TResult_.TCommand'></a>

`TCommand`

The command being handled\.

<a name='Cat.Commands.Decorators.Logging.LoggingDecorator.CatCommandHandler_TCommand,TResult_.TResult'></a>

`TResult`

The type of the data the handler returns\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatCommandHandler\<TCommand,TResult\>

Implements [Cat\.Commands\.Abstractions\.ICatCommandHandler&lt;](../../../Cat.Commands/namespaces/Cat.Commands.Abstractions/ICatCommandHandler_TCommand,TResult_.md 'Cat\.Commands\.Abstractions\.ICatCommandHandler\`2')[TCommand](LoggingDecorator.CatCommandHandler_TCommand,TResult_.md#Cat.Commands.Decorators.Logging.LoggingDecorator.CatCommandHandler_TCommand,TResult_.TCommand 'Cat\.Commands\.Decorators\.Logging\.LoggingDecorator\.CatCommandHandler\<TCommand,TResult\>\.TCommand')[,](../../../Cat.Commands/namespaces/Cat.Commands.Abstractions/ICatCommandHandler_TCommand,TResult_.md 'Cat\.Commands\.Abstractions\.ICatCommandHandler\`2')[TResult](LoggingDecorator.CatCommandHandler_TCommand,TResult_.md#Cat.Commands.Decorators.Logging.LoggingDecorator.CatCommandHandler_TCommand,TResult_.TResult 'Cat\.Commands\.Decorators\.Logging\.LoggingDecorator\.CatCommandHandler\<TCommand,TResult\>\.TResult')[&gt;](../../../Cat.Commands/namespaces/Cat.Commands.Abstractions/ICatCommandHandler_TCommand,TResult_.md 'Cat\.Commands\.Abstractions\.ICatCommandHandler\`2')

| Constructors | |
| :--- | :--- |
| [CatCommandHandler\(ICatCommandHandler&lt;TCommand,TResult&gt;, ILogger&lt;CatCommandHandler&lt;TCommand,TResult&gt;&gt;\)](LoggingDecorator.CatCommandHandler_TCommand,TResult_..ctor.LQ9CT4UPV27VI72WHIADL5QQ7.md 'Cat\.Commands\.Decorators\.Logging\.LoggingDecorator\.CatCommandHandler\<TCommand,TResult\>\.CatCommandHandler\(Cat\.Commands\.Abstractions\.ICatCommandHandler\<TCommand,TResult\>, Microsoft\.Extensions\.Logging\.ILogger\<Cat\.Commands\.Decorators\.Logging\.LoggingDecorator\.CatCommandHandler\<TCommand,TResult\>\>\)') | Creates the decorator\. |

| Fields | |
| :--- | :--- |
| [\_innerHandler](LoggingDecorator.CatCommandHandler_TCommand,TResult_._innerHandler.md 'Cat\.Commands\.Decorators\.Logging\.LoggingDecorator\.CatCommandHandler\<TCommand,TResult\>\.\_innerHandler') | |
| [\_logger](LoggingDecorator.CatCommandHandler_TCommand,TResult_._logger.md 'Cat\.Commands\.Decorators\.Logging\.LoggingDecorator\.CatCommandHandler\<TCommand,TResult\>\.\_logger') | |

| Methods | |
| :--- | :--- |
| [HandleAsync\(TCommand, CancellationToken\)](LoggingDecorator.CatCommandHandler_TCommand,TResult_.HandleAsync.W7T6WAEHPAWK9PRWO7DKA32G5.md 'Cat\.Commands\.Decorators\.Logging\.LoggingDecorator\.CatCommandHandler\<TCommand,TResult\>\.HandleAsync\(TCommand, System\.Threading\.CancellationToken\)') | Runs the command\. |
