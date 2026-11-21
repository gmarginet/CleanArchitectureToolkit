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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.OUTBOX](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Outbox Assembly](index.md 'index') >> [Cat\.Outbox Namespace](Cat.Outbox.md 'Cat\.Outbox')

## OutboxMessageSink Class

[ICatOutgoingMessageSink](../../../Cat.Messaging/namespaces/Cat.Messaging.Abstractions/ICatOutgoingMessageSink.md 'Cat\.Messaging\.Abstractions\.ICatOutgoingMessageSink') that stores the message in the outbox instead of sending it\.

```csharp
internal sealed class OutboxMessageSink : Cat.Messaging.Abstractions.ICatOutgoingMessageSink
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → OutboxMessageSink

Implements [ICatOutgoingMessageSink](../../../Cat.Messaging/namespaces/Cat.Messaging.Abstractions/ICatOutgoingMessageSink.md 'Cat\.Messaging\.Abstractions\.ICatOutgoingMessageSink')

| Constructors | |
| :--- | :--- |
| [OutboxMessageSink\(ICatOutboxStore\)](OutboxMessageSink..ctor.Q69O52GBKBT7H4TWZD0515JG4.md 'Cat\.Outbox\.OutboxMessageSink\.OutboxMessageSink\(Cat\.Outbox\.Abstractions\.ICatOutboxStore\)') | Creates the sink\. |

| Fields | |
| :--- | :--- |
| [\_store](OutboxMessageSink._store.md 'Cat\.Outbox\.OutboxMessageSink\.\_store') | |

| Methods | |
| :--- | :--- |
| [AcceptAsync\(CatOutgoingMessage, CancellationToken\)](OutboxMessageSink.AcceptAsync.XRXP38UDS0TKRW9LQ4XK2S2N5.md 'Cat\.Outbox\.OutboxMessageSink\.AcceptAsync\(Cat\.Messaging\.Abstractions\.CatOutgoingMessage, System\.Threading\.CancellationToken\)') | Takes a message that is ready to leave the service\. |
