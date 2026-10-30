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
            <img src='../../../../resources/logo/CatLogo-RoundedCorners-320x160.png' alt='' width='200' style='float: right;'/>
        </td>
    </tr>
    <tr>
        <td colspan='6' markdown='1' style='padding-left: 0; padding-right: 0; padding-top: 15px; padding-bottom: 0; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>

|&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[CAT.FLUENTWORKFLOWS](../../README.md)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.FluentWorkflows\.Abstractions Assembly](index.md 'index')

## Cat\.FluentWorkflows\.Abstractions Namespace

Defines the contracts for fluent workflows: workflows and their state, the builder you describe steps with,
the step bodies that do the work, and the processors that run them\.

| Interfaces | |
| :--- | :--- |
| [ICatForeachState&lt;TCollection,TWorkflowState&gt;](ICatForeachState_TCollection,TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatForeachState\<TCollection,TWorkflowState\>') | The state of the steps inside a foreach\. It holds the current item and the state of the workflow around the loop\. |
| [ICatHasSubWorkflowState&lt;TSubWorkflowState&gt;](ICatHasSubWorkflowState_TSubWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatHasSubWorkflowState\<TSubWorkflowState\>') | Marks a workflow state that carries the state for a sub\-workflow\. |
| [ICatStepBodyAsync](ICatStepBodyAsync.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBodyAsync') | The code of one step\. Derive from `CatStepBody` or `CatStepBodyAsync` instead of implementing this yourself\. |
| [ICatStepBodyWithState&lt;TWorkflowState&gt;](ICatStepBodyWithState_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBodyWithState\<TWorkflowState\>') | Marks a step body that wants the state of the workflow\. The step processor sets it before the step runs\. |
| [ICatStepBuilder&lt;TWorkflowState,TStepBody&gt;](ICatStepBuilder_TWorkflowState,TStepBody_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder\<TWorkflowState,TStepBody\>') | Connects a step to the workflow state\. Inputs go from the state into the step before it runs\. Outputs go from the step back into the state after it ran\. |
| [ICatStepParameter](ICatStepParameter.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepParameter') | One input or output of a step\. |
| [ICatStepProcessor](ICatStepProcessor.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepProcessor') | Runs a list of steps one by one\. Steps like if and foreach use it to run their own inner steps\. |
| [ICatSwitchCaseBuilder&lt;TWorkflowState,TSwitchValue&gt;](ICatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatSwitchCaseBuilder\<TWorkflowState,TSwitchValue\>') | Describes the cases of a switch step\. |
| [ICatWorkflow&lt;TWorkflowState&gt;](ICatWorkflow_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflow\<TWorkflowState\>') | Describes one workflow: the steps to run, in order\. Implement it once per workflow\. The module finds and registers it for you\. |
| [ICatWorkflowBuilder&lt;TWorkflowState&gt;](ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>') | Collects the steps of a workflow\. You get one in [Build\(ICatWorkflowBuilder&lt;TWorkflowState&gt;\)](ICatWorkflow_TWorkflowState_.Build.7RYNT7LWF2VVKIZWAO62GD9R6.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflow\<TWorkflowState\>\.Build\(Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>\)')\. The steps themselves are extension methods in `Cat.FluentWorkflows.Extensions`\. Each one adds a step to [WorkflowSteps](ICatWorkflowBuilder_TWorkflowState_.WorkflowSteps.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>\.WorkflowSteps'), and the steps run in the order they were added\. |
| [ICatWorkflowProcessor](ICatWorkflowProcessor.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowProcessor') | Single entry point for running a workflow\. |
| [ICatWorkflowResponse](ICatWorkflowResponse.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowResponse') | The outcome of a step or a workflow: what to do next, and the errors if something failed\. |
| [ICatWorkflowState&lt;TWorkflowState&gt;](ICatWorkflowState_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowState\<TWorkflowState\>') | Marks the class that holds the data of a workflow\. Steps read from it and write to it\. Implement it with the class itself as the type argument, like `class OrderState : ICatWorkflowState<OrderState>`\. |
| [ICatWorkflowStep](ICatWorkflowStep.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowStep') | One step in a workflow: the step body to run and how it connects to the state\. |

| Enums | |
| :--- | :--- |
| [CatStepExecutionResult](CatStepExecutionResult.md 'Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult') | Tells the step processor what to do after a step\. Every step returns one inside its workflow response\. |
