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

|&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[CAT.FLUENTWORKFLOWS](../../README.md)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.FluentWorkflows Assembly](index.md 'index')

## Cat\.FluentWorkflows\.Steps Namespace

| Classes | |
| :--- | :--- |
| [CatBreakIfStep&lt;TWorkflowState&gt;](CatBreakIfStep_TWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatBreakIfStep\<TWorkflowState\>') | Built\-in step behind `BreakCascadeIf`, `BreakFromCurrentFlowOnlyIf` and `BreakFromLoopIf`\. It runs the check\. When the check returns `true` it breaks the way [BreakType](CatBreakIfStep_TWorkflowState_.BreakType.md 'Cat\.FluentWorkflows\.Steps\.CatBreakIfStep\<TWorkflowState\>\.BreakType') says, otherwise it continues\. |
| [CatBreakStep](CatBreakStep.md 'Cat\.FluentWorkflows\.Steps\.CatBreakStep') | Built\-in step behind `BreakCascade`, `BreakFromCurrentFlowOnly` and `BreakFromLoop`\. It always breaks the way [BreakType](CatBreakStep.BreakType.md 'Cat\.FluentWorkflows\.Steps\.CatBreakStep\.BreakType') says\. |
| [CatForeachState&lt;TCollection,TWorkflowState&gt;](CatForeachState_TCollection,TWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatForeachState\<TCollection,TWorkflowState\>') | The default state for the steps inside a foreach\. It holds the current item and the state of the workflow around the loop\. |
| [CatForeachStep&lt;TWorkflowState,TCollection,TForeachState&gt;](CatForeachStep_TWorkflowState,TCollection,TForeachState_.md 'Cat\.FluentWorkflows\.Steps\.CatForeachStep\<TWorkflowState,TCollection,TForeachState\>') | Built\-in step behind `Foreach`\. It runs its inner steps once for every item of the collection, on one shared foreach state\. A BreakFromLoop or BreakCascade stops the loop\. A BreakCascade also ends the workflow\. The errors of every item are kept\. |
| [CatIfStep&lt;TWorkflowState&gt;](CatIfStep_TWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatIfStep\<TWorkflowState\>') | Built\-in step behind `If`\. It runs the then steps when the condition is `true`, otherwise the else steps, if there are any\. A break result from the inner steps goes on to the steps around the if\. |
| [CatInlineActionStep&lt;TWorkflowState&gt;](CatInlineActionStep_TWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatInlineActionStep\<TWorkflowState\>') | Built\-in step behind `Run(Action)`\. It runs your code and always continues\. |
| [CatInlineFuncStep&lt;TWorkflowState&gt;](CatInlineFuncStep_TWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatInlineFuncStep\<TWorkflowState\>') | Built\-in step behind `Run(Func)`\. It runs your code\. A succeeded response carries the result to use\. A failed response ends the workflow with BreakCascade and passes the errors on\. |
| [CatLogStep&lt;TWorkflowState&gt;](CatLogStep_TWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatLogStep\<TWorkflowState\>') | Built\-in step behind `Log` and the level specific log methods\. It writes one log entry and continues\. |
| [CatRunSubWorkflowStep&lt;TWorkflowState,TSubWorkflow,TSubWorkflowState&gt;](CatRunSubWorkflowStep_TWorkflowState,TSubWorkflow,TSubWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatRunSubWorkflowStep\<TWorkflowState,TSubWorkflow,TSubWorkflowState\>') | Built\-in step behind `Run<TSubWorkflow, TSubWorkflowState, TWorkflowState>`\. It runs another workflow on the sub\-workflow state that the main state carries\. A BreakFromCurrentFlowOnly inside the sub\-workflow ends only the sub\-workflow\. |
| [CatSetStatePropertyStep&lt;TWorkflowState,TProperty&gt;](CatSetStatePropertyStep_TWorkflowState,TProperty_.md 'Cat\.FluentWorkflows\.Steps\.CatSetStatePropertyStep\<TWorkflowState,TProperty\>') | Built\-in step behind `Set`\. It calculates a value and writes it to a property of the workflow state\. |
| [CatSwitchCaseBuilder&lt;TWorkflowState,TSwitchValue&gt;](CatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.md 'Cat\.FluentWorkflows\.Steps\.CatSwitchCaseBuilder\<TWorkflowState,TSwitchValue\>') | Default [ICatSwitchCaseBuilder&lt;TWorkflowState,TSwitchValue&gt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatSwitchCaseBuilder\`2')\. Collects the cases and the default case of a switch step\. |
| [CatSwitchStep&lt;TWorkflowState,TSwitchValue&gt;](CatSwitchStep_TWorkflowState,TSwitchValue_.md 'Cat\.FluentWorkflows\.Steps\.CatSwitchStep\<TWorkflowState,TSwitchValue\>') | Built\-in step behind `Switch`\. It runs the steps of the case that matches the value\. With no match it runs the default case\. With no default case either it does nothing and continues\. |
| [CatWhileStep&lt;TWorkflowState&gt;](CatWhileStep_TWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatWhileStep\<TWorkflowState\>') | Built\-in step behind `While`\. It repeats its inner steps while the condition is `true`\. A BreakFromLoop leaves the loop and continues\. A BreakCascade leaves the loop and ends the workflow\. The errors of every pass are kept\. |

| Enums | |
| :--- | :--- |
| [CatBreakType](CatBreakType.md 'Cat\.FluentWorkflows\.Steps\.CatBreakType') | The kinds of break a break step can make\. |
