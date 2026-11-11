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
  
##### >> [Cat\.Commands\.Decorators\.Logging Assembly](index.md 'index') >> [Cat\.Commands\.Decorators\.Logging Namespace](Cat.Commands.Decorators.Logging.md 'Cat\.Commands\.Decorators\.Logging') >> [LoggingDecorator Class](LoggingDecorator.md 'Cat\.Commands\.Decorators\.Logging\.LoggingDecorator') >> [CatCommandHandler&lt;TCommand,TResult&gt; Class](LoggingDecorator.CatCommandHandler_TCommand,TResult_.md 'Cat\.Commands\.Decorators\.Logging\.LoggingDecorator\.CatCommandHandler\<TCommand,TResult\>')

## CatCommandHandler\(ICatCommandHandler\<TCommand,TResult\>, ILogger\<CatCommandHandler\<TCommand,TResult\>\>\) Constructor

Creates the decorator\.

```csharp
public CatCommandHandler(Cat.Commands.Abstractions.ICatCommandHandler<TCommand,TResult> innerHandler, Microsoft.Extensions.Logging.ILogger<Cat.Commands.Decorators.Logging.LoggingDecorator.CatCommandHandler<TCommand,TResult>> logger);
```
#### Parameters

<a name='Cat.Commands.Decorators.Logging.LoggingDecorator.CatCommandHandler_TCommand,TResult_.CatCommandHandler(Cat.Commands.Abstractions.ICatCommandHandler_TCommand,TResult_,Microsoft.Extensions.Logging.ILogger_Cat.Commands.Decorators.Logging.LoggingDecorator.CatCommandHandler_TCommand,TResult__).innerHandler'></a>

`innerHandler` [Cat\.Commands\.Abstractions\.ICatCommandHandler&lt;](../../../Cat.Commands/namespaces/Cat.Commands.Abstractions/ICatCommandHandler_TCommand,TResult_.md 'Cat\.Commands\.Abstractions\.ICatCommandHandler\`2')[TCommand](LoggingDecorator.CatCommandHandler_TCommand,TResult_.md#Cat.Commands.Decorators.Logging.LoggingDecorator.CatCommandHandler_TCommand,TResult_.TCommand 'Cat\.Commands\.Decorators\.Logging\.LoggingDecorator\.CatCommandHandler\<TCommand,TResult\>\.TCommand')[,](../../../Cat.Commands/namespaces/Cat.Commands.Abstractions/ICatCommandHandler_TCommand,TResult_.md 'Cat\.Commands\.Abstractions\.ICatCommandHandler\`2')[TResult](LoggingDecorator.CatCommandHandler_TCommand,TResult_.md#Cat.Commands.Decorators.Logging.LoggingDecorator.CatCommandHandler_TCommand,TResult_.TResult 'Cat\.Commands\.Decorators\.Logging\.LoggingDecorator\.CatCommandHandler\<TCommand,TResult\>\.TResult')[&gt;](../../../Cat.Commands/namespaces/Cat.Commands.Abstractions/ICatCommandHandler_TCommand,TResult_.md 'Cat\.Commands\.Abstractions\.ICatCommandHandler\`2')

The handler to wrap\.

<a name='Cat.Commands.Decorators.Logging.LoggingDecorator.CatCommandHandler_TCommand,TResult_.CatCommandHandler(Cat.Commands.Abstractions.ICatCommandHandler_TCommand,TResult_,Microsoft.Extensions.Logging.ILogger_Cat.Commands.Decorators.Logging.LoggingDecorator.CatCommandHandler_TCommand,TResult__).logger'></a>

`logger` [Microsoft\.Extensions\.Logging\.ILogger&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')[Cat\.Commands\.Decorators\.Logging\.LoggingDecorator\.CatCommandHandler&lt;](LoggingDecorator.CatCommandHandler_TCommand,TResult_.md 'Cat\.Commands\.Decorators\.Logging\.LoggingDecorator\.CatCommandHandler\<TCommand,TResult\>')[TCommand](LoggingDecorator.CatCommandHandler_TCommand,TResult_.md#Cat.Commands.Decorators.Logging.LoggingDecorator.CatCommandHandler_TCommand,TResult_.TCommand 'Cat\.Commands\.Decorators\.Logging\.LoggingDecorator\.CatCommandHandler\<TCommand,TResult\>\.TCommand')[,](LoggingDecorator.CatCommandHandler_TCommand,TResult_.md 'Cat\.Commands\.Decorators\.Logging\.LoggingDecorator\.CatCommandHandler\<TCommand,TResult\>')[TResult](LoggingDecorator.CatCommandHandler_TCommand,TResult_.md#Cat.Commands.Decorators.Logging.LoggingDecorator.CatCommandHandler_TCommand,TResult_.TResult 'Cat\.Commands\.Decorators\.Logging\.LoggingDecorator\.CatCommandHandler\<TCommand,TResult\>\.TResult')[&gt;](LoggingDecorator.CatCommandHandler_TCommand,TResult_.md 'Cat\.Commands\.Decorators\.Logging\.LoggingDecorator\.CatCommandHandler\<TCommand,TResult\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')

Receives the log entries\.