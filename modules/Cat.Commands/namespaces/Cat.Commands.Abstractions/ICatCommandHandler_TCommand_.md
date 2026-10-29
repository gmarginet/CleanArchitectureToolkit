<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Commands\.Abstractions](index.md 'index') > [Cat\.Commands\.Abstractions](Cat.Commands.Abstractions.md 'Cat\.Commands\.Abstractions')

## ICatCommandHandler\<TCommand\> Interface

Handles one kind of command\.
Implement it once per command type\. The module finds and registers it for you\.

```csharp
public interface ICatCommandHandler<in TCommand>
    where TCommand : class, Cat.Commands.Abstractions.ICatCommand
```
#### Type parameters

<a name='Cat.Commands.Abstractions.ICatCommandHandler_TCommand_.TCommand'></a>

`TCommand`

The command this handler can run\.

| Methods | |
| :--- | :--- |
| [HandleAsync\(TCommand, CancellationToken\)](ICatCommandHandler_TCommand_.HandleAsync.DOGO4I1C9KLZNF43493MH80JB.md 'Cat\.Commands\.Abstractions\.ICatCommandHandler\<TCommand\>\.HandleAsync\(TCommand, System\.Threading\.CancellationToken\)') | Runs the command\. |
