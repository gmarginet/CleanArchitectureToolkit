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
  
##### >> [Cat\.Localizations\.EFCore Assembly](index.md 'index') >> [Cat\.Localizations\.EFCore Namespace](Cat.Localizations.EFCore.md 'Cat\.Localizations\.EFCore')

## CatTranslator\<TDbContext\> Class

Default [ICatTranslator](../../../Cat.Localizations/namespaces/Cat.Localizations.Abstractions/ICatTranslator.md 'Cat\.Localizations\.Abstractions\.ICatTranslator') on a `DbContext` that maps [CatTranslation](../../../Cat.Localizations/namespaces/Cat.Localizations.Abstractions/CatTranslation.md 'Cat\.Localizations\.Abstractions\.CatTranslation')\.

```csharp
internal sealed class CatTranslator<TDbContext> : Cat.Localizations.Abstractions.ICatTranslator
    where TDbContext : Microsoft.EntityFrameworkCore.DbContext
```
#### Type parameters

<a name='Cat.Localizations.EFCore.CatTranslator_TDbContext_.TDbContext'></a>

`TDbContext`

The `DbContext` with the translation table\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatTranslator\<TDbContext\>

Implements [ICatTranslator](../../../Cat.Localizations/namespaces/Cat.Localizations.Abstractions/ICatTranslator.md 'Cat\.Localizations\.Abstractions\.ICatTranslator')

| Constructors | |
| :--- | :--- |
| [CatTranslator\(TDbContext, ILogger&lt;CatTranslator&lt;TDbContext&gt;&gt;\)](CatTranslator_TDbContext_..ctor.PKFXB5FQ6MKTD5P0ZDYAZPRW9.md 'Cat\.Localizations\.EFCore\.CatTranslator\<TDbContext\>\.CatTranslator\(TDbContext, Microsoft\.Extensions\.Logging\.ILogger\<Cat\.Localizations\.EFCore\.CatTranslator\<TDbContext\>\>\)') | Creates the translator\. |

| Fields | |
| :--- | :--- |
| [\_dbContext](CatTranslator_TDbContext_._dbContext.md 'Cat\.Localizations\.EFCore\.CatTranslator\<TDbContext\>\.\_dbContext') | |
| [\_logger](CatTranslator_TDbContext_._logger.md 'Cat\.Localizations\.EFCore\.CatTranslator\<TDbContext\>\.\_logger') | |

| Methods | |
| :--- | :--- |
| [CultureChain\(CultureInfo\)](CatTranslator_TDbContext_.CultureChain.372UXXMANJWXG3Y6JMQM0HBL3.md 'Cat\.Localizations\.EFCore\.CatTranslator\<TDbContext\>\.CultureChain\(System\.Globalization\.CultureInfo\)') | Lists the culture and its parents, most specific first, without the invariant culture\. `nl-BE` gives `nl-BE` and `nl`\. |
| [GetTextAsync&lt;TEntity&gt;\(Guid, string, string, CancellationToken\)](CatTranslator_TDbContext_.GetTextAsync.FJY24BV8JYMTJ54HHH2J6QZT9.md 'Cat\.Localizations\.EFCore\.CatTranslator\<TDbContext\>\.GetTextAsync\<TEntity\>\(System\.Guid, string, string, System\.Threading\.CancellationToken\)') | Gets one text in the current culture\. |
| [GetTextsAsync&lt;TEntity&gt;\(IReadOnlyDictionary&lt;Guid,string&gt;, string, CancellationToken\)](CatTranslator_TDbContext_.GetTextsAsync.7RJM3DQRO5LRBU1FOXDUR4678.md 'Cat\.Localizations\.EFCore\.CatTranslator\<TDbContext\>\.GetTextsAsync\<TEntity\>\(System\.Collections\.Generic\.IReadOnlyDictionary\<System\.Guid,string\>, string, System\.Threading\.CancellationToken\)') | Gets the same field of many entities in the current culture, with one database call\. |
| [GetTranslationsAsync&lt;TEntity&gt;\(Guid, string, CancellationToken\)](CatTranslator_TDbContext_.GetTranslationsAsync.I03VLI5PMMIU0OLGMUUYLEGW3.md 'Cat\.Localizations\.EFCore\.CatTranslator\<TDbContext\>\.GetTranslationsAsync\<TEntity\>\(System\.Guid, string, System\.Threading\.CancellationToken\)') | Gets every translation of one field of one entity, for an admin screen\. |
| [SetTextAsync&lt;TEntity&gt;\(Guid, string, string, string, CancellationToken\)](CatTranslator_TDbContext_.SetTextAsync.EWDMR8BU1S8C7564SUKNJ6T74.md 'Cat\.Localizations\.EFCore\.CatTranslator\<TDbContext\>\.SetTextAsync\<TEntity\>\(System\.Guid, string, string, string, System\.Threading\.CancellationToken\)') | Adds, changes or removes the translation of one field in one culture\. It saves nothing, so the change goes into the same `SaveChanges` as the change of the entity\. |
