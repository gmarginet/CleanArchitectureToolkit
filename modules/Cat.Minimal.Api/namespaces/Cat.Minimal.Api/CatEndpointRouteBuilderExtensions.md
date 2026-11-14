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
  
##### >> [Cat\.Minimal\.Api Assembly](index.md 'index') >> [Cat\.Minimal\.Api Namespace](Cat.Minimal.Api.md 'Cat\.Minimal\.Api')

## CatEndpointRouteBuilderExtensions Class

Maps a [ICatServiceRequest](../../../Cat.ServiceRequests/namespaces/Cat.ServiceRequests.Abstractions/ICatServiceRequest.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest') to a minimal API endpoint for each http method\.

```csharp
public static class CatEndpointRouteBuilderExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatEndpointRouteBuilderExtensions

### Remarks

You choose which [CatResponseType](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.md 'Cat\.Responses\.Abstractions\.CatResponseType') values the service request handler returns. The OpenAPI document
lists exactly those status codes, so the consumers of your api see what the endpoint really does.

Leave the response types out and the endpoint uses the default for its http method:
[Ok](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.Ok.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Ok') for GET, [Created](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.Created.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Created') for POST and
[NoContent](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.NoContent.md 'Cat\.Responses\.Abstractions\.CatResponseType\.NoContent') for PUT, PATCH and DELETE.

Some status codes can always happen, so every endpoint lists them whatever you pass:
- 400, because the request can fail to bind. Think of malformed json or a route value that doesn't parse.
- 500, because an unexpected exception can always occur.
- 415, only for endpoints that read a body, because the content type can be wrong.

The endpoint checks the response type at runtime. A handler that returns a type the endpoint doesn't list causes an
[System\.InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception 'System\.InvalidOperationException'), so the documentation and the real behavior can't drift apart unnoticed.

Every method returns the [Microsoft\.AspNetCore\.Builder\.RouteHandlerBuilder](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.builder.routehandlerbuilder 'Microsoft\.AspNetCore\.Builder\.RouteHandlerBuilder'), so you can chain calls such as
`WithName` and `RequireAuthorization`.

| Constructors | |
| :--- | :--- |
| [CatEndpointRouteBuilderExtensions\(\)](CatEndpointRouteBuilderExtensions.CatEndpointRouteBuilderExtensions().md 'Cat\.Minimal\.Api\.CatEndpointRouteBuilderExtensions\.CatEndpointRouteBuilderExtensions\(\)') | |

| Fields | |
| :--- | :--- |
| [AlwaysPossible](CatEndpointRouteBuilderExtensions.AlwaysPossible.md 'Cat\.Minimal\.Api\.CatEndpointRouteBuilderExtensions\.AlwaysPossible') | |
| [DefaultsForDeleteMethods](CatEndpointRouteBuilderExtensions.DefaultsForDeleteMethods.md 'Cat\.Minimal\.Api\.CatEndpointRouteBuilderExtensions\.DefaultsForDeleteMethods') | |
| [DefaultsForGetMethods](CatEndpointRouteBuilderExtensions.DefaultsForGetMethods.md 'Cat\.Minimal\.Api\.CatEndpointRouteBuilderExtensions\.DefaultsForGetMethods') | |
| [DefaultsForPatchMethods](CatEndpointRouteBuilderExtensions.DefaultsForPatchMethods.md 'Cat\.Minimal\.Api\.CatEndpointRouteBuilderExtensions\.DefaultsForPatchMethods') | |
| [DefaultsForPostMethods](CatEndpointRouteBuilderExtensions.DefaultsForPostMethods.md 'Cat\.Minimal\.Api\.CatEndpointRouteBuilderExtensions\.DefaultsForPostMethods') | |
| [DefaultsForPutMethods](CatEndpointRouteBuilderExtensions.DefaultsForPutMethods.md 'Cat\.Minimal\.Api\.CatEndpointRouteBuilderExtensions\.DefaultsForPutMethods') | |
| [JsonContentType](CatEndpointRouteBuilderExtensions.JsonContentType.md 'Cat\.Minimal\.Api\.CatEndpointRouteBuilderExtensions\.JsonContentType') | |
| [JsonPatchContentType](CatEndpointRouteBuilderExtensions.JsonPatchContentType.md 'Cat\.Minimal\.Api\.CatEndpointRouteBuilderExtensions\.JsonPatchContentType') | |
| [ProblemJsonContentType](CatEndpointRouteBuilderExtensions.ProblemJsonContentType.md 'Cat\.Minimal\.Api\.CatEndpointRouteBuilderExtensions\.ProblemJsonContentType') | |

| Methods | |
| :--- | :--- |
| [MapCatDelete&lt;TRequest&gt;\(this IEndpointRouteBuilder, string, CatResponseType\[\]\)](CatEndpointRouteBuilderExtensions.MapCatDelete.3A5JY0PNL9FYY5QI5MD7I8WS6.md 'Cat\.Minimal\.Api\.CatEndpointRouteBuilderExtensions\.MapCatDelete\<TRequest\>\(this Microsoft\.AspNetCore\.Routing\.IEndpointRouteBuilder, string, Cat\.Responses\.Abstractions\.CatResponseType\[\]\)') | Maps a DELETE endpoint that removes a resource\. |
| [MapCatGet&lt;TRequest,TResponse&gt;\(this IEndpointRouteBuilder, string, CatResponseType\[\]\)](CatEndpointRouteBuilderExtensions.MapCatGet.2URUX22ZOARPDWLZIF576VNC3.md 'Cat\.Minimal\.Api\.CatEndpointRouteBuilderExtensions\.MapCatGet\<TRequest,TResponse\>\(this Microsoft\.AspNetCore\.Routing\.IEndpointRouteBuilder, string, Cat\.Responses\.Abstractions\.CatResponseType\[\]\)') | Maps a GET endpoint that returns the value of the service request\. |
| [MapCatGetList&lt;TRequest,TResponse&gt;\(this IEndpointRouteBuilder, string, CatResponseType\[\]\)](CatEndpointRouteBuilderExtensions.MapCatGetList.AM8NYE748T1IEQTGGBO9ISCH5.md 'Cat\.Minimal\.Api\.CatEndpointRouteBuilderExtensions\.MapCatGetList\<TRequest,TResponse\>\(this Microsoft\.AspNetCore\.Routing\.IEndpointRouteBuilder, string, Cat\.Responses\.Abstractions\.CatResponseType\[\]\)') | Maps a GET endpoint that returns a list of items\. |
| [MapCatGetPagedList&lt;TRequest,TResponse&gt;\(this IEndpointRouteBuilder, string, CatResponseType\[\]\)](CatEndpointRouteBuilderExtensions.MapCatGetPagedList.ZG9PSI6M5B3PSC7SL1RB2XIM4.md 'Cat\.Minimal\.Api\.CatEndpointRouteBuilderExtensions\.MapCatGetPagedList\<TRequest,TResponse\>\(this Microsoft\.AspNetCore\.Routing\.IEndpointRouteBuilder, string, Cat\.Responses\.Abstractions\.CatResponseType\[\]\)') | Maps a GET endpoint that returns one page of a larger list\. |
| [MapCatPatch&lt;TRequest&gt;\(this IEndpointRouteBuilder, string, CatResponseType\[\]\)](CatEndpointRouteBuilderExtensions.MapCatPatch.LZRIXNPDZ3P4M9T5WIOZF2WIB.md 'Cat\.Minimal\.Api\.CatEndpointRouteBuilderExtensions\.MapCatPatch\<TRequest\>\(this Microsoft\.AspNetCore\.Routing\.IEndpointRouteBuilder, string, Cat\.Responses\.Abstractions\.CatResponseType\[\]\)') | Maps a PATCH endpoint that changes part of a resource\. The request body holds your own change model\. Use [MapCatPatchDocument&lt;TRouteParameters,TModel&gt;\(this IEndpointRouteBuilder, string, CatResponseType\[\]\)](CatEndpointRouteBuilderExtensions.MapCatPatchDocument.JEOOA6BFH2HOLLPTHQQ4CI9O3.md 'Cat\.Minimal\.Api\.CatEndpointRouteBuilderExtensions\.MapCatPatchDocument\<TRouteParameters,TModel\>\(this Microsoft\.AspNetCore\.Routing\.IEndpointRouteBuilder, string, Cat\.Responses\.Abstractions\.CatResponseType\[\]\)') to accept a JSON Patch document instead\. |
| [MapCatPatchDocument&lt;TRouteParameters,TModel&gt;\(this IEndpointRouteBuilder, string, CatResponseType\[\]\)](CatEndpointRouteBuilderExtensions.MapCatPatchDocument.JEOOA6BFH2HOLLPTHQQ4CI9O3.md 'Cat\.Minimal\.Api\.CatEndpointRouteBuilderExtensions\.MapCatPatchDocument\<TRouteParameters,TModel\>\(this Microsoft\.AspNetCore\.Routing\.IEndpointRouteBuilder, string, Cat\.Responses\.Abstractions\.CatResponseType\[\]\)') | Maps a PATCH endpoint that accepts a JSON Patch document \(`application/json-patch+json`\)\. The service request handler receives a [PatchDocumentRequest&lt;TRouteParameters,TModel&gt;](../../../Cat.ServiceRequests/namespaces/Cat.ServiceRequests.Minimal.Api/PatchDocumentRequest_TRouteParameters,TModel_.md 'Cat\.ServiceRequests\.Minimal\.Api\.PatchDocumentRequest\`2')\. A request without a patch document gets a 400\. |
| [MapCatPost&lt;TRequest,TResponse&gt;\(this IEndpointRouteBuilder, string, CatResponseType\[\]\)](CatEndpointRouteBuilderExtensions.MapCatPost.md#Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.MapCatPost_TRequest,TResponse_(thisMicrosoft.AspNetCore.Routing.IEndpointRouteBuilder,string,Cat.Responses.Abstractions.CatResponseType[]) 'Cat\.Minimal\.Api\.CatEndpointRouteBuilderExtensions\.MapCatPost\<TRequest,TResponse\>\(this Microsoft\.AspNetCore\.Routing\.IEndpointRouteBuilder, string, Cat\.Responses\.Abstractions\.CatResponseType\[\]\)') | Maps a POST endpoint that creates a resource and returns it\. A [Created](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.Created.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Created') response carries the created value in its body and has no Location header\. Use the overload with a `location` argument to add the header\. |
| [MapCatPost&lt;TRequest,TResponse&gt;\(this IEndpointRouteBuilder, string, Func&lt;TResponse,string&gt;, CatResponseType\[\]\)](CatEndpointRouteBuilderExtensions.MapCatPost.md#Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.MapCatPost_TRequest,TResponse_(thisMicrosoft.AspNetCore.Routing.IEndpointRouteBuilder,string,System.Func_TResponse,string_,Cat.Responses.Abstractions.CatResponseType[]) 'Cat\.Minimal\.Api\.CatEndpointRouteBuilderExtensions\.MapCatPost\<TRequest,TResponse\>\(this Microsoft\.AspNetCore\.Routing\.IEndpointRouteBuilder, string, System\.Func\<TResponse,string\>, Cat\.Responses\.Abstractions\.CatResponseType\[\]\)') | Maps a POST endpoint that creates a resource and returns it\. A [Created](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.Created.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Created') response carries the created value in its body and a Location header built by [location](CatEndpointRouteBuilderExtensions.MapCatPost.md#Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.MapCatPost_TRequest,TResponse_(thisMicrosoft.AspNetCore.Routing.IEndpointRouteBuilder,string,System.Func_TResponse,string_,Cat.Responses.Abstractions.CatResponseType[]).location 'Cat\.Minimal\.Api\.CatEndpointRouteBuilderExtensions\.MapCatPost\<TRequest,TResponse\>\(this Microsoft\.AspNetCore\.Routing\.IEndpointRouteBuilder, string, System\.Func\<TResponse,string\>, Cat\.Responses\.Abstractions\.CatResponseType\[\]\)\.location')\. An [Accepted](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.Accepted.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Accepted') response carries the value and the header the same way, for work that is not finished yet\. |
| [MapCatPost&lt;TRequest&gt;\(this IEndpointRouteBuilder, string, CatResponseType\[\]\)](CatEndpointRouteBuilderExtensions.MapCatPost.md#Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.MapCatPost_TRequest_(thisMicrosoft.AspNetCore.Routing.IEndpointRouteBuilder,string,Cat.Responses.Abstractions.CatResponseType[]) 'Cat\.Minimal\.Api\.CatEndpointRouteBuilderExtensions\.MapCatPost\<TRequest\>\(this Microsoft\.AspNetCore\.Routing\.IEndpointRouteBuilder, string, Cat\.Responses\.Abstractions\.CatResponseType\[\]\)') | Maps a POST endpoint that creates a resource\. A [Created](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.Created.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Created') response has no body and no Location header\. |
| [MapCatPut&lt;TRequest&gt;\(this IEndpointRouteBuilder, string, CatResponseType\[\]\)](CatEndpointRouteBuilderExtensions.MapCatPut.MJX0GY1WP3NASJUIZF7FO7E7E.md 'Cat\.Minimal\.Api\.CatEndpointRouteBuilderExtensions\.MapCatPut\<TRequest\>\(this Microsoft\.AspNetCore\.Routing\.IEndpointRouteBuilder, string, Cat\.Responses\.Abstractions\.CatResponseType\[\]\)') | Maps a PUT endpoint that replaces a resource\. |
| [ProducesCatResponseTypes\(this RouteHandlerBuilder, CatResponseType\[\], Type, Type, Type\)](CatEndpointRouteBuilderExtensions.ProducesCatResponseTypes.W57HG95AOG6RHQ4CRUXNWA239.md 'Cat\.Minimal\.Api\.CatEndpointRouteBuilderExtensions\.ProducesCatResponseTypes\(this Microsoft\.AspNetCore\.Builder\.RouteHandlerBuilder, Cat\.Responses\.Abstractions\.CatResponseType\[\], System\.Type, System\.Type, System\.Type\)') | Adds one OpenAPI response per allowed response type, plus 415 when the endpoint reads a body\. |
| [ResolveResponseTypes\(CatResponseType\[\], CatResponseType\[\]\)](CatEndpointRouteBuilderExtensions.ResolveResponseTypes.RQY55OP3DT8FADS1U3M245DK4.md 'Cat\.Minimal\.Api\.CatEndpointRouteBuilderExtensions\.ResolveResponseTypes\(Cat\.Responses\.Abstractions\.CatResponseType\[\], Cat\.Responses\.Abstractions\.CatResponseType\[\]\)') | Builds the list of response types an endpoint allows\. Uses the defaults when no response types are given, adds the response types that can always happen and removes duplicates\. |
| [ToHttpResult\(this ICatResponse, HttpContext, CatResponseType\[\], Type, string, Func&lt;IResult&gt;, Func&lt;IResult&gt;, Func&lt;IResult&gt;\)](CatEndpointRouteBuilderExtensions.ToHttpResult.5MB52WVTGFYTYA4M3VIRDF1E7.md 'Cat\.Minimal\.Api\.CatEndpointRouteBuilderExtensions\.ToHttpResult\(this Cat\.Responses\.Abstractions\.ICatResponse, Microsoft\.AspNetCore\.Http\.HttpContext, Cat\.Responses\.Abstractions\.CatResponseType\[\], System\.Type, string, System\.Func\<Microsoft\.AspNetCore\.Http\.IResult\>, System\.Func\<Microsoft\.AspNetCore\.Http\.IResult\>, System\.Func\<Microsoft\.AspNetCore\.Http\.IResult\>\)') | Maps the response to an http result, but only when its type is one the endpoint allows\. |
