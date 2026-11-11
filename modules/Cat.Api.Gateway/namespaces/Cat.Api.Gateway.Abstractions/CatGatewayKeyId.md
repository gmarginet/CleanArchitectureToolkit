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
  
##### >> [Cat\.Api\.Gateway\.Abstractions Assembly](index.md 'index') >> [Cat\.Api\.Gateway\.Abstractions Namespace](Cat.Api.Gateway.Abstractions.md 'Cat\.Api\.Gateway\.Abstractions')

## CatGatewayKeyId Class

Gives a signing key its id\. The gateway and a service compute the same id from the same public key\.

```csharp
public static class CatGatewayKeyId
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatGatewayKeyId

### Remarks
The id is the thumbprint of the key as RFC 7638 describes it\. A key you configure on a service therefore
matches the key id in the header of an assertion, without anyone choosing an id\.

| Methods | |
| :--- | :--- |
| [ForP256\(byte\[\], byte\[\]\)](CatGatewayKeyId.ForP256.46C6QF2TES3H6NX2JIHHP3TX8.md 'Cat\.Api\.Gateway\.Abstractions\.CatGatewayKeyId\.ForP256\(byte\[\], byte\[\]\)') | Computes the id of a public P\-256 key\. |
| [ToBase64Url\(byte\[\]\)](CatGatewayKeyId.ToBase64Url.ZCIQZ7KXUPCJ7HBV8RZIQA3ID.md 'Cat\.Api\.Gateway\.Abstractions\.CatGatewayKeyId\.ToBase64Url\(byte\[\]\)') | Encodes bytes as an unpadded base64url text\. |
