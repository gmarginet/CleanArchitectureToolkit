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
  
##### >> [Cat\.EFCore\.Queries Assembly](index.md 'index') >> [Cat\.EFCore\.Queries Namespace](Cat.EFCore.Queries.md 'Cat\.EFCore\.Queries')

## QueryablePagingExtensions Class

Paging for Entity Framework Core queries\.

```csharp
public static class QueryablePagingExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → QueryablePagingExtensions

| Methods | |
| :--- | :--- |
| [ToPagedListAsync&lt;T&gt;\(this IQueryable&lt;T&gt;, int, int, CancellationToken\)](QueryablePagingExtensions.ToPagedListAsync.PB9F2UE6DIXCMNSMBDDW2HF92.md 'Cat\.EFCore\.Queries\.QueryablePagingExtensions\.ToPagedListAsync\<T\>\(this System\.Linq\.IQueryable\<T\>, int, int, System\.Threading\.CancellationToken\)') | Counts all items, then reads one page of them\. Sort the query before you call this, otherwise the pages have no stable order\. |
