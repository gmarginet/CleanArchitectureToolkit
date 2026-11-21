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

## ICatSystemMessageSender Interface

Sends messages that carry the token of the system, and never the token of a user\. Use it for work that has no user,
such as a webhook of a payment provider that hands its work off as a message\.

```csharp
public interface ICatSystemMessageSender
```

### Remarks
Running as the system is never a default\. Only the code that injects this interface can do it, so a handler that runs for a user
cannot do it by accident, and a search for the type finds every place that does\. The receiver still checks the policy of the
message type against the system token\. [ICatMessageSender](ICatMessageSender.md 'Cat\.Messaging\.Abstractions\.ICatMessageSender') stays as it is\.

| Methods | |
| :--- | :--- |
| [PublishAsync\(ICatEventMessage, Nullable&lt;DateTimeOffset&gt;, CancellationToken\)](ICatSystemMessageSender.PublishAsync.9WIODA0X15ADH92FRBWRFE7W7.md 'Cat\.Messaging\.Abstractions\.ICatSystemMessageSender\.PublishAsync\(Cat\.Messaging\.Abstractions\.ICatEventMessage, System\.Nullable\<System\.DateTimeOffset\>, System\.Threading\.CancellationToken\)') | Publishes an event to its topic, with the token of the system\. |
| [SendAsync\(ICatCommandMessage, Nullable&lt;DateTimeOffset&gt;, CancellationToken\)](ICatSystemMessageSender.SendAsync.9G0NIHIR9HV3IFGD3MQNJRI47.md 'Cat\.Messaging\.Abstractions\.ICatSystemMessageSender\.SendAsync\(Cat\.Messaging\.Abstractions\.ICatCommandMessage, System\.Nullable\<System\.DateTimeOffset\>, System\.Threading\.CancellationToken\)') | Sends a command message to its queue, with the token of the system\. |
