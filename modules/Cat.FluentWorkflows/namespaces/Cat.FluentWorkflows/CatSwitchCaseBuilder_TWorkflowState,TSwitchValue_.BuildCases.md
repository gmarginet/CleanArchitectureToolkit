<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows\.Steps](Cat.FluentWorkflows.Steps.md 'Cat\.FluentWorkflows\.Steps') > [CatSwitchCaseBuilder&lt;TWorkflowState,TSwitchValue&gt;](CatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.md 'Cat\.FluentWorkflows\.Steps\.CatSwitchCaseBuilder\<TWorkflowState,TSwitchValue\>')

## CatSwitchCaseBuilder\<TWorkflowState,TSwitchValue\>\.BuildCases Property

```csharp
internal System.Collections.Generic.Dictionary<TSwitchValue,System.Action<Cat.FluentWorkflows.CatWorkflowBuilder<TWorkflowState>>> BuildCases { internal get; }
```

#### Property Value
[System\.Collections\.Generic\.Dictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[TSwitchValue](CatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.md#Cat.FluentWorkflows.Steps.CatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.TSwitchValue 'Cat\.FluentWorkflows\.Steps\.CatSwitchCaseBuilder\<TWorkflowState,TSwitchValue\>\.TSwitchValue')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[Cat\.FluentWorkflows\.CatWorkflowBuilder&lt;](CatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatWorkflowBuilder\<TWorkflowState\>')[TWorkflowState](CatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.md#Cat.FluentWorkflows.Steps.CatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.TWorkflowState 'Cat\.FluentWorkflows\.Steps\.CatSwitchCaseBuilder\<TWorkflowState,TSwitchValue\>\.TWorkflowState')[&gt;](CatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatWorkflowBuilder\<TWorkflowState\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')