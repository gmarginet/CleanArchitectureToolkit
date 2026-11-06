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
  
##### >> [Cat\.Api\.Gateway Assembly](index.md 'index') >> [Cat\.Api\.Gateway\.Configuration Namespace](Cat.Api.Gateway.Configuration.md 'Cat\.Api\.Gateway\.Configuration') >> [CatProxyConfigBuilder Class](CatProxyConfigBuilder.md 'Cat\.Api\.Gateway\.Configuration\.CatProxyConfigBuilder')

## CatProxyConfigBuilder\.BuildCluster\(CatGatewayOptions, string, CatGatewayServiceOptions\) Method

```csharp
private static Yarp.ReverseProxy.Configuration.ClusterConfig BuildCluster(Cat.Api.Gateway.Configuration.CatGatewayOptions options, string name, Cat.Api.Gateway.Configuration.CatGatewayServiceOptions service);
```
#### Parameters

<a name='Cat.Api.Gateway.Configuration.CatProxyConfigBuilder.BuildCluster(Cat.Api.Gateway.Configuration.CatGatewayOptions,string,Cat.Api.Gateway.Configuration.CatGatewayServiceOptions).options'></a>

`options` [CatGatewayOptions](CatGatewayOptions.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayOptions')

<a name='Cat.Api.Gateway.Configuration.CatProxyConfigBuilder.BuildCluster(Cat.Api.Gateway.Configuration.CatGatewayOptions,string,Cat.Api.Gateway.Configuration.CatGatewayServiceOptions).name'></a>

`name` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='Cat.Api.Gateway.Configuration.CatProxyConfigBuilder.BuildCluster(Cat.Api.Gateway.Configuration.CatGatewayOptions,string,Cat.Api.Gateway.Configuration.CatGatewayServiceOptions).service'></a>

`service` [CatGatewayServiceOptions](CatGatewayServiceOptions.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayServiceOptions')

#### Returns
[Yarp\.ReverseProxy\.Configuration\.ClusterConfig](https://learn.microsoft.com/en-us/dotnet/api/yarp.reverseproxy.configuration.clusterconfig 'Yarp\.ReverseProxy\.Configuration\.ClusterConfig')