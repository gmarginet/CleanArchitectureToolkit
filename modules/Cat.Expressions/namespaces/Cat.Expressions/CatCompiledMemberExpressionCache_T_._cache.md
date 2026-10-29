<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Expressions](index.md 'index') > [Cat\.Expressions](Cat.Expressions.md 'Cat\.Expressions') > [CatCompiledMemberExpressionCache&lt;T&gt;](CatCompiledMemberExpressionCache_T_.md 'Cat\.Expressions\.CatCompiledMemberExpressionCache\<T\>')

## CatCompiledMemberExpressionCache\<T\>\.\_cache Field

```csharp
private readonly ConcurrentDictionary<CatCompiledMemberExpressionKey,Delegate> _cache;
```

#### Field Value
[System\.Collections\.Concurrent\.ConcurrentDictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.concurrent.concurrentdictionary-2 'System\.Collections\.Concurrent\.ConcurrentDictionary\`2')[CatCompiledMemberExpressionKey](CatCompiledMemberExpressionKey.md 'Cat\.Expressions\.CatCompiledMemberExpressionKey')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.concurrent.concurrentdictionary-2 'System\.Collections\.Concurrent\.ConcurrentDictionary\`2')[System\.Delegate](https://learn.microsoft.com/en-us/dotnet/api/system.delegate 'System\.Delegate')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.concurrent.concurrentdictionary-2 'System\.Collections\.Concurrent\.ConcurrentDictionary\`2')