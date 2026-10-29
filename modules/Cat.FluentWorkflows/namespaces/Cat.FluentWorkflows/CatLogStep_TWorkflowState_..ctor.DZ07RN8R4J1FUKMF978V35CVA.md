<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows\.Steps](Cat.FluentWorkflows.Steps.md 'Cat\.FluentWorkflows\.Steps') > [CatLogStep&lt;TWorkflowState&gt;](CatLogStep_TWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatLogStep\<TWorkflowState\>')

## CatLogStep\(ILogger\<CatLogStep\<TWorkflowState\>\>\) Constructor

Creates the step\.

```csharp
public CatLogStep(Microsoft.Extensions.Logging.ILogger<Cat.FluentWorkflows.Steps.CatLogStep<TWorkflowState>> logger);
```
#### Parameters

<a name='Cat.FluentWorkflows.Steps.CatLogStep_TWorkflowState_.CatLogStep(Microsoft.Extensions.Logging.ILogger_Cat.FluentWorkflows.Steps.CatLogStep_TWorkflowState__).logger'></a>

`logger` [Microsoft\.Extensions\.Logging\.ILogger&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')[Cat\.FluentWorkflows\.Steps\.CatLogStep&lt;](CatLogStep_TWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatLogStep\<TWorkflowState\>')[TWorkflowState](CatLogStep_TWorkflowState_.md#Cat.FluentWorkflows.Steps.CatLogStep_TWorkflowState_.TWorkflowState 'Cat\.FluentWorkflows\.Steps\.CatLogStep\<TWorkflowState\>\.TWorkflowState')[&gt;](CatLogStep_TWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatLogStep\<TWorkflowState\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')

Receives the log entry\.