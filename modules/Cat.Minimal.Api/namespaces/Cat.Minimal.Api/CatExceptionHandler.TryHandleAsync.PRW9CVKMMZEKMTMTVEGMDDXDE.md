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

|&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[CAT.MINIMAL.API](../../README.md)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Minimal\.Api Assembly](index.md 'index') >> [Cat\.Minimal\.Api Namespace](Cat.Minimal.Api.md 'Cat\.Minimal\.Api') >> [CatExceptionHandler Class](CatExceptionHandler.md 'Cat\.Minimal\.Api\.CatExceptionHandler')

## CatExceptionHandler\.TryHandleAsync\(HttpContext, Exception, CancellationToken\) Method

Logs the exception and writes a 500 problem details response\.
In the Development environment the type holds the exception type name and the detail holds the exception message\.
In every other environment the client gets a generic detail and the trace id to find the exception in the logs\.

```csharp
public System.Threading.Tasks.ValueTask<bool> TryHandleAsync(Microsoft.AspNetCore.Http.HttpContext httpContext, System.Exception exception, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='Cat.Minimal.Api.CatExceptionHandler.TryHandleAsync(Microsoft.AspNetCore.Http.HttpContext,System.Exception,System.Threading.CancellationToken).httpContext'></a>

`httpContext` [Microsoft\.AspNetCore\.Http\.HttpContext](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.httpcontext 'Microsoft\.AspNetCore\.Http\.HttpContext')

The current request\.

<a name='Cat.Minimal.Api.CatExceptionHandler.TryHandleAsync(Microsoft.AspNetCore.Http.HttpContext,System.Exception,System.Threading.CancellationToken).exception'></a>

`exception` [System\.Exception](https://learn.microsoft.com/en-us/dotnet/api/system.exception 'System\.Exception')

The exception that was thrown\.

<a name='Cat.Minimal.Api.CatExceptionHandler.TryHandleAsync(Microsoft.AspNetCore.Http.HttpContext,System.Exception,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Token to cancel the work\.

Implements [TryHandleAsync\(HttpContext, Exception, CancellationToken\)](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.diagnostics.iexceptionhandler.tryhandleasync#microsoft-aspnetcore-diagnostics-iexceptionhandler-tryhandleasync(microsoft-aspnetcore-http-httpcontext-system-exception-system-threading-cancellationtoken) 'Microsoft\.AspNetCore\.Diagnostics\.IExceptionHandler\.TryHandleAsync\(Microsoft\.AspNetCore\.Http\.HttpContext,System\.Exception,System\.Threading\.CancellationToken\)')

#### Returns
[System\.Threading\.Tasks\.ValueTask&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask-1 'System\.Threading\.Tasks\.ValueTask\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask-1 'System\.Threading\.Tasks\.ValueTask\`1')  
Always `true`, because the handler always writes the response\.