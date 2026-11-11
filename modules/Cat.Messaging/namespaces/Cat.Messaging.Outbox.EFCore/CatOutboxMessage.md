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
  
##### >> [Cat\.Messaging\.Outbox\.EFCore Assembly](index.md 'index') >> [Cat\.Messaging\.Outbox\.EFCore Namespace](Cat.Messaging.Outbox.EFCore.md 'Cat\.Messaging\.Outbox\.EFCore')

## CatOutboxMessage Class

One row of the outbox table\.

```csharp
public class CatOutboxMessage
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatOutboxMessage

| Properties | |
| :--- | :--- |
| [Body](CatOutboxMessage.Body.md 'Cat\.Messaging\.Outbox\.EFCore\.CatOutboxMessage\.Body') | The serialized message\. |
| [ContentType](CatOutboxMessage.ContentType.md 'Cat\.Messaging\.Outbox\.EFCore\.CatOutboxMessage\.ContentType') | The content type of the body\. |
| [CorrelationId](CatOutboxMessage.CorrelationId.md 'Cat\.Messaging\.Outbox\.EFCore\.CatOutboxMessage\.CorrelationId') | The ID of the business flow\. |
| [CreatedAt](CatOutboxMessage.CreatedAt.md 'Cat\.Messaging\.Outbox\.EFCore\.CatOutboxMessage\.CreatedAt') | When the row was added\. |
| [EntityName](CatOutboxMessage.EntityName.md 'Cat\.Messaging\.Outbox\.EFCore\.CatOutboxMessage\.EntityName') | The queue or topic name\. |
| [Id](CatOutboxMessage.Id.md 'Cat\.Messaging\.Outbox\.EFCore\.CatOutboxMessage\.Id') | The ID of the row\. |
| [Kind](CatOutboxMessage.Kind.md 'Cat\.Messaging\.Outbox\.EFCore\.CatOutboxMessage\.Kind') | Whether the message is a command message \(queue\) or an event \(topic\)\. |
| [MessageId](CatOutboxMessage.MessageId.md 'Cat\.Messaging\.Outbox\.EFCore\.CatOutboxMessage\.MessageId') | The ID of the message\. |
| [PropertiesJson](CatOutboxMessage.PropertiesJson.md 'Cat\.Messaging\.Outbox\.EFCore\.CatOutboxMessage\.PropertiesJson') | The extra properties of the message, as JSON\. Null when there are none\. |
| [ScheduledAt](CatOutboxMessage.ScheduledAt.md 'Cat\.Messaging\.Outbox\.EFCore\.CatOutboxMessage\.ScheduledAt') | The moment the bus must deliver the message, if it is scheduled\. |
| [SentAt](CatOutboxMessage.SentAt.md 'Cat\.Messaging\.Outbox\.EFCore\.CatOutboxMessage\.SentAt') | When the message was sent to the transport\. Null while it is pending\. |
| [SessionId](CatOutboxMessage.SessionId.md 'Cat\.Messaging\.Outbox\.EFCore\.CatOutboxMessage\.SessionId') | The session of the message, if it has one\. |
| [Subject](CatOutboxMessage.Subject.md 'Cat\.Messaging\.Outbox\.EFCore\.CatOutboxMessage\.Subject') | The subject of the message\. |
