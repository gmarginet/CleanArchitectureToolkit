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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.SERVICEREQUESTS](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.ServiceRequests Assembly](index.md 'index') >> [Cat\.ServiceRequests Namespace](Cat.ServiceRequests.md 'Cat\.ServiceRequests') >> [CatServiceRequestProcessor Class](CatServiceRequestProcessor.md 'Cat\.ServiceRequests\.CatServiceRequestProcessor')

## CatServiceRequestProcessor\.RunHandlerAsync\(IServiceProvider, ICatServiceRequest, CancellationToken\) Method

```csharp
private System.Threading.Tasks.Task<Cat.Responses.Abstractions.ICatResponse> RunHandlerAsync(System.IServiceProvider provider, Cat.ServiceRequests.Abstractions.ICatServiceRequest catServiceRequest, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='Cat.ServiceRequests.CatServiceRequestProcessor.RunHandlerAsync(System.IServiceProvider,Cat.ServiceRequests.Abstractions.ICatServiceRequest,System.Threading.CancellationToken).provider'></a>

`provider` [System\.IServiceProvider](https://learn.microsoft.com/en-us/dotnet/api/system.iserviceprovider 'System\.IServiceProvider')

<a name='Cat.ServiceRequests.CatServiceRequestProcessor.RunHandlerAsync(System.IServiceProvider,Cat.ServiceRequests.Abstractions.ICatServiceRequest,System.Threading.CancellationToken).catServiceRequest'></a>

`catServiceRequest` [ICatServiceRequest](../../../Cat.ServiceRequests/namespaces/Cat.ServiceRequests.Abstractions/ICatServiceRequest.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest')

<a name='Cat.ServiceRequests.CatServiceRequestProcessor.RunHandlerAsync(System.IServiceProvider,Cat.ServiceRequests.Abstractions.ICatServiceRequest,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[ICatResponse](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')