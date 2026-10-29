<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Responses](index.md 'index') > [Cat\.Responses](Cat.Responses.md 'Cat\.Responses') > [CatErrorDefinition](CatErrorDefinition.md 'Cat\.Responses\.CatErrorDefinition')

## CatErrorDefinition\.Create\(string, string\) Method

Creates a new error definition\.

```csharp
public static Cat.Responses.CatErrorDefinition Create(string code, string message);
```
#### Parameters

<a name='Cat.Responses.CatErrorDefinition.Create(string,string).code'></a>

`code` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The stable code identifying this kind of error\.

<a name='Cat.Responses.CatErrorDefinition.Create(string,string).message'></a>

`message` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The message template\. Can contain placeholders filled in when [CreateCatError\(object\[\]\)](CatErrorDefinition.CreateCatError.5WX0CKR3WJOIDHOM83UIBF54.md 'Cat\.Responses\.CatErrorDefinition\.CreateCatError\(object\[\]\)') is called\.

#### Returns
[CatErrorDefinition](CatErrorDefinition.md 'Cat\.Responses\.CatErrorDefinition')  
The new error definition\.