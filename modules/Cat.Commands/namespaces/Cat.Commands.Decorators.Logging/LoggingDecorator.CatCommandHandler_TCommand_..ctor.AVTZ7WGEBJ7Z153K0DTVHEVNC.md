<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Commands\.Decorators\.Logging](index.md 'index') > [Cat\.Commands\.Decorators\.Logging](Cat.Commands.Decorators.Logging.md 'Cat\.Commands\.Decorators\.Logging') > [LoggingDecorator](LoggingDecorator.md 'Cat\.Commands\.Decorators\.Logging\.LoggingDecorator') > [CatCommandHandler&lt;TCommand&gt;](LoggingDecorator.CatCommandHandler_TCommand_.md 'Cat\.Commands\.Decorators\.Logging\.LoggingDecorator\.CatCommandHandler\<TCommand\>')

## CatCommandHandler\(ICatCommandHandler\<TCommand\>, ILogger\<CatCommandHandler\<TCommand\>\>\) Constructor

Creates the decorator\.

```csharp
public CatCommandHandler(Cat.Commands.Abstractions.ICatCommandHandler<TCommand> innerHandler, Microsoft.Extensions.Logging.ILogger<Cat.Commands.Decorators.Logging.LoggingDecorator.CatCommandHandler<TCommand>> logger);
```
#### Parameters

<a name='Cat.Commands.Decorators.Logging.LoggingDecorator.CatCommandHandler_TCommand_.CatCommandHandler(Cat.Commands.Abstractions.ICatCommandHandler_TCommand_,Microsoft.Extensions.Logging.ILogger_Cat.Commands.Decorators.Logging.LoggingDecorator.CatCommandHandler_TCommand__).innerHandler'></a>

`innerHandler` [Cat\.Commands\.Abstractions\.ICatCommandHandler&lt;](..\Cat.Commands.Abstractions\ICatCommandHandler_TCommand_.md 'Cat\.Commands\.Abstractions\.ICatCommandHandler\`1')[TCommand](LoggingDecorator.CatCommandHandler_TCommand_.md#Cat.Commands.Decorators.Logging.LoggingDecorator.CatCommandHandler_TCommand_.TCommand 'Cat\.Commands\.Decorators\.Logging\.LoggingDecorator\.CatCommandHandler\<TCommand\>\.TCommand')[&gt;](..\Cat.Commands.Abstractions\ICatCommandHandler_TCommand_.md 'Cat\.Commands\.Abstractions\.ICatCommandHandler\`1')

The handler to wrap\.

<a name='Cat.Commands.Decorators.Logging.LoggingDecorator.CatCommandHandler_TCommand_.CatCommandHandler(Cat.Commands.Abstractions.ICatCommandHandler_TCommand_,Microsoft.Extensions.Logging.ILogger_Cat.Commands.Decorators.Logging.LoggingDecorator.CatCommandHandler_TCommand__).logger'></a>

`logger` [Microsoft\.Extensions\.Logging\.ILogger&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')[Cat\.Commands\.Decorators\.Logging\.LoggingDecorator\.CatCommandHandler&lt;](LoggingDecorator.CatCommandHandler_TCommand_.md 'Cat\.Commands\.Decorators\.Logging\.LoggingDecorator\.CatCommandHandler\<TCommand\>')[TCommand](LoggingDecorator.CatCommandHandler_TCommand_.md#Cat.Commands.Decorators.Logging.LoggingDecorator.CatCommandHandler_TCommand_.TCommand 'Cat\.Commands\.Decorators\.Logging\.LoggingDecorator\.CatCommandHandler\<TCommand\>\.TCommand')[&gt;](LoggingDecorator.CatCommandHandler_TCommand_.md 'Cat\.Commands\.Decorators\.Logging\.LoggingDecorator\.CatCommandHandler\<TCommand\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')

Receives the log entries\.