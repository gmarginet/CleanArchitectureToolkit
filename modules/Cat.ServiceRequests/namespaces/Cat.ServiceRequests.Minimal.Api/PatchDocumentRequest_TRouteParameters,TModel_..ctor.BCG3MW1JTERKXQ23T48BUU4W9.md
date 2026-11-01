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
  
##### >> [Cat\.ServiceRequests\.Minimal\.Api Assembly](index.md 'index') >> [Cat\.ServiceRequests\.Minimal\.Api Namespace](Cat.ServiceRequests.Minimal.Api.md 'Cat\.ServiceRequests\.Minimal\.Api') >> [PatchDocumentRequest&lt;TRouteParameters,TModel&gt; Class](PatchDocumentRequest_TRouteParameters,TModel_.md 'Cat\.ServiceRequests\.Minimal\.Api\.PatchDocumentRequest\<TRouteParameters,TModel\>')

## PatchDocumentRequest\(TRouteParameters, JsonPatchDocument\<TModel\>\) Constructor

A service request that carries a JSON Patch document and the route values that identify the resource to patch\.

```csharp
public PatchDocumentRequest(TRouteParameters RouteParameters, Microsoft.AspNetCore.JsonPatch.SystemTextJson.JsonPatchDocument<TModel> PatchDocument);
```
#### Parameters

<a name='Cat.ServiceRequests.Minimal.Api.PatchDocumentRequest_TRouteParameters,TModel_.PatchDocumentRequest(TRouteParameters,Microsoft.AspNetCore.JsonPatch.SystemTextJson.JsonPatchDocument_TModel_).RouteParameters'></a>

`RouteParameters` [TRouteParameters](PatchDocumentRequest_TRouteParameters,TModel_.md#Cat.ServiceRequests.Minimal.Api.PatchDocumentRequest_TRouteParameters,TModel_.TRouteParameters 'Cat\.ServiceRequests\.Minimal\.Api\.PatchDocumentRequest\<TRouteParameters,TModel\>\.TRouteParameters')

The route and query values that identify the resource to patch\.

<a name='Cat.ServiceRequests.Minimal.Api.PatchDocumentRequest_TRouteParameters,TModel_.PatchDocumentRequest(TRouteParameters,Microsoft.AspNetCore.JsonPatch.SystemTextJson.JsonPatchDocument_TModel_).PatchDocument'></a>

`PatchDocument` [Microsoft\.AspNetCore\.JsonPatch\.SystemTextJson\.JsonPatchDocument&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.jsonpatch.systemtextjson.jsonpatchdocument-1 'Microsoft\.AspNetCore\.JsonPatch\.SystemTextJson\.JsonPatchDocument\`1')[TModel](PatchDocumentRequest_TRouteParameters,TModel_.md#Cat.ServiceRequests.Minimal.Api.PatchDocumentRequest_TRouteParameters,TModel_.TModel 'Cat\.ServiceRequests\.Minimal\.Api\.PatchDocumentRequest\<TRouteParameters,TModel\>\.TModel')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.jsonpatch.systemtextjson.jsonpatchdocument-1 'Microsoft\.AspNetCore\.JsonPatch\.SystemTextJson\.JsonPatchDocument\`1')

The patch operations to apply to the model\.