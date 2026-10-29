<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.EventAggregators\.Abstractions](index.md 'index') > [Cat\.EventAggregators\.Abstractions](Cat.EventAggregators.Abstractions.md 'Cat\.EventAggregators\.Abstractions') > [ICatEventAggregator](ICatEventAggregator.md 'Cat\.EventAggregators\.Abstractions\.ICatEventAggregator')

## ICatEventAggregator\.Subscribe\(object\) Method

Registers a subscriber so it receives events for every [ICatHandleEvent&lt;TEvent&gt;](ICatHandleEvent_TEvent_.md 'Cat\.EventAggregators\.Abstractions\.ICatHandleEvent\<TEvent\>') it implements\.

```csharp
void Subscribe(object subscriber);
```
#### Parameters

<a name='Cat.EventAggregators.Abstractions.ICatEventAggregator.Subscribe(object).subscriber'></a>

`subscriber` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

The subscriber instance to register\. It's held by a weak reference, so it won't be kept alive by the aggregator\.