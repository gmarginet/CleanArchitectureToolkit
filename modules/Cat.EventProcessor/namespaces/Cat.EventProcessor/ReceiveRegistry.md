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
  
##### >> [Cat\.EventProcessor Assembly](index.md 'index') >> [Cat\.EventProcessor Namespace](Cat.EventProcessor.md 'Cat\.EventProcessor')

## ReceiveRegistry Class

Default [ICatReceiveRegistry](../../../Cat.EventProcessor/namespaces/Cat.EventProcessor.Abstractions/ICatReceiveRegistry.md 'Cat\.EventProcessor\.Abstractions\.ICatReceiveRegistry')\.

```csharp
internal sealed class ReceiveRegistry : Cat.EventProcessor.Abstractions.ICatReceiveRegistry
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → ReceiveRegistry

Implements [ICatReceiveRegistry](../../../Cat.EventProcessor/namespaces/Cat.EventProcessor.Abstractions/ICatReceiveRegistry.md 'Cat\.EventProcessor\.Abstractions\.ICatReceiveRegistry')

| Constructors | |
| :--- | :--- |
| [ReceiveRegistry\(IReadOnlyList&lt;CatReceiveRegistration&gt;\)](ReceiveRegistry..ctor.41HDQ4S13QOWQ93C0BZPDCUB3.md 'Cat\.EventProcessor\.ReceiveRegistry\.ReceiveRegistry\(System\.Collections\.Generic\.IReadOnlyList\<Cat\.EventProcessor\.Abstractions\.CatReceiveRegistration\>\)') | Creates the registry\. |

| Properties | |
| :--- | :--- |
| [Registrations](ReceiveRegistry.Registrations.md 'Cat\.EventProcessor\.ReceiveRegistry\.Registrations') | The declared message types with their settings\. |
