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

## CatGatewayConfigurationProvider Class

Gives YARP the routes and clusters of the gateway, and keeps them current when the configuration changes\.

```csharp
internal sealed class CatGatewayConfigurationProvider : Yarp.ReverseProxy.Configuration.IProxyConfigProvider, System.IDisposable
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatGatewayConfigurationProvider

Implements [Yarp\.ReverseProxy\.Configuration\.IProxyConfigProvider](https://learn.microsoft.com/en-us/dotnet/api/yarp.reverseproxy.configuration.iproxyconfigprovider 'Yarp\.ReverseProxy\.Configuration\.IProxyConfigProvider'), [System\.IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable 'System\.IDisposable')

### Remarks
A new configuration is bound and checked before it goes live\. When it fails the check, the provider logs the
errors and keeps the last good configuration\. It never throws from a reload, because that would end the process\.
The first configuration has no earlier one, so an error there stops the start\.

| Constructors | |
| :--- | :--- |
| [CatGatewayConfigurationProvider\(IConfiguration, bool, ILogger&lt;CatGatewayConfigurationProvider&gt;\)](CatGatewayConfigurationProvider..ctor.BXVHISD0P43UMRVTBA9RL6JCC.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayConfigurationProvider\.CatGatewayConfigurationProvider\(Microsoft\.Extensions\.Configuration\.IConfiguration, bool, Microsoft\.Extensions\.Logging\.ILogger\<Cat\.Api\.Gateway\.Configuration\.CatGatewayConfigurationProvider\>\)') | |

| Fields | |
| :--- | :--- |
| [\_current](CatGatewayConfigurationProvider._current.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayConfigurationProvider\.\_current') | |
| [\_gate](CatGatewayConfigurationProvider._gate.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayConfigurationProvider\.\_gate') | |
| [\_logger](CatGatewayConfigurationProvider._logger.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayConfigurationProvider\.\_logger') | |
| [\_registration](CatGatewayConfigurationProvider._registration.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayConfigurationProvider\.\_registration') | |
| [\_section](CatGatewayConfigurationProvider._section.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayConfigurationProvider\.\_section') | |
| [\_signingKeyAvailable](CatGatewayConfigurationProvider._signingKeyAvailable.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayConfigurationProvider\.\_signingKeyAvailable') | |

| Properties | |
| :--- | :--- |
| [Options](CatGatewayConfigurationProvider.Options.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayConfigurationProvider\.Options') | The configuration that is live now\. |

| Methods | |
| :--- | :--- |
| [Bind\(\)](CatGatewayConfigurationProvider.Bind().md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayConfigurationProvider\.Bind\(\)') | |
| [Dispose\(\)](CatGatewayConfigurationProvider.Dispose().md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayConfigurationProvider\.Dispose\(\)') | |
| [GetConfig\(\)](CatGatewayConfigurationProvider.GetConfig().md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayConfigurationProvider\.GetConfig\(\)') | Returns the current route and cluster data\. |
| [Reload\(\)](CatGatewayConfigurationProvider.Reload().md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayConfigurationProvider\.Reload\(\)') | |
