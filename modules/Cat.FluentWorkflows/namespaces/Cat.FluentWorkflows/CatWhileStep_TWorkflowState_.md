<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows\.Steps](Cat.FluentWorkflows.Steps.md 'Cat\.FluentWorkflows\.Steps')

## CatWhileStep\<TWorkflowState\> Class

Built\-in step behind `While`\. It repeats its inner steps while the condition is `true`\.
A BreakFromLoop leaves the loop and continues\. A BreakCascade leaves the loop and ends the workflow\.
The errors of every pass are kept\.

```csharp
public class CatWhileStep<TWorkflowState> : Cat.FluentWorkflows.CatStepBodyAsync<TWorkflowState>
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>
```
#### Type parameters

<a name='Cat.FluentWorkflows.Steps.CatWhileStep_TWorkflowState_.TWorkflowState'></a>

`TWorkflowState`

The state of the workflow\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [CatStepBodyAsync](CatStepBodyAsync.md 'Cat\.FluentWorkflows\.CatStepBodyAsync') → [Cat\.FluentWorkflows\.CatStepBodyAsync&lt;](CatStepBodyAsync_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\<TWorkflowState\>')[TWorkflowState](CatWhileStep_TWorkflowState_.md#Cat.FluentWorkflows.Steps.CatWhileStep_TWorkflowState_.TWorkflowState 'Cat\.FluentWorkflows\.Steps\.CatWhileStep\<TWorkflowState\>\.TWorkflowState')[&gt;](CatStepBodyAsync_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\<TWorkflowState\>') → CatWhileStep\<TWorkflowState\>

| Constructors | |
| :--- | :--- |
| [CatWhileStep\(ICatStepProcessor, ILogger&lt;CatWhileStep&lt;TWorkflowState&gt;&gt;\)](CatWhileStep_TWorkflowState_..ctor.Z9NS6MBJGIL3P0HR678J3RGY5.md 'Cat\.FluentWorkflows\.Steps\.CatWhileStep\<TWorkflowState\>\.CatWhileStep\(Cat\.FluentWorkflows\.Abstractions\.ICatStepProcessor, Microsoft\.Extensions\.Logging\.ILogger\<Cat\.FluentWorkflows\.Steps\.CatWhileStep\<TWorkflowState\>\>\)') | Creates the step\. |

| Fields | |
| :--- | :--- |
| [\_catStepProcessor](CatWhileStep_TWorkflowState_._catStepProcessor.md 'Cat\.FluentWorkflows\.Steps\.CatWhileStep\<TWorkflowState\>\.\_catStepProcessor') | |

| Properties | |
| :--- | :--- |
| [Builder](CatWhileStep_TWorkflowState_.Builder.md 'Cat\.FluentWorkflows\.Steps\.CatWhileStep\<TWorkflowState\>\.Builder') | Holds the inner steps\. |
| [Condition](CatWhileStep_TWorkflowState_.Condition.md 'Cat\.FluentWorkflows\.Steps\.CatWhileStep\<TWorkflowState\>\.Condition') | The condition\. It gets the workflow state and is checked before every pass\. |

| Methods | |
| :--- | :--- |
| [RunAsync\(CancellationToken\)](CatWhileStep_TWorkflowState_.RunAsync.FJA91O423CF7P9FS32HSMEH85.md 'Cat\.FluentWorkflows\.Steps\.CatWhileStep\<TWorkflowState\>\.RunAsync\(System\.Threading\.CancellationToken\)') | Runs the step\. |
