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
  
##### >> [Cat\.EventProcessor\.AzureServiceBus Assembly](index.md 'index') >> [Cat\.EventProcessor\.AzureServiceBus Namespace](Cat.EventProcessor.AzureServiceBus.md 'Cat\.EventProcessor\.AzureServiceBus')

## EventProcessorTopology Class

Default [ICatEventProcessorTopology](ICatEventProcessorTopology.md 'Cat\.EventProcessor\.AzureServiceBus\.ICatEventProcessorTopology'), on the administration client\.

```csharp
internal sealed class EventProcessorTopology : Cat.EventProcessor.AzureServiceBus.ICatEventProcessorTopology
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → EventProcessorTopology

Implements [ICatEventProcessorTopology](ICatEventProcessorTopology.md 'Cat\.EventProcessor\.AzureServiceBus\.ICatEventProcessorTopology')

| Constructors | |
| :--- | :--- |
| [EventProcessorTopology\(ServiceBusAdministrationClient, ICatReceiveRegistry, ICatMessageNameResolver, IOptions&lt;CatEventProcessorServiceBusOptions&gt;\)](EventProcessorTopology..ctor.4QURCUS2Y4JGH7FB4ZYX1LXI2.md 'Cat\.EventProcessor\.AzureServiceBus\.EventProcessorTopology\.EventProcessorTopology\(Azure\.Messaging\.ServiceBus\.Administration\.ServiceBusAdministrationClient, Cat\.EventProcessor\.Abstractions\.ICatReceiveRegistry, Cat\.Messaging\.Abstractions\.ICatMessageNameResolver, Microsoft\.Extensions\.Options\.IOptions\<Cat\.EventProcessor\.AzureServiceBus\.CatEventProcessorServiceBusOptions\>\)') | Creates the topology helper\. |

| Fields | |
| :--- | :--- |
| [\_admin](EventProcessorTopology._admin.md 'Cat\.EventProcessor\.AzureServiceBus\.EventProcessorTopology\.\_admin') | |
| [\_nameResolver](EventProcessorTopology._nameResolver.md 'Cat\.EventProcessor\.AzureServiceBus\.EventProcessorTopology\.\_nameResolver') | |
| [\_options](EventProcessorTopology._options.md 'Cat\.EventProcessor\.AzureServiceBus\.EventProcessorTopology\.\_options') | |
| [\_registry](EventProcessorTopology._registry.md 'Cat\.EventProcessor\.AzureServiceBus\.EventProcessorTopology\.\_registry') | |

| Methods | |
| :--- | :--- |
| [BuildSubscriptionOptions\(string, string, Action&lt;CreateSubscriptionOptions&gt;\)](EventProcessorTopology.BuildSubscriptionOptions.I97E2YGYRSC9P8XOPK04PGS5D.md 'Cat\.EventProcessor\.AzureServiceBus\.EventProcessorTopology\.BuildSubscriptionOptions\(string, string, System\.Action\<Azure\.Messaging\.ServiceBus\.Administration\.CreateSubscriptionOptions\>\)') | Builds the options of a subscription\. The module sets only the names, so the defaults of Azure Service Bus apply until the callback changes them\. |
| [EnsureSubscriptionsAsync\(CancellationToken\)](EventProcessorTopology.EnsureSubscriptionsAsync.WPZKOWE2CD1DA50DA4WAH79X5.md 'Cat\.EventProcessor\.AzureServiceBus\.EventProcessorTopology\.EnsureSubscriptionsAsync\(System\.Threading\.CancellationToken\)') | Creates the subscription of this service on the topic of every declared event, and skips what exists\. The topic must exist already\. |
