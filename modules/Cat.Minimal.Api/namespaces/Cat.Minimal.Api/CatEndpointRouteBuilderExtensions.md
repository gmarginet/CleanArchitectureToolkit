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
  
##### >> [Cat\.Minimal\.Api Assembly](index.md 'index') >> [Cat\.Minimal\.Api Namespace](Cat.Minimal.Api.md 'Cat\.Minimal\.Api')

## CatEndpointRouteBuilderExtensions Class

Maps service requests to minimal API endpoints\.

```csharp
public static class CatEndpointRouteBuilderExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatEndpointRouteBuilderExtensions

| Methods | |
| :--- | :--- |
| [CreateFailedResponseProblem&lt;TRequest&gt;\(ICatResponse, ILogger, HttpContext\)](CatEndpointRouteBuilderExtensions.CreateFailedResponseProblem.WKC8QP0IVJNWEHC5VMXSTCR8.md 'Cat\.Minimal\.Api\.CatEndpointRouteBuilderExtensions\.CreateFailedResponseProblem\<TRequest\>\(Cat\.Responses\.Abstractions\.ICatResponse, Microsoft\.Extensions\.Logging\.ILogger, Microsoft\.AspNetCore\.Http\.HttpContext\)') | Logs the errors of a failed response and creates the problem details answer for it\. |
| [CreateMissingBodyProblem\(HttpContext\)](CatEndpointRouteBuilderExtensions.CreateMissingBodyProblem.XVZLWJH4YCIEV8SAFZEBBDX03.md 'Cat\.Minimal\.Api\.CatEndpointRouteBuilderExtensions\.CreateMissingBodyProblem\(Microsoft\.AspNetCore\.Http\.HttpContext\)') | Creates the 400 answer for an empty body that can't be turned into a request\. |
| [MapCatServiceRequest&lt;TRequest,TResponse&gt;\(this IEndpointRouteBuilder, string\)](CatEndpointRouteBuilderExtensions.MapCatServiceRequest.md#Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.MapCatServiceRequest_TRequest,TResponse_(thisMicrosoft.AspNetCore.Routing.IEndpointRouteBuilder,string) 'Cat\.Minimal\.Api\.CatEndpointRouteBuilderExtensions\.MapCatServiceRequest\<TRequest,TResponse\>\(this Microsoft\.AspNetCore\.Routing\.IEndpointRouteBuilder, string\)') | Maps a POST endpoint that runs a service request with a payload\. A succeeded response gives 200 with the payload as JSON\. A failed response gives [CatProblemDetails](CatProblemDetails.md 'Cat\.Minimal\.Api\.CatProblemDetails') with status 400, 404, 401 or 500, depending on the response type\. An empty body gives a 400, unless the request type has a parameterless constructor\. |
| [MapCatServiceRequest&lt;TRequest&gt;\(this IEndpointRouteBuilder, string\)](CatEndpointRouteBuilderExtensions.MapCatServiceRequest.md#Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.MapCatServiceRequest_TRequest_(thisMicrosoft.AspNetCore.Routing.IEndpointRouteBuilder,string) 'Cat\.Minimal\.Api\.CatEndpointRouteBuilderExtensions\.MapCatServiceRequest\<TRequest\>\(this Microsoft\.AspNetCore\.Routing\.IEndpointRouteBuilder, string\)') | Maps a POST endpoint that runs a service request without a payload\. A succeeded response gives 200 with no body\. A failed response gives [CatProblemDetails](CatProblemDetails.md 'Cat\.Minimal\.Api\.CatProblemDetails') with status 400, 404, 401 or 500, depending on the response type\. An empty body gives a 400, unless the request type has a parameterless constructor\. |
| [TryGetRequest&lt;TRequest&gt;\(TRequest, TRequest\)](CatEndpointRouteBuilderExtensions.TryGetRequest.D60HW2G8417SGSPTDUFV5WQ3A.md 'Cat\.Minimal\.Api\.CatEndpointRouteBuilderExtensions\.TryGetRequest\<TRequest\>\(TRequest, TRequest\)') | Uses the request from the body\. An empty body falls back to the parameterless constructor\. |
