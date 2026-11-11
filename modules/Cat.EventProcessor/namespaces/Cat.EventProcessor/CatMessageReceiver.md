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

## CatMessageReceiver Class

Default [ICatMessageReceiver](../../../Cat.EventProcessor/namespaces/Cat.EventProcessor.Abstractions/ICatMessageReceiver.md 'Cat\.EventProcessor\.Abstractions\.ICatMessageReceiver')\.
The message is the service request itself, so there is no mapping step\.

```csharp
internal sealed class CatMessageReceiver : Cat.EventProcessor.Abstractions.ICatMessageReceiver
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatMessageReceiver

Implements [ICatMessageReceiver](../../../Cat.EventProcessor/namespaces/Cat.EventProcessor.Abstractions/ICatMessageReceiver.md 'Cat\.EventProcessor\.Abstractions\.ICatMessageReceiver')

| Constructors | |
| :--- | :--- |
| [CatMessageReceiver\(IServiceScopeFactory, ICatReceiveRegistry\)](CatMessageReceiver..ctor.VN7OKZXDRMLEW4KHL6MVCRJA.md 'Cat\.EventProcessor\.CatMessageReceiver\.CatMessageReceiver\(Microsoft\.Extensions\.DependencyInjection\.IServiceScopeFactory, Cat\.EventProcessor\.Abstractions\.ICatReceiveRegistry\)') | Creates the receiver\. |

| Fields | |
| :--- | :--- |
| [JsonOptions](CatMessageReceiver.JsonOptions.md 'Cat\.EventProcessor\.CatMessageReceiver\.JsonOptions') | |
| [\_registry](CatMessageReceiver._registry.md 'Cat\.EventProcessor\.CatMessageReceiver\.\_registry') | |
| [\_scopeFactory](CatMessageReceiver._scopeFactory.md 'Cat\.EventProcessor\.CatMessageReceiver\.\_scopeFactory') | |

| Methods | |
| :--- | :--- |
| [FindOptions\(Type\)](CatMessageReceiver.FindOptions.8TDFTR0NF9XO6ODARQMCYSZW1.md 'Cat\.EventProcessor\.CatMessageReceiver\.FindOptions\(System\.Type\)') | |
| [ReceiveAsync\(Type, CatIncomingMessage, CancellationToken\)](CatMessageReceiver.ReceiveAsync.TZBJRK81OY0USJ9WUK29A6AZ9.md 'Cat\.EventProcessor\.CatMessageReceiver\.ReceiveAsync\(System\.Type, Cat\.EventProcessor\.Abstractions\.CatIncomingMessage, System\.Threading\.CancellationToken\)') | Handles one message\. It never throws for a failure of the handler\. It returns a result instead\. |
