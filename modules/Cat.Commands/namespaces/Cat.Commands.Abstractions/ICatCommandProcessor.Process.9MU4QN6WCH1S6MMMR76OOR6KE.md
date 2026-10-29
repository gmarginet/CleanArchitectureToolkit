<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Commands\.Abstractions](index.md 'index') > [Cat\.Commands\.Abstractions](Cat.Commands.Abstractions.md 'Cat\.Commands\.Abstractions') > [ICatCommandProcessor](ICatCommandProcessor.md 'Cat\.Commands\.Abstractions\.ICatCommandProcessor')

## ICatCommandProcessor\.Process\(ICatCommand\) Method

Runs a command and blocks until it finishes\.
Prefer [ProcessAsync\(ICatCommand, CancellationToken\)](ICatCommandProcessor.ProcessAsync.VVA0QGJV7BSKJ1729JAXLLQT8.md 'Cat\.Commands\.Abstractions\.ICatCommandProcessor\.ProcessAsync\(Cat\.Commands\.Abstractions\.ICatCommand, System\.Threading\.CancellationToken\)') when you can\.

```csharp
Cat.Responses.Abstractions.ICatResponse Process(Cat.Commands.Abstractions.ICatCommand catCommand);
```
#### Parameters

<a name='Cat.Commands.Abstractions.ICatCommandProcessor.Process(Cat.Commands.Abstractions.ICatCommand).catCommand'></a>

`catCommand` [ICatCommand](ICatCommand.md 'Cat\.Commands\.Abstractions\.ICatCommand')

The command to run\.

#### Returns
[ICatResponse](../Cat.Responses.Abstractions/ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse')  
The response of the handler\.