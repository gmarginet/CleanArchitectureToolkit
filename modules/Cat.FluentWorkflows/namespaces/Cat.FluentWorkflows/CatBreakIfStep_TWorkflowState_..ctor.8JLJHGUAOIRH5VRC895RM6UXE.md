<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows\.Steps](Cat.FluentWorkflows.Steps.md 'Cat\.FluentWorkflows\.Steps') > [CatBreakIfStep&lt;TWorkflowState&gt;](CatBreakIfStep_TWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatBreakIfStep\<TWorkflowState\>')

## CatBreakIfStep\(ILogger\<CatBreakIfStep\<TWorkflowState\>\>\) Constructor

Creates the step\.

```csharp
public CatBreakIfStep(Microsoft.Extensions.Logging.ILogger<Cat.FluentWorkflows.Steps.CatBreakIfStep<TWorkflowState>> logger);
```
#### Parameters

<a name='Cat.FluentWorkflows.Steps.CatBreakIfStep_TWorkflowState_.CatBreakIfStep(Microsoft.Extensions.Logging.ILogger_Cat.FluentWorkflows.Steps.CatBreakIfStep_TWorkflowState__).logger'></a>

`logger` [Microsoft\.Extensions\.Logging\.ILogger&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')[Cat\.FluentWorkflows\.Steps\.CatBreakIfStep&lt;](CatBreakIfStep_TWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatBreakIfStep\<TWorkflowState\>')[TWorkflowState](CatBreakIfStep_TWorkflowState_.md#Cat.FluentWorkflows.Steps.CatBreakIfStep_TWorkflowState_.TWorkflowState 'Cat\.FluentWorkflows\.Steps\.CatBreakIfStep\<TWorkflowState\>\.TWorkflowState')[&gt;](CatBreakIfStep_TWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatBreakIfStep\<TWorkflowState\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')

The logger the step can use\.