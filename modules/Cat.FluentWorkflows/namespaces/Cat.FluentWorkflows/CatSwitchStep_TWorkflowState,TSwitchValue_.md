<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows\.Steps](Cat.FluentWorkflows.Steps.md 'Cat\.FluentWorkflows\.Steps')

## CatSwitchStep\<TWorkflowState,TSwitchValue\> Class

Built\-in step behind `Switch`\. It runs the steps of the case that matches the value\.
With no match it runs the default case\. With no default case either it does nothing and continues\.

```csharp
public class CatSwitchStep<TWorkflowState,TSwitchValue> : Cat.FluentWorkflows.CatStepBodyAsync<TWorkflowState>
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>
    where TSwitchValue : struct, System.ValueType, System.ValueType
```
#### Type parameters

<a name='Cat.FluentWorkflows.Steps.CatSwitchStep_TWorkflowState,TSwitchValue_.TWorkflowState'></a>

`TWorkflowState`

The state of the workflow\.

<a name='Cat.FluentWorkflows.Steps.CatSwitchStep_TWorkflowState,TSwitchValue_.TSwitchValue'></a>

`TSwitchValue`

The type of the value being switched on\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [CatStepBodyAsync](CatStepBodyAsync.md 'Cat\.FluentWorkflows\.CatStepBodyAsync') &#129106; [Cat\.FluentWorkflows\.CatStepBodyAsync&lt;](CatStepBodyAsync_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\<TWorkflowState\>')[TWorkflowState](CatSwitchStep_TWorkflowState,TSwitchValue_.md#Cat.FluentWorkflows.Steps.CatSwitchStep_TWorkflowState,TSwitchValue_.TWorkflowState 'Cat\.FluentWorkflows\.Steps\.CatSwitchStep\<TWorkflowState,TSwitchValue\>\.TWorkflowState')[&gt;](CatStepBodyAsync_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\<TWorkflowState\>') &#129106; CatSwitchStep\<TWorkflowState,TSwitchValue\>

| Constructors | |
| :--- | :--- |
| [CatSwitchStep\(ICatStepProcessor, ILogger&lt;CatSwitchStep&lt;TWorkflowState,TSwitchValue&gt;&gt;\)](CatSwitchStep_TWorkflowState,TSwitchValue_..ctor.SMZ0JF9A8P0QF4MIXG8OV9SQ9.md 'Cat\.FluentWorkflows\.Steps\.CatSwitchStep\<TWorkflowState,TSwitchValue\>\.CatSwitchStep\(Cat\.FluentWorkflows\.Abstractions\.ICatStepProcessor, Microsoft\.Extensions\.Logging\.ILogger\<Cat\.FluentWorkflows\.Steps\.CatSwitchStep\<TWorkflowState,TSwitchValue\>\>\)') | Creates the step\. |

| Fields | |
| :--- | :--- |
| [\_catStepProcessor](CatSwitchStep_TWorkflowState,TSwitchValue_._catStepProcessor.md 'Cat\.FluentWorkflows\.Steps\.CatSwitchStep\<TWorkflowState,TSwitchValue\>\.\_catStepProcessor') | |

| Properties | |
| :--- | :--- |
| [CaseBuilders](CatSwitchStep_TWorkflowState,TSwitchValue_.CaseBuilders.md 'Cat\.FluentWorkflows\.Steps\.CatSwitchStep\<TWorkflowState,TSwitchValue\>\.CaseBuilders') | Holds the steps of each case, by the value it matches\. |
| [DefaultCaseBuilder](CatSwitchStep_TWorkflowState,TSwitchValue_.DefaultCaseBuilder.md 'Cat\.FluentWorkflows\.Steps\.CatSwitchStep\<TWorkflowState,TSwitchValue\>\.DefaultCaseBuilder') | Holds the steps to run when no case matches, or `null` for none\. |
| [SwitchValue](CatSwitchStep_TWorkflowState,TSwitchValue_.SwitchValue.md 'Cat\.FluentWorkflows\.Steps\.CatSwitchStep\<TWorkflowState,TSwitchValue\>\.SwitchValue') | Gets the value to switch on from the workflow state\. |

| Methods | |
| :--- | :--- |
| [RunAsync\(CancellationToken\)](CatSwitchStep_TWorkflowState,TSwitchValue_.RunAsync.S5ZJP9XH140S6JCW0LWZMGC8A.md 'Cat\.FluentWorkflows\.Steps\.CatSwitchStep\<TWorkflowState,TSwitchValue\>\.RunAsync\(System\.Threading\.CancellationToken\)') | Runs the step\. |
