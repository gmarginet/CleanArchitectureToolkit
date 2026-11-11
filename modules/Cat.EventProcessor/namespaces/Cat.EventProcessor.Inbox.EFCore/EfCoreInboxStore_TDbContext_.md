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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.EVENTPROCESSOR](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.EventProcessor\.Inbox\.EFCore Assembly](index.md 'index') >> [Cat\.EventProcessor\.Inbox\.EFCore Namespace](Cat.EventProcessor.Inbox.EFCore.md 'Cat\.EventProcessor\.Inbox\.EFCore')

## EfCoreInboxStore\<TDbContext\> Class

[ICatInboxStore](ICatInboxStore.md 'Cat\.EventProcessor\.Inbox\.EFCore\.ICatInboxStore') on a `DbContext` of the service\.

```csharp
internal sealed class EfCoreInboxStore<TDbContext> : Cat.EventProcessor.Inbox.EFCore.ICatInboxStore
    where TDbContext : Microsoft.EntityFrameworkCore.DbContext
```
#### Type parameters

<a name='Cat.EventProcessor.Inbox.EFCore.EfCoreInboxStore_TDbContext_.TDbContext'></a>

`TDbContext`

The context that holds the inbox table, see [AddCatInbox\(this ModelBuilder\)](ModelBuilderExtensions.AddCatInbox.E9EHKR34AM1DFIZQXF0V8XE9A.md 'Cat\.EventProcessor\.Inbox\.EFCore\.ModelBuilderExtensions\.AddCatInbox\(this Microsoft\.EntityFrameworkCore\.ModelBuilder\)')\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → EfCoreInboxStore\<TDbContext\>

Implements [ICatInboxStore](ICatInboxStore.md 'Cat\.EventProcessor\.Inbox\.EFCore\.ICatInboxStore')

| Constructors | |
| :--- | :--- |
| [EfCoreInboxStore\(TDbContext\)](EfCoreInboxStore_TDbContext_..ctor.3U6HOEXUCCT1SKNIVKS10VZKB.md 'Cat\.EventProcessor\.Inbox\.EFCore\.EfCoreInboxStore\<TDbContext\>\.EfCoreInboxStore\(TDbContext\)') | Creates the store\. |

| Fields | |
| :--- | :--- |
| [\_dbContext](EfCoreInboxStore_TDbContext_._dbContext.md 'Cat\.EventProcessor\.Inbox\.EFCore\.EfCoreInboxStore\<TDbContext\>\.\_dbContext') | |

| Methods | |
| :--- | :--- |
| [Add\(string, string\)](EfCoreInboxStore_TDbContext_.Add.MI05GBXIGV3DJ75YNMGHR2XT3.md 'Cat\.EventProcessor\.Inbox\.EFCore\.EfCoreInboxStore\<TDbContext\>\.Add\(string, string\)') | Adds the message to the inbox\. It does not save by itself\. The `SaveChanges` of the handler saves it with the work\. |
| [ExistsAsync\(string, CancellationToken\)](EfCoreInboxStore_TDbContext_.ExistsAsync.XXXMZLL6Y1B3X4XCRHVI9DVUA.md 'Cat\.EventProcessor\.Inbox\.EFCore\.EfCoreInboxStore\<TDbContext\>\.ExistsAsync\(string, System\.Threading\.CancellationToken\)') | Tells whether the message was handled before\. |
