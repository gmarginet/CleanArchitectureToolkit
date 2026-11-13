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
  
##### >> [Cat\.EFCore\.Queries Assembly](index.md 'index') >> [Cat\.EFCore\.Queries Namespace](Cat.EFCore.Queries.md 'Cat\.EFCore\.Queries') >> [QueryablePagingExtensions Class](QueryablePagingExtensions.md 'Cat\.EFCore\.Queries\.QueryablePagingExtensions')

## QueryablePagingExtensions\.ToPagedListAsync\<T\>\(this IQueryable\<T\>, int, int, CancellationToken\) Method

Counts all items, then reads one page of them\. Sort the query before you call this,
otherwise the pages have no stable order\.

```csharp
public static System.Threading.Tasks.Task<Cat.Responses.Abstractions.ICatPagedList<T>> ToPagedListAsync<T>(this System.Linq.IQueryable<T> source, int pageNumber, int pageSize, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Type parameters

<a name='Cat.EFCore.Queries.QueryablePagingExtensions.ToPagedListAsync_T_(thisSystem.Linq.IQueryable_T_,int,int,System.Threading.CancellationToken).T'></a>

`T`

The type of the items\.
#### Parameters

<a name='Cat.EFCore.Queries.QueryablePagingExtensions.ToPagedListAsync_T_(thisSystem.Linq.IQueryable_T_,int,int,System.Threading.CancellationToken).source'></a>

`source` [System\.Linq\.IQueryable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.iqueryable-1 'System\.Linq\.IQueryable\`1')[T](QueryablePagingExtensions.ToPagedListAsync.PB9F2UE6DIXCMNSMBDDW2HF92.md#Cat.EFCore.Queries.QueryablePagingExtensions.ToPagedListAsync_T_(thisSystem.Linq.IQueryable_T_,int,int,System.Threading.CancellationToken).T 'Cat\.EFCore\.Queries\.QueryablePagingExtensions\.ToPagedListAsync\<T\>\(this System\.Linq\.IQueryable\<T\>, int, int, System\.Threading\.CancellationToken\)\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.iqueryable-1 'System\.Linq\.IQueryable\`1')

The sorted and filtered query\.

<a name='Cat.EFCore.Queries.QueryablePagingExtensions.ToPagedListAsync_T_(thisSystem.Linq.IQueryable_T_,int,int,System.Threading.CancellationToken).pageNumber'></a>

`pageNumber` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of the page to read\. The first page is 1\.

<a name='Cat.EFCore.Queries.QueryablePagingExtensions.ToPagedListAsync_T_(thisSystem.Linq.IQueryable_T_,int,int,System.Threading.CancellationToken).pageSize'></a>

`pageSize` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The maximum number of items on a page\.

<a name='Cat.EFCore.Queries.QueryablePagingExtensions.ToPagedListAsync_T_(thisSystem.Linq.IQueryable_T_,int,int,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Token to cancel the work\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Cat\.Responses\.Abstractions\.ICatPagedList&lt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatPagedList_TList_.md 'Cat\.Responses\.Abstractions\.ICatPagedList\`1')[T](QueryablePagingExtensions.ToPagedListAsync.PB9F2UE6DIXCMNSMBDDW2HF92.md#Cat.EFCore.Queries.QueryablePagingExtensions.ToPagedListAsync_T_(thisSystem.Linq.IQueryable_T_,int,int,System.Threading.CancellationToken).T 'Cat\.EFCore\.Queries\.QueryablePagingExtensions\.ToPagedListAsync\<T\>\(this System\.Linq\.IQueryable\<T\>, int, int, System\.Threading\.CancellationToken\)\.T')[&gt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatPagedList_TList_.md 'Cat\.Responses\.Abstractions\.ICatPagedList\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The page, with the total item count of the whole query\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
Thrown when [source](QueryablePagingExtensions.ToPagedListAsync.PB9F2UE6DIXCMNSMBDDW2HF92.md#Cat.EFCore.Queries.QueryablePagingExtensions.ToPagedListAsync_T_(thisSystem.Linq.IQueryable_T_,int,int,System.Threading.CancellationToken).source 'Cat\.EFCore\.Queries\.QueryablePagingExtensions\.ToPagedListAsync\<T\>\(this System\.Linq\.IQueryable\<T\>, int, int, System\.Threading\.CancellationToken\)\.source') is `null`\.

[System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException')  
Thrown when [pageNumber](QueryablePagingExtensions.ToPagedListAsync.PB9F2UE6DIXCMNSMBDDW2HF92.md#Cat.EFCore.Queries.QueryablePagingExtensions.ToPagedListAsync_T_(thisSystem.Linq.IQueryable_T_,int,int,System.Threading.CancellationToken).pageNumber 'Cat\.EFCore\.Queries\.QueryablePagingExtensions\.ToPagedListAsync\<T\>\(this System\.Linq\.IQueryable\<T\>, int, int, System\.Threading\.CancellationToken\)\.pageNumber') or [pageSize](QueryablePagingExtensions.ToPagedListAsync.PB9F2UE6DIXCMNSMBDDW2HF92.md#Cat.EFCore.Queries.QueryablePagingExtensions.ToPagedListAsync_T_(thisSystem.Linq.IQueryable_T_,int,int,System.Threading.CancellationToken).pageSize 'Cat\.EFCore\.Queries\.QueryablePagingExtensions\.ToPagedListAsync\<T\>\(this System\.Linq\.IQueryable\<T\>, int, int, System\.Threading\.CancellationToken\)\.pageSize') is less than 1\.