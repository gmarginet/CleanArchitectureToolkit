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
  
##### >> [Cat\.Localizations Assembly](index.md 'index') >> [Cat\.Localizations Namespace](Cat.Localizations.md 'Cat\.Localizations')

## NoLocalizationCatLocalizer Class

Default [ICatLocalizer](../../../Cat.Localizations/namespaces/Cat.Localizations.Abstractions/ICatLocalizer.md 'Cat\.Localizations\.Abstractions\.ICatLocalizer') implementation that performs no localization\. It returns the key as\-is,
only filling in placeholders for the indexer that takes arguments\.

```csharp
internal class NoLocalizationCatLocalizer : Cat.Localizations.Abstractions.ICatLocalizer
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → NoLocalizationCatLocalizer

Implements [ICatLocalizer](../../../Cat.Localizations/namespaces/Cat.Localizations.Abstractions/ICatLocalizer.md 'Cat\.Localizations\.Abstractions\.ICatLocalizer')

| Properties | |
| :--- | :--- |
| [this\[string, object\[\]\]](NoLocalizationCatLocalizer.Item.IHK969183C3VM6YLYNFZK3OF9.md 'Cat\.Localizations\.NoLocalizationCatLocalizer\.this\[string, object\[\]\]') | Gets the localized string for the given key, with placeholders filled in from the given arguments\. |
| [this\[string\]](NoLocalizationCatLocalizer.Item.ZCPDRAO0ITIIKJTVX4KRYDR6B.md 'Cat\.Localizations\.NoLocalizationCatLocalizer\.this\[string\]') | Gets the localized string for the given key\. |
