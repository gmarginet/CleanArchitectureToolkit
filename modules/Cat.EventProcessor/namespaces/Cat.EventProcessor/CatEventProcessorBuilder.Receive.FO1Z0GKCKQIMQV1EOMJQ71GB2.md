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
  
##### >> [Cat\.EventProcessor Assembly](index.md 'index') >> [Cat\.EventProcessor Namespace](Cat.EventProcessor.md 'Cat\.EventProcessor') >> [CatEventProcessorBuilder Class](CatEventProcessorBuilder.md 'Cat\.EventProcessor\.CatEventProcessorBuilder')

## CatEventProcessorBuilder\.Receive\<TMessage\>\(Action\<CatReceiveOptions\>\) Method

Declares a message type the service receives\. Every message of the type becomes this service request\.

```csharp
public Cat.EventProcessor.CatEventProcessorBuilder Receive<TMessage>(System.Action<Cat.EventProcessor.Abstractions.CatReceiveOptions>? configure=null)
    where TMessage : class, Cat.Messaging.Abstractions.ICatMessage, Cat.ServiceRequests.Abstractions.ICatServiceRequest;
```
#### Type parameters

<a name='Cat.EventProcessor.CatEventProcessorBuilder.Receive_TMessage_(System.Action_Cat.EventProcessor.Abstractions.CatReceiveOptions_).TMessage'></a>

`TMessage`

The message type\. It is a message and a service request at the same time\.
#### Parameters

<a name='Cat.EventProcessor.CatEventProcessorBuilder.Receive_TMessage_(System.Action_Cat.EventProcessor.Abstractions.CatReceiveOptions_).configure'></a>

`configure` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[CatReceiveOptions](../../../Cat.EventProcessor/namespaces/Cat.EventProcessor.Abstractions/CatReceiveOptions.md 'Cat\.EventProcessor\.Abstractions\.CatReceiveOptions')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

Changes the settings of the message type\.

#### Returns
[CatEventProcessorBuilder](CatEventProcessorBuilder.md 'Cat\.EventProcessor\.CatEventProcessorBuilder')  
The same builder, so calls can be chained\.

#### Exceptions

[System\.InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception 'System\.InvalidOperationException')  
The message type is declared twice\.