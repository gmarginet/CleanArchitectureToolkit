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
  
##### >> [Cat\.EventProcessor\.Abstractions Assembly](index.md 'index') >> [Cat\.EventProcessor\.Abstractions Namespace](Cat.EventProcessor.Abstractions.md 'Cat\.EventProcessor\.Abstractions')

## CatAuthorizationResult Class

The answer of the authorization of a message\.

```csharp
public sealed class CatAuthorizationResult
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatAuthorizationResult

| Constructors | |
| :--- | :--- |
| [CatAuthorizationResult\(bool, string, string\)](CatAuthorizationResult..ctor.O19VA31ECA30MPYZOITC0ZCPA.md 'Cat\.EventProcessor\.Abstractions\.CatAuthorizationResult\.CatAuthorizationResult\(bool, string, string\)') | |

| Fields | |
| :--- | :--- |
| [ForbiddenReason](CatAuthorizationResult.ForbiddenReason.md 'Cat\.EventProcessor\.Abstractions\.CatAuthorizationResult\.ForbiddenReason') | The reason of a message whose caller is known but is not allowed\. |
| [UnauthorizedReason](CatAuthorizationResult.UnauthorizedReason.md 'Cat\.EventProcessor\.Abstractions\.CatAuthorizationResult\.UnauthorizedReason') | The reason of a message that has no valid token or whose caller is not known\. |

| Properties | |
| :--- | :--- |
| [Description](CatAuthorizationResult.Description.md 'Cat\.EventProcessor\.Abstractions\.CatAuthorizationResult\.Description') | A longer description for the dead letter queue\. Empty on success\. |
| [Reason](CatAuthorizationResult.Reason.md 'Cat\.EventProcessor\.Abstractions\.CatAuthorizationResult\.Reason') | A short reason for the dead letter queue, [UnauthorizedReason](CatAuthorizationResult.UnauthorizedReason.md 'Cat\.EventProcessor\.Abstractions\.CatAuthorizationResult\.UnauthorizedReason') or [ForbiddenReason](CatAuthorizationResult.ForbiddenReason.md 'Cat\.EventProcessor\.Abstractions\.CatAuthorizationResult\.ForbiddenReason')\. Empty on success\. |
| [Succeeded](CatAuthorizationResult.Succeeded.md 'Cat\.EventProcessor\.Abstractions\.CatAuthorizationResult\.Succeeded') | True when the handler may run\. |
| [Success](CatAuthorizationResult.Success.md 'Cat\.EventProcessor\.Abstractions\.CatAuthorizationResult\.Success') | The handler may run\. |

| Methods | |
| :--- | :--- |
| [Forbidden\(string\)](CatAuthorizationResult.Forbidden.38W3H5CJQ7OZAVS722BOBDP8B.md 'Cat\.EventProcessor\.Abstractions\.CatAuthorizationResult\.Forbidden\(string\)') | The caller is known and is not allowed\. |
| [Unauthorized\(string\)](CatAuthorizationResult.Unauthorized.ARX48KCSVB5ML2THM31MBGLU8.md 'Cat\.EventProcessor\.Abstractions\.CatAuthorizationResult\.Unauthorized\(string\)') | The message has no valid token, or the caller is not known and the message type needs a caller\. |
