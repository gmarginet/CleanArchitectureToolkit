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
  
##### >> [Cat\.Commands\.Decorators\.Logging Assembly](index.md 'index') >> [Cat\.Commands\.Decorators\.Logging Namespace](Cat.Commands.Decorators.Logging.md 'Cat\.Commands\.Decorators\.Logging') >> [LoggingDecorator Class](LoggingDecorator.md 'Cat\.Commands\.Decorators\.Logging\.LoggingDecorator') >> [CatCommandHandler&lt;TCommand&gt; Class](LoggingDecorator.CatCommandHandler_TCommand_.md 'Cat\.Commands\.Decorators\.Logging\.LoggingDecorator\.CatCommandHandler\<TCommand\>')

## CatCommandHandler\(ICatCommandHandler\<TCommand\>, ILogger\<CatCommandHandler\<TCommand\>\>\) Constructor

Creates the decorator\.

```csharp
public CatCommandHandler(Cat.Commands.Abstractions.ICatCommandHandler<TCommand> innerHandler, Microsoft.Extensions.Logging.ILogger<Cat.Commands.Decorators.Logging.LoggingDecorator.CatCommandHandler<TCommand>> logger);
```
#### Parameters

<a name='Cat.Commands.Decorators.Logging.LoggingDecorator.CatCommandHandler_TCommand_.CatCommandHandler(Cat.Commands.Abstractions.ICatCommandHandler_TCommand_,Microsoft.Extensions.Logging.ILogger_Cat.Commands.Decorators.Logging.LoggingDecorator.CatCommandHandler_TCommand__).innerHandler'></a>

`innerHandler` [Cat\.Commands\.Abstractions\.ICatCommandHandler&lt;](../../../Cat.Commands/namespaces/Cat.Commands.Abstractions/ICatCommandHandler_TCommand_.md 'Cat\.Commands\.Abstractions\.ICatCommandHandler\`1')[TCommand](LoggingDecorator.CatCommandHandler_TCommand_.md#Cat.Commands.Decorators.Logging.LoggingDecorator.CatCommandHandler_TCommand_.TCommand 'Cat\.Commands\.Decorators\.Logging\.LoggingDecorator\.CatCommandHandler\<TCommand\>\.TCommand')[&gt;](../../../Cat.Commands/namespaces/Cat.Commands.Abstractions/ICatCommandHandler_TCommand_.md 'Cat\.Commands\.Abstractions\.ICatCommandHandler\`1')

The handler to wrap\.

<a name='Cat.Commands.Decorators.Logging.LoggingDecorator.CatCommandHandler_TCommand_.CatCommandHandler(Cat.Commands.Abstractions.ICatCommandHandler_TCommand_,Microsoft.Extensions.Logging.ILogger_Cat.Commands.Decorators.Logging.LoggingDecorator.CatCommandHandler_TCommand__).logger'></a>

`logger` [Microsoft\.Extensions\.Logging\.ILogger&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')[Cat\.Commands\.Decorators\.Logging\.LoggingDecorator\.CatCommandHandler&lt;](LoggingDecorator.CatCommandHandler_TCommand_.md 'Cat\.Commands\.Decorators\.Logging\.LoggingDecorator\.CatCommandHandler\<TCommand\>')[TCommand](LoggingDecorator.CatCommandHandler_TCommand_.md#Cat.Commands.Decorators.Logging.LoggingDecorator.CatCommandHandler_TCommand_.TCommand 'Cat\.Commands\.Decorators\.Logging\.LoggingDecorator\.CatCommandHandler\<TCommand\>\.TCommand')[&gt;](LoggingDecorator.CatCommandHandler_TCommand_.md 'Cat\.Commands\.Decorators\.Logging\.LoggingDecorator\.CatCommandHandler\<TCommand\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')

Receives the log entries\.