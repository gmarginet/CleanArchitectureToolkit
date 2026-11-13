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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.FLUENTWORKFLOWS](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.FluentWorkflows Assembly](index.md 'index') >> [Cat\.FluentWorkflows Namespace](Cat.FluentWorkflows.md 'Cat\.FluentWorkflows')

## CatContainerStepBody\<TWorkflowState\> Class

Base class for a step that runs other steps, such as an if or a loop\. It handles the frame of a suspend and a resume for you\.
Run the inner steps with [RunChildStepsAsync&lt;TChildState&gt;\(ICatStepProcessor, ICatWorkflowBuilder&lt;TChildState&gt;, TChildState, bool, CancellationToken\)](CatContainerStepBody_TWorkflowState_.RunChildStepsAsync.FHZ9TLOGUNDVTM092VJR0IW68.md 'Cat\.FluentWorkflows\.CatContainerStepBody\<TWorkflowState\>\.RunChildStepsAsync\<TChildState\>\(Cat\.FluentWorkflows\.Abstractions\.ICatStepProcessor, Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TChildState\>, TChildState, bool, System\.Threading\.CancellationToken\)')\. When the result suspends, return [Suspended\(ICatWorkflowResponse, Action&lt;CatCheckpointFrame&gt;\)](CatContainerStepBody_TWorkflowState_.Suspended.md#Cat.FluentWorkflows.CatContainerStepBody_TWorkflowState_.Suspended(Cat.FluentWorkflows.Abstractions.ICatWorkflowResponse,System.Action_Cat.FluentWorkflows.Abstractions.CatCheckpointFrame_) 'Cat\.FluentWorkflows\.CatContainerStepBody\<TWorkflowState\>\.Suspended\(Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowResponse, System\.Action\<Cat\.FluentWorkflows\.Abstractions\.CatCheckpointFrame\>\)')
and write in the frame what you need to find your place again\. On a resume read it from [SavedFrame](CatContainerStepBody_TWorkflowState_.SavedFrame.md 'Cat\.FluentWorkflows\.CatContainerStepBody\<TWorkflowState\>\.SavedFrame')\.

```csharp
public abstract class CatContainerStepBody<TWorkflowState> : Cat.FluentWorkflows.CatStepBodyAsync<TWorkflowState>, Cat.FluentWorkflows.Abstractions.ICatContainerStepBody
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>
```
#### Type parameters

<a name='Cat.FluentWorkflows.CatContainerStepBody_TWorkflowState_.TWorkflowState'></a>

`TWorkflowState`

The state of the workflow\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [CatStepBodyAsync](CatStepBodyAsync.md 'Cat\.FluentWorkflows\.CatStepBodyAsync') → [Cat\.FluentWorkflows\.CatStepBodyAsync&lt;](CatStepBodyAsync_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\<TWorkflowState\>')[TWorkflowState](CatContainerStepBody_TWorkflowState_.md#Cat.FluentWorkflows.CatContainerStepBody_TWorkflowState_.TWorkflowState 'Cat\.FluentWorkflows\.CatContainerStepBody\<TWorkflowState\>\.TWorkflowState')[&gt;](CatStepBodyAsync_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\<TWorkflowState\>') → CatContainerStepBody\<TWorkflowState\>

Derived  
↳ [CatForeachStep&lt;TWorkflowState,TCollection,TForeachState&gt;](CatForeachStep_TWorkflowState,TCollection,TForeachState_.md 'Cat\.FluentWorkflows\.Steps\.CatForeachStep\<TWorkflowState,TCollection,TForeachState\>')  
↳ [CatIfStep&lt;TWorkflowState&gt;](CatIfStep_TWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatIfStep\<TWorkflowState\>')  
↳ [CatParallelStep&lt;TWorkflowState&gt;](CatParallelStep_TWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatParallelStep\<TWorkflowState\>')  
↳ [CatRunSubWorkflowStep&lt;TWorkflowState,TSubWorkflow,TSubWorkflowState&gt;](CatRunSubWorkflowStep_TWorkflowState,TSubWorkflow,TSubWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatRunSubWorkflowStep\<TWorkflowState,TSubWorkflow,TSubWorkflowState\>')  
↳ [CatSwitchStep&lt;TWorkflowState,TSwitchValue&gt;](CatSwitchStep_TWorkflowState,TSwitchValue_.md 'Cat\.FluentWorkflows\.Steps\.CatSwitchStep\<TWorkflowState,TSwitchValue\>')  
↳ [CatWhileStep&lt;TWorkflowState&gt;](CatWhileStep_TWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatWhileStep\<TWorkflowState\>')

Implements [ICatContainerStepBody](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatContainerStepBody.md 'Cat\.FluentWorkflows\.Abstractions\.ICatContainerStepBody')

| Constructors | |
| :--- | :--- |
| [CatContainerStepBody\(ILogger\)](CatContainerStepBody_TWorkflowState_..ctor.4Q43KA7L4GDQ5BXY8R11R9D12.md 'Cat\.FluentWorkflows\.CatContainerStepBody\<TWorkflowState\>\.CatContainerStepBody\(Microsoft\.Extensions\.Logging\.ILogger\)') | Creates the step\. |

| Properties | |
| :--- | :--- |
| [Resume](CatContainerStepBody_TWorkflowState_.Resume.md 'Cat\.FluentWorkflows\.CatContainerStepBody\<TWorkflowState\>\.Resume') | The saved frame of this step when the workflow is being resumed, otherwise `null`\. The step processor sets it before the step runs\. |
| [SavedFrame](CatContainerStepBody_TWorkflowState_.SavedFrame.md 'Cat\.FluentWorkflows\.CatContainerStepBody\<TWorkflowState\>\.SavedFrame') | The frame this step wrote when it suspended, or `null` when the step runs for the first time\. When it is set, go on in the branch it names and do not decide again\. |

| Methods | |
| :--- | :--- |
| [RunChildStepsAsync&lt;TChildState&gt;\(ICatStepProcessor, ICatWorkflowBuilder&lt;TChildState&gt;, TChildState, bool, CancellationToken\)](CatContainerStepBody_TWorkflowState_.RunChildStepsAsync.FHZ9TLOGUNDVTM092VJR0IW68.md 'Cat\.FluentWorkflows\.CatContainerStepBody\<TWorkflowState\>\.RunChildStepsAsync\<TChildState\>\(Cat\.FluentWorkflows\.Abstractions\.ICatStepProcessor, Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TChildState\>, TChildState, bool, System\.Threading\.CancellationToken\)') | Runs the inner steps\. With [resuming](CatContainerStepBody_TWorkflowState_.RunChildStepsAsync.FHZ9TLOGUNDVTM092VJR0IW68.md#Cat.FluentWorkflows.CatContainerStepBody_TWorkflowState_.RunChildStepsAsync_TChildState_(Cat.FluentWorkflows.Abstractions.ICatStepProcessor,Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TChildState_,TChildState,bool,System.Threading.CancellationToken).resuming 'Cat\.FluentWorkflows\.CatContainerStepBody\<TWorkflowState\>\.RunChildStepsAsync\<TChildState\>\(Cat\.FluentWorkflows\.Abstractions\.ICatStepProcessor, Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TChildState\>, TChildState, bool, System\.Threading\.CancellationToken\)\.resuming') set, the run goes on at the step that suspended inside this container\. Set it only for the first pass of a loop\. |
| [Suspended\(ICatWorkflowResponse, Action&lt;CatCheckpointFrame&gt;\)](CatContainerStepBody_TWorkflowState_.Suspended.md#Cat.FluentWorkflows.CatContainerStepBody_TWorkflowState_.Suspended(Cat.FluentWorkflows.Abstractions.ICatWorkflowResponse,System.Action_Cat.FluentWorkflows.Abstractions.CatCheckpointFrame_) 'Cat\.FluentWorkflows\.CatContainerStepBody\<TWorkflowState\>\.Suspended\(Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowResponse, System\.Action\<Cat\.FluentWorkflows\.Abstractions\.CatCheckpointFrame\>\)') | Creates the response of a container whose inner steps suspended\. It keeps the errors of the inner steps\. |
| [Suspended\(ICatWorkflowResponse, IReadOnlyList&lt;ICatError&gt;, Action&lt;CatCheckpointFrame&gt;\)](CatContainerStepBody_TWorkflowState_.Suspended.md#Cat.FluentWorkflows.CatContainerStepBody_TWorkflowState_.Suspended(Cat.FluentWorkflows.Abstractions.ICatWorkflowResponse,System.Collections.Generic.IReadOnlyList_Cat.Responses.Abstractions.ICatError_,System.Action_Cat.FluentWorkflows.Abstractions.CatCheckpointFrame_) 'Cat\.FluentWorkflows\.CatContainerStepBody\<TWorkflowState\>\.Suspended\(Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowResponse, System\.Collections\.Generic\.IReadOnlyList\<Cat\.Responses\.Abstractions\.ICatError\>, System\.Action\<Cat\.FluentWorkflows\.Abstractions\.CatCheckpointFrame\>\)') | Creates the response of a container whose inner steps suspended, with the errors collected over several passes\. |
