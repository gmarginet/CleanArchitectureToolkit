<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Responses](index.md 'index') > [Cat\.Responses](Cat.Responses.md 'Cat\.Responses') > [CatError](CatError.md 'Cat\.Responses\.CatError')

## CatError\(string, string, object\[\]\) Constructor

Creates an error with the given code, message, and arguments\.

```csharp
private CatError(string code, string message, object?[] arguments);
```
#### Parameters

<a name='Cat.Responses.CatError.CatError(string,string,object[]).code'></a>

`code` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The stable code identifying this kind of error\.

<a name='Cat.Responses.CatError.CatError(string,string,object[]).message'></a>

`message` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The error message\. Can contain placeholders filled in by [arguments](CatError..ctor.6388ROMK40MNSHIGSSKKVZTIE.md#Cat.Responses.CatError.CatError(string,string,object[]).arguments 'Cat\.Responses\.CatError\.CatError\(string, string, object\[\]\)\.arguments')\.

<a name='Cat.Responses.CatError.CatError(string,string,object[]).arguments'></a>

`arguments` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The values to substitute into the message's placeholders, in order\.