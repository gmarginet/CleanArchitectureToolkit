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
  
##### >> [Cat\.Localizations\.EFCore Assembly](index.md 'index') >> [Cat\.Localizations\.EFCore Namespace](Cat.Localizations.EFCore.md 'Cat\.Localizations\.EFCore') >> [CatTranslator&lt;TDbContext&gt; Class](CatTranslator_TDbContext_.md 'Cat\.Localizations\.EFCore\.CatTranslator\<TDbContext\>')

## CatTranslator\(TDbContext, ILogger\<CatTranslator\<TDbContext\>\>\) Constructor

Creates the translator\.

```csharp
public CatTranslator(TDbContext dbContext, Microsoft.Extensions.Logging.ILogger<Cat.Localizations.EFCore.CatTranslator<TDbContext>> logger);
```
#### Parameters

<a name='Cat.Localizations.EFCore.CatTranslator_TDbContext_.CatTranslator(TDbContext,Microsoft.Extensions.Logging.ILogger_Cat.Localizations.EFCore.CatTranslator_TDbContext__).dbContext'></a>

`dbContext` [TDbContext](CatTranslator_TDbContext_.md#Cat.Localizations.EFCore.CatTranslator_TDbContext_.TDbContext 'Cat\.Localizations\.EFCore\.CatTranslator\<TDbContext\>\.TDbContext')

The context that holds the translation table\.

<a name='Cat.Localizations.EFCore.CatTranslator_TDbContext_.CatTranslator(TDbContext,Microsoft.Extensions.Logging.ILogger_Cat.Localizations.EFCore.CatTranslator_TDbContext__).logger'></a>

`logger` [Microsoft\.Extensions\.Logging\.ILogger&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')[Cat\.Localizations\.EFCore\.CatTranslator&lt;](CatTranslator_TDbContext_.md 'Cat\.Localizations\.EFCore\.CatTranslator\<TDbContext\>')[TDbContext](CatTranslator_TDbContext_.md#Cat.Localizations.EFCore.CatTranslator_TDbContext_.TDbContext 'Cat\.Localizations\.EFCore\.CatTranslator\<TDbContext\>\.TDbContext')[&gt;](CatTranslator_TDbContext_.md 'Cat\.Localizations\.EFCore\.CatTranslator\<TDbContext\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')

Writes a debug line for a missing translation\.