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
  
##### >> [Cat\.Users Assembly](index.md 'index')

## Cat\.Users Namespace

Builds the user from the claims of a token, holds the user of the current scope and lets a worker set it\.

| Classes | |
| :--- | :--- |
| [CatClaimsUser](CatClaimsUser.md 'Cat\.Users\.CatClaimsUser') | An [ICatUser](../../../Cat.Users/namespaces/Cat.Users.Abstractions/ICatUser.md 'Cat\.Users\.Abstractions\.ICatUser') read from the claims of a [System\.Security\.Claims\.ClaimsPrincipal](https://learn.microsoft.com/en-us/dotnet/api/system.security.claims.claimsprincipal 'System\.Security\.Claims\.ClaimsPrincipal')\. The gateway and the service validate the token\. This class only reads it\. |
| [CatUserAccessor](CatUserAccessor.md 'Cat\.Users\.CatUserAccessor') | Holds the user of the current scope\. A user that was set wins\. Without one, an authenticated HTTP request gives a user built from its claims, and everything else is anonymous\. |
| [CatUsersOptions](CatUsersOptions.md 'Cat\.Users\.CatUsersOptions') | The names of the claims that the user is built from\. The defaults fit a token with a flat `roles` claim, such as the one the demo gets from Keycloak\. A developer on another identity provider changes the values\. |
