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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.MINIMAL.API](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Minimal\.Api Assembly](index.md 'index') >> [Cat\.Minimal\.Api Namespace](Cat.Minimal.Api.md 'Cat\.Minimal\.Api') >> [CatEndpointRouteBuilderExtensions Class](CatEndpointRouteBuilderExtensions.md 'Cat\.Minimal\.Api\.CatEndpointRouteBuilderExtensions')

## CatEndpointRouteBuilderExtensions\.ProducesCatResponseTypes\(this RouteHandlerBuilder, CatResponseType\[\], Type, Type\) Method

Adds one OpenAPI response per allowed response type, plus 415 when the endpoint reads a body\.

```csharp
private static Microsoft.AspNetCore.Builder.RouteHandlerBuilder ProducesCatResponseTypes(this Microsoft.AspNetCore.Builder.RouteHandlerBuilder handlerBuilder, Cat.Responses.Abstractions.CatResponseType[] allowed, System.Type? okValueType=null, System.Type? createdValueType=null);
```
#### Parameters

<a name='Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.ProducesCatResponseTypes(thisMicrosoft.AspNetCore.Builder.RouteHandlerBuilder,Cat.Responses.Abstractions.CatResponseType[],System.Type,System.Type).handlerBuilder'></a>

`handlerBuilder` [Microsoft\.AspNetCore\.Builder\.RouteHandlerBuilder](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.builder.routehandlerbuilder 'Microsoft\.AspNetCore\.Builder\.RouteHandlerBuilder')

The endpoint to describe\.

<a name='Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.ProducesCatResponseTypes(thisMicrosoft.AspNetCore.Builder.RouteHandlerBuilder,Cat.Responses.Abstractions.CatResponseType[],System.Type,System.Type).allowed'></a>

`allowed` [CatResponseType](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.md 'Cat\.Responses\.Abstractions\.CatResponseType')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The response types the endpoint allows\.

<a name='Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.ProducesCatResponseTypes(thisMicrosoft.AspNetCore.Builder.RouteHandlerBuilder,Cat.Responses.Abstractions.CatResponseType[],System.Type,System.Type).okValueType'></a>

`okValueType` [System\.Type](https://learn.microsoft.com/en-us/dotnet/api/system.type 'System\.Type')

The type of the body of an Ok response\. `null` when it has no body\.

<a name='Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.ProducesCatResponseTypes(thisMicrosoft.AspNetCore.Builder.RouteHandlerBuilder,Cat.Responses.Abstractions.CatResponseType[],System.Type,System.Type).createdValueType'></a>

`createdValueType` [System\.Type](https://learn.microsoft.com/en-us/dotnet/api/system.type 'System\.Type')

The type of the body of a Created response\. `null` when it has no body\.

#### Returns
[Microsoft\.AspNetCore\.Builder\.RouteHandlerBuilder](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.builder.routehandlerbuilder 'Microsoft\.AspNetCore\.Builder\.RouteHandlerBuilder')  
The builder of the endpoint\.