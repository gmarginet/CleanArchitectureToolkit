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
  
##### >> [Cat\.Api\.Gateway Assembly](index.md 'index') >> [Cat\.Api\.Gateway\.Configuration Namespace](Cat.Api.Gateway.Configuration.md 'Cat\.Api\.Gateway\.Configuration')

## CatGatewayAssertionOptions Class

The keys and the lifetime of the gateway assertion\.

```csharp
public sealed class CatGatewayAssertionOptions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatGatewayAssertionOptions

| Properties | |
| :--- | :--- |
| [Issuer](CatGatewayAssertionOptions.Issuer.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayAssertionOptions\.Issuer') | The name of the issuer\. A service checks it\. The default is `cat-gateway`\. |
| [JwksPath](CatGatewayAssertionOptions.JwksPath.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayAssertionOptions\.JwksPath') | The path where the gateway publishes the public keys\. The default is `/.well-known/cat-gateway/jwks.json`\. |
| [Lifetime](CatGatewayAssertionOptions.Lifetime.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayAssertionOptions\.Lifetime') | How long an assertion is valid\. The default is 30 seconds\. |
| [PreviousPublicKeyPems](CatGatewayAssertionOptions.PreviousPublicKeyPems.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayAssertionOptions\.PreviousPublicKeyPems') | The public keys of earlier signing keys\. The gateway still publishes them, so a service accepts the assertions that are already out while you replace the signing key\. |
| [PrivateKeyPem](CatGatewayAssertionOptions.PrivateKeyPem.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayAssertionOptions\.PrivateKeyPem') | The private signing key, as a PEM text of an elliptic curve key \(P\-256\)\. Keep it in a secret store\. |
| [PrivateKeyPemFile](CatGatewayAssertionOptions.PrivateKeyPemFile.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayAssertionOptions\.PrivateKeyPemFile') | The path of a file with the private signing key\. Use this or [PrivateKeyPem](CatGatewayAssertionOptions.PrivateKeyPem.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayAssertionOptions\.PrivateKeyPem')\. |
