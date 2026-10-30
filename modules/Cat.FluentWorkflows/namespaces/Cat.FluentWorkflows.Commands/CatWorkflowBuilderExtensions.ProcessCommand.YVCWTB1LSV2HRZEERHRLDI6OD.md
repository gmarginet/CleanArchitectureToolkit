<link href="../../../../resources/styles/style.css" rel="stylesheet"/>
<table>
    <tr>
        <td colspan='6' style='text-align: center; font-weight: bold; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>
             Clean Architecture Toolkit for .NET
        </td>
    </tr>
    <tr>
        <td colspan='5' style='padding: 0; vertical-align: middle; border: none;'>
            Clean Architecture Toolkit is a clean, modular architecture foundation for .NET applications.<br>
            It embraces SOLID principles and focuses on maintainability, testability, and scalability through clear boundaries and pluggable design.</td>
        <td style='padding: 0; border: none;' width='220'>
            <img src='../../../../resources/logo/CatLogo.svg' alt='' width='200' style='padding: 15px; float: right; background: #121314; border-radius: 10px'/>
        </td>
    </tr>
    <tr>
        <td colspan='6' markdown='1' style='padding-left: 0; padding-right: 0; padding-top: 15px; padding-bottom: 0; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.FLUENTWORKFLOWS](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.FluentWorkflows\.Commands Assembly](index.md 'index') >> [Cat\.FluentWorkflows\.Commands Namespace](Cat.FluentWorkflows.Commands.md 'Cat\.FluentWorkflows\.Commands') >> [CatWorkflowBuilderExtensions Class](CatWorkflowBuilderExtensions.md 'Cat\.FluentWorkflows\.Commands\.CatWorkflowBuilderExtensions')

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

`builder` [Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder&lt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')[TWorkflowState](CatWorkflowBuilderExtensions.ProcessCommand.YVCWTB1LSV2HRZEERHRLDI6OD.md#Cat.FluentWorkflows.Commands.CatWorkflowBuilderExtensions.ProcessCommand_TWorkflowState,TCommand_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_).TWorkflowState 'Cat\.FluentWorkflows\.Commands\.CatWorkflowBuilderExtensions\.ProcessCommand\<TWorkflowState,TCommand\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>\)\.TWorkflowState')[&gt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')

The builder to add the step to\.

#### Returns
[Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder&lt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatStepBuilder_TWorkflowState,TStepBody_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder\`2')[TWorkflowState](CatWorkflowBuilderExtensions.ProcessCommand.YVCWTB1LSV2HRZEERHRLDI6OD.md#Cat.FluentWorkflows.Commands.CatWorkflowBuilderExtensions.ProcessCommand_TWorkflowState,TCommand_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_).TWorkflowState 'Cat\.FluentWorkflows\.Commands\.CatWorkflowBuilderExtensions\.ProcessCommand\<TWorkflowState,TCommand\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>\)\.TWorkflowState')[,](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatStepBuilder_TWorkflowState,TStepBody_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder\`2')[Cat\.FluentWorkflows\.Commands\.Steps\.CatProcessCommandStep&lt;](CatProcessCommandStep_TCommand_.md 'Cat\.FluentWorkflows\.Commands\.Steps\.CatProcessCommandStep\<TCommand\>')[TCommand](CatWorkflowBuilderExtensions.ProcessCommand.YVCWTB1LSV2HRZEERHRLDI6OD.md#Cat.FluentWorkflows.Commands.CatWorkflowBuilderExtensions.ProcessCommand_TWorkflowState,TCommand_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_).TCommand 'Cat\.FluentWorkflows\.Commands\.CatWorkflowBuilderExtensions\.ProcessCommand\<TWorkflowState,TCommand\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>\)\.TCommand')[&gt;](CatProcessCommandStep_TCommand_.md 'Cat\.FluentWorkflows\.Commands\.Steps\.CatProcessCommandStep\<TCommand\>')[&gt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatStepBuilder_TWorkflowState,TStepBody_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder\`2')  
A builder to connect the step to the state with `Input` and `Output`\.