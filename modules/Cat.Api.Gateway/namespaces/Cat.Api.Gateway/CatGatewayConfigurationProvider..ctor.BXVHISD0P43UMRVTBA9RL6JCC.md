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
  
##### >> [Cat\.Api\.Gateway Assembly](index.md 'index') >> [Cat\.Api\.Gateway\.Configuration Namespace](Cat.Api.Gateway.Configuration.md 'Cat\.Api\.Gateway\.Configuration') >> [CatGatewayConfigurationProvider Class](CatGatewayConfigurationProvider.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayConfigurationProvider')

## CatGatewayConfigurationProvider\(IConfiguration, bool, ILogger\<CatGatewayConfigurationProvider\>\) Constructor

```csharp
public CatGatewayConfigurationProvider(Microsoft.Extensions.Configuration.IConfiguration section, bool signingKeyAvailable, Microsoft.Extensions.Logging.ILogger<Cat.Api.Gateway.Configuration.CatGatewayConfigurationProvider> logger);
```
#### Parameters

<a name='Cat.Api.Gateway.Configuration.CatGatewayConfigurationProvider.CatGatewayConfigurationProvider(Microsoft.Extensions.Configuration.IConfiguration,bool,Microsoft.Extensions.Logging.ILogger_Cat.Api.Gateway.Configuration.CatGatewayConfigurationProvider_).section'></a>

`section` [Microsoft\.Extensions\.Configuration\.IConfiguration](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.configuration.iconfiguration 'Microsoft\.Extensions\.Configuration\.IConfiguration')

<a name='Cat.Api.Gateway.Configuration.CatGatewayConfigurationProvider.CatGatewayConfigurationProvider(Microsoft.Extensions.Configuration.IConfiguration,bool,Microsoft.Extensions.Logging.ILogger_Cat.Api.Gateway.Configuration.CatGatewayConfigurationProvider_).signingKeyAvailable'></a>

`signingKeyAvailable` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='Cat.Api.Gateway.Configuration.CatGatewayConfigurationProvider.CatGatewayConfigurationProvider(Microsoft.Extensions.Configuration.IConfiguration,bool,Microsoft.Extensions.Logging.ILogger_Cat.Api.Gateway.Configuration.CatGatewayConfigurationProvider_).logger'></a>

`logger` [Microsoft\.Extensions\.Logging\.ILogger&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')[CatGatewayConfigurationProvider](CatGatewayConfigurationProvider.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayConfigurationProvider')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')