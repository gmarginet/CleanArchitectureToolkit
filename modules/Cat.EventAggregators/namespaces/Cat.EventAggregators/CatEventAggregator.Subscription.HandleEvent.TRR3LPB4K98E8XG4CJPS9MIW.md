<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.EventAggregators](index.md 'index') > [Cat\.EventAggregators](Cat.EventAggregators.md 'Cat\.EventAggregators') > [CatEventAggregator](CatEventAggregator.md 'Cat\.EventAggregators\.CatEventAggregator') > [Subscription](CatEventAggregator.Subscription.md 'Cat\.EventAggregators\.CatEventAggregator\.Subscription')

## CatEventAggregator\.Subscription\.HandleEvent\(object, CancellationToken\) Method

Invokes every handler the subscriber has for the event's type\.

```csharp
public System.Collections.Generic.IList<System.Threading.Tasks.Task> HandleEvent(object @event, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='Cat.EventAggregators.CatEventAggregator.Subscription.HandleEvent(object,System.Threading.CancellationToken).event'></a>

`event` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

The event instance to dispatch\.

<a name='Cat.EventAggregators.CatEventAggregator.Subscription.HandleEvent(object,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A token to cancel the handling operation\.

#### Returns
[System\.Collections\.Generic\.IList&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ilist-1 'System\.Collections\.Generic\.IList\`1')[System\.Threading\.Tasks\.Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task 'System\.Threading\.Tasks\.Task')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ilist-1 'System\.Collections\.Generic\.IList\`1')  
The tasks returned by each matching handler, or an empty list if the subscriber is dead or has no matching handler\.