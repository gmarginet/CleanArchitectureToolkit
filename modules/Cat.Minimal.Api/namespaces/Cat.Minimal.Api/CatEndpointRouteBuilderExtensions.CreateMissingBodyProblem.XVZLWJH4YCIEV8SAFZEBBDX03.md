<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Minimal\.Api](index.md 'index') > [Cat\.Minimal\.Api](Cat.Minimal.Api.md 'Cat\.Minimal\.Api') > [CatEndpointRouteBuilderExtensions](CatEndpointRouteBuilderExtensions.md 'Cat\.Minimal\.Api\.CatEndpointRouteBuilderExtensions')

## CatEndpointRouteBuilderExtensions\.CreateMissingBodyProblem\(HttpContext\) Method

Creates the 400 answer for an empty body that can't be turned into a request\.

```csharp
private static Microsoft.AspNetCore.Http.HttpResults.ProblemHttpResult CreateMissingBodyProblem(Microsoft.AspNetCore.Http.HttpContext httpContext);
```
#### Parameters

<a name='Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.CreateMissingBodyProblem(Microsoft.AspNetCore.Http.HttpContext).httpContext'></a>

`httpContext` [Microsoft\.AspNetCore\.Http\.HttpContext](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.httpcontext 'Microsoft\.AspNetCore\.Http\.HttpContext')

#### Returns
[Microsoft\.AspNetCore\.Http\.HttpResults\.ProblemHttpResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.httpresults.problemhttpresult 'Microsoft\.AspNetCore\.Http\.HttpResults\.ProblemHttpResult')