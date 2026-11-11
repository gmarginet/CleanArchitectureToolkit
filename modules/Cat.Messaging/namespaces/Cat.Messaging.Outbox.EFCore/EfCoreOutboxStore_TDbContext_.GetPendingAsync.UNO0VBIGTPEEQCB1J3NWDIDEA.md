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

## EfCoreOutboxStore\<TDbContext\>\.GetPendingAsync\(int, CancellationToken\) Method

Gets the messages that are not sent yet, oldest first\.

```csharp
public System.Threading.Tasks.Task<System.Collections.Generic.IReadOnlyList<Cat.Messaging.Outbox.CatOutboxItem>> GetPendingAsync(int maxCount, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Cat.Messaging.Outbox.EFCore.EfCoreOutboxStore_TDbContext_.GetPendingAsync(int,System.Threading.CancellationToken).maxCount'></a>

`maxCount` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The maximum number of messages to get\.

<a name='Cat.Messaging.Outbox.EFCore.EfCoreOutboxStore_TDbContext_.GetPendingAsync(int,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Token to cancel the work\.

Implements [GetPendingAsync\(int, CancellationToken\)](../../../Cat.Messaging/namespaces/Cat.Messaging.Outbox/ICatOutboxStore.GetPendingAsync.6DHIU6ZXYUHR1N6AEHJY1EVQ3.md 'Cat\.Messaging\.Outbox\.ICatOutboxStore\.GetPendingAsync\(System\.Int32,System\.Threading\.CancellationToken\)')

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Collections\.Generic\.IReadOnlyList&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1 'System\.Collections\.Generic\.IReadOnlyList\`1')[CatOutboxItem](../../../Cat.Messaging/namespaces/Cat.Messaging.Outbox/CatOutboxItem.md 'Cat\.Messaging\.Outbox\.CatOutboxItem')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1 'System\.Collections\.Generic\.IReadOnlyList\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The pending messages\.