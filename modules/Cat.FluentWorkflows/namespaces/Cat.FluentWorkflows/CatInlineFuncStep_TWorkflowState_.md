<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows\.Steps](Cat.FluentWorkflows.Steps.md 'Cat\.FluentWorkflows\.Steps')

## CatInlineFuncStep\<TWorkflowState\> Class

Built\-in step behind `Run(Func)`\. It runs your code\. A succeeded response carries the result to use\.
A failed response ends the workflow with BreakCascade and passes the errors on\.

```csharp
public class CatInlineFuncStep<TWorkflowState> : Cat.FluentWorkflows.CatStepBody<TWorkflowState>
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>
```
#### Type parameters

<a name='Cat.FluentWorkflows.Steps.CatInlineFuncStep_TWorkflowState_.TWorkflowState'></a>

`TWorkflowState`

The state of the workflow\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [CatStepBodyAsync](CatStepBodyAsync.md 'Cat\.FluentWorkflows\.CatStepBodyAsync') &#129106; [Cat\.FluentWorkflows\.CatStepBodyAsync&lt;](CatStepBodyAsync_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\<TWorkflowState\>')[TWorkflowState](CatInlineFuncStep_TWorkflowState_.md#Cat.FluentWorkflows.Steps.CatInlineFuncStep_TWorkflowState_.TWorkflowState 'Cat\.FluentWorkflows\.Steps\.CatInlineFuncStep\<TWorkflowState\>\.TWorkflowState')[&gt;](CatStepBodyAsync_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\<TWorkflowState\>') &#129106; [Cat\.FluentWorkflows\.CatStepBody&lt;](CatStepBody_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBody\<TWorkflowState\>')[TWorkflowState](CatInlineFuncStep_TWorkflowState_.md#Cat.FluentWorkflows.Steps.CatInlineFuncStep_TWorkflowState_.TWorkflowState 'Cat\.FluentWorkflows\.Steps\.CatInlineFuncStep\<TWorkflowState\>\.TWorkflowState')[&gt;](CatStepBody_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBody\<TWorkflowState\>') &#129106; CatInlineFuncStep\<TWorkflowState\>

| Constructors | |
| :--- | :--- |
| [CatInlineFuncStep\(ILogger&lt;CatInlineFuncStep&lt;TWorkflowState&gt;&gt;\)](CatInlineFuncStep_TWorkflowState_..ctor.FFZL14ML3CBV825M9V3FZX3U9.md 'Cat\.FluentWorkflows\.Steps\.CatInlineFuncStep\<TWorkflowState\>\.CatInlineFuncStep\(Microsoft\.Extensions\.Logging\.ILogger\<Cat\.FluentWorkflows\.Steps\.CatInlineFuncStep\<TWorkflowState\>\>\)') | Creates the step\. |

| Properties | |
| :--- | :--- |
| [Body](CatInlineFuncStep_TWorkflowState_.Body.md 'Cat\.FluentWorkflows\.Steps\.CatInlineFuncStep\<TWorkflowState\>\.Body') | Your code\. It gets the logger and the workflow state\. |

| Methods | |
| :--- | :--- |
| [Run\(\)](CatInlineFuncStep_TWorkflowState_.Run().md 'Cat\.FluentWorkflows\.Steps\.CatInlineFuncStep\<TWorkflowState\>\.Run\(\)') | Does the work of the step\. |
