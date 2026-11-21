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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.MESSAGING](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Messaging Assembly](index.md 'index') >> [Cat\.Messaging Namespace](Cat.Messaging.md 'Cat\.Messaging')

## CatSystemMessageSender Class

```csharp
internal sealed class CatSystemMessageSender : Cat.Messaging.CatMessageSenderBase, Cat.Messaging.Abstractions.ICatSystemMessageSender
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [CatMessageSenderBase](CatMessageSenderBase.md 'Cat\.Messaging\.CatMessageSenderBase') → CatSystemMessageSender

Implements [ICatSystemMessageSender](../../../Cat.Messaging/namespaces/Cat.Messaging.Abstractions/ICatSystemMessageSender.md 'Cat\.Messaging\.Abstractions\.ICatSystemMessageSender')

| Constructors | |
| :--- | :--- |
| [CatSystemMessageSender\(ICatMessageNameResolver, ICatMessageSerializer, ICatOutgoingMessageSink, ICatTokenProvider\)](CatSystemMessageSender..ctor.GZR9FZHSQHUFRKMJRVY87FBBA.md 'Cat\.Messaging\.CatSystemMessageSender\.CatSystemMessageSender\(Cat\.Messaging\.Abstractions\.ICatMessageNameResolver, Cat\.Messaging\.ICatMessageSerializer, Cat\.Messaging\.Abstractions\.ICatOutgoingMessageSink, Cat\.Messaging\.Abstractions\.ICatTokenProvider\)') | |

| Methods | |
| :--- | :--- |
| [ChooseSubject\(Nullable&lt;DateTimeOffset&gt;\)](CatSystemMessageSender.ChooseSubject.6VU8R72RLQT6YRK7KLAPHK87C.md 'Cat\.Messaging\.CatSystemMessageSender\.ChooseSubject\(System\.Nullable\<System\.DateTimeOffset\>\)') | |
| [RequireNoTokenProvider\(\)](CatSystemMessageSender.RequireNoTokenProvider().md 'Cat\.Messaging\.CatSystemMessageSender\.RequireNoTokenProvider\(\)') | |
