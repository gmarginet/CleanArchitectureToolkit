<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.EventAggregators\.Abstractions](index.md 'index') > [Cat\.EventAggregators\.Abstractions](Cat.EventAggregators.Abstractions.md 'Cat\.EventAggregators\.Abstractions') > [ICatEventAggregator](ICatEventAggregator.md 'Cat\.EventAggregators\.Abstractions\.ICatEventAggregator')

## ICatEventAggregator\.PublishAsync\(object, CancellationToken\) Method

Publishes an event to every live subscriber that handles its type, and waits for all handlers to complete\.

```csharp
System.Threading.Tasks.Task PublishAsync(object @event, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Cat.EventAggregators.Abstractions.ICatEventAggregator.PublishAsync(object,System.Threading.CancellationToken).event'></a>

`event` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

The event instance to publish\.

<a name='Cat.EventAggregators.Abstractions.ICatEventAggregator.PublishAsync(object,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A token to cancel the publish operation\.

#### Returns
[System\.Threading\.Tasks\.Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task 'System\.Threading\.Tasks\.Task')