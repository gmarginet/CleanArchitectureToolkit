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

## ServiceBusListener\.HandleAsync\(Type, ServiceBusReceivedMessage, Func\<ServiceBusReceivedMessage,CancellationToken,Task\>, Func\<ServiceBusReceivedMessage,IDictionary\<string,object\>,CancellationToken,Task\>, Func\<ServiceBusReceivedMessage,string,string,CancellationToken,Task\>, CancellationToken\) Method

```csharp
private System.Threading.Tasks.Task HandleAsync(System.Type messageType, Azure.Messaging.ServiceBus.ServiceBusReceivedMessage received, System.Func<Azure.Messaging.ServiceBus.ServiceBusReceivedMessage,System.Threading.CancellationToken,System.Threading.Tasks.Task> complete, System.Func<Azure.Messaging.ServiceBus.ServiceBusReceivedMessage,System.Collections.Generic.IDictionary<string,object>?,System.Threading.CancellationToken,System.Threading.Tasks.Task> abandon, System.Func<Azure.Messaging.ServiceBus.ServiceBusReceivedMessage,string,string,System.Threading.CancellationToken,System.Threading.Tasks.Task> deadLetter, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='Cat.EventProcessor.AzureServiceBus.ServiceBusListener.HandleAsync(System.Type,Azure.Messaging.ServiceBus.ServiceBusReceivedMessage,System.Func_Azure.Messaging.ServiceBus.ServiceBusReceivedMessage,System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Func_Azure.Messaging.ServiceBus.ServiceBusReceivedMessage,System.Collections.Generic.IDictionary_string,object_,System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Func_Azure.Messaging.ServiceBus.ServiceBusReceivedMessage,string,string,System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Threading.CancellationToken).messageType'></a>

`messageType` [System\.Type](https://learn.microsoft.com/en-us/dotnet/api/system.type 'System\.Type')

<a name='Cat.EventProcessor.AzureServiceBus.ServiceBusListener.HandleAsync(System.Type,Azure.Messaging.ServiceBus.ServiceBusReceivedMessage,System.Func_Azure.Messaging.ServiceBus.ServiceBusReceivedMessage,System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Func_Azure.Messaging.ServiceBus.ServiceBusReceivedMessage,System.Collections.Generic.IDictionary_string,object_,System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Func_Azure.Messaging.ServiceBus.ServiceBusReceivedMessage,string,string,System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Threading.CancellationToken).received'></a>

`received` [Azure\.Messaging\.ServiceBus\.ServiceBusReceivedMessage](https://learn.microsoft.com/en-us/dotnet/api/azure.messaging.servicebus.servicebusreceivedmessage 'Azure\.Messaging\.ServiceBus\.ServiceBusReceivedMessage')

<a name='Cat.EventProcessor.AzureServiceBus.ServiceBusListener.HandleAsync(System.Type,Azure.Messaging.ServiceBus.ServiceBusReceivedMessage,System.Func_Azure.Messaging.ServiceBus.ServiceBusReceivedMessage,System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Func_Azure.Messaging.ServiceBus.ServiceBusReceivedMessage,System.Collections.Generic.IDictionary_string,object_,System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Func_Azure.Messaging.ServiceBus.ServiceBusReceivedMessage,string,string,System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Threading.CancellationToken).complete'></a>

`complete` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')[Azure\.Messaging\.ServiceBus\.ServiceBusReceivedMessage](https://learn.microsoft.com/en-us/dotnet/api/azure.messaging.servicebus.servicebusreceivedmessage 'Azure\.Messaging\.ServiceBus\.ServiceBusReceivedMessage')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')[System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')[System\.Threading\.Tasks\.Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task 'System\.Threading\.Tasks\.Task')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')

<a name='Cat.EventProcessor.AzureServiceBus.ServiceBusListener.HandleAsync(System.Type,Azure.Messaging.ServiceBus.ServiceBusReceivedMessage,System.Func_Azure.Messaging.ServiceBus.ServiceBusReceivedMessage,System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Func_Azure.Messaging.ServiceBus.ServiceBusReceivedMessage,System.Collections.Generic.IDictionary_string,object_,System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Func_Azure.Messaging.ServiceBus.ServiceBusReceivedMessage,string,string,System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Threading.CancellationToken).abandon'></a>

`abandon` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-4 'System\.Func\`4')[Azure\.Messaging\.ServiceBus\.ServiceBusReceivedMessage](https://learn.microsoft.com/en-us/dotnet/api/azure.messaging.servicebus.servicebusreceivedmessage 'Azure\.Messaging\.ServiceBus\.ServiceBusReceivedMessage')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-4 'System\.Func\`4')[System\.Collections\.Generic\.IDictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.idictionary-2 'System\.Collections\.Generic\.IDictionary\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.idictionary-2 'System\.Collections\.Generic\.IDictionary\`2')[System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.idictionary-2 'System\.Collections\.Generic\.IDictionary\`2')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-4 'System\.Func\`4')[System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-4 'System\.Func\`4')[System\.Threading\.Tasks\.Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task 'System\.Threading\.Tasks\.Task')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-4 'System\.Func\`4')

<a name='Cat.EventProcessor.AzureServiceBus.ServiceBusListener.HandleAsync(System.Type,Azure.Messaging.ServiceBus.ServiceBusReceivedMessage,System.Func_Azure.Messaging.ServiceBus.ServiceBusReceivedMessage,System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Func_Azure.Messaging.ServiceBus.ServiceBusReceivedMessage,System.Collections.Generic.IDictionary_string,object_,System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Func_Azure.Messaging.ServiceBus.ServiceBusReceivedMessage,string,string,System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Threading.CancellationToken).deadLetter'></a>

`deadLetter` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-5 'System\.Func\`5')[Azure\.Messaging\.ServiceBus\.ServiceBusReceivedMessage](https://learn.microsoft.com/en-us/dotnet/api/azure.messaging.servicebus.servicebusreceivedmessage 'Azure\.Messaging\.ServiceBus\.ServiceBusReceivedMessage')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-5 'System\.Func\`5')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-5 'System\.Func\`5')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-5 'System\.Func\`5')[System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-5 'System\.Func\`5')[System\.Threading\.Tasks\.Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task 'System\.Threading\.Tasks\.Task')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-5 'System\.Func\`5')

<a name='Cat.EventProcessor.AzureServiceBus.ServiceBusListener.HandleAsync(System.Type,Azure.Messaging.ServiceBus.ServiceBusReceivedMessage,System.Func_Azure.Messaging.ServiceBus.ServiceBusReceivedMessage,System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Func_Azure.Messaging.ServiceBus.ServiceBusReceivedMessage,System.Collections.Generic.IDictionary_string,object_,System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Func_Azure.Messaging.ServiceBus.ServiceBusReceivedMessage,string,string,System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

#### Returns
[System\.Threading\.Tasks\.Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task 'System\.Threading\.Tasks\.Task')