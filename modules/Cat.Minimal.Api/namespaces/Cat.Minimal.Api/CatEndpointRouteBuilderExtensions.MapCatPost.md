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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.MINIMAL.API](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Minimal\.Api Assembly](index.md 'index') >> [Cat\.Minimal\.Api Namespace](Cat.Minimal.Api.md 'Cat\.Minimal\.Api') >> [CatEndpointRouteBuilderExtensions Class](CatEndpointRouteBuilderExtensions.md 'Cat\.Minimal\.Api\.CatEndpointRouteBuilderExtensions')

## CatEndpointRouteBuilderExtensions\.MapCatPost Method

| Overloads | |
| :--- | :--- |
| [MapCatPost&lt;TRequest,TResponse&gt;\(this IEndpointRouteBuilder, string, CatResponseType\[\]\)](CatEndpointRouteBuilderExtensions.MapCatPost.md#Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.MapCatPost_TRequest,TResponse_(thisMicrosoft.AspNetCore.Routing.IEndpointRouteBuilder,string,Cat.Responses.Abstractions.CatResponseType[]) 'Cat\.Minimal\.Api\.CatEndpointRouteBuilderExtensions\.MapCatPost\<TRequest,TResponse\>\(this Microsoft\.AspNetCore\.Routing\.IEndpointRouteBuilder, string, Cat\.Responses\.Abstractions\.CatResponseType\[\]\)') | Maps a POST endpoint that creates a resource and returns it\. A [Created](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.Created.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Created') response carries the created value in its body and has no Location header\. Use the overload with a `location` argument to add the header\. |
| [MapCatPost&lt;TRequest,TResponse&gt;\(this IEndpointRouteBuilder, string, Func&lt;TResponse,string&gt;, CatResponseType\[\]\)](CatEndpointRouteBuilderExtensions.MapCatPost.md#Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.MapCatPost_TRequest,TResponse_(thisMicrosoft.AspNetCore.Routing.IEndpointRouteBuilder,string,System.Func_TResponse,string_,Cat.Responses.Abstractions.CatResponseType[]) 'Cat\.Minimal\.Api\.CatEndpointRouteBuilderExtensions\.MapCatPost\<TRequest,TResponse\>\(this Microsoft\.AspNetCore\.Routing\.IEndpointRouteBuilder, string, System\.Func\<TResponse,string\>, Cat\.Responses\.Abstractions\.CatResponseType\[\]\)') | Maps a POST endpoint that creates a resource and returns it\. A [Created](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.Created.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Created') response carries the created value in its body and a Location header built by [location](CatEndpointRouteBuilderExtensions.MapCatPost.md#Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.MapCatPost_TRequest,TResponse_(thisMicrosoft.AspNetCore.Routing.IEndpointRouteBuilder,string,System.Func_TResponse,string_,Cat.Responses.Abstractions.CatResponseType[]).location 'Cat\.Minimal\.Api\.CatEndpointRouteBuilderExtensions\.MapCatPost\<TRequest,TResponse\>\(this Microsoft\.AspNetCore\.Routing\.IEndpointRouteBuilder, string, System\.Func\<TResponse,string\>, Cat\.Responses\.Abstractions\.CatResponseType\[\]\)\.location')\. |
| [MapCatPost&lt;TRequest&gt;\(this IEndpointRouteBuilder, string, CatResponseType\[\]\)](CatEndpointRouteBuilderExtensions.MapCatPost.md#Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.MapCatPost_TRequest_(thisMicrosoft.AspNetCore.Routing.IEndpointRouteBuilder,string,Cat.Responses.Abstractions.CatResponseType[]) 'Cat\.Minimal\.Api\.CatEndpointRouteBuilderExtensions\.MapCatPost\<TRequest\>\(this Microsoft\.AspNetCore\.Routing\.IEndpointRouteBuilder, string, Cat\.Responses\.Abstractions\.CatResponseType\[\]\)') | Maps a POST endpoint that creates a resource\. A [Created](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.Created.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Created') response has no body and no Location header\. |

<a name='Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.MapCatPost_TRequest,TResponse_(thisMicrosoft.AspNetCore.Routing.IEndpointRouteBuilder,string,Cat.Responses.Abstractions.CatResponseType[])'></a>

## CatEndpointRouteBuilderExtensions\.MapCatPost\<TRequest,TResponse\>\(this IEndpointRouteBuilder, string, CatResponseType\[\]\) Method

Maps a POST endpoint that creates a resource and returns it\. A [Created](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.Created.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Created') response
carries the created value in its body and has no Location header\.
Use the overload with a `location` argument to add the header\.

```csharp
public static Microsoft.AspNetCore.Builder.RouteHandlerBuilder MapCatPost<TRequest,TResponse>(this Microsoft.AspNetCore.Routing.IEndpointRouteBuilder builder, string pattern, params Cat.Responses.Abstractions.CatResponseType[] responseTypes)
    where TRequest : class, Cat.ServiceRequests.Abstractions.ICatServiceRequest<TResponse>;
```
#### Type parameters

<a name='Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.MapCatPost_TRequest,TResponse_(thisMicrosoft.AspNetCore.Routing.IEndpointRouteBuilder,string,Cat.Responses.Abstractions.CatResponseType[]).TRequest'></a>

`TRequest`

The service request\. Give a property `[FromBody]` to read the request body\.

<a name='Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.MapCatPost_TRequest,TResponse_(thisMicrosoft.AspNetCore.Routing.IEndpointRouteBuilder,string,Cat.Responses.Abstractions.CatResponseType[]).TResponse'></a>

`TResponse`

The type of the created value in the response body\.
#### Parameters

<a name='Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.MapCatPost_TRequest,TResponse_(thisMicrosoft.AspNetCore.Routing.IEndpointRouteBuilder,string,Cat.Responses.Abstractions.CatResponseType[]).builder'></a>

`builder` [Microsoft\.AspNetCore\.Routing\.IEndpointRouteBuilder](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.routing.iendpointroutebuilder 'Microsoft\.AspNetCore\.Routing\.IEndpointRouteBuilder')

The route builder to add the endpoint to\.

<a name='Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.MapCatPost_TRequest,TResponse_(thisMicrosoft.AspNetCore.Routing.IEndpointRouteBuilder,string,Cat.Responses.Abstractions.CatResponseType[]).pattern'></a>

`pattern` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The route pattern of the endpoint\.

<a name='Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.MapCatPost_TRequest,TResponse_(thisMicrosoft.AspNetCore.Routing.IEndpointRouteBuilder,string,Cat.Responses.Abstractions.CatResponseType[]).responseTypes'></a>

`responseTypes` [CatResponseType](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.md 'Cat\.Responses\.Abstractions\.CatResponseType')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The response types the handler returns\. Defaults to [Created](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.Created.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Created')\.

#### Returns
[Microsoft\.AspNetCore\.Builder\.RouteHandlerBuilder](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.builder.routehandlerbuilder 'Microsoft\.AspNetCore\.Builder\.RouteHandlerBuilder')  
The builder of the endpoint, to chain more calls\.

<a name='Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.MapCatPost_TRequest,TResponse_(thisMicrosoft.AspNetCore.Routing.IEndpointRouteBuilder,string,System.Func_TResponse,string_,Cat.Responses.Abstractions.CatResponseType[])'></a>

## CatEndpointRouteBuilderExtensions\.MapCatPost\<TRequest,TResponse\>\(this IEndpointRouteBuilder, string, Func\<TResponse,string\>, CatResponseType\[\]\) Method

Maps a POST endpoint that creates a resource and returns it\. A [Created](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.Created.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Created') response
carries the created value in its body and a Location header built by [location](CatEndpointRouteBuilderExtensions.MapCatPost.md#Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.MapCatPost_TRequest,TResponse_(thisMicrosoft.AspNetCore.Routing.IEndpointRouteBuilder,string,System.Func_TResponse,string_,Cat.Responses.Abstractions.CatResponseType[]).location 'Cat\.Minimal\.Api\.CatEndpointRouteBuilderExtensions\.MapCatPost\<TRequest,TResponse\>\(this Microsoft\.AspNetCore\.Routing\.IEndpointRouteBuilder, string, System\.Func\<TResponse,string\>, Cat\.Responses\.Abstractions\.CatResponseType\[\]\)\.location')\.

```csharp
public static Microsoft.AspNetCore.Builder.RouteHandlerBuilder MapCatPost<TRequest,TResponse>(this Microsoft.AspNetCore.Routing.IEndpointRouteBuilder builder, string pattern, System.Func<TResponse,string?>? location, params Cat.Responses.Abstractions.CatResponseType[] responseTypes)
    where TRequest : class, Cat.ServiceRequests.Abstractions.ICatServiceRequest<TResponse>;
```
#### Type parameters

<a name='Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.MapCatPost_TRequest,TResponse_(thisMicrosoft.AspNetCore.Routing.IEndpointRouteBuilder,string,System.Func_TResponse,string_,Cat.Responses.Abstractions.CatResponseType[]).TRequest'></a>

`TRequest`

The service request\. Give a property `[FromBody]` to read the request body\.

<a name='Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.MapCatPost_TRequest,TResponse_(thisMicrosoft.AspNetCore.Routing.IEndpointRouteBuilder,string,System.Func_TResponse,string_,Cat.Responses.Abstractions.CatResponseType[]).TResponse'></a>

`TResponse`

The type of the created value in the response body\.
#### Parameters

<a name='Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.MapCatPost_TRequest,TResponse_(thisMicrosoft.AspNetCore.Routing.IEndpointRouteBuilder,string,System.Func_TResponse,string_,Cat.Responses.Abstractions.CatResponseType[]).builder'></a>

`builder` [Microsoft\.AspNetCore\.Routing\.IEndpointRouteBuilder](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.routing.iendpointroutebuilder 'Microsoft\.AspNetCore\.Routing\.IEndpointRouteBuilder')

The route builder to add the endpoint to\.

<a name='Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.MapCatPost_TRequest,TResponse_(thisMicrosoft.AspNetCore.Routing.IEndpointRouteBuilder,string,System.Func_TResponse,string_,Cat.Responses.Abstractions.CatResponseType[]).pattern'></a>

`pattern` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The route pattern of the endpoint\.

<a name='Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.MapCatPost_TRequest,TResponse_(thisMicrosoft.AspNetCore.Routing.IEndpointRouteBuilder,string,System.Func_TResponse,string_,Cat.Responses.Abstractions.CatResponseType[]).location'></a>

`location` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TResponse](CatEndpointRouteBuilderExtensions.MapCatPost.md#Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.MapCatPost_TRequest,TResponse_(thisMicrosoft.AspNetCore.Routing.IEndpointRouteBuilder,string,System.Func_TResponse,string_,Cat.Responses.Abstractions.CatResponseType[]).TResponse 'Cat\.Minimal\.Api\.CatEndpointRouteBuilderExtensions\.MapCatPost\<TRequest,TResponse\>\(this Microsoft\.AspNetCore\.Routing\.IEndpointRouteBuilder, string, System\.Func\<TResponse,string\>, Cat\.Responses\.Abstractions\.CatResponseType\[\]\)\.TResponse')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

Builds the Location header from the created value, for example `todo => $"/todo/{todo.Id}"`\.
The response has no Location header when this is `null` or returns `null`\.

<a name='Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.MapCatPost_TRequest,TResponse_(thisMicrosoft.AspNetCore.Routing.IEndpointRouteBuilder,string,System.Func_TResponse,string_,Cat.Responses.Abstractions.CatResponseType[]).responseTypes'></a>

`responseTypes` [CatResponseType](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.md 'Cat\.Responses\.Abstractions\.CatResponseType')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The response types the handler returns\. Defaults to [Created](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.Created.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Created')\.

#### Returns
[Microsoft\.AspNetCore\.Builder\.RouteHandlerBuilder](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.builder.routehandlerbuilder 'Microsoft\.AspNetCore\.Builder\.RouteHandlerBuilder')  
The builder of the endpoint, to chain more calls\.

<a name='Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.MapCatPost_TRequest_(thisMicrosoft.AspNetCore.Routing.IEndpointRouteBuilder,string,Cat.Responses.Abstractions.CatResponseType[])'></a>

## CatEndpointRouteBuilderExtensions\.MapCatPost\<TRequest\>\(this IEndpointRouteBuilder, string, CatResponseType\[\]\) Method

Maps a POST endpoint that creates a resource\. A [Created](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.Created.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Created') response has no body
and no Location header\.

```csharp
public static Microsoft.AspNetCore.Builder.RouteHandlerBuilder MapCatPost<TRequest>(this Microsoft.AspNetCore.Routing.IEndpointRouteBuilder builder, string pattern, params Cat.Responses.Abstractions.CatResponseType[] responseTypes)
    where TRequest : class, Cat.ServiceRequests.Abstractions.ICatServiceRequest;
```
#### Type parameters

<a name='Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.MapCatPost_TRequest_(thisMicrosoft.AspNetCore.Routing.IEndpointRouteBuilder,string,Cat.Responses.Abstractions.CatResponseType[]).TRequest'></a>

`TRequest`

The service request\. Give a property `[FromBody]` to read the request body\.
#### Parameters

<a name='Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.MapCatPost_TRequest_(thisMicrosoft.AspNetCore.Routing.IEndpointRouteBuilder,string,Cat.Responses.Abstractions.CatResponseType[]).builder'></a>

`builder` [Microsoft\.AspNetCore\.Routing\.IEndpointRouteBuilder](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.routing.iendpointroutebuilder 'Microsoft\.AspNetCore\.Routing\.IEndpointRouteBuilder')

The route builder to add the endpoint to\.

<a name='Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.MapCatPost_TRequest_(thisMicrosoft.AspNetCore.Routing.IEndpointRouteBuilder,string,Cat.Responses.Abstractions.CatResponseType[]).pattern'></a>

`pattern` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The route pattern of the endpoint\.

<a name='Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.MapCatPost_TRequest_(thisMicrosoft.AspNetCore.Routing.IEndpointRouteBuilder,string,Cat.Responses.Abstractions.CatResponseType[]).responseTypes'></a>

`responseTypes` [CatResponseType](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.md 'Cat\.Responses\.Abstractions\.CatResponseType')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The response types the handler returns\. Defaults to [Created](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.Created.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Created')\.

#### Returns
[Microsoft\.AspNetCore\.Builder\.RouteHandlerBuilder](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.builder.routehandlerbuilder 'Microsoft\.AspNetCore\.Builder\.RouteHandlerBuilder')  
The builder of the endpoint, to chain more calls\.