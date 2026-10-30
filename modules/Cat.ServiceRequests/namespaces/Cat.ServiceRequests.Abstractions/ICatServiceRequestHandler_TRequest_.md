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
            <img src='../../../../resources/logo/CatLogo-RoundedCorners-320x160.png' alt='' width='200' style='float: right;'/>
        </td>
    </tr>
    <tr>
        <td colspan='6' markdown='1' style='padding-left: 0; padding-right: 0; padding-top: 15px; padding-bottom: 0; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>

|&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[CAT.SERVICEREQUESTS](../../README.md)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.ServiceRequests\.Abstractions Assembly](index.md 'index') >> [Cat\.ServiceRequests\.Abstractions Namespace](Cat.ServiceRequests.Abstractions.md 'Cat\.ServiceRequests\.Abstractions')

## ICatServiceRequestHandler\<TRequest\> Interface

Handles one kind of service request that returns no payload\.
Implement it once per request type\. The module finds and registers it for you\.

```csharp
public interface ICatServiceRequestHandler<in TRequest>
    where TRequest : class, Cat.ServiceRequests.Abstractions.ICatServiceRequest
```
#### Type parameters

<a name='Cat.ServiceRequests.Abstractions.ICatServiceRequestHandler_TRequest_.TRequest'></a>

`TRequest`

The service request this handler can process\.

| Methods | |
| :--- | :--- |
| [HandleAsync\(TRequest, CancellationToken\)](ICatServiceRequestHandler_TRequest_.HandleAsync.UKV07R1O984838HBFKEWL7KL.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler\<TRequest\>\.HandleAsync\(TRequest, System\.Threading\.CancellationToken\)') | Runs the service request\. |
