<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows](Cat.FluentWorkflows.md 'Cat\.FluentWorkflows') > [CatWorkflowResponse](CatWorkflowResponse.md 'Cat\.FluentWorkflows\.CatWorkflowResponse')

## CatWorkflowResponse Constructors

| Overloads | |
| :--- | :--- |
| [CatWorkflowResponse\(CatStepExecutionResult\)](CatWorkflowResponse.CatWorkflowResponse.md#Cat.FluentWorkflows.CatWorkflowResponse.CatWorkflowResponse(Cat.FluentWorkflows.Abstractions.CatStepExecutionResult) 'Cat\.FluentWorkflows\.CatWorkflowResponse\.CatWorkflowResponse\(Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\)') | |
| [CatWorkflowResponse\(CatStepExecutionResult, IReadOnlyList&lt;ICatError&gt;\)](CatWorkflowResponse.CatWorkflowResponse.md#Cat.FluentWorkflows.CatWorkflowResponse.CatWorkflowResponse(Cat.FluentWorkflows.Abstractions.CatStepExecutionResult,System.Collections.Generic.IReadOnlyList_Cat.Responses.Abstractions.ICatError_) 'Cat\.FluentWorkflows\.CatWorkflowResponse\.CatWorkflowResponse\(Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult, System\.Collections\.Generic\.IReadOnlyList\<Cat\.Responses\.Abstractions\.ICatError\>\)') | |

<a name='Cat.FluentWorkflows.CatWorkflowResponse.CatWorkflowResponse(Cat.FluentWorkflows.Abstractions.CatStepExecutionResult)'></a>

## CatWorkflowResponse\(CatStepExecutionResult\) Constructor

```csharp
internal CatWorkflowResponse(Cat.FluentWorkflows.Abstractions.CatStepExecutionResult workflowResult);
```
#### Parameters

<a name='Cat.FluentWorkflows.CatWorkflowResponse.CatWorkflowResponse(Cat.FluentWorkflows.Abstractions.CatStepExecutionResult).workflowResult'></a>

`workflowResult` [CatStepExecutionResult](../Cat.FluentWorkflows.Abstractions/CatStepExecutionResult.md 'Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult')

<a name='Cat.FluentWorkflows.CatWorkflowResponse.CatWorkflowResponse(Cat.FluentWorkflows.Abstractions.CatStepExecutionResult,System.Collections.Generic.IReadOnlyList_Cat.Responses.Abstractions.ICatError_)'></a>

## CatWorkflowResponse\(CatStepExecutionResult, IReadOnlyList\<ICatError\>\) Constructor

```csharp
internal CatWorkflowResponse(Cat.FluentWorkflows.Abstractions.CatStepExecutionResult workflowResult, System.Collections.Generic.IReadOnlyList<Cat.Responses.Abstractions.ICatError> errorList);
```
#### Parameters

<a name='Cat.FluentWorkflows.CatWorkflowResponse.CatWorkflowResponse(Cat.FluentWorkflows.Abstractions.CatStepExecutionResult,System.Collections.Generic.IReadOnlyList_Cat.Responses.Abstractions.ICatError_).workflowResult'></a>

`workflowResult` [CatStepExecutionResult](../Cat.FluentWorkflows.Abstractions/CatStepExecutionResult.md 'Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult')

<a name='Cat.FluentWorkflows.CatWorkflowResponse.CatWorkflowResponse(Cat.FluentWorkflows.Abstractions.CatStepExecutionResult,System.Collections.Generic.IReadOnlyList_Cat.Responses.Abstractions.ICatError_).errorList'></a>

`errorList` [System\.Collections\.Generic\.IReadOnlyList&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1 'System\.Collections\.Generic\.IReadOnlyList\`1')[ICatError](../Cat.Responses.Abstractions/ICatError.md 'Cat\.Responses\.Abstractions\.ICatError')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1 'System\.Collections\.Generic\.IReadOnlyList\`1')