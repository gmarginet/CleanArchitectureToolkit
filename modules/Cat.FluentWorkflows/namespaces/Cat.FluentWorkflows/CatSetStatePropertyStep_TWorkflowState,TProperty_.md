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

## CatSetStatePropertyStep\<TWorkflowState,TProperty\> Class

Built\-in step behind `Set`\. It calculates a value and writes it to a property of the workflow state\.

```csharp
public class CatSetStatePropertyStep<TWorkflowState,TProperty> : Cat.FluentWorkflows.CatStepBody<TWorkflowState>
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>
```
#### Type parameters

<a name='Cat.FluentWorkflows.Steps.CatSetStatePropertyStep_TWorkflowState,TProperty_.TWorkflowState'></a>

`TWorkflowState`

The state of the workflow\.

<a name='Cat.FluentWorkflows.Steps.CatSetStatePropertyStep_TWorkflowState,TProperty_.TProperty'></a>

`TProperty`

The type of the property\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [CatStepBodyAsync](CatStepBodyAsync.md 'Cat\.FluentWorkflows\.CatStepBodyAsync') → [Cat\.FluentWorkflows\.CatStepBodyAsync&lt;](CatStepBodyAsync_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\<TWorkflowState\>')[TWorkflowState](CatSetStatePropertyStep_TWorkflowState,TProperty_.md#Cat.FluentWorkflows.Steps.CatSetStatePropertyStep_TWorkflowState,TProperty_.TWorkflowState 'Cat\.FluentWorkflows\.Steps\.CatSetStatePropertyStep\<TWorkflowState,TProperty\>\.TWorkflowState')[&gt;](CatStepBodyAsync_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\<TWorkflowState\>') → [Cat\.FluentWorkflows\.CatStepBody&lt;](CatStepBody_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBody\<TWorkflowState\>')[TWorkflowState](CatSetStatePropertyStep_TWorkflowState,TProperty_.md#Cat.FluentWorkflows.Steps.CatSetStatePropertyStep_TWorkflowState,TProperty_.TWorkflowState 'Cat\.FluentWorkflows\.Steps\.CatSetStatePropertyStep\<TWorkflowState,TProperty\>\.TWorkflowState')[&gt;](CatStepBody_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBody\<TWorkflowState\>') → CatSetStatePropertyStep\<TWorkflowState,TProperty\>

| Constructors | |
| :--- | :--- |
| [CatSetStatePropertyStep\(ILogger&lt;CatSetStatePropertyStep&lt;TWorkflowState,TProperty&gt;&gt;\)](CatSetStatePropertyStep_TWorkflowState,TProperty_..ctor.ATPD02KEMTYYH6QNN4IZNJZP1.md 'Cat\.FluentWorkflows\.Steps\.CatSetStatePropertyStep\<TWorkflowState,TProperty\>\.CatSetStatePropertyStep\(Microsoft\.Extensions\.Logging\.ILogger\<Cat\.FluentWorkflows\.Steps\.CatSetStatePropertyStep\<TWorkflowState,TProperty\>\>\)') | Creates the step\. |

| Properties | |
| :--- | :--- |
| [GetPropertyValue](CatSetStatePropertyStep_TWorkflowState,TProperty_.GetPropertyValue.md 'Cat\.FluentWorkflows\.Steps\.CatSetStatePropertyStep\<TWorkflowState,TProperty\>\.GetPropertyValue') | Calculates the new value from the logger and the workflow state\. |
| [StateProperty](CatSetStatePropertyStep_TWorkflowState,TProperty_.StateProperty.md 'Cat\.FluentWorkflows\.Steps\.CatSetStatePropertyStep\<TWorkflowState,TProperty\>\.StateProperty') | Picks the property to write\. |

| Methods | |
| :--- | :--- |
| [Run\(\)](CatSetStatePropertyStep_TWorkflowState,TProperty_.Run().md 'Cat\.FluentWorkflows\.Steps\.CatSetStatePropertyStep\<TWorkflowState,TProperty\>\.Run\(\)') | Does the work of the step\. |
