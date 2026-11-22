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
  
##### >> [Cat\.Localizations\.Abstractions Assembly](index.md 'index') >> [Cat\.Localizations\.Abstractions Namespace](Cat.Localizations.Abstractions.md 'Cat\.Localizations\.Abstractions')

## ICatTranslator Interface

Reads and saves the translations of reference data\. Reads use `CultureInfo.CurrentUICulture`,
the culture that `IStringLocalizer` reads too\. A request, or a message of `Cat.EventProcessor`, sets it\.
A text that has no translation comes back as the default text of the entity\.

```csharp
public interface ICatTranslator
```

| Methods | |
| :--- | :--- |
| [GetTextAsync&lt;TEntity&gt;\(Guid, string, string, CancellationToken\)](ICatTranslator.GetTextAsync.SPCEAAE1M52ET3REH7TES0PMD.md 'Cat\.Localizations\.Abstractions\.ICatTranslator\.GetTextAsync\<TEntity\>\(System\.Guid, string, string, System\.Threading\.CancellationToken\)') | Gets one text in the current culture\. |
| [GetTextsAsync&lt;TEntity&gt;\(IReadOnlyDictionary&lt;Guid,string&gt;, string, CancellationToken\)](ICatTranslator.GetTextsAsync.YMOEAHKBPO4DG6INI5MPRD4S8.md 'Cat\.Localizations\.Abstractions\.ICatTranslator\.GetTextsAsync\<TEntity\>\(System\.Collections\.Generic\.IReadOnlyDictionary\<System\.Guid,string\>, string, System\.Threading\.CancellationToken\)') | Gets the same field of many entities in the current culture, with one database call\. |
| [GetTranslationsAsync&lt;TEntity&gt;\(Guid, string, CancellationToken\)](ICatTranslator.GetTranslationsAsync.5F9LPJY9EH27GODR4PMN6R2J8.md 'Cat\.Localizations\.Abstractions\.ICatTranslator\.GetTranslationsAsync\<TEntity\>\(System\.Guid, string, System\.Threading\.CancellationToken\)') | Gets every translation of one field of one entity, for an admin screen\. |
| [SetTextAsync&lt;TEntity&gt;\(Guid, string, string, string, CancellationToken\)](ICatTranslator.SetTextAsync.CE8LOSLXTYE2AUJUNSZNC903C.md 'Cat\.Localizations\.Abstractions\.ICatTranslator\.SetTextAsync\<TEntity\>\(System\.Guid, string, string, string, System\.Threading\.CancellationToken\)') | Adds, changes or removes the translation of one field in one culture\. It saves nothing, so the change goes into the same `SaveChanges` as the change of the entity\. |
