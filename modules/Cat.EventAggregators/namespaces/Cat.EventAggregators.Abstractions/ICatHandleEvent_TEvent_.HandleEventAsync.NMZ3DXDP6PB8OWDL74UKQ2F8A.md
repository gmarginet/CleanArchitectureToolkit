<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.EventAggregators\.Abstractions](index.md 'index') > [Cat\.EventAggregators\.Abstractions](Cat.EventAggregators.Abstractions.md 'Cat\.EventAggregators\.Abstractions') > [ICatHandleEvent&lt;TEvent&gt;](ICatHandleEvent_TEvent_.md 'Cat\.EventAggregators\.Abstractions\.ICatHandleEvent\<TEvent\>')

## ICatHandleEvent\<TEvent\>\.HandleEventAsync\(TEvent, CancellationToken\) Method

Handles a published event\.

```csharp
System.Threading.Tasks.Task HandleEventAsync(TEvent @event, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Cat.EventAggregators.Abstractions.ICatHandleEvent_TEvent_.HandleEventAsync(TEvent,System.Threading.CancellationToken).event'></a>

`event` [TEvent](ICatHandleEvent_TEvent_.md#Cat.EventAggregators.Abstractions.ICatHandleEvent_TEvent_.TEvent 'Cat\.EventAggregators\.Abstractions\.ICatHandleEvent\<TEvent\>\.TEvent')

The event instance to handle\.

<a name='Cat.EventAggregators.Abstractions.ICatHandleEvent_TEvent_.HandleEventAsync(TEvent,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A token to cancel the handling operation\.

#### Returns
[System\.Threading\.Tasks\.Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task 'System\.Threading\.Tasks\.Task')