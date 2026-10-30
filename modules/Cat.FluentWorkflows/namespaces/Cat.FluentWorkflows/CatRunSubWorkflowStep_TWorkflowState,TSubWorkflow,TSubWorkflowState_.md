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
  
##### >> [Cat\.FluentWorkflows Assembly](index.md 'index') >> [Cat\.FluentWorkflows\.Steps Namespace](Cat.FluentWorkflows.Steps.md 'Cat\.FluentWorkflows\.Steps')

## CatRunSubWorkflowStep\<TWorkflowState,TSubWorkflow,TSubWorkflowState\> Class

Built\-in step behind `Run<TSubWorkflow, TSubWorkflowState, TWorkflowState>`\.
It runs another workflow on the sub\-workflow state that the main state carries\.
A BreakFromCurrentFlowOnly inside the sub\-workflow ends only the sub\-workflow\.

```csharp
public class CatRunSubWorkflowStep<TWorkflowState,TSubWorkflow,TSubWorkflowState> : Cat.FluentWorkflows.CatStepBodyAsync<TWorkflowState>
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>, Cat.FluentWorkflows.Abstractions.ICatHasSubWorkflowState<TSubWorkflowState>
    where TSubWorkflow : Cat.FluentWorkflows.Abstractions.ICatWorkflow<TSubWorkflowState>
    where TSubWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TSubWorkflowState>
```
#### Type parameters

<a name='Cat.FluentWorkflows.Steps.CatRunSubWorkflowStep_TWorkflowState,TSubWorkflow,TSubWorkflowState_.TWorkflowState'></a>

`TWorkflowState`

The state of the main workflow\.

<a name='Cat.FluentWorkflows.Steps.CatRunSubWorkflowStep_TWorkflowState,TSubWorkflow,TSubWorkflowState_.TSubWorkflow'></a>

`TSubWorkflow`

The workflow to run\.

<a name='Cat.FluentWorkflows.Steps.CatRunSubWorkflowStep_TWorkflowState,TSubWorkflow,TSubWorkflowState_.TSubWorkflowState'></a>

`TSubWorkflowState`

The state of the sub\-workflow\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [CatStepBodyAsync](CatStepBodyAsync.md 'Cat\.FluentWorkflows\.CatStepBodyAsync') → [Cat\.FluentWorkflows\.CatStepBodyAsync&lt;](CatStepBodyAsync_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\<TWorkflowState\>')[TWorkflowState](CatRunSubWorkflowStep_TWorkflowState,TSubWorkflow,TSubWorkflowState_.md#Cat.FluentWorkflows.Steps.CatRunSubWorkflowStep_TWorkflowState,TSubWorkflow,TSubWorkflowState_.TWorkflowState 'Cat\.FluentWorkflows\.Steps\.CatRunSubWorkflowStep\<TWorkflowState,TSubWorkflow,TSubWorkflowState\>\.TWorkflowState')[&gt;](CatStepBodyAsync_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\<TWorkflowState\>') → CatRunSubWorkflowStep\<TWorkflowState,TSubWorkflow,TSubWorkflowState\>

| Constructors | |
| :--- | :--- |
| [CatRunSubWorkflowStep\(ICatWorkflowProcessor, ILogger&lt;CatRunSubWorkflowStep&lt;TWorkflowState,TSubWorkflow,TSubWorkflowState&gt;&gt;\)](CatRunSubWorkflowStep_TWorkflowState,TSubWorkflow,TSubWorkflowState_..ctor.6KO9UD9XS3QDPECNTP029I8K1.md 'Cat\.FluentWorkflows\.Steps\.CatRunSubWorkflowStep\<TWorkflowState,TSubWorkflow,TSubWorkflowState\>\.CatRunSubWorkflowStep\(Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowProcessor, Microsoft\.Extensions\.Logging\.ILogger\<Cat\.FluentWorkflows\.Steps\.CatRunSubWorkflowStep\<TWorkflowState,TSubWorkflow,TSubWorkflowState\>\>\)') | Creates the step\. |

| Fields | |
| :--- | :--- |
| [\_workflowProcessor](CatRunSubWorkflowStep_TWorkflowState,TSubWorkflow,TSubWorkflowState_._workflowProcessor.md 'Cat\.FluentWorkflows\.Steps\.CatRunSubWorkflowStep\<TWorkflowState,TSubWorkflow,TSubWorkflowState\>\.\_workflowProcessor') | |

| Methods | |
| :--- | :--- |
| [RunAsync\(CancellationToken\)](CatRunSubWorkflowStep_TWorkflowState,TSubWorkflow,TSubWorkflowState_.RunAsync.E88WLD091MQGUXQIOLW9Z9JV3.md 'Cat\.FluentWorkflows\.Steps\.CatRunSubWorkflowStep\<TWorkflowState,TSubWorkflow,TSubWorkflowState\>\.RunAsync\(System\.Threading\.CancellationToken\)') | Runs the step\. |
