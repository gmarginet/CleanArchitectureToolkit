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
  
##### >> [Cat\.EventProcessor\.AzureServiceBus Assembly](index.md 'index') >> [Cat\.EventProcessor\.AzureServiceBus Namespace](Cat.EventProcessor.AzureServiceBus.md 'Cat\.EventProcessor\.AzureServiceBus')

## ICatEventProcessorTopology Interface

The easy way to create the subscriptions of this service\. A subscription belongs to the receiving service,
so the service creates its own, while the topic comes from the sender, see `ICatServiceBusTopology`\.
Nothing is created when the service starts\. It needs the manage right on the namespace\.

```csharp
public interface ICatEventProcessorTopology
```

Derived  
↳ [EventProcessorTopology](EventProcessorTopology.md 'Cat\.EventProcessor\.AzureServiceBus\.EventProcessorTopology')

| Methods | |
| :--- | :--- |
| [EnsureSubscriptionsAsync\(CancellationToken\)](ICatEventProcessorTopology.EnsureSubscriptionsAsync.89JZG04UO47UW6NXNKN2IUQSE.md 'Cat\.EventProcessor\.AzureServiceBus\.ICatEventProcessorTopology\.EnsureSubscriptionsAsync\(System\.Threading\.CancellationToken\)') | Creates the subscription of this service on the topic of every declared event, and skips what exists\. The topic must exist already\. |
