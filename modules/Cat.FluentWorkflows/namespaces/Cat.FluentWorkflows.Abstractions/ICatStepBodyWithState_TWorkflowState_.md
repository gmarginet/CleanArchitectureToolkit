<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.FluentWorkflows\.Abstractions](index.md 'index') > [Cat\.FluentWorkflows\.Abstractions](Cat.FluentWorkflows.Abstractions.md 'Cat\.FluentWorkflows\.Abstractions')

## ICatStepBodyWithState\<TWorkflowState\> Interface

Marks a step body that wants the state of the workflow\. The step processor sets it before the step runs\.

```csharp
public interface ICatStepBodyWithState<TWorkflowState>
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>
```
#### Type parameters

<a name='Cat.FluentWorkflows.Abstractions.ICatStepBodyWithState_TWorkflowState_.TWorkflowState'></a>

`TWorkflowState`

The state of the workflow\.

| Properties | |
| :--- | :--- |
| [WorkflowState](ICatStepBodyWithState_TWorkflowState_.WorkflowState.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBodyWithState\<TWorkflowState\>\.WorkflowState') | The state of the workflow the step runs in\. |
