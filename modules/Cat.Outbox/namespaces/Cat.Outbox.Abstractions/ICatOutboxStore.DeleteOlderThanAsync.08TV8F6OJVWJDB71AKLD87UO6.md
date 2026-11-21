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
  
##### >> [Cat\.Outbox\.Abstractions Assembly](index.md 'index') >> [Cat\.Outbox\.Abstractions Namespace](Cat.Outbox.Abstractions.md 'Cat\.Outbox\.Abstractions') >> [ICatOutboxStore Interface](ICatOutboxStore.md 'Cat\.Outbox\.Abstractions\.ICatOutboxStore')

## ICatOutboxStore\.DeleteOlderThanAsync\(DateTimeOffset, CancellationToken\) Method

Deletes the rows that were sent before the given time\. A row that is not sent yet is never deleted\.
It runs at once and does not wait for a `SaveChanges`\.
Call it from your own job\. Keep a sent row for a while, so you can still look up a message that went missing\.

```csharp
System.Threading.Tasks.Task<int> DeleteOlderThanAsync(System.DateTimeOffset sentBefore, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Cat.Outbox.Abstractions.ICatOutboxStore.DeleteOlderThanAsync(System.DateTimeOffset,System.Threading.CancellationToken).sentBefore'></a>

`sentBefore` [System\.DateTimeOffset](https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset 'System\.DateTimeOffset')

The time limit\. A row sent before this time is deleted\.

<a name='Cat.Outbox.Abstractions.ICatOutboxStore.DeleteOlderThanAsync(System.DateTimeOffset,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Token to cancel the work\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The number of deleted rows\.