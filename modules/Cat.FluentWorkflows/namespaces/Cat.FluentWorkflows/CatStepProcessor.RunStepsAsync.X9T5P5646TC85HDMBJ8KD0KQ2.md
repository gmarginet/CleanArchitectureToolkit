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
  
##### >> [Cat\.FluentWorkflows Assembly](index.md 'index') >> [Cat\.FluentWorkflows Namespace](Cat.FluentWorkflows.md 'Cat\.FluentWorkflows') >> [CatStepProcessor Class](CatStepProcessor.md 'Cat\.FluentWorkflows\.CatStepProcessor')

## CatStepProcessor\.RunStepsAsync\<TWorkflowState\>\(ICatWorkflowBuilder\<TWorkflowState\>, TWorkflowState, CancellationToken\) Method

Runs the steps of a builder in order\. It stops after a step that returns a break result\.

```csharp
public System.Threading.Tasks.Task<Cat.FluentWorkflows.Abstractions.ICatWorkflowResponse> RunStepsAsync<TWorkflowState>(Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder<TWorkflowState> workflowBuilder, TWorkflowState workflowState, System.Threading.CancellationToken cancellationToken)
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>;
```
#### Type parameters

<a name='Cat.FluentWorkflows.CatStepProcessor.RunStepsAsync_TWorkflowState_(Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,TWorkflowState,System.Threading.CancellationToken).TWorkflowState'></a>

`TWorkflowState`

The state of the workflow\.
#### Parameters

<a name='Cat.FluentWorkflows.CatStepProcessor.RunStepsAsync_TWorkflowState_(Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,TWorkflowState,System.Threading.CancellationToken).workflowBuilder'></a>

`workflowBuilder` [Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder&lt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')[TWorkflowState](CatStepProcessor.RunStepsAsync.X9T5P5646TC85HDMBJ8KD0KQ2.md#Cat.FluentWorkflows.CatStepProcessor.RunStepsAsync_TWorkflowState_(Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,TWorkflowState,System.Threading.CancellationToken).TWorkflowState 'Cat\.FluentWorkflows\.CatStepProcessor\.RunStepsAsync\<TWorkflowState\>\(Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, TWorkflowState, System\.Threading\.CancellationToken\)\.TWorkflowState')[&gt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')

Holds the steps\.

<a name='Cat.FluentWorkflows.CatStepProcessor.RunStepsAsync_TWorkflowState_(Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,TWorkflowState,System.Threading.CancellationToken).workflowState'></a>

`workflowState` [TWorkflowState](CatStepProcessor.RunStepsAsync.X9T5P5646TC85HDMBJ8KD0KQ2.md#Cat.FluentWorkflows.CatStepProcessor.RunStepsAsync_TWorkflowState_(Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,TWorkflowState,System.Threading.CancellationToken).TWorkflowState 'Cat\.FluentWorkflows\.CatStepProcessor\.RunStepsAsync\<TWorkflowState\>\(Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, TWorkflowState, System\.Threading\.CancellationToken\)\.TWorkflowState')

The state the steps work on\.

<a name='Cat.FluentWorkflows.CatStepProcessor.RunStepsAsync_TWorkflowState_(Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,TWorkflowState,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Token to cancel the work\.

Implements [RunStepsAsync&lt;TWorkflowState&gt;\(ICatWorkflowBuilder&lt;TWorkflowState&gt;, TWorkflowState, CancellationToken\)](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatStepProcessor.RunStepsAsync.5L6M6S533ILIRH2SAWC31DG37.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepProcessor\.RunStepsAsync\`\`1\(Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\{\`\`0\},\`\`0,System\.Threading\.CancellationToken\)')

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[ICatWorkflowResponse](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowResponse.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowResponse')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The result of the last step that ran, with the errors of every step that ran\.