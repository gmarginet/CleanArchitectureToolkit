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
  
##### >> [Cat\.Api\.Gateway Assembly](index.md 'index')

## Cat\.Api\.Gateway\.Configuration Namespace

| Classes | |
| :--- | :--- |
| [AnonymousPattern](AnonymousPattern.md 'Cat\.Api\.Gateway\.Configuration\.AnonymousPattern') | One entry of [Anonymous](CatGatewayServiceOptions.Anonymous.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayServiceOptions\.Anonymous'), parsed and checked\. |
| [CatGatewayAssertionOptions](CatGatewayAssertionOptions.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayAssertionOptions') | The keys and the lifetime of the gateway assertion\. |
| [CatGatewayAuthenticationOptions](CatGatewayAuthenticationOptions.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayAuthenticationOptions') | How the gateway checks the token of a caller\. The gateway uses the standard ASP\.NET Core JWT bearer authentication, so every OpenID Connect provider works\. |
| [CatGatewayConfigurationProvider](CatGatewayConfigurationProvider.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayConfigurationProvider') | Gives YARP the routes and clusters of the gateway, and keeps them current when the configuration changes\. |
| [CatGatewayConfigurationProvider\.ProxyConfig](CatGatewayConfigurationProvider.ProxyConfig.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayConfigurationProvider\.ProxyConfig') | |
| [CatGatewayConfigurationProvider\.Snapshot](CatGatewayConfigurationProvider.Snapshot.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayConfigurationProvider\.Snapshot') | |
| [CatGatewayCorsOptions](CatGatewayCorsOptions.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayCorsOptions') | Which browser origins may call the gateway\. Cross\-origin calls stay off until you list an origin\. |
| [CatGatewayHeadersOptions](CatGatewayHeadersOptions.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayHeadersOptions') | Which headers the gateway removes or trusts\. |
| [CatGatewayLimitsOptions](CatGatewayLimitsOptions.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayLimitsOptions') | The limits on a request\. |
| [CatGatewayOptions](CatGatewayOptions.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayOptions') | The configuration of the gateway\. It binds to the `CatGateway` section\. |
| [CatGatewayOptionsValidator](CatGatewayOptionsValidator.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayOptionsValidator') | Checks the gateway configuration\. A configuration that fails never goes live\. |
| [CatGatewayRateLimitOptions](CatGatewayRateLimitOptions.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayRateLimitOptions') | How many requests a caller may send\. The gateway counts per remote address\. |
| [CatGatewayServiceDefaults](CatGatewayServiceDefaults.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayServiceDefaults') | The values a service gets when it does not set its own\. |
| [CatGatewayServiceOptions](CatGatewayServiceOptions.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayServiceOptions') | One service behind the gateway\. |
| [CatProxyConfigBuilder](CatProxyConfigBuilder.md 'Cat\.Api\.Gateway\.Configuration\.CatProxyConfigBuilder') | Turns the gateway configuration into YARP routes and clusters\. The conventions live here\. |
