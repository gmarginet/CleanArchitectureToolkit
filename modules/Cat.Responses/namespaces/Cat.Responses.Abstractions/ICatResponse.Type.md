<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Responses\.Abstractions](index.md 'index') > [Cat\.Responses\.Abstractions](Cat.Responses.Abstractions.md 'Cat\.Responses\.Abstractions') > [ICatResponse](ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse')

## ICatResponse\.Type Property

The specific outcome of the operation, such as [Ok](CatResponseType.Ok.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Ok') or [NotFound](CatResponseType.NotFound.md 'Cat\.Responses\.Abstractions\.CatResponseType\.NotFound')\.

```csharp
Cat.Responses.Abstractions.CatResponseType Type { get; }
```

#### Property Value
[CatResponseType](CatResponseType.md 'Cat\.Responses\.Abstractions\.CatResponseType')