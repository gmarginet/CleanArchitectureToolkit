<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators](Cat.Validators.md 'Cat\.Validators') > [CatValidatorError](CatValidatorError.md 'Cat\.Validators\.CatValidatorError')

## CatValidatorError\(string, string, string, IList\<object\>\) Constructor

Creates the error\.

```csharp
public CatValidatorError(string code, string fieldName, string message, System.Collections.Generic.IList<object?> arguments);
```
#### Parameters

<a name='Cat.Validators.CatValidatorError.CatValidatorError(string,string,string,System.Collections.Generic.IList_object_).code'></a>

`code` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The stable code of this kind of failure\.

<a name='Cat.Validators.CatValidatorError.CatValidatorError(string,string,string,System.Collections.Generic.IList_object_).fieldName'></a>

`fieldName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the field that failed\.

<a name='Cat.Validators.CatValidatorError.CatValidatorError(string,string,string,System.Collections.Generic.IList_object_).message'></a>

`message` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The message template\.

<a name='Cat.Validators.CatValidatorError.CatValidatorError(string,string,string,System.Collections.Generic.IList_object_).arguments'></a>

`arguments` [System\.Collections\.Generic\.IList&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ilist-1 'System\.Collections\.Generic\.IList\`1')[System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ilist-1 'System\.Collections\.Generic\.IList\`1')

The values for the message placeholders, in order\.