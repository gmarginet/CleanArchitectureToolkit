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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.UNITTESTING](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.UnitTesting\.Messaging Assembly](index.md 'index') >> [Cat\.UnitTesting\.Messaging Namespace](Cat.UnitTesting.Messaging.md 'Cat\.UnitTesting\.Messaging') >> [SentMessage Class](SentMessage.md 'Cat\.UnitTesting\.Messaging\.SentMessage')

## SentMessage\(ICatMessage, Nullable\<DateTimeOffset\>\) Constructor

Creates a record of one message\.

```csharp
public SentMessage(Cat.Messaging.Abstractions.ICatMessage message, System.Nullable<System.DateTimeOffset> scheduledAt);
```
#### Parameters

<a name='Cat.UnitTesting.Messaging.SentMessage.SentMessage(Cat.Messaging.Abstractions.ICatMessage,System.Nullable_System.DateTimeOffset_).message'></a>

`message` [ICatMessage](../../../Cat.Messaging/namespaces/Cat.Messaging.Abstractions/ICatMessage.md 'Cat\.Messaging\.Abstractions\.ICatMessage')

The event or command message\.

<a name='Cat.UnitTesting.Messaging.SentMessage.SentMessage(Cat.Messaging.Abstractions.ICatMessage,System.Nullable_System.DateTimeOffset_).scheduledAt'></a>

`scheduledAt` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.DateTimeOffset](https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset 'System\.DateTimeOffset')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The time the caller asked to send it at, or `null` for now\.