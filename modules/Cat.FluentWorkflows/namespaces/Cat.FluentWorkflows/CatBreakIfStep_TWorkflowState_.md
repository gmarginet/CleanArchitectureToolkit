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
  
##### >> [Cat\.FluentWorkflows Assembly](index.md 'index') >> [Cat\.FluentWorkflows\.Steps Namespace](Cat.FluentWorkflows.Steps.md 'Cat\.FluentWorkflows\.Steps')

## CatBreakIfStep\<TWorkflowState\> Class

Built\-in step behind `BreakCascadeIf`, `BreakFromCurrentFlowOnlyIf` and `BreakFromLoopIf`\.
It runs the check\. When the check returns `true` it breaks the way [BreakType](CatBreakIfStep_TWorkflowState_.BreakType.md 'Cat\.FluentWorkflows\.Steps\.CatBreakIfStep\<TWorkflowState\>\.BreakType') says, otherwise it continues\.

```csharp
public class CatBreakIfStep<TWorkflowState> : Cat.FluentWorkflows.CatStepBody<TWorkflowState>
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>
```
#### Type parameters

<a name='Cat.FluentWorkflows.Steps.CatBreakIfStep_TWorkflowState_.TWorkflowState'></a>

`TWorkflowState`

The state of the workflow\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [CatStepBodyAsync](CatStepBodyAsync.md 'Cat\.FluentWorkflows\.CatStepBodyAsync') → [Cat\.FluentWorkflows\.CatStepBodyAsync&lt;](CatStepBodyAsync_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\<TWorkflowState\>')[TWorkflowState](CatBreakIfStep_TWorkflowState_.md#Cat.FluentWorkflows.Steps.CatBreakIfStep_TWorkflowState_.TWorkflowState 'Cat\.FluentWorkflows\.Steps\.CatBreakIfStep\<TWorkflowState\>\.TWorkflowState')[&gt;](CatStepBodyAsync_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\<TWorkflowState\>') → [Cat\.FluentWorkflows\.CatStepBody&lt;](CatStepBody_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBody\<TWorkflowState\>')[TWorkflowState](CatBreakIfStep_TWorkflowState_.md#Cat.FluentWorkflows.Steps.CatBreakIfStep_TWorkflowState_.TWorkflowState 'Cat\.FluentWorkflows\.Steps\.CatBreakIfStep\<TWorkflowState\>\.TWorkflowState')[&gt;](CatStepBody_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBody\<TWorkflowState\>') → CatBreakIfStep\<TWorkflowState\>

| Constructors | |
| :--- | :--- |
| [CatBreakIfStep\(ILogger&lt;CatBreakIfStep&lt;TWorkflowState&gt;&gt;\)](CatBreakIfStep_TWorkflowState_..ctor.8JLJHGUAOIRH5VRC895RM6UXE.md 'Cat\.FluentWorkflows\.Steps\.CatBreakIfStep\<TWorkflowState\>\.CatBreakIfStep\(Microsoft\.Extensions\.Logging\.ILogger\<Cat\.FluentWorkflows\.Steps\.CatBreakIfStep\<TWorkflowState\>\>\)') | Creates the step\. |

| Properties | |
| :--- | :--- |
| [BreakType](CatBreakIfStep_TWorkflowState_.BreakType.md 'Cat\.FluentWorkflows\.Steps\.CatBreakIfStep\<TWorkflowState\>\.BreakType') | The kind of break to make when the check returns `true`\. |
| [Check](CatBreakIfStep_TWorkflowState_.Check.md 'Cat\.FluentWorkflows\.Steps\.CatBreakIfStep\<TWorkflowState\>\.Check') | The check\. It gets the logger and the workflow state\. |

| Methods | |
| :--- | :--- |
| [Run\(\)](CatBreakIfStep_TWorkflowState_.Run().md 'Cat\.FluentWorkflows\.Steps\.CatBreakIfStep\<TWorkflowState\>\.Run\(\)') | Does the work of the step\. |
