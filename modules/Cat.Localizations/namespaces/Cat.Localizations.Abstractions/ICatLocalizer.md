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
  
##### >> [Cat\.Localizations\.Abstractions Assembly](index.md 'index') >> [Cat\.Localizations\.Abstractions Namespace](Cat.Localizations.Abstractions.md 'Cat\.Localizations\.Abstractions')

## ICatLocalizer Interface

Looks up localized strings by key\.

```csharp
public interface ICatLocalizer
```

| Properties | |
| :--- | :--- |
| [this\[string, object\[\]\]](ICatLocalizer.Item.SP0BGHDYQU87JBN8QJGTH1HL2.md 'Cat\.Localizations\.Abstractions\.ICatLocalizer\.this\[string, object\[\]\]') | Gets the localized string for the given key, with placeholders filled in from the given arguments\. |
| [this\[string\]](ICatLocalizer.Item.Q0AA7MM5YYX5RXC0Q87LKPW13.md 'Cat\.Localizations\.Abstractions\.ICatLocalizer\.this\[string\]') | Gets the localized string for the given key\. |
