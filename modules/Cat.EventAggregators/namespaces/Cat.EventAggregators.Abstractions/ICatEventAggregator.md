<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.EventAggregators\.Abstractions](index.md 'index') > [Cat\.EventAggregators\.Abstractions](Cat.EventAggregators.Abstractions.md 'Cat\.EventAggregators\.Abstractions')

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
