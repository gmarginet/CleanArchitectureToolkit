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

## SystemTextJsonMessageSerializer Class

[ICatMessageSerializer](ICatMessageSerializer.md 'Cat\.Messaging\.ICatMessageSerializer') on System\.Text\.Json with the web defaults\.

```csharp
internal sealed class SystemTextJsonMessageSerializer
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → SystemTextJsonMessageSerializer

| Fields | |
| :--- | :--- |
| [Options](SystemTextJsonMessageSerializer.Options.md 'Cat\.Messaging\.SystemTextJsonMessageSerializer\.Options') | |

| Properties | |
| :--- | :--- |
| [ContentType](SystemTextJsonMessageSerializer.ContentType.md 'Cat\.Messaging\.SystemTextJsonMessageSerializer\.ContentType') | The content type that goes on every message, so a receiver knows how to read the body\. |

| Methods | |
| :--- | :--- |
| [Serialize\(object, Type\)](SystemTextJsonMessageSerializer.Serialize.0LW0X09TDZXMUFM913QN7HQUE.md 'Cat\.Messaging\.SystemTextJsonMessageSerializer\.Serialize\(object, System\.Type\)') | Serializes a message with its runtime type, so the properties of a derived type are not lost\. |
