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

## ICatOutboxStore Interface

Stores the messages of the outbox\. `Cat.Messaging.Outbox.EFCore` has the implementation for EF Core\.

```csharp
public interface ICatOutboxStore
```

| Methods | |
| :--- | :--- |
| [AddAsync\(CatOutgoingMessage, CancellationToken\)](ICatOutboxStore.AddAsync.YFPZP6FGJ9SSI4M7BALC88ZXC.md 'Cat\.Messaging\.Outbox\.ICatOutboxStore\.AddAsync\(Cat\.Messaging\.Abstractions\.CatOutgoingMessage, System\.Threading\.CancellationToken\)') | Adds a message to the outbox\. It does not save by itself\. The unit of work that saves the data saves the message too, which is the whole point of the outbox\. |
| [GetPendingAsync\(int, CancellationToken\)](ICatOutboxStore.GetPendingAsync.6DHIU6ZXYUHR1N6AEHJY1EVQ3.md 'Cat\.Messaging\.Outbox\.ICatOutboxStore\.GetPendingAsync\(int, System\.Threading\.CancellationToken\)') | Gets the messages that are not sent yet, oldest first\. |
| [MarkSentAsync\(Guid, CancellationToken\)](ICatOutboxStore.MarkSentAsync.1A6P64PUZ7EVYJPQ7C4FAPIBC.md 'Cat\.Messaging\.Outbox\.ICatOutboxStore\.MarkSentAsync\(System\.Guid, System\.Threading\.CancellationToken\)') | Marks a message as sent and saves that\. |
