<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows\.Abstractions](index.md 'index') > [Cat\.FluentWorkflows\.Abstractions](Cat.FluentWorkflows.Abstractions.md 'Cat\.FluentWorkflows\.Abstractions')

## ICatWorkflowBuilder\<TWorkflowState\> Interface

Collects the steps of a workflow\. You get one in [Build\(ICatWorkflowBuilder&lt;TWorkflowState&gt;\)](ICatWorkflow_TWorkflowState_.Build.7RYNT7LWF2VVKIZWAO62GD9R6.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflow\<TWorkflowState\>\.Build\(Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>\)')\.
The steps themselves are extension methods in `Cat.FluentWorkflows.Extensions`\.
Each one adds a step to [WorkflowSteps](ICatWorkflowBuilder_TWorkflowState_.WorkflowSteps.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>\.WorkflowSteps'), and the steps run in the order they were added\.

```csharp
public interface ICatWorkflowBuilder<TWorkflowState>
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>
```
#### Type parameters

<a name='Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_.TWorkflowState'></a>

`TWorkflowState`

The state of the workflow\.

| Properties | |
| :--- | :--- |
| [WorkflowSteps](ICatWorkflowBuilder_TWorkflowState_.WorkflowSteps.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>\.WorkflowSteps') | The steps added so far\. |
