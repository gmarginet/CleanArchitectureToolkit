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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.INBOX](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Inbox\.Abstractions Assembly](index.md 'index') >> [Cat\.Inbox\.Abstractions Namespace](Cat.Inbox.Abstractions.md 'Cat\.Inbox\.Abstractions')

## ICatInboxStore Interface

Remembers which messages or calls the service handled\. The receiver of `Cat.EventProcessor` and the endpoint filter
of `Cat.Inbox.AspNetCore` call it\. The store works on the context of the current scope,
the same one the handler uses, so the row is saved by the `SaveChanges` of the handler\.

```csharp
public interface ICatInboxStore
```

| Methods | |
| :--- | :--- |
| [Add\(string, string\)](ICatInboxStore.Add.U5V1EPHTLIOR0PP9HU7E6POH5.md 'Cat\.Inbox\.Abstractions\.ICatInboxStore\.Add\(string, string\)') | Adds the message to the inbox\. It does not save by itself\. The `SaveChanges` of the handler saves it with the work\. |
| [DeleteOlderThanAsync\(DateTimeOffset, CancellationToken\)](ICatInboxStore.DeleteOlderThanAsync.ZSNZ2XNKS2TRPMDQ6MEZAWH6.md 'Cat\.Inbox\.Abstractions\.ICatInboxStore\.DeleteOlderThanAsync\(System\.DateTimeOffset, System\.Threading\.CancellationToken\)') | Deletes the rows that were handled before the given time\. It runs at once and does not wait for a `SaveChanges`\. Call it from your own job\. Keep a row at least as long as the bus can still deliver the same message again\. |
| [ExistsAsync\(string, CancellationToken\)](ICatInboxStore.ExistsAsync.NC4ZVEIUW9TNMFK0HOYNLR8L8.md 'Cat\.Inbox\.Abstractions\.ICatInboxStore\.ExistsAsync\(string, System\.Threading\.CancellationToken\)') | Tells whether the message was handled before\. |
