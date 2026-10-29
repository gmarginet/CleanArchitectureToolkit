<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows\.Abstractions](index.md 'index') > [Cat\.FluentWorkflows\.Abstractions](Cat.FluentWorkflows.Abstractions.md 'Cat\.FluentWorkflows\.Abstractions')

## ICatHasSubWorkflowState\<TSubWorkflowState\> Interface

Marks a workflow state that carries the state for a sub\-workflow\.

```csharp
public interface ICatHasSubWorkflowState<TSubWorkflowState>
```
#### Type parameters

<a name='Cat.FluentWorkflows.Abstractions.ICatHasSubWorkflowState_TSubWorkflowState_.TSubWorkflowState'></a>

`TSubWorkflowState`

The state of the sub\-workflow\.

| Properties | |
| :--- | :--- |
| [WorkflowState](ICatHasSubWorkflowState_TSubWorkflowState_.WorkflowState.md 'Cat\.FluentWorkflows\.Abstractions\.ICatHasSubWorkflowState\<TSubWorkflowState\>\.WorkflowState') | The state the sub\-workflow runs on\. |
