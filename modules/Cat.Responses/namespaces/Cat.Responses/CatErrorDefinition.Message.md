<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Responses](index.md 'index') > [Cat\.Responses](Cat.Responses.md 'Cat\.Responses') > [CatErrorDefinition](CatErrorDefinition.md 'Cat\.Responses\.CatErrorDefinition')

## CatErrorDefinition\.Message Property

A human\-readable message describing the error\. Can contain placeholders filled in by [Arguments](..\Cat.Responses.Abstractions\ICatError.Arguments.md 'Cat\.Responses\.Abstractions\.ICatError\.Arguments')\.

```csharp
public string Message { get; private set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')