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
  
##### >> [Cat\.Inbox\.EFCore Assembly](index.md 'index') >> [Cat\.Inbox\.EFCore Namespace](Cat.Inbox.EFCore.md 'Cat\.Inbox\.EFCore')

## EfCoreInboxStore\<TDbContext\> Class

[ICatInboxStore](../../../Cat.Inbox/namespaces/Cat.Inbox.Abstractions/ICatInboxStore.md 'Cat\.Inbox\.Abstractions\.ICatInboxStore') on a `DbContext` of the service\.

```csharp
internal sealed class EfCoreInboxStore<TDbContext> : Cat.Inbox.Abstractions.ICatInboxStore
    where TDbContext : Microsoft.EntityFrameworkCore.DbContext
```
#### Type parameters

<a name='Cat.Inbox.EFCore.EfCoreInboxStore_TDbContext_.TDbContext'></a>

`TDbContext`

The context that holds the inbox table, see [AddCatInbox\(this ModelBuilder\)](ModelBuilderExtensions.AddCatInbox.63AAC2LQWDZDZ9K1VLGFR1HHB.md 'Cat\.Inbox\.EFCore\.ModelBuilderExtensions\.AddCatInbox\(this Microsoft\.EntityFrameworkCore\.ModelBuilder\)')\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → EfCoreInboxStore\<TDbContext\>

Implements [ICatInboxStore](../../../Cat.Inbox/namespaces/Cat.Inbox.Abstractions/ICatInboxStore.md 'Cat\.Inbox\.Abstractions\.ICatInboxStore')

| Constructors | |
| :--- | :--- |
| [EfCoreInboxStore\(TDbContext\)](EfCoreInboxStore_TDbContext_..ctor.3NDP0LCS64OG6ENCMLJ8E9S0F.md 'Cat\.Inbox\.EFCore\.EfCoreInboxStore\<TDbContext\>\.EfCoreInboxStore\(TDbContext\)') | Creates the store\. |

| Fields | |
| :--- | :--- |
| [\_dbContext](EfCoreInboxStore_TDbContext_._dbContext.md 'Cat\.Inbox\.EFCore\.EfCoreInboxStore\<TDbContext\>\.\_dbContext') | |

| Methods | |
| :--- | :--- |
| [Add\(string, string\)](EfCoreInboxStore_TDbContext_.Add.8520AR5FQZLUJWHGWT5HKWALE.md 'Cat\.Inbox\.EFCore\.EfCoreInboxStore\<TDbContext\>\.Add\(string, string\)') | Adds the message to the inbox\. It does not save by itself\. The `SaveChanges` of the handler saves it with the work\. |
| [DeleteOlderThanAsync\(DateTimeOffset, CancellationToken\)](EfCoreInboxStore_TDbContext_.DeleteOlderThanAsync.T3H8ACNC0L2Q4VN44IF79SNQ3.md 'Cat\.Inbox\.EFCore\.EfCoreInboxStore\<TDbContext\>\.DeleteOlderThanAsync\(System\.DateTimeOffset, System\.Threading\.CancellationToken\)') | Deletes the rows that were handled before the given time\. It runs at once and does not wait for a `SaveChanges`\. Call it from your own job\. Keep a row at least as long as the bus can still deliver the same message again\. |
| [ExistsAsync\(string, CancellationToken\)](EfCoreInboxStore_TDbContext_.ExistsAsync.M8IPLW4QKNSR7KJUJ5UH2QKF1.md 'Cat\.Inbox\.EFCore\.EfCoreInboxStore\<TDbContext\>\.ExistsAsync\(string, System\.Threading\.CancellationToken\)') | Tells whether the message was handled before\. |
