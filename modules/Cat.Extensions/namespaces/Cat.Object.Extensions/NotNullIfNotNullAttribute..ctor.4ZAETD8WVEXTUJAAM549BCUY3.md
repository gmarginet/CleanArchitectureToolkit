<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Object\.Extensions](index.md 'index') > [System\.Diagnostics\.CodeAnalysis](System.Diagnostics.CodeAnalysis.md 'System\.Diagnostics\.CodeAnalysis') > [NotNullIfNotNullAttribute](NotNullIfNotNullAttribute.md 'System\.Diagnostics\.CodeAnalysis\.NotNullIfNotNullAttribute')

## NotNullIfNotNullAttribute\(string\) Constructor

Initializes the attribute with the associated parameter name\.

```csharp
public NotNullIfNotNullAttribute(string parameterName);
```
#### Parameters

<a name='System.Diagnostics.CodeAnalysis.NotNullIfNotNullAttribute.NotNullIfNotNullAttribute(string).parameterName'></a>

`parameterName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The associated parameter name\.
The output will be non\-[null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') if the argument to the
parameter specified is non\-[null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.