<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows\.Steps](Cat.FluentWorkflows.Steps.md 'Cat\.FluentWorkflows\.Steps')

## CatForeachState\<TCollection,TWorkflowState\> Class

The default state for the steps inside a foreach\. It holds the current item and the state of the workflow around the loop\.

```csharp
public class CatForeachState<TCollection,TWorkflowState> : Cat.FluentWorkflows.Abstractions.ICatForeachState<TCollection, TWorkflowState>, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<Cat.FluentWorkflows.Abstractions.ICatForeachState<TCollection, TWorkflowState>>, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>
```
#### Type parameters

<a name='Cat.FluentWorkflows.Steps.CatForeachState_TCollection,TWorkflowState_.TCollection'></a>

`TCollection`

The type of the items in the collection\.

<a name='Cat.FluentWorkflows.Steps.CatForeachState_TCollection,TWorkflowState_.TWorkflowState'></a>

`TWorkflowState`

The state of the workflow around the loop\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; CatForeachState\<TCollection,TWorkflowState\>

Implements [Cat\.FluentWorkflows\.Abstractions\.ICatForeachState&lt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatForeachState_TCollection,TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatForeachState\`2')[TCollection](CatForeachState_TCollection,TWorkflowState_.md#Cat.FluentWorkflows.Steps.CatForeachState_TCollection,TWorkflowState_.TCollection 'Cat\.FluentWorkflows\.Steps\.CatForeachState\<TCollection,TWorkflowState\>\.TCollection')[,](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatForeachState_TCollection,TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatForeachState\`2')[TWorkflowState](CatForeachState_TCollection,TWorkflowState_.md#Cat.FluentWorkflows.Steps.CatForeachState_TCollection,TWorkflowState_.TWorkflowState 'Cat\.FluentWorkflows\.Steps\.CatForeachState\<TCollection,TWorkflowState\>\.TWorkflowState')[&gt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatForeachState_TCollection,TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatForeachState\`2'), [Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowState&lt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowState_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowState\`1')[Cat\.FluentWorkflows\.Abstractions\.ICatForeachState&lt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatForeachState_TCollection,TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatForeachState\`2')[TCollection](CatForeachState_TCollection,TWorkflowState_.md#Cat.FluentWorkflows.Steps.CatForeachState_TCollection,TWorkflowState_.TCollection 'Cat\.FluentWorkflows\.Steps\.CatForeachState\<TCollection,TWorkflowState\>\.TCollection')[,](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatForeachState_TCollection,TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatForeachState\`2')[TWorkflowState](CatForeachState_TCollection,TWorkflowState_.md#Cat.FluentWorkflows.Steps.CatForeachState_TCollection,TWorkflowState_.TWorkflowState 'Cat\.FluentWorkflows\.Steps\.CatForeachState\<TCollection,TWorkflowState\>\.TWorkflowState')[&gt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatForeachState_TCollection,TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatForeachState\`2')[&gt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowState_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowState\`1'), [Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowState&lt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowState_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowState\`1')[TWorkflowState](CatForeachState_TCollection,TWorkflowState_.md#Cat.FluentWorkflows.Steps.CatForeachState_TCollection,TWorkflowState_.TWorkflowState 'Cat\.FluentWorkflows\.Steps\.CatForeachState\<TCollection,TWorkflowState\>\.TWorkflowState')[&gt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowState_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowState\`1')

| Properties | |
| :--- | :--- |
| [CurrentItem](CatForeachState_TCollection,TWorkflowState_.CurrentItem.md 'Cat\.FluentWorkflows\.Steps\.CatForeachState\<TCollection,TWorkflowState\>\.CurrentItem') | The item the loop is working on\. |
| [ParentWorkflowState](CatForeachState_TCollection,TWorkflowState_.ParentWorkflowState.md 'Cat\.FluentWorkflows\.Steps\.CatForeachState\<TCollection,TWorkflowState\>\.ParentWorkflowState') | The state of the workflow around the loop\. |
