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

## ServiceBusListener Class

Hosted service that starts one Azure Service Bus processor per declared message type, and stops them together\.
A command message is read from its queue, an event from the subscription of this service on its topic\.
A message type that needs sessions gets a session processor\.
The SDK continues the trace of the sender from the `Diagnostic-Id` of the message\.

```csharp
internal sealed class ServiceBusListener : Microsoft.Extensions.Hosting.IHostedService, System.IAsyncDisposable
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → ServiceBusListener

Implements [Microsoft\.Extensions\.Hosting\.IHostedService](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.hosting.ihostedservice 'Microsoft\.Extensions\.Hosting\.IHostedService'), [System\.IAsyncDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.iasyncdisposable 'System\.IAsyncDisposable')

| Constructors | |
| :--- | :--- |
| [ServiceBusListener\(ServiceBusClient, ICatReceiveRegistry, ICatMessageNameResolver, ICatMessageReceiver, IOptions&lt;CatEventProcessorServiceBusOptions&gt;, ListenerStatus, ILogger&lt;ServiceBusListener&gt;, IServiceProviderIsService\)](ServiceBusListener..ctor.YUZTTDA9U0SI87VM7YPBOETH1.md 'Cat\.EventProcessor\.AzureServiceBus\.ServiceBusListener\.ServiceBusListener\(Azure\.Messaging\.ServiceBus\.ServiceBusClient, Cat\.EventProcessor\.Abstractions\.ICatReceiveRegistry, Cat\.Messaging\.Abstractions\.ICatMessageNameResolver, Cat\.EventProcessor\.Abstractions\.ICatMessageReceiver, Microsoft\.Extensions\.Options\.IOptions\<Cat\.EventProcessor\.AzureServiceBus\.CatEventProcessorServiceBusOptions\>, Cat\.EventProcessor\.AzureServiceBus\.ListenerStatus, Microsoft\.Extensions\.Logging\.ILogger\<Cat\.EventProcessor\.AzureServiceBus\.ServiceBusListener\>, Microsoft\.Extensions\.DependencyInjection\.IServiceProviderIsService\)') | Creates the listener\. |

| Fields | |
| :--- | :--- |
| [\_client](ServiceBusListener._client.md 'Cat\.EventProcessor\.AzureServiceBus\.ServiceBusListener\.\_client') | |
| [\_disposables](ServiceBusListener._disposables.md 'Cat\.EventProcessor\.AzureServiceBus\.ServiceBusListener\.\_disposables') | |
| [\_logger](ServiceBusListener._logger.md 'Cat\.EventProcessor\.AzureServiceBus\.ServiceBusListener\.\_logger') | |
| [\_nameResolver](ServiceBusListener._nameResolver.md 'Cat\.EventProcessor\.AzureServiceBus\.ServiceBusListener\.\_nameResolver') | |
| [\_options](ServiceBusListener._options.md 'Cat\.EventProcessor\.AzureServiceBus\.ServiceBusListener\.\_options') | |
| [\_receiver](ServiceBusListener._receiver.md 'Cat\.EventProcessor\.AzureServiceBus\.ServiceBusListener\.\_receiver') | |
| [\_registry](ServiceBusListener._registry.md 'Cat\.EventProcessor\.AzureServiceBus\.ServiceBusListener\.\_registry') | |
| [\_serviceProviderIsService](ServiceBusListener._serviceProviderIsService.md 'Cat\.EventProcessor\.AzureServiceBus\.ServiceBusListener\.\_serviceProviderIsService') | |
| [\_status](ServiceBusListener._status.md 'Cat\.EventProcessor\.AzureServiceBus\.ServiceBusListener\.\_status') | |
| [\_stoppers](ServiceBusListener._stoppers.md 'Cat\.EventProcessor\.AzureServiceBus\.ServiceBusListener\.\_stoppers') | |

| Methods | |
| :--- | :--- |
| [BuildProcessorOptions\(Type, Nullable&lt;int&gt;, Action&lt;Type,ServiceBusProcessorOptions&gt;\)](ServiceBusListener.BuildProcessorOptions.39XKDZT5YV2SS7V63KU4DCS76.md 'Cat\.EventProcessor\.AzureServiceBus\.ServiceBusListener\.BuildProcessorOptions\(System\.Type, System\.Nullable\<int\>, System\.Action\<System\.Type,Azure\.Messaging\.ServiceBus\.ServiceBusProcessorOptions\>\)') | Builds the options of a processor\. The concurrency of the message type is set first, then the callback runs, and `AutoCompleteMessages` is set to false after it, because the listener settles every message itself\. |
| [BuildSessionProcessorOptions\(Type, Nullable&lt;int&gt;, Action&lt;Type,ServiceBusSessionProcessorOptions&gt;\)](ServiceBusListener.BuildSessionProcessorOptions.TVRCVCLBRA8SRSRT8L5BHRN73.md 'Cat\.EventProcessor\.AzureServiceBus\.ServiceBusListener\.BuildSessionProcessorOptions\(System\.Type, System\.Nullable\<int\>, System\.Action\<System\.Type,Azure\.Messaging\.ServiceBus\.ServiceBusSessionProcessorOptions\>\)') | Builds the options of a session processor\. The number of sessions of the message type is set first, then the callback runs, and `AutoCompleteMessages` is set to false after it, because the listener settles every message itself\. |
| [CheckInbox\(\)](ServiceBusListener.CheckInbox().md 'Cat\.EventProcessor\.AzureServiceBus\.ServiceBusListener\.CheckInbox\(\)') | |
| [DisposeAsync\(\)](ServiceBusListener.DisposeAsync().md 'Cat\.EventProcessor\.AzureServiceBus\.ServiceBusListener\.DisposeAsync\(\)') | Performs application\-defined tasks associated with freeing, releasing, or resetting unmanaged resources asynchronously\. |
| [HandleAsync\(Type, ServiceBusReceivedMessage, Func&lt;ServiceBusReceivedMessage,CancellationToken,Task&gt;, Func&lt;ServiceBusReceivedMessage,IDictionary&lt;string,object&gt;,CancellationToken,Task&gt;, Func&lt;ServiceBusReceivedMessage,string,string,CancellationToken,Task&gt;, CancellationToken\)](ServiceBusListener.HandleAsync.EFCP6ZUQDHPHO76C9FIWHHP85.md 'Cat\.EventProcessor\.AzureServiceBus\.ServiceBusListener\.HandleAsync\(System\.Type, Azure\.Messaging\.ServiceBus\.ServiceBusReceivedMessage, System\.Func\<Azure\.Messaging\.ServiceBus\.ServiceBusReceivedMessage,System\.Threading\.CancellationToken,System\.Threading\.Tasks\.Task\>, System\.Func\<Azure\.Messaging\.ServiceBus\.ServiceBusReceivedMessage,System\.Collections\.Generic\.IDictionary\<string,object\>,System\.Threading\.CancellationToken,System\.Threading\.Tasks\.Task\>, System\.Func\<Azure\.Messaging\.ServiceBus\.ServiceBusReceivedMessage,string,string,System\.Threading\.CancellationToken,System\.Threading\.Tasks\.Task\>, System\.Threading\.CancellationToken\)') | |
| [HandleErrorAsync\(ProcessErrorEventArgs\)](ServiceBusListener.HandleErrorAsync.V7RGSN5A73F1XAZB2CRDRSL4.md 'Cat\.EventProcessor\.AzureServiceBus\.ServiceBusListener\.HandleErrorAsync\(Azure\.Messaging\.ServiceBus\.ProcessErrorEventArgs\)') | |
| [StartAsync\(CancellationToken\)](ServiceBusListener.StartAsync.EMSST205AWUWVFWT2RNZ0W8X9.md 'Cat\.EventProcessor\.AzureServiceBus\.ServiceBusListener\.StartAsync\(System\.Threading\.CancellationToken\)') | Triggered when the application host is ready to start the service\. |
| [StartListenerAsync\(CatReceiveRegistration, CancellationToken\)](ServiceBusListener.StartListenerAsync.NPHWLBB48REQFYUA2C5ZUNJM3.md 'Cat\.EventProcessor\.AzureServiceBus\.ServiceBusListener\.StartListenerAsync\(Cat\.EventProcessor\.Abstractions\.CatReceiveRegistration, System\.Threading\.CancellationToken\)') | |
| [StopAsync\(CancellationToken\)](ServiceBusListener.StopAsync.81VAPC41JHSL14Q243AKDSTG.md 'Cat\.EventProcessor\.AzureServiceBus\.ServiceBusListener\.StopAsync\(System\.Threading\.CancellationToken\)') | Stops taking new messages and waits for the messages that are running\. |
