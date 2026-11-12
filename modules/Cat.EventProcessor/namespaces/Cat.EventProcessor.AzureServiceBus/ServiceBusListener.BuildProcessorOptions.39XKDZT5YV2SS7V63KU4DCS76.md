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
  
##### >> [Cat\.EventProcessor\.AzureServiceBus Assembly](index.md 'index') >> [Cat\.EventProcessor\.AzureServiceBus Namespace](Cat.EventProcessor.AzureServiceBus.md 'Cat\.EventProcessor\.AzureServiceBus') >> [ServiceBusListener Class](ServiceBusListener.md 'Cat\.EventProcessor\.AzureServiceBus\.ServiceBusListener')

## ServiceBusListener\.BuildProcessorOptions\(Type, Nullable\<int\>, Action\<Type,ServiceBusProcessorOptions\>\) Method

Builds the options of a processor\. The concurrency of the message type is set first, then the callback runs,
and `AutoCompleteMessages` is set to false after it, because the listener settles every message itself\.

```csharp
internal static Azure.Messaging.ServiceBus.ServiceBusProcessorOptions BuildProcessorOptions(System.Type messageType, System.Nullable<int> maxConcurrentCalls, System.Action<System.Type,Azure.Messaging.ServiceBus.ServiceBusProcessorOptions>? configure);
```
#### Parameters

<a name='Cat.EventProcessor.AzureServiceBus.ServiceBusListener.BuildProcessorOptions(System.Type,System.Nullable_int_,System.Action_System.Type,Azure.Messaging.ServiceBus.ServiceBusProcessorOptions_).messageType'></a>

`messageType` [System\.Type](https://learn.microsoft.com/en-us/dotnet/api/system.type 'System\.Type')

<a name='Cat.EventProcessor.AzureServiceBus.ServiceBusListener.BuildProcessorOptions(System.Type,System.Nullable_int_,System.Action_System.Type,Azure.Messaging.ServiceBus.ServiceBusProcessorOptions_).maxConcurrentCalls'></a>

`maxConcurrentCalls` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='Cat.EventProcessor.AzureServiceBus.ServiceBusListener.BuildProcessorOptions(System.Type,System.Nullable_int_,System.Action_System.Type,Azure.Messaging.ServiceBus.ServiceBusProcessorOptions_).configure'></a>

`configure` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-2 'System\.Action\`2')[System\.Type](https://learn.microsoft.com/en-us/dotnet/api/system.type 'System\.Type')[,](https://learn.microsoft.com/en-us/dotnet/api/system.action-2 'System\.Action\`2')[Azure\.Messaging\.ServiceBus\.ServiceBusProcessorOptions](https://learn.microsoft.com/en-us/dotnet/api/azure.messaging.servicebus.servicebusprocessoroptions 'Azure\.Messaging\.ServiceBus\.ServiceBusProcessorOptions')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-2 'System\.Action\`2')

#### Returns
[Azure\.Messaging\.ServiceBus\.ServiceBusProcessorOptions](https://learn.microsoft.com/en-us/dotnet/api/azure.messaging.servicebus.servicebusprocessoroptions 'Azure\.Messaging\.ServiceBus\.ServiceBusProcessorOptions')