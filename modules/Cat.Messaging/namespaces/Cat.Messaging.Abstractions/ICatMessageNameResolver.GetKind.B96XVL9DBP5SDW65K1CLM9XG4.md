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
  
##### >> [Cat\.Messaging\.Abstractions Assembly](index.md 'index') >> [Cat\.Messaging\.Abstractions Namespace](Cat.Messaging.Abstractions.md 'Cat\.Messaging\.Abstractions') >> [ICatMessageNameResolver Interface](ICatMessageNameResolver.md 'Cat\.Messaging\.Abstractions\.ICatMessageNameResolver')

## ICatMessageNameResolver\.GetKind\(Type\) Method

Tells whether a message type is an event or a command message\.

```csharp
Cat.Messaging.Abstractions.CatMessageKind GetKind(System.Type messageType);
```
#### Parameters

<a name='Cat.Messaging.Abstractions.ICatMessageNameResolver.GetKind(System.Type).messageType'></a>

`messageType` [System\.Type](https://learn.microsoft.com/en-us/dotnet/api/system.type 'System\.Type')

The message type\.

#### Returns
[CatMessageKind](CatMessageKind.md 'Cat\.Messaging\.Abstractions\.CatMessageKind')  
The kind of the message\.

#### Exceptions

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
The type is neither an [ICatEventMessage](ICatEventMessage.md 'Cat\.Messaging\.Abstractions\.ICatEventMessage') nor an [ICatCommandMessage](ICatCommandMessage.md 'Cat\.Messaging\.Abstractions\.ICatCommandMessage'), or it is both\.