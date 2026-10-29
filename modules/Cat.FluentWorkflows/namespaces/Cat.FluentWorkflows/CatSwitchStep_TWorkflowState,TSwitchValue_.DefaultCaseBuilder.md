<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows\.Steps](Cat.FluentWorkflows.Steps.md 'Cat\.FluentWorkflows\.Steps') > [CatSwitchStep&lt;TWorkflowState,TSwitchValue&gt;](CatSwitchStep_TWorkflowState,TSwitchValue_.md 'Cat\.FluentWorkflows\.Steps\.CatSwitchStep\<TWorkflowState,TSwitchValue\>')

## CatSwitchStep\<TWorkflowState,TSwitchValue\>\.DefaultCaseBuilder Property

Holds the steps to run when no case matches, or `null` for none\.

```csharp
public Cat.FluentWorkflows.CatWorkflowBuilder<TWorkflowState>? DefaultCaseBuilder { get; internal set; }
```

#### Property Value
[Cat\.FluentWorkflows\.CatWorkflowBuilder&lt;](CatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatWorkflowBuilder\<TWorkflowState\>')[TWorkflowState](CatSwitchStep_TWorkflowState,TSwitchValue_.md#Cat.FluentWorkflows.Steps.CatSwitchStep_TWorkflowState,TSwitchValue_.TWorkflowState 'Cat\.FluentWorkflows\.Steps\.CatSwitchStep\<TWorkflowState,TSwitchValue\>\.TWorkflowState')[&gt;](CatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatWorkflowBuilder\<TWorkflowState\>')