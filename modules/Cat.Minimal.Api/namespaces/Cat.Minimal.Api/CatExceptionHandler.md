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

## CatExceptionHandler Class

Catches exceptions that escape an endpoint and answers with a [CatProblemDetails](CatProblemDetails.md 'Cat\.Minimal\.Api\.CatProblemDetails')\.
Unexpected exceptions become a 500\. Request binding failures keep their own status code, usually a 400\.
A client that closed the request gets no body\.

```csharp
internal sealed class CatExceptionHandler : Microsoft.AspNetCore.Diagnostics.IExceptionHandler
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatExceptionHandler

Implements [Microsoft\.AspNetCore\.Diagnostics\.IExceptionHandler](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.diagnostics.iexceptionhandler 'Microsoft\.AspNetCore\.Diagnostics\.IExceptionHandler')

| Constructors | |
| :--- | :--- |
| [CatExceptionHandler\(ILogger&lt;CatExceptionHandler&gt;, IHostEnvironment, IProblemDetailsService\)](CatExceptionHandler..ctor.LUZKQF320U2BVGH3TCMU4O9M5.md 'Cat\.Minimal\.Api\.CatExceptionHandler\.CatExceptionHandler\(Microsoft\.Extensions\.Logging\.ILogger\<Cat\.Minimal\.Api\.CatExceptionHandler\>, Microsoft\.Extensions\.Hosting\.IHostEnvironment, Microsoft\.AspNetCore\.Http\.IProblemDetailsService\)') | Creates the handler\. |

| Fields | |
| :--- | :--- |
| [ProblemJsonContentType](CatExceptionHandler.ProblemJsonContentType.md 'Cat\.Minimal\.Api\.CatExceptionHandler\.ProblemJsonContentType') | |
| [Status499ClientClosedRequest](CatExceptionHandler.Status499ClientClosedRequest.md 'Cat\.Minimal\.Api\.CatExceptionHandler\.Status499ClientClosedRequest') | |
| [\_environment](CatExceptionHandler._environment.md 'Cat\.Minimal\.Api\.CatExceptionHandler\.\_environment') | |
| [\_logger](CatExceptionHandler._logger.md 'Cat\.Minimal\.Api\.CatExceptionHandler\.\_logger') | |
| [\_problemDetailsService](CatExceptionHandler._problemDetailsService.md 'Cat\.Minimal\.Api\.CatExceptionHandler\.\_problemDetailsService') | |

| Methods | |
| :--- | :--- |
| [TryHandleAsync\(HttpContext, Exception, CancellationToken\)](CatExceptionHandler.TryHandleAsync.PRW9CVKMMZEKMTMTVEGMDDXDE.md 'Cat\.Minimal\.Api\.CatExceptionHandler\.TryHandleAsync\(Microsoft\.AspNetCore\.Http\.HttpContext, System\.Exception, System\.Threading\.CancellationToken\)') | Logs the exception and writes a problem details response\. \.\.\. |
| [WriteProblemAsync\(HttpContext, CatProblemDetails, CancellationToken\)](CatExceptionHandler.WriteProblemAsync.5CPV1G1JRMOVWNW80KOIFTFZ.md 'Cat\.Minimal\.Api\.CatExceptionHandler\.WriteProblemAsync\(Microsoft\.AspNetCore\.Http\.HttpContext, Cat\.Minimal\.Api\.CatProblemDetails, System\.Threading\.CancellationToken\)') | Writes the problem details as the response, with the status code of the problem\. |
