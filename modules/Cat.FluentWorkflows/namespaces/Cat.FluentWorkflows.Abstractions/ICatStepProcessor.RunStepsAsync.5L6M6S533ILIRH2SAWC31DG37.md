<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows\.Abstractions](index.md 'index') > [Cat\.FluentWorkflows\.Abstractions](Cat.FluentWorkflows.Abstractions.md 'Cat\.FluentWorkflows\.Abstractions') > [ICatStepProcessor](ICatStepProcessor.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepProcessor')

## ICatStepProcessor\.RunStepsAsync\<TWorkflowState\>\(ICatWorkflowBuilder\<TWorkflowState\>, TWorkflowState, CancellationToken\) Method

Runs the steps of a builder in order\. It stops after a step that returns a break result\.

```csharp
System.Threading.Tasks.Task<Cat.FluentWorkflows.Abstractions.ICatWorkflowResponse> RunStepsAsync<TWorkflowState>(Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder<TWorkflowState> workflowBuilder, TWorkflowState workflowState, System.Threading.CancellationToken cancellationToken)
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>;
```
#### Type parameters

<a name='Cat.FluentWorkflows.Abstractions.ICatStepProcessor.RunStepsAsync_TWorkflowState_(Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,TWorkflowState,System.Threading.CancellationToken).TWorkflowState'></a>

`TWorkflowState`

The state of the workflow\.
#### Parameters

<a name='Cat.FluentWorkflows.Abstractions.ICatStepProcessor.RunStepsAsync_TWorkflowState_(Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,TWorkflowState,System.Threading.CancellationToken).workflowBuilder'></a>

`workflowBuilder` [Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder&lt;](ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>')[TWorkflowState](ICatStepProcessor.RunStepsAsync.5L6M6S533ILIRH2SAWC31DG37.md#Cat.FluentWorkflows.Abstractions.ICatStepProcessor.RunStepsAsync_TWorkflowState_(Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,TWorkflowState,System.Threading.CancellationToken).TWorkflowState 'Cat\.FluentWorkflows\.Abstractions\.ICatStepProcessor\.RunStepsAsync\<TWorkflowState\>\(Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, TWorkflowState, System\.Threading\.CancellationToken\)\.TWorkflowState')[&gt;](ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>')

Holds the steps\.

<a name='Cat.FluentWorkflows.Abstractions.ICatStepProcessor.RunStepsAsync_TWorkflowState_(Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,TWorkflowState,System.Threading.CancellationToken).workflowState'></a>

`workflowState` [TWorkflowState](ICatStepProcessor.RunStepsAsync.5L6M6S533ILIRH2SAWC31DG37.md#Cat.FluentWorkflows.Abstractions.ICatStepProcessor.RunStepsAsync_TWorkflowState_(Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,TWorkflowState,System.Threading.CancellationToken).TWorkflowState 'Cat\.FluentWorkflows\.Abstractions\.ICatStepProcessor\.RunStepsAsync\<TWorkflowState\>\(Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, TWorkflowState, System\.Threading\.CancellationToken\)\.TWorkflowState')

The state the steps work on\.

<a name='Cat.FluentWorkflows.Abstractions.ICatStepProcessor.RunStepsAsync_TWorkflowState_(Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,TWorkflowState,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Token to cancel the work\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[ICatWorkflowResponse](ICatWorkflowResponse.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowResponse')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The result of the last step that ran, with the errors of every step that ran\.