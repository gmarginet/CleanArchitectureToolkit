<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Responses\.Abstractions](index.md 'index') > [Cat\.Responses\.Abstractions](Cat.Responses.Abstractions.md 'Cat\.Responses\.Abstractions') > [ICatResponse](ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse')

## ICatResponse\.Cast Method

| Overloads | |
| :--- | :--- |
| [Cast&lt;TResponse&gt;\(\)](ICatResponse.Cast.md#Cat.Responses.Abstractions.ICatResponse.Cast_TResponse_() 'Cat\.Responses\.Abstractions\.ICatResponse\.Cast\<TResponse\>\(\)') | Converts this response into an [ICatResponse&lt;TResponse&gt;](ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\<TResponse\>'), carrying over its type and errors\. Only valid when [IsFailed](ICatResponse.IsFailed.md 'Cat\.Responses\.Abstractions\.ICatResponse\.IsFailed') is `true`, since no value is supplied for the succeeded case\. |
| [Cast&lt;TResponse&gt;\(TResponse\)](ICatResponse.Cast.md#Cat.Responses.Abstractions.ICatResponse.Cast_TResponse_(TResponse) 'Cat\.Responses\.Abstractions\.ICatResponse\.Cast\<TResponse\>\(TResponse\)') | Converts this response into an [ICatResponse&lt;TResponse&gt;](ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\<TResponse\>') carrying the given value, keeping this response's type\. |

<a name='Cat.Responses.Abstractions.ICatResponse.Cast_TResponse_()'></a>

## ICatResponse\.Cast\<TResponse\>\(\) Method

Converts this response into an [ICatResponse&lt;TResponse&gt;](ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\<TResponse\>'), carrying over its type and errors\.
Only valid when [IsFailed](ICatResponse.IsFailed.md 'Cat\.Responses\.Abstractions\.ICatResponse\.IsFailed') is `true`, since no value is supplied for the succeeded case\.

```csharp
Cat.Responses.Abstractions.ICatResponse<TResponse> Cast<TResponse>();
```
#### Type parameters

<a name='Cat.Responses.Abstractions.ICatResponse.Cast_TResponse_().TResponse'></a>

`TResponse`

The value type of the resulting response\.

#### Returns
[Cat\.Responses\.Abstractions\.ICatResponse&lt;](ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\<TResponse\>')[TResponse](ICatResponse.Cast.md#Cat.Responses.Abstractions.ICatResponse.Cast_TResponse_().TResponse 'Cat\.Responses\.Abstractions\.ICatResponse\.Cast\<TResponse\>\(\)\.TResponse')[&gt;](ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\<TResponse\>')  
A failed response with the same type and errors\.

<a name='Cat.Responses.Abstractions.ICatResponse.Cast_TResponse_(TResponse)'></a>

## ICatResponse\.Cast\<TResponse\>\(TResponse\) Method

Converts this response into an [ICatResponse&lt;TResponse&gt;](ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\<TResponse\>') carrying the given value, keeping this response's type\.

```csharp
Cat.Responses.Abstractions.ICatResponse<TResponse> Cast<TResponse>(TResponse value);
```
#### Type parameters

<a name='Cat.Responses.Abstractions.ICatResponse.Cast_TResponse_(TResponse).TResponse'></a>

`TResponse`

The value type of the resulting response\.
#### Parameters

<a name='Cat.Responses.Abstractions.ICatResponse.Cast_TResponse_(TResponse).value'></a>

`value` [TResponse](ICatResponse.Cast.md#Cat.Responses.Abstractions.ICatResponse.Cast_TResponse_(TResponse).TResponse 'Cat\.Responses\.Abstractions\.ICatResponse\.Cast\<TResponse\>\(TResponse\)\.TResponse')

The value to carry on the resulting response\. Only used when [IsSucceeded](ICatResponse.IsSucceeded.md 'Cat\.Responses\.Abstractions\.ICatResponse\.IsSucceeded') is `true`\.

#### Returns
[Cat\.Responses\.Abstractions\.ICatResponse&lt;](ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\<TResponse\>')[TResponse](ICatResponse.Cast.md#Cat.Responses.Abstractions.ICatResponse.Cast_TResponse_(TResponse).TResponse 'Cat\.Responses\.Abstractions\.ICatResponse\.Cast\<TResponse\>\(TResponse\)\.TResponse')[&gt;](ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\<TResponse\>')  
A response with the same type, carrying [value](ICatResponse.Cast.md#Cat.Responses.Abstractions.ICatResponse.Cast_TResponse_(TResponse).value 'Cat\.Responses\.Abstractions\.ICatResponse\.Cast\<TResponse\>\(TResponse\)\.value') if it succeeded\.