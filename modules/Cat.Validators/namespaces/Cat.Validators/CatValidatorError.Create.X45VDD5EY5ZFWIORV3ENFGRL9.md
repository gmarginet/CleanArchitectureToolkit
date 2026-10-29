<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators](Cat.Validators.md 'Cat\.Validators') > [CatValidatorError](CatValidatorError.md 'Cat\.Validators\.CatValidatorError')

## CatValidatorError\.Create\(string, string, string, object\[\]\) Method

Creates an error\.

```csharp
public static Cat.Validators.CatValidatorError Create(string code, string fieldName, string message, params object?[] arguments);
```
#### Parameters

<a name='Cat.Validators.CatValidatorError.Create(string,string,string,object[]).code'></a>

`code` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The stable code of this kind of failure\.

<a name='Cat.Validators.CatValidatorError.Create(string,string,string,object[]).fieldName'></a>

`fieldName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the field that failed\.

<a name='Cat.Validators.CatValidatorError.Create(string,string,string,object[]).message'></a>

`message` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The message template\.

<a name='Cat.Validators.CatValidatorError.Create(string,string,string,object[]).arguments'></a>

`arguments` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The values for the message placeholders, in order\.

#### Returns
[CatValidatorError](CatValidatorError.md 'Cat\.Validators\.CatValidatorError')  
The new error\.