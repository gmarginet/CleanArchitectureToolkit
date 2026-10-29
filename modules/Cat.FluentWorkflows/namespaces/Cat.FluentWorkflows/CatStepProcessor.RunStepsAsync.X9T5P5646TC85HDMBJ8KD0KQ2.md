<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows](Cat.FluentWorkflows.md 'Cat\.FluentWorkflows') > [CatStepProcessor](CatStepProcessor.md 'Cat\.FluentWorkflows\.CatStepProcessor')

## CatStepProcessor\.RunStepsAsync\<TWorkflowState\>\(ICatWorkflowBuilder\<TWorkflowState\>, TWorkflowState, CancellationToken\) Method

Runs the steps of a builder in order\. It stops after a step that returns a break result\.

```csharp
public System.Threading.Tasks.Task<Cat.FluentWorkflows.Abstractions.ICatWorkflowResponse> RunStepsAsync<TWorkflowState>(Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder<TWorkflowState> workflowBuilder, TWorkflowState workflowState, System.Threading.CancellationToken cancellationToken)
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>;
```
#### Type parameters

<a name='Cat.FluentWorkflows.CatStepProcessor.RunStepsAsync_TWorkflowState_(Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,TWorkflowState,System.Threading.CancellationToken).TWorkflowState'></a>

`TWorkflowState`

The state of the workflow\.
#### Parameters

<a name='Cat.FluentWorkflows.CatStepProcessor.RunStepsAsync_TWorkflowState_(Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,TWorkflowState,System.Threading.CancellationToken).workflowBuilder'></a>

`workflowBuilder` [Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder&lt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')[TWorkflowState](CatStepProcessor.RunStepsAsync.X9T5P5646TC85HDMBJ8KD0KQ2.md#Cat.FluentWorkflows.CatStepProcessor.RunStepsAsync_TWorkflowState_(Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,TWorkflowState,System.Threading.CancellationToken).TWorkflowState 'Cat\.FluentWorkflows\.CatStepProcessor\.RunStepsAsync\<TWorkflowState\>\(Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, TWorkflowState, System\.Threading\.CancellationToken\)\.TWorkflowState')[&gt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')

Holds the steps\.

<a name='Cat.FluentWorkflows.CatStepProcessor.RunStepsAsync_TWorkflowState_(Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,TWorkflowState,System.Threading.CancellationToken).workflowState'></a>

`workflowState` [TWorkflowState](CatStepProcessor.RunStepsAsync.X9T5P5646TC85HDMBJ8KD0KQ2.md#Cat.FluentWorkflows.CatStepProcessor.RunStepsAsync_TWorkflowState_(Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,TWorkflowState,System.Threading.CancellationToken).TWorkflowState 'Cat\.FluentWorkflows\.CatStepProcessor\.RunStepsAsync\<TWorkflowState\>\(Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, TWorkflowState, System\.Threading\.CancellationToken\)\.TWorkflowState')

The state the steps work on\.

<a name='Cat.FluentWorkflows.CatStepProcessor.RunStepsAsync_TWorkflowState_(Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,TWorkflowState,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Token to cancel the work\.

Implements [RunStepsAsync&lt;TWorkflowState&gt;\(ICatWorkflowBuilder&lt;TWorkflowState&gt;, TWorkflowState, CancellationToken\)](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatStepProcessor.RunStepsAsync.5L6M6S533ILIRH2SAWC31DG37.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepProcessor\.RunStepsAsync\`\`1\(Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\{\`\`0\},\`\`0,System\.Threading\.CancellationToken\)')

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[ICatWorkflowResponse](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowResponse.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowResponse')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The result of the last step that ran, with the errors of every step that ran\.