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
  
##### >> [Cat\.Users Assembly](index.md 'index') >> [Cat\.Users Namespace](Cat.Users.md 'Cat\.Users') >> [CatUserAccessor Class](CatUserAccessor.md 'Cat\.Users\.CatUserAccessor')

## CatUserAccessor\.Flowing Field

```csharp
private static readonly AsyncLocal<ICatUser?> Flowing;
```

#### Field Value
[System\.Threading\.AsyncLocal&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.asynclocal-1 'System\.Threading\.AsyncLocal\`1')[ICatUser](../../../Cat.Users/namespaces/Cat.Users.Abstractions/ICatUser.md 'Cat\.Users\.Abstractions\.ICatUser')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.asynclocal-1 'System\.Threading\.AsyncLocal\`1')