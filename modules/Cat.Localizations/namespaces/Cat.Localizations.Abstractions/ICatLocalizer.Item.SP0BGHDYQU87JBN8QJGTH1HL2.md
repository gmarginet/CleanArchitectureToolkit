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
            <img src='../../../../resources/logo/CatLogo.svg' alt='' width='200' style='padding: 15px; float: right; background: #121314; border-radius: 10px'/>
        </td>
    </tr>
    <tr>
        <td colspan='6' markdown='1' style='padding-left: 0; padding-right: 0; padding-top: 15px; padding-bottom: 0; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.LOCALIZATIONS](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Localizations\.Abstractions Assembly](index.md 'index') >> [Cat\.Localizations\.Abstractions Namespace](Cat.Localizations.Abstractions.md 'Cat\.Localizations\.Abstractions') >> [ICatLocalizer Interface](ICatLocalizer.md 'Cat\.Localizations\.Abstractions\.ICatLocalizer')

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