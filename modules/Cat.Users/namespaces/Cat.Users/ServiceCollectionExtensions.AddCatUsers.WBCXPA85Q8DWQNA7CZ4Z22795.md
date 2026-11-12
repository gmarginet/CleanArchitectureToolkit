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
  
##### >> [Cat\.Users Assembly](index.md 'index') >> [Cat\.Users\.Extensions Namespace](Cat.Users.Extensions.md 'Cat\.Users\.Extensions') >> [ServiceCollectionExtensions Class](ServiceCollectionExtensions.md 'Cat\.Users\.Extensions\.ServiceCollectionExtensions')

## ServiceCollectionExtensions\.AddCatUsers\(this IServiceCollection, Action\<CatUsersOptions\>\) Method

Registers [ICatUser](../../../Cat.Users/namespaces/Cat.Users.Abstractions/ICatUser.md 'Cat\.Users\.Abstractions\.ICatUser') and [ICatUserAccessor](../../../Cat.Users/namespaces/Cat.Users.Abstractions/ICatUserAccessor.md 'Cat\.Users\.Abstractions\.ICatUserAccessor'), both scoped\.

```csharp
public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddCatUsers(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, System.Action<Cat.Users.CatUsersOptions>? configure=null);
```
#### Parameters

<a name='Cat.Users.Extensions.ServiceCollectionExtensions.AddCatUsers(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,System.Action_Cat.Users.CatUsersOptions_).services'></a>

`services` [Microsoft\.Extensions\.DependencyInjection\.IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection 'Microsoft\.Extensions\.DependencyInjection\.IServiceCollection')

The service collection to add to\.

<a name='Cat.Users.Extensions.ServiceCollectionExtensions.AddCatUsers(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,System.Action_Cat.Users.CatUsersOptions_).configure'></a>

`configure` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[CatUsersOptions](CatUsersOptions.md 'Cat\.Users\.CatUsersOptions')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

Changes the names of the claims\.

#### Returns
[Microsoft\.Extensions\.DependencyInjection\.IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection 'Microsoft\.Extensions\.DependencyInjection\.IServiceCollection')  
The same service collection\.