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

## ICatMessageSender Interface

The entry point for sending messages\. Call it from a command handler, with the outbox on when a lost message is not acceptable\.

```csharp
public interface ICatMessageSender
```

| Methods | |
| :--- | :--- |
| [PublishAsync\(ICatEventMessage, Nullable&lt;DateTimeOffset&gt;, CancellationToken\)](ICatMessageSender.PublishAsync.4E8W5QCL2ENIUVTRBILDV6YA7.md 'Cat\.Messaging\.Abstractions\.ICatMessageSender\.PublishAsync\(Cat\.Messaging\.Abstractions\.ICatEventMessage, System\.Nullable\<System\.DateTimeOffset\>, System\.Threading\.CancellationToken\)') | Publishes an event to its topic\. |
| [SendAsync\(ICatCommandMessage, Nullable&lt;DateTimeOffset&gt;, CancellationToken\)](ICatMessageSender.SendAsync.OVZEFSEJM5EVI7JZG3U8EL09B.md 'Cat\.Messaging\.Abstractions\.ICatMessageSender\.SendAsync\(Cat\.Messaging\.Abstractions\.ICatCommandMessage, System\.Nullable\<System\.DateTimeOffset\>, System\.Threading\.CancellationToken\)') | Sends a command message to its queue\. |
