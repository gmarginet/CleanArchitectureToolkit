<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.EventAggregators\.Abstractions](index.md 'index') > [Cat\.EventAggregators\.Abstractions](Cat.EventAggregators.Abstractions.md 'Cat\.EventAggregators\.Abstractions') > [ICatEventAggregator](ICatEventAggregator.md 'Cat\.EventAggregators\.Abstractions\.ICatEventAggregator')

## ICatEventAggregator\.Unsubscribe\(object\) Method

Removes a previously registered subscriber so it stops receiving events\.

```csharp
void Unsubscribe(object subscriber);
```
#### Parameters

<a name='Cat.EventAggregators.Abstractions.ICatEventAggregator.Unsubscribe(object).subscriber'></a>

`subscriber` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

The subscriber instance to remove\.