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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.API.GATEWAY](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Api\.Gateway Assembly](index.md 'index') >> [Cat\.Api\.Gateway\.Middleware Namespace](Cat.Api.Gateway.Middleware.md 'Cat\.Api\.Gateway\.Middleware')

## RequestLoggingMiddleware Class

Logs one line for every request: the method, the path, the status, the time and the service\.

```csharp
internal sealed class RequestLoggingMiddleware
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → RequestLoggingMiddleware

### Remarks
The line never holds the query string, a header or a body, so a token or a personal value in them
does not end up in the log\. The path can still hold an id, so treat the log as sensitive\.

| Constructors | |
| :--- | :--- |
| [RequestLoggingMiddleware\(RequestDelegate, ILogger&lt;RequestLoggingMiddleware&gt;\)](RequestLoggingMiddleware..ctor.PA7PRU7QZ1AQZH8YUBAT45SA.md 'Cat\.Api\.Gateway\.Middleware\.RequestLoggingMiddleware\.RequestLoggingMiddleware\(Microsoft\.AspNetCore\.Http\.RequestDelegate, Microsoft\.Extensions\.Logging\.ILogger\<Cat\.Api\.Gateway\.Middleware\.RequestLoggingMiddleware\>\)') | |

| Fields | |
| :--- | :--- |
| [\_logger](RequestLoggingMiddleware._logger.md 'Cat\.Api\.Gateway\.Middleware\.RequestLoggingMiddleware\.\_logger') | |
| [\_next](RequestLoggingMiddleware._next.md 'Cat\.Api\.Gateway\.Middleware\.RequestLoggingMiddleware\.\_next') | |

| Methods | |
| :--- | :--- |
| [InvokeAsync\(HttpContext\)](RequestLoggingMiddleware.InvokeAsync.F0M9NEO21KPIUGH2QAE90TM81.md 'Cat\.Api\.Gateway\.Middleware\.RequestLoggingMiddleware\.InvokeAsync\(Microsoft\.AspNetCore\.Http\.HttpContext\)') | |
