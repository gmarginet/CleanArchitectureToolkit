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
  
##### >> [Cat\.Messaging\.Outbox Assembly](index.md 'index')

## Cat\.Messaging\.Outbox Namespace

The outbox pattern for messages\. The sender stores a message in the same unit of work as the data,
and a background service sends the stored messages to the transport\.
The storage itself is behind [ICatOutboxStore](ICatOutboxStore.md 'Cat\.Messaging\.Outbox\.ICatOutboxStore')\.

| Classes | |
| :--- | :--- |
| [CatOutboxItem](CatOutboxItem.md 'Cat\.Messaging\.Outbox\.CatOutboxItem') | A message that waits in the outbox to be sent\. |
| [CatOutboxOptions](CatOutboxOptions.md 'Cat\.Messaging\.Outbox\.CatOutboxOptions') | Settings of the outbox sender\. |
| [OutboxMessageSink](OutboxMessageSink.md 'Cat\.Messaging\.Outbox\.OutboxMessageSink') | [ICatOutgoingMessageSink](../../../Cat.Messaging/namespaces/Cat.Messaging.Abstractions/ICatOutgoingMessageSink.md 'Cat\.Messaging\.Abstractions\.ICatOutgoingMessageSink') that stores the message in the outbox instead of sending it\. |
| [OutboxSender](OutboxSender.md 'Cat\.Messaging\.Outbox\.OutboxSender') | Background service that sends the pending messages of the outbox to the transport\. A message is marked as sent after the transport accepted it, so a crash in between sends it twice, never zero times\. A receiver must handle a message more than once, and duplicate detection of the bus helps with the same message ID\. |

| Interfaces | |
| :--- | :--- |
| [ICatOutboxStore](ICatOutboxStore.md 'Cat\.Messaging\.Outbox\.ICatOutboxStore') | Stores the messages of the outbox\. `Cat.Messaging.Outbox.EFCore` has the implementation for EF Core\. |
