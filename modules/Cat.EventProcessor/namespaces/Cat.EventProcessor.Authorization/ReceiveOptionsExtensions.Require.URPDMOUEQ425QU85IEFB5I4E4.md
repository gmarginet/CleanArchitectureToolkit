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
  
##### >> [Cat\.EventProcessor\.Authorization Assembly](index.md 'index') >> [Cat\.EventProcessor\.Authorization\.Extensions Namespace](Cat.EventProcessor.Authorization.Extensions.md 'Cat\.EventProcessor\.Authorization\.Extensions') >> [ReceiveOptionsExtensions Class](ReceiveOptionsExtensions.md 'Cat\.EventProcessor\.Authorization\.Extensions\.ReceiveOptionsExtensions')

## ReceiveOptionsExtensions\.Require\(this CatReceiveOptions, Action\<AuthorizationPolicyBuilder\>\) Method

Adds a rule that a message of this type must pass before the handler runs\. The rule is built with the policy builder of ASP\.NET Core,
so every rule of ASP\.NET Core works, such as `options.Require(policy => policy.RequireRole("admin"))`\.
A message must pass the named policy of [Policy](../../../Cat.EventProcessor/namespaces/Cat.EventProcessor.Abstractions/CatReceiveOptions.Policy.md 'Cat\.EventProcessor\.Abstractions\.CatReceiveOptions\.Policy') and every rule\.

```csharp
public static Cat.EventProcessor.Abstractions.CatReceiveOptions Require(this Cat.EventProcessor.Abstractions.CatReceiveOptions options, System.Action<Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder> rule);
```
#### Parameters

<a name='Cat.EventProcessor.Authorization.Extensions.ReceiveOptionsExtensions.Require(thisCat.EventProcessor.Abstractions.CatReceiveOptions,System.Action_Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder_).options'></a>

`options` [CatReceiveOptions](../../../Cat.EventProcessor/namespaces/Cat.EventProcessor.Abstractions/CatReceiveOptions.md 'Cat\.EventProcessor\.Abstractions\.CatReceiveOptions')

The settings of the message type\.

<a name='Cat.EventProcessor.Authorization.Extensions.ReceiveOptionsExtensions.Require(thisCat.EventProcessor.Abstractions.CatReceiveOptions,System.Action_Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder_).rule'></a>

`rule` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[Microsoft\.AspNetCore\.Authorization\.AuthorizationPolicyBuilder](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.authorization.authorizationpolicybuilder 'Microsoft\.AspNetCore\.Authorization\.AuthorizationPolicyBuilder')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

Builds the rule\.

#### Returns
[CatReceiveOptions](../../../Cat.EventProcessor/namespaces/Cat.EventProcessor.Abstractions/CatReceiveOptions.md 'Cat\.EventProcessor\.Abstractions\.CatReceiveOptions')  
The same options, so calls can be chained\.