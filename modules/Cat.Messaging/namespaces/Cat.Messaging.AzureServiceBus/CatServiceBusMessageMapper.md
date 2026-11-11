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
  
##### >> [Cat\.Messaging\.AzureServiceBus Assembly](index.md 'index') >> [Cat\.Messaging\.AzureServiceBus Namespace](Cat.Messaging.AzureServiceBus.md 'Cat\.Messaging\.AzureServiceBus')

## CatServiceBusMessageMapper Class

Turns a [CatOutgoingMessage](../../../Cat.Messaging/namespaces/Cat.Messaging.Abstractions/CatOutgoingMessage.md 'Cat\.Messaging\.Abstractions\.CatOutgoingMessage') into a Service Bus message\.

```csharp
public static class CatServiceBusMessageMapper
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatServiceBusMessageMapper

| Methods | |
| :--- | :--- |
| [ToServiceBusMessage\(CatOutgoingMessage\)](CatServiceBusMessageMapper.ToServiceBusMessage.5DJYGY3H8CD28EEDNG6EQGNU6.md 'Cat\.Messaging\.AzureServiceBus\.CatServiceBusMessageMapper\.ToServiceBusMessage\(Cat\.Messaging\.Abstractions\.CatOutgoingMessage\)') | Maps the message\. The message ID is copied, so duplicate detection of the bus can use it\. The trace context is not added here, the Service Bus SDK puts its `Diagnostic-Id` on the message when it sends\. |
