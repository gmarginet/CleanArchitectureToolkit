<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.EventAggregators](index.md 'index') > [Cat\.EventAggregators](Cat.EventAggregators.md 'Cat\.EventAggregators') > [CatEventAggregator](CatEventAggregator.md 'Cat\.EventAggregators\.CatEventAggregator') > [Subscription](CatEventAggregator.Subscription.md 'Cat\.EventAggregators\.CatEventAggregator\.Subscription')

## CatEventAggregator\.Subscription\.InvokeHandler\(MethodInfo, object, object, CancellationToken\) Method

Calls one handler\. When the handler throws before it returns a task, the exception comes back as a failed task\.
That way the other handlers still run, and the caller gets the original exception, not a [System\.Reflection\.TargetInvocationException](https://learn.microsoft.com/en-us/dotnet/api/system.reflection.targetinvocationexception 'System\.Reflection\.TargetInvocationException')\.

```csharp
private static System.Threading.Tasks.Task InvokeHandler(System.Reflection.MethodInfo method, object subscriber, object @event, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='Cat.EventAggregators.CatEventAggregator.Subscription.InvokeHandler(System.Reflection.MethodInfo,object,object,System.Threading.CancellationToken).method'></a>

`method` [System\.Reflection\.MethodInfo](https://learn.microsoft.com/en-us/dotnet/api/system.reflection.methodinfo 'System\.Reflection\.MethodInfo')

The handler method\.

<a name='Cat.EventAggregators.CatEventAggregator.Subscription.InvokeHandler(System.Reflection.MethodInfo,object,object,System.Threading.CancellationToken).subscriber'></a>

`subscriber` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

The subscriber that owns the method\.

<a name='Cat.EventAggregators.CatEventAggregator.Subscription.InvokeHandler(System.Reflection.MethodInfo,object,object,System.Threading.CancellationToken).event'></a>

`event` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

The event instance to dispatch\.

<a name='Cat.EventAggregators.CatEventAggregator.Subscription.InvokeHandler(System.Reflection.MethodInfo,object,object,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A token to cancel the handling operation\.

#### Returns
[System\.Threading\.Tasks\.Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task 'System\.Threading\.Tasks\.Task')  
The task of the handler\.