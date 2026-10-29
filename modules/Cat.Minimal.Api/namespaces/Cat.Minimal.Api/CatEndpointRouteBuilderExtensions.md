<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Minimal\.Api](index.md 'index') > [Cat\.Minimal\.Api](Cat.Minimal.Api.md 'Cat\.Minimal\.Api')

## CatEndpointRouteBuilderExtensions Class

Maps service requests to minimal API endpoints\.

```csharp
public static class CatEndpointRouteBuilderExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; CatEndpointRouteBuilderExtensions

| Methods | |
| :--- | :--- |
| [CreateFailedResponseProblem&lt;TRequest&gt;\(ICatResponse, ILogger, HttpContext\)](CatEndpointRouteBuilderExtensions.CreateFailedResponseProblem.WKC8QP0IVJNWEHC5VMXSTCR8.md 'Cat\.Minimal\.Api\.CatEndpointRouteBuilderExtensions\.CreateFailedResponseProblem\<TRequest\>\(Cat\.Responses\.Abstractions\.ICatResponse, Microsoft\.Extensions\.Logging\.ILogger, Microsoft\.AspNetCore\.Http\.HttpContext\)') | Logs the errors of a failed response and creates the problem details answer for it\. |
| [CreateMissingBodyProblem\(HttpContext\)](CatEndpointRouteBuilderExtensions.CreateMissingBodyProblem.XVZLWJH4YCIEV8SAFZEBBDX03.md 'Cat\.Minimal\.Api\.CatEndpointRouteBuilderExtensions\.CreateMissingBodyProblem\(Microsoft\.AspNetCore\.Http\.HttpContext\)') | Creates the 400 answer for an empty body that can't be turned into a request\. |
| [MapCatServiceRequest&lt;TRequest,TResponse&gt;\(this IEndpointRouteBuilder, string\)](CatEndpointRouteBuilderExtensions.MapCatServiceRequest.md#Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.MapCatServiceRequest_TRequest,TResponse_(thisMicrosoft.AspNetCore.Routing.IEndpointRouteBuilder,string) 'Cat\.Minimal\.Api\.CatEndpointRouteBuilderExtensions\.MapCatServiceRequest\<TRequest,TResponse\>\(this Microsoft\.AspNetCore\.Routing\.IEndpointRouteBuilder, string\)') | Maps a POST endpoint that runs a service request with a payload\. A succeeded response gives 200 with the payload as JSON\. A failed response gives [CatProblemDetails](CatProblemDetails.md 'Cat\.Minimal\.Api\.CatProblemDetails') with status 400, 404, 401 or 500, depending on the response type\. An empty body gives a 400, unless the request type has a parameterless constructor\. |
| [MapCatServiceRequest&lt;TRequest&gt;\(this IEndpointRouteBuilder, string\)](CatEndpointRouteBuilderExtensions.MapCatServiceRequest.md#Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.MapCatServiceRequest_TRequest_(thisMicrosoft.AspNetCore.Routing.IEndpointRouteBuilder,string) 'Cat\.Minimal\.Api\.CatEndpointRouteBuilderExtensions\.MapCatServiceRequest\<TRequest\>\(this Microsoft\.AspNetCore\.Routing\.IEndpointRouteBuilder, string\)') | Maps a POST endpoint that runs a service request without a payload\. A succeeded response gives 200 with no body\. A failed response gives [CatProblemDetails](CatProblemDetails.md 'Cat\.Minimal\.Api\.CatProblemDetails') with status 400, 404, 401 or 500, depending on the response type\. An empty body gives a 400, unless the request type has a parameterless constructor\. |
| [TryGetRequest&lt;TRequest&gt;\(TRequest, TRequest\)](CatEndpointRouteBuilderExtensions.TryGetRequest.D60HW2G8417SGSPTDUFV5WQ3A.md 'Cat\.Minimal\.Api\.CatEndpointRouteBuilderExtensions\.TryGetRequest\<TRequest\>\(TRequest, TRequest\)') | Uses the request from the body\. An empty body falls back to the parameterless constructor\. |
