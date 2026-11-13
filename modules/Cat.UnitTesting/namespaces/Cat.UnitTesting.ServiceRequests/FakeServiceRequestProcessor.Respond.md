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

## FakeServiceRequestProcessor\.Respond Method

| Overloads | |
| :--- | :--- |
| [Respond&lt;TRequest,TResponse&gt;\(ICatResponse&lt;TResponse&gt;\)](FakeServiceRequestProcessor.Respond.md#Cat.UnitTesting.ServiceRequests.FakeServiceRequestProcessor.Respond_TRequest,TResponse_(Cat.Responses.Abstractions.ICatResponse_TResponse_) 'Cat\.UnitTesting\.ServiceRequests\.FakeServiceRequestProcessor\.Respond\<TRequest,TResponse\>\(Cat\.Responses\.Abstractions\.ICatResponse\<TResponse\>\)') | Sets the response for a service request with a result\. |
| [Respond&lt;TRequest,TResponse&gt;\(Func&lt;TRequest,ICatResponse&lt;TResponse&gt;&gt;\)](FakeServiceRequestProcessor.Respond.md#Cat.UnitTesting.ServiceRequests.FakeServiceRequestProcessor.Respond_TRequest,TResponse_(System.Func_TRequest,Cat.Responses.Abstractions.ICatResponse_TResponse__) 'Cat\.UnitTesting\.ServiceRequests\.FakeServiceRequestProcessor\.Respond\<TRequest,TResponse\>\(System\.Func\<TRequest,Cat\.Responses\.Abstractions\.ICatResponse\<TResponse\>\>\)') | Sets the response for a service request with a result, built from the request\. |
| [Respond&lt;TRequest&gt;\(ICatResponse\)](FakeServiceRequestProcessor.Respond.md#Cat.UnitTesting.ServiceRequests.FakeServiceRequestProcessor.Respond_TRequest_(Cat.Responses.Abstractions.ICatResponse) 'Cat\.UnitTesting\.ServiceRequests\.FakeServiceRequestProcessor\.Respond\<TRequest\>\(Cat\.Responses\.Abstractions\.ICatResponse\)') | Sets the response for a service request without a result\. |
| [Respond&lt;TRequest&gt;\(Func&lt;TRequest,ICatResponse&gt;\)](FakeServiceRequestProcessor.Respond.md#Cat.UnitTesting.ServiceRequests.FakeServiceRequestProcessor.Respond_TRequest_(System.Func_TRequest,Cat.Responses.Abstractions.ICatResponse_) 'Cat\.UnitTesting\.ServiceRequests\.FakeServiceRequestProcessor\.Respond\<TRequest\>\(System\.Func\<TRequest,Cat\.Responses\.Abstractions\.ICatResponse\>\)') | Sets the response for a service request without a result, built from the request\. |

<a name='Cat.UnitTesting.ServiceRequests.FakeServiceRequestProcessor.Respond_TRequest,TResponse_(Cat.Responses.Abstractions.ICatResponse_TResponse_)'></a>

## FakeServiceRequestProcessor\.Respond\<TRequest,TResponse\>\(ICatResponse\<TResponse\>\) Method

Sets the response for a service request with a result\.

```csharp
public Cat.UnitTesting.ServiceRequests.FakeServiceRequestProcessor Respond<TRequest,TResponse>(Cat.Responses.Abstractions.ICatResponse<TResponse> response)
    where TRequest : Cat.ServiceRequests.Abstractions.ICatServiceRequest<TResponse>;
```
#### Type parameters

<a name='Cat.UnitTesting.ServiceRequests.FakeServiceRequestProcessor.Respond_TRequest,TResponse_(Cat.Responses.Abstractions.ICatResponse_TResponse_).TRequest'></a>

`TRequest`

The service request type\.

<a name='Cat.UnitTesting.ServiceRequests.FakeServiceRequestProcessor.Respond_TRequest,TResponse_(Cat.Responses.Abstractions.ICatResponse_TResponse_).TResponse'></a>

`TResponse`

The type of the result\.
#### Parameters

<a name='Cat.UnitTesting.ServiceRequests.FakeServiceRequestProcessor.Respond_TRequest,TResponse_(Cat.Responses.Abstractions.ICatResponse_TResponse_).response'></a>

`response` [Cat\.Responses\.Abstractions\.ICatResponse&lt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[TResponse](FakeServiceRequestProcessor.Respond.md#Cat.UnitTesting.ServiceRequests.FakeServiceRequestProcessor.Respond_TRequest,TResponse_(Cat.Responses.Abstractions.ICatResponse_TResponse_).TResponse 'Cat\.UnitTesting\.ServiceRequests\.FakeServiceRequestProcessor\.Respond\<TRequest,TResponse\>\(Cat\.Responses\.Abstractions\.ICatResponse\<TResponse\>\)\.TResponse')[&gt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')

The response every request of this type gets\.

#### Returns
[FakeServiceRequestProcessor](FakeServiceRequestProcessor.md 'Cat\.UnitTesting\.ServiceRequests\.FakeServiceRequestProcessor')  
The fake, so calls can be chained\.

<a name='Cat.UnitTesting.ServiceRequests.FakeServiceRequestProcessor.Respond_TRequest,TResponse_(System.Func_TRequest,Cat.Responses.Abstractions.ICatResponse_TResponse__)'></a>

## FakeServiceRequestProcessor\.Respond\<TRequest,TResponse\>\(Func\<TRequest,ICatResponse\<TResponse\>\>\) Method

Sets the response for a service request with a result, built from the request\.

```csharp
public Cat.UnitTesting.ServiceRequests.FakeServiceRequestProcessor Respond<TRequest,TResponse>(System.Func<TRequest,Cat.Responses.Abstractions.ICatResponse<TResponse>> respond)
    where TRequest : Cat.ServiceRequests.Abstractions.ICatServiceRequest<TResponse>;
```
#### Type parameters

<a name='Cat.UnitTesting.ServiceRequests.FakeServiceRequestProcessor.Respond_TRequest,TResponse_(System.Func_TRequest,Cat.Responses.Abstractions.ICatResponse_TResponse__).TRequest'></a>

`TRequest`

The service request type\.

<a name='Cat.UnitTesting.ServiceRequests.FakeServiceRequestProcessor.Respond_TRequest,TResponse_(System.Func_TRequest,Cat.Responses.Abstractions.ICatResponse_TResponse__).TResponse'></a>

`TResponse`

The type of the result\.
#### Parameters

<a name='Cat.UnitTesting.ServiceRequests.FakeServiceRequestProcessor.Respond_TRequest,TResponse_(System.Func_TRequest,Cat.Responses.Abstractions.ICatResponse_TResponse__).respond'></a>

`respond` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TRequest](FakeServiceRequestProcessor.Respond.md#Cat.UnitTesting.ServiceRequests.FakeServiceRequestProcessor.Respond_TRequest,TResponse_(System.Func_TRequest,Cat.Responses.Abstractions.ICatResponse_TResponse__).TRequest 'Cat\.UnitTesting\.ServiceRequests\.FakeServiceRequestProcessor\.Respond\<TRequest,TResponse\>\(System\.Func\<TRequest,Cat\.Responses\.Abstractions\.ICatResponse\<TResponse\>\>\)\.TRequest')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[Cat\.Responses\.Abstractions\.ICatResponse&lt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[TResponse](FakeServiceRequestProcessor.Respond.md#Cat.UnitTesting.ServiceRequests.FakeServiceRequestProcessor.Respond_TRequest,TResponse_(System.Func_TRequest,Cat.Responses.Abstractions.ICatResponse_TResponse__).TResponse 'Cat\.UnitTesting\.ServiceRequests\.FakeServiceRequestProcessor\.Respond\<TRequest,TResponse\>\(System\.Func\<TRequest,Cat\.Responses\.Abstractions\.ICatResponse\<TResponse\>\>\)\.TResponse')[&gt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

Builds the response from the request\.

#### Returns
[FakeServiceRequestProcessor](FakeServiceRequestProcessor.md 'Cat\.UnitTesting\.ServiceRequests\.FakeServiceRequestProcessor')  
The fake, so calls can be chained\.

<a name='Cat.UnitTesting.ServiceRequests.FakeServiceRequestProcessor.Respond_TRequest_(Cat.Responses.Abstractions.ICatResponse)'></a>

## FakeServiceRequestProcessor\.Respond\<TRequest\>\(ICatResponse\) Method

Sets the response for a service request without a result\.

```csharp
public Cat.UnitTesting.ServiceRequests.FakeServiceRequestProcessor Respond<TRequest>(Cat.Responses.Abstractions.ICatResponse response)
    where TRequest : Cat.ServiceRequests.Abstractions.ICatServiceRequest;
```
#### Type parameters

<a name='Cat.UnitTesting.ServiceRequests.FakeServiceRequestProcessor.Respond_TRequest_(Cat.Responses.Abstractions.ICatResponse).TRequest'></a>

`TRequest`

The service request type\.
#### Parameters

<a name='Cat.UnitTesting.ServiceRequests.FakeServiceRequestProcessor.Respond_TRequest_(Cat.Responses.Abstractions.ICatResponse).response'></a>

`response` [ICatResponse](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse')

The response every request of this type gets\.

#### Returns
[FakeServiceRequestProcessor](FakeServiceRequestProcessor.md 'Cat\.UnitTesting\.ServiceRequests\.FakeServiceRequestProcessor')  
The fake, so calls can be chained\.

<a name='Cat.UnitTesting.ServiceRequests.FakeServiceRequestProcessor.Respond_TRequest_(System.Func_TRequest,Cat.Responses.Abstractions.ICatResponse_)'></a>

## FakeServiceRequestProcessor\.Respond\<TRequest\>\(Func\<TRequest,ICatResponse\>\) Method

Sets the response for a service request without a result, built from the request\.

```csharp
public Cat.UnitTesting.ServiceRequests.FakeServiceRequestProcessor Respond<TRequest>(System.Func<TRequest,Cat.Responses.Abstractions.ICatResponse> respond)
    where TRequest : Cat.ServiceRequests.Abstractions.ICatServiceRequest;
```
#### Type parameters

<a name='Cat.UnitTesting.ServiceRequests.FakeServiceRequestProcessor.Respond_TRequest_(System.Func_TRequest,Cat.Responses.Abstractions.ICatResponse_).TRequest'></a>

`TRequest`

The service request type\.
#### Parameters

<a name='Cat.UnitTesting.ServiceRequests.FakeServiceRequestProcessor.Respond_TRequest_(System.Func_TRequest,Cat.Responses.Abstractions.ICatResponse_).respond'></a>

`respond` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TRequest](FakeServiceRequestProcessor.Respond.md#Cat.UnitTesting.ServiceRequests.FakeServiceRequestProcessor.Respond_TRequest_(System.Func_TRequest,Cat.Responses.Abstractions.ICatResponse_).TRequest 'Cat\.UnitTesting\.ServiceRequests\.FakeServiceRequestProcessor\.Respond\<TRequest\>\(System\.Func\<TRequest,Cat\.Responses\.Abstractions\.ICatResponse\>\)\.TRequest')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[ICatResponse](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

Builds the response from the request\.

#### Returns
[FakeServiceRequestProcessor](FakeServiceRequestProcessor.md 'Cat\.UnitTesting\.ServiceRequests\.FakeServiceRequestProcessor')  
The fake, so calls can be chained\.