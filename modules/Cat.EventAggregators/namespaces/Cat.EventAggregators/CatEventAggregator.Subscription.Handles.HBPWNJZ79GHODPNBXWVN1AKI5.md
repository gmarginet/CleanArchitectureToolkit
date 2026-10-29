<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.EventAggregators](index.md 'index') > [Cat\.EventAggregators](Cat.EventAggregators.md 'Cat\.EventAggregators') > [CatEventAggregator](CatEventAggregator.md 'Cat\.EventAggregators\.CatEventAggregator') > [Subscription](CatEventAggregator.Subscription.md 'Cat\.EventAggregators\.CatEventAggregator\.Subscription')

## CatEventAggregator\.Subscription\.Handles\(Type\) Method

Checks whether the subscriber handles the given event type\.

```csharp
public bool Handles(System.Type eventType);
```
#### Parameters

<a name='Cat.EventAggregators.CatEventAggregator.Subscription.Handles(System.Type).eventType'></a>

`eventType` [System\.Type](https://learn.microsoft.com/en-us/dotnet/api/system.type 'System\.Type')

The event type to check for\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` if the subscriber has a handler assignable from [eventType](CatEventAggregator.Subscription.Handles.HBPWNJZ79GHODPNBXWVN1AKI5.md#Cat.EventAggregators.CatEventAggregator.Subscription.Handles(System.Type).eventType 'Cat\.EventAggregators\.CatEventAggregator\.Subscription\.Handles\(System\.Type\)\.eventType')\.