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
  
##### >> [Cat\.Messaging\.Abstractions Assembly](index.md 'index')

## Cat\.Messaging\.Abstractions Namespace

The contracts of the messaging module: the message base types, the sender, the name convention and the transport seam\.
A `Contracts` project references only this project to declare its messages\.

| Classes | |
| :--- | :--- |
| [CatCommandMessage](CatCommandMessage.md 'Cat\.Messaging\.Abstractions\.CatCommandMessage') | Base class for a command message, such as `ReserveStock`\. A new instance gets a new [MessageId](CatCommandMessage.MessageId.md 'Cat\.Messaging\.Abstractions\.CatCommandMessage\.MessageId'), a new [CorrelationId](CatCommandMessage.CorrelationId.md 'Cat\.Messaging\.Abstractions\.CatCommandMessage\.CorrelationId') and the current time\. Set [CorrelationId](CatCommandMessage.CorrelationId.md 'Cat\.Messaging\.Abstractions\.CatCommandMessage\.CorrelationId') to the ID of the flow when the message belongs to a flow that already started\. |
| [CatEventMessage](CatEventMessage.md 'Cat\.Messaging\.Abstractions\.CatEventMessage') | Base class for an event, such as `OrderPlaced`\. A new instance gets a new [MessageId](CatEventMessage.MessageId.md 'Cat\.Messaging\.Abstractions\.CatEventMessage\.MessageId'), a new [CorrelationId](CatEventMessage.CorrelationId.md 'Cat\.Messaging\.Abstractions\.CatEventMessage\.CorrelationId') and the current time\. Set [CorrelationId](CatEventMessage.CorrelationId.md 'Cat\.Messaging\.Abstractions\.CatEventMessage\.CorrelationId') to the ID of the flow when the event belongs to a flow that already started\. |
| [CatMessageAttribute](CatMessageAttribute.md 'Cat\.Messaging\.Abstractions\.CatMessageAttribute') | Overrides the conventions of a message type\. Without it the queue, topic and subject use the name of the message type, and sessions are off\. |
| [CatMessageProperties](CatMessageProperties.md 'Cat\.Messaging\.Abstractions\.CatMessageProperties') | The names of the properties that the toolkit puts on a message\. |
| [CatOutgoingMessage](CatOutgoingMessage.md 'Cat\.Messaging\.Abstractions\.CatOutgoingMessage') | A message that is ready to leave the service: serialized, with the name of its entity and its properties\. It is what the transport sends and what the outbox stores\. It knows nothing about a specific broker\. |

| Interfaces | |
| :--- | :--- |
| [ICatCommandMessage](ICatCommandMessage.md 'Cat\.Messaging\.Abstractions\.ICatCommandMessage') | Marks a message as a command message: do this\. One receiver must do it, and it must not get lost when the receiver is down\. It goes to a queue\. |
| [ICatEventMessage](ICatEventMessage.md 'Cat\.Messaging\.Abstractions\.ICatEventMessage') | Marks a message as an event: something happened\. Many services may listen, and the sender does not care if nobody does\. It goes to a topic\. |
| [ICatMessage](ICatMessage.md 'Cat\.Messaging\.Abstractions\.ICatMessage') | A message that travels over the bus\. Inherit [CatEventMessage](CatEventMessage.md 'Cat\.Messaging\.Abstractions\.CatEventMessage') or [CatCommandMessage](CatCommandMessage.md 'Cat\.Messaging\.Abstractions\.CatCommandMessage') when you can\. Implement [ICatEventMessage](ICatEventMessage.md 'Cat\.Messaging\.Abstractions\.ICatEventMessage') or [ICatCommandMessage](ICatCommandMessage.md 'Cat\.Messaging\.Abstractions\.ICatCommandMessage') when the type cannot inherit\. |
| [ICatMessageNameResolver](ICatMessageNameResolver.md 'Cat\.Messaging\.Abstractions\.ICatMessageNameResolver') | Finds the names a message type uses on the bus, by convention or from [CatMessageAttribute](CatMessageAttribute.md 'Cat\.Messaging\.Abstractions\.CatMessageAttribute')\. |
| [ICatMessageSender](ICatMessageSender.md 'Cat\.Messaging\.Abstractions\.ICatMessageSender') | The entry point for sending messages\. Call it from a command handler, with the outbox on when a lost message is not acceptable\. |
| [ICatMessageTransport](ICatMessageTransport.md 'Cat\.Messaging\.Abstractions\.ICatMessageTransport') | Sends a message to a broker\. Every broker gets its own project that implements it, such as `Cat.Messaging.AzureServiceBus`\. |
| [ICatOutgoingMessageSink](ICatOutgoingMessageSink.md 'Cat\.Messaging\.Abstractions\.ICatOutgoingMessageSink') | Takes the message from the sender\. By default it hands the message straight to the [ICatMessageTransport](ICatMessageTransport.md 'Cat\.Messaging\.Abstractions\.ICatMessageTransport')\. The outbox replaces it with one that stores the message, so the sender does not change\. |
| [ICatSessionMessage](ICatSessionMessage.md 'Cat\.Messaging\.Abstractions\.ICatSessionMessage') | A message that belongs to a session\. Messages with the same session ID are handled in order, one receiver at a time\. Implement it on a message that goes to an entity that needs sessions, see [RequiresSession](CatMessageAttribute.RequiresSession.md 'Cat\.Messaging\.Abstractions\.CatMessageAttribute\.RequiresSession')\. |
| [ICatTokenProvider](ICatTokenProvider.md 'Cat\.Messaging\.Abstractions\.ICatTokenProvider') | Gives the token that travels with a message, so the receiver knows who sent the work\. The host implements it, for example by reading the `Authorization` header of the current request\. A host that registers none sends messages without a token\. |

| Enums | |
| :--- | :--- |
| [CatMessageKind](CatMessageKind.md 'Cat\.Messaging\.Abstractions\.CatMessageKind') | The kind of a message, which decides between a queue and a topic\. |
| [CatTokenSubject](CatTokenSubject.md 'Cat\.Messaging\.Abstractions\.CatTokenSubject') | Whose token a message carries\. |
