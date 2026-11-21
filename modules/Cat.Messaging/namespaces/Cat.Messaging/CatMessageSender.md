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

## CatMessageSender Class

```csharp
internal sealed class CatMessageSender : Cat.Messaging.CatMessageSenderBase, Cat.Messaging.Abstractions.ICatMessageSender
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [CatMessageSenderBase](CatMessageSenderBase.md 'Cat\.Messaging\.CatMessageSenderBase') → CatMessageSender

Implements [ICatMessageSender](../../../Cat.Messaging/namespaces/Cat.Messaging.Abstractions/ICatMessageSender.md 'Cat\.Messaging\.Abstractions\.ICatMessageSender')

| Constructors | |
| :--- | :--- |
| [CatMessageSender\(ICatMessageNameResolver, ICatMessageSerializer, ICatOutgoingMessageSink, ICatTokenProvider\)](CatMessageSender..ctor.G7M5SJROLG4ZAIAA4SOXQ94A9.md 'Cat\.Messaging\.CatMessageSender\.CatMessageSender\(Cat\.Messaging\.Abstractions\.ICatMessageNameResolver, Cat\.Messaging\.ICatMessageSerializer, Cat\.Messaging\.Abstractions\.ICatOutgoingMessageSink, Cat\.Messaging\.Abstractions\.ICatTokenProvider\)') | |

| Methods | |
| :--- | :--- |
| [ChooseSubject\(Nullable&lt;DateTimeOffset&gt;\)](CatMessageSender.ChooseSubject.UITUJ9ILVI7QILIXCWROQZSBA.md 'Cat\.Messaging\.CatMessageSender\.ChooseSubject\(System\.Nullable\<System\.DateTimeOffset\>\)') | |
