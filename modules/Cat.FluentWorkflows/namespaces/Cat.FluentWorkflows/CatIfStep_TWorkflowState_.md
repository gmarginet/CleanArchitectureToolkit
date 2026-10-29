<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows\.Steps](Cat.FluentWorkflows.Steps.md 'Cat\.FluentWorkflows\.Steps')

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

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [CatStepBodyAsync](CatStepBodyAsync.md 'Cat\.FluentWorkflows\.CatStepBodyAsync') &#129106; [Cat\.FluentWorkflows\.CatStepBodyAsync&lt;](CatStepBodyAsync_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\<TWorkflowState\>')[TWorkflowState](CatIfStep_TWorkflowState_.md#Cat.FluentWorkflows.Steps.CatIfStep_TWorkflowState_.TWorkflowState 'Cat\.FluentWorkflows\.Steps\.CatIfStep\<TWorkflowState\>\.TWorkflowState')[&gt;](CatStepBodyAsync_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\<TWorkflowState\>') &#129106; CatIfStep\<TWorkflowState\>

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
