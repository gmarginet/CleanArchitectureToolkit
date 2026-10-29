<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.FluentWorkflows\.Abstractions](index.md 'index') > [Cat\.FluentWorkflows\.Abstractions](Cat.FluentWorkflows.Abstractions.md 'Cat\.FluentWorkflows\.Abstractions') > [ICatSwitchCaseBuilder&lt;TWorkflowState,TSwitchValue&gt;](ICatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatSwitchCaseBuilder\<TWorkflowState,TSwitchValue\>')

## ICatSwitchCaseBuilder\<TWorkflowState,TSwitchValue\>\.Default\(Action\<ICatWorkflowBuilder\<TWorkflowState\>\>\) Method

Adds the steps to run when no case matches\.

```csharp
void Default(System.Action<Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder<TWorkflowState>> defaultCaseBuilder);
```
#### Parameters

<a name='Cat.FluentWorkflows.Abstractions.ICatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.Default(System.Action_Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState__).defaultCaseBuilder'></a>

`defaultCaseBuilder` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder&lt;](ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>')[TWorkflowState](ICatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.md#Cat.FluentWorkflows.Abstractions.ICatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.TWorkflowState 'Cat\.FluentWorkflows\.Abstractions\.ICatSwitchCaseBuilder\<TWorkflowState,TSwitchValue\>\.TWorkflowState')[&gt;](ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

Adds the steps\.