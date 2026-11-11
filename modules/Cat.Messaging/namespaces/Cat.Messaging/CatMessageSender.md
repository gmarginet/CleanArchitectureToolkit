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
  
##### >> [Cat\.Messaging Assembly](index.md 'index') >> [Cat\.Messaging Namespace](Cat.Messaging.md 'Cat\.Messaging')

## CatMessageSender Class

Default [ICatMessageSender](../../../Cat.Messaging/namespaces/Cat.Messaging.Abstractions/ICatMessageSender.md 'Cat\.Messaging\.Abstractions\.ICatMessageSender')\.
Builds a [CatOutgoingMessage](../../../Cat.Messaging/namespaces/Cat.Messaging.Abstractions/CatOutgoingMessage.md 'Cat\.Messaging\.Abstractions\.CatOutgoingMessage') from the message and gives it to the [ICatOutgoingMessageSink](../../../Cat.Messaging/namespaces/Cat.Messaging.Abstractions/ICatOutgoingMessageSink.md 'Cat\.Messaging\.Abstractions\.ICatOutgoingMessageSink')\.

```csharp
internal sealed class CatMessageSender : Cat.Messaging.Abstractions.ICatMessageSender
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatMessageSender

Implements [ICatMessageSender](../../../Cat.Messaging/namespaces/Cat.Messaging.Abstractions/ICatMessageSender.md 'Cat\.Messaging\.Abstractions\.ICatMessageSender')

| Constructors | |
| :--- | :--- |
| [CatMessageSender\(ICatMessageNameResolver, ICatMessageSerializer, ICatOutgoingMessageSink\)](CatMessageSender..ctor.SKRQ8ICX0K0A2A2YET133MIT5.md 'Cat\.Messaging\.CatMessageSender\.CatMessageSender\(Cat\.Messaging\.Abstractions\.ICatMessageNameResolver, Cat\.Messaging\.ICatMessageSerializer, Cat\.Messaging\.Abstractions\.ICatOutgoingMessageSink\)') | Creates the sender\. |

| Fields | |
| :--- | :--- |
| [\_nameResolver](CatMessageSender._nameResolver.md 'Cat\.Messaging\.CatMessageSender\.\_nameResolver') | |
| [\_serializer](CatMessageSender._serializer.md 'Cat\.Messaging\.CatMessageSender\.\_serializer') | |
| [\_sink](CatMessageSender._sink.md 'Cat\.Messaging\.CatMessageSender\.\_sink') | |

| Methods | |
| :--- | :--- |
| [AcceptAsync\(ICatMessage, CatMessageKind, Nullable&lt;DateTimeOffset&gt;, CancellationToken\)](CatMessageSender.AcceptAsync.5R1ASBXJOGKPLUT5AQ349EKQ.md 'Cat\.Messaging\.CatMessageSender\.AcceptAsync\(Cat\.Messaging\.Abstractions\.ICatMessage, Cat\.Messaging\.Abstractions\.CatMessageKind, System\.Nullable\<System\.DateTimeOffset\>, System\.Threading\.CancellationToken\)') | |
| [PublishAsync\(ICatEventMessage, Nullable&lt;DateTimeOffset&gt;, CancellationToken\)](CatMessageSender.PublishAsync.ZEXHIX2911PSUWEAKC0G8NP3D.md 'Cat\.Messaging\.CatMessageSender\.PublishAsync\(Cat\.Messaging\.Abstractions\.ICatEventMessage, System\.Nullable\<System\.DateTimeOffset\>, System\.Threading\.CancellationToken\)') | Publishes an event to its topic\. |
| [SendAsync\(ICatCommandMessage, Nullable&lt;DateTimeOffset&gt;, CancellationToken\)](CatMessageSender.SendAsync.WSQRBKEN9WV1HFOAL8OYEJYXE.md 'Cat\.Messaging\.CatMessageSender\.SendAsync\(Cat\.Messaging\.Abstractions\.ICatCommandMessage, System\.Nullable\<System\.DateTimeOffset\>, System\.Threading\.CancellationToken\)') | Sends a command message to its queue\. |
