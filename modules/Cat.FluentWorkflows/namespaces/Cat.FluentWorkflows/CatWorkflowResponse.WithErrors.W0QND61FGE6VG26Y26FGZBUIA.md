<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows](Cat.FluentWorkflows.md 'Cat\.FluentWorkflows') > [CatWorkflowResponse](CatWorkflowResponse.md 'Cat\.FluentWorkflows\.CatWorkflowResponse')

## CatWorkflowResponse\.WithErrors\(ICatWorkflowResponse, List\<ICatError\>\) Method

Gives a response all the errors that were collected on the way\.

```csharp
internal static Cat.FluentWorkflows.Abstractions.ICatWorkflowResponse WithErrors(Cat.FluentWorkflows.Abstractions.ICatWorkflowResponse last, System.Collections.Generic.List<Cat.Responses.Abstractions.ICatError> allErrors);
```
#### Parameters

<a name='Cat.FluentWorkflows.CatWorkflowResponse.WithErrors(Cat.FluentWorkflows.Abstractions.ICatWorkflowResponse,System.Collections.Generic.List_Cat.Responses.Abstractions.ICatError_).last'></a>

`last` [ICatWorkflowResponse](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowResponse.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowResponse')

The response of the last step\. Its result is kept\.

<a name='Cat.FluentWorkflows.CatWorkflowResponse.WithErrors(Cat.FluentWorkflows.Abstractions.ICatWorkflowResponse,System.Collections.Generic.List_Cat.Responses.Abstractions.ICatError_).allErrors'></a>

`allErrors` [System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[ICatError](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatError.md 'Cat\.Responses\.Abstractions\.ICatError')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

Every error collected, including the ones of [last](CatWorkflowResponse.WithErrors.W0QND61FGE6VG26Y26FGZBUIA.md#Cat.FluentWorkflows.CatWorkflowResponse.WithErrors(Cat.FluentWorkflows.Abstractions.ICatWorkflowResponse,System.Collections.Generic.List_Cat.Responses.Abstractions.ICatError_).last 'Cat\.FluentWorkflows\.CatWorkflowResponse\.WithErrors\(Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowResponse, System\.Collections\.Generic\.List\<Cat\.Responses\.Abstractions\.ICatError\>\)\.last')\.

#### Returns
[ICatWorkflowResponse](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowResponse.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowResponse')  
[last](CatWorkflowResponse.WithErrors.W0QND61FGE6VG26Y26FGZBUIA.md#Cat.FluentWorkflows.CatWorkflowResponse.WithErrors(Cat.FluentWorkflows.Abstractions.ICatWorkflowResponse,System.Collections.Generic.List_Cat.Responses.Abstractions.ICatError_).last 'Cat\.FluentWorkflows\.CatWorkflowResponse\.WithErrors\(Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowResponse, System\.Collections\.Generic\.List\<Cat\.Responses\.Abstractions\.ICatError\>\)\.last') when it already holds all the errors, otherwise a response with all of them\.