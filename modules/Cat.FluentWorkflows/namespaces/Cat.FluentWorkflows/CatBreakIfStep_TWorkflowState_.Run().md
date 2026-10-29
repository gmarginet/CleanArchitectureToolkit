<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows\.Steps](Cat.FluentWorkflows.Steps.md 'Cat\.FluentWorkflows\.Steps') > [CatBreakIfStep&lt;TWorkflowState&gt;](CatBreakIfStep_TWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatBreakIfStep\<TWorkflowState\>')

## CatBreakIfStep\<TWorkflowState\>\.Run\(\) Method

Does the work of the step\.

```csharp
protected override Cat.FluentWorkflows.Abstractions.ICatWorkflowResponse Run();
```

#### Returns
[ICatWorkflowResponse](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowResponse.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowResponse')  
A response with the result for the step processor and the errors, if any\.