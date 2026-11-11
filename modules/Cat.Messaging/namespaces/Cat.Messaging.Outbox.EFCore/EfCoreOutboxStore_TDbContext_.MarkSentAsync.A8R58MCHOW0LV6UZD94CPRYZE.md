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
  
##### >> [Cat\.Messaging\.Outbox\.EFCore Assembly](index.md 'index') >> [Cat\.Messaging\.Outbox\.EFCore Namespace](Cat.Messaging.Outbox.EFCore.md 'Cat\.Messaging\.Outbox\.EFCore') >> [EfCoreOutboxStore&lt;TDbContext&gt; Class](EfCoreOutboxStore_TDbContext_.md 'Cat\.Messaging\.Outbox\.EFCore\.EfCoreOutboxStore\<TDbContext\>')

## EfCoreOutboxStore\<TDbContext\>\.MarkSentAsync\(Guid, CancellationToken\) Method

Marks a message as sent and saves that\.

```csharp
public System.Threading.Tasks.Task MarkSentAsync(System.Guid id, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Cat.Messaging.Outbox.EFCore.EfCoreOutboxStore_TDbContext_.MarkSentAsync(System.Guid,System.Threading.CancellationToken).id'></a>

`id` [System\.Guid](https://learn.microsoft.com/en-us/dotnet/api/system.guid 'System\.Guid')

The [Id](../../../Cat.Messaging/namespaces/Cat.Messaging.Outbox/CatOutboxItem.Id.md 'Cat\.Messaging\.Outbox\.CatOutboxItem\.Id') of the message\.

<a name='Cat.Messaging.Outbox.EFCore.EfCoreOutboxStore_TDbContext_.MarkSentAsync(System.Guid,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Token to cancel the work\.

Implements [MarkSentAsync\(Guid, CancellationToken\)](../../../Cat.Messaging/namespaces/Cat.Messaging.Outbox/ICatOutboxStore.MarkSentAsync.1A6P64PUZ7EVYJPQ7C4FAPIBC.md 'Cat\.Messaging\.Outbox\.ICatOutboxStore\.MarkSentAsync\(System\.Guid,System\.Threading\.CancellationToken\)')

#### Returns
[System\.Threading\.Tasks\.Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task 'System\.Threading\.Tasks\.Task')  
A task that completes when the change is saved\.