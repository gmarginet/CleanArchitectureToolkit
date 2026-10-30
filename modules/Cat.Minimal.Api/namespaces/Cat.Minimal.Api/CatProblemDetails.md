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
  
##### >> [Cat\.Minimal\.Api Assembly](index.md 'index') >> [Cat\.Minimal\.Api Namespace](Cat.Minimal.Api.md 'Cat\.Minimal\.Api')

## CatProblemDetails Class

The body of every failed response\. It is a standard problem details object plus the CAT errors and a trace id\.

```csharp
public class CatProblemDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [Microsoft\.AspNetCore\.Mvc\.ProblemDetails](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.problemdetails 'Microsoft\.AspNetCore\.Mvc\.ProblemDetails') → CatProblemDetails

| Constructors | |
| :--- | :--- |
| [CatProblemDetails\(\)](CatProblemDetails.CatProblemDetails.md#Cat.Minimal.Api.CatProblemDetails.CatProblemDetails() 'Cat\.Minimal\.Api\.CatProblemDetails\.CatProblemDetails\(\)') | Creates an empty instance\. Use it when you fill in the properties yourself\. |
| [CatProblemDetails\(ICatResponse, string, string\)](CatProblemDetails.CatProblemDetails.md#Cat.Minimal.Api.CatProblemDetails.CatProblemDetails(Cat.Responses.Abstractions.ICatResponse,string,string) 'Cat\.Minimal\.Api\.CatProblemDetails\.CatProblemDetails\(Cat\.Responses\.Abstractions\.ICatResponse, string, string\)') | Creates problem details from a failed response\. The status follows the response type: BadRequest gives 400, NotFound gives 404, Unauthorized gives 401\. Every other failure gives 500\. |

| Properties | |
| :--- | :--- |
| [CatErrors](CatProblemDetails.CatErrors.md 'Cat\.Minimal\.Api\.CatProblemDetails\.CatErrors') | The errors of the failed response, each with a code, a message template and arguments\. |
| [CatTraceId](CatProblemDetails.CatTraceId.md 'Cat\.Minimal\.Api\.CatProblemDetails\.CatTraceId') | The id to find this request in the logs\. |
