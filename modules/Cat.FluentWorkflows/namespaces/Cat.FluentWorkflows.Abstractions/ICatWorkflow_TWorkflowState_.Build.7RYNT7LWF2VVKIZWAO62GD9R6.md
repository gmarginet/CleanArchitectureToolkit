<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.FluentWorkflows\.Abstractions](index.md 'index') > [Cat\.FluentWorkflows\.Abstractions](Cat.FluentWorkflows.Abstractions.md 'Cat\.FluentWorkflows\.Abstractions') > [ICatWorkflow&lt;TWorkflowState&gt;](ICatWorkflow_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflow\<TWorkflowState\>')

## ICatWorkflow\<TWorkflowState\>\.Build\(ICatWorkflowBuilder\<TWorkflowState\>\) Method

Adds the steps of the workflow\.

```csharp
void Build(Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder<TWorkflowState> builder);
```
#### Parameters

<a name='Cat.FluentWorkflows.Abstractions.ICatWorkflow_TWorkflowState_.Build(Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_).builder'></a>

`builder` [Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder&lt;](ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>')[TWorkflowState](ICatWorkflow_TWorkflowState_.md#Cat.FluentWorkflows.Abstractions.ICatWorkflow_TWorkflowState_.TWorkflowState 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflow\<TWorkflowState\>\.TWorkflowState')[&gt;](ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>')

Collects the steps\.