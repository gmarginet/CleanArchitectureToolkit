<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows](Cat.FluentWorkflows.md 'Cat\.FluentWorkflows') > [CatWorkflowResponse](CatWorkflowResponse.md 'Cat\.FluentWorkflows\.CatWorkflowResponse')

## CatWorkflowResponse\.Succeeded\(CatStepExecutionResult\) Method

Creates a response for a step that worked\.

```csharp
public static Cat.FluentWorkflows.Abstractions.ICatWorkflowResponse Succeeded(Cat.FluentWorkflows.Abstractions.CatStepExecutionResult workflowResult);
```
#### Parameters

<a name='Cat.FluentWorkflows.CatWorkflowResponse.Succeeded(Cat.FluentWorkflows.Abstractions.CatStepExecutionResult).workflowResult'></a>

`workflowResult` [CatStepExecutionResult](../Cat.FluentWorkflows.Abstractions/CatStepExecutionResult.md 'Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult')

What the step processor does next\.

#### Returns
[ICatWorkflowResponse](../Cat.FluentWorkflows.Abstractions/ICatWorkflowResponse.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowResponse')  
The response, without errors\.