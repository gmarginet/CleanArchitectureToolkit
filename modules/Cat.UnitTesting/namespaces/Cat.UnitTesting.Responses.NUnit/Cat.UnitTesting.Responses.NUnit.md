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
  
##### >> [Cat\.UnitTesting\.Responses\.NUnit Assembly](index.md 'index')

## Cat\.UnitTesting\.Responses\.NUnit Namespace

NUnit constraints for responses, such as succeeded, failed, the response type and an error code\.

| Classes | |
| :--- | :--- |
| [CatIs](CatIs.md 'Cat\.UnitTesting\.Responses\.NUnit\.CatIs') | NUnit constraints for an [ICatResponse](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse')\. Use them with `Assert.That`, for example `Assert.That(response, CatIs.Succeeded)` or `Assert.That(response, CatIs.FailedWith(CatResponseType.NotFound, "DEM-ORD-1004"))`\. |
| [CatResponseConstraint](CatResponseConstraint.md 'Cat\.UnitTesting\.Responses\.NUnit\.CatResponseConstraint') | A constraint that checks the outcome, the type and an error code of an [ICatResponse](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse')\. Create it with [CatIs](CatIs.md 'Cat\.UnitTesting\.Responses\.NUnit\.CatIs')\. A failed check shows the response as it is, for example `Failed NotFound [DEM-ORD-1004]`\. |
