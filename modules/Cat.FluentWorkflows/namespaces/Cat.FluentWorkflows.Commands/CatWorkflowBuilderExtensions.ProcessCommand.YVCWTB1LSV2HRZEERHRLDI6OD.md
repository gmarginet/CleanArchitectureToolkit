<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows\.Commands](index.md 'index') > [Cat\.FluentWorkflows\.Commands](Cat.FluentWorkflows.Commands.md 'Cat\.FluentWorkflows\.Commands') > [CatWorkflowBuilderExtensions](CatWorkflowBuilderExtensions.md 'Cat\.FluentWorkflows\.Commands\.CatWorkflowBuilderExtensions')

## CatWorkflowBuilderExtensions\.ProcessCommand\<TWorkflowState,TCommand\>\(this ICatWorkflowBuilder\<TWorkflowState\>\) Method

Adds a step that processes a command\.
The command is created with its parameterless constructor\. Fill it with `Input`, like `.Input(s => s.Name, step => step.Command.Name)`\.
A failed command ends the workflow with BreakCascade and the errors of the command\.

```csharp
public static Cat.FluentWorkflows.Abstractions.ICatStepBuilder<TWorkflowState,Cat.FluentWorkflows.Commands.Steps.CatProcessCommandStep<TCommand>> ProcessCommand<TWorkflowState,TCommand>(this Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder<TWorkflowState> builder)
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>
    where TCommand : class, Cat.Commands.Abstractions.ICatCommand;
```
#### Type parameters

<a name='Cat.FluentWorkflows.Commands.CatWorkflowBuilderExtensions.ProcessCommand_TWorkflowState,TCommand_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_).TWorkflowState'></a>

`TWorkflowState`

The state of the workflow\.

<a name='Cat.FluentWorkflows.Commands.CatWorkflowBuilderExtensions.ProcessCommand_TWorkflowState,TCommand_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_).TCommand'></a>

`TCommand`

The command to process\.
#### Parameters

<a name='Cat.FluentWorkflows.Commands.CatWorkflowBuilderExtensions.ProcessCommand_TWorkflowState,TCommand_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_).builder'></a>

`builder` [Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder&lt;](../Cat.FluentWorkflows.Abstractions/ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')[TWorkflowState](CatWorkflowBuilderExtensions.ProcessCommand.YVCWTB1LSV2HRZEERHRLDI6OD.md#Cat.FluentWorkflows.Commands.CatWorkflowBuilderExtensions.ProcessCommand_TWorkflowState,TCommand_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_).TWorkflowState 'Cat\.FluentWorkflows\.Commands\.CatWorkflowBuilderExtensions\.ProcessCommand\<TWorkflowState,TCommand\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>\)\.TWorkflowState')[&gt;](../Cat.FluentWorkflows.Abstractions/ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')

The builder to add the step to\.

#### Returns
[Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder&lt;](../Cat.FluentWorkflows.Abstractions/ICatStepBuilder_TWorkflowState,TStepBody_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder\`2')[TWorkflowState](CatWorkflowBuilderExtensions.ProcessCommand.YVCWTB1LSV2HRZEERHRLDI6OD.md#Cat.FluentWorkflows.Commands.CatWorkflowBuilderExtensions.ProcessCommand_TWorkflowState,TCommand_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_).TWorkflowState 'Cat\.FluentWorkflows\.Commands\.CatWorkflowBuilderExtensions\.ProcessCommand\<TWorkflowState,TCommand\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>\)\.TWorkflowState')[,](../Cat.FluentWorkflows.Abstractions/ICatStepBuilder_TWorkflowState,TStepBody_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder\`2')[Cat\.FluentWorkflows\.Commands\.Steps\.CatProcessCommandStep&lt;](CatProcessCommandStep_TCommand_.md 'Cat\.FluentWorkflows\.Commands\.Steps\.CatProcessCommandStep\<TCommand\>')[TCommand](CatWorkflowBuilderExtensions.ProcessCommand.YVCWTB1LSV2HRZEERHRLDI6OD.md#Cat.FluentWorkflows.Commands.CatWorkflowBuilderExtensions.ProcessCommand_TWorkflowState,TCommand_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_).TCommand 'Cat\.FluentWorkflows\.Commands\.CatWorkflowBuilderExtensions\.ProcessCommand\<TWorkflowState,TCommand\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>\)\.TCommand')[&gt;](CatProcessCommandStep_TCommand_.md 'Cat\.FluentWorkflows\.Commands\.Steps\.CatProcessCommandStep\<TCommand\>')[&gt;](../Cat.FluentWorkflows.Abstractions/ICatStepBuilder_TWorkflowState,TStepBody_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder\`2')  
A builder to connect the step to the state with `Input` and `Output`\.