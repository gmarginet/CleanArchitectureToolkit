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

## CatMessageTokenValidator Class

Validates the token of a message with the JWT bearer options of the service, the same way the HTTP side does,
with one difference: the lifetime is checked against the time the bus received the message, not against the clock now\.

```csharp
internal sealed class CatMessageTokenValidator
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatMessageTokenValidator

| Constructors | |
| :--- | :--- |
| [CatMessageTokenValidator\(IOptionsMonitor&lt;JwtBearerOptions&gt;, IOptions&lt;CatUsersOptions&gt;, IOptions&lt;CatMessageAuthorizationOptions&gt;\)](CatMessageTokenValidator..ctor.WZ1PVZU5K6VGHFIN4FNGWSH0D.md 'Cat\.EventProcessor\.Authorization\.CatMessageTokenValidator\.CatMessageTokenValidator\(Microsoft\.Extensions\.Options\.IOptionsMonitor\<Microsoft\.AspNetCore\.Authentication\.JwtBearer\.JwtBearerOptions\>, Microsoft\.Extensions\.Options\.IOptions\<Cat\.Users\.CatUsersOptions\>, Microsoft\.Extensions\.Options\.IOptions\<Cat\.EventProcessor\.Authorization\.CatMessageAuthorizationOptions\>\)') | |

| Fields | |
| :--- | :--- |
| [\_jwtOptions](CatMessageTokenValidator._jwtOptions.md 'Cat\.EventProcessor\.Authorization\.CatMessageTokenValidator\.\_jwtOptions') | |
| [\_options](CatMessageTokenValidator._options.md 'Cat\.EventProcessor\.Authorization\.CatMessageTokenValidator\.\_options') | |
| [\_usersOptions](CatMessageTokenValidator._usersOptions.md 'Cat\.EventProcessor\.Authorization\.CatMessageTokenValidator\.\_usersOptions') | |

| Methods | |
| :--- | :--- |
| [IsAlive\(Nullable&lt;DateTime&gt;, Nullable&lt;DateTime&gt;, DateTime, TimeSpan\)](CatMessageTokenValidator.IsAlive.Z4HGMGL5TERMS1047KZ7TWA7C.md 'Cat\.EventProcessor\.Authorization\.CatMessageTokenValidator\.IsAlive\(System\.Nullable\<System\.DateTime\>, System\.Nullable\<System\.DateTime\>, System\.DateTime, System\.TimeSpan\)') | |
| [ValidateAsync\(string, CatIncomingMessage, CancellationToken\)](CatMessageTokenValidator.ValidateAsync.76ZLIGRAJFDSIUYAIIIBNJD1B.md 'Cat\.EventProcessor\.Authorization\.CatMessageTokenValidator\.ValidateAsync\(string, Cat\.EventProcessor\.Abstractions\.CatIncomingMessage, System\.Threading\.CancellationToken\)') | Validates the token\. |
