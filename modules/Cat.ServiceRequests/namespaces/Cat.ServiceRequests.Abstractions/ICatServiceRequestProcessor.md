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
  
##### >> [Cat\.ServiceRequests\.Abstractions Assembly](index.md 'index') >> [Cat\.ServiceRequests\.Abstractions Namespace](Cat.ServiceRequests.Abstractions.md 'Cat\.ServiceRequests\.Abstractions')

## ICatServiceRequestProcessor Interface

Single entry point for running service requests\.
It finds the handler for a request, runs it through the registered decorators and returns the response\.

```csharp
public interface ICatServiceRequestProcessor
```

| Methods | |
| :--- | :--- |
| [Process\(ICatServiceRequest\)](ICatServiceRequestProcessor.Process.md#Cat.ServiceRequests.Abstractions.ICatServiceRequestProcessor.Process(Cat.ServiceRequests.Abstractions.ICatServiceRequest) 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestProcessor\.Process\(Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest\)') | Runs a service request that returns no payload and blocks until it finishes\. Prefer [ProcessAsync\(ICatServiceRequest, CancellationToken\)](ICatServiceRequestProcessor.ProcessAsync.md#Cat.ServiceRequests.Abstractions.ICatServiceRequestProcessor.ProcessAsync(Cat.ServiceRequests.Abstractions.ICatServiceRequest,System.Threading.CancellationToken) 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestProcessor\.ProcessAsync\(Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest, System\.Threading\.CancellationToken\)') when you can\. |
| [Process&lt;TResponse&gt;\(ICatServiceRequest&lt;TResponse&gt;\)](ICatServiceRequestProcessor.Process.md#Cat.ServiceRequests.Abstractions.ICatServiceRequestProcessor.Process_TResponse_(Cat.ServiceRequests.Abstractions.ICatServiceRequest_TResponse_) 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestProcessor\.Process\<TResponse\>\(Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest\<TResponse\>\)') | Runs a service request that returns a payload and blocks until it finishes\. Prefer [ProcessAsync&lt;TResponse&gt;\(ICatServiceRequest&lt;TResponse&gt;, CancellationToken\)](ICatServiceRequestProcessor.ProcessAsync.md#Cat.ServiceRequests.Abstractions.ICatServiceRequestProcessor.ProcessAsync_TResponse_(Cat.ServiceRequests.Abstractions.ICatServiceRequest_TResponse_,System.Threading.CancellationToken) 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestProcessor\.ProcessAsync\<TResponse\>\(Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest\<TResponse\>, System\.Threading\.CancellationToken\)') when you can\. |
| [ProcessAsync\(ICatServiceRequest, CancellationToken\)](ICatServiceRequestProcessor.ProcessAsync.md#Cat.ServiceRequests.Abstractions.ICatServiceRequestProcessor.ProcessAsync(Cat.ServiceRequests.Abstractions.ICatServiceRequest,System.Threading.CancellationToken) 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestProcessor\.ProcessAsync\(Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest, System\.Threading\.CancellationToken\)') | Runs a service request that returns no payload\. |
| [ProcessAsync&lt;TResponse&gt;\(ICatServiceRequest&lt;TResponse&gt;, CancellationToken\)](ICatServiceRequestProcessor.ProcessAsync.md#Cat.ServiceRequests.Abstractions.ICatServiceRequestProcessor.ProcessAsync_TResponse_(Cat.ServiceRequests.Abstractions.ICatServiceRequest_TResponse_,System.Threading.CancellationToken) 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestProcessor\.ProcessAsync\<TResponse\>\(Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest\<TResponse\>, System\.Threading\.CancellationToken\)') | Runs a service request that returns a payload\. |
