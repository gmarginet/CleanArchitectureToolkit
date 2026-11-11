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
  
##### >> [Cat\.Api\.Gateway Assembly](index.md 'index') >> [Cat\.Api\.Gateway\.Assertion Namespace](Cat.Api.Gateway.Assertion.md 'Cat\.Api\.Gateway\.Assertion') >> [CatGatewaySigningKeys Class](CatGatewaySigningKeys.md 'Cat\.Api\.Gateway\.Assertion\.CatGatewaySigningKeys')

## CatGatewaySigningKeys\(CatGatewayAssertionOptions, IHostEnvironment, ILogger\<CatGatewaySigningKeys\>, TimeProvider\) Constructor

```csharp
public CatGatewaySigningKeys(Cat.Api.Gateway.Configuration.CatGatewayAssertionOptions options, Microsoft.Extensions.Hosting.IHostEnvironment environment, Microsoft.Extensions.Logging.ILogger<Cat.Api.Gateway.Assertion.CatGatewaySigningKeys> logger, System.TimeProvider? time=null);
```
#### Parameters

<a name='Cat.Api.Gateway.Assertion.CatGatewaySigningKeys.CatGatewaySigningKeys(Cat.Api.Gateway.Configuration.CatGatewayAssertionOptions,Microsoft.Extensions.Hosting.IHostEnvironment,Microsoft.Extensions.Logging.ILogger_Cat.Api.Gateway.Assertion.CatGatewaySigningKeys_,System.TimeProvider).options'></a>

`options` [CatGatewayAssertionOptions](CatGatewayAssertionOptions.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayAssertionOptions')

<a name='Cat.Api.Gateway.Assertion.CatGatewaySigningKeys.CatGatewaySigningKeys(Cat.Api.Gateway.Configuration.CatGatewayAssertionOptions,Microsoft.Extensions.Hosting.IHostEnvironment,Microsoft.Extensions.Logging.ILogger_Cat.Api.Gateway.Assertion.CatGatewaySigningKeys_,System.TimeProvider).environment'></a>

`environment` [Microsoft\.Extensions\.Hosting\.IHostEnvironment](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.hosting.ihostenvironment 'Microsoft\.Extensions\.Hosting\.IHostEnvironment')

<a name='Cat.Api.Gateway.Assertion.CatGatewaySigningKeys.CatGatewaySigningKeys(Cat.Api.Gateway.Configuration.CatGatewayAssertionOptions,Microsoft.Extensions.Hosting.IHostEnvironment,Microsoft.Extensions.Logging.ILogger_Cat.Api.Gateway.Assertion.CatGatewaySigningKeys_,System.TimeProvider).logger'></a>

`logger` [Microsoft\.Extensions\.Logging\.ILogger&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')[CatGatewaySigningKeys](CatGatewaySigningKeys.md 'Cat\.Api\.Gateway\.Assertion\.CatGatewaySigningKeys')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')

<a name='Cat.Api.Gateway.Assertion.CatGatewaySigningKeys.CatGatewaySigningKeys(Cat.Api.Gateway.Configuration.CatGatewayAssertionOptions,Microsoft.Extensions.Hosting.IHostEnvironment,Microsoft.Extensions.Logging.ILogger_Cat.Api.Gateway.Assertion.CatGatewaySigningKeys_,System.TimeProvider).time'></a>

`time` [System\.TimeProvider](https://learn.microsoft.com/en-us/dotnet/api/system.timeprovider 'System\.TimeProvider')