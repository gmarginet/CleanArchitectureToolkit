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
  
##### >> [Cat\.EventProcessor\.Authorization Assembly](index.md 'index') >> [Cat\.EventProcessor\.Authorization Namespace](Cat.EventProcessor.Authorization.md 'Cat\.EventProcessor\.Authorization') >> [CatMessageTokenValidator Class](CatMessageTokenValidator.md 'Cat\.EventProcessor\.Authorization\.CatMessageTokenValidator')

## CatMessageTokenValidator\(IOptionsMonitor\<JwtBearerOptions\>, IOptions\<CatUsersOptions\>, IOptions\<CatMessageAuthorizationOptions\>\) Constructor

```csharp
public CatMessageTokenValidator(Microsoft.Extensions.Options.IOptionsMonitor<Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerOptions> jwtOptions, Microsoft.Extensions.Options.IOptions<Cat.Users.CatUsersOptions> usersOptions, Microsoft.Extensions.Options.IOptions<Cat.EventProcessor.Authorization.CatMessageAuthorizationOptions> options);
```
#### Parameters

<a name='Cat.EventProcessor.Authorization.CatMessageTokenValidator.CatMessageTokenValidator(Microsoft.Extensions.Options.IOptionsMonitor_Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerOptions_,Microsoft.Extensions.Options.IOptions_Cat.Users.CatUsersOptions_,Microsoft.Extensions.Options.IOptions_Cat.EventProcessor.Authorization.CatMessageAuthorizationOptions_).jwtOptions'></a>

`jwtOptions` [Microsoft\.Extensions\.Options\.IOptionsMonitor&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.options.ioptionsmonitor-1 'Microsoft\.Extensions\.Options\.IOptionsMonitor\`1')[Microsoft\.AspNetCore\.Authentication\.JwtBearer\.JwtBearerOptions](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.authentication.jwtbearer.jwtbeareroptions 'Microsoft\.AspNetCore\.Authentication\.JwtBearer\.JwtBearerOptions')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.options.ioptionsmonitor-1 'Microsoft\.Extensions\.Options\.IOptionsMonitor\`1')

<a name='Cat.EventProcessor.Authorization.CatMessageTokenValidator.CatMessageTokenValidator(Microsoft.Extensions.Options.IOptionsMonitor_Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerOptions_,Microsoft.Extensions.Options.IOptions_Cat.Users.CatUsersOptions_,Microsoft.Extensions.Options.IOptions_Cat.EventProcessor.Authorization.CatMessageAuthorizationOptions_).usersOptions'></a>

`usersOptions` [Microsoft\.Extensions\.Options\.IOptions&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.options.ioptions-1 'Microsoft\.Extensions\.Options\.IOptions\`1')[CatUsersOptions](../../../Cat.Users/namespaces/Cat.Users/CatUsersOptions.md 'Cat\.Users\.CatUsersOptions')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.options.ioptions-1 'Microsoft\.Extensions\.Options\.IOptions\`1')

<a name='Cat.EventProcessor.Authorization.CatMessageTokenValidator.CatMessageTokenValidator(Microsoft.Extensions.Options.IOptionsMonitor_Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerOptions_,Microsoft.Extensions.Options.IOptions_Cat.Users.CatUsersOptions_,Microsoft.Extensions.Options.IOptions_Cat.EventProcessor.Authorization.CatMessageAuthorizationOptions_).options'></a>

`options` [Microsoft\.Extensions\.Options\.IOptions&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.options.ioptions-1 'Microsoft\.Extensions\.Options\.IOptions\`1')[CatMessageAuthorizationOptions](CatMessageAuthorizationOptions.md 'Cat\.EventProcessor\.Authorization\.CatMessageAuthorizationOptions')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.options.ioptions-1 'Microsoft\.Extensions\.Options\.IOptions\`1')