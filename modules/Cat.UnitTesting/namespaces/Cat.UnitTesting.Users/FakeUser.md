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
  
##### >> [Cat\.UnitTesting\.Users Assembly](index.md 'index') >> [Cat\.UnitTesting\.Users Namespace](Cat.UnitTesting.Users.md 'Cat\.UnitTesting\.Users')

## FakeUser Class

A user for unit tests\. The test sets the id, the name, the login state and the roles\.
It starts as a logged in user without roles\. Use [CatUser](../../../Cat.Users/namespaces/Cat.Users.Abstractions/CatUser.md 'Cat\.Users\.Abstractions\.CatUser') when the user never changes during the test\.
Derive from it to add the properties of your own application, such as an email address\.

```csharp
public class FakeUser : Cat.Users.Abstractions.ICatUser
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → FakeUser

Implements [ICatUser](../../../Cat.Users/namespaces/Cat.Users.Abstractions/ICatUser.md 'Cat\.Users\.Abstractions\.ICatUser')

| Properties | |
| :--- | :--- |
| [IsAuthenticated](FakeUser.IsAuthenticated.md 'Cat\.UnitTesting\.Users\.FakeUser\.IsAuthenticated') | Whether the user is logged in\. It starts as `true`\. |
| [Name](FakeUser.Name.md 'Cat\.UnitTesting\.Users\.FakeUser\.Name') | The display name of the user\. It starts as `Test User`\. |
| [Roles](FakeUser.Roles.md 'Cat\.UnitTesting\.Users\.FakeUser\.Roles') | The roles of the user\. Add to it or remove from it during the test\. |
| [UserId](FakeUser.UserId.md 'Cat\.UnitTesting\.Users\.FakeUser\.UserId') | The id of the user\. It starts as `test-user`\. |

| Methods | |
| :--- | :--- |
| [InRole\(string\[\]\)](FakeUser.InRole.53YK4ZEM2MW75UTA9FZFLWS6A.md 'Cat\.UnitTesting\.Users\.FakeUser\.InRole\(string\[\]\)') | Gives the user these roles\. |
| [IsInRole\(string\)](FakeUser.IsInRole.YDX2OLJALBHN69VPGPWOOL0Y1.md 'Cat\.UnitTesting\.Users\.FakeUser\.IsInRole\(string\)') | Tells whether the user has the role\. |
