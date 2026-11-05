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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.RESPONSES](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Responses Assembly](index.md 'index') >> [Cat\.Responses Namespace](Cat.Responses.md 'Cat\.Responses') >> [CatPagedList&lt;TList&gt; Class](CatPagedList_TList_.md 'Cat\.Responses\.CatPagedList\<TList\>')

## CatPagedList\(IReadOnlyList\<TList\>, int, int, int\) Constructor

Creates a page from the given values\.

```csharp
public CatPagedList(System.Collections.Generic.IReadOnlyList<TList> list, int pageNumber, int pageSize, int totalItemCount);
```
#### Parameters

<a name='Cat.Responses.CatPagedList_TList_.CatPagedList(System.Collections.Generic.IReadOnlyList_TList_,int,int,int).list'></a>

`list` [System\.Collections\.Generic\.IReadOnlyList&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1 'System\.Collections\.Generic\.IReadOnlyList\`1')[TList](CatPagedList_TList_.md#Cat.Responses.CatPagedList_TList_.TList 'Cat\.Responses\.CatPagedList\<TList\>\.TList')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1 'System\.Collections\.Generic\.IReadOnlyList\`1')

The items on this page\.

<a name='Cat.Responses.CatPagedList_TList_.CatPagedList(System.Collections.Generic.IReadOnlyList_TList_,int,int,int).pageNumber'></a>

`pageNumber` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of this page\. The first page is 1\.

<a name='Cat.Responses.CatPagedList_TList_.CatPagedList(System.Collections.Generic.IReadOnlyList_TList_,int,int,int).pageSize'></a>

`pageSize` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The maximum number of items on a page\.

<a name='Cat.Responses.CatPagedList_TList_.CatPagedList(System.Collections.Generic.IReadOnlyList_TList_,int,int,int).totalItemCount'></a>

`totalItemCount` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of items across all pages\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
Thrown when [list](CatPagedList_TList_..ctor.ZMOZAKU4GWPKLFVMA9I019BJB.md#Cat.Responses.CatPagedList_TList_.CatPagedList(System.Collections.Generic.IReadOnlyList_TList_,int,int,int).list 'Cat\.Responses\.CatPagedList\<TList\>\.CatPagedList\(System\.Collections\.Generic\.IReadOnlyList\<TList\>, int, int, int\)\.list') is `null`\.

[System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException')  
Thrown when [pageNumber](CatPagedList_TList_..ctor.ZMOZAKU4GWPKLFVMA9I019BJB.md#Cat.Responses.CatPagedList_TList_.CatPagedList(System.Collections.Generic.IReadOnlyList_TList_,int,int,int).pageNumber 'Cat\.Responses\.CatPagedList\<TList\>\.CatPagedList\(System\.Collections\.Generic\.IReadOnlyList\<TList\>, int, int, int\)\.pageNumber') or [pageSize](CatPagedList_TList_..ctor.ZMOZAKU4GWPKLFVMA9I019BJB.md#Cat.Responses.CatPagedList_TList_.CatPagedList(System.Collections.Generic.IReadOnlyList_TList_,int,int,int).pageSize 'Cat\.Responses\.CatPagedList\<TList\>\.CatPagedList\(System\.Collections\.Generic\.IReadOnlyList\<TList\>, int, int, int\)\.pageSize') is less than 1, or [totalItemCount](CatPagedList_TList_..ctor.ZMOZAKU4GWPKLFVMA9I019BJB.md#Cat.Responses.CatPagedList_TList_.CatPagedList(System.Collections.Generic.IReadOnlyList_TList_,int,int,int).totalItemCount 'Cat\.Responses\.CatPagedList\<TList\>\.CatPagedList\(System\.Collections\.Generic\.IReadOnlyList\<TList\>, int, int, int\)\.totalItemCount') is negative\.