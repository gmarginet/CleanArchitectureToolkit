<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Commands](index.md 'index') > [Cat\.Commands](Cat.Commands.md 'Cat\.Commands') > [CatCommandProcessor](CatCommandProcessor.md 'Cat\.Commands\.CatCommandProcessor')

## Cat\.Commands\.Abstractions\.ICatCommandProcessor\.Process\(ICatCommand\) Method

Runs a command and blocks until it finishes\.
Prefer [ProcessAsync\(ICatCommand, CancellationToken\)](../Cat.Commands.Abstractions/ICatCommandProcessor.ProcessAsync.VVA0QGJV7BSKJ1729JAXLLQT8.md 'Cat\.Commands\.Abstractions\.ICatCommandProcessor\.ProcessAsync\(Cat\.Commands\.Abstractions\.ICatCommand,System\.Threading\.CancellationToken\)') when you can\.

```csharp
Cat.Responses.Abstractions.ICatResponse Cat.Commands.Abstractions.ICatCommandProcessor.Process(Cat.Commands.Abstractions.ICatCommand catCommand);
```
#### Parameters

<a name='Cat.Commands.CatCommandProcessor.Cat.Commands.Abstractions.ICatCommandProcessor.Process(Cat.Commands.Abstractions.ICatCommand).catCommand'></a>

`catCommand` [ICatCommand](../Cat.Commands.Abstractions/ICatCommand.md 'Cat\.Commands\.Abstractions\.ICatCommand')

The command to run\.

Implements [Process\(ICatCommand\)](../Cat.Commands.Abstractions/ICatCommandProcessor.Process.9MU4QN6WCH1S6MMMR76OOR6KE.md 'Cat\.Commands\.Abstractions\.ICatCommandProcessor\.Process\(Cat\.Commands\.Abstractions\.ICatCommand\)')