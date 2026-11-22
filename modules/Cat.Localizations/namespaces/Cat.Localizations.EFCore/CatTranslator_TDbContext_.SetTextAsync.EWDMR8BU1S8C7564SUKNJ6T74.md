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

## CatTranslator\<TDbContext\>\.SetTextAsync\<TEntity\>\(Guid, string, string, string, CancellationToken\) Method

Adds, changes or removes the translation of one field in one culture\. It saves nothing,
so the change goes into the same `SaveChanges` as the change of the entity\.

```csharp
public System.Threading.Tasks.Task SetTextAsync<TEntity>(System.Guid id, string field, string culture, string? text, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken))
    where TEntity : Cat.Localizations.Abstractions.ICatTranslatable;
```
#### Type parameters

<a name='Cat.Localizations.EFCore.CatTranslator_TDbContext_.SetTextAsync_TEntity_(System.Guid,string,string,string,System.Threading.CancellationToken).TEntity'></a>

`TEntity`

The translatable entity type\.
#### Parameters

<a name='Cat.Localizations.EFCore.CatTranslator_TDbContext_.SetTextAsync_TEntity_(System.Guid,string,string,string,System.Threading.CancellationToken).id'></a>

`id` [System\.Guid](https://learn.microsoft.com/en-us/dotnet/api/system.guid 'System\.Guid')

The id of the entity\.

<a name='Cat.Localizations.EFCore.CatTranslator_TDbContext_.SetTextAsync_TEntity_(System.Guid,string,string,string,System.Threading.CancellationToken).field'></a>

`field` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the field, such as `Name`\.

<a name='Cat.Localizations.EFCore.CatTranslator_TDbContext_.SetTextAsync_TEntity_(System.Guid,string,string,string,System.Threading.CancellationToken).culture'></a>

`culture` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The culture name, such as `nl`\.

<a name='Cat.Localizations.EFCore.CatTranslator_TDbContext_.SetTextAsync_TEntity_(System.Guid,string,string,string,System.Threading.CancellationToken).text'></a>

`text` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The translation\. Null or white space removes it\.

<a name='Cat.Localizations.EFCore.CatTranslator_TDbContext_.SetTextAsync_TEntity_(System.Guid,string,string,string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Cancels the call\.

Implements [SetTextAsync&lt;TEntity&gt;\(Guid, string, string, string, CancellationToken\)](../../../Cat.Localizations/namespaces/Cat.Localizations.Abstractions/ICatTranslator.SetTextAsync.CE8LOSLXTYE2AUJUNSZNC903C.md 'Cat\.Localizations\.Abstractions\.ICatTranslator\.SetTextAsync\`\`1\(System\.Guid,System\.String,System\.String,System\.String,System\.Threading\.CancellationToken\)')

#### Returns
[System\.Threading\.Tasks\.Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task 'System\.Threading\.Tasks\.Task')  
A task that completes when the change is staged\.