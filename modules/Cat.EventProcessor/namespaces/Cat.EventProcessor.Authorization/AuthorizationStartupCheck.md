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
  
##### >> [Cat\.EventProcessor\.Authorization Assembly](index.md 'index') >> [Cat\.EventProcessor\.Authorization Namespace](Cat.EventProcessor.Authorization.md 'Cat\.EventProcessor\.Authorization')

## AuthorizationStartupCheck Class

Checks the policies of the message types when the service starts\. A policy name that does not exist stops the start,
so the mistake shows at startup and not on the first message\. The message types without a rule are logged\.

```csharp
internal sealed class AuthorizationStartupCheck : Microsoft.Extensions.Hosting.IHostedService
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → AuthorizationStartupCheck

Implements [Microsoft\.Extensions\.Hosting\.IHostedService](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.hosting.ihostedservice 'Microsoft\.Extensions\.Hosting\.IHostedService')

| Constructors | |
| :--- | :--- |
| [AuthorizationStartupCheck\(ICatReceiveRegistry, IAuthorizationPolicyProvider, ILogger&lt;AuthorizationStartupCheck&gt;\)](AuthorizationStartupCheck..ctor.Z1YE8F895ZQ8HDSPK67RU5BQ7.md 'Cat\.EventProcessor\.Authorization\.AuthorizationStartupCheck\.AuthorizationStartupCheck\(Cat\.EventProcessor\.Abstractions\.ICatReceiveRegistry, Microsoft\.AspNetCore\.Authorization\.IAuthorizationPolicyProvider, Microsoft\.Extensions\.Logging\.ILogger\<Cat\.EventProcessor\.Authorization\.AuthorizationStartupCheck\>\)') | |

| Fields | |
| :--- | :--- |
| [\_logger](AuthorizationStartupCheck._logger.md 'Cat\.EventProcessor\.Authorization\.AuthorizationStartupCheck\.\_logger') | |
| [\_policies](AuthorizationStartupCheck._policies.md 'Cat\.EventProcessor\.Authorization\.AuthorizationStartupCheck\.\_policies') | |
| [\_registry](AuthorizationStartupCheck._registry.md 'Cat\.EventProcessor\.Authorization\.AuthorizationStartupCheck\.\_registry') | |

| Methods | |
| :--- | :--- |
| [StartAsync\(CancellationToken\)](AuthorizationStartupCheck.StartAsync.LDDNVPA70WWZD4L7NMYKS3DUC.md 'Cat\.EventProcessor\.Authorization\.AuthorizationStartupCheck\.StartAsync\(System\.Threading\.CancellationToken\)') | |
| [StopAsync\(CancellationToken\)](AuthorizationStartupCheck.StopAsync.OHCJLFEPPSGN80MUZ2S2DWRDD.md 'Cat\.EventProcessor\.Authorization\.AuthorizationStartupCheck\.StopAsync\(System\.Threading\.CancellationToken\)') | |
