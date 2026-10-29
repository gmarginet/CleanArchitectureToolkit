<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows\.Extensions](Cat.FluentWorkflows.Extensions.md 'Cat\.FluentWorkflows\.Extensions') > [CatWorkflowBuilderExtensions](CatWorkflowBuilderExtensions.md 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions')

## CatWorkflowBuilderExtensions\.BreakFromLoop\<TWorkflowState\>\(this ICatWorkflowBuilder\<TWorkflowState\>\) Method

Adds a step that leaves the nearest loop\.

```csharp
public static void BreakFromLoop<TWorkflowState>(this Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder<TWorkflowState> builder)
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>;
```
#### Type parameters

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.BreakFromLoop_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_).TWorkflowState'></a>

`TWorkflowState`

The state of the workflow\.
#### Parameters

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.BreakFromLoop_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_).builder'></a>

`builder` [Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder&lt;](..\Cat.FluentWorkflows.Abstractions\ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')[TWorkflowState](CatWorkflowBuilderExtensions.BreakFromLoop.BAG5DX9JCZ1QPIEX2JOYM8KME.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.BreakFromLoop_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_).TWorkflowState 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.BreakFromLoop\<TWorkflowState\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>\)\.TWorkflowState')[&gt;](..\Cat.FluentWorkflows.Abstractions\ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')

The builder to add the step to\.