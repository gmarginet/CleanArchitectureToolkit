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
  
##### >> [Cat\.FluentWorkflows Assembly](index.md 'index') >> [Cat\.FluentWorkflows Namespace](Cat.FluentWorkflows.md 'Cat\.FluentWorkflows')

## CatStepBodyAsync\<TWorkflowState\> Class

Base class for a step that works asynchronously and reads or writes the workflow state directly\.
Implement [RunAsync\(CancellationToken\)](CatStepBodyAsync.RunAsync.NDIRNNFATTDGG9GCGGAU4GQP1.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\.RunAsync\(System\.Threading\.CancellationToken\)') and use [WorkflowState](CatStepBodyAsync_TWorkflowState_.WorkflowState.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\<TWorkflowState\>\.WorkflowState')\.

```csharp
public abstract class CatStepBodyAsync<TWorkflowState> : Cat.FluentWorkflows.CatStepBodyAsync, Cat.FluentWorkflows.Abstractions.ICatStepBodyWithState<TWorkflowState>
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>
```
#### Type parameters

<a name='Cat.FluentWorkflows.CatStepBodyAsync_TWorkflowState_.TWorkflowState'></a>

`TWorkflowState`

The state of the workflow\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [CatStepBodyAsync](CatStepBodyAsync.md 'Cat\.FluentWorkflows\.CatStepBodyAsync') → CatStepBodyAsync\<TWorkflowState\>

Derived  
↳ [CatStepBody&lt;TWorkflowState&gt;](CatStepBody_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBody\<TWorkflowState\>')  
↳ [CatForeachStep&lt;TWorkflowState,TCollection,TForeachState&gt;](CatForeachStep_TWorkflowState,TCollection,TForeachState_.md 'Cat\.FluentWorkflows\.Steps\.CatForeachStep\<TWorkflowState,TCollection,TForeachState\>')  
↳ [CatIfStep&lt;TWorkflowState&gt;](CatIfStep_TWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatIfStep\<TWorkflowState\>')  
↳ [CatRunSubWorkflowStep&lt;TWorkflowState,TSubWorkflow,TSubWorkflowState&gt;](CatRunSubWorkflowStep_TWorkflowState,TSubWorkflow,TSubWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatRunSubWorkflowStep\<TWorkflowState,TSubWorkflow,TSubWorkflowState\>')  
↳ [CatSwitchStep&lt;TWorkflowState,TSwitchValue&gt;](CatSwitchStep_TWorkflowState,TSwitchValue_.md 'Cat\.FluentWorkflows\.Steps\.CatSwitchStep\<TWorkflowState,TSwitchValue\>')  
↳ [CatWhileStep&lt;TWorkflowState&gt;](CatWhileStep_TWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatWhileStep\<TWorkflowState\>')

Implements [Cat\.FluentWorkflows\.Abstractions\.ICatStepBodyWithState&lt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatStepBodyWithState_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBodyWithState\`1')[TWorkflowState](CatStepBodyAsync_TWorkflowState_.md#Cat.FluentWorkflows.CatStepBodyAsync_TWorkflowState_.TWorkflowState 'Cat\.FluentWorkflows\.CatStepBodyAsync\<TWorkflowState\>\.TWorkflowState')[&gt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatStepBodyWithState_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBodyWithState\`1')

| Constructors | |
| :--- | :--- |
| [CatStepBodyAsync\(ILogger\)](CatStepBodyAsync_TWorkflowState_..ctor.A6YX3OOBOLP1TIEMDUHCNWQCD.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\<TWorkflowState\>\.CatStepBodyAsync\(Microsoft\.Extensions\.Logging\.ILogger\)') | Creates the step\. |

| Properties | |
| :--- | :--- |
| [WorkflowState](CatStepBodyAsync_TWorkflowState_.WorkflowState.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\<TWorkflowState\>\.WorkflowState') | The state of the workflow the step runs in\. |
