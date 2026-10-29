<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Responses](index.md 'index') > [Cat\.Responses](Cat.Responses.md 'Cat\.Responses') > [CatResponse](CatResponse.md 'Cat\.Responses\.CatResponse')

## CatResponse\.Type Property

The specific outcome of the operation, such as [Ok](..\Cat.Responses.Abstractions\CatResponseType.Ok.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Ok') or [NotFound](..\Cat.Responses.Abstractions\CatResponseType.NotFound.md 'Cat\.Responses\.Abstractions\.CatResponseType\.NotFound')\.

```csharp
public Cat.Responses.Abstractions.CatResponseType Type { get; private set; }
```

Implements [Type](..\Cat.Responses.Abstractions\ICatResponse.Type.md 'Cat\.Responses\.Abstractions\.ICatResponse\.Type')

#### Property Value
[CatResponseType](..\Cat.Responses.Abstractions\CatResponseType.md 'Cat\.Responses\.Abstractions\.CatResponseType')