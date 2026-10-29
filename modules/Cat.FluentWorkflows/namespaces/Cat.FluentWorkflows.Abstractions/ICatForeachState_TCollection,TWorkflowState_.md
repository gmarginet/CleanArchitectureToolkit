<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows\.Abstractions](index.md 'index') > [Cat\.FluentWorkflows\.Abstractions](Cat.FluentWorkflows.Abstractions.md 'Cat\.FluentWorkflows\.Abstractions')

## ICatForeachState\<TCollection,TWorkflowState\> Interface

The state of the steps inside a foreach\. It holds the current item and the state of the workflow around the loop\.

```csharp
public interface ICatForeachState<TCollection,TWorkflowState> : Cat.FluentWorkflows.Abstractions.ICatWorkflowState<Cat.FluentWorkflows.Abstractions.ICatForeachState<TCollection, TWorkflowState>>
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>
```
#### Type parameters

<a name='Cat.FluentWorkflows.Abstractions.ICatForeachState_TCollection,TWorkflowState_.TCollection'></a>

`TCollection`

The type of the items in the collection\.

<a name='Cat.FluentWorkflows.Abstractions.ICatForeachState_TCollection,TWorkflowState_.TWorkflowState'></a>

`TWorkflowState`

The state of the workflow around the loop\.

Implements [Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowState&lt;](ICatWorkflowState_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowState\<TWorkflowState\>')[Cat\.FluentWorkflows\.Abstractions\.ICatForeachState&lt;](ICatForeachState_TCollection,TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatForeachState\<TCollection,TWorkflowState\>')[TCollection](ICatForeachState_TCollection,TWorkflowState_.md#Cat.FluentWorkflows.Abstractions.ICatForeachState_TCollection,TWorkflowState_.TCollection 'Cat\.FluentWorkflows\.Abstractions\.ICatForeachState\<TCollection,TWorkflowState\>\.TCollection')[,](ICatForeachState_TCollection,TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatForeachState\<TCollection,TWorkflowState\>')[TWorkflowState](ICatForeachState_TCollection,TWorkflowState_.md#Cat.FluentWorkflows.Abstractions.ICatForeachState_TCollection,TWorkflowState_.TWorkflowState 'Cat\.FluentWorkflows\.Abstractions\.ICatForeachState\<TCollection,TWorkflowState\>\.TWorkflowState')[&gt;](ICatForeachState_TCollection,TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatForeachState\<TCollection,TWorkflowState\>')[&gt;](ICatWorkflowState_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowState\<TWorkflowState\>')

| Properties | |
| :--- | :--- |
| [CurrentItem](ICatForeachState_TCollection,TWorkflowState_.CurrentItem.md 'Cat\.FluentWorkflows\.Abstractions\.ICatForeachState\<TCollection,TWorkflowState\>\.CurrentItem') | The item the loop is working on\. |
| [ParentWorkflowState](ICatForeachState_TCollection,TWorkflowState_.ParentWorkflowState.md 'Cat\.FluentWorkflows\.Abstractions\.ICatForeachState\<TCollection,TWorkflowState\>\.ParentWorkflowState') | The state of the workflow around the loop\. |
