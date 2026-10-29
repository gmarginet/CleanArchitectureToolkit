<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows\.Abstractions](index.md 'index') > [Cat\.FluentWorkflows\.Abstractions](Cat.FluentWorkflows.Abstractions.md 'Cat\.FluentWorkflows\.Abstractions')

## ICatWorkflowResponse Interface

The outcome of a step or a workflow: what to do next, and the errors if something failed\.

```csharp
public interface ICatWorkflowResponse
```

| Properties | |
| :--- | :--- |
| [ErrorList](ICatWorkflowResponse.ErrorList.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowResponse\.ErrorList') | The errors\. The list is empty when nothing failed\. |
| [WorkflowResult](ICatWorkflowResponse.WorkflowResult.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowResponse\.WorkflowResult') | What the step processor does next\. |

| Methods | |
| :--- | :--- |
| [ChangeWorkflowResult\(CatStepExecutionResult\)](ICatWorkflowResponse.ChangeWorkflowResult.WRWZKQICCH7W93PNSHP2XK1SE.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowResponse\.ChangeWorkflowResult\(Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\)') | Changes the result and keeps the errors\. |
