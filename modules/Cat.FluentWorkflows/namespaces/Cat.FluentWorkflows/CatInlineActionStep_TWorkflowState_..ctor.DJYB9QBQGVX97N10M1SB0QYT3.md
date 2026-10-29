<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows\.Steps](Cat.FluentWorkflows.Steps.md 'Cat\.FluentWorkflows\.Steps') > [CatInlineActionStep&lt;TWorkflowState&gt;](CatInlineActionStep_TWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatInlineActionStep\<TWorkflowState\>')

## CatInlineActionStep\(ILogger\<CatInlineActionStep\<TWorkflowState\>\>\) Constructor

Creates the step\.

```csharp
public CatInlineActionStep(Microsoft.Extensions.Logging.ILogger<Cat.FluentWorkflows.Steps.CatInlineActionStep<TWorkflowState>> logger);
```
#### Parameters

<a name='Cat.FluentWorkflows.Steps.CatInlineActionStep_TWorkflowState_.CatInlineActionStep(Microsoft.Extensions.Logging.ILogger_Cat.FluentWorkflows.Steps.CatInlineActionStep_TWorkflowState__).logger'></a>

`logger` [Microsoft\.Extensions\.Logging\.ILogger&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')[Cat\.FluentWorkflows\.Steps\.CatInlineActionStep&lt;](CatInlineActionStep_TWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatInlineActionStep\<TWorkflowState\>')[TWorkflowState](CatInlineActionStep_TWorkflowState_.md#Cat.FluentWorkflows.Steps.CatInlineActionStep_TWorkflowState_.TWorkflowState 'Cat\.FluentWorkflows\.Steps\.CatInlineActionStep\<TWorkflowState\>\.TWorkflowState')[&gt;](CatInlineActionStep_TWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatInlineActionStep\<TWorkflowState\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')

The logger the step passes to your code\.