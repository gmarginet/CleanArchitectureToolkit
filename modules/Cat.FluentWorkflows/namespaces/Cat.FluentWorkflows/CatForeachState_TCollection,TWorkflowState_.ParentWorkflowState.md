<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows\.Steps](Cat.FluentWorkflows.Steps.md 'Cat\.FluentWorkflows\.Steps') > [CatForeachState&lt;TCollection,TWorkflowState&gt;](CatForeachState_TCollection,TWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatForeachState\<TCollection,TWorkflowState\>')

## CatForeachState\<TCollection,TWorkflowState\>\.ParentWorkflowState Property

The state of the workflow around the loop\.

```csharp
public TWorkflowState ParentWorkflowState { get; set; }
```

Implements [ParentWorkflowState](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatForeachState_TCollection,TWorkflowState_.ParentWorkflowState.md 'Cat\.FluentWorkflows\.Abstractions\.ICatForeachState\`2\.ParentWorkflowState')

#### Property Value
[TWorkflowState](CatForeachState_TCollection,TWorkflowState_.md#Cat.FluentWorkflows.Steps.CatForeachState_TCollection,TWorkflowState_.TWorkflowState 'Cat\.FluentWorkflows\.Steps\.CatForeachState\<TCollection,TWorkflowState\>\.TWorkflowState')