<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.EventAggregators](index.md 'index') > [Cat\.EventAggregators](Cat.EventAggregators.md 'Cat\.EventAggregators') > [CatEventAggregator](CatEventAggregator.md 'Cat\.EventAggregators\.CatEventAggregator') > [Subscription](CatEventAggregator.Subscription.md 'Cat\.EventAggregators\.CatEventAggregator\.Subscription')

## Subscription\(object\) Constructor

Inspects the subscriber's implemented interfaces and caches its [ICatHandleEvent&lt;TEvent&gt;](../../../Cat.EventAggregators/namespaces/Cat.EventAggregators.Abstractions/ICatHandleEvent_TEvent_.md 'Cat\.EventAggregators\.Abstractions\.ICatHandleEvent\`1') handler methods, keyed by event type\.

```csharp
public Subscription(object subscriber);
```
#### Parameters

<a name='Cat.EventAggregators.CatEventAggregator.Subscription.Subscription(object).subscriber'></a>

`subscriber` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

The subscriber instance to track\. It's held by a weak reference\.