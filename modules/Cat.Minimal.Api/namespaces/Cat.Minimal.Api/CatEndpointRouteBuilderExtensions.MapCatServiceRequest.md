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

|&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[CAT.MINIMAL.API](../../README.md)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Minimal\.Api Assembly](index.md 'index') >> [Cat\.Minimal\.Api Namespace](Cat.Minimal.Api.md 'Cat\.Minimal\.Api') >> [CatEndpointRouteBuilderExtensions Class](CatEndpointRouteBuilderExtensions.md 'Cat\.Minimal\.Api\.CatEndpointRouteBuilderExtensions')

## CatEndpointRouteBuilderExtensions\.MapCatServiceRequest Method

| Overloads | |
| :--- | :--- |
| [MapCatServiceRequest&lt;TRequest,TResponse&gt;\(this IEndpointRouteBuilder, string\)](CatEndpointRouteBuilderExtensions.MapCatServiceRequest.md#Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.MapCatServiceRequest_TRequest,TResponse_(thisMicrosoft.AspNetCore.Routing.IEndpointRouteBuilder,string) 'Cat\.Minimal\.Api\.CatEndpointRouteBuilderExtensions\.MapCatServiceRequest\<TRequest,TResponse\>\(this Microsoft\.AspNetCore\.Routing\.IEndpointRouteBuilder, string\)') | Maps a POST endpoint that runs a service request with a payload\. A succeeded response gives 200 with the payload as JSON\. A failed response gives [CatProblemDetails](CatProblemDetails.md 'Cat\.Minimal\.Api\.CatProblemDetails') with status 400, 404, 401 or 500, depending on the response type\. An empty body gives a 400, unless the request type has a parameterless constructor\. |
| [MapCatServiceRequest&lt;TRequest&gt;\(this IEndpointRouteBuilder, string\)](CatEndpointRouteBuilderExtensions.MapCatServiceRequest.md#Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.MapCatServiceRequest_TRequest_(thisMicrosoft.AspNetCore.Routing.IEndpointRouteBuilder,string) 'Cat\.Minimal\.Api\.CatEndpointRouteBuilderExtensions\.MapCatServiceRequest\<TRequest\>\(this Microsoft\.AspNetCore\.Routing\.IEndpointRouteBuilder, string\)') | Maps a POST endpoint that runs a service request without a payload\. A succeeded response gives 200 with no body\. A failed response gives [CatProblemDetails](CatProblemDetails.md 'Cat\.Minimal\.Api\.CatProblemDetails') with status 400, 404, 401 or 500, depending on the response type\. An empty body gives a 400, unless the request type has a parameterless constructor\. |

<a name='Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.MapCatServiceRequest_TRequest,TResponse_(thisMicrosoft.AspNetCore.Routing.IEndpointRouteBuilder,string)'></a>

## CatEndpointRouteBuilderExtensions\.MapCatServiceRequest\<TRequest,TResponse\>\(this IEndpointRouteBuilder, string\) Method

Maps a POST endpoint that runs a service request with a payload\.
A succeeded response gives 200 with the payload as JSON\. A failed response gives [CatProblemDetails](CatProblemDetails.md 'Cat\.Minimal\.Api\.CatProblemDetails')
with status 400, 404, 401 or 500, depending on the response type\.
An empty body gives a 400, unless the request type has a parameterless constructor\.

```csharp
public static void MapCatServiceRequest<TRequest,TResponse>(this Microsoft.AspNetCore.Routing.IEndpointRouteBuilder builder, string pattern)
    where TRequest : class, Cat.ServiceRequests.Abstractions.ICatServiceRequest<TResponse>;
```
#### Type parameters

<a name='Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.MapCatServiceRequest_TRequest,TResponse_(thisMicrosoft.AspNetCore.Routing.IEndpointRouteBuilder,string).TRequest'></a>

`TRequest`

The service request\. The JSON body is read into it\.

<a name='Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.MapCatServiceRequest_TRequest,TResponse_(thisMicrosoft.AspNetCore.Routing.IEndpointRouteBuilder,string).TResponse'></a>

`TResponse`

The type of the payload\.
#### Parameters

<a name='Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.MapCatServiceRequest_TRequest,TResponse_(thisMicrosoft.AspNetCore.Routing.IEndpointRouteBuilder,string).builder'></a>

`builder` [Microsoft\.AspNetCore\.Routing\.IEndpointRouteBuilder](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.routing.iendpointroutebuilder 'Microsoft\.AspNetCore\.Routing\.IEndpointRouteBuilder')

The route builder, or a group\.

<a name='Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.MapCatServiceRequest_TRequest,TResponse_(thisMicrosoft.AspNetCore.Routing.IEndpointRouteBuilder,string).pattern'></a>

`pattern` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The route pattern, like `/get`\.

<a name='Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.MapCatServiceRequest_TRequest_(thisMicrosoft.AspNetCore.Routing.IEndpointRouteBuilder,string)'></a>

## CatEndpointRouteBuilderExtensions\.MapCatServiceRequest\<TRequest\>\(this IEndpointRouteBuilder, string\) Method

Maps a POST endpoint that runs a service request without a payload\.
A succeeded response gives 200 with no body\. A failed response gives [CatProblemDetails](CatProblemDetails.md 'Cat\.Minimal\.Api\.CatProblemDetails')
with status 400, 404, 401 or 500, depending on the response type\.
An empty body gives a 400, unless the request type has a parameterless constructor\.

```csharp
public static void MapCatServiceRequest<TRequest>(this Microsoft.AspNetCore.Routing.IEndpointRouteBuilder builder, string pattern)
    where TRequest : class, Cat.ServiceRequests.Abstractions.ICatServiceRequest;
```
#### Type parameters

<a name='Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.MapCatServiceRequest_TRequest_(thisMicrosoft.AspNetCore.Routing.IEndpointRouteBuilder,string).TRequest'></a>

`TRequest`

The service request\. The JSON body is read into it\.
#### Parameters

<a name='Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.MapCatServiceRequest_TRequest_(thisMicrosoft.AspNetCore.Routing.IEndpointRouteBuilder,string).builder'></a>

`builder` [Microsoft\.AspNetCore\.Routing\.IEndpointRouteBuilder](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.routing.iendpointroutebuilder 'Microsoft\.AspNetCore\.Routing\.IEndpointRouteBuilder')

The route builder, or a group\.

<a name='Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.MapCatServiceRequest_TRequest_(thisMicrosoft.AspNetCore.Routing.IEndpointRouteBuilder,string).pattern'></a>

`pattern` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The route pattern, like `/create-update`\.