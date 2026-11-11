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
  
##### >> [Cat\.EventProcessor\.Abstractions Assembly](index.md 'index') >> [Cat\.EventProcessor\.Abstractions Namespace](Cat.EventProcessor.Abstractions.md 'Cat\.EventProcessor\.Abstractions')

## CatIncomingMessage Class

A message that arrived from the broker, before it is turned into a service request\. It knows nothing about a specific broker\.

```csharp
public class CatIncomingMessage
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatIncomingMessage

| Properties | |
| :--- | :--- |
| [Body](CatIncomingMessage.Body.md 'Cat\.EventProcessor\.Abstractions\.CatIncomingMessage\.Body') | The serialized message\. |
| [ContentType](CatIncomingMessage.ContentType.md 'Cat\.EventProcessor\.Abstractions\.CatIncomingMessage\.ContentType') | The content type of the body, such as `application/json`\. Empty is read as JSON\. |
| [DeliveryCount](CatIncomingMessage.DeliveryCount.md 'Cat\.EventProcessor\.Abstractions\.CatIncomingMessage\.DeliveryCount') | How many times the bus delivered the message, this one included\. |
| [MessageId](CatIncomingMessage.MessageId.md 'Cat\.EventProcessor\.Abstractions\.CatIncomingMessage\.MessageId') | The ID of the message, as the sender set it\. |
| [Properties](CatIncomingMessage.Properties.md 'Cat\.EventProcessor\.Abstractions\.CatIncomingMessage\.Properties') | The extra properties of the message\. |
