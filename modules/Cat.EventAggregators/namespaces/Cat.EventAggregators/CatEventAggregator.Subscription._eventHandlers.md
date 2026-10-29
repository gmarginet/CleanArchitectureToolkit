<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.EventAggregators](index.md 'index') > [Cat\.EventAggregators](Cat.EventAggregators.md 'Cat\.EventAggregators') > [CatEventAggregator](CatEventAggregator.md 'Cat\.EventAggregators\.CatEventAggregator') > [Subscription](CatEventAggregator.Subscription.md 'Cat\.EventAggregators\.CatEventAggregator\.Subscription')

## CatEventAggregator\.Subscription\.\_eventHandlers Field

```csharp
private readonly Dictionary<TypeInfo,MethodInfo> _eventHandlers;
```

#### Field Value
[System\.Collections\.Generic\.Dictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[System\.Reflection\.TypeInfo](https://learn.microsoft.com/en-us/dotnet/api/system.reflection.typeinfo 'System\.Reflection\.TypeInfo')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[System\.Reflection\.MethodInfo](https://learn.microsoft.com/en-us/dotnet/api/system.reflection.methodinfo 'System\.Reflection\.MethodInfo')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')