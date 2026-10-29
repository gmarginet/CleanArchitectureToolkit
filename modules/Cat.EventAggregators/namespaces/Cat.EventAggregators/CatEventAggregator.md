<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.EventAggregators](index.md 'index') > [Cat\.EventAggregators](Cat.EventAggregators.md 'Cat\.EventAggregators')

## CatEventAggregator Class

Default in\-memory implementation of [ICatEventAggregator](../Cat.EventAggregators.Abstractions/ICatEventAggregator.md 'Cat\.EventAggregators\.Abstractions\.ICatEventAggregator')\. Tracks subscribers through weak
references, so a subscriber doesn't need to unsubscribe to be garbage collected\.

```csharp
internal class CatEventAggregator : Cat.EventAggregators.Abstractions.ICatEventAggregator
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; CatEventAggregator

Implements [ICatEventAggregator](../Cat.EventAggregators.Abstractions/ICatEventAggregator.md 'Cat\.EventAggregators\.Abstractions\.ICatEventAggregator')

| Fields | |
| :--- | :--- |
| [\_subscriptions](CatEventAggregator._subscriptions.md 'Cat\.EventAggregators\.CatEventAggregator\.\_subscriptions') | |

| Methods | |
| :--- | :--- |
| [HasSubscribersForEvent\(Type\)](CatEventAggregator.HasSubscribersForEvent.FGHVW7KWUFU4OZTMRSQG06VNC.md 'Cat\.EventAggregators\.CatEventAggregator\.HasSubscribersForEvent\(System\.Type\)') | Checks whether any live subscriber currently handles the given event type\. |
| [PublishAsync\(object, CancellationToken\)](CatEventAggregator.PublishAsync.3E76WOMKYET3G0CDCKZIN1B83.md 'Cat\.EventAggregators\.CatEventAggregator\.PublishAsync\(object, System\.Threading\.CancellationToken\)') | Publishes an event to every live subscriber that handles its type, and waits for all handlers to complete\. |
| [Subscribe\(object\)](CatEventAggregator.Subscribe.V4TP29GTQZNR45IELMAP6BOR.md 'Cat\.EventAggregators\.CatEventAggregator\.Subscribe\(object\)') | Registers a subscriber so it receives events for every [ICatHandleEvent&lt;TEvent&gt;](../Cat.EventAggregators.Abstractions/ICatHandleEvent_TEvent_.md 'Cat\.EventAggregators\.Abstractions\.ICatHandleEvent\`1') it implements\. |
| [Unsubscribe\(object\)](CatEventAggregator.Unsubscribe.WGQJPBS9GISZ4Z2T7IJ2ANN33.md 'Cat\.EventAggregators\.CatEventAggregator\.Unsubscribe\(object\)') | Removes a previously registered subscriber so it stops receiving events\. |
