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

## FakeMessageSender Class

A message sender for unit tests\. It records the events that were published and the commands that were sent,
in one list and in order\. It sends nothing\.

```csharp
public class FakeMessageSender : Cat.Messaging.Abstractions.ICatMessageSender
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → FakeMessageSender

Implements [ICatMessageSender](../../../Cat.Messaging/namespaces/Cat.Messaging.Abstractions/ICatMessageSender.md 'Cat\.Messaging\.Abstractions\.ICatMessageSender')

| Properties | |
| :--- | :--- |
| [Sent](FakeMessageSender.Sent.md 'Cat\.UnitTesting\.Messaging\.FakeMessageSender\.Sent') | Every message that was published or sent, in order\. |

| Methods | |
| :--- | :--- |
| [Of&lt;T&gt;\(\)](FakeMessageSender.Of_T_().md 'Cat\.UnitTesting\.Messaging\.FakeMessageSender\.Of\<T\>\(\)') | Gives the messages of one type, in order\. The type can be a message class, or [ICatEventMessage](../../../Cat.Messaging/namespaces/Cat.Messaging.Abstractions/ICatEventMessage.md 'Cat\.Messaging\.Abstractions\.ICatEventMessage') or [ICatCommandMessage](../../../Cat.Messaging/namespaces/Cat.Messaging.Abstractions/ICatCommandMessage.md 'Cat\.Messaging\.Abstractions\.ICatCommandMessage')\. |
| [PublishAsync\(ICatEventMessage, Nullable&lt;DateTimeOffset&gt;, CancellationToken\)](FakeMessageSender.PublishAsync.B569Z7QN0GV3R2YOO0X4YLJP9.md 'Cat\.UnitTesting\.Messaging\.FakeMessageSender\.PublishAsync\(Cat\.Messaging\.Abstractions\.ICatEventMessage, System\.Nullable\<System\.DateTimeOffset\>, System\.Threading\.CancellationToken\)') | Publishes an event to its topic\. |
| [Reset\(\)](FakeMessageSender.Reset().md 'Cat\.UnitTesting\.Messaging\.FakeMessageSender\.Reset\(\)') | Clears the recorded messages\. |
| [SendAsync\(ICatCommandMessage, Nullable&lt;DateTimeOffset&gt;, CancellationToken\)](FakeMessageSender.SendAsync.2ULEX7TKFDLVR0XUKBX2EPF4F.md 'Cat\.UnitTesting\.Messaging\.FakeMessageSender\.SendAsync\(Cat\.Messaging\.Abstractions\.ICatCommandMessage, System\.Nullable\<System\.DateTimeOffset\>, System\.Threading\.CancellationToken\)') | Sends a command message to its queue\. |
