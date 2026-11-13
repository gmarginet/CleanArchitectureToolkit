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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.EFCORE](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.EFCore\.Queries Assembly](index.md 'index') >> [Cat\.EFCore\.Queries Namespace](Cat.EFCore.Queries.md 'Cat\.EFCore\.Queries') >> [CatEfQueryHandlerBase&lt;TDbContext,TQuery,TQueryResult&gt; Class](CatEfQueryHandlerBase_TDbContext,TQuery,TQueryResult_.md 'Cat\.EFCore\.Queries\.CatEfQueryHandlerBase\<TDbContext,TQuery,TQueryResult\>')

## CatEfQueryHandlerBase\<TDbContext,TQuery,TQueryResult\>\.TrackChanges Property

Tells whether [Set&lt;TEntity&gt;\(\)](CatEfQueryHandlerBase_TDbContext,TQuery,TQueryResult_.Set_TEntity_().md 'Cat\.EFCore\.Queries\.CatEfQueryHandlerBase\<TDbContext,TQuery,TQueryResult\>\.Set\<TEntity\>\(\)') tracks the entities it returns\. The default is `false`\.
Override it in a handler that needs tracking\.

```csharp
protected virtual bool TrackChanges { protected get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')