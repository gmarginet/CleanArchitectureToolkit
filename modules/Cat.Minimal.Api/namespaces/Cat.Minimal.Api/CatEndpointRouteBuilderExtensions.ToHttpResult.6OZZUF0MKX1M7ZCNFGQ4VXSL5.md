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

## CatEndpointRouteBuilderExtensions\.ToHttpResult\(this ICatResponse, HttpContext, CatResponseType\[\], Type, string, Func\<IResult\>, Func\<IResult\>\) Method

Maps the response to an http result, but only when its type is one the endpoint allows\.

```csharp
private static Microsoft.AspNetCore.Http.IResult ToHttpResult(this Cat.Responses.Abstractions.ICatResponse response, Microsoft.AspNetCore.Http.HttpContext httpContext, Cat.Responses.Abstractions.CatResponseType[] allowed, System.Type requestType, string httpMethod, System.Func<Microsoft.AspNetCore.Http.IResult>? ok=null, System.Func<Microsoft.AspNetCore.Http.IResult>? created=null);
```
#### Parameters

<a name='Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.ToHttpResult(thisCat.Responses.Abstractions.ICatResponse,Microsoft.AspNetCore.Http.HttpContext,Cat.Responses.Abstractions.CatResponseType[],System.Type,string,System.Func_Microsoft.AspNetCore.Http.IResult_,System.Func_Microsoft.AspNetCore.Http.IResult_).response'></a>

`response` [ICatResponse](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse')

The response of the service request handler\.

<a name='Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.ToHttpResult(thisCat.Responses.Abstractions.ICatResponse,Microsoft.AspNetCore.Http.HttpContext,Cat.Responses.Abstractions.CatResponseType[],System.Type,string,System.Func_Microsoft.AspNetCore.Http.IResult_,System.Func_Microsoft.AspNetCore.Http.IResult_).httpContext'></a>

`httpContext` [Microsoft\.AspNetCore\.Http\.HttpContext](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.httpcontext 'Microsoft\.AspNetCore\.Http\.HttpContext')

The current request\.

<a name='Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.ToHttpResult(thisCat.Responses.Abstractions.ICatResponse,Microsoft.AspNetCore.Http.HttpContext,Cat.Responses.Abstractions.CatResponseType[],System.Type,string,System.Func_Microsoft.AspNetCore.Http.IResult_,System.Func_Microsoft.AspNetCore.Http.IResult_).allowed'></a>

`allowed` [CatResponseType](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.md 'Cat\.Responses\.Abstractions\.CatResponseType')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The response types the endpoint allows\.

<a name='Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.ToHttpResult(thisCat.Responses.Abstractions.ICatResponse,Microsoft.AspNetCore.Http.HttpContext,Cat.Responses.Abstractions.CatResponseType[],System.Type,string,System.Func_Microsoft.AspNetCore.Http.IResult_,System.Func_Microsoft.AspNetCore.Http.IResult_).requestType'></a>

`requestType` [System\.Type](https://learn.microsoft.com/en-us/dotnet/api/system.type 'System\.Type')

The type of the service request, used in the error message\.

<a name='Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.ToHttpResult(thisCat.Responses.Abstractions.ICatResponse,Microsoft.AspNetCore.Http.HttpContext,Cat.Responses.Abstractions.CatResponseType[],System.Type,string,System.Func_Microsoft.AspNetCore.Http.IResult_,System.Func_Microsoft.AspNetCore.Http.IResult_).httpMethod'></a>

`httpMethod` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The http method of the endpoint, used in the error message\.

<a name='Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.ToHttpResult(thisCat.Responses.Abstractions.ICatResponse,Microsoft.AspNetCore.Http.HttpContext,Cat.Responses.Abstractions.CatResponseType[],System.Type,string,System.Func_Microsoft.AspNetCore.Http.IResult_,System.Func_Microsoft.AspNetCore.Http.IResult_).ok'></a>

`ok` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')[Microsoft\.AspNetCore\.Http\.IResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.iresult 'Microsoft\.AspNetCore\.Http\.IResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')

Builds the result for an Ok response with a body\. Without it the result has no body\.

<a name='Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.ToHttpResult(thisCat.Responses.Abstractions.ICatResponse,Microsoft.AspNetCore.Http.HttpContext,Cat.Responses.Abstractions.CatResponseType[],System.Type,string,System.Func_Microsoft.AspNetCore.Http.IResult_,System.Func_Microsoft.AspNetCore.Http.IResult_).created'></a>

`created` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')[Microsoft\.AspNetCore\.Http\.IResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.iresult 'Microsoft\.AspNetCore\.Http\.IResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')

Builds the result for a Created response with a body\. Without it the result has no body\.

#### Returns
[Microsoft\.AspNetCore\.Http\.IResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.iresult 'Microsoft\.AspNetCore\.Http\.IResult')  
The http result for the response\.

#### Exceptions

[System\.InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception 'System\.InvalidOperationException')  
Thrown when the response type isn't one the endpoint allows\.