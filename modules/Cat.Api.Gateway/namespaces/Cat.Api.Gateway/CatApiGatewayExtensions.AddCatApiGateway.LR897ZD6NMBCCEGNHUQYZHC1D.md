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
  
##### >> [Cat\.Api\.Gateway Assembly](index.md 'index') >> [Cat\.Api\.Gateway Namespace](Cat.Api.Gateway.md 'Cat\.Api\.Gateway') >> [CatApiGatewayExtensions Class](CatApiGatewayExtensions.md 'Cat\.Api\.Gateway\.CatApiGatewayExtensions')

## CatApiGatewayExtensions\.AddCatApiGateway\(this IServiceCollection, IConfiguration\) Method

Registers the gateway\. It reads the `CatGateway` section of the configuration\.

```csharp
public static Microsoft.Extensions.DependencyInjection.IReverseProxyBuilder AddCatApiGateway(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration);
```
#### Parameters

<a name='Cat.Api.Gateway.CatApiGatewayExtensions.AddCatApiGateway(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.Configuration.IConfiguration).services'></a>

`services` [Microsoft\.Extensions\.DependencyInjection\.IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection 'Microsoft\.Extensions\.DependencyInjection\.IServiceCollection')

The service collection of the host\.

<a name='Cat.Api.Gateway.CatApiGatewayExtensions.AddCatApiGateway(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.Configuration.IConfiguration).configuration'></a>

`configuration` [Microsoft\.Extensions\.Configuration\.IConfiguration](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.configuration.iconfiguration 'Microsoft\.Extensions\.Configuration\.IConfiguration')

The configuration of the host\.

#### Returns
[Microsoft\.Extensions\.DependencyInjection\.IReverseProxyBuilder](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.ireverseproxybuilder 'Microsoft\.Extensions\.DependencyInjection\.IReverseProxyBuilder')  
The YARP builder\. Use it to add what the host needs, such as service discovery or routes from a plain
YARP configuration section\.