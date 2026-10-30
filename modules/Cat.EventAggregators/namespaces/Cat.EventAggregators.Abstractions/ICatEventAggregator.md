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

|&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[CAT.EVENTAGGREGATORS](../../README.md)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.EventAggregators\.Abstractions Assembly](index.md 'index') >> [Cat\.EventAggregators\.Abstractions Namespace](Cat.EventAggregators.Abstractions.md 'Cat\.EventAggregators\.Abstractions')

## ICatEventAggregator Interface

Publishes events to subscribers that implement [ICatHandleEvent&lt;TEvent&gt;](ICatHandleEvent_TEvent_.md 'Cat\.EventAggregators\.Abstractions\.ICatHandleEvent\<TEvent\>') for the event's type\.

```csharp
public interface ICatEventAggregator
```

| Methods | |
| :--- | :--- |
| [HasSubscribersForEvent\(Type\)](ICatEventAggregator.HasSubscribersForEvent.N681I1FETEOLJC18VX34L5GE.md 'Cat\.EventAggregators\.Abstractions\.ICatEventAggregator\.HasSubscribersForEvent\(System\.Type\)') | Checks whether any live subscriber currently handles the given event type\. |
| [PublishAsync\(object, CancellationToken\)](ICatEventAggregator.PublishAsync.255NNT0CTQLR4IZT88LNX6BZ7.md 'Cat\.EventAggregators\.Abstractions\.ICatEventAggregator\.PublishAsync\(object, System\.Threading\.CancellationToken\)') | Publishes an event to every live subscriber that handles its type, and waits for all handlers to complete\. |
| [Subscribe\(object\)](ICatEventAggregator.Subscribe.UAP61SE4Y7K8NH7WZG3YYJWP7.md 'Cat\.EventAggregators\.Abstractions\.ICatEventAggregator\.Subscribe\(object\)') | Registers a subscriber so it receives events for every [ICatHandleEvent&lt;TEvent&gt;](ICatHandleEvent_TEvent_.md 'Cat\.EventAggregators\.Abstractions\.ICatHandleEvent\<TEvent\>') it implements\. |
| [Unsubscribe\(object\)](ICatEventAggregator.Unsubscribe.QFMFC33IRLO9WQRQ5Z7JO71H1.md 'Cat\.EventAggregators\.Abstractions\.ICatEventAggregator\.Unsubscribe\(object\)') | Removes a previously registered subscriber so it stops receiving events\. |
