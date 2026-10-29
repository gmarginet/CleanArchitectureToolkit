<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows\.Steps](Cat.FluentWorkflows.Steps.md 'Cat\.FluentWorkflows\.Steps') > [CatForeachStep&lt;TWorkflowState,TCollection,TForeachState&gt;](CatForeachStep_TWorkflowState,TCollection,TForeachState_.md 'Cat\.FluentWorkflows\.Steps\.CatForeachStep\<TWorkflowState,TCollection,TForeachState\>')

## CatForeachStep\<TWorkflowState,TCollection,TForeachState\>\.CreateForeachState\(\) Method

Creates the state of the loop\. When the state type is an interface, as in the simple foreach, the default state class is used\.

```csharp
private static TForeachState CreateForeachState();
```

#### Returns
[TForeachState](CatForeachStep_TWorkflowState,TCollection,TForeachState_.md#Cat.FluentWorkflows.Steps.CatForeachStep_TWorkflowState,TCollection,TForeachState_.TForeachState 'Cat\.FluentWorkflows\.Steps\.CatForeachStep\<TWorkflowState,TCollection,TForeachState\>\.TForeachState')