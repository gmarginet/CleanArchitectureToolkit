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
  
##### >> [Cat\.FluentWorkflows Assembly](index.md 'index') >> [Cat\.FluentWorkflows Namespace](Cat.FluentWorkflows.md 'Cat\.FluentWorkflows')

## CatStepBody\<TWorkflowState\> Class

Base class for a step that works synchronously and reads or writes the workflow state directly\.
Implement [Run\(\)](CatStepBody_TWorkflowState_.Run().md 'Cat\.FluentWorkflows\.CatStepBody\<TWorkflowState\>\.Run\(\)') and use [WorkflowState](CatStepBodyAsync_TWorkflowState_.WorkflowState.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\<TWorkflowState\>\.WorkflowState')\.

```csharp
public abstract class CatStepBody<TWorkflowState> : Cat.FluentWorkflows.CatStepBodyAsync<TWorkflowState>
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>
```
#### Type parameters

<a name='Cat.FluentWorkflows.CatStepBody_TWorkflowState_.TWorkflowState'></a>

`TWorkflowState`

The state of the workflow\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [CatStepBodyAsync](CatStepBodyAsync.md 'Cat\.FluentWorkflows\.CatStepBodyAsync') → [Cat\.FluentWorkflows\.CatStepBodyAsync&lt;](CatStepBodyAsync_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\<TWorkflowState\>')[TWorkflowState](CatStepBody_TWorkflowState_.md#Cat.FluentWorkflows.CatStepBody_TWorkflowState_.TWorkflowState 'Cat\.FluentWorkflows\.CatStepBody\<TWorkflowState\>\.TWorkflowState')[&gt;](CatStepBodyAsync_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\<TWorkflowState\>') → CatStepBody\<TWorkflowState\>

Derived  
↳ [CatBreakIfStep&lt;TWorkflowState&gt;](CatBreakIfStep_TWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatBreakIfStep\<TWorkflowState\>')  
↳ [CatInlineActionStep&lt;TWorkflowState&gt;](CatInlineActionStep_TWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatInlineActionStep\<TWorkflowState\>')  
↳ [CatInlineFuncStep&lt;TWorkflowState&gt;](CatInlineFuncStep_TWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatInlineFuncStep\<TWorkflowState\>')  
↳ [CatLogStep&lt;TWorkflowState&gt;](CatLogStep_TWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatLogStep\<TWorkflowState\>')  
↳ [CatSetStatePropertyStep&lt;TWorkflowState,TProperty&gt;](CatSetStatePropertyStep_TWorkflowState,TProperty_.md 'Cat\.FluentWorkflows\.Steps\.CatSetStatePropertyStep\<TWorkflowState,TProperty\>')

| Constructors | |
| :--- | :--- |
| [CatStepBody\(ILogger&lt;CatStepBody&lt;TWorkflowState&gt;&gt;\)](CatStepBody_TWorkflowState_..ctor.KS4E5UVG79L14FGK9E1H2P6D4.md 'Cat\.FluentWorkflows\.CatStepBody\<TWorkflowState\>\.CatStepBody\(Microsoft\.Extensions\.Logging\.ILogger\<Cat\.FluentWorkflows\.CatStepBody\<TWorkflowState\>\>\)') | Creates the step\. |

| Methods | |
| :--- | :--- |
| [Run\(\)](CatStepBody_TWorkflowState_.Run().md 'Cat\.FluentWorkflows\.CatStepBody\<TWorkflowState\>\.Run\(\)') | Does the work of the step\. |
| [RunAsync\(CancellationToken\)](CatStepBody_TWorkflowState_.RunAsync.X3HHHAR6W9Y316VF0SSPL7NE2.md 'Cat\.FluentWorkflows\.CatStepBody\<TWorkflowState\>\.RunAsync\(System\.Threading\.CancellationToken\)') | Runs the step\. |
