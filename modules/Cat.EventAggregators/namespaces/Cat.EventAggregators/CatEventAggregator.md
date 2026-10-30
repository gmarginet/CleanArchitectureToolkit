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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.EVENTAGGREGATORS](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.EventAggregators Assembly](index.md 'index') >> [Cat\.EventAggregators Namespace](Cat.EventAggregators.md 'Cat\.EventAggregators')

## CatEventAggregator Class

Default in\-memory implementation of [ICatEventAggregator](../../../Cat.EventAggregators/namespaces/Cat.EventAggregators.Abstractions/ICatEventAggregator.md 'Cat\.EventAggregators\.Abstractions\.ICatEventAggregator')\. Tracks subscribers through weak
references, so a subscriber doesn't need to unsubscribe to be garbage collected\.

```csharp
internal class CatEventAggregator : Cat.EventAggregators.Abstractions.ICatEventAggregator
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatEventAggregator

Implements [ICatEventAggregator](../../../Cat.EventAggregators/namespaces/Cat.EventAggregators.Abstractions/ICatEventAggregator.md 'Cat\.EventAggregators\.Abstractions\.ICatEventAggregator')

| Fields | |
| :--- | :--- |
| [\_subscriptions](CatEventAggregator._subscriptions.md 'Cat\.EventAggregators\.CatEventAggregator\.\_subscriptions') | |

| Methods | |
| :--- | :--- |
| [HasSubscribersForEvent\(Type\)](CatEventAggregator.HasSubscribersForEvent.FGHVW7KWUFU4OZTMRSQG06VNC.md 'Cat\.EventAggregators\.CatEventAggregator\.HasSubscribersForEvent\(System\.Type\)') | Checks whether any live subscriber currently handles the given event type\. |
| [PublishAsync\(object, CancellationToken\)](CatEventAggregator.PublishAsync.3E76WOMKYET3G0CDCKZIN1B83.md 'Cat\.EventAggregators\.CatEventAggregator\.PublishAsync\(object, System\.Threading\.CancellationToken\)') | Publishes an event to every live subscriber that handles its type, and waits for all handlers to complete\. |
| [Subscribe\(object\)](CatEventAggregator.Subscribe.V4TP29GTQZNR45IELMAP6BOR.md 'Cat\.EventAggregators\.CatEventAggregator\.Subscribe\(object\)') | Registers a subscriber so it receives events for every [ICatHandleEvent&lt;TEvent&gt;](../../../Cat.EventAggregators/namespaces/Cat.EventAggregators.Abstractions/ICatHandleEvent_TEvent_.md 'Cat\.EventAggregators\.Abstractions\.ICatHandleEvent\`1') it implements\. |
| [Unsubscribe\(object\)](CatEventAggregator.Unsubscribe.WGQJPBS9GISZ4Z2T7IJ2ANN33.md 'Cat\.EventAggregators\.CatEventAggregator\.Unsubscribe\(object\)') | Removes a previously registered subscriber so it stops receiving events\. |
