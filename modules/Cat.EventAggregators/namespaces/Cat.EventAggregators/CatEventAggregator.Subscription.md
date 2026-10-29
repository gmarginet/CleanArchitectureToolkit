<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.EventAggregators](index.md 'index') > [Cat\.EventAggregators](Cat.EventAggregators.md 'Cat\.EventAggregators') > [CatEventAggregator](CatEventAggregator.md 'Cat\.EventAggregators\.CatEventAggregator')

## CatEventAggregator\.Subscription Class

Tracks one subscriber's live reference and the [ICatHandleEvent&lt;TEvent&gt;](../Cat.EventAggregators.Abstractions/ICatHandleEvent_TEvent_.md 'Cat\.EventAggregators\.Abstractions\.ICatHandleEvent\`1') handler methods it implements\.

```csharp
private class CatEventAggregator.Subscription
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; Subscription

| Constructors | |
| :--- | :--- |
| [Subscription\(object\)](CatEventAggregator.Subscription..ctor.OLDQSNEVBBMCFWBC4DG754BJA.md 'Cat\.EventAggregators\.CatEventAggregator\.Subscription\.Subscription\(object\)') | Inspects the subscriber's implemented interfaces and caches its [ICatHandleEvent&lt;TEvent&gt;](../Cat.EventAggregators.Abstractions/ICatHandleEvent_TEvent_.md 'Cat\.EventAggregators\.Abstractions\.ICatHandleEvent\`1') handler methods, keyed by event type\. |

| Fields | |
| :--- | :--- |
| [\_eventHandlers](CatEventAggregator.Subscription._eventHandlers.md 'Cat\.EventAggregators\.CatEventAggregator\.Subscription\.\_eventHandlers') | |
| [\_subscriberReference](CatEventAggregator.Subscription._subscriberReference.md 'Cat\.EventAggregators\.CatEventAggregator\.Subscription\.\_subscriberReference') | |

| Properties | |
| :--- | :--- |
| [HasEventHandlers](CatEventAggregator.Subscription.HasEventHandlers.md 'Cat\.EventAggregators\.CatEventAggregator\.Subscription\.HasEventHandlers') | `true` if the subscriber implements at least one [ICatHandleEvent&lt;TEvent&gt;](../Cat.EventAggregators.Abstractions/ICatHandleEvent_TEvent_.md 'Cat\.EventAggregators\.Abstractions\.ICatHandleEvent\`1') handler\. |
| [IsDead](CatEventAggregator.Subscription.IsDead.md 'Cat\.EventAggregators\.CatEventAggregator\.Subscription\.IsDead') | `true` if the subscriber has been garbage collected\. |

| Methods | |
| :--- | :--- |
| [HandleEvent\(object, CancellationToken\)](CatEventAggregator.Subscription.HandleEvent.TRR3LPB4K98E8XG4CJPS9MIW.md 'Cat\.EventAggregators\.CatEventAggregator\.Subscription\.HandleEvent\(object, System\.Threading\.CancellationToken\)') | Invokes every handler the subscriber has for the event's type\. |
| [Handles\(Type\)](CatEventAggregator.Subscription.Handles.HBPWNJZ79GHODPNBXWVN1AKI5.md 'Cat\.EventAggregators\.CatEventAggregator\.Subscription\.Handles\(System\.Type\)') | Checks whether the subscriber handles the given event type\. |
| [InvokeHandler\(MethodInfo, object, object, CancellationToken\)](CatEventAggregator.Subscription.InvokeHandler.9MJZ8SAOV1SFV0FRJ12EON5XE.md 'Cat\.EventAggregators\.CatEventAggregator\.Subscription\.InvokeHandler\(System\.Reflection\.MethodInfo, object, object, System\.Threading\.CancellationToken\)') | Calls one handler\. When the handler throws before it returns a task, the exception comes back as a failed task\. That way the other handlers still run, and the caller gets the original exception, not a [System\.Reflection\.TargetInvocationException](https://learn.microsoft.com/en-us/dotnet/api/system.reflection.targetinvocationexception 'System\.Reflection\.TargetInvocationException')\. |
| [Matches\(object\)](CatEventAggregator.Subscription.Matches.OJGHYEN1YIW6ADPONXAOV49C.md 'Cat\.EventAggregators\.CatEventAggregator\.Subscription\.Matches\(object\)') | Checks whether this subscription tracks the given subscriber instance\. |
