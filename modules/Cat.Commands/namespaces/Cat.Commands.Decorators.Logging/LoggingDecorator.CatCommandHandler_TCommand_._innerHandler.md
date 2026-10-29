<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Commands\.Decorators\.Logging](index.md 'index') > [Cat\.Commands\.Decorators\.Logging](Cat.Commands.Decorators.Logging.md 'Cat\.Commands\.Decorators\.Logging') > [LoggingDecorator](LoggingDecorator.md 'Cat\.Commands\.Decorators\.Logging\.LoggingDecorator') > [CatCommandHandler&lt;TCommand&gt;](LoggingDecorator.CatCommandHandler_TCommand_.md 'Cat\.Commands\.Decorators\.Logging\.LoggingDecorator\.CatCommandHandler\<TCommand\>')

## LoggingDecorator\.CatCommandHandler\<TCommand\>\.\_innerHandler Field

```csharp
private readonly ICatCommandHandler<TCommand> _innerHandler;
```

#### Field Value
[Cat\.Commands\.Abstractions\.ICatCommandHandler&lt;](..\Cat.Commands.Abstractions\ICatCommandHandler_TCommand_.md 'Cat\.Commands\.Abstractions\.ICatCommandHandler\`1')[TCommand](LoggingDecorator.CatCommandHandler_TCommand_.md#Cat.Commands.Decorators.Logging.LoggingDecorator.CatCommandHandler_TCommand_.TCommand 'Cat\.Commands\.Decorators\.Logging\.LoggingDecorator\.CatCommandHandler\<TCommand\>\.TCommand')[&gt;](..\Cat.Commands.Abstractions\ICatCommandHandler_TCommand_.md 'Cat\.Commands\.Abstractions\.ICatCommandHandler\`1')