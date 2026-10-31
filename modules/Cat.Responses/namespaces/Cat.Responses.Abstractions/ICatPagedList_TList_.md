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
  
##### >> [Cat\.Responses\.Abstractions Assembly](index.md 'index') >> [Cat\.Responses\.Abstractions Namespace](Cat.Responses.Abstractions.md 'Cat\.Responses\.Abstractions')

## ICatPagedList\<TList\> Interface

One page of a larger list, with the numbers needed to page through the rest\.

```csharp
public interface ICatPagedList<TList>
```
#### Type parameters

<a name='Cat.Responses.Abstractions.ICatPagedList_TList_.TList'></a>

`TList`

The type of the items in the page\.

| Properties | |
| :--- | :--- |
| [List](ICatPagedList_TList_.List.md 'Cat\.Responses\.Abstractions\.ICatPagedList\<TList\>\.List') | The items on this page\. |
| [PageNumber](ICatPagedList_TList_.PageNumber.md 'Cat\.Responses\.Abstractions\.ICatPagedList\<TList\>\.PageNumber') | The number of this page\. The first page is 1\. |
| [PageSize](ICatPagedList_TList_.PageSize.md 'Cat\.Responses\.Abstractions\.ICatPagedList\<TList\>\.PageSize') | The maximum number of items on a page\. |
| [TotalItemCount](ICatPagedList_TList_.TotalItemCount.md 'Cat\.Responses\.Abstractions\.ICatPagedList\<TList\>\.TotalItemCount') | The number of items across all pages\. |
| [TotalPages](ICatPagedList_TList_.TotalPages.md 'Cat\.Responses\.Abstractions\.ICatPagedList\<TList\>\.TotalPages') | The number of pages needed to hold all items\. |
