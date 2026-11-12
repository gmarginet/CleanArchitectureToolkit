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
  
##### >> [Cat\.Users\.JwtBearer Assembly](index.md 'index') >> [Cat\.Users\.JwtBearer\.Extensions Namespace](Cat.Users.JwtBearer.Extensions.md 'Cat\.Users\.JwtBearer\.Extensions')

## ServiceCollectionExtensions Class

Registration helpers for the JWT bearer part of the users module\.

```csharp
public static class ServiceCollectionExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → ServiceCollectionExtensions

| Methods | |
| :--- | :--- |
| [AddCatUsersJwtBearer\(this IServiceCollection, string\)](ServiceCollectionExtensions.AddCatUsersJwtBearer.O8VHHZEC3I64CRQZF176JO1MA.md 'Cat\.Users\.JwtBearer\.Extensions\.ServiceCollectionExtensions\.AddCatUsersJwtBearer\(this Microsoft\.Extensions\.DependencyInjection\.IServiceCollection, string\)') | Sets the role claim type of the token validation to [RoleClaimType](../../../Cat.Users/namespaces/Cat.Users/CatUsersOptions.RoleClaimType.md 'Cat\.Users\.CatUsersOptions\.RoleClaimType')\. A role policy such as `RequireRole` and [IsInRole\(string\)](../../../Cat.Users/namespaces/Cat.Users.Abstractions/ICatUser.IsInRole.AAQMPF0AY4605MAN4H5R139PB.md 'Cat\.Users\.Abstractions\.ICatUser\.IsInRole\(System\.String\)') then read the same claim\. The setting runs after the other settings of the scheme, so it wins over a role claim type set in `AddJwtBearer`\. |
