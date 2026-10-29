<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows](Cat.FluentWorkflows.md 'Cat\.FluentWorkflows') > [CatStepBody&lt;TWorkflowState&gt;](CatStepBody_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBody\<TWorkflowState\>')

## CatStepBody\(ILogger\<CatStepBody\<TWorkflowState\>\>\) Constructor

Creates the step\.

```csharp
protected CatStepBody(Microsoft.Extensions.Logging.ILogger<Cat.FluentWorkflows.CatStepBody<TWorkflowState>> logger);
```
#### Parameters

<a name='Cat.FluentWorkflows.CatStepBody_TWorkflowState_.CatStepBody(Microsoft.Extensions.Logging.ILogger_Cat.FluentWorkflows.CatStepBody_TWorkflowState__).logger'></a>

`logger` [Microsoft\.Extensions\.Logging\.ILogger&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')[Cat\.FluentWorkflows\.CatStepBody&lt;](CatStepBody_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBody\<TWorkflowState\>')[TWorkflowState](CatStepBody_TWorkflowState_.md#Cat.FluentWorkflows.CatStepBody_TWorkflowState_.TWorkflowState 'Cat\.FluentWorkflows\.CatStepBody\<TWorkflowState\>\.TWorkflowState')[&gt;](CatStepBody_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBody\<TWorkflowState\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')

The logger the step can use\. Pass the `ILogger<YourStep>` you got from the constructor\.