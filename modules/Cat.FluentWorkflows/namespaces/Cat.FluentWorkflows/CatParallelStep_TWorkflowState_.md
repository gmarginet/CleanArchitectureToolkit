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
  
##### >> [Cat\.FluentWorkflows Assembly](index.md 'index') >> [Cat\.FluentWorkflows\.Steps Namespace](Cat.FluentWorkflows.Steps.md 'Cat\.FluentWorkflows\.Steps')

## CatParallelStep\<TWorkflowState\> Class

Built\-in step behind `Parallel`\. It runs several branches on the same workflow state\.
The code steps of the branches run one after another, in the order the branches were added\. Only the waiting is parallel:
a branch that suspends waits while the other branches run\. [Rule](CatParallelStep_TWorkflowState_.Rule.md 'Cat\.FluentWorkflows\.Steps\.CatParallelStep\<TWorkflowState\>\.Rule') says what a failure or a suspend does\.
Two branches must not write the same property of the state\.

```csharp
public class CatParallelStep<TWorkflowState> : Cat.FluentWorkflows.CatContainerStepBody<TWorkflowState>
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>
```
#### Type parameters

<a name='Cat.FluentWorkflows.Steps.CatParallelStep_TWorkflowState_.TWorkflowState'></a>

`TWorkflowState`

The state of the workflow\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [CatStepBodyAsync](CatStepBodyAsync.md 'Cat\.FluentWorkflows\.CatStepBodyAsync') → [Cat\.FluentWorkflows\.CatStepBodyAsync&lt;](CatStepBodyAsync_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\<TWorkflowState\>')[TWorkflowState](CatParallelStep_TWorkflowState_.md#Cat.FluentWorkflows.Steps.CatParallelStep_TWorkflowState_.TWorkflowState 'Cat\.FluentWorkflows\.Steps\.CatParallelStep\<TWorkflowState\>\.TWorkflowState')[&gt;](CatStepBodyAsync_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\<TWorkflowState\>') → [Cat\.FluentWorkflows\.CatContainerStepBody&lt;](CatContainerStepBody_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatContainerStepBody\<TWorkflowState\>')[TWorkflowState](CatParallelStep_TWorkflowState_.md#Cat.FluentWorkflows.Steps.CatParallelStep_TWorkflowState_.TWorkflowState 'Cat\.FluentWorkflows\.Steps\.CatParallelStep\<TWorkflowState\>\.TWorkflowState')[&gt;](CatContainerStepBody_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatContainerStepBody\<TWorkflowState\>') → CatParallelStep\<TWorkflowState\>

| Constructors | |
| :--- | :--- |
| [CatParallelStep\(ICatStepProcessor, ILogger&lt;CatParallelStep&lt;TWorkflowState&gt;&gt;\)](CatParallelStep_TWorkflowState_..ctor.0LR79C2SV1B1KH6KA8E9W53DB.md 'Cat\.FluentWorkflows\.Steps\.CatParallelStep\<TWorkflowState\>\.CatParallelStep\(Cat\.FluentWorkflows\.Abstractions\.ICatStepProcessor, Microsoft\.Extensions\.Logging\.ILogger\<Cat\.FluentWorkflows\.Steps\.CatParallelStep\<TWorkflowState\>\>\)') | Creates the step\. |

| Fields | |
| :--- | :--- |
| [\_catStepProcessor](CatParallelStep_TWorkflowState_._catStepProcessor.md 'Cat\.FluentWorkflows\.Steps\.CatParallelStep\<TWorkflowState\>\.\_catStepProcessor') | |

| Properties | |
| :--- | :--- |
| [Branches](CatParallelStep_TWorkflowState_.Branches.md 'Cat\.FluentWorkflows\.Steps\.CatParallelStep\<TWorkflowState\>\.Branches') | Holds the steps of each branch\. |
| [Rule](CatParallelStep_TWorkflowState_.Rule.md 'Cat\.FluentWorkflows\.Steps\.CatParallelStep\<TWorkflowState\>\.Rule') | What a failing or suspending branch does to the other branches\. |

| Methods | |
| :--- | :--- |
| [RunAsync\(CancellationToken\)](CatParallelStep_TWorkflowState_.RunAsync.EGM17IFJ9K37QRS94YNL7RQI8.md 'Cat\.FluentWorkflows\.Steps\.CatParallelStep\<TWorkflowState\>\.RunAsync\(System\.Threading\.CancellationToken\)') | Runs the step\. |
| [Suspended\(List&lt;CatParallelBranchFrame&gt;, List&lt;ICatError&gt;\)](CatParallelStep_TWorkflowState_.Suspended.GTJJYSL2WYW2D0OH9UW3SANB6.md 'Cat\.FluentWorkflows\.Steps\.CatParallelStep\<TWorkflowState\>\.Suspended\(System\.Collections\.Generic\.List\<Cat\.FluentWorkflows\.Abstractions\.CatParallelBranchFrame\>, System\.Collections\.Generic\.List\<Cat\.Responses\.Abstractions\.ICatError\>\)') | |
