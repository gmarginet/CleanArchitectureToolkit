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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.API.GATEWAY](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Api\.Gateway\.Verification Assembly](index.md 'index') >> [Cat\.Api\.Gateway\.Verification Namespace](Cat.Api.Gateway.Verification.md 'Cat\.Api\.Gateway\.Verification') >> [CatGatewayKeyProvider Class](CatGatewayKeyProvider.md 'Cat\.Api\.Gateway\.Verification\.CatGatewayKeyProvider')

## CatGatewayKeyProvider\(CatGatewayVerificationOptions, IHttpClientFactory, TimeProvider, ILogger\<CatGatewayKeyProvider\>\) Constructor

```csharp
public CatGatewayKeyProvider(Cat.Api.Gateway.Verification.CatGatewayVerificationOptions options, System.Net.Http.IHttpClientFactory? httpClientFactory, System.TimeProvider time, Microsoft.Extensions.Logging.ILogger<Cat.Api.Gateway.Verification.CatGatewayKeyProvider> logger);
```
#### Parameters

<a name='Cat.Api.Gateway.Verification.CatGatewayKeyProvider.CatGatewayKeyProvider(Cat.Api.Gateway.Verification.CatGatewayVerificationOptions,System.Net.Http.IHttpClientFactory,System.TimeProvider,Microsoft.Extensions.Logging.ILogger_Cat.Api.Gateway.Verification.CatGatewayKeyProvider_).options'></a>

`options` [CatGatewayVerificationOptions](CatGatewayVerificationOptions.md 'Cat\.Api\.Gateway\.Verification\.CatGatewayVerificationOptions')

<a name='Cat.Api.Gateway.Verification.CatGatewayKeyProvider.CatGatewayKeyProvider(Cat.Api.Gateway.Verification.CatGatewayVerificationOptions,System.Net.Http.IHttpClientFactory,System.TimeProvider,Microsoft.Extensions.Logging.ILogger_Cat.Api.Gateway.Verification.CatGatewayKeyProvider_).httpClientFactory'></a>

`httpClientFactory` [System\.Net\.Http\.IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.ihttpclientfactory 'System\.Net\.Http\.IHttpClientFactory')

<a name='Cat.Api.Gateway.Verification.CatGatewayKeyProvider.CatGatewayKeyProvider(Cat.Api.Gateway.Verification.CatGatewayVerificationOptions,System.Net.Http.IHttpClientFactory,System.TimeProvider,Microsoft.Extensions.Logging.ILogger_Cat.Api.Gateway.Verification.CatGatewayKeyProvider_).time'></a>

`time` [System\.TimeProvider](https://learn.microsoft.com/en-us/dotnet/api/system.timeprovider 'System\.TimeProvider')

<a name='Cat.Api.Gateway.Verification.CatGatewayKeyProvider.CatGatewayKeyProvider(Cat.Api.Gateway.Verification.CatGatewayVerificationOptions,System.Net.Http.IHttpClientFactory,System.TimeProvider,Microsoft.Extensions.Logging.ILogger_Cat.Api.Gateway.Verification.CatGatewayKeyProvider_).logger'></a>

`logger` [Microsoft\.Extensions\.Logging\.ILogger&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')[CatGatewayKeyProvider](CatGatewayKeyProvider.md 'Cat\.Api\.Gateway\.Verification\.CatGatewayKeyProvider')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')