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
  
##### >> [Cat\.Inbox\.EFCore Assembly](index.md 'index') >> [Cat\.Inbox\.EFCore Namespace](Cat.Inbox.EFCore.md 'Cat\.Inbox\.EFCore') >> [EfCoreInboxStore&lt;TDbContext&gt; Class](EfCoreInboxStore_TDbContext_.md 'Cat\.Inbox\.EFCore\.EfCoreInboxStore\<TDbContext\>')

## EfCoreInboxStore\<TDbContext\>\.DeleteOlderThanAsync\(DateTimeOffset, CancellationToken\) Method

Deletes the rows that were handled before the given time\. It runs at once and does not wait for a `SaveChanges`\.
Call it from your own job\. Keep a row at least as long as the bus can still deliver the same message again\.

```csharp
public System.Threading.Tasks.Task<int> DeleteOlderThanAsync(System.DateTimeOffset handledBefore, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Cat.Inbox.EFCore.EfCoreInboxStore_TDbContext_.DeleteOlderThanAsync(System.DateTimeOffset,System.Threading.CancellationToken).handledBefore'></a>

`handledBefore` [System\.DateTimeOffset](https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset 'System\.DateTimeOffset')

The time limit\. A row handled before this time is deleted\.

<a name='Cat.Inbox.EFCore.EfCoreInboxStore_TDbContext_.DeleteOlderThanAsync(System.DateTimeOffset,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Token to cancel the work\.

Implements [DeleteOlderThanAsync\(DateTimeOffset, CancellationToken\)](../../../Cat.Inbox/namespaces/Cat.Inbox.Abstractions/ICatInboxStore.DeleteOlderThanAsync.ZSNZ2XNKS2TRPMDQ6MEZAWH6.md 'Cat\.Inbox\.Abstractions\.ICatInboxStore\.DeleteOlderThanAsync\(System\.DateTimeOffset,System\.Threading\.CancellationToken\)')

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The number of deleted rows\.