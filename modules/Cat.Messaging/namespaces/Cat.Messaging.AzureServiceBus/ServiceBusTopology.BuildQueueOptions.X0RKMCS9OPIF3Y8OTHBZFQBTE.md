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
  
##### >> [Cat\.Messaging\.AzureServiceBus Assembly](index.md 'index') >> [Cat\.Messaging\.AzureServiceBus Namespace](Cat.Messaging.AzureServiceBus.md 'Cat\.Messaging\.AzureServiceBus') >> [ServiceBusTopology Class](ServiceBusTopology.md 'Cat\.Messaging\.AzureServiceBus\.ServiceBusTopology')

## ServiceBusTopology\.BuildQueueOptions\(string, bool\) Method

Builds the options of a queue\. Duplicate detection is on, so the bus drops a repeated message with the same
message ID\. The time window keeps the default of Azure Service Bus\.

```csharp
internal static Azure.Messaging.ServiceBus.Administration.CreateQueueOptions BuildQueueOptions(string name, bool requiresSession);
```
#### Parameters

<a name='Cat.Messaging.AzureServiceBus.ServiceBusTopology.BuildQueueOptions(string,bool).name'></a>

`name` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='Cat.Messaging.AzureServiceBus.ServiceBusTopology.BuildQueueOptions(string,bool).requiresSession'></a>

`requiresSession` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

#### Returns
[Azure\.Messaging\.ServiceBus\.Administration\.CreateQueueOptions](https://learn.microsoft.com/en-us/dotnet/api/azure.messaging.servicebus.administration.createqueueoptions 'Azure\.Messaging\.ServiceBus\.Administration\.CreateQueueOptions')