<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Minimal\.Api](index.md 'index') > [Cat\.Minimal\.Api](Cat.Minimal.Api.md 'Cat\.Minimal\.Api')

## CatExceptionHandler Class

Catches unexpected exceptions, logs them and answers with a 500 [CatProblemDetails](CatProblemDetails.md 'Cat\.Minimal\.Api\.CatProblemDetails')\.

```csharp
internal sealed class CatExceptionHandler : Microsoft.AspNetCore.Diagnostics.IExceptionHandler
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; CatExceptionHandler

Implements [Microsoft\.AspNetCore\.Diagnostics\.IExceptionHandler](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.diagnostics.iexceptionhandler 'Microsoft\.AspNetCore\.Diagnostics\.IExceptionHandler')

| Constructors | |
| :--- | :--- |
| [CatExceptionHandler\(ILogger&lt;CatExceptionHandler&gt;, IHostEnvironment\)](CatExceptionHandler..ctor.UIXM1YD3HJXXK4WDF9NDNJC8C.md 'Cat\.Minimal\.Api\.CatExceptionHandler\.CatExceptionHandler\(Microsoft\.Extensions\.Logging\.ILogger\<Cat\.Minimal\.Api\.CatExceptionHandler\>, Microsoft\.Extensions\.Hosting\.IHostEnvironment\)') | Creates the handler\. |

| Fields | |
| :--- | :--- |
| [\_environment](CatExceptionHandler._environment.md 'Cat\.Minimal\.Api\.CatExceptionHandler\.\_environment') | |
| [\_logger](CatExceptionHandler._logger.md 'Cat\.Minimal\.Api\.CatExceptionHandler\.\_logger') | |

| Methods | |
| :--- | :--- |
| [TryHandleAsync\(HttpContext, Exception, CancellationToken\)](CatExceptionHandler.TryHandleAsync.PRW9CVKMMZEKMTMTVEGMDDXDE.md 'Cat\.Minimal\.Api\.CatExceptionHandler\.TryHandleAsync\(Microsoft\.AspNetCore\.Http\.HttpContext, System\.Exception, System\.Threading\.CancellationToken\)') | Logs the exception and writes a 500 problem details response\. In the Development environment the type holds the exception type name and the detail holds the exception message\. In every other environment the client gets a generic detail and the trace id to find the exception in the logs\. |
