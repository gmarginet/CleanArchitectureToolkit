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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.RESPONSES](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Responses Assembly](index.md 'index') >> [Cat\.Responses Namespace](Cat.Responses.md 'Cat\.Responses') >> [CatResponse Class](CatResponse.md 'Cat\.Responses\.CatResponse') >> [PagedList Class](CatResponse.PagedList.md 'Cat\.Responses\.CatResponse\.PagedList')

## CatResponse\.PagedList\.Created Method

| Overloads | |
| :--- | :--- |
| [Created&lt;TResponse&gt;\(ICatPagedList&lt;TResponse&gt;\)](CatResponse.PagedList.Created.md#Cat.Responses.CatResponse.PagedList.Created_TResponse_(Cat.Responses.Abstractions.ICatPagedList_TResponse_) 'Cat\.Responses\.CatResponse\.PagedList\.Created\<TResponse\>\(Cat\.Responses\.Abstractions\.ICatPagedList\<TResponse\>\)') | Creates a succeeded response with the [Created](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.Created.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Created') outcome, carrying the given page\. |
| [Created&lt;TResponse&gt;\(IReadOnlyList&lt;TResponse&gt;, int, int, int\)](CatResponse.PagedList.Created.md#Cat.Responses.CatResponse.PagedList.Created_TResponse_(System.Collections.Generic.IReadOnlyList_TResponse_,int,int,int) 'Cat\.Responses\.CatResponse\.PagedList\.Created\<TResponse\>\(System\.Collections\.Generic\.IReadOnlyList\<TResponse\>, int, int, int\)') | Creates a succeeded response with the [Created](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.Created.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Created') outcome, carrying a page built from the given values\. |

<a name='Cat.Responses.CatResponse.PagedList.Created_TResponse_(Cat.Responses.Abstractions.ICatPagedList_TResponse_)'></a>

## CatResponse\.PagedList\.Created\<TResponse\>\(ICatPagedList\<TResponse\>\) Method

Creates a succeeded response with the [Created](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.Created.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Created') outcome, carrying the given page\.

```csharp
public static Cat.Responses.Abstractions.ICatResponse<Cat.Responses.Abstractions.ICatPagedList<TResponse>> Created<TResponse>(Cat.Responses.Abstractions.ICatPagedList<TResponse> pagedList);
```
#### Type parameters

<a name='Cat.Responses.CatResponse.PagedList.Created_TResponse_(Cat.Responses.Abstractions.ICatPagedList_TResponse_).TResponse'></a>

`TResponse`

The type of the items in the page\.
#### Parameters

<a name='Cat.Responses.CatResponse.PagedList.Created_TResponse_(Cat.Responses.Abstractions.ICatPagedList_TResponse_).pagedList'></a>

`pagedList` [Cat\.Responses\.Abstractions\.ICatPagedList&lt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatPagedList_TList_.md 'Cat\.Responses\.Abstractions\.ICatPagedList\`1')[TResponse](CatResponse.PagedList.Created.md#Cat.Responses.CatResponse.PagedList.Created_TResponse_(Cat.Responses.Abstractions.ICatPagedList_TResponse_).TResponse 'Cat\.Responses\.CatResponse\.PagedList\.Created\<TResponse\>\(Cat\.Responses\.Abstractions\.ICatPagedList\<TResponse\>\)\.TResponse')[&gt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatPagedList_TList_.md 'Cat\.Responses\.Abstractions\.ICatPagedList\`1')

The page the response carries\.

#### Returns
[Cat\.Responses\.Abstractions\.ICatResponse&lt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[Cat\.Responses\.Abstractions\.ICatPagedList&lt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatPagedList_TList_.md 'Cat\.Responses\.Abstractions\.ICatPagedList\`1')[TResponse](CatResponse.PagedList.Created.md#Cat.Responses.CatResponse.PagedList.Created_TResponse_(Cat.Responses.Abstractions.ICatPagedList_TResponse_).TResponse 'Cat\.Responses\.CatResponse\.PagedList\.Created\<TResponse\>\(Cat\.Responses\.Abstractions\.ICatPagedList\<TResponse\>\)\.TResponse')[&gt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatPagedList_TList_.md 'Cat\.Responses\.Abstractions\.ICatPagedList\`1')[&gt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')

<a name='Cat.Responses.CatResponse.PagedList.Created_TResponse_(System.Collections.Generic.IReadOnlyList_TResponse_,int,int,int)'></a>

## CatResponse\.PagedList\.Created\<TResponse\>\(IReadOnlyList\<TResponse\>, int, int, int\) Method

Creates a succeeded response with the [Created](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.Created.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Created') outcome, carrying a page built from the given values\.

```csharp
public static Cat.Responses.Abstractions.ICatResponse<Cat.Responses.Abstractions.ICatPagedList<TResponse>> Created<TResponse>(System.Collections.Generic.IReadOnlyList<TResponse> list, int pageNumber, int pageSize, int totalItemCount);
```
#### Type parameters

<a name='Cat.Responses.CatResponse.PagedList.Created_TResponse_(System.Collections.Generic.IReadOnlyList_TResponse_,int,int,int).TResponse'></a>

`TResponse`

The type of the items in the page\.
#### Parameters

<a name='Cat.Responses.CatResponse.PagedList.Created_TResponse_(System.Collections.Generic.IReadOnlyList_TResponse_,int,int,int).list'></a>

`list` [System\.Collections\.Generic\.IReadOnlyList&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1 'System\.Collections\.Generic\.IReadOnlyList\`1')[TResponse](CatResponse.PagedList.Created.md#Cat.Responses.CatResponse.PagedList.Created_TResponse_(System.Collections.Generic.IReadOnlyList_TResponse_,int,int,int).TResponse 'Cat\.Responses\.CatResponse\.PagedList\.Created\<TResponse\>\(System\.Collections\.Generic\.IReadOnlyList\<TResponse\>, int, int, int\)\.TResponse')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1 'System\.Collections\.Generic\.IReadOnlyList\`1')

The items on this page\.

<a name='Cat.Responses.CatResponse.PagedList.Created_TResponse_(System.Collections.Generic.IReadOnlyList_TResponse_,int,int,int).pageNumber'></a>

`pageNumber` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of this page\. The first page is 1\.

<a name='Cat.Responses.CatResponse.PagedList.Created_TResponse_(System.Collections.Generic.IReadOnlyList_TResponse_,int,int,int).pageSize'></a>

`pageSize` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The maximum number of items on a page\.

<a name='Cat.Responses.CatResponse.PagedList.Created_TResponse_(System.Collections.Generic.IReadOnlyList_TResponse_,int,int,int).totalItemCount'></a>

`totalItemCount` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of items across all pages\.

#### Returns
[Cat\.Responses\.Abstractions\.ICatResponse&lt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[Cat\.Responses\.Abstractions\.ICatPagedList&lt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatPagedList_TList_.md 'Cat\.Responses\.Abstractions\.ICatPagedList\`1')[TResponse](CatResponse.PagedList.Created.md#Cat.Responses.CatResponse.PagedList.Created_TResponse_(System.Collections.Generic.IReadOnlyList_TResponse_,int,int,int).TResponse 'Cat\.Responses\.CatResponse\.PagedList\.Created\<TResponse\>\(System\.Collections\.Generic\.IReadOnlyList\<TResponse\>, int, int, int\)\.TResponse')[&gt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatPagedList_TList_.md 'Cat\.Responses\.Abstractions\.ICatPagedList\`1')[&gt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
Thrown when [list](CatResponse.PagedList.Created.md#Cat.Responses.CatResponse.PagedList.Created_TResponse_(System.Collections.Generic.IReadOnlyList_TResponse_,int,int,int).list 'Cat\.Responses\.CatResponse\.PagedList\.Created\<TResponse\>\(System\.Collections\.Generic\.IReadOnlyList\<TResponse\>, int, int, int\)\.list') is `null`\.

[System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException')  
Thrown when [pageNumber](CatResponse.PagedList.Created.md#Cat.Responses.CatResponse.PagedList.Created_TResponse_(System.Collections.Generic.IReadOnlyList_TResponse_,int,int,int).pageNumber 'Cat\.Responses\.CatResponse\.PagedList\.Created\<TResponse\>\(System\.Collections\.Generic\.IReadOnlyList\<TResponse\>, int, int, int\)\.pageNumber') or [pageSize](CatResponse.PagedList.Created.md#Cat.Responses.CatResponse.PagedList.Created_TResponse_(System.Collections.Generic.IReadOnlyList_TResponse_,int,int,int).pageSize 'Cat\.Responses\.CatResponse\.PagedList\.Created\<TResponse\>\(System\.Collections\.Generic\.IReadOnlyList\<TResponse\>, int, int, int\)\.pageSize') is less than 1, or [totalItemCount](CatResponse.PagedList.Created.md#Cat.Responses.CatResponse.PagedList.Created_TResponse_(System.Collections.Generic.IReadOnlyList_TResponse_,int,int,int).totalItemCount 'Cat\.Responses\.CatResponse\.PagedList\.Created\<TResponse\>\(System\.Collections\.Generic\.IReadOnlyList\<TResponse\>, int, int, int\)\.totalItemCount') is negative\.