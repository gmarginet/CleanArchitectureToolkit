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
  
##### >> [Cat\.Api\.Gateway Assembly](index.md 'index') >> [Cat\.Api\.Gateway\.Assertion Namespace](Cat.Api.Gateway.Assertion.md 'Cat\.Api\.Gateway\.Assertion')

## CatGatewaySigningKeys Class

Holds the signing key of the gateway, creates the gateway assertions and publishes the public keys\.

```csharp
internal sealed class CatGatewaySigningKeys : System.IDisposable
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatGatewaySigningKeys

Implements [System\.IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable 'System\.IDisposable')

### Remarks
The key is read when the gateway starts\. A key you configure is used as it is\. In the Development environment,
the gateway generates a key when you configure none\. That key changes with every start, and two gateway
instances would not share it, so production needs a configured key\.

| Constructors | |
| :--- | :--- |
| [CatGatewaySigningKeys\(CatGatewayAssertionOptions, IHostEnvironment, ILogger&lt;CatGatewaySigningKeys&gt;, TimeProvider\)](CatGatewaySigningKeys..ctor.V1RJ8M72JBZE4E4YZVAJZ5GBE.md 'Cat\.Api\.Gateway\.Assertion\.CatGatewaySigningKeys\.CatGatewaySigningKeys\(Cat\.Api\.Gateway\.Configuration\.CatGatewayAssertionOptions, Microsoft\.Extensions\.Hosting\.IHostEnvironment, Microsoft\.Extensions\.Logging\.ILogger\<Cat\.Api\.Gateway\.Assertion\.CatGatewaySigningKeys\>, System\.TimeProvider\)') | |

| Fields | |
| :--- | :--- |
| [\_cache](CatGatewaySigningKeys._cache.md 'Cat\.Api\.Gateway\.Assertion\.CatGatewaySigningKeys\.\_cache') | |
| [\_handler](CatGatewaySigningKeys._handler.md 'Cat\.Api\.Gateway\.Assertion\.CatGatewaySigningKeys\.\_handler') | |
| [\_issuer](CatGatewaySigningKeys._issuer.md 'Cat\.Api\.Gateway\.Assertion\.CatGatewaySigningKeys\.\_issuer') | |
| [\_jwks](CatGatewaySigningKeys._jwks.md 'Cat\.Api\.Gateway\.Assertion\.CatGatewaySigningKeys\.\_jwks') | |
| [\_key](CatGatewaySigningKeys._key.md 'Cat\.Api\.Gateway\.Assertion\.CatGatewaySigningKeys\.\_key') | |
| [\_keyId](CatGatewaySigningKeys._keyId.md 'Cat\.Api\.Gateway\.Assertion\.CatGatewaySigningKeys\.\_keyId') | |
| [\_lifetime](CatGatewaySigningKeys._lifetime.md 'Cat\.Api\.Gateway\.Assertion\.CatGatewaySigningKeys\.\_lifetime') | |
| [\_time](CatGatewaySigningKeys._time.md 'Cat\.Api\.Gateway\.Assertion\.CatGatewaySigningKeys\.\_time') | |

| Properties | |
| :--- | :--- |
| [HasKey](CatGatewaySigningKeys.HasKey.md 'Cat\.Api\.Gateway\.Assertion\.CatGatewaySigningKeys\.HasKey') | Whether the gateway has a key to sign with\. |

| Methods | |
| :--- | :--- |
| [BuildJwks\(ECParameters, IEnumerable&lt;string&gt;\)](CatGatewaySigningKeys.BuildJwks.TFATGS763OCNTVLD2HLU4YAL6.md 'Cat\.Api\.Gateway\.Assertion\.CatGatewaySigningKeys\.BuildJwks\(System\.Security\.Cryptography\.ECParameters, System\.Collections\.Generic\.IEnumerable\<string\>\)') | |
| [Dispose\(\)](CatGatewaySigningKeys.Dispose().md 'Cat\.Api\.Gateway\.Assertion\.CatGatewaySigningKeys\.Dispose\(\)') | |
| [GetAssertion\(string\)](CatGatewaySigningKeys.GetAssertion.ASKHFEZF662RBY984JJ9KL6N1.md 'Cat\.Api\.Gateway\.Assertion\.CatGatewaySigningKeys\.GetAssertion\(string\)') | Gives an assertion for a service\. The gateway reuses an assertion until half of its life has passed\. |
| [GetJwks\(\)](CatGatewaySigningKeys.GetJwks().md 'Cat\.Api\.Gateway\.Assertion\.CatGatewaySigningKeys\.GetJwks\(\)') | The public keys as a JSON Web Key Set\. It never holds a private key\. |
| [ReadPrivateKeyPem\(CatGatewayAssertionOptions\)](CatGatewaySigningKeys.ReadPrivateKeyPem.AKDV5C5ZJUW4LH20JWMGJANW1.md 'Cat\.Api\.Gateway\.Assertion\.CatGatewaySigningKeys\.ReadPrivateKeyPem\(Cat\.Api\.Gateway\.Configuration\.CatGatewayAssertionOptions\)') | |
| [WriteKey\(Utf8JsonWriter, ECParameters\)](CatGatewaySigningKeys.WriteKey.BR4V3ZHMGLE941ZIWHZ8832K6.md 'Cat\.Api\.Gateway\.Assertion\.CatGatewaySigningKeys\.WriteKey\(System\.Text\.Json\.Utf8JsonWriter, System\.Security\.Cryptography\.ECParameters\)') | |
