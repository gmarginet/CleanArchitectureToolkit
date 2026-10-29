<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Minimal\.Api](index.md 'index') > [Cat\.Minimal\.Api](Cat.Minimal.Api.md 'Cat\.Minimal\.Api')

## CatProblemDetails Class

The body of every failed response\. It is a standard problem details object plus the CAT errors and a trace id\.

```csharp
public class CatProblemDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [Microsoft\.AspNetCore\.Mvc\.ProblemDetails](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.problemdetails 'Microsoft\.AspNetCore\.Mvc\.ProblemDetails') &#129106; CatProblemDetails

| Constructors | |
| :--- | :--- |
| [CatProblemDetails\(\)](CatProblemDetails.CatProblemDetails.md#Cat.Minimal.Api.CatProblemDetails.CatProblemDetails() 'Cat\.Minimal\.Api\.CatProblemDetails\.CatProblemDetails\(\)') | Creates an empty instance\. Use it when you fill in the properties yourself\. |
| [CatProblemDetails\(ICatResponse, string, string\)](CatProblemDetails.CatProblemDetails.md#Cat.Minimal.Api.CatProblemDetails.CatProblemDetails(Cat.Responses.Abstractions.ICatResponse,string,string) 'Cat\.Minimal\.Api\.CatProblemDetails\.CatProblemDetails\(Cat\.Responses\.Abstractions\.ICatResponse, string, string\)') | Creates problem details from a failed response\. The status follows the response type: BadRequest gives 400, NotFound gives 404, Unauthorized gives 401\. Every other failure gives 500\. |

| Properties | |
| :--- | :--- |
| [CatErrors](CatProblemDetails.CatErrors.md 'Cat\.Minimal\.Api\.CatProblemDetails\.CatErrors') | The errors of the failed response, each with a code, a message template and arguments\. |
| [CatTraceId](CatProblemDetails.CatTraceId.md 'Cat\.Minimal\.Api\.CatProblemDetails\.CatTraceId') | The id to find this request in the logs\. |
