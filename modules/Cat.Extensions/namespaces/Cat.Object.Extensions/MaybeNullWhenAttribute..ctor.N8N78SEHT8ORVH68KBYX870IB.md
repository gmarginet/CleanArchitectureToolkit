<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Object\.Extensions](index.md 'index') > [System\.Diagnostics\.CodeAnalysis](System.Diagnostics.CodeAnalysis.md 'System\.Diagnostics\.CodeAnalysis') > [MaybeNullWhenAttribute](MaybeNullWhenAttribute.md 'System\.Diagnostics\.CodeAnalysis\.MaybeNullWhenAttribute')

## MaybeNullWhenAttribute\(bool\) Constructor

Initializes the attribute with the specified return value condition\.

```csharp
public MaybeNullWhenAttribute(bool returnValue);
```
#### Parameters

<a name='System.Diagnostics.CodeAnalysis.MaybeNullWhenAttribute.MaybeNullWhenAttribute(bool).returnValue'></a>

`returnValue` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

The return value condition\.
If the method returns this value, the associated parameter may be [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.