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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.USERS](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Users Assembly](index.md 'index') >> [Cat\.Users Namespace](Cat.Users.md 'Cat\.Users')

## CatClaimsUser Class

An [ICatUser](../../../Cat.Users/namespaces/Cat.Users.Abstractions/ICatUser.md 'Cat\.Users\.Abstractions\.ICatUser') read from the claims of a [System\.Security\.Claims\.ClaimsPrincipal](https://learn.microsoft.com/en-us/dotnet/api/system.security.claims.claimsprincipal 'System\.Security\.Claims\.ClaimsPrincipal')\.
The gateway and the service validate the token\. This class only reads it\.

```csharp
public class CatClaimsUser : Cat.Users.Abstractions.ICatUser
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatClaimsUser

Implements [ICatUser](../../../Cat.Users/namespaces/Cat.Users.Abstractions/ICatUser.md 'Cat\.Users\.Abstractions\.ICatUser')

| Constructors | |
| :--- | :--- |
| [CatClaimsUser\(ClaimsPrincipal, CatUsersOptions\)](CatClaimsUser..ctor.NULFIZ8KZ9AGZ17CTEO2TEWT9.md 'Cat\.Users\.CatClaimsUser\.CatClaimsUser\(System\.Security\.Claims\.ClaimsPrincipal, Cat\.Users\.CatUsersOptions\)') | Creates the user\. |

| Fields | |
| :--- | :--- |
| [\_options](CatClaimsUser._options.md 'Cat\.Users\.CatClaimsUser\.\_options') | |
| [\_principal](CatClaimsUser._principal.md 'Cat\.Users\.CatClaimsUser\.\_principal') | |

| Properties | |
| :--- | :--- |
| [IsAuthenticated](CatClaimsUser.IsAuthenticated.md 'Cat\.Users\.CatClaimsUser\.IsAuthenticated') | True when the caller is known\. Anonymous work is not authenticated\. |
| [Name](CatClaimsUser.Name.md 'Cat\.Users\.CatClaimsUser\.Name') | The display name of the user\. Empty when it is not known\. |
| [UserId](CatClaimsUser.UserId.md 'Cat\.Users\.CatClaimsUser\.UserId') | The id of the user at the identity provider\. Empty when the user is not authenticated\. |

| Methods | |
| :--- | :--- |
| [IsInRole\(string\)](CatClaimsUser.IsInRole.ZUJ9ID74P60IO2GVTLQ6YO20B.md 'Cat\.Users\.CatClaimsUser\.IsInRole\(string\)') | Tells whether the user has the role\. |
