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
  
##### >> [Cat\.EventProcessor\.AzureServiceBus Assembly](index.md 'index') >> [Cat\.EventProcessor\.AzureServiceBus\.Extensions Namespace](Cat.EventProcessor.AzureServiceBus.Extensions.md 'Cat\.EventProcessor\.AzureServiceBus\.Extensions') >> [ServiceCollectionExtensions Class](ServiceCollectionExtensions.md 'Cat\.EventProcessor\.AzureServiceBus\.Extensions\.ServiceCollectionExtensions')

## ServiceCollectionExtensions\.AddCatEventProcessorAzureServiceBus\(this IServiceCollection, Action\<CatEventProcessorServiceBusOptions\>\) Method

Registers the listener that starts a processor for every declared message type\.
Call it after `AddCatEventProcessor` and `AddCatMessagingAzureServiceBus`, which holds the connection\.

```csharp
public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddCatEventProcessorAzureServiceBus(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, System.Action<Cat.EventProcessor.AzureServiceBus.CatEventProcessorServiceBusOptions> configure);
```
#### Parameters

<a name='Cat.EventProcessor.AzureServiceBus.Extensions.ServiceCollectionExtensions.AddCatEventProcessorAzureServiceBus(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,System.Action_Cat.EventProcessor.AzureServiceBus.CatEventProcessorServiceBusOptions_).services'></a>

`services` [Microsoft\.Extensions\.DependencyInjection\.IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection 'Microsoft\.Extensions\.DependencyInjection\.IServiceCollection')

The service collection to add to\.

<a name='Cat.EventProcessor.AzureServiceBus.Extensions.ServiceCollectionExtensions.AddCatEventProcessorAzureServiceBus(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,System.Action_Cat.EventProcessor.AzureServiceBus.CatEventProcessorServiceBusOptions_).configure'></a>

`configure` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[CatEventProcessorServiceBusOptions](CatEventProcessorServiceBusOptions.md 'Cat\.EventProcessor\.AzureServiceBus\.CatEventProcessorServiceBusOptions')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

Sets the subscription name of this service\.

#### Returns
[Microsoft\.Extensions\.DependencyInjection\.IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection 'Microsoft\.Extensions\.DependencyInjection\.IServiceCollection')  
The same service collection, so calls can be chained\.