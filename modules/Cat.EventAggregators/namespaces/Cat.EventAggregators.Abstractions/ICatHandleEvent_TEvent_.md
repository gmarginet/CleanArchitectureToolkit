<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.EventAggregators\.Abstractions](index.md 'index') > [Cat\.EventAggregators\.Abstractions](Cat.EventAggregators.Abstractions.md 'Cat\.EventAggregators\.Abstractions')

## ICatHandleEvent\<TEvent\> Interface

Implemented by a subscriber to receive events of type [TEvent](ICatHandleEvent_TEvent_.md#Cat.EventAggregators.Abstractions.ICatHandleEvent_TEvent_.TEvent 'Cat\.EventAggregators\.Abstractions\.ICatHandleEvent\<TEvent\>\.TEvent') from an [ICatEventAggregator](ICatEventAggregator.md 'Cat\.EventAggregators\.Abstractions\.ICatEventAggregator')\.

```csharp
public interface ICatHandleEvent<TEvent>
```
#### Type parameters

<a name='Cat.EventAggregators.Abstractions.ICatHandleEvent_TEvent_.TEvent'></a>

`TEvent`

The type of event this subscriber handles\.

| Methods | |
| :--- | :--- |
| [HandleEventAsync\(TEvent, CancellationToken\)](ICatHandleEvent_TEvent_.HandleEventAsync.NMZ3DXDP6PB8OWDL74UKQ2F8A.md 'Cat\.EventAggregators\.Abstractions\.ICatHandleEvent\<TEvent\>\.HandleEventAsync\(TEvent, System\.Threading\.CancellationToken\)') | Handles a published event\. |
