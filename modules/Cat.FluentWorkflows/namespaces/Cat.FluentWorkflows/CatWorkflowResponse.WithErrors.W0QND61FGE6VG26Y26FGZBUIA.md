<link href="../../../../resources/styles/style.css" rel="stylesheet"/>
<table>
    <tr>
        <td colspan='6' style='text-align: center; font-weight: bold; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>
             Clean Architecture Toolkit for .NET
        </td>
    </tr>
    <tr>
        <td colspan='5' style='padding: 0; vertical-align: middle; border: none;'>
            Clean Architecture Toolkit is a clean, modular architecture foundation for .NET applications.<br>
            It embraces SOLID principles and focuses on maintainability, testability, and scalability through clear boundaries and pluggable design.</td>
        <td style='padding: 0; border: none;' width='220'>
            <img src='../../../../resources/logo/CatLogo-RoundedCorners-320x160.png' alt='' width='200' style='float: right;'/>
        </td>
    </tr>
    <tr>
        <td colspan='6' markdown='1' style='padding-left: 0; padding-right: 0; padding-top: 15px; padding-bottom: 0; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>

|&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[CAT.FLUENTWORKFLOWS](../../README.md)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.FluentWorkflows Assembly](index.md 'index') >> [Cat\.FluentWorkflows Namespace](Cat.FluentWorkflows.md 'Cat\.FluentWorkflows') >> [CatWorkflowResponse Class](CatWorkflowResponse.md 'Cat\.FluentWorkflows\.CatWorkflowResponse')

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