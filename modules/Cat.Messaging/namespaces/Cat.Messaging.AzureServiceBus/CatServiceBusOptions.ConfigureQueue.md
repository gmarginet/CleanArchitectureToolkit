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
  
##### >> [Cat\.Messaging\.AzureServiceBus Assembly](index.md 'index') >> [Cat\.Messaging\.AzureServiceBus Namespace](Cat.Messaging.AzureServiceBus.md 'Cat\.Messaging\.AzureServiceBus') >> [CatServiceBusOptions Class](CatServiceBusOptions.md 'Cat\.Messaging\.AzureServiceBus\.CatServiceBusOptions')

## CatServiceBusOptions\.ConfigureQueue Property

Changes the options of a queue that the topology helper creates, such as the lock duration or the maximum delivery count\.
The module turns duplicate detection on before the callback runs, so the callback can turn it off\.
The module sets [Azure\.Messaging\.ServiceBus\.Administration\.CreateQueueOptions\.RequiresSession](https://learn.microsoft.com/en-us/dotnet/api/azure.messaging.servicebus.administration.createqueueoptions.requiressession 'Azure\.Messaging\.ServiceBus\.Administration\.CreateQueueOptions\.RequiresSession') after the callback, because the message type decides it\.

```csharp
public System.Action<Azure.Messaging.ServiceBus.Administration.CreateQueueOptions>? ConfigureQueue { get; set; }
```

#### Property Value
[System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[Azure\.Messaging\.ServiceBus\.Administration\.CreateQueueOptions](https://learn.microsoft.com/en-us/dotnet/api/azure.messaging.servicebus.administration.createqueueoptions 'Azure\.Messaging\.ServiceBus\.Administration\.CreateQueueOptions')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')