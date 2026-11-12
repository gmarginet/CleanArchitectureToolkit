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
  
##### >> [Cat\.Messaging\.AzureServiceBus Assembly](index.md 'index')

## Cat\.Messaging\.AzureServiceBus Namespace

The Azure Service Bus transport of the messaging module\.
It sends messages to queues and topics, creates the entities on request and can publish a metric for the dead letters\.

| Classes | |
| :--- | :--- |
| [CatDeadLetterMetricsOptions](CatDeadLetterMetricsOptions.md 'Cat\.Messaging\.AzureServiceBus\.CatDeadLetterMetricsOptions') | Settings of the dead letter metric\. The metric is off until the developer adds it, because reading the counts needs the manage right on the namespace\. |
| [CatDeadLetterSubscription](CatDeadLetterSubscription.md 'Cat\.Messaging\.AzureServiceBus\.CatDeadLetterSubscription') | A subscription to watch for dead letters\. |
| [CatServiceBusMessageMapper](CatServiceBusMessageMapper.md 'Cat\.Messaging\.AzureServiceBus\.CatServiceBusMessageMapper') | Turns a [CatOutgoingMessage](../../../Cat.Messaging/namespaces/Cat.Messaging.Abstractions/CatOutgoingMessage.md 'Cat\.Messaging\.Abstractions\.CatOutgoingMessage') into a Service Bus message\. |
| [CatServiceBusOptions](CatServiceBusOptions.md 'Cat\.Messaging\.AzureServiceBus\.CatServiceBusOptions') | Settings of the Azure Service Bus transport\. The module starts from the defaults of Azure Service Bus\. Every `Configure` callback gets the SDK options after the module has filled in its own values, so you can change anything\. |
| [DeadLetterMetricsService](DeadLetterMetricsService.md 'Cat\.Messaging\.AzureServiceBus\.DeadLetterMetricsService') | Reads the dead letter counts on an interval and publishes them as the gauge `cat.messaging.dead_letters` on the meter `Cat.Messaging`\. A dashboard that listens to the meter, such as the Aspire dashboard, shows it\. |
| [ServiceBusMessageTransport](ServiceBusMessageTransport.md 'Cat\.Messaging\.AzureServiceBus\.ServiceBusMessageTransport') | [ICatMessageTransport](../../../Cat.Messaging/namespaces/Cat.Messaging.Abstractions/ICatMessageTransport.md 'Cat\.Messaging\.Abstractions\.ICatMessageTransport') for Azure Service Bus\. A queue and a topic are both reached by a sender with the entity name\. |
| [ServiceBusTopology](ServiceBusTopology.md 'Cat\.Messaging\.AzureServiceBus\.ServiceBusTopology') | Default [ICatServiceBusTopology](ICatServiceBusTopology.md 'Cat\.Messaging\.AzureServiceBus\.ICatServiceBusTopology'), on the administration client\. |

| Interfaces | |
| :--- | :--- |
| [ICatServiceBusTopology](ICatServiceBusTopology.md 'Cat\.Messaging\.AzureServiceBus\.ICatServiceBusTopology') | The easy way to create the queues and topics of the message types\. Nothing is created when a service starts\. Call it from a deployment step, a small tool or a test\. It needs the manage right on the namespace\. |
