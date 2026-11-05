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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.MINIMAL.API](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

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

| Properties | |
| :--- | :--- |
| [CatErrors](CatProblemDetails.CatErrors.md 'Cat\.Minimal\.Api\.CatProblemDetails\.CatErrors') | The errors of the failed response, each with a code, a message template and arguments\. |
| [CatTraceId](CatProblemDetails.CatTraceId.md 'Cat\.Minimal\.Api\.CatProblemDetails\.CatTraceId') | The id to find this request in the logs\. |

| Methods | |
| :--- | :--- |
| [Create\(HttpContext, int, string, string, IReadOnlyList&lt;ICatError&gt;\)](CatProblemDetails.Create.PXVTJ0B7B433M57RRFG9HZ6M8.md 'Cat\.Minimal\.Api\.CatProblemDetails\.Create\(Microsoft\.AspNetCore\.Http\.HttpContext, int, string, string, System\.Collections\.Generic\.IReadOnlyList\<Cat\.Responses\.Abstractions\.ICatError\>\)') | Creates problem details for the current request, with the trace id filled in\. |
| [GetTraceId\(HttpContext\)](CatProblemDetails.GetTraceId.BWFSWZGY6JQWNRAMOVBP388W2.md 'Cat\.Minimal\.Api\.CatProblemDetails\.GetTraceId\(Microsoft\.AspNetCore\.Http\.HttpContext\)') | Gets the id to find the request in the logs\. |
