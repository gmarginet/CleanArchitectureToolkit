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

## CatMessageAuthorizer Class

Default [ICatMessageAuthorizer](../../../Cat.EventProcessor/namespaces/Cat.EventProcessor.Abstractions/ICatMessageAuthorizer.md 'Cat\.EventProcessor\.Abstractions\.ICatMessageAuthorizer')\. It validates the token, sets the user of the scope and checks the policy and the rules
of the message type with [Microsoft\.AspNetCore\.Authorization\.IAuthorizationService](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.authorization.iauthorizationservice 'Microsoft\.AspNetCore\.Authorization\.IAuthorizationService')\.

```csharp
internal sealed class CatMessageAuthorizer : Cat.EventProcessor.Abstractions.ICatMessageAuthorizer
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatMessageAuthorizer

Implements [ICatMessageAuthorizer](../../../Cat.EventProcessor/namespaces/Cat.EventProcessor.Abstractions/ICatMessageAuthorizer.md 'Cat\.EventProcessor\.Abstractions\.ICatMessageAuthorizer')

| Constructors | |
| :--- | :--- |
| [CatMessageAuthorizer\(CatMessageTokenValidator, IAuthorizationService, ICatUserAccessor, IOptions&lt;CatUsersOptions&gt;, IOptions&lt;CatMessageAuthorizationOptions&gt;\)](CatMessageAuthorizer..ctor.5A9FLBVCU1PL7HX3W7F79U3O.md 'Cat\.EventProcessor\.Authorization\.CatMessageAuthorizer\.CatMessageAuthorizer\(Cat\.EventProcessor\.Authorization\.CatMessageTokenValidator, Microsoft\.AspNetCore\.Authorization\.IAuthorizationService, Cat\.Users\.Abstractions\.ICatUserAccessor, Microsoft\.Extensions\.Options\.IOptions\<Cat\.Users\.CatUsersOptions\>, Microsoft\.Extensions\.Options\.IOptions\<Cat\.EventProcessor\.Authorization\.CatMessageAuthorizationOptions\>\)') | |

| Fields | |
| :--- | :--- |
| [\_authorization](CatMessageAuthorizer._authorization.md 'Cat\.EventProcessor\.Authorization\.CatMessageAuthorizer\.\_authorization') | |
| [\_options](CatMessageAuthorizer._options.md 'Cat\.EventProcessor\.Authorization\.CatMessageAuthorizer\.\_options') | |
| [\_userAccessor](CatMessageAuthorizer._userAccessor.md 'Cat\.EventProcessor\.Authorization\.CatMessageAuthorizer\.\_userAccessor') | |
| [\_usersOptions](CatMessageAuthorizer._usersOptions.md 'Cat\.EventProcessor\.Authorization\.CatMessageAuthorizer\.\_usersOptions') | |
| [\_validator](CatMessageAuthorizer._validator.md 'Cat\.EventProcessor\.Authorization\.CatMessageAuthorizer\.\_validator') | |

| Methods | |
| :--- | :--- |
| [AuthorizeAsync\(CatIncomingMessage, CatReceiveOptions, CancellationToken\)](CatMessageAuthorizer.AuthorizeAsync.B39T2UHR29I4KG2HM093ZM195.md 'Cat\.EventProcessor\.Authorization\.CatMessageAuthorizer\.AuthorizeAsync\(Cat\.EventProcessor\.Abstractions\.CatIncomingMessage, Cat\.EventProcessor\.Abstractions\.CatReceiveOptions, System\.Threading\.CancellationToken\)') | Reads the token of the message, sets the user of the scope and checks the policy of the message type\. |
| [Denied\(ClaimsPrincipal, string\)](CatMessageAuthorizer.Denied.H4XS28UIVKXET5IUAYMJU30JE.md 'Cat\.EventProcessor\.Authorization\.CatMessageAuthorizer\.Denied\(System\.Security\.Claims\.ClaimsPrincipal, string\)') | |
| [ReadToken\(CatIncomingMessage\)](CatMessageAuthorizer.ReadToken.JXHTA0AO14RP1ROWZ7XDFAG7D.md 'Cat\.EventProcessor\.Authorization\.CatMessageAuthorizer\.ReadToken\(Cat\.EventProcessor\.Abstractions\.CatIncomingMessage\)') | |
