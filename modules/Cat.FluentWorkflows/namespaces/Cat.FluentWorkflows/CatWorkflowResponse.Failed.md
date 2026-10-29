<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows](Cat.FluentWorkflows.md 'Cat\.FluentWorkflows') > [CatWorkflowResponse](CatWorkflowResponse.md 'Cat\.FluentWorkflows\.CatWorkflowResponse')

## CatWorkflowResponse\.Failed Method

| Overloads | |
| :--- | :--- |
| [Failed\(CatStepExecutionResult, ICatError\[\]\)](CatWorkflowResponse.Failed.md#Cat.FluentWorkflows.CatWorkflowResponse.Failed(Cat.FluentWorkflows.Abstractions.CatStepExecutionResult,Cat.Responses.Abstractions.ICatError[]) 'Cat\.FluentWorkflows\.CatWorkflowResponse\.Failed\(Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult, Cat\.Responses\.Abstractions\.ICatError\[\]\)') | Creates a response for a step that failed\. Use [BreakCascade](..\Cat.FluentWorkflows.Abstractions\CatStepExecutionResult.md#Cat.FluentWorkflows.Abstractions.CatStepExecutionResult.BreakCascade 'Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\.BreakCascade') as the result to end the workflow on the failure\. With any other result the workflow goes on, and the errors are still part of the final response\. |
| [Failed\(CatStepExecutionResult, IReadOnlyList&lt;ICatError&gt;\)](CatWorkflowResponse.Failed.md#Cat.FluentWorkflows.CatWorkflowResponse.Failed(Cat.FluentWorkflows.Abstractions.CatStepExecutionResult,System.Collections.Generic.IReadOnlyList_Cat.Responses.Abstractions.ICatError_) 'Cat\.FluentWorkflows\.CatWorkflowResponse\.Failed\(Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult, System\.Collections\.Generic\.IReadOnlyList\<Cat\.Responses\.Abstractions\.ICatError\>\)') | Creates a response for a step that failed\. Use [BreakCascade](..\Cat.FluentWorkflows.Abstractions\CatStepExecutionResult.md#Cat.FluentWorkflows.Abstractions.CatStepExecutionResult.BreakCascade 'Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\.BreakCascade') as the result to end the workflow on the failure\. With any other result the workflow goes on, and the errors are still part of the final response\. |

<a name='Cat.FluentWorkflows.CatWorkflowResponse.Failed(Cat.FluentWorkflows.Abstractions.CatStepExecutionResult,Cat.Responses.Abstractions.ICatError[])'></a>

## CatWorkflowResponse\.Failed\(CatStepExecutionResult, ICatError\[\]\) Method

Creates a response for a step that failed\.
Use [BreakCascade](..\Cat.FluentWorkflows.Abstractions\CatStepExecutionResult.md#Cat.FluentWorkflows.Abstractions.CatStepExecutionResult.BreakCascade 'Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\.BreakCascade') as the result to end the workflow on the failure\.
With any other result the workflow goes on, and the errors are still part of the final response\.

```csharp
public static Cat.FluentWorkflows.Abstractions.ICatWorkflowResponse Failed(Cat.FluentWorkflows.Abstractions.CatStepExecutionResult workflowResult, params Cat.Responses.Abstractions.ICatError[] errorList);
```
#### Parameters

<a name='Cat.FluentWorkflows.CatWorkflowResponse.Failed(Cat.FluentWorkflows.Abstractions.CatStepExecutionResult,Cat.Responses.Abstractions.ICatError[]).workflowResult'></a>

`workflowResult` [CatStepExecutionResult](..\Cat.FluentWorkflows.Abstractions\CatStepExecutionResult.md 'Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult')

What the step processor does next\.

<a name='Cat.FluentWorkflows.CatWorkflowResponse.Failed(Cat.FluentWorkflows.Abstractions.CatStepExecutionResult,Cat.Responses.Abstractions.ICatError[]).errorList'></a>

`errorList` [ICatError](..\Cat.Responses.Abstractions\ICatError.md 'Cat\.Responses\.Abstractions\.ICatError')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The errors\.

#### Returns
[ICatWorkflowResponse](..\Cat.FluentWorkflows.Abstractions\ICatWorkflowResponse.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowResponse')  
The response, with the errors\.

<a name='Cat.FluentWorkflows.CatWorkflowResponse.Failed(Cat.FluentWorkflows.Abstractions.CatStepExecutionResult,System.Collections.Generic.IReadOnlyList_Cat.Responses.Abstractions.ICatError_)'></a>

## CatWorkflowResponse\.Failed\(CatStepExecutionResult, IReadOnlyList\<ICatError\>\) Method

Creates a response for a step that failed\.
Use [BreakCascade](..\Cat.FluentWorkflows.Abstractions\CatStepExecutionResult.md#Cat.FluentWorkflows.Abstractions.CatStepExecutionResult.BreakCascade 'Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\.BreakCascade') as the result to end the workflow on the failure\.
With any other result the workflow goes on, and the errors are still part of the final response\.

```csharp
public static Cat.FluentWorkflows.Abstractions.ICatWorkflowResponse Failed(Cat.FluentWorkflows.Abstractions.CatStepExecutionResult workflowResult, System.Collections.Generic.IReadOnlyList<Cat.Responses.Abstractions.ICatError> errorList);
```
#### Parameters

<a name='Cat.FluentWorkflows.CatWorkflowResponse.Failed(Cat.FluentWorkflows.Abstractions.CatStepExecutionResult,System.Collections.Generic.IReadOnlyList_Cat.Responses.Abstractions.ICatError_).workflowResult'></a>

`workflowResult` [CatStepExecutionResult](..\Cat.FluentWorkflows.Abstractions\CatStepExecutionResult.md 'Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult')

What the step processor does next\.

<a name='Cat.FluentWorkflows.CatWorkflowResponse.Failed(Cat.FluentWorkflows.Abstractions.CatStepExecutionResult,System.Collections.Generic.IReadOnlyList_Cat.Responses.Abstractions.ICatError_).errorList'></a>

`errorList` [System\.Collections\.Generic\.IReadOnlyList&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1 'System\.Collections\.Generic\.IReadOnlyList\`1')[ICatError](..\Cat.Responses.Abstractions\ICatError.md 'Cat\.Responses\.Abstractions\.ICatError')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1 'System\.Collections\.Generic\.IReadOnlyList\`1')

The errors\.

#### Returns
[ICatWorkflowResponse](..\Cat.FluentWorkflows.Abstractions\ICatWorkflowResponse.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowResponse')  
The response, with the errors\.