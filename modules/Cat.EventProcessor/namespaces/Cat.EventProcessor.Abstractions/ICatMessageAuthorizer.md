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

## ICatMessageAuthorizer Interface

Checks who sent a message and whether the message type allows that caller\. The receiver calls it before the handler runs\.
It is scoped, and it is resolved from the scope of the message, so it can set the user of that scope\.
A service without an implementation runs its messages without a user and without a policy\.
The implementation lives in an optional project, such as `Cat.EventProcessor.Authorization`\.

```csharp
public interface ICatMessageAuthorizer
```

| Methods | |
| :--- | :--- |
| [AuthorizeAsync\(CatIncomingMessage, CatReceiveOptions, CancellationToken\)](ICatMessageAuthorizer.AuthorizeAsync.TPMAGSOMK6XLIJQYYP93QM4O8.md 'Cat\.EventProcessor\.Abstractions\.ICatMessageAuthorizer\.AuthorizeAsync\(Cat\.EventProcessor\.Abstractions\.CatIncomingMessage, Cat\.EventProcessor\.Abstractions\.CatReceiveOptions, System\.Threading\.CancellationToken\)') | Reads the token of the message, sets the user of the scope and checks the policy of the message type\. |
