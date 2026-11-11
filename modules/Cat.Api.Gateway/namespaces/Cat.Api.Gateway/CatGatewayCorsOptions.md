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

## CatGatewayCorsOptions Class

Which browser origins may call the gateway\. Cross\-origin calls stay off until you list an origin\.

```csharp
public sealed class CatGatewayCorsOptions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatGatewayCorsOptions

| Properties | |
| :--- | :--- |
| [AllowCredentials](CatGatewayCorsOptions.AllowCredentials.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayCorsOptions\.AllowCredentials') | Whether a browser may send credentials such as cookies\. The default is `false`\. |
| [AllowedHeaders](CatGatewayCorsOptions.AllowedHeaders.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayCorsOptions\.AllowedHeaders') | The headers a browser may send\. The default is every header\. |
| [AllowedMethods](CatGatewayCorsOptions.AllowedMethods.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayCorsOptions\.AllowedMethods') | The methods a browser may use\. The default is every method\. |
| [AllowedOrigins](CatGatewayCorsOptions.AllowedOrigins.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayCorsOptions\.AllowedOrigins') | The origins that may call the gateway, such as `https://shop.example.com`\. |
