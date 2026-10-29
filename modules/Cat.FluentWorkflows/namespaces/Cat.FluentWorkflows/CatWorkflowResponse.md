<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows](Cat.FluentWorkflows.md 'Cat\.FluentWorkflows')

## CatWorkflowResponse Class

Default [ICatWorkflowResponse](..\Cat.FluentWorkflows.Abstractions\ICatWorkflowResponse.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowResponse')\. Create one with [Succeeded\(CatStepExecutionResult\)](CatWorkflowResponse.Succeeded.6G1DWSINROG6P566C8AAH0K1.md 'Cat\.FluentWorkflows\.CatWorkflowResponse\.Succeeded\(Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\)') or [Failed\(CatStepExecutionResult, ICatError\[\]\)](CatWorkflowResponse.Failed.md#Cat.FluentWorkflows.CatWorkflowResponse.Failed(Cat.FluentWorkflows.Abstractions.CatStepExecutionResult,Cat.Responses.Abstractions.ICatError[]) 'Cat\.FluentWorkflows\.CatWorkflowResponse\.Failed\(Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult, Cat\.Responses\.Abstractions\.ICatError\[\]\)')\.

```csharp
public class CatWorkflowResponse : Cat.FluentWorkflows.Abstractions.ICatWorkflowResponse
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; CatWorkflowResponse

Implements [ICatWorkflowResponse](..\Cat.FluentWorkflows.Abstractions\ICatWorkflowResponse.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowResponse')

| Constructors | |
| :--- | :--- |
| [CatWorkflowResponse\(CatStepExecutionResult\)](CatWorkflowResponse.CatWorkflowResponse.md#Cat.FluentWorkflows.CatWorkflowResponse.CatWorkflowResponse(Cat.FluentWorkflows.Abstractions.CatStepExecutionResult) 'Cat\.FluentWorkflows\.CatWorkflowResponse\.CatWorkflowResponse\(Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\)') | |
| [CatWorkflowResponse\(CatStepExecutionResult, IReadOnlyList&lt;ICatError&gt;\)](CatWorkflowResponse.CatWorkflowResponse.md#Cat.FluentWorkflows.CatWorkflowResponse.CatWorkflowResponse(Cat.FluentWorkflows.Abstractions.CatStepExecutionResult,System.Collections.Generic.IReadOnlyList_Cat.Responses.Abstractions.ICatError_) 'Cat\.FluentWorkflows\.CatWorkflowResponse\.CatWorkflowResponse\(Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult, System\.Collections\.Generic\.IReadOnlyList\<Cat\.Responses\.Abstractions\.ICatError\>\)') | |

| Properties | |
| :--- | :--- |
| [ErrorList](CatWorkflowResponse.ErrorList.md 'Cat\.FluentWorkflows\.CatWorkflowResponse\.ErrorList') | The errors\. The list is empty when nothing failed\. |
| [WorkflowResult](CatWorkflowResponse.WorkflowResult.md 'Cat\.FluentWorkflows\.CatWorkflowResponse\.WorkflowResult') | What the step processor does next\. |

| Methods | |
| :--- | :--- |
| [ChangeWorkflowResult\(CatStepExecutionResult\)](CatWorkflowResponse.ChangeWorkflowResult.SLTTAVSE97M2BDZ8V5RTXSHRE.md 'Cat\.FluentWorkflows\.CatWorkflowResponse\.ChangeWorkflowResult\(Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\)') | Changes the result and keeps the errors\. |
| [Failed\(CatStepExecutionResult, ICatError\[\]\)](CatWorkflowResponse.Failed.md#Cat.FluentWorkflows.CatWorkflowResponse.Failed(Cat.FluentWorkflows.Abstractions.CatStepExecutionResult,Cat.Responses.Abstractions.ICatError[]) 'Cat\.FluentWorkflows\.CatWorkflowResponse\.Failed\(Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult, Cat\.Responses\.Abstractions\.ICatError\[\]\)') | Creates a response for a step that failed\. Use [BreakCascade](..\Cat.FluentWorkflows.Abstractions\CatStepExecutionResult.md#Cat.FluentWorkflows.Abstractions.CatStepExecutionResult.BreakCascade 'Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\.BreakCascade') as the result to end the workflow on the failure\. With any other result the workflow goes on, and the errors are still part of the final response\. |
| [Failed\(CatStepExecutionResult, IReadOnlyList&lt;ICatError&gt;\)](CatWorkflowResponse.Failed.md#Cat.FluentWorkflows.CatWorkflowResponse.Failed(Cat.FluentWorkflows.Abstractions.CatStepExecutionResult,System.Collections.Generic.IReadOnlyList_Cat.Responses.Abstractions.ICatError_) 'Cat\.FluentWorkflows\.CatWorkflowResponse\.Failed\(Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult, System\.Collections\.Generic\.IReadOnlyList\<Cat\.Responses\.Abstractions\.ICatError\>\)') | Creates a response for a step that failed\. Use [BreakCascade](..\Cat.FluentWorkflows.Abstractions\CatStepExecutionResult.md#Cat.FluentWorkflows.Abstractions.CatStepExecutionResult.BreakCascade 'Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\.BreakCascade') as the result to end the workflow on the failure\. With any other result the workflow goes on, and the errors are still part of the final response\. |
| [Succeeded\(CatStepExecutionResult\)](CatWorkflowResponse.Succeeded.6G1DWSINROG6P566C8AAH0K1.md 'Cat\.FluentWorkflows\.CatWorkflowResponse\.Succeeded\(Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\)') | Creates a response for a step that worked\. |
| [WithErrors\(ICatWorkflowResponse, List&lt;ICatError&gt;\)](CatWorkflowResponse.WithErrors.W0QND61FGE6VG26Y26FGZBUIA.md 'Cat\.FluentWorkflows\.CatWorkflowResponse\.WithErrors\(Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowResponse, System\.Collections\.Generic\.List\<Cat\.Responses\.Abstractions\.ICatError\>\)') | Gives a response all the errors that were collected on the way\. |
