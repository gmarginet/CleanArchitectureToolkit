<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.FluentWorkflows](index.md 'index')

## Cat\.FluentWorkflows Namespace

Provides the default workflow builder and processors, the base classes for your own steps,
and the response types that steps return\.

| Classes | |
| :--- | :--- |
| [CatStepBody](CatStepBody.md 'Cat\.FluentWorkflows\.CatStepBody') | Base class for a step that works synchronously and doesn't need the workflow state directly\. Get its data through `Input` and hand results back through `Output`\. Implement [Run\(\)](CatStepBody.Run().md 'Cat\.FluentWorkflows\.CatStepBody\.Run\(\)')\. |
| [CatStepBody&lt;TWorkflowState&gt;](CatStepBody_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBody\<TWorkflowState\>') | Base class for a step that works synchronously and reads or writes the workflow state directly\. Implement [Run\(\)](CatStepBody_TWorkflowState_.Run().md 'Cat\.FluentWorkflows\.CatStepBody\<TWorkflowState\>\.Run\(\)') and use [WorkflowState](CatStepBodyAsync_TWorkflowState_.WorkflowState.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\<TWorkflowState\>\.WorkflowState')\. |
| [CatStepBodyAsync](CatStepBodyAsync.md 'Cat\.FluentWorkflows\.CatStepBodyAsync') | Base class for a step that works asynchronously and doesn't need the workflow state directly\. Get its data through `Input` and hand results back through `Output`\. Implement [RunAsync\(CancellationToken\)](CatStepBodyAsync.RunAsync.NDIRNNFATTDGG9GCGGAU4GQP1.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\.RunAsync\(System\.Threading\.CancellationToken\)')\. |
| [CatStepBodyAsync&lt;TWorkflowState&gt;](CatStepBodyAsync_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\<TWorkflowState\>') | Base class for a step that works asynchronously and reads or writes the workflow state directly\. Implement [RunAsync\(CancellationToken\)](CatStepBodyAsync.RunAsync.NDIRNNFATTDGG9GCGGAU4GQP1.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\.RunAsync\(System\.Threading\.CancellationToken\)') and use [WorkflowState](CatStepBodyAsync_TWorkflowState_.WorkflowState.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\<TWorkflowState\>\.WorkflowState')\. |
| [CatStepBuilder&lt;TWorkflowState,TStepBody&gt;](CatStepBuilder_TWorkflowState,TStepBody_.md 'Cat\.FluentWorkflows\.CatStepBuilder\<TWorkflowState,TStepBody\>') | Default [ICatStepBuilder&lt;TWorkflowState,TStepBody&gt;](..\Cat.FluentWorkflows.Abstractions\ICatStepBuilder_TWorkflowState,TStepBody_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder\`2')\. Stores the inputs and outputs on the workflow step\. |
| [CatStepParameter](CatStepParameter.md 'Cat\.FluentWorkflows\.CatStepParameter') | Default [ICatStepParameter](..\Cat.FluentWorkflows.Abstractions\ICatStepParameter.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepParameter')\. Reads a value with one expression and writes it with another\. A `null` value writes the default of the target type\. |
| [CatStepProcessor](CatStepProcessor.md 'Cat\.FluentWorkflows\.CatStepProcessor') | Default [ICatStepProcessor](..\Cat.FluentWorkflows.Abstractions\ICatStepProcessor.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepProcessor')\. For each step it gets the step body from the service provider, fills the inputs, runs the step and copies the outputs\. It stops after a step that returns BreakCascade, BreakFromCurrentFlowOnly or BreakFromLoop\. The result is the one of the last step that ran\. The errors of every step that ran are kept\. |
| [CatWorkflowBuilder&lt;TWorkflowState&gt;](CatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatWorkflowBuilder\<TWorkflowState\>') | Default [ICatWorkflowBuilder&lt;TWorkflowState&gt;](..\Cat.FluentWorkflows.Abstractions\ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')\. It only holds the steps\. The extension methods in `Cat.FluentWorkflows.Extensions` add them\. |
| [CatWorkflowProcessor](CatWorkflowProcessor.md 'Cat\.FluentWorkflows\.CatWorkflowProcessor') | Default [ICatWorkflowProcessor](..\Cat.FluentWorkflows.Abstractions\ICatWorkflowProcessor.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowProcessor')\. Gets the workflow from the service provider, builds its steps, and runs them inside a tracing activity\. |
| [CatWorkflowResponse](CatWorkflowResponse.md 'Cat\.FluentWorkflows\.CatWorkflowResponse') | Default [ICatWorkflowResponse](..\Cat.FluentWorkflows.Abstractions\ICatWorkflowResponse.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowResponse')\. Create one with [Succeeded\(CatStepExecutionResult\)](CatWorkflowResponse.Succeeded.6G1DWSINROG6P566C8AAH0K1.md 'Cat\.FluentWorkflows\.CatWorkflowResponse\.Succeeded\(Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\)') or [Failed\(CatStepExecutionResult, ICatError\[\]\)](CatWorkflowResponse.Failed.md#Cat.FluentWorkflows.CatWorkflowResponse.Failed(Cat.FluentWorkflows.Abstractions.CatStepExecutionResult,Cat.Responses.Abstractions.ICatError[]) 'Cat\.FluentWorkflows\.CatWorkflowResponse\.Failed\(Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult, Cat\.Responses\.Abstractions\.ICatError\[\]\)')\. |
| [CatWorkflowStep](CatWorkflowStep.md 'Cat\.FluentWorkflows\.CatWorkflowStep') | Base class of a workflow step\. |
| [CatWorkflowStep&lt;TStepBody&gt;](CatWorkflowStep_TStepBody_.md 'Cat\.FluentWorkflows\.CatWorkflowStep\<TStepBody\>') | A workflow step that runs the step body [TStepBody](CatWorkflowStep_TStepBody_.md#Cat.FluentWorkflows.CatWorkflowStep_TStepBody_.TStepBody 'Cat\.FluentWorkflows\.CatWorkflowStep\<TStepBody\>\.TStepBody')\. |
