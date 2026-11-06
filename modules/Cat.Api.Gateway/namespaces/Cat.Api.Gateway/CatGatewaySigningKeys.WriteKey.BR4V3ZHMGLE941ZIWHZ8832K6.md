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
  
##### >> [Cat\.Api\.Gateway Assembly](index.md 'index') >> [Cat\.Api\.Gateway\.Assertion Namespace](Cat.Api.Gateway.Assertion.md 'Cat\.Api\.Gateway\.Assertion') >> [CatGatewaySigningKeys Class](CatGatewaySigningKeys.md 'Cat\.Api\.Gateway\.Assertion\.CatGatewaySigningKeys')

## CatGatewaySigningKeys\.WriteKey\(Utf8JsonWriter, ECParameters\) Method

```csharp
private static void WriteKey(System.Text.Json.Utf8JsonWriter writer, System.Security.Cryptography.ECParameters parameters);
```
#### Parameters

<a name='Cat.Api.Gateway.Assertion.CatGatewaySigningKeys.WriteKey(System.Text.Json.Utf8JsonWriter,System.Security.Cryptography.ECParameters).writer'></a>

`writer` [System\.Text\.Json\.Utf8JsonWriter](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.utf8jsonwriter 'System\.Text\.Json\.Utf8JsonWriter')

<a name='Cat.Api.Gateway.Assertion.CatGatewaySigningKeys.WriteKey(System.Text.Json.Utf8JsonWriter,System.Security.Cryptography.ECParameters).parameters'></a>

`parameters` [System\.Security\.Cryptography\.ECParameters](https://learn.microsoft.com/en-us/dotnet/api/system.security.cryptography.ecparameters 'System\.Security\.Cryptography\.ECParameters')