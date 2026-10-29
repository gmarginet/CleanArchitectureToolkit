<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Responses](index.md 'index') > [Cat\.Responses](Cat.Responses.md 'Cat\.Responses') > [CatErrorDefinition](CatErrorDefinition.md 'Cat\.Responses\.CatErrorDefinition')

## CatErrorDefinition\.CreateCatError\(object\[\]\) Method

Creates an [ICatError](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatError.md 'Cat\.Responses\.Abstractions\.ICatError') from this definition, with the given values filled into the message's placeholders\.

```csharp
public Cat.Responses.Abstractions.ICatError CreateCatError(params object?[] arguments);
```
#### Parameters

<a name='Cat.Responses.CatErrorDefinition.CreateCatError(object[]).arguments'></a>

`arguments` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The values to substitute into the message's placeholders, in order\.

#### Returns
[ICatError](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatError.md 'Cat\.Responses\.Abstractions\.ICatError')  
An error carrying this definition's code and message, with [arguments](CatErrorDefinition.CreateCatError.5WX0CKR3WJOIDHOM83UIBF54.md#Cat.Responses.CatErrorDefinition.CreateCatError(object[]).arguments 'Cat\.Responses\.CatErrorDefinition\.CreateCatError\(object\[\]\)\.arguments') attached\.