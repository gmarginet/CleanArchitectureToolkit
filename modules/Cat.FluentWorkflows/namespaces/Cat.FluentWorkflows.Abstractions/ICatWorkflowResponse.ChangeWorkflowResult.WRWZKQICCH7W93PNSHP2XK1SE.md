<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows\.Abstractions](index.md 'index') > [Cat\.FluentWorkflows\.Abstractions](Cat.FluentWorkflows.Abstractions.md 'Cat\.FluentWorkflows\.Abstractions') > [ICatWorkflowResponse](ICatWorkflowResponse.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowResponse')

## ICatWorkflowResponse\.ChangeWorkflowResult\(CatStepExecutionResult\) Method

Changes the result and keeps the errors\.

```csharp
Cat.FluentWorkflows.Abstractions.ICatWorkflowResponse ChangeWorkflowResult(Cat.FluentWorkflows.Abstractions.CatStepExecutionResult workflowResult);
```
#### Parameters

<a name='Cat.FluentWorkflows.Abstractions.ICatWorkflowResponse.ChangeWorkflowResult(Cat.FluentWorkflows.Abstractions.CatStepExecutionResult).workflowResult'></a>

`workflowResult` [CatStepExecutionResult](CatStepExecutionResult.md 'Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult')

The new result\.

#### Returns
[ICatWorkflowResponse](ICatWorkflowResponse.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowResponse')  
The same response\.