<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Commands\.Abstractions](index.md 'index') > [Cat\.Commands\.Abstractions](Cat.Commands.Abstractions.md 'Cat\.Commands\.Abstractions') > [ICatCommandHandler&lt;TCommand&gt;](ICatCommandHandler_TCommand_.md 'Cat\.Commands\.Abstractions\.ICatCommandHandler\<TCommand\>')

## ICatCommandHandler\<TCommand\>\.HandleAsync\(TCommand, CancellationToken\) Method

Runs the command\.

```csharp
System.Threading.Tasks.Task<Cat.Responses.Abstractions.ICatResponse> HandleAsync(TCommand command, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Cat.Commands.Abstractions.ICatCommandHandler_TCommand_.HandleAsync(TCommand,System.Threading.CancellationToken).command'></a>

`command` [TCommand](ICatCommandHandler_TCommand_.md#Cat.Commands.Abstractions.ICatCommandHandler_TCommand_.TCommand 'Cat\.Commands\.Abstractions\.ICatCommandHandler\<TCommand\>\.TCommand')

The command to handle\.

<a name='Cat.Commands.Abstractions.ICatCommandHandler_TCommand_.HandleAsync(TCommand,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Token to cancel the work\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[ICatResponse](../Cat.Responses.Abstractions/ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A response that tells whether the command succeeded, and why not if it failed\.