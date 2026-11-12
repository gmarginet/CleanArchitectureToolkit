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
  
##### >> [Cat\.Messaging\.AzureServiceBus Assembly](index.md 'index') >> [Cat\.Messaging\.AzureServiceBus Namespace](Cat.Messaging.AzureServiceBus.md 'Cat\.Messaging\.AzureServiceBus')

## CatServiceBusOptions Class

Settings of the Azure Service Bus transport\.
The module starts from the defaults of Azure Service Bus\. Every `Configure` callback gets the SDK options
after the module has filled in its own values, so you can change anything\.

```csharp
public class CatServiceBusOptions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatServiceBusOptions

| Properties | |
| :--- | :--- |
| [AdministrationConnectionString](CatServiceBusOptions.AdministrationConnectionString.md 'Cat\.Messaging\.AzureServiceBus\.CatServiceBusOptions\.AdministrationConnectionString') | The connection string for the administration client, which creates the queues, topics and subscriptions\. Leave it empty to use [ConnectionString](CatServiceBusOptions.ConnectionString.md 'Cat\.Messaging\.AzureServiceBus\.CatServiceBusOptions\.ConnectionString')\. The emulator needs its own, because it answers management calls on a different port than the messages\. |
| [ConfigureAdministrationClient](CatServiceBusOptions.ConfigureAdministrationClient.md 'Cat\.Messaging\.AzureServiceBus\.CatServiceBusOptions\.ConfigureAdministrationClient') | Changes the options of the [Azure\.Messaging\.ServiceBus\.Administration\.ServiceBusAdministrationClient](https://learn.microsoft.com/en-us/dotnet/api/azure.messaging.servicebus.administration.servicebusadministrationclient 'Azure\.Messaging\.ServiceBus\.Administration\.ServiceBusAdministrationClient')\. The module sets nothing here, so the defaults of the SDK apply\. |
| [ConfigureClient](CatServiceBusOptions.ConfigureClient.md 'Cat\.Messaging\.AzureServiceBus\.CatServiceBusOptions\.ConfigureClient') | Changes the options of the [Azure\.Messaging\.ServiceBus\.ServiceBusClient](https://learn.microsoft.com/en-us/dotnet/api/azure.messaging.servicebus.servicebusclient 'Azure\.Messaging\.ServiceBus\.ServiceBusClient'), such as the retry options for failed calls to the bus\. The module sets nothing here, so the defaults of the SDK apply\. |
| [ConfigureQueue](CatServiceBusOptions.ConfigureQueue.md 'Cat\.Messaging\.AzureServiceBus\.CatServiceBusOptions\.ConfigureQueue') | Changes the options of a queue that the topology helper creates, such as the lock duration or the maximum delivery count\. The module turns duplicate detection on before the callback runs, so the callback can turn it off\. The module sets [Azure\.Messaging\.ServiceBus\.Administration\.CreateQueueOptions\.RequiresSession](https://learn.microsoft.com/en-us/dotnet/api/azure.messaging.servicebus.administration.createqueueoptions.requiressession 'Azure\.Messaging\.ServiceBus\.Administration\.CreateQueueOptions\.RequiresSession') after the callback, because the message type decides it\. |
| [ConfigureTopic](CatServiceBusOptions.ConfigureTopic.md 'Cat\.Messaging\.AzureServiceBus\.CatServiceBusOptions\.ConfigureTopic') | Changes the options of a topic that the topology helper creates\. The module turns duplicate detection on before the callback runs, so the callback can turn it off\. |
| [ConnectionString](CatServiceBusOptions.ConnectionString.md 'Cat\.Messaging\.AzureServiceBus\.CatServiceBusOptions\.ConnectionString') | The connection string of the namespace, for the real service and for the emulator\. |

| Methods | |
| :--- | :--- |
| [ResolveAdministrationConnectionString\(\)](CatServiceBusOptions.ResolveAdministrationConnectionString().md 'Cat\.Messaging\.AzureServiceBus\.CatServiceBusOptions\.ResolveAdministrationConnectionString\(\)') | |
