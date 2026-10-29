<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Responses\.Abstractions](index.md 'index') > [Cat\.Responses\.Abstractions](Cat.Responses.Abstractions.md 'Cat\.Responses\.Abstractions') > [ICatResponse&lt;TResponse&gt;](ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\<TResponse\>')

## ICatResponse\<TResponse\>\.Cast\<TTargetResponse\>\(Func\<TResponse,TTargetResponse\>\) Method

Converts this response's value to another type, keeping its type and errors\.

```csharp
Cat.Responses.Abstractions.ICatResponse<TTargetResponse> Cast<TTargetResponse>(System.Func<TResponse,TTargetResponse> convertValue);
```
#### Type parameters

<a name='Cat.Responses.Abstractions.ICatResponse_TResponse_.Cast_TTargetResponse_(System.Func_TResponse,TTargetResponse_).TTargetResponse'></a>

`TTargetResponse`

The value type of the resulting response\.
#### Parameters

<a name='Cat.Responses.Abstractions.ICatResponse_TResponse_.Cast_TTargetResponse_(System.Func_TResponse,TTargetResponse_).convertValue'></a>

`convertValue` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TResponse](ICatResponse_TResponse_.md#Cat.Responses.Abstractions.ICatResponse_TResponse_.TResponse 'Cat\.Responses\.Abstractions\.ICatResponse\<TResponse\>\.TResponse')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TTargetResponse](ICatResponse_TResponse_.Cast.WAJ903NRS5M5P402XGKJZBS0A.md#Cat.Responses.Abstractions.ICatResponse_TResponse_.Cast_TTargetResponse_(System.Func_TResponse,TTargetResponse_).TTargetResponse 'Cat\.Responses\.Abstractions\.ICatResponse\<TResponse\>\.Cast\<TTargetResponse\>\(System\.Func\<TResponse,TTargetResponse\>\)\.TTargetResponse')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

Converts [Value](ICatResponse_TResponse_.Value.md 'Cat\.Responses\.Abstractions\.ICatResponse\<TResponse\>\.Value') to [TTargetResponse](ICatResponse_TResponse_.Cast.WAJ903NRS5M5P402XGKJZBS0A.md#Cat.Responses.Abstractions.ICatResponse_TResponse_.Cast_TTargetResponse_(System.Func_TResponse,TTargetResponse_).TTargetResponse 'Cat\.Responses\.Abstractions\.ICatResponse\<TResponse\>\.Cast\<TTargetResponse\>\(System\.Func\<TResponse,TTargetResponse\>\)\.TTargetResponse')\. Only invoked when the response succeeded\.

#### Returns
[Cat\.Responses\.Abstractions\.ICatResponse&lt;](ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\<TResponse\>')[TTargetResponse](ICatResponse_TResponse_.Cast.WAJ903NRS5M5P402XGKJZBS0A.md#Cat.Responses.Abstractions.ICatResponse_TResponse_.Cast_TTargetResponse_(System.Func_TResponse,TTargetResponse_).TTargetResponse 'Cat\.Responses\.Abstractions\.ICatResponse\<TResponse\>\.Cast\<TTargetResponse\>\(System\.Func\<TResponse,TTargetResponse\>\)\.TTargetResponse')[&gt;](ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\<TResponse\>')  
A response of the same type, carrying the converted value if it succeeded\.