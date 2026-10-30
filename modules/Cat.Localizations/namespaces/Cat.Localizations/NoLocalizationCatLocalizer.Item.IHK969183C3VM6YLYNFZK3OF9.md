<link href="../../../../resources/styles/style.css" rel="stylesheet"/>
<table>
    <tr>
        <td colspan='6' style='text-align: center; font-weight: bold; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>
             Clean Architecture Toolkit for .NET
        </td>
    </tr>
    <tr>
        <td colspan='5' style='padding: 0; vertical-align: middle; border: none;'>
            Clean Architecture Toolkit is a clean, modular architecture foundation for .NET applications.<br>
            It embraces SOLID principles and focuses on maintainability, testability, and scalability through clear boundaries and pluggable design.</td>
        <td style='padding: 0; border: none;' width='220'>
            <img src='../../../../resources/logo/CatLogo-RoundedCorners-320x160.png' alt='' width='200' style='float: right;'/>
        </td>
    </tr>
    <tr>
        <td colspan='6' markdown='1' style='padding-left: 0; padding-right: 0; padding-top: 15px; padding-bottom: 0; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>

|&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[CAT.LOCALIZATIONS](../../README.md)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Localizations Assembly](index.md 'index') >> [Cat\.Localizations Namespace](Cat.Localizations.md 'Cat\.Localizations') >> [NoLocalizationCatLocalizer Class](NoLocalizationCatLocalizer.md 'Cat\.Localizations\.NoLocalizationCatLocalizer')

## NoLocalizationCatLocalizer\.this\[string, object\[\]\] Property

Gets the localized string for the given key, with placeholders filled in from the given arguments\.

```csharp
public string this[string key, params object[] arguments] { get; }
```
#### Parameters

<a name='Cat.Localizations.NoLocalizationCatLocalizer.this[string,object[]].key'></a>

`key` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The key to look up\. Its localized value can contain placeholders, filled in order by [arguments](NoLocalizationCatLocalizer.Item.IHK969183C3VM6YLYNFZK3OF9.md#Cat.Localizations.NoLocalizationCatLocalizer.this[string,object[]].arguments 'Cat\.Localizations\.NoLocalizationCatLocalizer\.this\[string, object\[\]\]\.arguments')\.

<a name='Cat.Localizations.NoLocalizationCatLocalizer.this[string,object[]].arguments'></a>

`arguments` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The values to substitute into the localized string's placeholders, in order\.

Implements [this\[string, object\[\]\]](../../../Cat.Localizations/namespaces/Cat.Localizations.Abstractions/ICatLocalizer.Item.SP0BGHDYQU87JBN8QJGTH1HL2.md 'Cat\.Localizations\.Abstractions\.ICatLocalizer\.Item\(System\.String,System\.Object\[\]\)')

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')