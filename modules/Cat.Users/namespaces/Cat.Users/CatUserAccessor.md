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

## CatUserAccessor Class

Holds the user of the current scope\.
A user that was set wins, also in a scope that is created further down the same async call chain\. Without one, an authenticated HTTP request gives a user built from its claims, and everything else is anonymous\.

```csharp
public class CatUserAccessor : Cat.Users.Abstractions.ICatUserAccessor
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatUserAccessor

Implements [ICatUserAccessor](../../../Cat.Users/namespaces/Cat.Users.Abstractions/ICatUserAccessor.md 'Cat\.Users\.Abstractions\.ICatUserAccessor')

| Constructors | |
| :--- | :--- |
| [CatUserAccessor\(IHttpContextAccessor, IOptions&lt;CatUsersOptions&gt;\)](CatUserAccessor..ctor.NWJCRIJUA2W2WR4D00Q20REPE.md 'Cat\.Users\.CatUserAccessor\.CatUserAccessor\(Microsoft\.AspNetCore\.Http\.IHttpContextAccessor, Microsoft\.Extensions\.Options\.IOptions\<Cat\.Users\.CatUsersOptions\>\)') | Creates the accessor\. |

| Fields | |
| :--- | :--- |
| [Flowing](CatUserAccessor.Flowing.md 'Cat\.Users\.CatUserAccessor\.Flowing') | |
| [\_httpContextAccessor](CatUserAccessor._httpContextAccessor.md 'Cat\.Users\.CatUserAccessor\.\_httpContextAccessor') | |
| [\_options](CatUserAccessor._options.md 'Cat\.Users\.CatUserAccessor\.\_options') | |
| [\_user](CatUserAccessor._user.md 'Cat\.Users\.CatUserAccessor\.\_user') | |

| Properties | |
| :--- | :--- |
| [User](CatUserAccessor.User.md 'Cat\.Users\.CatUserAccessor\.User') | The user of the current scope\. When nobody has set a user, this is the user of the HTTP request when there is one, and the anonymous user otherwise\. Running as the system is never a default\. A worker sets [System\(string\)](../../../Cat.Users/namespaces/Cat.Users.Abstractions/CatUser.System.YH6UTGHVYBPJEIMY9ZWQI1152.md 'Cat\.Users\.Abstractions\.CatUser\.System\(System\.String\)') on purpose\. |
