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

## CatMessageSenderBase Class

The shared work of [ICatMessageSender](../../../Cat.Messaging/namespaces/Cat.Messaging.Abstractions/ICatMessageSender.md 'Cat\.Messaging\.Abstractions\.ICatMessageSender') and [ICatSystemMessageSender](../../../Cat.Messaging/namespaces/Cat.Messaging.Abstractions/ICatSystemMessageSender.md 'Cat\.Messaging\.Abstractions\.ICatSystemMessageSender')\. They differ only in the subject of the token\.
Builds a [CatOutgoingMessage](../../../Cat.Messaging/namespaces/Cat.Messaging.Abstractions/CatOutgoingMessage.md 'Cat\.Messaging\.Abstractions\.CatOutgoingMessage') from the message and gives it to the [ICatOutgoingMessageSink](../../../Cat.Messaging/namespaces/Cat.Messaging.Abstractions/ICatOutgoingMessageSink.md 'Cat\.Messaging\.Abstractions\.ICatOutgoingMessageSink')\.

```csharp
internal abstract class CatMessageSenderBase
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatMessageSenderBase

Derived  
↳ [CatMessageSender](CatMessageSender.md 'Cat\.Messaging\.CatMessageSender')  
↳ [CatSystemMessageSender](CatSystemMessageSender.md 'Cat\.Messaging\.CatSystemMessageSender')

| Constructors | |
| :--- | :--- |
| [CatMessageSenderBase\(ICatMessageNameResolver, ICatMessageSerializer, ICatOutgoingMessageSink, ICatTokenProvider\)](CatMessageSenderBase..ctor.5YZYH0GB7I5SDJBBD8VQZIMP5.md 'Cat\.Messaging\.CatMessageSenderBase\.CatMessageSenderBase\(Cat\.Messaging\.Abstractions\.ICatMessageNameResolver, Cat\.Messaging\.ICatMessageSerializer, Cat\.Messaging\.Abstractions\.ICatOutgoingMessageSink, Cat\.Messaging\.Abstractions\.ICatTokenProvider\)') | Creates the sender\. |

| Fields | |
| :--- | :--- |
| [\_nameResolver](CatMessageSenderBase._nameResolver.md 'Cat\.Messaging\.CatMessageSenderBase\.\_nameResolver') | |
| [\_serializer](CatMessageSenderBase._serializer.md 'Cat\.Messaging\.CatMessageSenderBase\.\_serializer') | |
| [\_sink](CatMessageSenderBase._sink.md 'Cat\.Messaging\.CatMessageSenderBase\.\_sink') | |
| [\_tokenProvider](CatMessageSenderBase._tokenProvider.md 'Cat\.Messaging\.CatMessageSenderBase\.\_tokenProvider') | |

| Methods | |
| :--- | :--- |
| [AcceptAsync\(ICatMessage, CatMessageKind, Nullable&lt;DateTimeOffset&gt;, CancellationToken\)](CatMessageSenderBase.AcceptAsync.W3MTURH0RD1S3AYUPJKJHEX87.md 'Cat\.Messaging\.CatMessageSenderBase\.AcceptAsync\(Cat\.Messaging\.Abstractions\.ICatMessage, Cat\.Messaging\.Abstractions\.CatMessageKind, System\.Nullable\<System\.DateTimeOffset\>, System\.Threading\.CancellationToken\)') | |
| [ChooseSubject\(Nullable&lt;DateTimeOffset&gt;\)](CatMessageSenderBase.ChooseSubject.FHBXR3GMPDIOOTZN5FTL9A26E.md 'Cat\.Messaging\.CatMessageSenderBase\.ChooseSubject\(System\.Nullable\<System\.DateTimeOffset\>\)') | Picks the subject of the token for a message\. |
| [PublishAsync\(ICatEventMessage, Nullable&lt;DateTimeOffset&gt;, CancellationToken\)](CatMessageSenderBase.PublishAsync.QCNY5VPI4Y8N4MTO7DJFOBLL6.md 'Cat\.Messaging\.CatMessageSenderBase\.PublishAsync\(Cat\.Messaging\.Abstractions\.ICatEventMessage, System\.Nullable\<System\.DateTimeOffset\>, System\.Threading\.CancellationToken\)') | |
| [RequireNoTokenProvider\(\)](CatMessageSenderBase.RequireNoTokenProvider().md 'Cat\.Messaging\.CatMessageSenderBase\.RequireNoTokenProvider\(\)') | Called when no token provider is registered\. The default sends the message without a token\. |
| [SendAsync\(ICatCommandMessage, Nullable&lt;DateTimeOffset&gt;, CancellationToken\)](CatMessageSenderBase.SendAsync.N88L6B85A08JT8RMO3IPZUY17.md 'Cat\.Messaging\.CatMessageSenderBase\.SendAsync\(Cat\.Messaging\.Abstractions\.ICatCommandMessage, System\.Nullable\<System\.DateTimeOffset\>, System\.Threading\.CancellationToken\)') | |
