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
  
##### >> [Cat\.Messaging\.Outbox\.EFCore Assembly](index.md 'index') >> [Cat\.Messaging\.Outbox\.EFCore Namespace](Cat.Messaging.Outbox.EFCore.md 'Cat\.Messaging\.Outbox\.EFCore')

## EfCoreOutboxStore\<TDbContext\> Class

[ICatOutboxStore](../../../Cat.Messaging/namespaces/Cat.Messaging.Outbox/ICatOutboxStore.md 'Cat\.Messaging\.Outbox\.ICatOutboxStore') on a `DbContext` of the service\.

```csharp
internal sealed class EfCoreOutboxStore<TDbContext> : Cat.Messaging.Outbox.ICatOutboxStore
    where TDbContext : Microsoft.EntityFrameworkCore.DbContext
```
#### Type parameters

<a name='Cat.Messaging.Outbox.EFCore.EfCoreOutboxStore_TDbContext_.TDbContext'></a>

`TDbContext`

The context that holds the outbox table, see [AddCatOutbox\(this ModelBuilder\)](ModelBuilderExtensions.AddCatOutbox.0V31BQIBB44RJQ2TOGMYYN8P.md 'Cat\.Messaging\.Outbox\.EFCore\.ModelBuilderExtensions\.AddCatOutbox\(this Microsoft\.EntityFrameworkCore\.ModelBuilder\)')\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → EfCoreOutboxStore\<TDbContext\>

Implements [ICatOutboxStore](../../../Cat.Messaging/namespaces/Cat.Messaging.Outbox/ICatOutboxStore.md 'Cat\.Messaging\.Outbox\.ICatOutboxStore')

| Constructors | |
| :--- | :--- |
| [EfCoreOutboxStore\(TDbContext\)](EfCoreOutboxStore_TDbContext_..ctor.CMH8AFD1MAFKL14M0CH5BVR99.md 'Cat\.Messaging\.Outbox\.EFCore\.EfCoreOutboxStore\<TDbContext\>\.EfCoreOutboxStore\(TDbContext\)') | Creates the store\. |

| Fields | |
| :--- | :--- |
| [\_dbContext](EfCoreOutboxStore_TDbContext_._dbContext.md 'Cat\.Messaging\.Outbox\.EFCore\.EfCoreOutboxStore\<TDbContext\>\.\_dbContext') | |

| Methods | |
| :--- | :--- |
| [AddAsync\(CatOutgoingMessage, CancellationToken\)](EfCoreOutboxStore_TDbContext_.AddAsync.6Q12RQL78XRX34T7Y0HMMKGA1.md 'Cat\.Messaging\.Outbox\.EFCore\.EfCoreOutboxStore\<TDbContext\>\.AddAsync\(Cat\.Messaging\.Abstractions\.CatOutgoingMessage, System\.Threading\.CancellationToken\)') | Adds a message to the outbox\. It does not save by itself\. The unit of work that saves the data saves the message too, which is the whole point of the outbox\. |
| [GetPendingAsync\(int, CancellationToken\)](EfCoreOutboxStore_TDbContext_.GetPendingAsync.UNO0VBIGTPEEQCB1J3NWDIDEA.md 'Cat\.Messaging\.Outbox\.EFCore\.EfCoreOutboxStore\<TDbContext\>\.GetPendingAsync\(int, System\.Threading\.CancellationToken\)') | Gets the messages that are not sent yet, oldest first\. |
| [MarkSentAsync\(Guid, CancellationToken\)](EfCoreOutboxStore_TDbContext_.MarkSentAsync.A8R58MCHOW0LV6UZD94CPRYZE.md 'Cat\.Messaging\.Outbox\.EFCore\.EfCoreOutboxStore\<TDbContext\>\.MarkSentAsync\(System\.Guid, System\.Threading\.CancellationToken\)') | Marks a message as sent and saves that\. |
