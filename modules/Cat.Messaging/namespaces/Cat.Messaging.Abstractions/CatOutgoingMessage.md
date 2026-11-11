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
  
##### >> [Cat\.Messaging\.Abstractions Assembly](index.md 'index') >> [Cat\.Messaging\.Abstractions Namespace](Cat.Messaging.Abstractions.md 'Cat\.Messaging\.Abstractions')

## CatOutgoingMessage Class

A message that is ready to leave the service: serialized, with the name of its entity and its properties\.
It is what the transport sends and what the outbox stores\. It knows nothing about a specific broker\.

```csharp
public class CatOutgoingMessage
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatOutgoingMessage

| Properties | |
| :--- | :--- |
| [Body](CatOutgoingMessage.Body.md 'Cat\.Messaging\.Abstractions\.CatOutgoingMessage\.Body') | The serialized message\. |
| [ContentType](CatOutgoingMessage.ContentType.md 'Cat\.Messaging\.Abstractions\.CatOutgoingMessage\.ContentType') | The content type of [Body](CatOutgoingMessage.Body.md 'Cat\.Messaging\.Abstractions\.CatOutgoingMessage\.Body'), such as `application/json`\. A receiver uses it to pick the deserializer\. |
| [CorrelationId](CatOutgoingMessage.CorrelationId.md 'Cat\.Messaging\.Abstractions\.CatOutgoingMessage\.CorrelationId') | The ID of the business flow, from [CorrelationId](ICatMessage.CorrelationId.md 'Cat\.Messaging\.Abstractions\.ICatMessage\.CorrelationId')\. |
| [EntityName](CatOutgoingMessage.EntityName.md 'Cat\.Messaging\.Abstractions\.CatOutgoingMessage\.EntityName') | The name of the queue or the topic the message goes to\. |
| [Kind](CatOutgoingMessage.Kind.md 'Cat\.Messaging\.Abstractions\.CatOutgoingMessage\.Kind') | Whether [EntityName](CatOutgoingMessage.EntityName.md 'Cat\.Messaging\.Abstractions\.CatOutgoingMessage\.EntityName') is a queue \(command\) or a topic \(event\)\. |
| [MessageId](CatOutgoingMessage.MessageId.md 'Cat\.Messaging\.Abstractions\.CatOutgoingMessage\.MessageId') | The ID of the message, from [MessageId](ICatMessage.MessageId.md 'Cat\.Messaging\.Abstractions\.ICatMessage\.MessageId')\. |
| [Properties](CatOutgoingMessage.Properties.md 'Cat\.Messaging\.Abstractions\.CatOutgoingMessage\.Properties') | Extra properties of the message, such as the headers a receiver needs\. |
| [ScheduledAt](CatOutgoingMessage.ScheduledAt.md 'Cat\.Messaging\.Abstractions\.CatOutgoingMessage\.ScheduledAt') | The moment the bus must deliver the message\. Null means as soon as possible\. |
| [SessionId](CatOutgoingMessage.SessionId.md 'Cat\.Messaging\.Abstractions\.CatOutgoingMessage\.SessionId') | The session of the message, from [SessionId](ICatSessionMessage.SessionId.md 'Cat\.Messaging\.Abstractions\.ICatSessionMessage\.SessionId')\. Null when the message has no session\. |
| [Subject](CatOutgoingMessage.Subject.md 'Cat\.Messaging\.Abstractions\.CatOutgoingMessage\.Subject') | The subject of the message\. A receiver uses it to find the message type\. |
