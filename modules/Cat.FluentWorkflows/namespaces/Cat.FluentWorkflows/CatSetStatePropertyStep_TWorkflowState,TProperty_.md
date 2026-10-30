<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows\.Steps](Cat.FluentWorkflows.Steps.md 'Cat\.FluentWorkflows\.Steps')

## CatSetStatePropertyStep\<TWorkflowState,TProperty\> Class

Built\-in step behind `Set`\. It calculates a value and writes it to a property of the workflow state\.

```csharp
public class CatSetStatePropertyStep<TWorkflowState,TProperty> : Cat.FluentWorkflows.CatStepBody<TWorkflowState>
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>
```
#### Type parameters

<a name='Cat.FluentWorkflows.Steps.CatSetStatePropertyStep_TWorkflowState,TProperty_.TWorkflowState'></a>

`TWorkflowState`

The state of the workflow\.

<a name='Cat.FluentWorkflows.Steps.CatSetStatePropertyStep_TWorkflowState,TProperty_.TProperty'></a>

`TProperty`

The type of the property\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [CatStepBodyAsync](CatStepBodyAsync.md 'Cat\.FluentWorkflows\.CatStepBodyAsync') → [Cat\.FluentWorkflows\.CatStepBodyAsync&lt;](CatStepBodyAsync_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\<TWorkflowState\>')[TWorkflowState](CatSetStatePropertyStep_TWorkflowState,TProperty_.md#Cat.FluentWorkflows.Steps.CatSetStatePropertyStep_TWorkflowState,TProperty_.TWorkflowState 'Cat\.FluentWorkflows\.Steps\.CatSetStatePropertyStep\<TWorkflowState,TProperty\>\.TWorkflowState')[&gt;](CatStepBodyAsync_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\<TWorkflowState\>') → [Cat\.FluentWorkflows\.CatStepBody&lt;](CatStepBody_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBody\<TWorkflowState\>')[TWorkflowState](CatSetStatePropertyStep_TWorkflowState,TProperty_.md#Cat.FluentWorkflows.Steps.CatSetStatePropertyStep_TWorkflowState,TProperty_.TWorkflowState 'Cat\.FluentWorkflows\.Steps\.CatSetStatePropertyStep\<TWorkflowState,TProperty\>\.TWorkflowState')[&gt;](CatStepBody_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBody\<TWorkflowState\>') → CatSetStatePropertyStep\<TWorkflowState,TProperty\>

| Constructors | |
| :--- | :--- |
| [CatSetStatePropertyStep\(ILogger&lt;CatSetStatePropertyStep&lt;TWorkflowState,TProperty&gt;&gt;\)](CatSetStatePropertyStep_TWorkflowState,TProperty_..ctor.ATPD02KEMTYYH6QNN4IZNJZP1.md 'Cat\.FluentWorkflows\.Steps\.CatSetStatePropertyStep\<TWorkflowState,TProperty\>\.CatSetStatePropertyStep\(Microsoft\.Extensions\.Logging\.ILogger\<Cat\.FluentWorkflows\.Steps\.CatSetStatePropertyStep\<TWorkflowState,TProperty\>\>\)') | Creates the step\. |

| Properties | |
| :--- | :--- |
| [GetPropertyValue](CatSetStatePropertyStep_TWorkflowState,TProperty_.GetPropertyValue.md 'Cat\.FluentWorkflows\.Steps\.CatSetStatePropertyStep\<TWorkflowState,TProperty\>\.GetPropertyValue') | Calculates the new value from the logger and the workflow state\. |
| [StateProperty](CatSetStatePropertyStep_TWorkflowState,TProperty_.StateProperty.md 'Cat\.FluentWorkflows\.Steps\.CatSetStatePropertyStep\<TWorkflowState,TProperty\>\.StateProperty') | Picks the property to write\. |

| Methods | |
| :--- | :--- |
| [Run\(\)](CatSetStatePropertyStep_TWorkflowState,TProperty_.Run().md 'Cat\.FluentWorkflows\.Steps\.CatSetStatePropertyStep\<TWorkflowState,TProperty\>\.Run\(\)') | Does the work of the step\. |
