<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Responses](index.md 'index') > [Cat\.Responses](Cat.Responses.md 'Cat\.Responses') > [CatResponse](CatResponse.md 'Cat\.Responses\.CatResponse')

## CatResponse\.Ok Method

| Overloads | |
| :--- | :--- |
| [Ok\(\)](CatResponse.Ok.md#Cat.Responses.CatResponse.Ok() 'Cat\.Responses\.CatResponse\.Ok\(\)') | Creates a succeeded response with the [Ok](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.Ok.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Ok') outcome and no value\. |
| [Ok&lt;TResponse&gt;\(TResponse\)](CatResponse.Ok.md#Cat.Responses.CatResponse.Ok_TResponse_(TResponse) 'Cat\.Responses\.CatResponse\.Ok\<TResponse\>\(TResponse\)') | Creates a succeeded response with the [Ok](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.Ok.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Ok') outcome, carrying the given value\. |

<a name='Cat.Responses.CatResponse.Ok()'></a>

## CatResponse\.Ok\(\) Method

Creates a succeeded response with the [Ok](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.Ok.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Ok') outcome and no value\.

```csharp
public static Cat.Responses.Abstractions.ICatResponse Ok();
```

#### Returns
[ICatResponse](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse')

<a name='Cat.Responses.CatResponse.Ok_TResponse_(TResponse)'></a>

## CatResponse\.Ok\<TResponse\>\(TResponse\) Method

Creates a succeeded response with the [Ok](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.Ok.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Ok') outcome, carrying the given value\.

```csharp
public static Cat.Responses.Abstractions.ICatResponse<TResponse> Ok<TResponse>(TResponse value);
```
#### Type parameters

<a name='Cat.Responses.CatResponse.Ok_TResponse_(TResponse).TResponse'></a>

`TResponse`

The type of value the response carries\.
#### Parameters

<a name='Cat.Responses.CatResponse.Ok_TResponse_(TResponse).value'></a>

`value` [TResponse](CatResponse.md#Cat.Responses.CatResponse.Ok_TResponse_(TResponse).TResponse 'Cat\.Responses\.CatResponse\.Ok\<TResponse\>\(TResponse\)\.TResponse')

The value the response carries\.

#### Returns
[Cat\.Responses\.Abstractions\.ICatResponse&lt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[TResponse](CatResponse.md#Cat.Responses.CatResponse.Ok_TResponse_(TResponse).TResponse 'Cat\.Responses\.CatResponse\.Ok\<TResponse\>\(TResponse\)\.TResponse')[&gt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')