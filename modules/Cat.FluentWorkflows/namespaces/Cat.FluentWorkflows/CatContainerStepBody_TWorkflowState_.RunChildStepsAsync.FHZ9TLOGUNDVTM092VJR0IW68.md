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
  
##### >> [Cat\.FluentWorkflows Assembly](index.md 'index') >> [Cat\.FluentWorkflows Namespace](Cat.FluentWorkflows.md 'Cat\.FluentWorkflows') >> [CatContainerStepBody&lt;TWorkflowState&gt; Class](CatContainerStepBody_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatContainerStepBody\<TWorkflowState\>')

## CatContainerStepBody\<TWorkflowState\>\.RunChildStepsAsync\<TChildState\>\(ICatStepProcessor, ICatWorkflowBuilder\<TChildState\>, TChildState, bool, CancellationToken\) Method

Runs the inner steps\. With [resuming](CatContainerStepBody_TWorkflowState_.RunChildStepsAsync.FHZ9TLOGUNDVTM092VJR0IW68.md#Cat.FluentWorkflows.CatContainerStepBody_TWorkflowState_.RunChildStepsAsync_TChildState_(Cat.FluentWorkflows.Abstractions.ICatStepProcessor,Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TChildState_,TChildState,bool,System.Threading.CancellationToken).resuming 'Cat\.FluentWorkflows\.CatContainerStepBody\<TWorkflowState\>\.RunChildStepsAsync\<TChildState\>\(Cat\.FluentWorkflows\.Abstractions\.ICatStepProcessor, Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TChildState\>, TChildState, bool, System\.Threading\.CancellationToken\)\.resuming') set, the run goes on at the step that suspended inside this container\.
Set it only for the first pass of a loop\.

```csharp
protected System.Threading.Tasks.Task<Cat.FluentWorkflows.Abstractions.ICatWorkflowResponse> RunChildStepsAsync<TChildState>(Cat.FluentWorkflows.Abstractions.ICatStepProcessor stepProcessor, Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder<TChildState> builder, TChildState state, bool resuming, System.Threading.CancellationToken cancellationToken)
    where TChildState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TChildState>;
```
#### Type parameters

<a name='Cat.FluentWorkflows.CatContainerStepBody_TWorkflowState_.RunChildStepsAsync_TChildState_(Cat.FluentWorkflows.Abstractions.ICatStepProcessor,Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TChildState_,TChildState,bool,System.Threading.CancellationToken).TChildState'></a>

`TChildState`

The state of the inner steps\.
#### Parameters

<a name='Cat.FluentWorkflows.CatContainerStepBody_TWorkflowState_.RunChildStepsAsync_TChildState_(Cat.FluentWorkflows.Abstractions.ICatStepProcessor,Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TChildState_,TChildState,bool,System.Threading.CancellationToken).stepProcessor'></a>

`stepProcessor` [ICatStepProcessor](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatStepProcessor.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepProcessor')

Runs the inner steps\.

<a name='Cat.FluentWorkflows.CatContainerStepBody_TWorkflowState_.RunChildStepsAsync_TChildState_(Cat.FluentWorkflows.Abstractions.ICatStepProcessor,Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TChildState_,TChildState,bool,System.Threading.CancellationToken).builder'></a>

`builder` [Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder&lt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')[TChildState](CatContainerStepBody_TWorkflowState_.RunChildStepsAsync.FHZ9TLOGUNDVTM092VJR0IW68.md#Cat.FluentWorkflows.CatContainerStepBody_TWorkflowState_.RunChildStepsAsync_TChildState_(Cat.FluentWorkflows.Abstractions.ICatStepProcessor,Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TChildState_,TChildState,bool,System.Threading.CancellationToken).TChildState 'Cat\.FluentWorkflows\.CatContainerStepBody\<TWorkflowState\>\.RunChildStepsAsync\<TChildState\>\(Cat\.FluentWorkflows\.Abstractions\.ICatStepProcessor, Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TChildState\>, TChildState, bool, System\.Threading\.CancellationToken\)\.TChildState')[&gt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')

Holds the inner steps\.

<a name='Cat.FluentWorkflows.CatContainerStepBody_TWorkflowState_.RunChildStepsAsync_TChildState_(Cat.FluentWorkflows.Abstractions.ICatStepProcessor,Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TChildState_,TChildState,bool,System.Threading.CancellationToken).state'></a>

`state` [TChildState](CatContainerStepBody_TWorkflowState_.RunChildStepsAsync.FHZ9TLOGUNDVTM092VJR0IW68.md#Cat.FluentWorkflows.CatContainerStepBody_TWorkflowState_.RunChildStepsAsync_TChildState_(Cat.FluentWorkflows.Abstractions.ICatStepProcessor,Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TChildState_,TChildState,bool,System.Threading.CancellationToken).TChildState 'Cat\.FluentWorkflows\.CatContainerStepBody\<TWorkflowState\>\.RunChildStepsAsync\<TChildState\>\(Cat\.FluentWorkflows\.Abstractions\.ICatStepProcessor, Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TChildState\>, TChildState, bool, System\.Threading\.CancellationToken\)\.TChildState')

The state the inner steps work on\.

<a name='Cat.FluentWorkflows.CatContainerStepBody_TWorkflowState_.RunChildStepsAsync_TChildState_(Cat.FluentWorkflows.Abstractions.ICatStepProcessor,Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TChildState_,TChildState,bool,System.Threading.CancellationToken).resuming'></a>

`resuming` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

`true` to go on at the saved step, `false` to run from the first step\.

<a name='Cat.FluentWorkflows.CatContainerStepBody_TWorkflowState_.RunChildStepsAsync_TChildState_(Cat.FluentWorkflows.Abstractions.ICatStepProcessor,Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TChildState_,TChildState,bool,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Token to cancel the work\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[ICatWorkflowResponse](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowResponse.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowResponse')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The result of the inner steps\.