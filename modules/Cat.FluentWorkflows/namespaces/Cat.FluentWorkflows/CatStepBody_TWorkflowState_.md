<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows](Cat.FluentWorkflows.md 'Cat\.FluentWorkflows')

## CatStepBody\<TWorkflowState\> Class

Base class for a step that works synchronously and reads or writes the workflow state directly\.
Implement [Run\(\)](CatStepBody_TWorkflowState_.Run().md 'Cat\.FluentWorkflows\.CatStepBody\<TWorkflowState\>\.Run\(\)') and use [WorkflowState](CatStepBodyAsync_TWorkflowState_.WorkflowState.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\<TWorkflowState\>\.WorkflowState')\.

```csharp
public abstract class CatStepBody<TWorkflowState> : Cat.FluentWorkflows.CatStepBodyAsync<TWorkflowState>
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>
```
#### Type parameters

<a name='Cat.FluentWorkflows.CatStepBody_TWorkflowState_.TWorkflowState'></a>

`TWorkflowState`

The state of the workflow\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [CatStepBodyAsync](CatStepBodyAsync.md 'Cat\.FluentWorkflows\.CatStepBodyAsync') → [Cat\.FluentWorkflows\.CatStepBodyAsync&lt;](CatStepBodyAsync_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\<TWorkflowState\>')[TWorkflowState](CatStepBody_TWorkflowState_.md#Cat.FluentWorkflows.CatStepBody_TWorkflowState_.TWorkflowState 'Cat\.FluentWorkflows\.CatStepBody\<TWorkflowState\>\.TWorkflowState')[&gt;](CatStepBodyAsync_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\<TWorkflowState\>') → CatStepBody\<TWorkflowState\>

Derived  
↳ [CatBreakIfStep&lt;TWorkflowState&gt;](CatBreakIfStep_TWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatBreakIfStep\<TWorkflowState\>')  
↳ [CatInlineActionStep&lt;TWorkflowState&gt;](CatInlineActionStep_TWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatInlineActionStep\<TWorkflowState\>')  
↳ [CatInlineFuncStep&lt;TWorkflowState&gt;](CatInlineFuncStep_TWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatInlineFuncStep\<TWorkflowState\>')  
↳ [CatLogStep&lt;TWorkflowState&gt;](CatLogStep_TWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatLogStep\<TWorkflowState\>')  
↳ [CatSetStatePropertyStep&lt;TWorkflowState,TProperty&gt;](CatSetStatePropertyStep_TWorkflowState,TProperty_.md 'Cat\.FluentWorkflows\.Steps\.CatSetStatePropertyStep\<TWorkflowState,TProperty\>')

| Constructors | |
| :--- | :--- |
| [CatStepBody\(ILogger&lt;CatStepBody&lt;TWorkflowState&gt;&gt;\)](CatStepBody_TWorkflowState_..ctor.KS4E5UVG79L14FGK9E1H2P6D4.md 'Cat\.FluentWorkflows\.CatStepBody\<TWorkflowState\>\.CatStepBody\(Microsoft\.Extensions\.Logging\.ILogger\<Cat\.FluentWorkflows\.CatStepBody\<TWorkflowState\>\>\)') | Creates the step\. |

| Methods | |
| :--- | :--- |
| [Run\(\)](CatStepBody_TWorkflowState_.Run().md 'Cat\.FluentWorkflows\.CatStepBody\<TWorkflowState\>\.Run\(\)') | Does the work of the step\. |
| [RunAsync\(CancellationToken\)](CatStepBody_TWorkflowState_.RunAsync.X3HHHAR6W9Y316VF0SSPL7NE2.md 'Cat\.FluentWorkflows\.CatStepBody\<TWorkflowState\>\.RunAsync\(System\.Threading\.CancellationToken\)') | Runs the step\. |
