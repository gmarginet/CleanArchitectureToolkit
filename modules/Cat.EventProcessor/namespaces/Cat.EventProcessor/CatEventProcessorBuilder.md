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
  
##### >> [Cat\.EventProcessor Assembly](index.md 'index') >> [Cat\.EventProcessor Namespace](Cat.EventProcessor.md 'Cat\.EventProcessor')

## CatEventProcessorBuilder Class

Declares the message types a service receives\. Use it where the API project registers the event processor, like you define the endpoints of an API\.

```csharp
public sealed class CatEventProcessorBuilder
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatEventProcessorBuilder

| Fields | |
| :--- | :--- |
| [\_registrations](CatEventProcessorBuilder._registrations.md 'Cat\.EventProcessor\.CatEventProcessorBuilder\.\_registrations') | |

| Properties | |
| :--- | :--- |
| [Registrations](CatEventProcessorBuilder.Registrations.md 'Cat\.EventProcessor\.CatEventProcessorBuilder\.Registrations') | |

| Methods | |
| :--- | :--- |
| [Receive&lt;TMessage&gt;\(Action&lt;CatReceiveOptions&gt;\)](CatEventProcessorBuilder.Receive.FO1Z0GKCKQIMQV1EOMJQ71GB2.md 'Cat\.EventProcessor\.CatEventProcessorBuilder\.Receive\<TMessage\>\(System\.Action\<Cat\.EventProcessor\.Abstractions\.CatReceiveOptions\>\)') | Declares a message type the service receives\. Every message of the type becomes this service request\. |
