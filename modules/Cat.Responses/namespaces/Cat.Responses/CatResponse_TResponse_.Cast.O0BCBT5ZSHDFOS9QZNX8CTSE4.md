<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Responses](index.md 'index') > [Cat\.Responses](Cat.Responses.md 'Cat\.Responses') > [CatResponse&lt;TResponse&gt;](CatResponse_TResponse_.md 'Cat\.Responses\.CatResponse\<TResponse\>')

## CatResponse\<TResponse\>\.Cast\<TTargetResponse\>\(Func\<TResponse,TTargetResponse\>\) Method

Converts this response's value to another type, keeping its type and errors\.

```csharp
public Cat.Responses.Abstractions.ICatResponse<TTargetResponse> Cast<TTargetResponse>(System.Func<TResponse,TTargetResponse> convertValue);
```
#### Type parameters

<a name='Cat.Responses.CatResponse_TResponse_.Cast_TTargetResponse_(System.Func_TResponse,TTargetResponse_).TTargetResponse'></a>

`TTargetResponse`

The value type of the resulting response\.
#### Parameters

<a name='Cat.Responses.CatResponse_TResponse_.Cast_TTargetResponse_(System.Func_TResponse,TTargetResponse_).convertValue'></a>

`convertValue` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TResponse](CatResponse_TResponse_.md#Cat.Responses.CatResponse_TResponse_.TResponse 'Cat\.Responses\.CatResponse\<TResponse\>\.TResponse')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TTargetResponse](CatResponse_TResponse_.Cast.O0BCBT5ZSHDFOS9QZNX8CTSE4.md#Cat.Responses.CatResponse_TResponse_.Cast_TTargetResponse_(System.Func_TResponse,TTargetResponse_).TTargetResponse 'Cat\.Responses\.CatResponse\<TResponse\>\.Cast\<TTargetResponse\>\(System\.Func\<TResponse,TTargetResponse\>\)\.TTargetResponse')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

Converts [Value](../Cat.Responses.Abstractions/ICatResponse_TResponse_.Value.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1\.Value') to [TTargetResponse](CatResponse_TResponse_.Cast.O0BCBT5ZSHDFOS9QZNX8CTSE4.md#Cat.Responses.CatResponse_TResponse_.Cast_TTargetResponse_(System.Func_TResponse,TTargetResponse_).TTargetResponse 'Cat\.Responses\.CatResponse\<TResponse\>\.Cast\<TTargetResponse\>\(System\.Func\<TResponse,TTargetResponse\>\)\.TTargetResponse')\. Only invoked when the response succeeded\.

Implements [Cast&lt;TTargetResponse&gt;\(Func&lt;TResponse,TTargetResponse&gt;\)](../Cat.Responses.Abstractions/ICatResponse_TResponse_.Cast.WAJ903NRS5M5P402XGKJZBS0A.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1\.Cast\`\`1\(System\.Func\{\`0,\`\`0\}\)')

#### Returns
[Cat\.Responses\.Abstractions\.ICatResponse&lt;](../Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[TTargetResponse](CatResponse_TResponse_.Cast.O0BCBT5ZSHDFOS9QZNX8CTSE4.md#Cat.Responses.CatResponse_TResponse_.Cast_TTargetResponse_(System.Func_TResponse,TTargetResponse_).TTargetResponse 'Cat\.Responses\.CatResponse\<TResponse\>\.Cast\<TTargetResponse\>\(System\.Func\<TResponse,TTargetResponse\>\)\.TTargetResponse')[&gt;](../Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')  
A response of the same type, carrying the converted value if it succeeded\.