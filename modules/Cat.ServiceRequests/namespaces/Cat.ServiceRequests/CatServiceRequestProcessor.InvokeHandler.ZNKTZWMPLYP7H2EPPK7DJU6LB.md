<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.ServiceRequests](index.md 'index') > [Cat\.ServiceRequests](Cat.ServiceRequests.md 'Cat\.ServiceRequests') > [CatServiceRequestProcessor](CatServiceRequestProcessor.md 'Cat\.ServiceRequests\.CatServiceRequestProcessor')

## CatServiceRequestProcessor\.InvokeHandler\(MethodInfo, object, object, CancellationToken\) Method

Calls the handler\. An exception thrown by the handler itself reaches the caller as it is, not wrapped in a [System\.Reflection\.TargetInvocationException](https://learn.microsoft.com/en-us/dotnet/api/system.reflection.targetinvocationexception 'System\.Reflection\.TargetInvocationException')\.

```csharp
private static object InvokeHandler(System.Reflection.MethodInfo method, object handler, object serviceRequest, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='Cat.ServiceRequests.CatServiceRequestProcessor.InvokeHandler(System.Reflection.MethodInfo,object,object,System.Threading.CancellationToken).method'></a>

`method` [System\.Reflection\.MethodInfo](https://learn.microsoft.com/en-us/dotnet/api/system.reflection.methodinfo 'System\.Reflection\.MethodInfo')

<a name='Cat.ServiceRequests.CatServiceRequestProcessor.InvokeHandler(System.Reflection.MethodInfo,object,object,System.Threading.CancellationToken).handler'></a>

`handler` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

<a name='Cat.ServiceRequests.CatServiceRequestProcessor.InvokeHandler(System.Reflection.MethodInfo,object,object,System.Threading.CancellationToken).serviceRequest'></a>

`serviceRequest` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

<a name='Cat.ServiceRequests.CatServiceRequestProcessor.InvokeHandler(System.Reflection.MethodInfo,object,object,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

#### Returns
[System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')