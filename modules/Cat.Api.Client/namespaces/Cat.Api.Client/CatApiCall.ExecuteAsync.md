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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.API.CLIENT](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Api\.Client Assembly](index.md 'index') >> [Cat\.Api\.Client Namespace](Cat.Api.Client.md 'Cat\.Api\.Client') >> [CatApiCall Class](CatApiCall.md 'Cat\.Api\.Client\.CatApiCall')

## CatApiCall\.ExecuteAsync Method

| Overloads | |
| :--- | :--- |
| [ExecuteAsync\(Func&lt;Task&gt;, string, CancellationToken\)](CatApiCall.ExecuteAsync.md#Cat.Api.Client.CatApiCall.ExecuteAsync(System.Func_System.Threading.Tasks.Task_,string,System.Threading.CancellationToken) 'Cat\.Api\.Client\.CatApiCall\.ExecuteAsync\(System\.Func\<System\.Threading\.Tasks\.Task\>, string, System\.Threading\.CancellationToken\)') | Runs a call that returns nothing\. |
| [ExecuteAsync&lt;TResponse&gt;\(Func&lt;Task&lt;TResponse&gt;&gt;, string, CancellationToken\)](CatApiCall.ExecuteAsync.md#Cat.Api.Client.CatApiCall.ExecuteAsync_TResponse_(System.Func_System.Threading.Tasks.Task_TResponse__,string,System.Threading.CancellationToken) 'Cat\.Api\.Client\.CatApiCall\.ExecuteAsync\<TResponse\>\(System\.Func\<System\.Threading\.Tasks\.Task\<TResponse\>\>, string, System\.Threading\.CancellationToken\)') | Runs a call that returns a value\. |

<a name='Cat.Api.Client.CatApiCall.ExecuteAsync(System.Func_System.Threading.Tasks.Task_,string,System.Threading.CancellationToken)'></a>

## CatApiCall\.ExecuteAsync\(Func\<Task\>, string, CancellationToken\) Method

Runs a call that returns nothing\.

```csharp
public static System.Threading.Tasks.Task<Cat.Responses.Abstractions.ICatResponse> ExecuteAsync(System.Func<System.Threading.Tasks.Task> call, string serviceName, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Cat.Api.Client.CatApiCall.ExecuteAsync(System.Func_System.Threading.Tasks.Task_,string,System.Threading.CancellationToken).call'></a>

`call` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')[System\.Threading\.Tasks\.Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task 'System\.Threading\.Tasks\.Task')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')

The call to run, for example a method of a generated client\.

<a name='Cat.Api.Client.CatApiCall.ExecuteAsync(System.Func_System.Threading.Tasks.Task_,string,System.Threading.CancellationToken).serviceName'></a>

`serviceName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the service that is called\. It is used in the error of an unexpected answer\.

<a name='Cat.Api.Client.CatApiCall.ExecuteAsync(System.Func_System.Threading.Tasks.Task_,string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The token of the caller\. A cancel by the caller is not turned into a response\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[ICatResponse](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A succeeded response, or a failed response with the errors of the service\.

<a name='Cat.Api.Client.CatApiCall.ExecuteAsync_TResponse_(System.Func_System.Threading.Tasks.Task_TResponse__,string,System.Threading.CancellationToken)'></a>

## CatApiCall\.ExecuteAsync\<TResponse\>\(Func\<Task\<TResponse\>\>, string, CancellationToken\) Method

Runs a call that returns a value\.

```csharp
public static System.Threading.Tasks.Task<Cat.Responses.Abstractions.ICatResponse<TResponse>> ExecuteAsync<TResponse>(System.Func<System.Threading.Tasks.Task<TResponse>> call, string serviceName, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Type parameters

<a name='Cat.Api.Client.CatApiCall.ExecuteAsync_TResponse_(System.Func_System.Threading.Tasks.Task_TResponse__,string,System.Threading.CancellationToken).TResponse'></a>

`TResponse`

The type of the value of the call\.
#### Parameters

<a name='Cat.Api.Client.CatApiCall.ExecuteAsync_TResponse_(System.Func_System.Threading.Tasks.Task_TResponse__,string,System.Threading.CancellationToken).call'></a>

`call` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[TResponse](CatApiCall.ExecuteAsync.md#Cat.Api.Client.CatApiCall.ExecuteAsync_TResponse_(System.Func_System.Threading.Tasks.Task_TResponse__,string,System.Threading.CancellationToken).TResponse 'Cat\.Api\.Client\.CatApiCall\.ExecuteAsync\<TResponse\>\(System\.Func\<System\.Threading\.Tasks\.Task\<TResponse\>\>, string, System\.Threading\.CancellationToken\)\.TResponse')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')

The call to run, for example a method of a generated client\.

<a name='Cat.Api.Client.CatApiCall.ExecuteAsync_TResponse_(System.Func_System.Threading.Tasks.Task_TResponse__,string,System.Threading.CancellationToken).serviceName'></a>

`serviceName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the service that is called\. It is used in the error of an unexpected answer\.

<a name='Cat.Api.Client.CatApiCall.ExecuteAsync_TResponse_(System.Func_System.Threading.Tasks.Task_TResponse__,string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The token of the caller\. A cancel by the caller is not turned into a response\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Cat\.Responses\.Abstractions\.ICatResponse&lt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[TResponse](CatApiCall.ExecuteAsync.md#Cat.Api.Client.CatApiCall.ExecuteAsync_TResponse_(System.Func_System.Threading.Tasks.Task_TResponse__,string,System.Threading.CancellationToken).TResponse 'Cat\.Api\.Client\.CatApiCall\.ExecuteAsync\<TResponse\>\(System\.Func\<System\.Threading\.Tasks\.Task\<TResponse\>\>, string, System\.Threading\.CancellationToken\)\.TResponse')[&gt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A succeeded response with the value, or a failed response with the errors of the service\.
The status of the answer picks the type: 400, 401, 403, 404 and 409 map to their own type, everything else
to [InternalServerError](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.InternalServerError.md 'Cat\.Responses\.Abstractions\.CatResponseType\.InternalServerError')\.