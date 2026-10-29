<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows\.Steps](Cat.FluentWorkflows.Steps.md 'Cat\.FluentWorkflows\.Steps') > [CatInlineFuncStep&lt;TWorkflowState&gt;](CatInlineFuncStep_TWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatInlineFuncStep\<TWorkflowState\>')

## CatInlineFuncStep\(ILogger\<CatInlineFuncStep\<TWorkflowState\>\>\) Constructor

Creates the step\.

```csharp
public CatInlineFuncStep(Microsoft.Extensions.Logging.ILogger<Cat.FluentWorkflows.Steps.CatInlineFuncStep<TWorkflowState>> logger);
```
#### Parameters

<a name='Cat.FluentWorkflows.Steps.CatInlineFuncStep_TWorkflowState_.CatInlineFuncStep(Microsoft.Extensions.Logging.ILogger_Cat.FluentWorkflows.Steps.CatInlineFuncStep_TWorkflowState__).logger'></a>

`logger` [Microsoft\.Extensions\.Logging\.ILogger&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')[Cat\.FluentWorkflows\.Steps\.CatInlineFuncStep&lt;](CatInlineFuncStep_TWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatInlineFuncStep\<TWorkflowState\>')[TWorkflowState](CatInlineFuncStep_TWorkflowState_.md#Cat.FluentWorkflows.Steps.CatInlineFuncStep_TWorkflowState_.TWorkflowState 'Cat\.FluentWorkflows\.Steps\.CatInlineFuncStep\<TWorkflowState\>\.TWorkflowState')[&gt;](CatInlineFuncStep_TWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatInlineFuncStep\<TWorkflowState\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')

The logger the step passes to your code\.