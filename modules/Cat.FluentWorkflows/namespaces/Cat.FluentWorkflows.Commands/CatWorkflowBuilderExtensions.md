<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.FluentWorkflows\.Commands](index.md 'index') > [Cat\.FluentWorkflows\.Commands](Cat.FluentWorkflows.Commands.md 'Cat\.FluentWorkflows\.Commands')

## CatWorkflowBuilderExtensions Class

The command step for the workflow builder\.

```csharp
public static class CatWorkflowBuilderExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; CatWorkflowBuilderExtensions

| Methods | |
| :--- | :--- |
| [ProcessCommand&lt;TWorkflowState,TCommand&gt;\(this ICatWorkflowBuilder&lt;TWorkflowState&gt;\)](CatWorkflowBuilderExtensions.ProcessCommand.YVCWTB1LSV2HRZEERHRLDI6OD.md 'Cat\.FluentWorkflows\.Commands\.CatWorkflowBuilderExtensions\.ProcessCommand\<TWorkflowState,TCommand\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>\)') | Adds a step that processes a command\. The command is created with its parameterless constructor\. Fill it with `Input`, like `.Input(s => s.Name, step => step.Command.Name)`\. A failed command ends the workflow with BreakCascade and the errors of the command\. |
