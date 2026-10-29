<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows\.Steps](Cat.FluentWorkflows.Steps.md 'Cat\.FluentWorkflows\.Steps')

## CatInlineActionStep\<TWorkflowState\> Class

Built\-in step behind `Run(Action)`\. It runs your code and always continues\.

```csharp
public class CatInlineActionStep<TWorkflowState> : Cat.FluentWorkflows.CatStepBody<TWorkflowState>
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>
```
#### Type parameters

<a name='Cat.FluentWorkflows.Steps.CatInlineActionStep_TWorkflowState_.TWorkflowState'></a>

`TWorkflowState`

The state of the workflow\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [CatStepBodyAsync](CatStepBodyAsync.md 'Cat\.FluentWorkflows\.CatStepBodyAsync') &#129106; [Cat\.FluentWorkflows\.CatStepBodyAsync&lt;](CatStepBodyAsync_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\<TWorkflowState\>')[TWorkflowState](CatInlineActionStep_TWorkflowState_.md#Cat.FluentWorkflows.Steps.CatInlineActionStep_TWorkflowState_.TWorkflowState 'Cat\.FluentWorkflows\.Steps\.CatInlineActionStep\<TWorkflowState\>\.TWorkflowState')[&gt;](CatStepBodyAsync_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\<TWorkflowState\>') &#129106; [Cat\.FluentWorkflows\.CatStepBody&lt;](CatStepBody_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBody\<TWorkflowState\>')[TWorkflowState](CatInlineActionStep_TWorkflowState_.md#Cat.FluentWorkflows.Steps.CatInlineActionStep_TWorkflowState_.TWorkflowState 'Cat\.FluentWorkflows\.Steps\.CatInlineActionStep\<TWorkflowState\>\.TWorkflowState')[&gt;](CatStepBody_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBody\<TWorkflowState\>') &#129106; CatInlineActionStep\<TWorkflowState\>

| Constructors | |
| :--- | :--- |
| [CatInlineActionStep\(ILogger&lt;CatInlineActionStep&lt;TWorkflowState&gt;&gt;\)](CatInlineActionStep_TWorkflowState_..ctor.DJYB9QBQGVX97N10M1SB0QYT3.md 'Cat\.FluentWorkflows\.Steps\.CatInlineActionStep\<TWorkflowState\>\.CatInlineActionStep\(Microsoft\.Extensions\.Logging\.ILogger\<Cat\.FluentWorkflows\.Steps\.CatInlineActionStep\<TWorkflowState\>\>\)') | Creates the step\. |

| Properties | |
| :--- | :--- |
| [Body](CatInlineActionStep_TWorkflowState_.Body.md 'Cat\.FluentWorkflows\.Steps\.CatInlineActionStep\<TWorkflowState\>\.Body') | Your code\. It gets the logger and the workflow state\. |

| Methods | |
| :--- | :--- |
| [Run\(\)](CatInlineActionStep_TWorkflowState_.Run().md 'Cat\.FluentWorkflows\.Steps\.CatInlineActionStep\<TWorkflowState\>\.Run\(\)') | Does the work of the step\. |
