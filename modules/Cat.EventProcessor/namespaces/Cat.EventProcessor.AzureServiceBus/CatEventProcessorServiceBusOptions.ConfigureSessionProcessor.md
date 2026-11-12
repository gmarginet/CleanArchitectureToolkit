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
  
##### >> [Cat\.EventProcessor\.AzureServiceBus Assembly](index.md 'index') >> [Cat\.EventProcessor\.AzureServiceBus Namespace](Cat.EventProcessor.AzureServiceBus.md 'Cat\.EventProcessor\.AzureServiceBus') >> [CatEventProcessorServiceBusOptions Class](CatEventProcessorServiceBusOptions.md 'Cat\.EventProcessor\.AzureServiceBus\.CatEventProcessorServiceBusOptions')

## CatEventProcessorServiceBusOptions\.ConfigureSessionProcessor Property

Changes the options of the processor of a message type that needs sessions\.
The first argument is the message type\. The listener sets the number of sessions of the message type before the callback runs,
so the callback wins\. The listener sets [Azure\.Messaging\.ServiceBus\.ServiceBusSessionProcessorOptions\.AutoCompleteMessages](https://learn.microsoft.com/en-us/dotnet/api/azure.messaging.servicebus.servicebussessionprocessoroptions.autocompletemessages 'Azure\.Messaging\.ServiceBus\.ServiceBusSessionProcessorOptions\.AutoCompleteMessages') to false after the callback,
because it settles every message itself\.

```csharp
public System.Action<System.Type,Azure.Messaging.ServiceBus.ServiceBusSessionProcessorOptions>? ConfigureSessionProcessor { get; set; }
```

#### Property Value
[System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-2 'System\.Action\`2')[System\.Type](https://learn.microsoft.com/en-us/dotnet/api/system.type 'System\.Type')[,](https://learn.microsoft.com/en-us/dotnet/api/system.action-2 'System\.Action\`2')[Azure\.Messaging\.ServiceBus\.ServiceBusSessionProcessorOptions](https://learn.microsoft.com/en-us/dotnet/api/azure.messaging.servicebus.servicebussessionprocessoroptions 'Azure\.Messaging\.ServiceBus\.ServiceBusSessionProcessorOptions')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-2 'System\.Action\`2')