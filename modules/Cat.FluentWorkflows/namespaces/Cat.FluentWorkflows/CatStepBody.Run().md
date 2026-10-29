<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows](Cat.FluentWorkflows.md 'Cat\.FluentWorkflows') > [CatStepBody](CatStepBody.md 'Cat\.FluentWorkflows\.CatStepBody')

## CatStepBody\.Run\(\) Method

Does the work of the step\.

```csharp
protected abstract Cat.FluentWorkflows.Abstractions.ICatWorkflowResponse Run();
```

#### Returns
[ICatWorkflowResponse](..\Cat.FluentWorkflows.Abstractions\ICatWorkflowResponse.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowResponse')  
A response with the result for the step processor and the errors, if any\.