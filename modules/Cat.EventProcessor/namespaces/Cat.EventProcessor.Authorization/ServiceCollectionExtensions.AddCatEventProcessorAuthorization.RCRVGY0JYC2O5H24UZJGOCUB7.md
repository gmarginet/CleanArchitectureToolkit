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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.EVENTPROCESSOR](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.EventProcessor\.Authorization Assembly](index.md 'index') >> [Cat\.EventProcessor\.Authorization\.Extensions Namespace](Cat.EventProcessor.Authorization.Extensions.md 'Cat\.EventProcessor\.Authorization\.Extensions') >> [ServiceCollectionExtensions Class](ServiceCollectionExtensions.md 'Cat\.EventProcessor\.Authorization\.Extensions\.ServiceCollectionExtensions')

## ServiceCollectionExtensions\.AddCatEventProcessorAuthorization\(this IServiceCollection, Action\<CatMessageAuthorizationOptions\>\) Method

Registers the message authorizer\. It validates the token of a message with the JWT bearer options of the service,
so register the scheme with `AddAuthentication().AddJwtBearer()`, also when the service has no HTTP authentication\.
It also registers ASP\.NET Core authorization, the users module and a check of the policy names at startup\.
Define the policies with `AddAuthorization`\. Register it after `AddCatEventProcessor`\.

```csharp
public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddCatEventProcessorAuthorization(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, System.Action<Cat.EventProcessor.Authorization.CatMessageAuthorizationOptions>? configure=null);
```
#### Parameters

<a name='Cat.EventProcessor.Authorization.Extensions.ServiceCollectionExtensions.AddCatEventProcessorAuthorization(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,System.Action_Cat.EventProcessor.Authorization.CatMessageAuthorizationOptions_).services'></a>

`services` [Microsoft\.Extensions\.DependencyInjection\.IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection 'Microsoft\.Extensions\.DependencyInjection\.IServiceCollection')

The service collection to add to\.

<a name='Cat.EventProcessor.Authorization.Extensions.ServiceCollectionExtensions.AddCatEventProcessorAuthorization(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,System.Action_Cat.EventProcessor.Authorization.CatMessageAuthorizationOptions_).configure'></a>

`configure` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[CatMessageAuthorizationOptions](CatMessageAuthorizationOptions.md 'Cat\.EventProcessor\.Authorization\.CatMessageAuthorizationOptions')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

Changes the settings of the authorization of messages\.

#### Returns
[Microsoft\.Extensions\.DependencyInjection\.IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection 'Microsoft\.Extensions\.DependencyInjection\.IServiceCollection')  
The same service collection, so calls can be chained\.