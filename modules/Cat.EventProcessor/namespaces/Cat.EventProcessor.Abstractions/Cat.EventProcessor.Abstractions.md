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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.EVENTPROCESSOR](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.EventProcessor\.Abstractions Assembly](index.md 'index')

## Cat\.EventProcessor\.Abstractions Namespace

The contracts of the event processor: the incoming message, the settlement of a message, the receiver, the contract of the inbox store and the settings per message type\.
A broker project, such as the one for Azure Service Bus, calls the receiver and settles the message with the result\.

| Classes | |
| :--- | :--- |
| [CatIncomingMessage](CatIncomingMessage.md 'Cat\.EventProcessor\.Abstractions\.CatIncomingMessage') | A message that arrived from the broker, before it is turned into a service request\. It knows nothing about a specific broker\. |
| [CatMessageContext](CatMessageContext.md 'Cat\.EventProcessor\.Abstractions\.CatMessageContext') | The message that is being handled right now\. Code in the handler pipeline, such as the inbox decorator, reads it\. It is empty when a service request does not come from a message, for example from an HTTP call\. |
| [CatMessageContext\.Scope](CatMessageContext.Scope.md 'Cat\.EventProcessor\.Abstractions\.CatMessageContext\.Scope') | |
| [CatMessageContextData](CatMessageContextData.md 'Cat\.EventProcessor\.Abstractions\.CatMessageContextData') | The data of the message that is being handled\. |
| [CatReceiveOptions](CatReceiveOptions.md 'Cat\.EventProcessor\.Abstractions\.CatReceiveOptions') | The settings of one declared message type\. Set them in code, and the configuration of the service can change them\. |
| [CatReceiveRegistration](CatReceiveRegistration.md 'Cat\.EventProcessor\.Abstractions\.CatReceiveRegistration') | A message type the service receives, with its settings\. |
| [CatSettlementResult](CatSettlementResult.md 'Cat\.EventProcessor\.Abstractions\.CatSettlementResult') | The outcome of handling one message: what to do with it, and why\. |

| Interfaces | |
| :--- | :--- |
| [ICatInboxStore](ICatInboxStore.md 'Cat\.EventProcessor\.Abstractions\.ICatInboxStore') | Remembers which messages the service handled\. The receiver calls it for a message type that has [UseInbox](CatReceiveOptions.UseInbox.md 'Cat\.EventProcessor\.Abstractions\.CatReceiveOptions\.UseInbox') on\. The store works on the context of the current scope, the same one the handler uses, so the row is saved by the `SaveChanges` of the handler\. |
| [ICatMessageReceiver](ICatMessageReceiver.md 'Cat\.EventProcessor\.Abstractions\.ICatMessageReceiver') | Turns one incoming message into a service request, runs it and tells the broker what to do with the message\. |
| [ICatReceiveRegistry](ICatReceiveRegistry.md 'Cat\.EventProcessor\.Abstractions\.ICatReceiveRegistry') | The message types the service receives, as declared in the `EventProcessor` project\. |

| Enums | |
| :--- | :--- |
| [CatSettlement](CatSettlement.md 'Cat\.EventProcessor\.Abstractions\.CatSettlement') | What the broker does with a message after the service handled it\. |
