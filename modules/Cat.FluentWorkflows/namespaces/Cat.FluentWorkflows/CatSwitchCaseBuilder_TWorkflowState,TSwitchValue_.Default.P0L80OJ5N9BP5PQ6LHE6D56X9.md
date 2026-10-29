<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows\.Steps](Cat.FluentWorkflows.Steps.md 'Cat\.FluentWorkflows\.Steps') > [CatSwitchCaseBuilder&lt;TWorkflowState,TSwitchValue&gt;](CatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.md 'Cat\.FluentWorkflows\.Steps\.CatSwitchCaseBuilder\<TWorkflowState,TSwitchValue\>')

## CatSwitchCaseBuilder\<TWorkflowState,TSwitchValue\>\.Default\(Action\<ICatWorkflowBuilder\<TWorkflowState\>\>\) Method

Adds the steps to run when no case matches\.

```csharp
public void Default(System.Action<Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder<TWorkflowState>> defaultCaseBuilder);
```
#### Parameters

<a name='Cat.FluentWorkflows.Steps.CatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.Default(System.Action_Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState__).defaultCaseBuilder'></a>

`defaultCaseBuilder` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder&lt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')[TWorkflowState](CatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.md#Cat.FluentWorkflows.Steps.CatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.TWorkflowState 'Cat\.FluentWorkflows\.Steps\.CatSwitchCaseBuilder\<TWorkflowState,TSwitchValue\>\.TWorkflowState')[&gt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

Adds the steps\.

Implements [Default\(Action&lt;ICatWorkflowBuilder&lt;TWorkflowState&gt;&gt;\)](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.Default.RQTMMYBVC4TIU3P75LQHNIYZ3.md 'Cat\.FluentWorkflows\.Abstractions\.ICatSwitchCaseBuilder\`2\.Default\(System\.Action\{Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\{\`0\}\}\)')