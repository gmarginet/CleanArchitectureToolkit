<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows\.Steps](Cat.FluentWorkflows.Steps.md 'Cat\.FluentWorkflows\.Steps') > [CatForeachStep&lt;TWorkflowState,TCollection,TForeachState&gt;](CatForeachStep_TWorkflowState,TCollection,TForeachState_.md 'Cat\.FluentWorkflows\.Steps\.CatForeachStep\<TWorkflowState,TCollection,TForeachState\>')

## CatForeachStep\<TWorkflowState,TCollection,TForeachState\>\.Collection Property

Gets the collection from the workflow state\.

```csharp
public System.Func<TWorkflowState,System.Collections.Generic.IEnumerable<TCollection>> Collection { get; set; }
```

#### Property Value
[System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TWorkflowState](CatForeachStep_TWorkflowState,TCollection,TForeachState_.md#Cat.FluentWorkflows.Steps.CatForeachStep_TWorkflowState,TCollection,TForeachState_.TWorkflowState 'Cat\.FluentWorkflows\.Steps\.CatForeachStep\<TWorkflowState,TCollection,TForeachState\>\.TWorkflowState')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[TCollection](CatForeachStep_TWorkflowState,TCollection,TForeachState_.md#Cat.FluentWorkflows.Steps.CatForeachStep_TWorkflowState,TCollection,TForeachState_.TCollection 'Cat\.FluentWorkflows\.Steps\.CatForeachStep\<TWorkflowState,TCollection,TForeachState\>\.TCollection')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')