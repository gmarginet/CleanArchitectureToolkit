<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Responses](index.md 'index') > [Cat\.Responses](Cat.Responses.md 'Cat\.Responses') > [CatResponse&lt;TResponse&gt;](CatResponse_TResponse_.md 'Cat\.Responses\.CatResponse\<TResponse\>')

## CatResponse\<TResponse\>\.Value Property

The value the operation produced\. Only meaningful when [IsSucceeded](..\Cat.Responses.Abstractions\ICatResponse.IsSucceeded.md 'Cat\.Responses\.Abstractions\.ICatResponse\.IsSucceeded') is `true`\.

```csharp
public TResponse Value { get; }
```

Implements [Value](..\Cat.Responses.Abstractions\ICatResponse_TResponse_.Value.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1\.Value')

#### Property Value
[TResponse](CatResponse_TResponse_.md#Cat.Responses.CatResponse_TResponse_.TResponse 'Cat\.Responses\.CatResponse\<TResponse\>\.TResponse')