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
  
##### >> [Cat\.EventProcessor\.Authorization Assembly](index.md 'index') >> [Cat\.EventProcessor\.Authorization\.Extensions Namespace](Cat.EventProcessor.Authorization.Extensions.md 'Cat\.EventProcessor\.Authorization\.Extensions')

## ReceiveOptionsExtensions Class

States an authorization rule next to a message type\.

```csharp
public static class ReceiveOptionsExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → ReceiveOptionsExtensions

| Methods | |
| :--- | :--- |
| [Require\(this CatReceiveOptions, Action&lt;AuthorizationPolicyBuilder&gt;\)](ReceiveOptionsExtensions.Require.URPDMOUEQ425QU85IEFB5I4E4.md 'Cat\.EventProcessor\.Authorization\.Extensions\.ReceiveOptionsExtensions\.Require\(this Cat\.EventProcessor\.Abstractions\.CatReceiveOptions, System\.Action\<Microsoft\.AspNetCore\.Authorization\.AuthorizationPolicyBuilder\>\)') | Adds a rule that a message of this type must pass before the handler runs\. The rule is built with the policy builder of ASP\.NET Core, so every rule of ASP\.NET Core works, such as `options.Require(policy => policy.RequireRole("admin"))`\. A message must pass the named policy of [Policy](../../../Cat.EventProcessor/namespaces/Cat.EventProcessor.Abstractions/CatReceiveOptions.Policy.md 'Cat\.EventProcessor\.Abstractions\.CatReceiveOptions\.Policy') and every rule\. |
