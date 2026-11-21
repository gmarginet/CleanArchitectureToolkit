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
  
##### >> [Cat\.Outbox\.Abstractions Assembly](index.md 'index') >> [Cat\.Outbox\.Abstractions Namespace](Cat.Outbox.Abstractions.md 'Cat\.Outbox\.Abstractions')

## ICatOutboxStore Interface

Stores the messages of the outbox\. `Cat.Outbox.EFCore` has the implementation for EF Core\.

```csharp
public interface ICatOutboxStore
```

| Methods | |
| :--- | :--- |
| [AddAsync\(CatOutgoingMessage, CancellationToken\)](ICatOutboxStore.AddAsync.57PSOWRE56DIX02KNN37FCH98.md 'Cat\.Outbox\.Abstractions\.ICatOutboxStore\.AddAsync\(Cat\.Messaging\.Abstractions\.CatOutgoingMessage, System\.Threading\.CancellationToken\)') | Adds a message to the outbox\. It does not save by itself\. The unit of work that saves the data saves the message too, which is the whole point of the outbox\. |
| [DeleteOlderThanAsync\(DateTimeOffset, CancellationToken\)](ICatOutboxStore.DeleteOlderThanAsync.08TV8F6OJVWJDB71AKLD87UO6.md 'Cat\.Outbox\.Abstractions\.ICatOutboxStore\.DeleteOlderThanAsync\(System\.DateTimeOffset, System\.Threading\.CancellationToken\)') | Deletes the rows that were sent before the given time\. A row that is not sent yet is never deleted\. It runs at once and does not wait for a `SaveChanges`\. Call it from your own job\. Keep a sent row for a while, so you can still look up a message that went missing\. |
| [GetPendingAsync\(int, CancellationToken\)](ICatOutboxStore.GetPendingAsync.4UC1ZTDL0H22ZHCG22HT14XPE.md 'Cat\.Outbox\.Abstractions\.ICatOutboxStore\.GetPendingAsync\(int, System\.Threading\.CancellationToken\)') | Gets the messages that are not sent yet, oldest first\. |
| [MarkSentAsync\(Guid, CancellationToken\)](ICatOutboxStore.MarkSentAsync.2F803FDL0KU53NXFPHKWHKZT7.md 'Cat\.Outbox\.Abstractions\.ICatOutboxStore\.MarkSentAsync\(System\.Guid, System\.Threading\.CancellationToken\)') | Marks a message as sent and saves that\. |
