<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.ServiceRequests](index.md 'index') > [Cat\.ServiceRequests](Cat.ServiceRequests.md 'Cat\.ServiceRequests') > [CatServiceRequestProcessor](CatServiceRequestProcessor.md 'Cat\.ServiceRequests\.CatServiceRequestProcessor')

## CatServiceRequestProcessor\.Process Method

| Overloads | |
| :--- | :--- |
| [Process\(ICatServiceRequest\)](CatServiceRequestProcessor.Process.md#Cat.ServiceRequests.CatServiceRequestProcessor.Process(Cat.ServiceRequests.Abstractions.ICatServiceRequest) 'Cat\.ServiceRequests\.CatServiceRequestProcessor\.Process\(Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest\)') | Runs a service request that returns no payload and blocks until it finishes\. Prefer [ProcessAsync\(ICatServiceRequest, CancellationToken\)](..\Cat.ServiceRequests.Abstractions\ICatServiceRequestProcessor.ProcessAsync.md#Cat.ServiceRequests.Abstractions.ICatServiceRequestProcessor.ProcessAsync(Cat.ServiceRequests.Abstractions.ICatServiceRequest,System.Threading.CancellationToken) 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestProcessor\.ProcessAsync\(Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest,System\.Threading\.CancellationToken\)') when you can\. |
| [Process&lt;TResponse&gt;\(ICatServiceRequest&lt;TResponse&gt;\)](CatServiceRequestProcessor.Process.md#Cat.ServiceRequests.CatServiceRequestProcessor.Process_TResponse_(Cat.ServiceRequests.Abstractions.ICatServiceRequest_TResponse_) 'Cat\.ServiceRequests\.CatServiceRequestProcessor\.Process\<TResponse\>\(Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest\<TResponse\>\)') | Runs a service request that returns a payload and blocks until it finishes\. Prefer [ProcessAsync&lt;TResponse&gt;\(ICatServiceRequest&lt;TResponse&gt;, CancellationToken\)](..\Cat.ServiceRequests.Abstractions\ICatServiceRequestProcessor.ProcessAsync.md#Cat.ServiceRequests.Abstractions.ICatServiceRequestProcessor.ProcessAsync_TResponse_(Cat.ServiceRequests.Abstractions.ICatServiceRequest_TResponse_,System.Threading.CancellationToken) 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestProcessor\.ProcessAsync\`\`1\(Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest\{\`\`0\},System\.Threading\.CancellationToken\)') when you can\. |

<a name='Cat.ServiceRequests.CatServiceRequestProcessor.Process(Cat.ServiceRequests.Abstractions.ICatServiceRequest)'></a>

## CatServiceRequestProcessor\.Process\(ICatServiceRequest\) Method

Runs a service request that returns no payload and blocks until it finishes\.
Prefer [ProcessAsync\(ICatServiceRequest, CancellationToken\)](..\Cat.ServiceRequests.Abstractions\ICatServiceRequestProcessor.ProcessAsync.md#Cat.ServiceRequests.Abstractions.ICatServiceRequestProcessor.ProcessAsync(Cat.ServiceRequests.Abstractions.ICatServiceRequest,System.Threading.CancellationToken) 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestProcessor\.ProcessAsync\(Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest,System\.Threading\.CancellationToken\)') when you can\.

```csharp
public Cat.Responses.Abstractions.ICatResponse Process(Cat.ServiceRequests.Abstractions.ICatServiceRequest catServiceRequest);
```
#### Parameters

<a name='Cat.ServiceRequests.CatServiceRequestProcessor.Process(Cat.ServiceRequests.Abstractions.ICatServiceRequest).catServiceRequest'></a>

`catServiceRequest` [ICatServiceRequest](..\Cat.ServiceRequests.Abstractions\ICatServiceRequest.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest')

The request to run\.

Implements [Process\(ICatServiceRequest\)](..\Cat.ServiceRequests.Abstractions\ICatServiceRequestProcessor.Process.md#Cat.ServiceRequests.Abstractions.ICatServiceRequestProcessor.Process(Cat.ServiceRequests.Abstractions.ICatServiceRequest) 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestProcessor\.Process\(Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest\)')

#### Returns
[ICatResponse](..\Cat.Responses.Abstractions\ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse')  
The response of the handler\.

<a name='Cat.ServiceRequests.CatServiceRequestProcessor.Process_TResponse_(Cat.ServiceRequests.Abstractions.ICatServiceRequest_TResponse_)'></a>

## CatServiceRequestProcessor\.Process\<TResponse\>\(ICatServiceRequest\<TResponse\>\) Method

Runs a service request that returns a payload and blocks until it finishes\.
Prefer [ProcessAsync&lt;TResponse&gt;\(ICatServiceRequest&lt;TResponse&gt;, CancellationToken\)](..\Cat.ServiceRequests.Abstractions\ICatServiceRequestProcessor.ProcessAsync.md#Cat.ServiceRequests.Abstractions.ICatServiceRequestProcessor.ProcessAsync_TResponse_(Cat.ServiceRequests.Abstractions.ICatServiceRequest_TResponse_,System.Threading.CancellationToken) 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestProcessor\.ProcessAsync\`\`1\(Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest\{\`\`0\},System\.Threading\.CancellationToken\)') when you can\.

```csharp
public Cat.Responses.Abstractions.ICatResponse<TResponse> Process<TResponse>(Cat.ServiceRequests.Abstractions.ICatServiceRequest<TResponse> catServiceRequest);
```
#### Type parameters

<a name='Cat.ServiceRequests.CatServiceRequestProcessor.Process_TResponse_(Cat.ServiceRequests.Abstractions.ICatServiceRequest_TResponse_).TResponse'></a>

`TResponse`

The type of the payload\.
#### Parameters

<a name='Cat.ServiceRequests.CatServiceRequestProcessor.Process_TResponse_(Cat.ServiceRequests.Abstractions.ICatServiceRequest_TResponse_).catServiceRequest'></a>

`catServiceRequest` [Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest&lt;](..\Cat.ServiceRequests.Abstractions\ICatServiceRequest_TResponse_.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest\`1')[TResponse](CatServiceRequestProcessor.md#Cat.ServiceRequests.CatServiceRequestProcessor.Process_TResponse_(Cat.ServiceRequests.Abstractions.ICatServiceRequest_TResponse_).TResponse 'Cat\.ServiceRequests\.CatServiceRequestProcessor\.Process\<TResponse\>\(Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest\<TResponse\>\)\.TResponse')[&gt;](..\Cat.ServiceRequests.Abstractions\ICatServiceRequest_TResponse_.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest\`1')

The request to run\.

Implements [Process&lt;TResponse&gt;\(ICatServiceRequest&lt;TResponse&gt;\)](..\Cat.ServiceRequests.Abstractions\ICatServiceRequestProcessor.Process.md#Cat.ServiceRequests.Abstractions.ICatServiceRequestProcessor.Process_TResponse_(Cat.ServiceRequests.Abstractions.ICatServiceRequest_TResponse_) 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestProcessor\.Process\`\`1\(Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest\{\`\`0\}\)')

#### Returns
[Cat\.Responses\.Abstractions\.ICatResponse&lt;](..\Cat.Responses.Abstractions\ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[TResponse](CatServiceRequestProcessor.md#Cat.ServiceRequests.CatServiceRequestProcessor.Process_TResponse_(Cat.ServiceRequests.Abstractions.ICatServiceRequest_TResponse_).TResponse 'Cat\.ServiceRequests\.CatServiceRequestProcessor\.Process\<TResponse\>\(Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest\<TResponse\>\)\.TResponse')[&gt;](..\Cat.Responses.Abstractions\ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')  
The response of the handler, with the payload when it succeeded\.