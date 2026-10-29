<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows\.Commands](index.md 'index') > [Cat\.FluentWorkflows\.Commands\.Steps](Cat.FluentWorkflows.Commands.Steps.md 'Cat\.FluentWorkflows\.Commands\.Steps')

## CatProcessCommandStep\<TCommand\> Class

Built\-in step behind `ProcessCommand`\. It processes a command with the command processor\.
A succeeded command continues the workflow\. A failed command ends it with BreakCascade and the errors\.

```csharp
public class CatProcessCommandStep<TCommand> : Cat.FluentWorkflows.CatStepBodyAsync
    where TCommand : class, Cat.Commands.Abstractions.ICatCommand
```
#### Type parameters

<a name='Cat.FluentWorkflows.Commands.Steps.CatProcessCommandStep_TCommand_.TCommand'></a>

`TCommand`

The command to process\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [CatStepBodyAsync](../Cat.FluentWorkflows/CatStepBodyAsync.md 'Cat\.FluentWorkflows\.CatStepBodyAsync') &#129106; CatProcessCommandStep\<TCommand\>

| Constructors | |
| :--- | :--- |
| [CatProcessCommandStep\(ICatCommandProcessor, ILogger&lt;CatProcessCommandStep&lt;TCommand&gt;&gt;\)](CatProcessCommandStep_TCommand_..ctor.6Q3ONWDV49CNNOFIGX4QLYCQ1.md 'Cat\.FluentWorkflows\.Commands\.Steps\.CatProcessCommandStep\<TCommand\>\.CatProcessCommandStep\(Cat\.Commands\.Abstractions\.ICatCommandProcessor, Microsoft\.Extensions\.Logging\.ILogger\<Cat\.FluentWorkflows\.Commands\.Steps\.CatProcessCommandStep\<TCommand\>\>\)') | Creates the step and the command, using the parameterless constructor of the command\. |

| Fields | |
| :--- | :--- |
| [\_commandProcessor](CatProcessCommandStep_TCommand_._commandProcessor.md 'Cat\.FluentWorkflows\.Commands\.Steps\.CatProcessCommandStep\<TCommand\>\.\_commandProcessor') | |

| Properties | |
| :--- | :--- |
| [Command](CatProcessCommandStep_TCommand_.Command.md 'Cat\.FluentWorkflows\.Commands\.Steps\.CatProcessCommandStep\<TCommand\>\.Command') | The command to process\. Fill its members with `Input`\. |
| [Response](CatProcessCommandStep_TCommand_.Response.md 'Cat\.FluentWorkflows\.Commands\.Steps\.CatProcessCommandStep\<TCommand\>\.Response') | The response of the command\. Read it with `Output` after the step ran\. |

| Methods | |
| :--- | :--- |
| [RunAsync\(CancellationToken\)](CatProcessCommandStep_TCommand_.RunAsync.S01NTQHBKUJ7O8U3USSOSA8K.md 'Cat\.FluentWorkflows\.Commands\.Steps\.CatProcessCommandStep\<TCommand\>\.RunAsync\(System\.Threading\.CancellationToken\)') | Runs the step\. |
