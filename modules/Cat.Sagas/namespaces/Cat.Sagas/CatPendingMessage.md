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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.SAGAS](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Sagas Assembly](index.md 'index') >> [Cat\.Sagas Namespace](Cat.Sagas.md 'Cat\.Sagas')

## CatPendingMessage Class

A message a step wants to send, with the moment the bus must deliver it\.

```csharp
internal sealed class CatPendingMessage
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatPendingMessage

| Constructors | |
| :--- | :--- |
| [CatPendingMessage\(ICatMessage, Nullable&lt;DateTimeOffset&gt;\)](CatPendingMessage..ctor.PGHIMXMGN3TT54ROLMZPZEK56.md 'Cat\.Sagas\.CatPendingMessage\.CatPendingMessage\(Cat\.Messaging\.Abstractions\.ICatMessage, System\.Nullable\<System\.DateTimeOffset\>\)') | |

| Properties | |
| :--- | :--- |
| [Message](CatPendingMessage.Message.md 'Cat\.Sagas\.CatPendingMessage\.Message') | |
| [ScheduledAt](CatPendingMessage.ScheduledAt.md 'Cat\.Sagas\.CatPendingMessage\.ScheduledAt') | |
