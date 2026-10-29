<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows\.Steps](Cat.FluentWorkflows.Steps.md 'Cat\.FluentWorkflows\.Steps')

## CatLogStep\<TWorkflowState\> Class

Built\-in step behind `Log` and the level specific log methods\. It writes one log entry and continues\.

```csharp
public class CatLogStep<TWorkflowState> : Cat.FluentWorkflows.CatStepBody<TWorkflowState>
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>
```
#### Type parameters

<a name='Cat.FluentWorkflows.Steps.CatLogStep_TWorkflowState_.TWorkflowState'></a>

`TWorkflowState`

The state of the workflow\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [CatStepBodyAsync](CatStepBodyAsync.md 'Cat\.FluentWorkflows\.CatStepBodyAsync') &#129106; [Cat\.FluentWorkflows\.CatStepBodyAsync&lt;](CatStepBodyAsync_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\<TWorkflowState\>')[TWorkflowState](CatLogStep_TWorkflowState_.md#Cat.FluentWorkflows.Steps.CatLogStep_TWorkflowState_.TWorkflowState 'Cat\.FluentWorkflows\.Steps\.CatLogStep\<TWorkflowState\>\.TWorkflowState')[&gt;](CatStepBodyAsync_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\<TWorkflowState\>') &#129106; [Cat\.FluentWorkflows\.CatStepBody&lt;](CatStepBody_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBody\<TWorkflowState\>')[TWorkflowState](CatLogStep_TWorkflowState_.md#Cat.FluentWorkflows.Steps.CatLogStep_TWorkflowState_.TWorkflowState 'Cat\.FluentWorkflows\.Steps\.CatLogStep\<TWorkflowState\>\.TWorkflowState')[&gt;](CatStepBody_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBody\<TWorkflowState\>') &#129106; CatLogStep\<TWorkflowState\>

| Constructors | |
| :--- | :--- |
| [CatLogStep\(ILogger&lt;CatLogStep&lt;TWorkflowState&gt;&gt;\)](CatLogStep_TWorkflowState_..ctor.DZ07RN8R4J1FUKMF978V35CVA.md 'Cat\.FluentWorkflows\.Steps\.CatLogStep\<TWorkflowState\>\.CatLogStep\(Microsoft\.Extensions\.Logging\.ILogger\<Cat\.FluentWorkflows\.Steps\.CatLogStep\<TWorkflowState\>\>\)') | Creates the step\. |

| Properties | |
| :--- | :--- |
| [GetArgs](CatLogStep_TWorkflowState_.GetArgs.md 'Cat\.FluentWorkflows\.Steps\.CatLogStep\<TWorkflowState\>\.GetArgs') | Gets the values for the placeholders from the workflow state\. |
| [LogLevel](CatLogStep_TWorkflowState_.LogLevel.md 'Cat\.FluentWorkflows\.Steps\.CatLogStep\<TWorkflowState\>\.LogLevel') | The level to log at\. |
| [Message](CatLogStep_TWorkflowState_.Message.md 'Cat\.FluentWorkflows\.Steps\.CatLogStep\<TWorkflowState\>\.Message') | The message template\. |

| Methods | |
| :--- | :--- |
| [Run\(\)](CatLogStep_TWorkflowState_.Run().md 'Cat\.FluentWorkflows\.Steps\.CatLogStep\<TWorkflowState\>\.Run\(\)') | Does the work of the step\. |
