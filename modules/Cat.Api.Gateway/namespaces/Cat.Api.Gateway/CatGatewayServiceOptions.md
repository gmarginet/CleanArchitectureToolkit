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

## CatGatewayServiceOptions Class

One service behind the gateway\.

```csharp
public sealed class CatGatewayServiceOptions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatGatewayServiceOptions

| Properties | |
| :--- | :--- |
| [Address](CatGatewayServiceOptions.Address.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayServiceOptions\.Address') | The address of the service\. It can hold a path, which the gateway keeps in front of the path of the request\. |
| [Addresses](CatGatewayServiceOptions.Addresses.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayServiceOptions\.Addresses') | The addresses of the instances of the service, when there is more than one\. Use this or [Address](CatGatewayServiceOptions.Address.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayServiceOptions\.Address')\. |
| [Anonymous](CatGatewayServiceOptions.Anonymous.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayServiceOptions\.Anonymous') | The endpoints that need no token, such as `GET /books/**`\. Every other endpoint of the service needs a valid token\. |
| [GatewayOnly](CatGatewayServiceOptions.GatewayOnly.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayServiceOptions\.GatewayOnly') | Whether the gateway sends a gateway assertion to this service\. The default comes from [GatewayOnly](CatGatewayServiceDefaults.GatewayOnly.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayServiceDefaults\.GatewayOnly')\. |
| [HealthCheckInterval](CatGatewayServiceOptions.HealthCheckInterval.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayServiceOptions\.HealthCheckInterval') | How often the gateway checks the health of the service\. The default is 15 seconds\. |
| [HealthCheckPath](CatGatewayServiceOptions.HealthCheckPath.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayServiceOptions\.HealthCheckPath') | The path the gateway calls to check the health of the service\. Leave it empty to skip the check\. |
| [Path](CatGatewayServiceOptions.Path.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayServiceOptions\.Path') | The path the gateway listens on for this service\. The default is `/` followed by the name of the service\. |
| [StripPrefix](CatGatewayServiceOptions.StripPrefix.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayServiceOptions\.StripPrefix') | Whether the gateway removes [Path](CatGatewayServiceOptions.Path.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayServiceOptions\.Path') before it calls the service\. The default is `true`\. |
| [Timeout](CatGatewayServiceOptions.Timeout.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayServiceOptions\.Timeout') | How long the gateway waits for the service to answer\. The default comes from [Timeout](CatGatewayServiceDefaults.Timeout.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayServiceDefaults\.Timeout')\. |
