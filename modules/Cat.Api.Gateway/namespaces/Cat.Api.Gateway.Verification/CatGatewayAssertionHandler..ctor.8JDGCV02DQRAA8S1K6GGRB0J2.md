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
  
##### >> [Cat\.Api\.Gateway\.Verification Assembly](index.md 'index') >> [Cat\.Api\.Gateway\.Verification Namespace](Cat.Api.Gateway.Verification.md 'Cat\.Api\.Gateway\.Verification') >> [CatGatewayAssertionHandler Class](CatGatewayAssertionHandler.md 'Cat\.Api\.Gateway\.Verification\.CatGatewayAssertionHandler')

## CatGatewayAssertionHandler\(IOptionsMonitor\<CatGatewayVerificationOptions\>, ILoggerFactory, UrlEncoder, CatGatewayKeyProvider\) Constructor

```csharp
public CatGatewayAssertionHandler(Microsoft.Extensions.Options.IOptionsMonitor<Cat.Api.Gateway.Verification.CatGatewayVerificationOptions> options, Microsoft.Extensions.Logging.ILoggerFactory logger, System.Text.Encodings.Web.UrlEncoder encoder, Cat.Api.Gateway.Verification.CatGatewayKeyProvider keys);
```
#### Parameters

<a name='Cat.Api.Gateway.Verification.CatGatewayAssertionHandler.CatGatewayAssertionHandler(Microsoft.Extensions.Options.IOptionsMonitor_Cat.Api.Gateway.Verification.CatGatewayVerificationOptions_,Microsoft.Extensions.Logging.ILoggerFactory,System.Text.Encodings.Web.UrlEncoder,Cat.Api.Gateway.Verification.CatGatewayKeyProvider).options'></a>

`options` [Microsoft\.Extensions\.Options\.IOptionsMonitor&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.options.ioptionsmonitor-1 'Microsoft\.Extensions\.Options\.IOptionsMonitor\`1')[CatGatewayVerificationOptions](CatGatewayVerificationOptions.md 'Cat\.Api\.Gateway\.Verification\.CatGatewayVerificationOptions')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.options.ioptionsmonitor-1 'Microsoft\.Extensions\.Options\.IOptionsMonitor\`1')

<a name='Cat.Api.Gateway.Verification.CatGatewayAssertionHandler.CatGatewayAssertionHandler(Microsoft.Extensions.Options.IOptionsMonitor_Cat.Api.Gateway.Verification.CatGatewayVerificationOptions_,Microsoft.Extensions.Logging.ILoggerFactory,System.Text.Encodings.Web.UrlEncoder,Cat.Api.Gateway.Verification.CatGatewayKeyProvider).logger'></a>

`logger` [Microsoft\.Extensions\.Logging\.ILoggerFactory](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.iloggerfactory 'Microsoft\.Extensions\.Logging\.ILoggerFactory')

<a name='Cat.Api.Gateway.Verification.CatGatewayAssertionHandler.CatGatewayAssertionHandler(Microsoft.Extensions.Options.IOptionsMonitor_Cat.Api.Gateway.Verification.CatGatewayVerificationOptions_,Microsoft.Extensions.Logging.ILoggerFactory,System.Text.Encodings.Web.UrlEncoder,Cat.Api.Gateway.Verification.CatGatewayKeyProvider).encoder'></a>

`encoder` [System\.Text\.Encodings\.Web\.UrlEncoder](https://learn.microsoft.com/en-us/dotnet/api/system.text.encodings.web.urlencoder 'System\.Text\.Encodings\.Web\.UrlEncoder')

<a name='Cat.Api.Gateway.Verification.CatGatewayAssertionHandler.CatGatewayAssertionHandler(Microsoft.Extensions.Options.IOptionsMonitor_Cat.Api.Gateway.Verification.CatGatewayVerificationOptions_,Microsoft.Extensions.Logging.ILoggerFactory,System.Text.Encodings.Web.UrlEncoder,Cat.Api.Gateway.Verification.CatGatewayKeyProvider).keys'></a>

`keys` [CatGatewayKeyProvider](CatGatewayKeyProvider.md 'Cat\.Api\.Gateway\.Verification\.CatGatewayKeyProvider')