<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows\.Steps](Cat.FluentWorkflows.Steps.md 'Cat\.FluentWorkflows\.Steps') > [CatSetStatePropertyStep&lt;TWorkflowState,TProperty&gt;](CatSetStatePropertyStep_TWorkflowState,TProperty_.md 'Cat\.FluentWorkflows\.Steps\.CatSetStatePropertyStep\<TWorkflowState,TProperty\>')

## CatSetStatePropertyStep\(ILogger\<CatSetStatePropertyStep\<TWorkflowState,TProperty\>\>\) Constructor

Creates the step\.

```csharp
public CatSetStatePropertyStep(Microsoft.Extensions.Logging.ILogger<Cat.FluentWorkflows.Steps.CatSetStatePropertyStep<TWorkflowState,TProperty>> logger);
```
#### Parameters

<a name='Cat.FluentWorkflows.Steps.CatSetStatePropertyStep_TWorkflowState,TProperty_.CatSetStatePropertyStep(Microsoft.Extensions.Logging.ILogger_Cat.FluentWorkflows.Steps.CatSetStatePropertyStep_TWorkflowState,TProperty__).logger'></a>

`logger` [Microsoft\.Extensions\.Logging\.ILogger&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')[Cat\.FluentWorkflows\.Steps\.CatSetStatePropertyStep&lt;](CatSetStatePropertyStep_TWorkflowState,TProperty_.md 'Cat\.FluentWorkflows\.Steps\.CatSetStatePropertyStep\<TWorkflowState,TProperty\>')[TWorkflowState](CatSetStatePropertyStep_TWorkflowState,TProperty_.md#Cat.FluentWorkflows.Steps.CatSetStatePropertyStep_TWorkflowState,TProperty_.TWorkflowState 'Cat\.FluentWorkflows\.Steps\.CatSetStatePropertyStep\<TWorkflowState,TProperty\>\.TWorkflowState')[,](CatSetStatePropertyStep_TWorkflowState,TProperty_.md 'Cat\.FluentWorkflows\.Steps\.CatSetStatePropertyStep\<TWorkflowState,TProperty\>')[TProperty](CatSetStatePropertyStep_TWorkflowState,TProperty_.md#Cat.FluentWorkflows.Steps.CatSetStatePropertyStep_TWorkflowState,TProperty_.TProperty 'Cat\.FluentWorkflows\.Steps\.CatSetStatePropertyStep\<TWorkflowState,TProperty\>\.TProperty')[&gt;](CatSetStatePropertyStep_TWorkflowState,TProperty_.md 'Cat\.FluentWorkflows\.Steps\.CatSetStatePropertyStep\<TWorkflowState,TProperty\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')

The logger the step passes to your code\.