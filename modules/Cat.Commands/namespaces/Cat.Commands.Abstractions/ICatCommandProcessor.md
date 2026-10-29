<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Commands\.Abstractions](index.md 'index') > [Cat\.Commands\.Abstractions](Cat.Commands.Abstractions.md 'Cat\.Commands\.Abstractions')

## ICatCommandProcessor Interface

Single entry point for running commands\.
It finds the handler for a command, runs it through the registered decorators and returns the response\.

```csharp
public interface ICatCommandProcessor
```

| Methods | |
| :--- | :--- |
| [Process\(ICatCommand\)](ICatCommandProcessor.Process.9MU4QN6WCH1S6MMMR76OOR6KE.md 'Cat\.Commands\.Abstractions\.ICatCommandProcessor\.Process\(Cat\.Commands\.Abstractions\.ICatCommand\)') | Runs a command and blocks until it finishes\. Prefer [ProcessAsync\(ICatCommand, CancellationToken\)](ICatCommandProcessor.ProcessAsync.VVA0QGJV7BSKJ1729JAXLLQT8.md 'Cat\.Commands\.Abstractions\.ICatCommandProcessor\.ProcessAsync\(Cat\.Commands\.Abstractions\.ICatCommand, System\.Threading\.CancellationToken\)') when you can\. |
| [ProcessAsync\(ICatCommand, CancellationToken\)](ICatCommandProcessor.ProcessAsync.VVA0QGJV7BSKJ1729JAXLLQT8.md 'Cat\.Commands\.Abstractions\.ICatCommandProcessor\.ProcessAsync\(Cat\.Commands\.Abstractions\.ICatCommand, System\.Threading\.CancellationToken\)') | Runs a command\. |
