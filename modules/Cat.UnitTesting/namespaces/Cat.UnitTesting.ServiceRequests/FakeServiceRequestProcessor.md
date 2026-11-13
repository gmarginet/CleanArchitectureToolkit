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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.UNITTESTING](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.UnitTesting\.ServiceRequests Assembly](index.md 'index') >> [Cat\.UnitTesting\.ServiceRequests Namespace](Cat.UnitTesting.ServiceRequests.md 'Cat\.UnitTesting\.ServiceRequests')

## FakeServiceRequestProcessor Class

A service request processor for unit tests\. It records every service request and returns what the test says\.
It works like the fake command processor: a request without a result gets [DefaultResponse](FakeServiceRequestProcessor.DefaultResponse.md 'Cat\.UnitTesting\.ServiceRequests\.FakeServiceRequestProcessor\.DefaultResponse'),
and a request with a result needs a set up response\.

```csharp
public class FakeServiceRequestProcessor : Cat.ServiceRequests.Abstractions.ICatServiceRequestProcessor
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → FakeServiceRequestProcessor

Implements [ICatServiceRequestProcessor](../../../Cat.ServiceRequests/namespaces/Cat.ServiceRequests.Abstractions/ICatServiceRequestProcessor.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestProcessor')

| Fields | |
| :--- | :--- |
| [\_responses](FakeServiceRequestProcessor._responses.md 'Cat\.UnitTesting\.ServiceRequests\.FakeServiceRequestProcessor\.\_responses') | |

| Properties | |
| :--- | :--- |
| [DefaultResponse](FakeServiceRequestProcessor.DefaultResponse.md 'Cat\.UnitTesting\.ServiceRequests\.FakeServiceRequestProcessor\.DefaultResponse') | The response of a service request without a result when the test set up nothing for its type\. It starts as [Ok\(\)](../../../Cat.Responses/namespaces/Cat.Responses/CatResponse.Ok.md#Cat.Responses.CatResponse.Ok() 'Cat\.Responses\.CatResponse\.Ok')\. |
| [Requests](FakeServiceRequestProcessor.Requests.md 'Cat\.UnitTesting\.ServiceRequests\.FakeServiceRequestProcessor\.Requests') | Every service request that was processed, in order\. It holds requests with and without a result\. |

| Methods | |
| :--- | :--- |
| [Of&lt;T&gt;\(\)](FakeServiceRequestProcessor.Of_T_().md 'Cat\.UnitTesting\.ServiceRequests\.FakeServiceRequestProcessor\.Of\<T\>\(\)') | Gives the processed service requests of one type, in order\. |
| [Process\(ICatServiceRequest\)](FakeServiceRequestProcessor.Process.md#Cat.UnitTesting.ServiceRequests.FakeServiceRequestProcessor.Process(Cat.ServiceRequests.Abstractions.ICatServiceRequest) 'Cat\.UnitTesting\.ServiceRequests\.FakeServiceRequestProcessor\.Process\(Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest\)') | Runs a service request that returns no payload and blocks until it finishes\. Prefer [ProcessAsync\(ICatServiceRequest, CancellationToken\)](../../../Cat.ServiceRequests/namespaces/Cat.ServiceRequests.Abstractions/ICatServiceRequestProcessor.ProcessAsync.md#Cat.ServiceRequests.Abstractions.ICatServiceRequestProcessor.ProcessAsync(Cat.ServiceRequests.Abstractions.ICatServiceRequest,System.Threading.CancellationToken) 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestProcessor\.ProcessAsync\(Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest,System\.Threading\.CancellationToken\)') when you can\. |
| [Process&lt;TResponse&gt;\(ICatServiceRequest&lt;TResponse&gt;\)](FakeServiceRequestProcessor.Process.md#Cat.UnitTesting.ServiceRequests.FakeServiceRequestProcessor.Process_TResponse_(Cat.ServiceRequests.Abstractions.ICatServiceRequest_TResponse_) 'Cat\.UnitTesting\.ServiceRequests\.FakeServiceRequestProcessor\.Process\<TResponse\>\(Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest\<TResponse\>\)') | Runs a service request that returns a payload and blocks until it finishes\. Prefer [ProcessAsync&lt;TResponse&gt;\(ICatServiceRequest&lt;TResponse&gt;, CancellationToken\)](../../../Cat.ServiceRequests/namespaces/Cat.ServiceRequests.Abstractions/ICatServiceRequestProcessor.ProcessAsync.md#Cat.ServiceRequests.Abstractions.ICatServiceRequestProcessor.ProcessAsync_TResponse_(Cat.ServiceRequests.Abstractions.ICatServiceRequest_TResponse_,System.Threading.CancellationToken) 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestProcessor\.ProcessAsync\`\`1\(Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest\{\`\`0\},System\.Threading\.CancellationToken\)') when you can\. |
| [ProcessAsync\(ICatServiceRequest, CancellationToken\)](FakeServiceRequestProcessor.ProcessAsync.md#Cat.UnitTesting.ServiceRequests.FakeServiceRequestProcessor.ProcessAsync(Cat.ServiceRequests.Abstractions.ICatServiceRequest,System.Threading.CancellationToken) 'Cat\.UnitTesting\.ServiceRequests\.FakeServiceRequestProcessor\.ProcessAsync\(Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest, System\.Threading\.CancellationToken\)') | Runs a service request that returns no payload\. |
| [ProcessAsync&lt;TResponse&gt;\(ICatServiceRequest&lt;TResponse&gt;, CancellationToken\)](FakeServiceRequestProcessor.ProcessAsync.md#Cat.UnitTesting.ServiceRequests.FakeServiceRequestProcessor.ProcessAsync_TResponse_(Cat.ServiceRequests.Abstractions.ICatServiceRequest_TResponse_,System.Threading.CancellationToken) 'Cat\.UnitTesting\.ServiceRequests\.FakeServiceRequestProcessor\.ProcessAsync\<TResponse\>\(Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest\<TResponse\>, System\.Threading\.CancellationToken\)') | Runs a service request that returns a payload\. |
| [Reset\(\)](FakeServiceRequestProcessor.Reset().md 'Cat\.UnitTesting\.ServiceRequests\.FakeServiceRequestProcessor\.Reset\(\)') | Clears the recorded requests, the set up responses and the default response\. |
| [Respond&lt;TRequest,TResponse&gt;\(ICatResponse&lt;TResponse&gt;\)](FakeServiceRequestProcessor.Respond.md#Cat.UnitTesting.ServiceRequests.FakeServiceRequestProcessor.Respond_TRequest,TResponse_(Cat.Responses.Abstractions.ICatResponse_TResponse_) 'Cat\.UnitTesting\.ServiceRequests\.FakeServiceRequestProcessor\.Respond\<TRequest,TResponse\>\(Cat\.Responses\.Abstractions\.ICatResponse\<TResponse\>\)') | Sets the response for a service request with a result\. |
| [Respond&lt;TRequest,TResponse&gt;\(Func&lt;TRequest,ICatResponse&lt;TResponse&gt;&gt;\)](FakeServiceRequestProcessor.Respond.md#Cat.UnitTesting.ServiceRequests.FakeServiceRequestProcessor.Respond_TRequest,TResponse_(System.Func_TRequest,Cat.Responses.Abstractions.ICatResponse_TResponse__) 'Cat\.UnitTesting\.ServiceRequests\.FakeServiceRequestProcessor\.Respond\<TRequest,TResponse\>\(System\.Func\<TRequest,Cat\.Responses\.Abstractions\.ICatResponse\<TResponse\>\>\)') | Sets the response for a service request with a result, built from the request\. |
| [Respond&lt;TRequest&gt;\(ICatResponse\)](FakeServiceRequestProcessor.Respond.md#Cat.UnitTesting.ServiceRequests.FakeServiceRequestProcessor.Respond_TRequest_(Cat.Responses.Abstractions.ICatResponse) 'Cat\.UnitTesting\.ServiceRequests\.FakeServiceRequestProcessor\.Respond\<TRequest\>\(Cat\.Responses\.Abstractions\.ICatResponse\)') | Sets the response for a service request without a result\. |
| [Respond&lt;TRequest&gt;\(Func&lt;TRequest,ICatResponse&gt;\)](FakeServiceRequestProcessor.Respond.md#Cat.UnitTesting.ServiceRequests.FakeServiceRequestProcessor.Respond_TRequest_(System.Func_TRequest,Cat.Responses.Abstractions.ICatResponse_) 'Cat\.UnitTesting\.ServiceRequests\.FakeServiceRequestProcessor\.Respond\<TRequest\>\(System\.Func\<TRequest,Cat\.Responses\.Abstractions\.ICatResponse\>\)') | Sets the response for a service request without a result, built from the request\. |
