<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Commands\.Decorators\.Logging](index.md 'index') > [Cat\.Commands\.Decorators\.Logging](Cat.Commands.Decorators.Logging.md 'Cat\.Commands\.Decorators\.Logging') > [LoggingDecorator](LoggingDecorator.md 'Cat\.Commands\.Decorators\.Logging\.LoggingDecorator') > [CatCommandHandler&lt;TCommand&gt;](LoggingDecorator.CatCommandHandler_TCommand_.md 'Cat\.Commands\.Decorators\.Logging\.LoggingDecorator\.CatCommandHandler\<TCommand\>')

## LoggingDecorator\.CatCommandHandler\<TCommand\>\.HandleAsync\(TCommand, CancellationToken\) Method

Runs the command\.

```csharp
public System.Threading.Tasks.Task<Cat.Responses.Abstractions.ICatResponse> HandleAsync(TCommand command, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Cat.Commands.Decorators.Logging.LoggingDecorator.CatCommandHandler_TCommand_.HandleAsync(TCommand,System.Threading.CancellationToken).command'></a>

`command` [TCommand](LoggingDecorator.CatCommandHandler_TCommand_.md#Cat.Commands.Decorators.Logging.LoggingDecorator.CatCommandHandler_TCommand_.TCommand 'Cat\.Commands\.Decorators\.Logging\.LoggingDecorator\.CatCommandHandler\<TCommand\>\.TCommand')

The command to handle\.

<a name='Cat.Commands.Decorators.Logging.LoggingDecorator.CatCommandHandler_TCommand_.HandleAsync(TCommand,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Token to cancel the work\.

Implements [HandleAsync\(TCommand, CancellationToken\)](..\Cat.Commands.Abstractions\ICatCommandHandler_TCommand_.HandleAsync.DOGO4I1C9KLZNF43493MH80JB.md 'Cat\.Commands\.Abstractions\.ICatCommandHandler\`1\.HandleAsync\(\`0,System\.Threading\.CancellationToken\)')

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[ICatResponse](..\Cat.Responses.Abstractions\ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A response that tells whether the command succeeded, and why not if it failed\.