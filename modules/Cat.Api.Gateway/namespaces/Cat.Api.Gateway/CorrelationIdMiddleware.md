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

## CorrelationIdMiddleware Class

Gives every request a correlation id and passes it on to the service and back to the caller\.

```csharp
internal sealed class CorrelationIdMiddleware
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CorrelationIdMiddleware

### Remarks
A caller may send its own id in the `X-Correlation-Id` header\. The gateway only accepts a short id of
plain characters\. Anything else could break a log line, so the gateway replaces it with a new id\.

| Constructors | |
| :--- | :--- |
| [CorrelationIdMiddleware\(RequestDelegate, ILogger&lt;CorrelationIdMiddleware&gt;\)](CorrelationIdMiddleware..ctor.C0NAD4NWPWEJJUOLXGOB42GF5.md 'Cat\.Api\.Gateway\.Middleware\.CorrelationIdMiddleware\.CorrelationIdMiddleware\(Microsoft\.AspNetCore\.Http\.RequestDelegate, Microsoft\.Extensions\.Logging\.ILogger\<Cat\.Api\.Gateway\.Middleware\.CorrelationIdMiddleware\>\)') | |

| Fields | |
| :--- | :--- |
| [MaximumLength](CorrelationIdMiddleware.MaximumLength.md 'Cat\.Api\.Gateway\.Middleware\.CorrelationIdMiddleware\.MaximumLength') | |
| [\_logger](CorrelationIdMiddleware._logger.md 'Cat\.Api\.Gateway\.Middleware\.CorrelationIdMiddleware\.\_logger') | |
| [\_next](CorrelationIdMiddleware._next.md 'Cat\.Api\.Gateway\.Middleware\.CorrelationIdMiddleware\.\_next') | |

| Methods | |
| :--- | :--- |
| [InvokeAsync\(HttpContext\)](CorrelationIdMiddleware.InvokeAsync.4DO8M29GC3PEBNZO99I1JOEB3.md 'Cat\.Api\.Gateway\.Middleware\.CorrelationIdMiddleware\.InvokeAsync\(Microsoft\.AspNetCore\.Http\.HttpContext\)') | |
| [IsValid\(string\)](CorrelationIdMiddleware.IsValid.7VFIP0JP9QO7QO2F227CPLNJE.md 'Cat\.Api\.Gateway\.Middleware\.CorrelationIdMiddleware\.IsValid\(string\)') | |
