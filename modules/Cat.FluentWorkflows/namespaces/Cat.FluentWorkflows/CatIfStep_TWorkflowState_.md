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

## CatIfStep\<TWorkflowState\> Class

Built\-in step behind `If`\. It runs the then steps when the condition is `true`, otherwise the else steps, if there are any\.
A break result from the inner steps goes on to the steps around the if\.

```csharp
public class CatIfStep<TWorkflowState> : Cat.FluentWorkflows.CatStepBodyAsync<TWorkflowState>
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>
```
#### Type parameters

<a name='Cat.FluentWorkflows.Steps.CatIfStep_TWorkflowState_.TWorkflowState'></a>

`TWorkflowState`

The state of the workflow\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [CatStepBodyAsync](CatStepBodyAsync.md 'Cat\.FluentWorkflows\.CatStepBodyAsync') → [Cat\.FluentWorkflows\.CatStepBodyAsync&lt;](CatStepBodyAsync_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\<TWorkflowState\>')[TWorkflowState](CatIfStep_TWorkflowState_.md#Cat.FluentWorkflows.Steps.CatIfStep_TWorkflowState_.TWorkflowState 'Cat\.FluentWorkflows\.Steps\.CatIfStep\<TWorkflowState\>\.TWorkflowState')[&gt;](CatStepBodyAsync_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\<TWorkflowState\>') → CatIfStep\<TWorkflowState\>

| Constructors | |
| :--- | :--- |
| [CatIfStep\(ICatStepProcessor, ILogger&lt;CatIfStep&lt;TWorkflowState&gt;&gt;\)](CatIfStep_TWorkflowState_..ctor.4IVLXXEPR2ZI7MG3HNSW4M679.md 'Cat\.FluentWorkflows\.Steps\.CatIfStep\<TWorkflowState\>\.CatIfStep\(Cat\.FluentWorkflows\.Abstractions\.ICatStepProcessor, Microsoft\.Extensions\.Logging\.ILogger\<Cat\.FluentWorkflows\.Steps\.CatIfStep\<TWorkflowState\>\>\)') | Creates the step\. |

| Fields | |
| :--- | :--- |
| [\_catStepProcessor](CatIfStep_TWorkflowState_._catStepProcessor.md 'Cat\.FluentWorkflows\.Steps\.CatIfStep\<TWorkflowState\>\.\_catStepProcessor') | |

| Properties | |
| :--- | :--- |
| [Condition](CatIfStep_TWorkflowState_.Condition.md 'Cat\.FluentWorkflows\.Steps\.CatIfStep\<TWorkflowState\>\.Condition') | The condition\. It gets the workflow state\. |
| [ElseBuilder](CatIfStep_TWorkflowState_.ElseBuilder.md 'Cat\.FluentWorkflows\.Steps\.CatIfStep\<TWorkflowState\>\.ElseBuilder') | Holds the steps to run when the condition is `false`, or `null` for none\. |
| [ThenBuilder](CatIfStep_TWorkflowState_.ThenBuilder.md 'Cat\.FluentWorkflows\.Steps\.CatIfStep\<TWorkflowState\>\.ThenBuilder') | Holds the steps to run when the condition is `true`\. |

| Methods | |
| :--- | :--- |
| [RunAsync\(CancellationToken\)](CatIfStep_TWorkflowState_.RunAsync.1TCVJ6QPBYVGDV8A7SWB77TAC.md 'Cat\.FluentWorkflows\.Steps\.CatIfStep\<TWorkflowState\>\.RunAsync\(System\.Threading\.CancellationToken\)') | Runs the step\. |
