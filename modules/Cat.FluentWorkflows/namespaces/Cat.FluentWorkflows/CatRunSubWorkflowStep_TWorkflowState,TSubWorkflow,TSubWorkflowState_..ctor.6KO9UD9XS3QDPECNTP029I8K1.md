<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows\.Steps](Cat.FluentWorkflows.Steps.md 'Cat\.FluentWorkflows\.Steps') > [CatRunSubWorkflowStep&lt;TWorkflowState,TSubWorkflow,TSubWorkflowState&gt;](CatRunSubWorkflowStep_TWorkflowState,TSubWorkflow,TSubWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatRunSubWorkflowStep\<TWorkflowState,TSubWorkflow,TSubWorkflowState\>')

## CatRunSubWorkflowStep\(ICatWorkflowProcessor, ILogger\<CatRunSubWorkflowStep\<TWorkflowState,TSubWorkflow,TSubWorkflowState\>\>\) Constructor

Creates the step\.

```csharp
public CatRunSubWorkflowStep(Cat.FluentWorkflows.Abstractions.ICatWorkflowProcessor workflowProcessor, Microsoft.Extensions.Logging.ILogger<Cat.FluentWorkflows.Steps.CatRunSubWorkflowStep<TWorkflowState,TSubWorkflow,TSubWorkflowState>> logger);
```
#### Parameters

<a name='Cat.FluentWorkflows.Steps.CatRunSubWorkflowStep_TWorkflowState,TSubWorkflow,TSubWorkflowState_.CatRunSubWorkflowStep(Cat.FluentWorkflows.Abstractions.ICatWorkflowProcessor,Microsoft.Extensions.Logging.ILogger_Cat.FluentWorkflows.Steps.CatRunSubWorkflowStep_TWorkflowState,TSubWorkflow,TSubWorkflowState__).workflowProcessor'></a>

`workflowProcessor` [ICatWorkflowProcessor](..\Cat.FluentWorkflows.Abstractions\ICatWorkflowProcessor.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowProcessor')

Runs the sub\-workflow\.

<a name='Cat.FluentWorkflows.Steps.CatRunSubWorkflowStep_TWorkflowState,TSubWorkflow,TSubWorkflowState_.CatRunSubWorkflowStep(Cat.FluentWorkflows.Abstractions.ICatWorkflowProcessor,Microsoft.Extensions.Logging.ILogger_Cat.FluentWorkflows.Steps.CatRunSubWorkflowStep_TWorkflowState,TSubWorkflow,TSubWorkflowState__).logger'></a>

`logger` [Microsoft\.Extensions\.Logging\.ILogger&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')[Cat\.FluentWorkflows\.Steps\.CatRunSubWorkflowStep&lt;](CatRunSubWorkflowStep_TWorkflowState,TSubWorkflow,TSubWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatRunSubWorkflowStep\<TWorkflowState,TSubWorkflow,TSubWorkflowState\>')[TWorkflowState](CatRunSubWorkflowStep_TWorkflowState,TSubWorkflow,TSubWorkflowState_.md#Cat.FluentWorkflows.Steps.CatRunSubWorkflowStep_TWorkflowState,TSubWorkflow,TSubWorkflowState_.TWorkflowState 'Cat\.FluentWorkflows\.Steps\.CatRunSubWorkflowStep\<TWorkflowState,TSubWorkflow,TSubWorkflowState\>\.TWorkflowState')[,](CatRunSubWorkflowStep_TWorkflowState,TSubWorkflow,TSubWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatRunSubWorkflowStep\<TWorkflowState,TSubWorkflow,TSubWorkflowState\>')[TSubWorkflow](CatRunSubWorkflowStep_TWorkflowState,TSubWorkflow,TSubWorkflowState_.md#Cat.FluentWorkflows.Steps.CatRunSubWorkflowStep_TWorkflowState,TSubWorkflow,TSubWorkflowState_.TSubWorkflow 'Cat\.FluentWorkflows\.Steps\.CatRunSubWorkflowStep\<TWorkflowState,TSubWorkflow,TSubWorkflowState\>\.TSubWorkflow')[,](CatRunSubWorkflowStep_TWorkflowState,TSubWorkflow,TSubWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatRunSubWorkflowStep\<TWorkflowState,TSubWorkflow,TSubWorkflowState\>')[TSubWorkflowState](CatRunSubWorkflowStep_TWorkflowState,TSubWorkflow,TSubWorkflowState_.md#Cat.FluentWorkflows.Steps.CatRunSubWorkflowStep_TWorkflowState,TSubWorkflow,TSubWorkflowState_.TSubWorkflowState 'Cat\.FluentWorkflows\.Steps\.CatRunSubWorkflowStep\<TWorkflowState,TSubWorkflow,TSubWorkflowState\>\.TSubWorkflowState')[&gt;](CatRunSubWorkflowStep_TWorkflowState,TSubWorkflow,TSubWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatRunSubWorkflowStep\<TWorkflowState,TSubWorkflow,TSubWorkflowState\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')

The logger the step can use\.