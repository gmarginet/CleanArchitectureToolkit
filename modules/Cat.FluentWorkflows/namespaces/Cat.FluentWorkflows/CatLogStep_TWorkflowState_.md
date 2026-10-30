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

## CatLogStep\<TWorkflowState\> Class

Built\-in step behind `Log` and the level specific log methods\. It writes one log entry and continues\.

```csharp
public class CatLogStep<TWorkflowState> : Cat.FluentWorkflows.CatStepBody<TWorkflowState>
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>
```
#### Type parameters

<a name='Cat.FluentWorkflows.Steps.CatLogStep_TWorkflowState_.TWorkflowState'></a>

`TWorkflowState`

The state of the workflow\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [CatStepBodyAsync](CatStepBodyAsync.md 'Cat\.FluentWorkflows\.CatStepBodyAsync') → [Cat\.FluentWorkflows\.CatStepBodyAsync&lt;](CatStepBodyAsync_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\<TWorkflowState\>')[TWorkflowState](CatLogStep_TWorkflowState_.md#Cat.FluentWorkflows.Steps.CatLogStep_TWorkflowState_.TWorkflowState 'Cat\.FluentWorkflows\.Steps\.CatLogStep\<TWorkflowState\>\.TWorkflowState')[&gt;](CatStepBodyAsync_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\<TWorkflowState\>') → [Cat\.FluentWorkflows\.CatStepBody&lt;](CatStepBody_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBody\<TWorkflowState\>')[TWorkflowState](CatLogStep_TWorkflowState_.md#Cat.FluentWorkflows.Steps.CatLogStep_TWorkflowState_.TWorkflowState 'Cat\.FluentWorkflows\.Steps\.CatLogStep\<TWorkflowState\>\.TWorkflowState')[&gt;](CatStepBody_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBody\<TWorkflowState\>') → CatLogStep\<TWorkflowState\>

| Constructors | |
| :--- | :--- |
| [CatLogStep\(ILogger&lt;CatLogStep&lt;TWorkflowState&gt;&gt;\)](CatLogStep_TWorkflowState_..ctor.DZ07RN8R4J1FUKMF978V35CVA.md 'Cat\.FluentWorkflows\.Steps\.CatLogStep\<TWorkflowState\>\.CatLogStep\(Microsoft\.Extensions\.Logging\.ILogger\<Cat\.FluentWorkflows\.Steps\.CatLogStep\<TWorkflowState\>\>\)') | Creates the step\. |

| Properties | |
| :--- | :--- |
| [GetArgs](CatLogStep_TWorkflowState_.GetArgs.md 'Cat\.FluentWorkflows\.Steps\.CatLogStep\<TWorkflowState\>\.GetArgs') | Gets the values for the placeholders from the workflow state\. |
| [LogLevel](CatLogStep_TWorkflowState_.LogLevel.md 'Cat\.FluentWorkflows\.Steps\.CatLogStep\<TWorkflowState\>\.LogLevel') | The level to log at\. |
| [Message](CatLogStep_TWorkflowState_.Message.md 'Cat\.FluentWorkflows\.Steps\.CatLogStep\<TWorkflowState\>\.Message') | The message template\. |

| Methods | |
| :--- | :--- |
| [Run\(\)](CatLogStep_TWorkflowState_.Run().md 'Cat\.FluentWorkflows\.Steps\.CatLogStep\<TWorkflowState\>\.Run\(\)') | Does the work of the step\. |
