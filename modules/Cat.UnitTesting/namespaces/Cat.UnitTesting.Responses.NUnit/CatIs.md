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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.UNITTESTING](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.UnitTesting\.Responses\.NUnit Assembly](index.md 'index') >> [Cat\.UnitTesting\.Responses\.NUnit Namespace](Cat.UnitTesting.Responses.NUnit.md 'Cat\.UnitTesting\.Responses\.NUnit')

## CatIs Class

NUnit constraints for an [ICatResponse](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse')\. Use them with `Assert.That`, for example
`Assert.That(response, CatIs.Succeeded)` or `Assert.That(response, CatIs.FailedWith(CatResponseType.NotFound, "DEM-ORD-1004"))`\.

```csharp
public static class CatIs
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatIs

| Properties | |
| :--- | :--- |
| [Failed](CatIs.Failed.md 'Cat\.UnitTesting\.Responses\.NUnit\.CatIs\.Failed') | The response failed, with any failure type and any errors\. |
| [Succeeded](CatIs.Succeeded.md 'Cat\.UnitTesting\.Responses\.NUnit\.CatIs\.Succeeded') | The response succeeded, with any success type\. |

| Methods | |
| :--- | :--- |
| [FailedWith\(CatResponseType\)](CatIs.FailedWith.md#Cat.UnitTesting.Responses.NUnit.CatIs.FailedWith(Cat.Responses.Abstractions.CatResponseType) 'Cat\.UnitTesting\.Responses\.NUnit\.CatIs\.FailedWith\(Cat\.Responses\.Abstractions\.CatResponseType\)') | The response failed with this type, such as [NotFound](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.NotFound.md 'Cat\.Responses\.Abstractions\.CatResponseType\.NotFound')\. |
| [FailedWith\(CatResponseType, string\)](CatIs.FailedWith.md#Cat.UnitTesting.Responses.NUnit.CatIs.FailedWith(Cat.Responses.Abstractions.CatResponseType,string) 'Cat\.UnitTesting\.Responses\.NUnit\.CatIs\.FailedWith\(Cat\.Responses\.Abstractions\.CatResponseType, string\)') | The response failed with this type and one of its errors has this code\. |
| [FailedWithCode\(string\)](CatIs.FailedWithCode.5FSNSX761X85Q8GU5TTLG2KI9.md 'Cat\.UnitTesting\.Responses\.NUnit\.CatIs\.FailedWithCode\(string\)') | The response failed and one of its errors has this code\. |
| [SucceededWith\(CatResponseType\)](CatIs.SucceededWith.AQ01RT1OFPLUUGI9U626WNJJ8.md 'Cat\.UnitTesting\.Responses\.NUnit\.CatIs\.SucceededWith\(Cat\.Responses\.Abstractions\.CatResponseType\)') | The response succeeded with this type, such as [Created](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.Created.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Created')\. |
