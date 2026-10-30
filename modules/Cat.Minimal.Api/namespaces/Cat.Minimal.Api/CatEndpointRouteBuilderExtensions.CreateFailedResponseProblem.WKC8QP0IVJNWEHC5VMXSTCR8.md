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

## CatEndpointRouteBuilderExtensions\.CreateFailedResponseProblem\<TRequest\>\(ICatResponse, ILogger, HttpContext\) Method

Logs the errors of a failed response and creates the problem details answer for it\.

```csharp
private static Microsoft.AspNetCore.Http.HttpResults.ProblemHttpResult CreateFailedResponseProblem<TRequest>(Cat.Responses.Abstractions.ICatResponse response, Microsoft.Extensions.Logging.ILogger logger, Microsoft.AspNetCore.Http.HttpContext httpContext);
```
#### Type parameters

<a name='Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.CreateFailedResponseProblem_TRequest_(Cat.Responses.Abstractions.ICatResponse,Microsoft.Extensions.Logging.ILogger,Microsoft.AspNetCore.Http.HttpContext).TRequest'></a>

`TRequest`
#### Parameters

<a name='Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.CreateFailedResponseProblem_TRequest_(Cat.Responses.Abstractions.ICatResponse,Microsoft.Extensions.Logging.ILogger,Microsoft.AspNetCore.Http.HttpContext).response'></a>

`response` [ICatResponse](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse')

<a name='Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.CreateFailedResponseProblem_TRequest_(Cat.Responses.Abstractions.ICatResponse,Microsoft.Extensions.Logging.ILogger,Microsoft.AspNetCore.Http.HttpContext).logger'></a>

`logger` [Microsoft\.Extensions\.Logging\.ILogger](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger 'Microsoft\.Extensions\.Logging\.ILogger')

<a name='Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.CreateFailedResponseProblem_TRequest_(Cat.Responses.Abstractions.ICatResponse,Microsoft.Extensions.Logging.ILogger,Microsoft.AspNetCore.Http.HttpContext).httpContext'></a>

`httpContext` [Microsoft\.AspNetCore\.Http\.HttpContext](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.httpcontext 'Microsoft\.AspNetCore\.Http\.HttpContext')

#### Returns
[Microsoft\.AspNetCore\.Http\.HttpResults\.ProblemHttpResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.httpresults.problemhttpresult 'Microsoft\.AspNetCore\.Http\.HttpResults\.ProblemHttpResult')