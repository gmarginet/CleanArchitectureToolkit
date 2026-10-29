<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows\.Abstractions](index.md 'index') > [Cat\.FluentWorkflows\.Abstractions](Cat.FluentWorkflows.Abstractions.md 'Cat\.FluentWorkflows\.Abstractions')

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