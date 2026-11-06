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
  
##### >> [Cat\.Api\.Gateway Assembly](index.md 'index') >> [Cat\.Api\.Gateway\.Configuration Namespace](Cat.Api.Gateway.Configuration.md 'Cat\.Api\.Gateway\.Configuration') >> [CatGatewayConfigurationProvider Class](CatGatewayConfigurationProvider.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayConfigurationProvider')

## CatGatewayConfigurationProvider\.ProxyConfig Class

```csharp
private sealed class CatGatewayConfigurationProvider.ProxyConfig : Yarp.ReverseProxy.Configuration.IProxyConfig
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → ProxyConfig

Implements [Yarp\.ReverseProxy\.Configuration\.IProxyConfig](https://learn.microsoft.com/en-us/dotnet/api/yarp.reverseproxy.configuration.iproxyconfig 'Yarp\.ReverseProxy\.Configuration\.IProxyConfig')

| Constructors | |
| :--- | :--- |
| [ProxyConfig\(IReadOnlyList&lt;RouteConfig&gt;, IReadOnlyList&lt;ClusterConfig&gt;\)](CatGatewayConfigurationProvider.ProxyConfig..ctor.8C7W585MJDQPWCXH648E5R6B9.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayConfigurationProvider\.ProxyConfig\.ProxyConfig\(System\.Collections\.Generic\.IReadOnlyList\<Yarp\.ReverseProxy\.Configuration\.RouteConfig\>, System\.Collections\.Generic\.IReadOnlyList\<Yarp\.ReverseProxy\.Configuration\.ClusterConfig\>\)') | |

| Fields | |
| :--- | :--- |
| [\_source](CatGatewayConfigurationProvider.ProxyConfig._source.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayConfigurationProvider\.ProxyConfig\.\_source') | |

| Properties | |
| :--- | :--- |
| [ChangeToken](CatGatewayConfigurationProvider.ProxyConfig.ChangeToken.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayConfigurationProvider\.ProxyConfig\.ChangeToken') | |
| [Clusters](CatGatewayConfigurationProvider.ProxyConfig.Clusters.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayConfigurationProvider\.ProxyConfig\.Clusters') | |
| [Routes](CatGatewayConfigurationProvider.ProxyConfig.Routes.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayConfigurationProvider\.ProxyConfig\.Routes') | |

| Methods | |
| :--- | :--- |
| [Cancel\(\)](CatGatewayConfigurationProvider.ProxyConfig.Cancel().md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayConfigurationProvider\.ProxyConfig\.Cancel\(\)') | |
