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

## CatProxyConfigBuilder Class

Turns the gateway configuration into YARP routes and clusters\. The conventions live here\.

```csharp
internal static class CatProxyConfigBuilder
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatProxyConfigBuilder

| Fields | |
| :--- | :--- |
| [AnonymousPolicy](CatProxyConfigBuilder.AnonymousPolicy.md 'Cat\.Api\.Gateway\.Configuration\.CatProxyConfigBuilder\.AnonymousPolicy') | |
| [GatewayOnlyMetadataKey](CatProxyConfigBuilder.GatewayOnlyMetadataKey.md 'Cat\.Api\.Gateway\.Configuration\.CatProxyConfigBuilder\.GatewayOnlyMetadataKey') | The metadata key that says a route sends the gateway assertion\. The value is `true`\. |
| [ServiceMetadataKey](CatProxyConfigBuilder.ServiceMetadataKey.md 'Cat\.Api\.Gateway\.Configuration\.CatProxyConfigBuilder\.ServiceMetadataKey') | The metadata key that holds the name of the service of a route\. |

| Methods | |
| :--- | :--- |
| [Build\(CatGatewayOptions\)](CatProxyConfigBuilder.Build.PA9S7SRIURZF7UO1WCWVAT3IE.md 'Cat\.Api\.Gateway\.Configuration\.CatProxyConfigBuilder\.Build\(Cat\.Api\.Gateway\.Configuration\.CatGatewayOptions\)') | |
| [BuildCluster\(CatGatewayOptions, string, CatGatewayServiceOptions\)](CatProxyConfigBuilder.BuildCluster.K4TAGYG14ARRZ9WJZ2ZJSZR94.md 'Cat\.Api\.Gateway\.Configuration\.CatProxyConfigBuilder\.BuildCluster\(Cat\.Api\.Gateway\.Configuration\.CatGatewayOptions, string, Cat\.Api\.Gateway\.Configuration\.CatGatewayServiceOptions\)') | |
