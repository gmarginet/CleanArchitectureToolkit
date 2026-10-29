<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.EventAggregators](index.md 'index') > [Cat\.EventAggregators](Cat.EventAggregators.md 'Cat\.EventAggregators') > [CatEventAggregator](CatEventAggregator.md 'Cat\.EventAggregators\.CatEventAggregator') > [Subscription](CatEventAggregator.Subscription.md 'Cat\.EventAggregators\.CatEventAggregator\.Subscription')

## CatEventAggregator\.Subscription\.Matches\(object\) Method

Checks whether this subscription tracks the given subscriber instance\.

```csharp
public bool Matches(object instance);
```
#### Parameters

<a name='Cat.EventAggregators.CatEventAggregator.Subscription.Matches(object).instance'></a>

`instance` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

The instance to compare by reference\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` if [instance](CatEventAggregator.Subscription.Matches.OJGHYEN1YIW6ADPONXAOV49C.md#Cat.EventAggregators.CatEventAggregator.Subscription.Matches(object).instance 'Cat\.EventAggregators\.CatEventAggregator\.Subscription\.Matches\(object\)\.instance') is the tracked subscriber\.