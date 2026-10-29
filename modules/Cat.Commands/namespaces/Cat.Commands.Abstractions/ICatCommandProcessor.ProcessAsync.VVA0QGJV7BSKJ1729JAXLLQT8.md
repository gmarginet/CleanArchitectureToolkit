<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Commands\.Abstractions](index.md 'index') > [Cat\.Commands\.Abstractions](Cat.Commands.Abstractions.md 'Cat\.Commands\.Abstractions') > [ICatCommandProcessor](ICatCommandProcessor.md 'Cat\.Commands\.Abstractions\.ICatCommandProcessor')

## ICatCommandProcessor\.ProcessAsync\(ICatCommand, CancellationToken\) Method

Runs a command\.

```csharp
System.Threading.Tasks.Task<Cat.Responses.Abstractions.ICatResponse> ProcessAsync(Cat.Commands.Abstractions.ICatCommand catCommand, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Cat.Commands.Abstractions.ICatCommandProcessor.ProcessAsync(Cat.Commands.Abstractions.ICatCommand,System.Threading.CancellationToken).catCommand'></a>

`catCommand` [ICatCommand](ICatCommand.md 'Cat\.Commands\.Abstractions\.ICatCommand')

The command to run\.

<a name='Cat.Commands.Abstractions.ICatCommandProcessor.ProcessAsync(Cat.Commands.Abstractions.ICatCommand,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Token to cancel the work\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[ICatResponse](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The response of the handler\.