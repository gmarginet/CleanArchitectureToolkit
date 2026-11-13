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
  
##### >> [Cat\.EventProcessor\.Authorization Assembly](index.md 'index') >> [Cat\.EventProcessor\.Authorization Namespace](Cat.EventProcessor.Authorization.md 'Cat\.EventProcessor\.Authorization') >> [AuthorizationStartupCheck Class](AuthorizationStartupCheck.md 'Cat\.EventProcessor\.Authorization\.AuthorizationStartupCheck')

## AuthorizationStartupCheck\(ICatReceiveRegistry, IAuthorizationPolicyProvider, ILogger\<AuthorizationStartupCheck\>\) Constructor

```csharp
public AuthorizationStartupCheck(Cat.EventProcessor.Abstractions.ICatReceiveRegistry registry, Microsoft.AspNetCore.Authorization.IAuthorizationPolicyProvider policies, Microsoft.Extensions.Logging.ILogger<Cat.EventProcessor.Authorization.AuthorizationStartupCheck> logger);
```
#### Parameters

<a name='Cat.EventProcessor.Authorization.AuthorizationStartupCheck.AuthorizationStartupCheck(Cat.EventProcessor.Abstractions.ICatReceiveRegistry,Microsoft.AspNetCore.Authorization.IAuthorizationPolicyProvider,Microsoft.Extensions.Logging.ILogger_Cat.EventProcessor.Authorization.AuthorizationStartupCheck_).registry'></a>

`registry` [ICatReceiveRegistry](../../../Cat.EventProcessor/namespaces/Cat.EventProcessor.Abstractions/ICatReceiveRegistry.md 'Cat\.EventProcessor\.Abstractions\.ICatReceiveRegistry')

<a name='Cat.EventProcessor.Authorization.AuthorizationStartupCheck.AuthorizationStartupCheck(Cat.EventProcessor.Abstractions.ICatReceiveRegistry,Microsoft.AspNetCore.Authorization.IAuthorizationPolicyProvider,Microsoft.Extensions.Logging.ILogger_Cat.EventProcessor.Authorization.AuthorizationStartupCheck_).policies'></a>

`policies` [Microsoft\.AspNetCore\.Authorization\.IAuthorizationPolicyProvider](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.authorization.iauthorizationpolicyprovider 'Microsoft\.AspNetCore\.Authorization\.IAuthorizationPolicyProvider')

<a name='Cat.EventProcessor.Authorization.AuthorizationStartupCheck.AuthorizationStartupCheck(Cat.EventProcessor.Abstractions.ICatReceiveRegistry,Microsoft.AspNetCore.Authorization.IAuthorizationPolicyProvider,Microsoft.Extensions.Logging.ILogger_Cat.EventProcessor.Authorization.AuthorizationStartupCheck_).logger'></a>

`logger` [Microsoft\.Extensions\.Logging\.ILogger&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')[AuthorizationStartupCheck](AuthorizationStartupCheck.md 'Cat\.EventProcessor\.Authorization\.AuthorizationStartupCheck')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')