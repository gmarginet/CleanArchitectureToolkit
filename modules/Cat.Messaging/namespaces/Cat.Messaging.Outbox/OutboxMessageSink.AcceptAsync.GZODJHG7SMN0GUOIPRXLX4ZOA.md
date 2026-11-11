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
  
##### >> [Cat\.Messaging\.Outbox Assembly](index.md 'index') >> [Cat\.Messaging\.Outbox Namespace](Cat.Messaging.Outbox.md 'Cat\.Messaging\.Outbox') >> [OutboxMessageSink Class](OutboxMessageSink.md 'Cat\.Messaging\.Outbox\.OutboxMessageSink')

## OutboxMessageSink\.AcceptAsync\(CatOutgoingMessage, CancellationToken\) Method

Takes a message that is ready to leave the service\.

```csharp
public System.Threading.Tasks.Task AcceptAsync(Cat.Messaging.Abstractions.CatOutgoingMessage message, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Cat.Messaging.Outbox.OutboxMessageSink.AcceptAsync(Cat.Messaging.Abstractions.CatOutgoingMessage,System.Threading.CancellationToken).message'></a>

`message` [CatOutgoingMessage](../../../Cat.Messaging/namespaces/Cat.Messaging.Abstractions/CatOutgoingMessage.md 'Cat\.Messaging\.Abstractions\.CatOutgoingMessage')

The message to take\.

<a name='Cat.Messaging.Outbox.OutboxMessageSink.AcceptAsync(Cat.Messaging.Abstractions.CatOutgoingMessage,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Token to cancel the work\.

Implements [AcceptAsync\(CatOutgoingMessage, CancellationToken\)](../../../Cat.Messaging/namespaces/Cat.Messaging.Abstractions/ICatOutgoingMessageSink.AcceptAsync.AYIJDI2SZDK94W0MEDXVMRZTB.md 'Cat\.Messaging\.Abstractions\.ICatOutgoingMessageSink\.AcceptAsync\(Cat\.Messaging\.Abstractions\.CatOutgoingMessage,System\.Threading\.CancellationToken\)')

#### Returns
[System\.Threading\.Tasks\.Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task 'System\.Threading\.Tasks\.Task')  
A task that completes when the message is sent or stored\.