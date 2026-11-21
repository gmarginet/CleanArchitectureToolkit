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
  
##### >> [Cat\.Outbox\.EFCore Assembly](index.md 'index') >> [Cat\.Outbox\.EFCore Namespace](Cat.Outbox.EFCore.md 'Cat\.Outbox\.EFCore')

## EfCoreOutboxStore\<TDbContext\> Class

[ICatOutboxStore](../../../Cat.Outbox/namespaces/Cat.Outbox.Abstractions/ICatOutboxStore.md 'Cat\.Outbox\.Abstractions\.ICatOutboxStore') on a `DbContext` of the service\.

```csharp
internal sealed class EfCoreOutboxStore<TDbContext> : Cat.Outbox.Abstractions.ICatOutboxStore
    where TDbContext : Microsoft.EntityFrameworkCore.DbContext
```
#### Type parameters

<a name='Cat.Outbox.EFCore.EfCoreOutboxStore_TDbContext_.TDbContext'></a>

`TDbContext`

The context that holds the outbox table, see [AddCatOutbox\(this ModelBuilder\)](ModelBuilderExtensions.AddCatOutbox.4MBVYQYL34QU6L00E6KOBZ401.md 'Cat\.Outbox\.EFCore\.ModelBuilderExtensions\.AddCatOutbox\(this Microsoft\.EntityFrameworkCore\.ModelBuilder\)')\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → EfCoreOutboxStore\<TDbContext\>

Implements [ICatOutboxStore](../../../Cat.Outbox/namespaces/Cat.Outbox.Abstractions/ICatOutboxStore.md 'Cat\.Outbox\.Abstractions\.ICatOutboxStore')

| Constructors | |
| :--- | :--- |
| [EfCoreOutboxStore\(TDbContext\)](EfCoreOutboxStore_TDbContext_..ctor.33XNLYWYXE4DAPDQ5P6VZDCW7.md 'Cat\.Outbox\.EFCore\.EfCoreOutboxStore\<TDbContext\>\.EfCoreOutboxStore\(TDbContext\)') | Creates the store\. |

| Fields | |
| :--- | :--- |
| [DiagnosticIdProperty](EfCoreOutboxStore_TDbContext_.DiagnosticIdProperty.md 'Cat\.Outbox\.EFCore\.EfCoreOutboxStore\<TDbContext\>\.DiagnosticIdProperty') | |
| [\_dbContext](EfCoreOutboxStore_TDbContext_._dbContext.md 'Cat\.Outbox\.EFCore\.EfCoreOutboxStore\<TDbContext\>\.\_dbContext') | |

| Methods | |
| :--- | :--- |
| [AddAsync\(CatOutgoingMessage, CancellationToken\)](EfCoreOutboxStore_TDbContext_.AddAsync.HT2EO1HIC3AJRPB40QLF0OS99.md 'Cat\.Outbox\.EFCore\.EfCoreOutboxStore\<TDbContext\>\.AddAsync\(Cat\.Messaging\.Abstractions\.CatOutgoingMessage, System\.Threading\.CancellationToken\)') | Adds a message to the outbox\. It does not save by itself\. The unit of work that saves the data saves the message too, which is the whole point of the outbox\. |
| [CurrentTraceParent\(\)](EfCoreOutboxStore_TDbContext_.CurrentTraceParent().md 'Cat\.Outbox\.EFCore\.EfCoreOutboxStore\<TDbContext\>\.CurrentTraceParent\(\)') | |
| [DeleteOlderThanAsync\(DateTimeOffset, CancellationToken\)](EfCoreOutboxStore_TDbContext_.DeleteOlderThanAsync.3LIVI73XW5QKKG1K5MPBP9AVC.md 'Cat\.Outbox\.EFCore\.EfCoreOutboxStore\<TDbContext\>\.DeleteOlderThanAsync\(System\.DateTimeOffset, System\.Threading\.CancellationToken\)') | Deletes the rows that were sent before the given time\. A row that is not sent yet is never deleted\. It runs at once and does not wait for a `SaveChanges`\. Call it from your own job\. Keep a sent row for a while, so you can still look up a message that went missing\. |
| [GetPendingAsync\(int, CancellationToken\)](EfCoreOutboxStore_TDbContext_.GetPendingAsync.IWIWW0FH5JWY57H83OVHJLC91.md 'Cat\.Outbox\.EFCore\.EfCoreOutboxStore\<TDbContext\>\.GetPendingAsync\(int, System\.Threading\.CancellationToken\)') | Gets the messages that are not sent yet, oldest first\. |
| [MarkSentAsync\(Guid, CancellationToken\)](EfCoreOutboxStore_TDbContext_.MarkSentAsync.HBS768ERW4P09XF58QW3R4W0F.md 'Cat\.Outbox\.EFCore\.EfCoreOutboxStore\<TDbContext\>\.MarkSentAsync\(System\.Guid, System\.Threading\.CancellationToken\)') | Marks a message as sent and saves that\. |
| [ReadProperties\(CatOutboxMessage\)](EfCoreOutboxStore_TDbContext_.ReadProperties.2HPN4I9SUMFFXRDWF4576L15C.md 'Cat\.Outbox\.EFCore\.EfCoreOutboxStore\<TDbContext\>\.ReadProperties\(Cat\.Outbox\.EFCore\.CatOutboxMessage\)') | |
