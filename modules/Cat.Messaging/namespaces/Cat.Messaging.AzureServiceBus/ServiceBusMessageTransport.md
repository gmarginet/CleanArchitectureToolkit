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

## ServiceBusMessageTransport Class

[ICatMessageTransport](../../../Cat.Messaging/namespaces/Cat.Messaging.Abstractions/ICatMessageTransport.md 'Cat\.Messaging\.Abstractions\.ICatMessageTransport') for Azure Service Bus\. A queue and a topic are both reached by a sender with the entity name\.

```csharp
internal sealed class ServiceBusMessageTransport : Cat.Messaging.Abstractions.ICatMessageTransport, System.IAsyncDisposable
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → ServiceBusMessageTransport

Implements [ICatMessageTransport](../../../Cat.Messaging/namespaces/Cat.Messaging.Abstractions/ICatMessageTransport.md 'Cat\.Messaging\.Abstractions\.ICatMessageTransport'), [System\.IAsyncDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.iasyncdisposable 'System\.IAsyncDisposable')

| Constructors | |
| :--- | :--- |
| [ServiceBusMessageTransport\(ServiceBusClient\)](ServiceBusMessageTransport..ctor.PKYVG6LTWB6ABL9P12QRW90GD.md 'Cat\.Messaging\.AzureServiceBus\.ServiceBusMessageTransport\.ServiceBusMessageTransport\(Azure\.Messaging\.ServiceBus\.ServiceBusClient\)') | Creates the transport\. |

| Fields | |
| :--- | :--- |
| [\_client](ServiceBusMessageTransport._client.md 'Cat\.Messaging\.AzureServiceBus\.ServiceBusMessageTransport\.\_client') | |
| [\_senders](ServiceBusMessageTransport._senders.md 'Cat\.Messaging\.AzureServiceBus\.ServiceBusMessageTransport\.\_senders') | |

| Methods | |
| :--- | :--- |
| [DisposeAsync\(\)](ServiceBusMessageTransport.DisposeAsync().md 'Cat\.Messaging\.AzureServiceBus\.ServiceBusMessageTransport\.DisposeAsync\(\)') | Performs application\-defined tasks associated with freeing, releasing, or resetting unmanaged resources asynchronously\. |
| [SendAsync\(CatOutgoingMessage, CancellationToken\)](ServiceBusMessageTransport.SendAsync.RJZTXQTZM1DKB3VQKYM6MBAV9.md 'Cat\.Messaging\.AzureServiceBus\.ServiceBusMessageTransport\.SendAsync\(Cat\.Messaging\.Abstractions\.CatOutgoingMessage, System\.Threading\.CancellationToken\)') | Sends a message to its queue or topic\. |
