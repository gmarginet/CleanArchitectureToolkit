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

## CatTranslator\<TDbContext\>\.GetTextsAsync\<TEntity\>\(IReadOnlyDictionary\<Guid,string\>, string, CancellationToken\) Method

Gets the same field of many entities in the current culture, with one database call\.

```csharp
public System.Threading.Tasks.Task<System.Collections.Generic.IReadOnlyDictionary<System.Guid,string>> GetTextsAsync<TEntity>(System.Collections.Generic.IReadOnlyDictionary<System.Guid,string> defaultTexts, string field, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken))
    where TEntity : Cat.Localizations.Abstractions.ICatTranslatable;
```
#### Type parameters

<a name='Cat.Localizations.EFCore.CatTranslator_TDbContext_.GetTextsAsync_TEntity_(System.Collections.Generic.IReadOnlyDictionary_System.Guid,string_,string,System.Threading.CancellationToken).TEntity'></a>

`TEntity`

The translatable entity type\.
#### Parameters

<a name='Cat.Localizations.EFCore.CatTranslator_TDbContext_.GetTextsAsync_TEntity_(System.Collections.Generic.IReadOnlyDictionary_System.Guid,string_,string,System.Threading.CancellationToken).defaultTexts'></a>

`defaultTexts` [System\.Collections\.Generic\.IReadOnlyDictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlydictionary-2 'System\.Collections\.Generic\.IReadOnlyDictionary\`2')[System\.Guid](https://learn.microsoft.com/en-us/dotnet/api/system.guid 'System\.Guid')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlydictionary-2 'System\.Collections\.Generic\.IReadOnlyDictionary\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlydictionary-2 'System\.Collections\.Generic\.IReadOnlyDictionary\`2')

The default text per entity id\.

<a name='Cat.Localizations.EFCore.CatTranslator_TDbContext_.GetTextsAsync_TEntity_(System.Collections.Generic.IReadOnlyDictionary_System.Guid,string_,string,System.Threading.CancellationToken).field'></a>

`field` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the field, such as `Name`\.

<a name='Cat.Localizations.EFCore.CatTranslator_TDbContext_.GetTextsAsync_TEntity_(System.Collections.Generic.IReadOnlyDictionary_System.Guid,string_,string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Cancels the read\.

Implements [GetTextsAsync&lt;TEntity&gt;\(IReadOnlyDictionary&lt;Guid,string&gt;, string, CancellationToken\)](../../../Cat.Localizations/namespaces/Cat.Localizations.Abstractions/ICatTranslator.GetTextsAsync.YMOEAHKBPO4DG6INI5MPRD4S8.md 'Cat\.Localizations\.Abstractions\.ICatTranslator\.GetTextsAsync\`\`1\(System\.Collections\.Generic\.IReadOnlyDictionary\{System\.Guid,System\.String\},System\.String,System\.Threading\.CancellationToken\)')

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Collections\.Generic\.IReadOnlyDictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlydictionary-2 'System\.Collections\.Generic\.IReadOnlyDictionary\`2')[System\.Guid](https://learn.microsoft.com/en-us/dotnet/api/system.guid 'System\.Guid')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlydictionary-2 'System\.Collections\.Generic\.IReadOnlyDictionary\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlydictionary-2 'System\.Collections\.Generic\.IReadOnlyDictionary\`2')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The same ids, each with the translation or its default text\.