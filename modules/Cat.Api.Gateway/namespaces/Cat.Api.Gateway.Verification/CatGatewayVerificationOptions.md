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
  
##### >> [Cat\.Api\.Gateway\.Verification Assembly](index.md 'index') >> [Cat\.Api\.Gateway\.Verification Namespace](Cat.Api.Gateway.Verification.md 'Cat\.Api\.Gateway\.Verification')

## CatGatewayVerificationOptions Class

The settings of a service that only accepts calls that come from the gateway\. They bind to the
`CatGatewayVerification` section\.

```csharp
public sealed class CatGatewayVerificationOptions : Microsoft.AspNetCore.Authentication.AuthenticationSchemeOptions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [Microsoft\.AspNetCore\.Authentication\.AuthenticationSchemeOptions](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.authentication.authenticationschemeoptions 'Microsoft\.AspNetCore\.Authentication\.AuthenticationSchemeOptions') → CatGatewayVerificationOptions

### Remarks
The service needs the public key of the gateway\. Give it the address where the gateway publishes its keys
\([JwksAddress](CatGatewayVerificationOptions.JwksAddress.md 'Cat\.Api\.Gateway\.Verification\.CatGatewayVerificationOptions\.JwksAddress')\), a fixed key \([PublicKeyPems](CatGatewayVerificationOptions.PublicKeyPems.md 'Cat\.Api\.Gateway\.Verification\.CatGatewayVerificationOptions\.PublicKeyPems')\), or both\. The settings are read when the
service starts\.

| Fields | |
| :--- | :--- |
| [SectionName](CatGatewayVerificationOptions.SectionName.md 'Cat\.Api\.Gateway\.Verification\.CatGatewayVerificationOptions\.SectionName') | The name of the configuration section\. |

| Properties | |
| :--- | :--- |
| [Audience](CatGatewayVerificationOptions.Audience.md 'Cat\.Api\.Gateway\.Verification\.CatGatewayVerificationOptions\.Audience') | The name of this service, as the gateway knows it\. The assertion is for one service only, and the service rejects an assertion that names another one\. |
| [ClockSkew](CatGatewayVerificationOptions.ClockSkew.md 'Cat\.Api\.Gateway\.Verification\.CatGatewayVerificationOptions\.ClockSkew') | How much the clocks of the gateway and the service may differ\. The default is 10 seconds\. |
| [Issuer](CatGatewayVerificationOptions.Issuer.md 'Cat\.Api\.Gateway\.Verification\.CatGatewayVerificationOptions\.Issuer') | The issuer of the assertion\. It must match `Assertion:Issuer` of the gateway\. The default is `cat-gateway`\. |
| [JwksAddress](CatGatewayVerificationOptions.JwksAddress.md 'Cat\.Api\.Gateway\.Verification\.CatGatewayVerificationOptions\.JwksAddress') | The address of the keys of the gateway, such as `https://gateway/.well-known/cat-gateway/jwks.json`\. Use HTTPS when the network between the service and the gateway is not trusted\. Whoever can change the answer can sign assertions\. |
| [JwksMinimumRefreshInterval](CatGatewayVerificationOptions.JwksMinimumRefreshInterval.md 'Cat\.Api\.Gateway\.Verification\.CatGatewayVerificationOptions\.JwksMinimumRefreshInterval') | The shortest time between two downloads, also when an assertion has an unknown key\. It stops a caller from making the service download the keys over and over\. The default is 30 seconds\. |
| [JwksRefreshInterval](CatGatewayVerificationOptions.JwksRefreshInterval.md 'Cat\.Api\.Gateway\.Verification\.CatGatewayVerificationOptions\.JwksRefreshInterval') | How long the service keeps the downloaded keys\. The default is 10 minutes\. |
| [PublicKeyPems](CatGatewayVerificationOptions.PublicKeyPems.md 'Cat\.Api\.Gateway\.Verification\.CatGatewayVerificationOptions\.PublicKeyPems') | Public keys as PEM text \(P\-256\)\. Use it instead of, or next to, [JwksAddress](CatGatewayVerificationOptions.JwksAddress.md 'Cat\.Api\.Gateway\.Verification\.CatGatewayVerificationOptions\.JwksAddress')\. |
