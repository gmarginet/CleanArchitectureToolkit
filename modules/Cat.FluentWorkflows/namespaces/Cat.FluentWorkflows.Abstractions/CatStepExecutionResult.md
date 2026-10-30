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
  
##### >> [Cat\.FluentWorkflows\.Abstractions Assembly](index.md 'index') >> [Cat\.FluentWorkflows\.Abstractions Namespace](Cat.FluentWorkflows.Abstractions.md 'Cat\.FluentWorkflows\.Abstractions')

## CatStepExecutionResult Enum

Tells the step processor what to do after a step\. Every step returns one inside its workflow response\.

```csharp
public enum CatStepExecutionResult
```
### Fields

<a name='Cat.FluentWorkflows.Abstractions.CatStepExecutionResult.Continue'></a>

`Continue` 0

Go on with the next step\.

<a name='Cat.FluentWorkflows.Abstractions.CatStepExecutionResult.BreakCascade'></a>

`BreakCascade` 1

Stop the current list of steps and tell every level above to stop too\.
The workflow ends and returns this result\. Use it to end a workflow on a failure\.

<a name='Cat.FluentWorkflows.Abstractions.CatStepExecutionResult.BreakFromCurrentFlowOnly'></a>

`BreakFromCurrentFlowOnly` 2

Stop the current list of steps\. In a workflow it ends that workflow, and its caller goes on as if it succeeded\.
In a foreach it ends the current item only\.

<a name='Cat.FluentWorkflows.Abstractions.CatStepExecutionResult.BreakFromLoop'></a>

`BreakFromLoop` 3

Leave the nearest loop, a while or a foreach, and go on with the step after it\.

<a name='Cat.FluentWorkflows.Abstractions.CatStepExecutionResult.ContinueLoop'></a>

`ContinueLoop` 4

Reserved for loops\. The step processor does not stop on it, and no built\-in step returns it\.