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
  
##### >> [Cat\.Api\.Gateway\.Verification Assembly](index.md 'index') >> [Cat\.Api\.Gateway\.Verification Namespace](Cat.Api.Gateway.Verification.md 'Cat\.Api\.Gateway\.Verification') >> [CatGatewayVerificationExtensions Class](CatGatewayVerificationExtensions.md 'Cat\.Api\.Gateway\.Verification\.CatGatewayVerificationExtensions')

## CatGatewayVerificationExtensions\.AddCatGatewayVerification Method

| Overloads | |
| :--- | :--- |
| [AddCatGatewayVerification\(this IServiceCollection, IConfiguration\)](CatGatewayVerificationExtensions.AddCatGatewayVerification.md#Cat.Api.Gateway.Verification.CatGatewayVerificationExtensions.AddCatGatewayVerification(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.Configuration.IConfiguration) 'Cat\.Api\.Gateway\.Verification\.CatGatewayVerificationExtensions\.AddCatGatewayVerification\(this Microsoft\.Extensions\.DependencyInjection\.IServiceCollection, Microsoft\.Extensions\.Configuration\.IConfiguration\)') | Registers the check\. It reads the `CatGatewayVerification` section of the configuration\. |
| [AddCatGatewayVerification\(this IServiceCollection, Action&lt;CatGatewayVerificationOptions&gt;\)](CatGatewayVerificationExtensions.AddCatGatewayVerification.md#Cat.Api.Gateway.Verification.CatGatewayVerificationExtensions.AddCatGatewayVerification(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,System.Action_Cat.Api.Gateway.Verification.CatGatewayVerificationOptions_) 'Cat\.Api\.Gateway\.Verification\.CatGatewayVerificationExtensions\.AddCatGatewayVerification\(this Microsoft\.Extensions\.DependencyInjection\.IServiceCollection, System\.Action\<Cat\.Api\.Gateway\.Verification\.CatGatewayVerificationOptions\>\)') | Registers the check with settings from code\. |

<a name='Cat.Api.Gateway.Verification.CatGatewayVerificationExtensions.AddCatGatewayVerification(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.Configuration.IConfiguration)'></a>

## CatGatewayVerificationExtensions\.AddCatGatewayVerification\(this IServiceCollection, IConfiguration\) Method

Registers the check\. It reads the `CatGatewayVerification` section of the configuration\.

```csharp
public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddCatGatewayVerification(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration);
```
#### Parameters

<a name='Cat.Api.Gateway.Verification.CatGatewayVerificationExtensions.AddCatGatewayVerification(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.Configuration.IConfiguration).services'></a>

`services` [Microsoft\.Extensions\.DependencyInjection\.IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection 'Microsoft\.Extensions\.DependencyInjection\.IServiceCollection')

The service collection of the service\.

<a name='Cat.Api.Gateway.Verification.CatGatewayVerificationExtensions.AddCatGatewayVerification(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.Configuration.IConfiguration).configuration'></a>

`configuration` [Microsoft\.Extensions\.Configuration\.IConfiguration](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.configuration.iconfiguration 'Microsoft\.Extensions\.Configuration\.IConfiguration')

The configuration of the service\.

#### Returns
[Microsoft\.Extensions\.DependencyInjection\.IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection 'Microsoft\.Extensions\.DependencyInjection\.IServiceCollection')  
The same service collection\.

<a name='Cat.Api.Gateway.Verification.CatGatewayVerificationExtensions.AddCatGatewayVerification(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,System.Action_Cat.Api.Gateway.Verification.CatGatewayVerificationOptions_)'></a>

## CatGatewayVerificationExtensions\.AddCatGatewayVerification\(this IServiceCollection, Action\<CatGatewayVerificationOptions\>\) Method

Registers the check with settings from code\.

```csharp
public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddCatGatewayVerification(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, System.Action<Cat.Api.Gateway.Verification.CatGatewayVerificationOptions> configure);
```
#### Parameters

<a name='Cat.Api.Gateway.Verification.CatGatewayVerificationExtensions.AddCatGatewayVerification(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,System.Action_Cat.Api.Gateway.Verification.CatGatewayVerificationOptions_).services'></a>

`services` [Microsoft\.Extensions\.DependencyInjection\.IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection 'Microsoft\.Extensions\.DependencyInjection\.IServiceCollection')

The service collection of the service\.

<a name='Cat.Api.Gateway.Verification.CatGatewayVerificationExtensions.AddCatGatewayVerification(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,System.Action_Cat.Api.Gateway.Verification.CatGatewayVerificationOptions_).configure'></a>

`configure` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[CatGatewayVerificationOptions](CatGatewayVerificationOptions.md 'Cat\.Api\.Gateway\.Verification\.CatGatewayVerificationOptions')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

Sets the options\.

#### Returns
[Microsoft\.Extensions\.DependencyInjection\.IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection 'Microsoft\.Extensions\.DependencyInjection\.IServiceCollection')  
The same service collection\.