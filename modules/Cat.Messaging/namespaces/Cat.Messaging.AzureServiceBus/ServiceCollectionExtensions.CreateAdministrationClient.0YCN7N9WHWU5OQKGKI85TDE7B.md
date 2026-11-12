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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.MESSAGING](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Messaging\.AzureServiceBus Assembly](index.md 'index') >> [Cat\.Messaging\.AzureServiceBus\.Extensions Namespace](Cat.Messaging.AzureServiceBus.Extensions.md 'Cat\.Messaging\.AzureServiceBus\.Extensions') >> [ServiceCollectionExtensions Class](ServiceCollectionExtensions.md 'Cat\.Messaging\.AzureServiceBus\.Extensions\.ServiceCollectionExtensions')

## ServiceCollectionExtensions\.CreateAdministrationClient\(CatServiceBusOptions\) Method

```csharp
internal static Azure.Messaging.ServiceBus.Administration.ServiceBusAdministrationClient CreateAdministrationClient(Cat.Messaging.AzureServiceBus.CatServiceBusOptions options);
```
#### Parameters

<a name='Cat.Messaging.AzureServiceBus.Extensions.ServiceCollectionExtensions.CreateAdministrationClient(Cat.Messaging.AzureServiceBus.CatServiceBusOptions).options'></a>

`options` [CatServiceBusOptions](CatServiceBusOptions.md 'Cat\.Messaging\.AzureServiceBus\.CatServiceBusOptions')

#### Returns
[Azure\.Messaging\.ServiceBus\.Administration\.ServiceBusAdministrationClient](https://learn.microsoft.com/en-us/dotnet/api/azure.messaging.servicebus.administration.servicebusadministrationclient 'Azure\.Messaging\.ServiceBus\.Administration\.ServiceBusAdministrationClient')