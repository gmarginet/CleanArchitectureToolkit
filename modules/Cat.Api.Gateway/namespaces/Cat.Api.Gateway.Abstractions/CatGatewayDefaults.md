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
  
##### >> [Cat\.Api\.Gateway\.Abstractions Assembly](index.md 'index') >> [Cat\.Api\.Gateway\.Abstractions Namespace](Cat.Api.Gateway.Abstractions.md 'Cat\.Api\.Gateway\.Abstractions')

## CatGatewayDefaults Class

The names and values that the gateway and the services must agree on\.

```csharp
public static class CatGatewayDefaults
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatGatewayDefaults

### Remarks
The gateway writes them, and a service that checks the gateway assertion reads them\. Both sides use this class,
so a name never drifts apart\.

| Constructors | |
| :--- | :--- |
| [CatGatewayDefaults\(\)](CatGatewayDefaults.CatGatewayDefaults().md 'Cat\.Api\.Gateway\.Abstractions\.CatGatewayDefaults\.CatGatewayDefaults\(\)') | |

| Fields | |
| :--- | :--- |
| [AssertionHeaderName](CatGatewayDefaults.AssertionHeaderName.md 'Cat\.Api\.Gateway\.Abstractions\.CatGatewayDefaults\.AssertionHeaderName') | The header that carries the gateway assertion to a service\. The gateway always removes this header from the incoming request, so a client can never set it\. |
| [CorrelationIdHeaderName](CatGatewayDefaults.CorrelationIdHeaderName.md 'Cat\.Api\.Gateway\.Abstractions\.CatGatewayDefaults\.CorrelationIdHeaderName') | The header that carries the correlation id of a request through the gateway and the services\. |
| [DefaultAssertionLifetime](CatGatewayDefaults.DefaultAssertionLifetime.md 'Cat\.Api\.Gateway\.Abstractions\.CatGatewayDefaults\.DefaultAssertionLifetime') | How long a gateway assertion is valid, unless the gateway configures another lifetime\. |
| [DefaultIssuer](CatGatewayDefaults.DefaultIssuer.md 'Cat\.Api\.Gateway\.Abstractions\.CatGatewayDefaults\.DefaultIssuer') | The issuer of the gateway assertion, unless the gateway configures another name\. |
| [DefaultJwksPath](CatGatewayDefaults.DefaultJwksPath.md 'Cat\.Api\.Gateway\.Abstractions\.CatGatewayDefaults\.DefaultJwksPath') | The path where the gateway publishes the public keys that sign the gateway assertion\. |
| [SigningAlgorithm](CatGatewayDefaults.SigningAlgorithm.md 'Cat\.Api\.Gateway\.Abstractions\.CatGatewayDefaults\.SigningAlgorithm') | The signing algorithm of the gateway assertion\. It is the only algorithm a service accepts\. |
