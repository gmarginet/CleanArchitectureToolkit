<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.EventAggregators](index.md 'index') > [Cat\.EventAggregators](Cat.EventAggregators.md 'Cat\.EventAggregators') > [CatEventAggregator](CatEventAggregator.md 'Cat\.EventAggregators\.CatEventAggregator')

## CatEventAggregator\.Subscribe\(object\) Method

Registers a subscriber so it receives events for every [ICatHandleEvent&lt;TEvent&gt;](../../../Cat.EventAggregators/namespaces/Cat.EventAggregators.Abstractions/ICatHandleEvent_TEvent_.md 'Cat\.EventAggregators\.Abstractions\.ICatHandleEvent\`1') it implements\.

```csharp
public void Subscribe(object subscriber);
```
#### Parameters

<a name='Cat.EventAggregators.CatEventAggregator.Subscribe(object).subscriber'></a>

`subscriber` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

The subscriber instance to register\. It's held by a weak reference, so it won't be kept alive by the aggregator\.

Implements [Subscribe\(object\)](../../../Cat.EventAggregators/namespaces/Cat.EventAggregators.Abstractions/ICatEventAggregator.Subscribe.UAP61SE4Y7K8NH7WZG3YYJWP7.md 'Cat\.EventAggregators\.Abstractions\.ICatEventAggregator\.Subscribe\(System\.Object\)')