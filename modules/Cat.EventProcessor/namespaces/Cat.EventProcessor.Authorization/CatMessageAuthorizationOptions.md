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

## CatMessageAuthorizationOptions Class

The settings of the authorization of messages\.

```csharp
public class CatMessageAuthorizationOptions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatMessageAuthorizationOptions

| Properties | |
| :--- | :--- |
| [AuthenticationScheme](CatMessageAuthorizationOptions.AuthenticationScheme.md 'Cat\.EventProcessor\.Authorization\.CatMessageAuthorizationOptions\.AuthenticationScheme') | The JWT bearer scheme whose options validate the token of a message\. The default is `Bearer`\. The service registers that scheme, also when it has no HTTP authentication\. |
| [DenyMessagesWithoutPolicy](CatMessageAuthorizationOptions.DenyMessagesWithoutPolicy.md 'Cat\.EventProcessor\.Authorization\.CatMessageAuthorizationOptions\.DenyMessagesWithoutPolicy') | When true, the receiver denies a message type that has no policy and no rule\. The default is false, so a service keeps working while its message types get their rules\. The listener logs the message types without a rule at startup either way\. A message type that is open on purpose states a rule that always passes, such as `options.Require(policy => policy.RequireAssertion(_ => true))`\. |
