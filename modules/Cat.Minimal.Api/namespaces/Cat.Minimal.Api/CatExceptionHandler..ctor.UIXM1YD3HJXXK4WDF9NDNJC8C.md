<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Minimal\.Api](index.md 'index') > [Cat\.Minimal\.Api](Cat.Minimal.Api.md 'Cat\.Minimal\.Api') > [CatExceptionHandler](CatExceptionHandler.md 'Cat\.Minimal\.Api\.CatExceptionHandler')

## CatExceptionHandler\(ILogger\<CatExceptionHandler\>, IHostEnvironment\) Constructor

Creates the handler\.

```csharp
public CatExceptionHandler(Microsoft.Extensions.Logging.ILogger<Cat.Minimal.Api.CatExceptionHandler> logger, Microsoft.Extensions.Hosting.IHostEnvironment environment);
```
#### Parameters

<a name='Cat.Minimal.Api.CatExceptionHandler.CatExceptionHandler(Microsoft.Extensions.Logging.ILogger_Cat.Minimal.Api.CatExceptionHandler_,Microsoft.Extensions.Hosting.IHostEnvironment).logger'></a>

`logger` [Microsoft\.Extensions\.Logging\.ILogger&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')[CatExceptionHandler](CatExceptionHandler.md 'Cat\.Minimal\.Api\.CatExceptionHandler')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')

Receives the exception\.

<a name='Cat.Minimal.Api.CatExceptionHandler.CatExceptionHandler(Microsoft.Extensions.Logging.ILogger_Cat.Minimal.Api.CatExceptionHandler_,Microsoft.Extensions.Hosting.IHostEnvironment).environment'></a>

`environment` [Microsoft\.Extensions\.Hosting\.IHostEnvironment](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.hosting.ihostenvironment 'Microsoft\.Extensions\.Hosting\.IHostEnvironment')

Decides whether the exception details may go to the client\.