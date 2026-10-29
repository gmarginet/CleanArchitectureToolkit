<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.FluentWorkflows\.Abstractions](index.md 'index') > [Cat\.FluentWorkflows\.Abstractions](Cat.FluentWorkflows.Abstractions.md 'Cat\.FluentWorkflows\.Abstractions')

## ICatWorkflowProcessor Interface

Single entry point for running a workflow\.

```csharp
public interface ICatWorkflowProcessor
```

| Methods | |
| :--- | :--- |
| [RunAsync&lt;TWorkflow,TWorkflowState&gt;\(TWorkflowState, CancellationToken\)](ICatWorkflowProcessor.RunAsync.R1HS9NJ8EQXVXKZLXHU6G4NG5.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowProcessor\.RunAsync\<TWorkflow,TWorkflowState\>\(TWorkflowState, System\.Threading\.CancellationToken\)') | Builds the workflow, runs its steps on the given state and returns the outcome\. A [BreakFromCurrentFlowOnly](CatStepExecutionResult.md#Cat.FluentWorkflows.Abstractions.CatStepExecutionResult.BreakFromCurrentFlowOnly 'Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\.BreakFromCurrentFlowOnly') result is reported as [Continue](CatStepExecutionResult.md#Cat.FluentWorkflows.Abstractions.CatStepExecutionResult.Continue 'Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\.Continue')\. |
