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

## CatGatewayAssertionHandler Class

Checks the gateway assertion of a request: the signature, the issuer, the audience and the lifetime\.

```csharp
internal sealed class CatGatewayAssertionHandler : Microsoft.AspNetCore.Authentication.AuthenticationHandler<Cat.Api.Gateway.Verification.CatGatewayVerificationOptions>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [Microsoft\.AspNetCore\.Authentication\.AuthenticationHandler&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.authentication.authenticationhandler-1 'Microsoft\.AspNetCore\.Authentication\.AuthenticationHandler\`1')[CatGatewayVerificationOptions](CatGatewayVerificationOptions.md 'Cat\.Api\.Gateway\.Verification\.CatGatewayVerificationOptions')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.authentication.authenticationhandler-1 'Microsoft\.AspNetCore\.Authentication\.AuthenticationHandler\`1') → CatGatewayAssertionHandler

### Remarks
The handler accepts one algorithm only, `ES256`\. A token that asks for another algorithm fails, so a
caller cannot trick the service into a weaker check\.

| Constructors | |
| :--- | :--- |
| [CatGatewayAssertionHandler\(IOptionsMonitor&lt;CatGatewayVerificationOptions&gt;, ILoggerFactory, UrlEncoder, CatGatewayKeyProvider\)](CatGatewayAssertionHandler..ctor.8JDGCV02DQRAA8S1K6GGRB0J2.md 'Cat\.Api\.Gateway\.Verification\.CatGatewayAssertionHandler\.CatGatewayAssertionHandler\(Microsoft\.Extensions\.Options\.IOptionsMonitor\<Cat\.Api\.Gateway\.Verification\.CatGatewayVerificationOptions\>, Microsoft\.Extensions\.Logging\.ILoggerFactory, System\.Text\.Encodings\.Web\.UrlEncoder, Cat\.Api\.Gateway\.Verification\.CatGatewayKeyProvider\)') | |

| Fields | |
| :--- | :--- |
| [TokenHandler](CatGatewayAssertionHandler.TokenHandler.md 'Cat\.Api\.Gateway\.Verification\.CatGatewayAssertionHandler\.TokenHandler') | |
| [\_keys](CatGatewayAssertionHandler._keys.md 'Cat\.Api\.Gateway\.Verification\.CatGatewayAssertionHandler\.\_keys') | |

| Methods | |
| :--- | :--- |
| [HandleAuthenticateAsync\(\)](CatGatewayAssertionHandler.HandleAuthenticateAsync().md 'Cat\.Api\.Gateway\.Verification\.CatGatewayAssertionHandler\.HandleAuthenticateAsync\(\)') | |
