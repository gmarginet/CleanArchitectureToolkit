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
  
##### >> [Cat\.ServiceRequests\.Abstractions Assembly](index.md 'index') >> [Cat\.ServiceRequests\.Abstractions Namespace](Cat.ServiceRequests.Abstractions.md 'Cat\.ServiceRequests\.Abstractions') >> [ICatServiceRequestProcessor Interface](ICatServiceRequestProcessor.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestProcessor')

## ICatServiceRequestProcessor\.Process Method

| Overloads | |
| :--- | :--- |
| [Process\(ICatServiceRequest\)](ICatServiceRequestProcessor.Process.md#Cat.ServiceRequests.Abstractions.ICatServiceRequestProcessor.Process(Cat.ServiceRequests.Abstractions.ICatServiceRequest) 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestProcessor\.Process\(Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest\)') | Runs a service request that returns no payload and blocks until it finishes\. Prefer [ProcessAsync\(ICatServiceRequest, CancellationToken\)](ICatServiceRequestProcessor.ProcessAsync.md#Cat.ServiceRequests.Abstractions.ICatServiceRequestProcessor.ProcessAsync(Cat.ServiceRequests.Abstractions.ICatServiceRequest,System.Threading.CancellationToken) 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestProcessor\.ProcessAsync\(Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest, System\.Threading\.CancellationToken\)') when you can\. |
| [Process&lt;TResponse&gt;\(ICatServiceRequest&lt;TResponse&gt;\)](ICatServiceRequestProcessor.Process.md#Cat.ServiceRequests.Abstractions.ICatServiceRequestProcessor.Process_TResponse_(Cat.ServiceRequests.Abstractions.ICatServiceRequest_TResponse_) 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestProcessor\.Process\<TResponse\>\(Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest\<TResponse\>\)') | Runs a service request that returns a payload and blocks until it finishes\. Prefer [ProcessAsync&lt;TResponse&gt;\(ICatServiceRequest&lt;TResponse&gt;, CancellationToken\)](ICatServiceRequestProcessor.ProcessAsync.md#Cat.ServiceRequests.Abstractions.ICatServiceRequestProcessor.ProcessAsync_TResponse_(Cat.ServiceRequests.Abstractions.ICatServiceRequest_TResponse_,System.Threading.CancellationToken) 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestProcessor\.ProcessAsync\<TResponse\>\(Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest\<TResponse\>, System\.Threading\.CancellationToken\)') when you can\. |

<a name='Cat.ServiceRequests.Abstractions.ICatServiceRequestProcessor.Process(Cat.ServiceRequests.Abstractions.ICatServiceRequest)'></a>

## ICatServiceRequestProcessor\.Process\(ICatServiceRequest\) Method

Runs a service request that returns no payload and blocks until it finishes\.
Prefer [ProcessAsync\(ICatServiceRequest, CancellationToken\)](ICatServiceRequestProcessor.ProcessAsync.md#Cat.ServiceRequests.Abstractions.ICatServiceRequestProcessor.ProcessAsync(Cat.ServiceRequests.Abstractions.ICatServiceRequest,System.Threading.CancellationToken) 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestProcessor\.ProcessAsync\(Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest, System\.Threading\.CancellationToken\)') when you can\.

```csharp
Cat.Responses.Abstractions.ICatResponse Process(Cat.ServiceRequests.Abstractions.ICatServiceRequest catServiceRequest);
```
#### Parameters

<a name='Cat.ServiceRequests.Abstractions.ICatServiceRequestProcessor.Process(Cat.ServiceRequests.Abstractions.ICatServiceRequest).catServiceRequest'></a>

`catServiceRequest` [ICatServiceRequest](ICatServiceRequest.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest')

The request to run\.

#### Returns
[ICatResponse](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse')  
The response of the handler\.

<a name='Cat.ServiceRequests.Abstractions.ICatServiceRequestProcessor.Process_TResponse_(Cat.ServiceRequests.Abstractions.ICatServiceRequest_TResponse_)'></a>

## ICatServiceRequestProcessor\.Process\<TResponse\>\(ICatServiceRequest\<TResponse\>\) Method

Runs a service request that returns a payload and blocks until it finishes\.
Prefer [ProcessAsync&lt;TResponse&gt;\(ICatServiceRequest&lt;TResponse&gt;, CancellationToken\)](ICatServiceRequestProcessor.ProcessAsync.md#Cat.ServiceRequests.Abstractions.ICatServiceRequestProcessor.ProcessAsync_TResponse_(Cat.ServiceRequests.Abstractions.ICatServiceRequest_TResponse_,System.Threading.CancellationToken) 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestProcessor\.ProcessAsync\<TResponse\>\(Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest\<TResponse\>, System\.Threading\.CancellationToken\)') when you can\.

```csharp
Cat.Responses.Abstractions.ICatResponse<TResponse> Process<TResponse>(Cat.ServiceRequests.Abstractions.ICatServiceRequest<TResponse> catServiceRequest);
```
#### Type parameters

<a name='Cat.ServiceRequests.Abstractions.ICatServiceRequestProcessor.Process_TResponse_(Cat.ServiceRequests.Abstractions.ICatServiceRequest_TResponse_).TResponse'></a>

`TResponse`

The type of the payload\.
#### Parameters

<a name='Cat.ServiceRequests.Abstractions.ICatServiceRequestProcessor.Process_TResponse_(Cat.ServiceRequests.Abstractions.ICatServiceRequest_TResponse_).catServiceRequest'></a>

`catServiceRequest` [Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest&lt;](ICatServiceRequest_TResponse_.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest\<TResponse\>')[TResponse](ICatServiceRequestProcessor.Process.md#Cat.ServiceRequests.Abstractions.ICatServiceRequestProcessor.Process_TResponse_(Cat.ServiceRequests.Abstractions.ICatServiceRequest_TResponse_).TResponse 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestProcessor\.Process\<TResponse\>\(Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest\<TResponse\>\)\.TResponse')[&gt;](ICatServiceRequest_TResponse_.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest\<TResponse\>')

The request to run\.

#### Returns
[Cat\.Responses\.Abstractions\.ICatResponse&lt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[TResponse](ICatServiceRequestProcessor.Process.md#Cat.ServiceRequests.Abstractions.ICatServiceRequestProcessor.Process_TResponse_(Cat.ServiceRequests.Abstractions.ICatServiceRequest_TResponse_).TResponse 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestProcessor\.Process\<TResponse\>\(Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest\<TResponse\>\)\.TResponse')[&gt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')  
The response of the handler, with the payload when it succeeded\.