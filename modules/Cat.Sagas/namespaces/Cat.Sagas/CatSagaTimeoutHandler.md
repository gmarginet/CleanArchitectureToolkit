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

## CatSagaTimeoutHandler Class

The handler for [CatSagaTimeout](CatSagaTimeout.md 'Cat\.Sagas\.CatSagaTimeout')\. It gives the timeout to the dispatcher\.

```csharp
public sealed class CatSagaTimeoutHandler : Cat.ServiceRequests.Abstractions.ICatServiceRequestHandler<Cat.Sagas.CatSagaTimeout>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatSagaTimeoutHandler

Implements [Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler&lt;](../../../Cat.ServiceRequests/namespaces/Cat.ServiceRequests.Abstractions/ICatServiceRequestHandler_TRequest_.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler\`1')[CatSagaTimeout](CatSagaTimeout.md 'Cat\.Sagas\.CatSagaTimeout')[&gt;](../../../Cat.ServiceRequests/namespaces/Cat.ServiceRequests.Abstractions/ICatServiceRequestHandler_TRequest_.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler\`1')

| Constructors | |
| :--- | :--- |
| [CatSagaTimeoutHandler\(ICatSagaDispatcher\)](CatSagaTimeoutHandler..ctor.JY9GEFVU7AMR5VL8CVS3O8HX2.md 'Cat\.Sagas\.CatSagaTimeoutHandler\.CatSagaTimeoutHandler\(Cat\.Sagas\.Abstractions\.ICatSagaDispatcher\)') | Creates the handler\. |

| Fields | |
| :--- | :--- |
| [\_dispatcher](CatSagaTimeoutHandler._dispatcher.md 'Cat\.Sagas\.CatSagaTimeoutHandler\.\_dispatcher') | |

| Methods | |
| :--- | :--- |
| [HandleAsync\(CatSagaTimeout, CancellationToken\)](CatSagaTimeoutHandler.HandleAsync.ZTP6NXMDC1MQW1Y5WDLXJRNA3.md 'Cat\.Sagas\.CatSagaTimeoutHandler\.HandleAsync\(Cat\.Sagas\.CatSagaTimeout, System\.Threading\.CancellationToken\)') | |
