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
  
##### >> [Cat\.UnitTesting\.ServiceRequests Assembly](index.md 'index') >> [Cat\.UnitTesting\.ServiceRequests Namespace](Cat.UnitTesting.ServiceRequests.md 'Cat\.UnitTesting\.ServiceRequests') >> [FakeServiceRequestProcessor Class](FakeServiceRequestProcessor.md 'Cat\.UnitTesting\.ServiceRequests\.FakeServiceRequestProcessor')

## FakeServiceRequestProcessor\.Process Method

| Overloads | |
| :--- | :--- |
| [Process\(ICatServiceRequest\)](FakeServiceRequestProcessor.Process.md#Cat.UnitTesting.ServiceRequests.FakeServiceRequestProcessor.Process(Cat.ServiceRequests.Abstractions.ICatServiceRequest) 'Cat\.UnitTesting\.ServiceRequests\.FakeServiceRequestProcessor\.Process\(Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest\)') | Runs a service request that returns no payload and blocks until it finishes\. Prefer [ProcessAsync\(ICatServiceRequest, CancellationToken\)](../../../Cat.ServiceRequests/namespaces/Cat.ServiceRequests.Abstractions/ICatServiceRequestProcessor.ProcessAsync.md#Cat.ServiceRequests.Abstractions.ICatServiceRequestProcessor.ProcessAsync(Cat.ServiceRequests.Abstractions.ICatServiceRequest,System.Threading.CancellationToken) 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestProcessor\.ProcessAsync\(Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest,System\.Threading\.CancellationToken\)') when you can\. |
| [Process&lt;TResponse&gt;\(ICatServiceRequest&lt;TResponse&gt;\)](FakeServiceRequestProcessor.Process.md#Cat.UnitTesting.ServiceRequests.FakeServiceRequestProcessor.Process_TResponse_(Cat.ServiceRequests.Abstractions.ICatServiceRequest_TResponse_) 'Cat\.UnitTesting\.ServiceRequests\.FakeServiceRequestProcessor\.Process\<TResponse\>\(Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest\<TResponse\>\)') | Runs a service request that returns a payload and blocks until it finishes\. Prefer [ProcessAsync&lt;TResponse&gt;\(ICatServiceRequest&lt;TResponse&gt;, CancellationToken\)](../../../Cat.ServiceRequests/namespaces/Cat.ServiceRequests.Abstractions/ICatServiceRequestProcessor.ProcessAsync.md#Cat.ServiceRequests.Abstractions.ICatServiceRequestProcessor.ProcessAsync_TResponse_(Cat.ServiceRequests.Abstractions.ICatServiceRequest_TResponse_,System.Threading.CancellationToken) 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestProcessor\.ProcessAsync\`\`1\(Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest\{\`\`0\},System\.Threading\.CancellationToken\)') when you can\. |

<a name='Cat.UnitTesting.ServiceRequests.FakeServiceRequestProcessor.Process(Cat.ServiceRequests.Abstractions.ICatServiceRequest)'></a>

## FakeServiceRequestProcessor\.Process\(ICatServiceRequest\) Method

Runs a service request that returns no payload and blocks until it finishes\.
Prefer [ProcessAsync\(ICatServiceRequest, CancellationToken\)](../../../Cat.ServiceRequests/namespaces/Cat.ServiceRequests.Abstractions/ICatServiceRequestProcessor.ProcessAsync.md#Cat.ServiceRequests.Abstractions.ICatServiceRequestProcessor.ProcessAsync(Cat.ServiceRequests.Abstractions.ICatServiceRequest,System.Threading.CancellationToken) 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestProcessor\.ProcessAsync\(Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest,System\.Threading\.CancellationToken\)') when you can\.

```csharp
public Cat.Responses.Abstractions.ICatResponse Process(Cat.ServiceRequests.Abstractions.ICatServiceRequest catServiceRequest);
```
#### Parameters

<a name='Cat.UnitTesting.ServiceRequests.FakeServiceRequestProcessor.Process(Cat.ServiceRequests.Abstractions.ICatServiceRequest).catServiceRequest'></a>

`catServiceRequest` [ICatServiceRequest](../../../Cat.ServiceRequests/namespaces/Cat.ServiceRequests.Abstractions/ICatServiceRequest.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest')

The request to run\.

Implements [Process\(ICatServiceRequest\)](../../../Cat.ServiceRequests/namespaces/Cat.ServiceRequests.Abstractions/ICatServiceRequestProcessor.Process.md#Cat.ServiceRequests.Abstractions.ICatServiceRequestProcessor.Process(Cat.ServiceRequests.Abstractions.ICatServiceRequest) 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestProcessor\.Process\(Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest\)')

#### Returns
[ICatResponse](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse')  
The response of the handler\.

<a name='Cat.UnitTesting.ServiceRequests.FakeServiceRequestProcessor.Process_TResponse_(Cat.ServiceRequests.Abstractions.ICatServiceRequest_TResponse_)'></a>

## FakeServiceRequestProcessor\.Process\<TResponse\>\(ICatServiceRequest\<TResponse\>\) Method

Runs a service request that returns a payload and blocks until it finishes\.
Prefer [ProcessAsync&lt;TResponse&gt;\(ICatServiceRequest&lt;TResponse&gt;, CancellationToken\)](../../../Cat.ServiceRequests/namespaces/Cat.ServiceRequests.Abstractions/ICatServiceRequestProcessor.ProcessAsync.md#Cat.ServiceRequests.Abstractions.ICatServiceRequestProcessor.ProcessAsync_TResponse_(Cat.ServiceRequests.Abstractions.ICatServiceRequest_TResponse_,System.Threading.CancellationToken) 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestProcessor\.ProcessAsync\`\`1\(Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest\{\`\`0\},System\.Threading\.CancellationToken\)') when you can\.

```csharp
public Cat.Responses.Abstractions.ICatResponse<TResponse> Process<TResponse>(Cat.ServiceRequests.Abstractions.ICatServiceRequest<TResponse> catServiceRequest);
```
#### Type parameters

<a name='Cat.UnitTesting.ServiceRequests.FakeServiceRequestProcessor.Process_TResponse_(Cat.ServiceRequests.Abstractions.ICatServiceRequest_TResponse_).TResponse'></a>

`TResponse`

The type of the payload\.
#### Parameters

<a name='Cat.UnitTesting.ServiceRequests.FakeServiceRequestProcessor.Process_TResponse_(Cat.ServiceRequests.Abstractions.ICatServiceRequest_TResponse_).catServiceRequest'></a>

`catServiceRequest` [Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest&lt;](../../../Cat.ServiceRequests/namespaces/Cat.ServiceRequests.Abstractions/ICatServiceRequest_TResponse_.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest\`1')[TResponse](FakeServiceRequestProcessor.Process.md#Cat.UnitTesting.ServiceRequests.FakeServiceRequestProcessor.Process_TResponse_(Cat.ServiceRequests.Abstractions.ICatServiceRequest_TResponse_).TResponse 'Cat\.UnitTesting\.ServiceRequests\.FakeServiceRequestProcessor\.Process\<TResponse\>\(Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest\<TResponse\>\)\.TResponse')[&gt;](../../../Cat.ServiceRequests/namespaces/Cat.ServiceRequests.Abstractions/ICatServiceRequest_TResponse_.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest\`1')

The request to run\.

Implements [Process&lt;TResponse&gt;\(ICatServiceRequest&lt;TResponse&gt;\)](../../../Cat.ServiceRequests/namespaces/Cat.ServiceRequests.Abstractions/ICatServiceRequestProcessor.Process.md#Cat.ServiceRequests.Abstractions.ICatServiceRequestProcessor.Process_TResponse_(Cat.ServiceRequests.Abstractions.ICatServiceRequest_TResponse_) 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestProcessor\.Process\`\`1\(Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest\{\`\`0\}\)')

#### Returns
[Cat\.Responses\.Abstractions\.ICatResponse&lt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[TResponse](FakeServiceRequestProcessor.Process.md#Cat.UnitTesting.ServiceRequests.FakeServiceRequestProcessor.Process_TResponse_(Cat.ServiceRequests.Abstractions.ICatServiceRequest_TResponse_).TResponse 'Cat\.UnitTesting\.ServiceRequests\.FakeServiceRequestProcessor\.Process\<TResponse\>\(Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest\<TResponse\>\)\.TResponse')[&gt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')  
The response of the handler, with the payload when it succeeded\.