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
  
##### >> [Cat\.Messaging\.Abstractions Assembly](index.md 'index') >> [Cat\.Messaging\.Abstractions Namespace](Cat.Messaging.Abstractions.md 'Cat\.Messaging\.Abstractions')

## ICatMessageNameResolver Interface

Finds the names a message type uses on the bus, by convention or from [CatMessageAttribute](CatMessageAttribute.md 'Cat\.Messaging\.Abstractions\.CatMessageAttribute')\.

```csharp
public interface ICatMessageNameResolver
```

| Methods | |
| :--- | :--- |
| [GetKind\(Type\)](ICatMessageNameResolver.GetKind.B96XVL9DBP5SDW65K1CLM9XG4.md 'Cat\.Messaging\.Abstractions\.ICatMessageNameResolver\.GetKind\(System\.Type\)') | Tells whether a message type is an event or a command message\. |
| [GetName\(Type\)](ICatMessageNameResolver.GetName.EJDE3V0APPM267E5RQ3EJIRW.md 'Cat\.Messaging\.Abstractions\.ICatMessageNameResolver\.GetName\(System\.Type\)') | Gets the name of the queue or topic, and the subject, of a message type\. |
| [RequiresSession\(Type\)](ICatMessageNameResolver.RequiresSession.OUCTRKEQZ0W61OAPZLON7FYCD.md 'Cat\.Messaging\.Abstractions\.ICatMessageNameResolver\.RequiresSession\(System\.Type\)') | Tells whether a message type goes to an entity that needs sessions\. |
