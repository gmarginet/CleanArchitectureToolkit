<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Responses\.Abstractions](index.md 'index') > [Cat\.Responses\.Abstractions](Cat.Responses.Abstractions.md 'Cat\.Responses\.Abstractions') > [ICatResponse&lt;TResponse&gt;](ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\<TResponse\>')

## ICatResponse\<TResponse\>\.Value Property

The value the operation produced\. Only meaningful when [IsSucceeded](ICatResponse.IsSucceeded.md 'Cat\.Responses\.Abstractions\.ICatResponse\.IsSucceeded') is `true`\.

```csharp
TResponse Value { get; }
```

#### Property Value
[TResponse](ICatResponse_TResponse_.md#Cat.Responses.Abstractions.ICatResponse_TResponse_.TResponse 'Cat\.Responses\.Abstractions\.ICatResponse\<TResponse\>\.TResponse')