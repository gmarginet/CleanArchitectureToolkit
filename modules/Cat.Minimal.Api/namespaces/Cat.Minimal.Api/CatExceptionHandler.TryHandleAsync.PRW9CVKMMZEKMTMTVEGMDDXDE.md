<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Minimal\.Api](index.md 'index') > [Cat\.Minimal\.Api](Cat.Minimal.Api.md 'Cat\.Minimal\.Api') > [CatExceptionHandler](CatExceptionHandler.md 'Cat\.Minimal\.Api\.CatExceptionHandler')

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