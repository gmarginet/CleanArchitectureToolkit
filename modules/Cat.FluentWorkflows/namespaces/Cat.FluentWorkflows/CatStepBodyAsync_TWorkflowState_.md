<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows](Cat.FluentWorkflows.md 'Cat\.FluentWorkflows')

## CatStepBodyAsync\<TWorkflowState\> Class

Base class for a step that works asynchronously and reads or writes the workflow state directly\.
Implement [RunAsync\(CancellationToken\)](CatStepBodyAsync.RunAsync.NDIRNNFATTDGG9GCGGAU4GQP1.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\.RunAsync\(System\.Threading\.CancellationToken\)') and use [WorkflowState](CatStepBodyAsync_TWorkflowState_.WorkflowState.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\<TWorkflowState\>\.WorkflowState')\.

```csharp
public abstract class CatStepBodyAsync<TWorkflowState> : Cat.FluentWorkflows.CatStepBodyAsync, Cat.FluentWorkflows.Abstractions.ICatStepBodyWithState<TWorkflowState>
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>
```
#### Type parameters

<a name='Cat.FluentWorkflows.CatStepBodyAsync_TWorkflowState_.TWorkflowState'></a>

`TWorkflowState`

The state of the workflow\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [CatStepBodyAsync](CatStepBodyAsync.md 'Cat\.FluentWorkflows\.CatStepBodyAsync') &#129106; CatStepBodyAsync\<TWorkflowState\>

Derived  
&#8627; [CatStepBody&lt;TWorkflowState&gt;](CatStepBody_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBody\<TWorkflowState\>')  
&#8627; [CatForeachStep&lt;TWorkflowState,TCollection,TForeachState&gt;](CatForeachStep_TWorkflowState,TCollection,TForeachState_.md 'Cat\.FluentWorkflows\.Steps\.CatForeachStep\<TWorkflowState,TCollection,TForeachState\>')  
&#8627; [CatIfStep&lt;TWorkflowState&gt;](CatIfStep_TWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatIfStep\<TWorkflowState\>')  
&#8627; [CatRunSubWorkflowStep&lt;TWorkflowState,TSubWorkflow,TSubWorkflowState&gt;](CatRunSubWorkflowStep_TWorkflowState,TSubWorkflow,TSubWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatRunSubWorkflowStep\<TWorkflowState,TSubWorkflow,TSubWorkflowState\>')  
&#8627; [CatSwitchStep&lt;TWorkflowState,TSwitchValue&gt;](CatSwitchStep_TWorkflowState,TSwitchValue_.md 'Cat\.FluentWorkflows\.Steps\.CatSwitchStep\<TWorkflowState,TSwitchValue\>')  
&#8627; [CatWhileStep&lt;TWorkflowState&gt;](CatWhileStep_TWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatWhileStep\<TWorkflowState\>')

Implements [Cat\.FluentWorkflows\.Abstractions\.ICatStepBodyWithState&lt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatStepBodyWithState_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBodyWithState\`1')[TWorkflowState](CatStepBodyAsync_TWorkflowState_.md#Cat.FluentWorkflows.CatStepBodyAsync_TWorkflowState_.TWorkflowState 'Cat\.FluentWorkflows\.CatStepBodyAsync\<TWorkflowState\>\.TWorkflowState')[&gt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatStepBodyWithState_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBodyWithState\`1')

| Constructors | |
| :--- | :--- |
| [CatStepBodyAsync\(ILogger\)](CatStepBodyAsync_TWorkflowState_..ctor.A6YX3OOBOLP1TIEMDUHCNWQCD.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\<TWorkflowState\>\.CatStepBodyAsync\(Microsoft\.Extensions\.Logging\.ILogger\)') | Creates the step\. |

| Properties | |
| :--- | :--- |
| [WorkflowState](CatStepBodyAsync_TWorkflowState_.WorkflowState.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\<TWorkflowState\>\.WorkflowState') | The state of the workflow the step runs in\. |
