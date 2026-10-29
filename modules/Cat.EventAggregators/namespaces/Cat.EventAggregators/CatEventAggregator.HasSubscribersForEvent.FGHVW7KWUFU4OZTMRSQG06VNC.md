<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.EventAggregators](index.md 'index') > [Cat\.EventAggregators](Cat.EventAggregators.md 'Cat\.EventAggregators') > [CatEventAggregator](CatEventAggregator.md 'Cat\.EventAggregators\.CatEventAggregator')

## CatEventAggregator\.HasSubscribersForEvent\(Type\) Method

Checks whether any live subscriber currently handles the given event type\.

```csharp
public bool HasSubscribersForEvent(System.Type eventType);
```
#### Parameters

<a name='Cat.EventAggregators.CatEventAggregator.HasSubscribersForEvent(System.Type).eventType'></a>

`eventType` [System\.Type](https://learn.microsoft.com/en-us/dotnet/api/system.type 'System\.Type')

The event type to check for\.

Implements [HasSubscribersForEvent\(Type\)](..\Cat.EventAggregators.Abstractions\ICatEventAggregator.HasSubscribersForEvent.N681I1FETEOLJC18VX34L5GE.md 'Cat\.EventAggregators\.Abstractions\.ICatEventAggregator\.HasSubscribersForEvent\(System\.Type\)')

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` if at least one live subscriber handles the event type, otherwise `false`\.