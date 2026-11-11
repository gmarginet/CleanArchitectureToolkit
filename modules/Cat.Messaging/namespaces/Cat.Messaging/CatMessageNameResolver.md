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

## CatMessageNameResolver Class

Default [ICatMessageNameResolver](../../../Cat.Messaging/namespaces/Cat.Messaging.Abstractions/ICatMessageNameResolver.md 'Cat\.Messaging\.Abstractions\.ICatMessageNameResolver')\.
The name of the type is the name on the bus, unless [CatMessageAttribute](../../../Cat.Messaging/namespaces/Cat.Messaging.Abstractions/CatMessageAttribute.md 'Cat\.Messaging\.Abstractions\.CatMessageAttribute') says otherwise\.

```csharp
internal sealed class CatMessageNameResolver : Cat.Messaging.Abstractions.ICatMessageNameResolver
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatMessageNameResolver

Implements [ICatMessageNameResolver](../../../Cat.Messaging/namespaces/Cat.Messaging.Abstractions/ICatMessageNameResolver.md 'Cat\.Messaging\.Abstractions\.ICatMessageNameResolver')

| Methods | |
| :--- | :--- |
| [GetKind\(Type\)](CatMessageNameResolver.GetKind.MUD5TAE7RQ25F7621AXZPU6QD.md 'Cat\.Messaging\.CatMessageNameResolver\.GetKind\(System\.Type\)') | Tells whether a message type is an event or a command message\. |
| [GetName\(Type\)](CatMessageNameResolver.GetName.4IX62DO8VM2WWZ1FIDI9VT4J9.md 'Cat\.Messaging\.CatMessageNameResolver\.GetName\(System\.Type\)') | Gets the name of the queue or topic, and the subject, of a message type\. |
| [RequiresSession\(Type\)](CatMessageNameResolver.RequiresSession.H75IXE71EH7K4QK32CRJDU712.md 'Cat\.Messaging\.CatMessageNameResolver\.RequiresSession\(System\.Type\)') | Tells whether a message type goes to an entity that needs sessions\. |
