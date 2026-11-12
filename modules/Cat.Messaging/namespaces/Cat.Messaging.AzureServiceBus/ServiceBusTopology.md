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

## ServiceBusTopology Class

Default [ICatServiceBusTopology](ICatServiceBusTopology.md 'Cat\.Messaging\.AzureServiceBus\.ICatServiceBusTopology'), on the administration client\.

```csharp
internal sealed class ServiceBusTopology : Cat.Messaging.AzureServiceBus.ICatServiceBusTopology
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → ServiceBusTopology

Implements [ICatServiceBusTopology](ICatServiceBusTopology.md 'Cat\.Messaging\.AzureServiceBus\.ICatServiceBusTopology')

| Constructors | |
| :--- | :--- |
| [ServiceBusTopology\(ServiceBusAdministrationClient, ICatMessageNameResolver, IOptions&lt;CatServiceBusOptions&gt;\)](ServiceBusTopology..ctor.QO1AHZ47NREOMM5XI7X28MYPA.md 'Cat\.Messaging\.AzureServiceBus\.ServiceBusTopology\.ServiceBusTopology\(Azure\.Messaging\.ServiceBus\.Administration\.ServiceBusAdministrationClient, Cat\.Messaging\.Abstractions\.ICatMessageNameResolver, Microsoft\.Extensions\.Options\.IOptions\<Cat\.Messaging\.AzureServiceBus\.CatServiceBusOptions\>\)') | Creates the topology helper\. |

| Fields | |
| :--- | :--- |
| [\_admin](ServiceBusTopology._admin.md 'Cat\.Messaging\.AzureServiceBus\.ServiceBusTopology\.\_admin') | |
| [\_nameResolver](ServiceBusTopology._nameResolver.md 'Cat\.Messaging\.AzureServiceBus\.ServiceBusTopology\.\_nameResolver') | |
| [\_options](ServiceBusTopology._options.md 'Cat\.Messaging\.AzureServiceBus\.ServiceBusTopology\.\_options') | |

| Methods | |
| :--- | :--- |
| [BuildQueueOptions\(string, bool, Action&lt;CreateQueueOptions&gt;\)](ServiceBusTopology.BuildQueueOptions.EJW3CSOOZ5IN7QVNQQTPD1D0D.md 'Cat\.Messaging\.AzureServiceBus\.ServiceBusTopology\.BuildQueueOptions\(string, bool, System\.Action\<Azure\.Messaging\.ServiceBus\.Administration\.CreateQueueOptions\>\)') | Builds the options of a queue\. Duplicate detection is on, so the bus drops a repeated message with the same message ID\. The time window keeps the default of Azure Service Bus\. The callback runs next, and the session setting is applied after it, because the message type decides it\. |
| [BuildTopicOptions\(string, Action&lt;CreateTopicOptions&gt;\)](ServiceBusTopology.BuildTopicOptions.BHTSLCFDK48EHAP8ARPKCF7LD.md 'Cat\.Messaging\.AzureServiceBus\.ServiceBusTopology\.BuildTopicOptions\(string, System\.Action\<Azure\.Messaging\.ServiceBus\.Administration\.CreateTopicOptions\>\)') | Builds the options of a topic\. Duplicate detection is on, so the bus drops a repeated message with the same message ID\. The time window keeps the default of Azure Service Bus\. The callback runs last\. |
| [EnsureTopologyAsync\(IEnumerable&lt;Assembly&gt;, CancellationToken\)](ServiceBusTopology.EnsureTopologyAsync.1UCAPUUBWV8EVRODQDHE2W213.md 'Cat\.Messaging\.AzureServiceBus\.ServiceBusTopology\.EnsureTopologyAsync\(System\.Collections\.Generic\.IEnumerable\<System\.Reflection\.Assembly\>, System\.Threading\.CancellationToken\)') | Creates a queue for every command message and a topic for every event in the assemblies, and skips what exists\. A subscription belongs to the receiving service, so this method does not create subscriptions\. |
| [FindMessageTypes\(IEnumerable&lt;Assembly&gt;\)](ServiceBusTopology.FindMessageTypes.51ORQD9Z0U7EEPDKAZWRI0DT3.md 'Cat\.Messaging\.AzureServiceBus\.ServiceBusTopology\.FindMessageTypes\(System\.Collections\.Generic\.IEnumerable\<System\.Reflection\.Assembly\>\)') | Finds the concrete message types\. Two types with the same name give one entity\. |
| [GetTypesSafely\(Assembly\)](ServiceBusTopology.GetTypesSafely.7HP4ZFT591KZW3UCNDTH9FEJ1.md 'Cat\.Messaging\.AzureServiceBus\.ServiceBusTopology\.GetTypesSafely\(System\.Reflection\.Assembly\)') | |
