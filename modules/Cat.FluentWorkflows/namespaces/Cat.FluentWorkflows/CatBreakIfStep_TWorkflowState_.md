<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows\.Steps](Cat.FluentWorkflows.Steps.md 'Cat\.FluentWorkflows\.Steps')

## CatBreakIfStep\<TWorkflowState\> Class

Built\-in step behind `BreakCascadeIf`, `BreakFromCurrentFlowOnlyIf` and `BreakFromLoopIf`\.
It runs the check\. When the check returns `true` it breaks the way [BreakType](CatBreakIfStep_TWorkflowState_.BreakType.md 'Cat\.FluentWorkflows\.Steps\.CatBreakIfStep\<TWorkflowState\>\.BreakType') says, otherwise it continues\.

```csharp
public class CatBreakIfStep<TWorkflowState> : Cat.FluentWorkflows.CatStepBody<TWorkflowState>
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>
```
#### Type parameters

<a name='Cat.FluentWorkflows.Steps.CatBreakIfStep_TWorkflowState_.TWorkflowState'></a>

`TWorkflowState`

The state of the workflow\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [CatStepBodyAsync](CatStepBodyAsync.md 'Cat\.FluentWorkflows\.CatStepBodyAsync') &#129106; [Cat\.FluentWorkflows\.CatStepBodyAsync&lt;](CatStepBodyAsync_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\<TWorkflowState\>')[TWorkflowState](CatBreakIfStep_TWorkflowState_.md#Cat.FluentWorkflows.Steps.CatBreakIfStep_TWorkflowState_.TWorkflowState 'Cat\.FluentWorkflows\.Steps\.CatBreakIfStep\<TWorkflowState\>\.TWorkflowState')[&gt;](CatStepBodyAsync_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\<TWorkflowState\>') &#129106; [Cat\.FluentWorkflows\.CatStepBody&lt;](CatStepBody_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBody\<TWorkflowState\>')[TWorkflowState](CatBreakIfStep_TWorkflowState_.md#Cat.FluentWorkflows.Steps.CatBreakIfStep_TWorkflowState_.TWorkflowState 'Cat\.FluentWorkflows\.Steps\.CatBreakIfStep\<TWorkflowState\>\.TWorkflowState')[&gt;](CatStepBody_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBody\<TWorkflowState\>') &#129106; CatBreakIfStep\<TWorkflowState\>

| Constructors | |
| :--- | :--- |
| [CatBreakIfStep\(ILogger&lt;CatBreakIfStep&lt;TWorkflowState&gt;&gt;\)](CatBreakIfStep_TWorkflowState_..ctor.8JLJHGUAOIRH5VRC895RM6UXE.md 'Cat\.FluentWorkflows\.Steps\.CatBreakIfStep\<TWorkflowState\>\.CatBreakIfStep\(Microsoft\.Extensions\.Logging\.ILogger\<Cat\.FluentWorkflows\.Steps\.CatBreakIfStep\<TWorkflowState\>\>\)') | Creates the step\. |

| Properties | |
| :--- | :--- |
| [BreakType](CatBreakIfStep_TWorkflowState_.BreakType.md 'Cat\.FluentWorkflows\.Steps\.CatBreakIfStep\<TWorkflowState\>\.BreakType') | The kind of break to make when the check returns `true`\. |
| [Check](CatBreakIfStep_TWorkflowState_.Check.md 'Cat\.FluentWorkflows\.Steps\.CatBreakIfStep\<TWorkflowState\>\.Check') | The check\. It gets the logger and the workflow state\. |

| Methods | |
| :--- | :--- |
| [Run\(\)](CatBreakIfStep_TWorkflowState_.Run().md 'Cat\.FluentWorkflows\.Steps\.CatBreakIfStep\<TWorkflowState\>\.Run\(\)') | Does the work of the step\. |
