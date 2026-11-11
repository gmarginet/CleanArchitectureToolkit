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
  
##### >> [Cat\.Api\.Gateway Assembly](index.md 'index') >> [Cat\.Api\.Gateway\.Configuration Namespace](Cat.Api.Gateway.Configuration.md 'Cat\.Api\.Gateway\.Configuration')

## CatGatewayOptions Class

The configuration of the gateway\. It binds to the `CatGateway` section\.

```csharp
public sealed class CatGatewayOptions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatGatewayOptions

### Remarks

You describe the services behind the gateway, and the gateway derives the routes from them. The service name
is the first part of the path, so a service called `catalog` gets every request that starts with
`/catalog`.

A change of [Services](CatGatewayOptions.Services.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayOptions\.Services') and [Defaults](CatGatewayOptions.Defaults.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayOptions\.Defaults') is picked up while the gateway runs. A change that
is not valid is logged and ignored, and the gateway keeps the last good configuration. The other sections are
read when the gateway starts.

| Fields | |
| :--- | :--- |
| [SectionName](CatGatewayOptions.SectionName.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayOptions\.SectionName') | The name of the configuration section\. |

| Properties | |
| :--- | :--- |
| [Assertion](CatGatewayOptions.Assertion.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayOptions\.Assertion') | The keys and the lifetime of the gateway assertion\. |
| [Authentication](CatGatewayOptions.Authentication.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayOptions\.Authentication') | How the gateway checks the token of a caller\. |
| [Cors](CatGatewayOptions.Cors.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayOptions\.Cors') | Which browser origins may call the gateway\. |
| [Defaults](CatGatewayOptions.Defaults.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayOptions\.Defaults') | The values a service gets when it does not set its own\. |
| [Headers](CatGatewayOptions.Headers.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayOptions\.Headers') | Which headers the gateway removes or trusts\. |
| [Limits](CatGatewayOptions.Limits.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayOptions\.Limits') | The limits on a request\. |
| [RateLimit](CatGatewayOptions.RateLimit.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayOptions\.RateLimit') | How many requests a caller may send\. |
| [Services](CatGatewayOptions.Services.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayOptions\.Services') | The services behind the gateway, by name\. |
