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
  
##### >> [Cat\.EventProcessor Assembly](index.md 'index') >> [Cat\.EventProcessor Namespace](Cat.EventProcessor.md 'Cat\.EventProcessor') >> [CatSenderCultureScope Class](CatSenderCultureScope.md 'Cat\.EventProcessor\.CatSenderCultureScope')

## CatSenderCultureScope\.Begin\(bool, CatIncomingMessage\) Method

Starts the scope\. It does nothing when the service did not turn the option on, or when the message has no usable culture\.

```csharp
public static System.IDisposable Begin(bool enabled, Cat.EventProcessor.Abstractions.CatIncomingMessage message);
```
#### Parameters

<a name='Cat.EventProcessor.CatSenderCultureScope.Begin(bool,Cat.EventProcessor.Abstractions.CatIncomingMessage).enabled'></a>

`enabled` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

True when the service applies the culture of the sender\.

<a name='Cat.EventProcessor.CatSenderCultureScope.Begin(bool,Cat.EventProcessor.Abstractions.CatIncomingMessage).message'></a>

`message` [CatIncomingMessage](../../../Cat.EventProcessor/namespaces/Cat.EventProcessor.Abstractions/CatIncomingMessage.md 'Cat\.EventProcessor\.Abstractions\.CatIncomingMessage')

The incoming message\.

#### Returns
[System\.IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable 'System\.IDisposable')  
A scope to dispose when the handling ends\.