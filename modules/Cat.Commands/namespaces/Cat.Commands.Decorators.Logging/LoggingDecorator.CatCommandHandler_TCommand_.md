<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Commands\.Decorators\.Logging](index.md 'index') > [Cat\.Commands\.Decorators\.Logging](Cat.Commands.Decorators.Logging.md 'Cat\.Commands\.Decorators\.Logging') > [LoggingDecorator](LoggingDecorator.md 'Cat\.Commands\.Decorators\.Logging\.LoggingDecorator')

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
