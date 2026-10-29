<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows\.Abstractions](index.md 'index') > [Cat\.FluentWorkflows\.Abstractions](Cat.FluentWorkflows.Abstractions.md 'Cat\.FluentWorkflows\.Abstractions') > [ICatWorkflowProcessor](ICatWorkflowProcessor.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowProcessor')

## ICatWorkflowProcessor\.RunAsync\<TWorkflow,TWorkflowState\>\(TWorkflowState, CancellationToken\) Method

Builds the workflow, runs its steps on the given state and returns the outcome\.
A [BreakFromCurrentFlowOnly](CatStepExecutionResult.md#Cat.FluentWorkflows.Abstractions.CatStepExecutionResult.BreakFromCurrentFlowOnly 'Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\.BreakFromCurrentFlowOnly') result is reported as [Continue](CatStepExecutionResult.md#Cat.FluentWorkflows.Abstractions.CatStepExecutionResult.Continue 'Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\.Continue')\.

```csharp
System.Threading.Tasks.Task<Cat.FluentWorkflows.Abstractions.ICatWorkflowResponse> RunAsync<TWorkflow,TWorkflowState>(TWorkflowState workflowState, System.Threading.CancellationToken cancellationToken)
    where TWorkflow : Cat.FluentWorkflows.Abstractions.ICatWorkflow<TWorkflowState>
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>;
```
#### Type parameters

<a name='Cat.FluentWorkflows.Abstractions.ICatWorkflowProcessor.RunAsync_TWorkflow,TWorkflowState_(TWorkflowState,System.Threading.CancellationToken).TWorkflow'></a>

`TWorkflow`

The workflow to run\. It must be registered\.

<a name='Cat.FluentWorkflows.Abstractions.ICatWorkflowProcessor.RunAsync_TWorkflow,TWorkflowState_(TWorkflowState,System.Threading.CancellationToken).TWorkflowState'></a>

`TWorkflowState`

The state of the workflow\.
#### Parameters

<a name='Cat.FluentWorkflows.Abstractions.ICatWorkflowProcessor.RunAsync_TWorkflow,TWorkflowState_(TWorkflowState,System.Threading.CancellationToken).workflowState'></a>

`workflowState` [TWorkflowState](ICatWorkflowProcessor.RunAsync.R1HS9NJ8EQXVXKZLXHU6G4NG5.md#Cat.FluentWorkflows.Abstractions.ICatWorkflowProcessor.RunAsync_TWorkflow,TWorkflowState_(TWorkflowState,System.Threading.CancellationToken).TWorkflowState 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowProcessor\.RunAsync\<TWorkflow,TWorkflowState\>\(TWorkflowState, System\.Threading\.CancellationToken\)\.TWorkflowState')

The state the steps work on\. Read it afterwards to get the results\.

<a name='Cat.FluentWorkflows.Abstractions.ICatWorkflowProcessor.RunAsync_TWorkflow,TWorkflowState_(TWorkflowState,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Token to cancel the work\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[ICatWorkflowResponse](ICatWorkflowResponse.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowResponse')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The result of the last step that ran, with the errors of every step that ran\.