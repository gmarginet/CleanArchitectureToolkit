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
  
##### >> [Cat\.Messaging\.Outbox Assembly](index.md 'index') >> [Cat\.Messaging\.Outbox Namespace](Cat.Messaging.Outbox.md 'Cat\.Messaging\.Outbox')

## OutboxSender Class

Background service that sends the pending messages of the outbox to the transport\.
A message is marked as sent after the transport accepted it, so a crash in between sends it twice, never zero times\.
A receiver must handle a message more than once, and duplicate detection of the bus helps with the same message ID\.

```csharp
internal sealed class OutboxSender : Microsoft.Extensions.Hosting.BackgroundService
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [Microsoft\.Extensions\.Hosting\.BackgroundService](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.hosting.backgroundservice 'Microsoft\.Extensions\.Hosting\.BackgroundService') → OutboxSender

| Constructors | |
| :--- | :--- |
| [OutboxSender\(IServiceScopeFactory, IOptions&lt;CatOutboxOptions&gt;, ILogger&lt;OutboxSender&gt;\)](OutboxSender..ctor.0IMLW5U28W1BWD9YQ59Z2LD4A.md 'Cat\.Messaging\.Outbox\.OutboxSender\.OutboxSender\(Microsoft\.Extensions\.DependencyInjection\.IServiceScopeFactory, Microsoft\.Extensions\.Options\.IOptions\<Cat\.Messaging\.Outbox\.CatOutboxOptions\>, Microsoft\.Extensions\.Logging\.ILogger\<Cat\.Messaging\.Outbox\.OutboxSender\>\)') | Creates the sender\. |

| Fields | |
| :--- | :--- |
| [\_logger](OutboxSender._logger.md 'Cat\.Messaging\.Outbox\.OutboxSender\.\_logger') | |
| [\_options](OutboxSender._options.md 'Cat\.Messaging\.Outbox\.OutboxSender\.\_options') | |
| [\_scopeFactory](OutboxSender._scopeFactory.md 'Cat\.Messaging\.Outbox\.OutboxSender\.\_scopeFactory') | |

| Methods | |
| :--- | :--- |
| [ExecuteAsync\(CancellationToken\)](OutboxSender.ExecuteAsync.KOERDX2BBLILJL6O2W3YM5T2B.md 'Cat\.Messaging\.Outbox\.OutboxSender\.ExecuteAsync\(System\.Threading\.CancellationToken\)') | |
| [SendPendingAsync\(CancellationToken\)](OutboxSender.SendPendingAsync.X406B14T2NFKBJ8VG6F754969.md 'Cat\.Messaging\.Outbox\.OutboxSender\.SendPendingAsync\(System\.Threading\.CancellationToken\)') | Sends one batch\. It stops at the first message that fails, so the order of the rest is kept\. |
