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
  
##### >> [Cat\.EventProcessor\.AzureServiceBus Assembly](index.md 'index')

## Cat\.EventProcessor\.AzureServiceBus Namespace

The Azure Service Bus listener of the event processor\.
It starts one processor per declared message type, settles every message and offers a health check and the creation of the subscriptions\.

| Classes | |
| :--- | :--- |
| [CatEventProcessorServiceBusOptions](CatEventProcessorServiceBusOptions.md 'Cat\.EventProcessor\.AzureServiceBus\.CatEventProcessorServiceBusOptions') | Settings of the Azure Service Bus listener\. |
| [EventProcessorHealthCheck](EventProcessorHealthCheck.md 'Cat\.EventProcessor\.AzureServiceBus\.EventProcessorHealthCheck') | Health check of the listeners\. It is unhealthy when a listener has stopped, for example after a fatal error, and degraded for a minute after a listener reported an error while it keeps processing\. The Azure SDK restarts the connection by itself\. |
| [EventProcessorTopology](EventProcessorTopology.md 'Cat\.EventProcessor\.AzureServiceBus\.EventProcessorTopology') | Default [ICatEventProcessorTopology](ICatEventProcessorTopology.md 'Cat\.EventProcessor\.AzureServiceBus\.ICatEventProcessorTopology'), on the administration client\. |
| [ListenerStatus](ListenerStatus.md 'Cat\.EventProcessor\.AzureServiceBus\.ListenerStatus') | Tracks the state of the listeners, for the health check\. |
| [ServiceBusIncomingMessageMapper](ServiceBusIncomingMessageMapper.md 'Cat\.EventProcessor\.AzureServiceBus\.ServiceBusIncomingMessageMapper') | Turns a received Service Bus message into a [CatIncomingMessage](../../../Cat.EventProcessor/namespaces/Cat.EventProcessor.Abstractions/CatIncomingMessage.md 'Cat\.EventProcessor\.Abstractions\.CatIncomingMessage')\. |
| [ServiceBusListener](ServiceBusListener.md 'Cat\.EventProcessor\.AzureServiceBus\.ServiceBusListener') | Hosted service that starts one Azure Service Bus processor per declared message type, and stops them together\. A command message is read from its queue, an event from the subscription of this service on its topic\. A message type that needs sessions gets a session processor\. The SDK continues the trace of the sender from the `Diagnostic-Id` of the message\. |

| Interfaces | |
| :--- | :--- |
| [ICatEventProcessorTopology](ICatEventProcessorTopology.md 'Cat\.EventProcessor\.AzureServiceBus\.ICatEventProcessorTopology') | The easy way to create the subscriptions of this service\. A subscription belongs to the receiving service, so the service creates its own, while the topic comes from the sender, see `ICatServiceBusTopology`\. Nothing is created when the service starts\. It needs the manage right on the namespace\. |
