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
  
##### >> [Cat\.Users\.Abstractions Assembly](index.md 'index') >> [Cat\.Users\.Abstractions Namespace](Cat.Users.Abstractions.md 'Cat\.Users\.Abstractions')

## CatUser Class

A plain, immutable [ICatUser](ICatUser.md 'Cat\.Users\.Abstractions\.ICatUser')\.
It is the anonymous user, the system user of a worker, or any user a developer builds by hand\.

```csharp
public sealed class CatUser : Cat.Users.Abstractions.ICatUser
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatUser

Implements [ICatUser](ICatUser.md 'Cat\.Users\.Abstractions\.ICatUser')

| Constructors | |
| :--- | :--- |
| [CatUser\(string, string, bool, IEnumerable&lt;string&gt;\)](CatUser..ctor.FFW49Z4GO9FSHH3MSHG7V3DV2.md 'Cat\.Users\.Abstractions\.CatUser\.CatUser\(string, string, bool, System\.Collections\.Generic\.IEnumerable\<string\>\)') | Creates a user\. |

| Fields | |
| :--- | :--- |
| [SystemRole](CatUser.SystemRole.md 'Cat\.Users\.Abstractions\.CatUser\.SystemRole') | The role of the system user\. |
| [\_roles](CatUser._roles.md 'Cat\.Users\.Abstractions\.CatUser\.\_roles') | |

| Properties | |
| :--- | :--- |
| [Anonymous](CatUser.Anonymous.md 'Cat\.Users\.Abstractions\.CatUser\.Anonymous') | The user that is not authenticated: no id, no name and no roles\. A rule that needs a login denies it\. |
| [IsAuthenticated](CatUser.IsAuthenticated.md 'Cat\.Users\.Abstractions\.CatUser\.IsAuthenticated') | True when the caller is known\. Anonymous work is not authenticated\. |
| [Name](CatUser.Name.md 'Cat\.Users\.Abstractions\.CatUser\.Name') | The display name of the user\. Empty when it is not known\. |
| [UserId](CatUser.UserId.md 'Cat\.Users\.Abstractions\.CatUser\.UserId') | The id of the user at the identity provider\. Empty when the user is not authenticated\. |

| Methods | |
| :--- | :--- |
| [IsInRole\(string\)](CatUser.IsInRole.M6LLTHKDV4SBDGEHU7DDB8QW1.md 'Cat\.Users\.Abstractions\.CatUser\.IsInRole\(string\)') | Tells whether the user has the role\. |
| [System\(string\)](CatUser.System.YH6UTGHVYBPJEIMY9ZWQI1152.md 'Cat\.Users\.Abstractions\.CatUser\.System\(string\)') | Creates the named user of a worker\. It is authenticated and has the role [SystemRole](CatUser.SystemRole.md 'Cat\.Users\.Abstractions\.CatUser\.SystemRole')\. |
