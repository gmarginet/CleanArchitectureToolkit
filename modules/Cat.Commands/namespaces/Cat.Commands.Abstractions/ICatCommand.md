<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Commands\.Abstractions](index.md 'index') > [Cat\.Commands\.Abstractions](Cat.Commands.Abstractions.md 'Cat\.Commands\.Abstractions')

## ICatCommand Interface

Marks a command that changes state and returns a response without a payload\.
Handle it with [ICatCommandHandler&lt;TCommand&gt;](ICatCommandHandler_TCommand_.md 'Cat\.Commands\.Abstractions\.ICatCommandHandler\<TCommand\>')\.

```csharp
public interface ICatCommand
```