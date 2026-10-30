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
  
##### >> [Cat\.Minimal\.Api Assembly](index.md 'index') >> [Cat\.Minimal\.Api Namespace](Cat.Minimal.Api.md 'Cat\.Minimal\.Api') >> [CatExceptionHandler Class](CatExceptionHandler.md 'Cat\.Minimal\.Api\.CatExceptionHandler')

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