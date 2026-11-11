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

## CatCommandMessage Class

Base class for a command message, such as `ReserveStock`\.
A new instance gets a new [MessageId](CatCommandMessage.MessageId.md 'Cat\.Messaging\.Abstractions\.CatCommandMessage\.MessageId'), a new [CorrelationId](CatCommandMessage.CorrelationId.md 'Cat\.Messaging\.Abstractions\.CatCommandMessage\.CorrelationId') and the current time\.
Set [CorrelationId](CatCommandMessage.CorrelationId.md 'Cat\.Messaging\.Abstractions\.CatCommandMessage\.CorrelationId') to the ID of the flow when the message belongs to a flow that already started\.

```csharp
public abstract class CatCommandMessage : Cat.Messaging.Abstractions.ICatCommandMessage, Cat.Messaging.Abstractions.ICatMessage
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatCommandMessage

Implements [ICatCommandMessage](ICatCommandMessage.md 'Cat\.Messaging\.Abstractions\.ICatCommandMessage'), [ICatMessage](ICatMessage.md 'Cat\.Messaging\.Abstractions\.ICatMessage')

| Properties | |
| :--- | :--- |
| [CorrelationId](CatCommandMessage.CorrelationId.md 'Cat\.Messaging\.Abstractions\.CatCommandMessage\.CorrelationId') | Follows a business flow across services\. Create it at the start of a flow and copy it to every message that follows from it\. |
| [MessageId](CatCommandMessage.MessageId.md 'Cat\.Messaging\.Abstractions\.CatCommandMessage\.MessageId') | Identifies this message\. It is copied to the message ID of the bus, which duplicate detection uses\. |
| [OccurredAt](CatCommandMessage.OccurredAt.md 'Cat\.Messaging\.Abstractions\.CatCommandMessage\.OccurredAt') | The moment the thing happened or the work was asked for\. |
