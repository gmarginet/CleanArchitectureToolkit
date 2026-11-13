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
  
##### >> [Cat\.UnitTesting\.Messaging Assembly](index.md 'index') >> [Cat\.UnitTesting\.Messaging Namespace](Cat.UnitTesting.Messaging.md 'Cat\.UnitTesting\.Messaging')

## SentMessage Class

One message that the [FakeMessageSender](FakeMessageSender.md 'Cat\.UnitTesting\.Messaging\.FakeMessageSender') got\.

```csharp
public sealed class SentMessage
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → SentMessage

| Constructors | |
| :--- | :--- |
| [SentMessage\(ICatMessage, Nullable&lt;DateTimeOffset&gt;\)](SentMessage..ctor.M2UF4L1OXMBJJ7SUQBQZDM5AE.md 'Cat\.UnitTesting\.Messaging\.SentMessage\.SentMessage\(Cat\.Messaging\.Abstractions\.ICatMessage, System\.Nullable\<System\.DateTimeOffset\>\)') | Creates a record of one message\. |

| Properties | |
| :--- | :--- |
| [Message](SentMessage.Message.md 'Cat\.UnitTesting\.Messaging\.SentMessage\.Message') | The event or command message\. |
| [ScheduledAt](SentMessage.ScheduledAt.md 'Cat\.UnitTesting\.Messaging\.SentMessage\.ScheduledAt') | The time the caller asked to send it at, or `null` for now\. |
