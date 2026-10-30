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

|&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[CAT.SERVICEREQUESTS](../../README.md)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.ServiceRequests\.Decorators\.ActivitySource Assembly](index.md 'index') >> [Cat\.ServiceRequests\.Decorators\.ActivitySource Namespace](Cat.ServiceRequests.Decorators.ActivitySource.md 'Cat\.ServiceRequests\.Decorators\.ActivitySource') >> [ActivitySourceDecorator Class](ActivitySourceDecorator.md 'Cat\.ServiceRequests\.Decorators\.ActivitySource\.ActivitySourceDecorator')

## ActivitySourceDecorator\.CatServiceRequestHandler\<TRequest\> Class

Traces a handler that returns no payload\.

```csharp
internal sealed class ActivitySourceDecorator.CatServiceRequestHandler<TRequest> : Cat.ServiceRequests.Abstractions.ICatServiceRequestHandler<TRequest>
    where TRequest : class, Cat.ServiceRequests.Abstractions.ICatServiceRequest
```
#### Type parameters

<a name='Cat.ServiceRequests.Decorators.ActivitySource.ActivitySourceDecorator.CatServiceRequestHandler_TRequest_.TRequest'></a>

`TRequest`

The service request being handled\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatServiceRequestHandler\<TRequest\>

Implements [Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler&lt;](../../../Cat.ServiceRequests/namespaces/Cat.ServiceRequests.Abstractions/ICatServiceRequestHandler_TRequest_.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler\`1')[TRequest](ActivitySourceDecorator.CatServiceRequestHandler_TRequest_.md#Cat.ServiceRequests.Decorators.ActivitySource.ActivitySourceDecorator.CatServiceRequestHandler_TRequest_.TRequest 'Cat\.ServiceRequests\.Decorators\.ActivitySource\.ActivitySourceDecorator\.CatServiceRequestHandler\<TRequest\>\.TRequest')[&gt;](../../../Cat.ServiceRequests/namespaces/Cat.ServiceRequests.Abstractions/ICatServiceRequestHandler_TRequest_.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler\`1')

| Constructors | |
| :--- | :--- |
| [CatServiceRequestHandler\(ICatServiceRequestHandler&lt;TRequest&gt;\)](ActivitySourceDecorator.CatServiceRequestHandler_TRequest_..ctor.AT67T1AK38F2OBE6CWGF1S2UC.md 'Cat\.ServiceRequests\.Decorators\.ActivitySource\.ActivitySourceDecorator\.CatServiceRequestHandler\<TRequest\>\.CatServiceRequestHandler\(Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler\<TRequest\>\)') | Creates the decorator\. |

| Fields | |
| :--- | :--- |
| [\_innerHandler](ActivitySourceDecorator.CatServiceRequestHandler_TRequest_._innerHandler.md 'Cat\.ServiceRequests\.Decorators\.ActivitySource\.ActivitySourceDecorator\.CatServiceRequestHandler\<TRequest\>\.\_innerHandler') | |

| Methods | |
| :--- | :--- |
| [HandleAsync\(TRequest, CancellationToken\)](ActivitySourceDecorator.CatServiceRequestHandler_TRequest_.HandleAsync.6C17YPXQ4XGHMC7CNCJ01N018.md 'Cat\.ServiceRequests\.Decorators\.ActivitySource\.ActivitySourceDecorator\.CatServiceRequestHandler\<TRequest\>\.HandleAsync\(TRequest, System\.Threading\.CancellationToken\)') | Runs the service request\. |
