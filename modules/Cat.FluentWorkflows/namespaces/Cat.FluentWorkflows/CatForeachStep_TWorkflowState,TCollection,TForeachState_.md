<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows\.Steps](Cat.FluentWorkflows.Steps.md 'Cat\.FluentWorkflows\.Steps')

## CatForeachStep\<TWorkflowState,TCollection,TForeachState\> Class

Built\-in step behind `Foreach`\. It runs its inner steps once for every item of the collection,
on one shared foreach state\. A BreakFromLoop or BreakCascade stops the loop\. A BreakCascade also ends the workflow\.
The errors of every item are kept\.

```csharp
public class CatForeachStep<TWorkflowState,TCollection,TForeachState> : Cat.FluentWorkflows.CatStepBodyAsync<TWorkflowState>
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>
    where TForeachState : class, Cat.FluentWorkflows.Abstractions.ICatForeachState<TCollection, TWorkflowState>, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TForeachState>
```
#### Type parameters

<a name='Cat.FluentWorkflows.Steps.CatForeachStep_TWorkflowState,TCollection,TForeachState_.TWorkflowState'></a>

`TWorkflowState`

The state of the workflow around the loop\.

<a name='Cat.FluentWorkflows.Steps.CatForeachStep_TWorkflowState,TCollection,TForeachState_.TCollection'></a>

`TCollection`

The type of the items\.

<a name='Cat.FluentWorkflows.Steps.CatForeachStep_TWorkflowState,TCollection,TForeachState_.TForeachState'></a>

`TForeachState`

The state of the inner steps\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [CatStepBodyAsync](CatStepBodyAsync.md 'Cat\.FluentWorkflows\.CatStepBodyAsync') &#129106; [Cat\.FluentWorkflows\.CatStepBodyAsync&lt;](CatStepBodyAsync_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\<TWorkflowState\>')[TWorkflowState](CatForeachStep_TWorkflowState,TCollection,TForeachState_.md#Cat.FluentWorkflows.Steps.CatForeachStep_TWorkflowState,TCollection,TForeachState_.TWorkflowState 'Cat\.FluentWorkflows\.Steps\.CatForeachStep\<TWorkflowState,TCollection,TForeachState\>\.TWorkflowState')[&gt;](CatStepBodyAsync_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\<TWorkflowState\>') &#129106; CatForeachStep\<TWorkflowState,TCollection,TForeachState\>

| Constructors | |
| :--- | :--- |
| [CatForeachStep\(ICatStepProcessor, ILogger&lt;CatForeachStep&lt;TWorkflowState,TCollection,TForeachState&gt;&gt;\)](CatForeachStep_TWorkflowState,TCollection,TForeachState_..ctor.KLQRZ6FDFQ4C3Q4DA7NRYIXO3.md 'Cat\.FluentWorkflows\.Steps\.CatForeachStep\<TWorkflowState,TCollection,TForeachState\>\.CatForeachStep\(Cat\.FluentWorkflows\.Abstractions\.ICatStepProcessor, Microsoft\.Extensions\.Logging\.ILogger\<Cat\.FluentWorkflows\.Steps\.CatForeachStep\<TWorkflowState,TCollection,TForeachState\>\>\)') | Creates the step\. |

| Fields | |
| :--- | :--- |
| [\_catStepProcessor](CatForeachStep_TWorkflowState,TCollection,TForeachState_._catStepProcessor.md 'Cat\.FluentWorkflows\.Steps\.CatForeachStep\<TWorkflowState,TCollection,TForeachState\>\.\_catStepProcessor') | |
| [\_logger](CatForeachStep_TWorkflowState,TCollection,TForeachState_._logger.md 'Cat\.FluentWorkflows\.Steps\.CatForeachStep\<TWorkflowState,TCollection,TForeachState\>\.\_logger') | |

| Properties | |
| :--- | :--- |
| [Builder](CatForeachStep_TWorkflowState,TCollection,TForeachState_.Builder.md 'Cat\.FluentWorkflows\.Steps\.CatForeachStep\<TWorkflowState,TCollection,TForeachState\>\.Builder') | Holds the inner steps\. |
| [Collection](CatForeachStep_TWorkflowState,TCollection,TForeachState_.Collection.md 'Cat\.FluentWorkflows\.Steps\.CatForeachStep\<TWorkflowState,TCollection,TForeachState\>\.Collection') | Gets the collection from the workflow state\. |

| Methods | |
| :--- | :--- |
| [CreateForeachState\(\)](CatForeachStep_TWorkflowState,TCollection,TForeachState_.CreateForeachState().md 'Cat\.FluentWorkflows\.Steps\.CatForeachStep\<TWorkflowState,TCollection,TForeachState\>\.CreateForeachState\(\)') | Creates the state of the loop\. When the state type is an interface, as in the simple foreach, the default state class is used\. |
| [RunAsync\(CancellationToken\)](CatForeachStep_TWorkflowState,TCollection,TForeachState_.RunAsync.TQJ3RBM6DZCUDEKLQ6ACI13ZD.md 'Cat\.FluentWorkflows\.Steps\.CatForeachStep\<TWorkflowState,TCollection,TForeachState\>\.RunAsync\(System\.Threading\.CancellationToken\)') | Runs the step\. |
