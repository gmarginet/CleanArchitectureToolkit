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
            <img src='../../../../resources/logo/CatLogo.svg' alt='' width='200' style='padding: 15px; float: right; background: #121314; border-radius: 10px'/>
        </td>
    </tr>
    <tr>
        <td colspan='6' markdown='1' style='padding-left: 0; padding-right: 0; padding-top: 15px; padding-bottom: 0; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.SERVICEREQUESTS](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.ServiceRequests\.Minimal\.Api Assembly](index.md 'index') >> [Cat\.ServiceRequests\.Minimal\.Api Namespace](Cat.ServiceRequests.Minimal.Api.md 'Cat\.ServiceRequests\.Minimal\.Api')

## PatchDocumentRequest\<TRouteParameters,TModel\> Class

A service request that carries a JSON Patch document and the route values that identify the resource to patch\.

```csharp
public record PatchDocumentRequest<TRouteParameters,TModel> : Cat.ServiceRequests.Abstractions.ICatServiceRequest, System.IEquatable<Cat.ServiceRequests.Minimal.Api.PatchDocumentRequest<TRouteParameters, TModel>>
    where TModel : class
```
#### Type parameters

<a name='Cat.ServiceRequests.Minimal.Api.PatchDocumentRequest_TRouteParameters,TModel_.TRouteParameters'></a>

`TRouteParameters`

The type that holds the route and query values, such as the id of the resource\.

<a name='Cat.ServiceRequests.Minimal.Api.PatchDocumentRequest_TRouteParameters,TModel_.TModel'></a>

`TModel`

The model the patch operations apply to\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → PatchDocumentRequest\<TRouteParameters,TModel\>

Implements [ICatServiceRequest](../../../Cat.ServiceRequests/namespaces/Cat.ServiceRequests.Abstractions/ICatServiceRequest.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest'), [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[Cat\.ServiceRequests\.Minimal\.Api\.PatchDocumentRequest&lt;](PatchDocumentRequest_TRouteParameters,TModel_.md 'Cat\.ServiceRequests\.Minimal\.Api\.PatchDocumentRequest\<TRouteParameters,TModel\>')[TRouteParameters](PatchDocumentRequest_TRouteParameters,TModel_.md#Cat.ServiceRequests.Minimal.Api.PatchDocumentRequest_TRouteParameters,TModel_.TRouteParameters 'Cat\.ServiceRequests\.Minimal\.Api\.PatchDocumentRequest\<TRouteParameters,TModel\>\.TRouteParameters')[,](PatchDocumentRequest_TRouteParameters,TModel_.md 'Cat\.ServiceRequests\.Minimal\.Api\.PatchDocumentRequest\<TRouteParameters,TModel\>')[TModel](PatchDocumentRequest_TRouteParameters,TModel_.md#Cat.ServiceRequests.Minimal.Api.PatchDocumentRequest_TRouteParameters,TModel_.TModel 'Cat\.ServiceRequests\.Minimal\.Api\.PatchDocumentRequest\<TRouteParameters,TModel\>\.TModel')[&gt;](PatchDocumentRequest_TRouteParameters,TModel_.md 'Cat\.ServiceRequests\.Minimal\.Api\.PatchDocumentRequest\<TRouteParameters,TModel\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [PatchDocumentRequest\(TRouteParameters, JsonPatchDocument&lt;TModel&gt;\)](PatchDocumentRequest_TRouteParameters,TModel_..ctor.BCG3MW1JTERKXQ23T48BUU4W9.md 'Cat\.ServiceRequests\.Minimal\.Api\.PatchDocumentRequest\<TRouteParameters,TModel\>\.PatchDocumentRequest\(TRouteParameters, Microsoft\.AspNetCore\.JsonPatch\.SystemTextJson\.JsonPatchDocument\<TModel\>\)') | A service request that carries a JSON Patch document and the route values that identify the resource to patch\. |

| Properties | |
| :--- | :--- |
| [PatchDocument](PatchDocumentRequest_TRouteParameters,TModel_.PatchDocument.md 'Cat\.ServiceRequests\.Minimal\.Api\.PatchDocumentRequest\<TRouteParameters,TModel\>\.PatchDocument') | The patch operations to apply to the model\. |
| [RouteParameters](PatchDocumentRequest_TRouteParameters,TModel_.RouteParameters.md 'Cat\.ServiceRequests\.Minimal\.Api\.PatchDocumentRequest\<TRouteParameters,TModel\>\.RouteParameters') | The route and query values that identify the resource to patch\. |
