<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows\.Abstractions](index.md 'index') > [Cat\.FluentWorkflows\.Abstractions](Cat.FluentWorkflows.Abstractions.md 'Cat\.FluentWorkflows\.Abstractions')

## ICatWorkflow\<TWorkflowState\> Interface

Describes one workflow: the steps to run, in order\. Implement it once per workflow\. The module finds and registers it for you\.

```csharp
public interface ICatWorkflow<TWorkflowState>
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>
```
#### Type parameters

<a name='Cat.FluentWorkflows.Abstractions.ICatWorkflow_TWorkflowState_.TWorkflowState'></a>

`TWorkflowState`

The state of the workflow\.

| Methods | |
| :--- | :--- |
| [Build\(ICatWorkflowBuilder&lt;TWorkflowState&gt;\)](ICatWorkflow_TWorkflowState_.Build.7RYNT7LWF2VVKIZWAO62GD9R6.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflow\<TWorkflowState\>\.Build\(Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>\)') | Adds the steps of the workflow\. |
