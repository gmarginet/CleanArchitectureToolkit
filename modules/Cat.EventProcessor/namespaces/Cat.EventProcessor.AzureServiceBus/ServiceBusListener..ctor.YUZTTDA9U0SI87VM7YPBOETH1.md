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
  
##### >> [Cat\.EventProcessor\.AzureServiceBus Assembly](index.md 'index') >> [Cat\.EventProcessor\.AzureServiceBus Namespace](Cat.EventProcessor.AzureServiceBus.md 'Cat\.EventProcessor\.AzureServiceBus') >> [ServiceBusListener Class](ServiceBusListener.md 'Cat\.EventProcessor\.AzureServiceBus\.ServiceBusListener')

## ServiceBusListener\(ServiceBusClient, ICatReceiveRegistry, ICatMessageNameResolver, ICatMessageReceiver, IOptions\<CatEventProcessorServiceBusOptions\>, ListenerStatus, ILogger\<ServiceBusListener\>, IServiceProviderIsService\) Constructor

Creates the listener\.

```csharp
public ServiceBusListener(Azure.Messaging.ServiceBus.ServiceBusClient client, Cat.EventProcessor.Abstractions.ICatReceiveRegistry registry, Cat.Messaging.Abstractions.ICatMessageNameResolver nameResolver, Cat.EventProcessor.Abstractions.ICatMessageReceiver receiver, Microsoft.Extensions.Options.IOptions<Cat.EventProcessor.AzureServiceBus.CatEventProcessorServiceBusOptions> options, Cat.EventProcessor.AzureServiceBus.ListenerStatus status, Microsoft.Extensions.Logging.ILogger<Cat.EventProcessor.AzureServiceBus.ServiceBusListener> logger, Microsoft.Extensions.DependencyInjection.IServiceProviderIsService serviceProviderIsService);
```
#### Parameters

<a name='Cat.EventProcessor.AzureServiceBus.ServiceBusListener.ServiceBusListener(Azure.Messaging.ServiceBus.ServiceBusClient,Cat.EventProcessor.Abstractions.ICatReceiveRegistry,Cat.Messaging.Abstractions.ICatMessageNameResolver,Cat.EventProcessor.Abstractions.ICatMessageReceiver,Microsoft.Extensions.Options.IOptions_Cat.EventProcessor.AzureServiceBus.CatEventProcessorServiceBusOptions_,Cat.EventProcessor.AzureServiceBus.ListenerStatus,Microsoft.Extensions.Logging.ILogger_Cat.EventProcessor.AzureServiceBus.ServiceBusListener_,Microsoft.Extensions.DependencyInjection.IServiceProviderIsService).client'></a>

`client` [Azure\.Messaging\.ServiceBus\.ServiceBusClient](https://learn.microsoft.com/en-us/dotnet/api/azure.messaging.servicebus.servicebusclient 'Azure\.Messaging\.ServiceBus\.ServiceBusClient')

The shared Service Bus client\.

<a name='Cat.EventProcessor.AzureServiceBus.ServiceBusListener.ServiceBusListener(Azure.Messaging.ServiceBus.ServiceBusClient,Cat.EventProcessor.Abstractions.ICatReceiveRegistry,Cat.Messaging.Abstractions.ICatMessageNameResolver,Cat.EventProcessor.Abstractions.ICatMessageReceiver,Microsoft.Extensions.Options.IOptions_Cat.EventProcessor.AzureServiceBus.CatEventProcessorServiceBusOptions_,Cat.EventProcessor.AzureServiceBus.ListenerStatus,Microsoft.Extensions.Logging.ILogger_Cat.EventProcessor.AzureServiceBus.ServiceBusListener_,Microsoft.Extensions.DependencyInjection.IServiceProviderIsService).registry'></a>

`registry` [ICatReceiveRegistry](../../../Cat.EventProcessor/namespaces/Cat.EventProcessor.Abstractions/ICatReceiveRegistry.md 'Cat\.EventProcessor\.Abstractions\.ICatReceiveRegistry')

The declared message types\.

<a name='Cat.EventProcessor.AzureServiceBus.ServiceBusListener.ServiceBusListener(Azure.Messaging.ServiceBus.ServiceBusClient,Cat.EventProcessor.Abstractions.ICatReceiveRegistry,Cat.Messaging.Abstractions.ICatMessageNameResolver,Cat.EventProcessor.Abstractions.ICatMessageReceiver,Microsoft.Extensions.Options.IOptions_Cat.EventProcessor.AzureServiceBus.CatEventProcessorServiceBusOptions_,Cat.EventProcessor.AzureServiceBus.ListenerStatus,Microsoft.Extensions.Logging.ILogger_Cat.EventProcessor.AzureServiceBus.ServiceBusListener_,Microsoft.Extensions.DependencyInjection.IServiceProviderIsService).nameResolver'></a>

`nameResolver` [ICatMessageNameResolver](../../../Cat.Messaging/namespaces/Cat.Messaging.Abstractions/ICatMessageNameResolver.md 'Cat\.Messaging\.Abstractions\.ICatMessageNameResolver')

Finds the queue or topic name and the kind of a message type\.

<a name='Cat.EventProcessor.AzureServiceBus.ServiceBusListener.ServiceBusListener(Azure.Messaging.ServiceBus.ServiceBusClient,Cat.EventProcessor.Abstractions.ICatReceiveRegistry,Cat.Messaging.Abstractions.ICatMessageNameResolver,Cat.EventProcessor.Abstractions.ICatMessageReceiver,Microsoft.Extensions.Options.IOptions_Cat.EventProcessor.AzureServiceBus.CatEventProcessorServiceBusOptions_,Cat.EventProcessor.AzureServiceBus.ListenerStatus,Microsoft.Extensions.Logging.ILogger_Cat.EventProcessor.AzureServiceBus.ServiceBusListener_,Microsoft.Extensions.DependencyInjection.IServiceProviderIsService).receiver'></a>

`receiver` [ICatMessageReceiver](../../../Cat.EventProcessor/namespaces/Cat.EventProcessor.Abstractions/ICatMessageReceiver.md 'Cat\.EventProcessor\.Abstractions\.ICatMessageReceiver')

Handles one message\.

<a name='Cat.EventProcessor.AzureServiceBus.ServiceBusListener.ServiceBusListener(Azure.Messaging.ServiceBus.ServiceBusClient,Cat.EventProcessor.Abstractions.ICatReceiveRegistry,Cat.Messaging.Abstractions.ICatMessageNameResolver,Cat.EventProcessor.Abstractions.ICatMessageReceiver,Microsoft.Extensions.Options.IOptions_Cat.EventProcessor.AzureServiceBus.CatEventProcessorServiceBusOptions_,Cat.EventProcessor.AzureServiceBus.ListenerStatus,Microsoft.Extensions.Logging.ILogger_Cat.EventProcessor.AzureServiceBus.ServiceBusListener_,Microsoft.Extensions.DependencyInjection.IServiceProviderIsService).options'></a>

`options` [Microsoft\.Extensions\.Options\.IOptions&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.options.ioptions-1 'Microsoft\.Extensions\.Options\.IOptions\`1')[CatEventProcessorServiceBusOptions](CatEventProcessorServiceBusOptions.md 'Cat\.EventProcessor\.AzureServiceBus\.CatEventProcessorServiceBusOptions')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.options.ioptions-1 'Microsoft\.Extensions\.Options\.IOptions\`1')

The settings of the listener\.

<a name='Cat.EventProcessor.AzureServiceBus.ServiceBusListener.ServiceBusListener(Azure.Messaging.ServiceBus.ServiceBusClient,Cat.EventProcessor.Abstractions.ICatReceiveRegistry,Cat.Messaging.Abstractions.ICatMessageNameResolver,Cat.EventProcessor.Abstractions.ICatMessageReceiver,Microsoft.Extensions.Options.IOptions_Cat.EventProcessor.AzureServiceBus.CatEventProcessorServiceBusOptions_,Cat.EventProcessor.AzureServiceBus.ListenerStatus,Microsoft.Extensions.Logging.ILogger_Cat.EventProcessor.AzureServiceBus.ServiceBusListener_,Microsoft.Extensions.DependencyInjection.IServiceProviderIsService).status'></a>

`status` [ListenerStatus](ListenerStatus.md 'Cat\.EventProcessor\.AzureServiceBus\.ListenerStatus')

The state of the listeners, for the health check\.

<a name='Cat.EventProcessor.AzureServiceBus.ServiceBusListener.ServiceBusListener(Azure.Messaging.ServiceBus.ServiceBusClient,Cat.EventProcessor.Abstractions.ICatReceiveRegistry,Cat.Messaging.Abstractions.ICatMessageNameResolver,Cat.EventProcessor.Abstractions.ICatMessageReceiver,Microsoft.Extensions.Options.IOptions_Cat.EventProcessor.AzureServiceBus.CatEventProcessorServiceBusOptions_,Cat.EventProcessor.AzureServiceBus.ListenerStatus,Microsoft.Extensions.Logging.ILogger_Cat.EventProcessor.AzureServiceBus.ServiceBusListener_,Microsoft.Extensions.DependencyInjection.IServiceProviderIsService).logger'></a>

`logger` [Microsoft\.Extensions\.Logging\.ILogger&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')[ServiceBusListener](ServiceBusListener.md 'Cat\.EventProcessor\.AzureServiceBus\.ServiceBusListener')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')

The logger\.

<a name='Cat.EventProcessor.AzureServiceBus.ServiceBusListener.ServiceBusListener(Azure.Messaging.ServiceBus.ServiceBusClient,Cat.EventProcessor.Abstractions.ICatReceiveRegistry,Cat.Messaging.Abstractions.ICatMessageNameResolver,Cat.EventProcessor.Abstractions.ICatMessageReceiver,Microsoft.Extensions.Options.IOptions_Cat.EventProcessor.AzureServiceBus.CatEventProcessorServiceBusOptions_,Cat.EventProcessor.AzureServiceBus.ListenerStatus,Microsoft.Extensions.Logging.ILogger_Cat.EventProcessor.AzureServiceBus.ServiceBusListener_,Microsoft.Extensions.DependencyInjection.IServiceProviderIsService).serviceProviderIsService'></a>

`serviceProviderIsService` [Microsoft\.Extensions\.DependencyInjection\.IServiceProviderIsService](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iserviceproviderisservice 'Microsoft\.Extensions\.DependencyInjection\.IServiceProviderIsService')

Tells whether the service registered an inbox store\.