<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Minimal\.Api](index.md 'index') > [Cat\.Minimal\.Api](Cat.Minimal.Api.md 'Cat\.Minimal\.Api') > [CatEndpointRouteBuilderExtensions](CatEndpointRouteBuilderExtensions.md 'Cat\.Minimal\.Api\.CatEndpointRouteBuilderExtensions')

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

`response` [ICatResponse](..\Cat.Responses.Abstractions\ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse')

<a name='Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.CreateFailedResponseProblem_TRequest_(Cat.Responses.Abstractions.ICatResponse,Microsoft.Extensions.Logging.ILogger,Microsoft.AspNetCore.Http.HttpContext).logger'></a>

`logger` [Microsoft\.Extensions\.Logging\.ILogger](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger 'Microsoft\.Extensions\.Logging\.ILogger')

<a name='Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.CreateFailedResponseProblem_TRequest_(Cat.Responses.Abstractions.ICatResponse,Microsoft.Extensions.Logging.ILogger,Microsoft.AspNetCore.Http.HttpContext).httpContext'></a>

`httpContext` [Microsoft\.AspNetCore\.Http\.HttpContext](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.httpcontext 'Microsoft\.AspNetCore\.Http\.HttpContext')

#### Returns
[Microsoft\.AspNetCore\.Http\.HttpResults\.ProblemHttpResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.httpresults.problemhttpresult 'Microsoft\.AspNetCore\.Http\.HttpResults\.ProblemHttpResult')