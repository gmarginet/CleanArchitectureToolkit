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

## CatForeachStep\<TWorkflowState,TCollection,TForeachState\> Class

Built\-in step behind `Foreach`\. It runs its inner steps once for every item of the collection,
on one shared foreach state\. A BreakFromLoop or BreakCascade stops the loop\. A BreakCascade also ends the workflow\.
The errors of every item are kept\.

```csharp
public class CatForeachStep<TWorkflowState,TCollection,TForeachState> : Cat.FluentWorkflows.CatStepBodyAsync<TWorkflowState>
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>
    where TForeachState : class, Cat.FluentWorkflows.Abstractions.ICatForeachState<TCollection, TWorkflowState>, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TForeachState>
```
#### Type parameters

<a name='Cat.FluentWorkflows.Steps.CatForeachStep_TWorkflowState,TCollection,TForeachState_.TWorkflowState'></a>

`TWorkflowState`

The state of the workflow around the loop\.

<a name='Cat.FluentWorkflows.Steps.CatForeachStep_TWorkflowState,TCollection,TForeachState_.TCollection'></a>

`TCollection`

The type of the items\.

<a name='Cat.FluentWorkflows.Steps.CatForeachStep_TWorkflowState,TCollection,TForeachState_.TForeachState'></a>

`TForeachState`

The state of the inner steps\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [CatStepBodyAsync](CatStepBodyAsync.md 'Cat\.FluentWorkflows\.CatStepBodyAsync') → [Cat\.FluentWorkflows\.CatStepBodyAsync&lt;](CatStepBodyAsync_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\<TWorkflowState\>')[TWorkflowState](CatForeachStep_TWorkflowState,TCollection,TForeachState_.md#Cat.FluentWorkflows.Steps.CatForeachStep_TWorkflowState,TCollection,TForeachState_.TWorkflowState 'Cat\.FluentWorkflows\.Steps\.CatForeachStep\<TWorkflowState,TCollection,TForeachState\>\.TWorkflowState')[&gt;](CatStepBodyAsync_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\<TWorkflowState\>') → CatForeachStep\<TWorkflowState,TCollection,TForeachState\>

| Constructors | |
| :--- | :--- |
| [CatForeachStep\(ICatStepProcessor, ILogger&lt;CatForeachStep&lt;TWorkflowState,TCollection,TForeachState&gt;&gt;\)](CatForeachStep_TWorkflowState,TCollection,TForeachState_..ctor.KLQRZ6FDFQ4C3Q4DA7NRYIXO3.md 'Cat\.FluentWorkflows\.Steps\.CatForeachStep\<TWorkflowState,TCollection,TForeachState\>\.CatForeachStep\(Cat\.FluentWorkflows\.Abstractions\.ICatStepProcessor, Microsoft\.Extensions\.Logging\.ILogger\<Cat\.FluentWorkflows\.Steps\.CatForeachStep\<TWorkflowState,TCollection,TForeachState\>\>\)') | Creates the step\. |

| Fields | |
| :--- | :--- |
| [\_catStepProcessor](CatForeachStep_TWorkflowState,TCollection,TForeachState_._catStepProcessor.md 'Cat\.FluentWorkflows\.Steps\.CatForeachStep\<TWorkflowState,TCollection,TForeachState\>\.\_catStepProcessor') | |
| [\_logger](CatForeachStep_TWorkflowState,TCollection,TForeachState_._logger.md 'Cat\.FluentWorkflows\.Steps\.CatForeachStep\<TWorkflowState,TCollection,TForeachState\>\.\_logger') | |

| Properties | |
| :--- | :--- |
| [Builder](CatForeachStep_TWorkflowState,TCollection,TForeachState_.Builder.md 'Cat\.FluentWorkflows\.Steps\.CatForeachStep\<TWorkflowState,TCollection,TForeachState\>\.Builder') | Holds the inner steps\. |
| [Collection](CatForeachStep_TWorkflowState,TCollection,TForeachState_.Collection.md 'Cat\.FluentWorkflows\.Steps\.CatForeachStep\<TWorkflowState,TCollection,TForeachState\>\.Collection') | Gets the collection from the workflow state\. |

| Methods | |
| :--- | :--- |
| [CreateForeachState\(\)](CatForeachStep_TWorkflowState,TCollection,TForeachState_.CreateForeachState().md 'Cat\.FluentWorkflows\.Steps\.CatForeachStep\<TWorkflowState,TCollection,TForeachState\>\.CreateForeachState\(\)') | Creates the state of the loop\. When the state type is an interface, as in the simple foreach, the default state class is used\. |
| [RunAsync\(CancellationToken\)](CatForeachStep_TWorkflowState,TCollection,TForeachState_.RunAsync.TQJ3RBM6DZCUDEKLQ6ACI13ZD.md 'Cat\.FluentWorkflows\.Steps\.CatForeachStep\<TWorkflowState,TCollection,TForeachState\>\.RunAsync\(System\.Threading\.CancellationToken\)') | Runs the step\. |
