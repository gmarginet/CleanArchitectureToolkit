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
  
##### >> [Cat\.EventProcessor\.AzureServiceBus Assembly](index.md 'index') >> [Cat\.EventProcessor\.AzureServiceBus Namespace](Cat.EventProcessor.AzureServiceBus.md 'Cat\.EventProcessor\.AzureServiceBus') >> [ServiceBusIncomingMessageMapper Class](ServiceBusIncomingMessageMapper.md 'Cat\.EventProcessor\.AzureServiceBus\.ServiceBusIncomingMessageMapper')

## ServiceBusIncomingMessageMapper\.ToIncomingMessage\(ServiceBusReceivedMessage\) Method

Maps the message\. The application properties are copied as text\.

```csharp
public static Cat.EventProcessor.Abstractions.CatIncomingMessage ToIncomingMessage(Azure.Messaging.ServiceBus.ServiceBusReceivedMessage message);
```
#### Parameters

<a name='Cat.EventProcessor.AzureServiceBus.ServiceBusIncomingMessageMapper.ToIncomingMessage(Azure.Messaging.ServiceBus.ServiceBusReceivedMessage).message'></a>

`message` [Azure\.Messaging\.ServiceBus\.ServiceBusReceivedMessage](https://learn.microsoft.com/en-us/dotnet/api/azure.messaging.servicebus.servicebusreceivedmessage 'Azure\.Messaging\.ServiceBus\.ServiceBusReceivedMessage')

The received message\.

#### Returns
[CatIncomingMessage](../../../Cat.EventProcessor/namespaces/Cat.EventProcessor.Abstractions/CatIncomingMessage.md 'Cat\.EventProcessor\.Abstractions\.CatIncomingMessage')  
The broker neutral message\.