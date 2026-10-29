<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Responses](index.md 'index') > [Cat\.Responses](Cat.Responses.md 'Cat\.Responses') > [CatResponse](CatResponse.md 'Cat\.Responses\.CatResponse')

## CatResponse\.Cast Method

| Overloads | |
| :--- | :--- |
| [Cast&lt;TResponse&gt;\(\)](CatResponse.Cast.md#Cat.Responses.CatResponse.Cast_TResponse_() 'Cat\.Responses\.CatResponse\.Cast\<TResponse\>\(\)') | Converts this response into an [ICatResponse&lt;TResponse&gt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1'), carrying over its type and errors\. Only valid when [IsFailed](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse.IsFailed.md 'Cat\.Responses\.Abstractions\.ICatResponse\.IsFailed') is `true`, since no value is supplied for the succeeded case\. |
| [Cast&lt;TResponse&gt;\(TResponse\)](CatResponse.Cast.md#Cat.Responses.CatResponse.Cast_TResponse_(TResponse) 'Cat\.Responses\.CatResponse\.Cast\<TResponse\>\(TResponse\)') | Converts this response into an [ICatResponse&lt;TResponse&gt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1') carrying the given value, keeping this response's type\. |

<a name='Cat.Responses.CatResponse.Cast_TResponse_()'></a>

## CatResponse\.Cast\<TResponse\>\(\) Method

Converts this response into an [ICatResponse&lt;TResponse&gt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1'), carrying over its type and errors\.
Only valid when [IsFailed](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse.IsFailed.md 'Cat\.Responses\.Abstractions\.ICatResponse\.IsFailed') is `true`, since no value is supplied for the succeeded case\.

```csharp
public Cat.Responses.Abstractions.ICatResponse<TResponse> Cast<TResponse>();
```
#### Type parameters

<a name='Cat.Responses.CatResponse.Cast_TResponse_().TResponse'></a>

`TResponse`

The value type of the resulting response\.

Implements [Cast&lt;TResponse&gt;\(\)](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse.Cast.md#Cat.Responses.Abstractions.ICatResponse.Cast_TResponse_() 'Cat\.Responses\.Abstractions\.ICatResponse\.Cast\`\`1')

#### Returns
[Cat\.Responses\.Abstractions\.ICatResponse&lt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[TResponse](CatResponse.md#Cat.Responses.CatResponse.Cast_TResponse_().TResponse 'Cat\.Responses\.CatResponse\.Cast\<TResponse\>\(\)\.TResponse')[&gt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')  
A failed response with the same type and errors\.

<a name='Cat.Responses.CatResponse.Cast_TResponse_(TResponse)'></a>

## CatResponse\.Cast\<TResponse\>\(TResponse\) Method

Converts this response into an [ICatResponse&lt;TResponse&gt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1') carrying the given value, keeping this response's type\.

```csharp
public Cat.Responses.Abstractions.ICatResponse<TResponse> Cast<TResponse>(TResponse value);
```
#### Type parameters

<a name='Cat.Responses.CatResponse.Cast_TResponse_(TResponse).TResponse'></a>

`TResponse`

The value type of the resulting response\.
#### Parameters

<a name='Cat.Responses.CatResponse.Cast_TResponse_(TResponse).value'></a>

`value` [TResponse](CatResponse.md#Cat.Responses.CatResponse.Cast_TResponse_(TResponse).TResponse 'Cat\.Responses\.CatResponse\.Cast\<TResponse\>\(TResponse\)\.TResponse')

The value to carry on the resulting response\. Only used when [IsSucceeded](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse.IsSucceeded.md 'Cat\.Responses\.Abstractions\.ICatResponse\.IsSucceeded') is `true`\.

Implements [Cast&lt;TResponse&gt;\(TResponse\)](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse.Cast.md#Cat.Responses.Abstractions.ICatResponse.Cast_TResponse_(TResponse) 'Cat\.Responses\.Abstractions\.ICatResponse\.Cast\`\`1\(\`\`0\)')

#### Returns
[Cat\.Responses\.Abstractions\.ICatResponse&lt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[TResponse](CatResponse.md#Cat.Responses.CatResponse.Cast_TResponse_(TResponse).TResponse 'Cat\.Responses\.CatResponse\.Cast\<TResponse\>\(TResponse\)\.TResponse')[&gt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')  
A response with the same type, carrying [value](CatResponse.md#Cat.Responses.CatResponse.Cast_TResponse_(TResponse).value 'Cat\.Responses\.CatResponse\.Cast\<TResponse\>\(TResponse\)\.value') if it succeeded\.