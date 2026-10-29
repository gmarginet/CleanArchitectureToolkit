<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows](Cat.FluentWorkflows.md 'Cat\.FluentWorkflows')

## CatWorkflowBuilder\<TWorkflowState\> Class

Default [ICatWorkflowBuilder&lt;TWorkflowState&gt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')\.
It only holds the steps\. The extension methods in `Cat.FluentWorkflows.Extensions` add them\.

```csharp
public class CatWorkflowBuilder<TWorkflowState> : Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder<TWorkflowState>
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>
```
#### Type parameters

<a name='Cat.FluentWorkflows.CatWorkflowBuilder_TWorkflowState_.TWorkflowState'></a>

`TWorkflowState`

The state of the workflow\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; CatWorkflowBuilder\<TWorkflowState\>

Implements [Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder&lt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')[TWorkflowState](CatWorkflowBuilder_TWorkflowState_.md#Cat.FluentWorkflows.CatWorkflowBuilder_TWorkflowState_.TWorkflowState 'Cat\.FluentWorkflows\.CatWorkflowBuilder\<TWorkflowState\>\.TWorkflowState')[&gt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')

| Properties | |
| :--- | :--- |
| [WorkflowSteps](CatWorkflowBuilder_TWorkflowState_.WorkflowSteps.md 'Cat\.FluentWorkflows\.CatWorkflowBuilder\<TWorkflowState\>\.WorkflowSteps') | The steps added so far\. |
