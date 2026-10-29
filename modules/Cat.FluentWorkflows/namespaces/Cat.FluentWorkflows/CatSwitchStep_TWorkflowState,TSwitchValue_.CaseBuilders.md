<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows\.Steps](Cat.FluentWorkflows.Steps.md 'Cat\.FluentWorkflows\.Steps') > [CatSwitchStep&lt;TWorkflowState,TSwitchValue&gt;](CatSwitchStep_TWorkflowState,TSwitchValue_.md 'Cat\.FluentWorkflows\.Steps\.CatSwitchStep\<TWorkflowState,TSwitchValue\>')

## CatSwitchStep\<TWorkflowState,TSwitchValue\>\.CaseBuilders Property

Holds the steps of each case, by the value it matches\.

```csharp
public System.Collections.Generic.Dictionary<TSwitchValue,Cat.FluentWorkflows.CatWorkflowBuilder<TWorkflowState>> CaseBuilders { get; internal set; }
```

#### Property Value
[System\.Collections\.Generic\.Dictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[TSwitchValue](CatSwitchStep_TWorkflowState,TSwitchValue_.md#Cat.FluentWorkflows.Steps.CatSwitchStep_TWorkflowState,TSwitchValue_.TSwitchValue 'Cat\.FluentWorkflows\.Steps\.CatSwitchStep\<TWorkflowState,TSwitchValue\>\.TSwitchValue')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[Cat\.FluentWorkflows\.CatWorkflowBuilder&lt;](CatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatWorkflowBuilder\<TWorkflowState\>')[TWorkflowState](CatSwitchStep_TWorkflowState,TSwitchValue_.md#Cat.FluentWorkflows.Steps.CatSwitchStep_TWorkflowState,TSwitchValue_.TWorkflowState 'Cat\.FluentWorkflows\.Steps\.CatSwitchStep\<TWorkflowState,TSwitchValue\>\.TWorkflowState')[&gt;](CatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatWorkflowBuilder\<TWorkflowState\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')