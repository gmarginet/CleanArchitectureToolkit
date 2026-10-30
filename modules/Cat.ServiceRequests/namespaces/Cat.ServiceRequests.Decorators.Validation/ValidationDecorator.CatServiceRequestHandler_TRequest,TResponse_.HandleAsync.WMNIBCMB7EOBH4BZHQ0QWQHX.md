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
  
##### >> [Cat\.ServiceRequests\.Decorators\.Validation Assembly](index.md 'index') >> [Cat\.ServiceRequests\.Decorators\.Validation Namespace](Cat.ServiceRequests.Decorators.Validation.md 'Cat\.ServiceRequests\.Decorators\.Validation') >> [ValidationDecorator Class](ValidationDecorator.md 'Cat\.ServiceRequests\.Decorators\.Validation\.ValidationDecorator') >> [CatServiceRequestHandler&lt;TRequest,TResponse&gt; Class](ValidationDecorator.CatServiceRequestHandler_TRequest,TResponse_.md 'Cat\.ServiceRequests\.Decorators\.Validation\.ValidationDecorator\.CatServiceRequestHandler\<TRequest,TResponse\>')

## ValidationDecorator\.CatServiceRequestHandler\<TRequest,TResponse\>\.HandleAsync\(TRequest, CancellationToken\) Method

Runs the service request\.

```csharp
public System.Threading.Tasks.Task<Cat.Responses.Abstractions.ICatResponse<TResponse>> HandleAsync(TRequest serviceRequest, System.Threading.CancellationToken ct=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Cat.ServiceRequests.Decorators.Validation.ValidationDecorator.CatServiceRequestHandler_TRequest,TResponse_.HandleAsync(TRequest,System.Threading.CancellationToken).serviceRequest'></a>

`serviceRequest` [TRequest](ValidationDecorator.CatServiceRequestHandler_TRequest,TResponse_.md#Cat.ServiceRequests.Decorators.Validation.ValidationDecorator.CatServiceRequestHandler_TRequest,TResponse_.TRequest 'Cat\.ServiceRequests\.Decorators\.Validation\.ValidationDecorator\.CatServiceRequestHandler\<TRequest,TResponse\>\.TRequest')

The request to handle\.

<a name='Cat.ServiceRequests.Decorators.Validation.ValidationDecorator.CatServiceRequestHandler_TRequest,TResponse_.HandleAsync(TRequest,System.Threading.CancellationToken).ct'></a>

`ct` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Implements [HandleAsync\(TRequest, CancellationToken\)](../../../Cat.ServiceRequests/namespaces/Cat.ServiceRequests.Abstractions/ICatServiceRequestHandler_TRequest,TResponse_.HandleAsync.TZWIOXWSUV7KFO64E34V9YC46.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler\`2\.HandleAsync\(\`0,System\.Threading\.CancellationToken\)')

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Cat\.Responses\.Abstractions\.ICatResponse&lt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[TResponse](ValidationDecorator.CatServiceRequestHandler_TRequest,TResponse_.md#Cat.ServiceRequests.Decorators.Validation.ValidationDecorator.CatServiceRequestHandler_TRequest,TResponse_.TResponse 'Cat\.ServiceRequests\.Decorators\.Validation\.ValidationDecorator\.CatServiceRequestHandler\<TRequest,TResponse\>\.TResponse')[&gt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A response with the payload when it succeeded, or the errors when it failed\.