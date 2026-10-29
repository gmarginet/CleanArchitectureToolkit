<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Localizations\.Abstractions](index.md 'index') > [Cat\.Localizations\.Abstractions](Cat.Localizations.Abstractions.md 'Cat\.Localizations\.Abstractions') > [ICatLocalizer](ICatLocalizer.md 'Cat\.Localizations\.Abstractions\.ICatLocalizer')

## ICatLocalizer\.this\[string, object\[\]\] Property

Gets the localized string for the given key, with placeholders filled in from the given arguments\.

```csharp
string this[string key, params object[] arguments] { get; }
```
#### Parameters

<a name='Cat.Localizations.Abstractions.ICatLocalizer.this[string,object[]].key'></a>

`key` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The key to look up\. Its localized value can contain placeholders, filled in order by [arguments](ICatLocalizer.Item.SP0BGHDYQU87JBN8QJGTH1HL2.md#Cat.Localizations.Abstractions.ICatLocalizer.this[string,object[]].arguments 'Cat\.Localizations\.Abstractions\.ICatLocalizer\.this\[string, object\[\]\]\.arguments')\.

<a name='Cat.Localizations.Abstractions.ICatLocalizer.this[string,object[]].arguments'></a>

`arguments` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The values to substitute into the localized string's placeholders, in order\.

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')