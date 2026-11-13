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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.EVENTPROCESSOR](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.EventProcessor\.Authorization Assembly](index.md 'index') >> [Cat\.EventProcessor\.Authorization Namespace](Cat.EventProcessor.Authorization.md 'Cat\.EventProcessor\.Authorization') >> [CatMessageAuthorizer Class](CatMessageAuthorizer.md 'Cat\.EventProcessor\.Authorization\.CatMessageAuthorizer')

## CatMessageAuthorizer\(CatMessageTokenValidator, IAuthorizationService, ICatUserAccessor, IOptions\<CatUsersOptions\>, IOptions\<CatMessageAuthorizationOptions\>\) Constructor

```csharp
public CatMessageAuthorizer(Cat.EventProcessor.Authorization.CatMessageTokenValidator validator, Microsoft.AspNetCore.Authorization.IAuthorizationService authorization, Cat.Users.Abstractions.ICatUserAccessor userAccessor, Microsoft.Extensions.Options.IOptions<Cat.Users.CatUsersOptions> usersOptions, Microsoft.Extensions.Options.IOptions<Cat.EventProcessor.Authorization.CatMessageAuthorizationOptions> options);
```
#### Parameters

<a name='Cat.EventProcessor.Authorization.CatMessageAuthorizer.CatMessageAuthorizer(Cat.EventProcessor.Authorization.CatMessageTokenValidator,Microsoft.AspNetCore.Authorization.IAuthorizationService,Cat.Users.Abstractions.ICatUserAccessor,Microsoft.Extensions.Options.IOptions_Cat.Users.CatUsersOptions_,Microsoft.Extensions.Options.IOptions_Cat.EventProcessor.Authorization.CatMessageAuthorizationOptions_).validator'></a>

`validator` [CatMessageTokenValidator](CatMessageTokenValidator.md 'Cat\.EventProcessor\.Authorization\.CatMessageTokenValidator')

<a name='Cat.EventProcessor.Authorization.CatMessageAuthorizer.CatMessageAuthorizer(Cat.EventProcessor.Authorization.CatMessageTokenValidator,Microsoft.AspNetCore.Authorization.IAuthorizationService,Cat.Users.Abstractions.ICatUserAccessor,Microsoft.Extensions.Options.IOptions_Cat.Users.CatUsersOptions_,Microsoft.Extensions.Options.IOptions_Cat.EventProcessor.Authorization.CatMessageAuthorizationOptions_).authorization'></a>

`authorization` [Microsoft\.AspNetCore\.Authorization\.IAuthorizationService](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.authorization.iauthorizationservice 'Microsoft\.AspNetCore\.Authorization\.IAuthorizationService')

<a name='Cat.EventProcessor.Authorization.CatMessageAuthorizer.CatMessageAuthorizer(Cat.EventProcessor.Authorization.CatMessageTokenValidator,Microsoft.AspNetCore.Authorization.IAuthorizationService,Cat.Users.Abstractions.ICatUserAccessor,Microsoft.Extensions.Options.IOptions_Cat.Users.CatUsersOptions_,Microsoft.Extensions.Options.IOptions_Cat.EventProcessor.Authorization.CatMessageAuthorizationOptions_).userAccessor'></a>

`userAccessor` [ICatUserAccessor](../../../Cat.Users/namespaces/Cat.Users.Abstractions/ICatUserAccessor.md 'Cat\.Users\.Abstractions\.ICatUserAccessor')

<a name='Cat.EventProcessor.Authorization.CatMessageAuthorizer.CatMessageAuthorizer(Cat.EventProcessor.Authorization.CatMessageTokenValidator,Microsoft.AspNetCore.Authorization.IAuthorizationService,Cat.Users.Abstractions.ICatUserAccessor,Microsoft.Extensions.Options.IOptions_Cat.Users.CatUsersOptions_,Microsoft.Extensions.Options.IOptions_Cat.EventProcessor.Authorization.CatMessageAuthorizationOptions_).usersOptions'></a>

`usersOptions` [Microsoft\.Extensions\.Options\.IOptions&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.options.ioptions-1 'Microsoft\.Extensions\.Options\.IOptions\`1')[CatUsersOptions](../../../Cat.Users/namespaces/Cat.Users/CatUsersOptions.md 'Cat\.Users\.CatUsersOptions')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.options.ioptions-1 'Microsoft\.Extensions\.Options\.IOptions\`1')

<a name='Cat.EventProcessor.Authorization.CatMessageAuthorizer.CatMessageAuthorizer(Cat.EventProcessor.Authorization.CatMessageTokenValidator,Microsoft.AspNetCore.Authorization.IAuthorizationService,Cat.Users.Abstractions.ICatUserAccessor,Microsoft.Extensions.Options.IOptions_Cat.Users.CatUsersOptions_,Microsoft.Extensions.Options.IOptions_Cat.EventProcessor.Authorization.CatMessageAuthorizationOptions_).options'></a>

`options` [Microsoft\.Extensions\.Options\.IOptions&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.options.ioptions-1 'Microsoft\.Extensions\.Options\.IOptions\`1')[CatMessageAuthorizationOptions](CatMessageAuthorizationOptions.md 'Cat\.EventProcessor\.Authorization\.CatMessageAuthorizationOptions')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.options.ioptions-1 'Microsoft\.Extensions\.Options\.IOptions\`1')