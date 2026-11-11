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
  
##### >> [Cat\.Messaging Assembly](index.md 'index') >> [Cat\.Messaging Namespace](Cat.Messaging.md 'Cat\.Messaging') >> [CatMessageSender Class](CatMessageSender.md 'Cat\.Messaging\.CatMessageSender')

## CatMessageSender\.SendAsync\(ICatCommandMessage, Nullable\<DateTimeOffset\>, CancellationToken\) Method

Sends a command message to its queue\.

```csharp
public System.Threading.Tasks.Task SendAsync(Cat.Messaging.Abstractions.ICatCommandMessage message, System.Nullable<System.DateTimeOffset> scheduledAt=null, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Cat.Messaging.CatMessageSender.SendAsync(Cat.Messaging.Abstractions.ICatCommandMessage,System.Nullable_System.DateTimeOffset_,System.Threading.CancellationToken).message'></a>

`message` [ICatCommandMessage](../../../Cat.Messaging/namespaces/Cat.Messaging.Abstractions/ICatCommandMessage.md 'Cat\.Messaging\.Abstractions\.ICatCommandMessage')

The command message to send\.

<a name='Cat.Messaging.CatMessageSender.SendAsync(Cat.Messaging.Abstractions.ICatCommandMessage,System.Nullable_System.DateTimeOffset_,System.Threading.CancellationToken).scheduledAt'></a>

`scheduledAt` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.DateTimeOffset](https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset 'System\.DateTimeOffset')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The moment the bus must deliver the message\. Null means as soon as possible\.

<a name='Cat.Messaging.CatMessageSender.SendAsync(Cat.Messaging.Abstractions.ICatCommandMessage,System.Nullable_System.DateTimeOffset_,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Token to cancel the work\.

Implements [SendAsync\(ICatCommandMessage, Nullable&lt;DateTimeOffset&gt;, CancellationToken\)](../../../Cat.Messaging/namespaces/Cat.Messaging.Abstractions/ICatMessageSender.SendAsync.OVZEFSEJM5EVI7JZG3U8EL09B.md 'Cat\.Messaging\.Abstractions\.ICatMessageSender\.SendAsync\(Cat\.Messaging\.Abstractions\.ICatCommandMessage,System\.Nullable\{System\.DateTimeOffset\},System\.Threading\.CancellationToken\)')

#### Returns
[System\.Threading\.Tasks\.Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task 'System\.Threading\.Tasks\.Task')  
A task that completes when the message is sent, or stored when the outbox is on\.