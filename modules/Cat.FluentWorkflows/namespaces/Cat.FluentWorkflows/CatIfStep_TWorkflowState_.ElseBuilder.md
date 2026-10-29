<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows\.Steps](Cat.FluentWorkflows.Steps.md 'Cat\.FluentWorkflows\.Steps') > [CatIfStep&lt;TWorkflowState&gt;](CatIfStep_TWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatIfStep\<TWorkflowState\>')

## CatIfStep\<TWorkflowState\>\.ElseBuilder Property

Holds the steps to run when the condition is `false`, or `null` for none\.

```csharp
public Cat.FluentWorkflows.CatWorkflowBuilder<TWorkflowState>? ElseBuilder { get; set; }
```

#### Property Value
[Cat\.FluentWorkflows\.CatWorkflowBuilder&lt;](CatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatWorkflowBuilder\<TWorkflowState\>')[TWorkflowState](CatIfStep_TWorkflowState_.md#Cat.FluentWorkflows.Steps.CatIfStep_TWorkflowState_.TWorkflowState 'Cat\.FluentWorkflows\.Steps\.CatIfStep\<TWorkflowState\>\.TWorkflowState')[&gt;](CatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatWorkflowBuilder\<TWorkflowState\>')