<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Queries](index.md 'index') > [Cat\.Queries](Cat.Queries.md 'Cat\.Queries') > [CatQueryProcessor](CatQueryProcessor.md 'Cat\.Queries\.CatQueryProcessor')

## CatQueryProcessor\.InvokeHandler\(MethodInfo, object, object, CancellationToken\) Method

Calls the handler\. An exception thrown by the handler itself reaches the caller as it is, not wrapped in a [System\.Reflection\.TargetInvocationException](https://learn.microsoft.com/en-us/dotnet/api/system.reflection.targetinvocationexception 'System\.Reflection\.TargetInvocationException')\.

```csharp
private static object InvokeHandler(System.Reflection.MethodInfo method, object handler, object query, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='Cat.Queries.CatQueryProcessor.InvokeHandler(System.Reflection.MethodInfo,object,object,System.Threading.CancellationToken).method'></a>

`method` [System\.Reflection\.MethodInfo](https://learn.microsoft.com/en-us/dotnet/api/system.reflection.methodinfo 'System\.Reflection\.MethodInfo')

<a name='Cat.Queries.CatQueryProcessor.InvokeHandler(System.Reflection.MethodInfo,object,object,System.Threading.CancellationToken).handler'></a>

`handler` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

<a name='Cat.Queries.CatQueryProcessor.InvokeHandler(System.Reflection.MethodInfo,object,object,System.Threading.CancellationToken).query'></a>

`query` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

<a name='Cat.Queries.CatQueryProcessor.InvokeHandler(System.Reflection.MethodInfo,object,object,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

#### Returns
[System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')