<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows\.Abstractions](index.md 'index') > [Cat\.FluentWorkflows\.Abstractions](Cat.FluentWorkflows.Abstractions.md 'Cat\.FluentWorkflows\.Abstractions')

## ICatStepProcessor Interface

Runs a list of steps one by one\. Steps like if and foreach use it to run their own inner steps\.

```csharp
public interface ICatStepProcessor
```

| Methods | |
| :--- | :--- |
| [RunStepsAsync&lt;TWorkflowState&gt;\(ICatWorkflowBuilder&lt;TWorkflowState&gt;, TWorkflowState, CancellationToken\)](ICatStepProcessor.RunStepsAsync.5L6M6S533ILIRH2SAWC31DG37.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepProcessor\.RunStepsAsync\<TWorkflowState\>\(Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, TWorkflowState, System\.Threading\.CancellationToken\)') | Runs the steps of a builder in order\. It stops after a step that returns a break result\. |
