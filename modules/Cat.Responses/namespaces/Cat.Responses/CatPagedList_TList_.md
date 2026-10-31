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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.RESPONSES](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Responses Assembly](index.md 'index') >> [Cat\.Responses Namespace](Cat.Responses.md 'Cat\.Responses')

## CatPagedList\<TList\> Class

The default [ICatPagedList&lt;TList&gt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatPagedList_TList_.md 'Cat\.Responses\.Abstractions\.ICatPagedList\`1') implementation\. Every value is checked when it is set,
and two pages are equal when their numbers and items are equal\.

```csharp
public record CatPagedList<TList> : Cat.Responses.Abstractions.ICatPagedList<TList>, System.IEquatable<Cat.Responses.CatPagedList<TList>>
```
#### Type parameters

<a name='Cat.Responses.CatPagedList_TList_.TList'></a>

`TList`

The type of the items in the page\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatPagedList\<TList\>

Implements [Cat\.Responses\.Abstractions\.ICatPagedList&lt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatPagedList_TList_.md 'Cat\.Responses\.Abstractions\.ICatPagedList\`1')[TList](CatPagedList_TList_.md#Cat.Responses.CatPagedList_TList_.TList 'Cat\.Responses\.CatPagedList\<TList\>\.TList')[&gt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatPagedList_TList_.md 'Cat\.Responses\.Abstractions\.ICatPagedList\`1'), [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[Cat\.Responses\.CatPagedList&lt;](CatPagedList_TList_.md 'Cat\.Responses\.CatPagedList\<TList\>')[TList](CatPagedList_TList_.md#Cat.Responses.CatPagedList_TList_.TList 'Cat\.Responses\.CatPagedList\<TList\>\.TList')[&gt;](CatPagedList_TList_.md 'Cat\.Responses\.CatPagedList\<TList\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [CatPagedList\(IReadOnlyList&lt;TList&gt;, int, int, int\)](CatPagedList_TList_..ctor.ZMOZAKU4GWPKLFVMA9I019BJB.md 'Cat\.Responses\.CatPagedList\<TList\>\.CatPagedList\(System\.Collections\.Generic\.IReadOnlyList\<TList\>, int, int, int\)') | Creates a page from the given values\. |

| Properties | |
| :--- | :--- |
| [List](CatPagedList_TList_.List.md 'Cat\.Responses\.CatPagedList\<TList\>\.List') | The items on this page\. |
| [PageNumber](CatPagedList_TList_.PageNumber.md 'Cat\.Responses\.CatPagedList\<TList\>\.PageNumber') | The number of this page\. The first page is 1\. |
| [PageSize](CatPagedList_TList_.PageSize.md 'Cat\.Responses\.CatPagedList\<TList\>\.PageSize') | The maximum number of items on a page\. |
| [TotalItemCount](CatPagedList_TList_.TotalItemCount.md 'Cat\.Responses\.CatPagedList\<TList\>\.TotalItemCount') | The number of items across all pages\. |
| [TotalPages](CatPagedList_TList_.TotalPages.md 'Cat\.Responses\.CatPagedList\<TList\>\.TotalPages') | The number of pages needed to hold all items\. |

| Methods | |
| :--- | :--- |
| [Equals\(CatPagedList&lt;TList&gt;\)](CatPagedList_TList_.Equals.DI5H5O3Z5RWC6SN3CGJO0LY38.md 'Cat\.Responses\.CatPagedList\<TList\>\.Equals\(Cat\.Responses\.CatPagedList\<TList\>\)') | Checks whether another page has the same numbers and the same items in the same order\. |
| [GetHashCode\(\)](CatPagedList_TList_.GetHashCode().md 'Cat\.Responses\.CatPagedList\<TList\>\.GetHashCode\(\)') | Builds a hash code from the numbers and every item on the page\. |
