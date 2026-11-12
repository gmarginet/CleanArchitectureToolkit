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

## ServiceCollectionExtensions\.AddCatMessagingAzureServiceBus\(this IServiceCollection, Action\<CatServiceBusOptions\>\) Method

Registers the Azure Service Bus transport, and the helper that creates the queues and topics on request\.
Nothing is created at startup\. Call [EnsureTopologyAsync\(IEnumerable&lt;Assembly&gt;, CancellationToken\)](ICatServiceBusTopology.EnsureTopologyAsync.BIVLHFG4Y7114YB5ZHKJ7MEBE.md 'Cat\.Messaging\.AzureServiceBus\.ICatServiceBusTopology\.EnsureTopologyAsync\(System\.Collections\.Generic\.IEnumerable\<System\.Reflection\.Assembly\>, System\.Threading\.CancellationToken\)') when you want the entities\.
The administration client connects only when it is used, so a service that never creates entities needs no manage right\.

```csharp
public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddCatMessagingAzureServiceBus(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, System.Action<Cat.Messaging.AzureServiceBus.CatServiceBusOptions> configure);
```
#### Parameters

<a name='Cat.Messaging.AzureServiceBus.Extensions.ServiceCollectionExtensions.AddCatMessagingAzureServiceBus(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,System.Action_Cat.Messaging.AzureServiceBus.CatServiceBusOptions_).services'></a>

`services` [Microsoft\.Extensions\.DependencyInjection\.IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection 'Microsoft\.Extensions\.DependencyInjection\.IServiceCollection')

The service collection to add to\.

<a name='Cat.Messaging.AzureServiceBus.Extensions.ServiceCollectionExtensions.AddCatMessagingAzureServiceBus(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,System.Action_Cat.Messaging.AzureServiceBus.CatServiceBusOptions_).configure'></a>

`configure` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[CatServiceBusOptions](CatServiceBusOptions.md 'Cat\.Messaging\.AzureServiceBus\.CatServiceBusOptions')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

Sets the connection string, and the optional callbacks that change the options of the SDK\.

#### Returns
[Microsoft\.Extensions\.DependencyInjection\.IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection 'Microsoft\.Extensions\.DependencyInjection\.IServiceCollection')  
The same service collection, so calls can be chained\.