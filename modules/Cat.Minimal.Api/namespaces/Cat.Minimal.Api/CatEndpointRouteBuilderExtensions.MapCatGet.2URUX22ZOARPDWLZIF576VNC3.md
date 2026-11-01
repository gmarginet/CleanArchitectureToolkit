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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.MINIMAL.API](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Minimal\.Api Assembly](index.md 'index') >> [Cat\.Minimal\.Api Namespace](Cat.Minimal.Api.md 'Cat\.Minimal\.Api') >> [CatEndpointRouteBuilderExtensions Class](CatEndpointRouteBuilderExtensions.md 'Cat\.Minimal\.Api\.CatEndpointRouteBuilderExtensions')

## CatEndpointRouteBuilderExtensions\.MapCatGet\<TRequest,TResponse\>\(this IEndpointRouteBuilder, string, CatResponseType\[\]\) Method

Maps a GET endpoint that returns the value of the service request\.

```csharp
public static Microsoft.AspNetCore.Builder.RouteHandlerBuilder MapCatGet<TRequest,TResponse>(this Microsoft.AspNetCore.Routing.IEndpointRouteBuilder builder, string pattern, params Cat.Responses.Abstractions.CatResponseType[] responseTypes)
    where TRequest : class, Cat.ServiceRequests.Abstractions.ICatServiceRequest<TResponse>;
```
#### Type parameters

<a name='Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.MapCatGet_TRequest,TResponse_(thisMicrosoft.AspNetCore.Routing.IEndpointRouteBuilder,string,Cat.Responses.Abstractions.CatResponseType[]).TRequest'></a>

`TRequest`

The service request\. Its properties bind from the route, the query string and the headers\.

<a name='Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.MapCatGet_TRequest,TResponse_(thisMicrosoft.AspNetCore.Routing.IEndpointRouteBuilder,string,Cat.Responses.Abstractions.CatResponseType[]).TResponse'></a>

`TResponse`

The type of the value in the response body\.
#### Parameters

<a name='Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.MapCatGet_TRequest,TResponse_(thisMicrosoft.AspNetCore.Routing.IEndpointRouteBuilder,string,Cat.Responses.Abstractions.CatResponseType[]).builder'></a>

`builder` [Microsoft\.AspNetCore\.Routing\.IEndpointRouteBuilder](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.routing.iendpointroutebuilder 'Microsoft\.AspNetCore\.Routing\.IEndpointRouteBuilder')

The route builder to add the endpoint to\.

<a name='Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.MapCatGet_TRequest,TResponse_(thisMicrosoft.AspNetCore.Routing.IEndpointRouteBuilder,string,Cat.Responses.Abstractions.CatResponseType[]).pattern'></a>

`pattern` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The route pattern of the endpoint\.

<a name='Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.MapCatGet_TRequest,TResponse_(thisMicrosoft.AspNetCore.Routing.IEndpointRouteBuilder,string,Cat.Responses.Abstractions.CatResponseType[]).responseTypes'></a>

`responseTypes` [CatResponseType](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.md 'Cat\.Responses\.Abstractions\.CatResponseType')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The response types the handler returns\. Defaults to [Ok](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.Ok.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Ok')\.

#### Returns
[Microsoft\.AspNetCore\.Builder\.RouteHandlerBuilder](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.builder.routehandlerbuilder 'Microsoft\.AspNetCore\.Builder\.RouteHandlerBuilder')  
The builder of the endpoint, to chain more calls\.