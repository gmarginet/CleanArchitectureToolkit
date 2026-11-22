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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.LOCALIZATIONS](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Localizations\.EFCore Assembly](index.md 'index') >> [Cat\.Localizations\.EFCore\.Extensions Namespace](Cat.Localizations.EFCore.Extensions.md 'Cat\.Localizations\.EFCore\.Extensions')

## ServiceCollectionExtensions Class

Registration helpers for the translator\.

```csharp
public static class ServiceCollectionExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → ServiceCollectionExtensions

| Methods | |
| :--- | :--- |
| [AddCatLocalizations&lt;TDbContext&gt;\(this IServiceCollection\)](ServiceCollectionExtensions.AddCatLocalizations.03JKVG6K9NL3J1KBG57TRLXFB.md 'Cat\.Localizations\.EFCore\.Extensions\.ServiceCollectionExtensions\.AddCatLocalizations\<TDbContext\>\(this Microsoft\.Extensions\.DependencyInjection\.IServiceCollection\)') | Registers [ICatTranslator](../../../Cat.Localizations/namespaces/Cat.Localizations.Abstractions/ICatTranslator.md 'Cat\.Localizations\.Abstractions\.ICatTranslator') on the `DbContext` that maps the translation table with [AddCatTranslations\(this ModelBuilder, string, string\)](ModelBuilderExtensions.AddCatTranslations.NOJJP5WTGTTVOOPM9O64UUIOD.md 'Cat\.Localizations\.EFCore\.ModelBuilderExtensions\.AddCatTranslations\(this Microsoft\.EntityFrameworkCore\.ModelBuilder, string, string\)')\. The translator is scoped, like the `DbContext`\. It writes its debug lines through `ILogger`, so the service needs logging registered, as a web host has\. |
