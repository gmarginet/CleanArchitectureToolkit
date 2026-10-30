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
  
##### >> [Cat\.ServiceRequests\.Decorators\.ActivitySource Assembly](index.md 'index') >> [Cat\.ServiceRequests\.Decorators\.ActivitySource Namespace](Cat.ServiceRequests.Decorators.ActivitySource.md 'Cat\.ServiceRequests\.Decorators\.ActivitySource') >> [ActivitySourceDecorator Class](ActivitySourceDecorator.md 'Cat\.ServiceRequests\.Decorators\.ActivitySource\.ActivitySourceDecorator') >> [CatServiceRequestHandler&lt;TRequest,TResponse&gt; Class](ActivitySourceDecorator.CatServiceRequestHandler_TRequest,TResponse_.md 'Cat\.ServiceRequests\.Decorators\.ActivitySource\.ActivitySourceDecorator\.CatServiceRequestHandler\<TRequest,TResponse\>')

## CatServiceRequestHandler\(ICatServiceRequestHandler\<TRequest,TResponse\>\) Constructor

Creates the decorator\.

```csharp
public CatServiceRequestHandler(Cat.ServiceRequests.Abstractions.ICatServiceRequestHandler<TRequest,TResponse> innerHandler);
```
#### Parameters

<a name='Cat.ServiceRequests.Decorators.ActivitySource.ActivitySourceDecorator.CatServiceRequestHandler_TRequest,TResponse_.CatServiceRequestHandler(Cat.ServiceRequests.Abstractions.ICatServiceRequestHandler_TRequest,TResponse_).innerHandler'></a>

`innerHandler` [Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler&lt;](../../../Cat.ServiceRequests/namespaces/Cat.ServiceRequests.Abstractions/ICatServiceRequestHandler_TRequest,TResponse_.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler\`2')[TRequest](ActivitySourceDecorator.CatServiceRequestHandler_TRequest,TResponse_.md#Cat.ServiceRequests.Decorators.ActivitySource.ActivitySourceDecorator.CatServiceRequestHandler_TRequest,TResponse_.TRequest 'Cat\.ServiceRequests\.Decorators\.ActivitySource\.ActivitySourceDecorator\.CatServiceRequestHandler\<TRequest,TResponse\>\.TRequest')[,](../../../Cat.ServiceRequests/namespaces/Cat.ServiceRequests.Abstractions/ICatServiceRequestHandler_TRequest,TResponse_.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler\`2')[TResponse](ActivitySourceDecorator.CatServiceRequestHandler_TRequest,TResponse_.md#Cat.ServiceRequests.Decorators.ActivitySource.ActivitySourceDecorator.CatServiceRequestHandler_TRequest,TResponse_.TResponse 'Cat\.ServiceRequests\.Decorators\.ActivitySource\.ActivitySourceDecorator\.CatServiceRequestHandler\<TRequest,TResponse\>\.TResponse')[&gt;](../../../Cat.ServiceRequests/namespaces/Cat.ServiceRequests.Abstractions/ICatServiceRequestHandler_TRequest,TResponse_.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler\`2')

The handler to wrap\.