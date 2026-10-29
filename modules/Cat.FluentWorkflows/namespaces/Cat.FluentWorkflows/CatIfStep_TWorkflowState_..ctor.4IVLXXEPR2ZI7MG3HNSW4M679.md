<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows\.Steps](Cat.FluentWorkflows.Steps.md 'Cat\.FluentWorkflows\.Steps') > [CatIfStep&lt;TWorkflowState&gt;](CatIfStep_TWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatIfStep\<TWorkflowState\>')

## CatIfStep\(ICatStepProcessor, ILogger\<CatIfStep\<TWorkflowState\>\>\) Constructor

Creates the step\.

```csharp
public CatIfStep(Cat.FluentWorkflows.Abstractions.ICatStepProcessor catStepProcessor, Microsoft.Extensions.Logging.ILogger<Cat.FluentWorkflows.Steps.CatIfStep<TWorkflowState>> logger);
```
#### Parameters

<a name='Cat.FluentWorkflows.Steps.CatIfStep_TWorkflowState_.CatIfStep(Cat.FluentWorkflows.Abstractions.ICatStepProcessor,Microsoft.Extensions.Logging.ILogger_Cat.FluentWorkflows.Steps.CatIfStep_TWorkflowState__).catStepProcessor'></a>

`catStepProcessor` [ICatStepProcessor](..\Cat.FluentWorkflows.Abstractions\ICatStepProcessor.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepProcessor')

Runs the inner steps\.

<a name='Cat.FluentWorkflows.Steps.CatIfStep_TWorkflowState_.CatIfStep(Cat.FluentWorkflows.Abstractions.ICatStepProcessor,Microsoft.Extensions.Logging.ILogger_Cat.FluentWorkflows.Steps.CatIfStep_TWorkflowState__).logger'></a>

`logger` [Microsoft\.Extensions\.Logging\.ILogger&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')[Cat\.FluentWorkflows\.Steps\.CatIfStep&lt;](CatIfStep_TWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatIfStep\<TWorkflowState\>')[TWorkflowState](CatIfStep_TWorkflowState_.md#Cat.FluentWorkflows.Steps.CatIfStep_TWorkflowState_.TWorkflowState 'Cat\.FluentWorkflows\.Steps\.CatIfStep\<TWorkflowState\>\.TWorkflowState')[&gt;](CatIfStep_TWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatIfStep\<TWorkflowState\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')

The logger the step can use\.