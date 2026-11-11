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

## ICatServiceBusTopology Interface

The easy way to create the queues and topics of the message types\. Nothing is created when a service starts\.
Call it from a deployment step, a small tool or a test\. It needs the manage right on the namespace\.

```csharp
public interface ICatServiceBusTopology
```

Derived  
↳ [ServiceBusTopology](ServiceBusTopology.md 'Cat\.Messaging\.AzureServiceBus\.ServiceBusTopology')

| Methods | |
| :--- | :--- |
| [EnsureTopologyAsync\(IEnumerable&lt;Assembly&gt;, CancellationToken\)](ICatServiceBusTopology.EnsureTopologyAsync.BIVLHFG4Y7114YB5ZHKJ7MEBE.md 'Cat\.Messaging\.AzureServiceBus\.ICatServiceBusTopology\.EnsureTopologyAsync\(System\.Collections\.Generic\.IEnumerable\<System\.Reflection\.Assembly\>, System\.Threading\.CancellationToken\)') | Creates a queue for every command message and a topic for every event in the assemblies, and skips what exists\. A subscription belongs to the receiving service, so this method does not create subscriptions\. |
