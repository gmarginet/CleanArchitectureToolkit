<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Responses](index.md 'index') > [Cat\.Responses](Cat.Responses.md 'Cat\.Responses') > [CatError](CatError.md 'Cat\.Responses\.CatError')

## CatError\.Code Property

A stable code identifying the kind of error, independent of its message text\.

```csharp
public string Code { get; private set; }
```

Implements [Code](..\Cat.Responses.Abstractions\ICatError.Code.md 'Cat\.Responses\.Abstractions\.ICatError\.Code')

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')