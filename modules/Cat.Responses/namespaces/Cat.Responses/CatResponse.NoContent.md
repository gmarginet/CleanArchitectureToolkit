<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Responses](index.md 'index') > [Cat\.Responses](Cat.Responses.md 'Cat\.Responses') > [CatResponse](CatResponse.md 'Cat\.Responses\.CatResponse')

## CatResponse\.NoContent Method

| Overloads | |
| :--- | :--- |
| [NoContent\(\)](CatResponse.NoContent.md#Cat.Responses.CatResponse.NoContent() 'Cat\.Responses\.CatResponse\.NoContent\(\)') | Creates a succeeded response with the [NoContent](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.NoContent.md 'Cat\.Responses\.Abstractions\.CatResponseType\.NoContent') outcome\. |
| [NoContent&lt;TResponse&gt;\(\)](CatResponse.NoContent.md#Cat.Responses.CatResponse.NoContent_TResponse_() 'Cat\.Responses\.CatResponse\.NoContent\<TResponse\>\(\)') | Creates a succeeded response with the [NoContent](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.NoContent.md 'Cat\.Responses\.Abstractions\.CatResponseType\.NoContent') outcome and no value\. |

<a name='Cat.Responses.CatResponse.NoContent()'></a>

## CatResponse\.NoContent\(\) Method

Creates a succeeded response with the [NoContent](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.NoContent.md 'Cat\.Responses\.Abstractions\.CatResponseType\.NoContent') outcome\.

```csharp
public static Cat.Responses.Abstractions.ICatResponse NoContent();
```

#### Returns
[ICatResponse](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse')

<a name='Cat.Responses.CatResponse.NoContent_TResponse_()'></a>

## CatResponse\.NoContent\<TResponse\>\(\) Method

Creates a succeeded response with the [NoContent](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.NoContent.md 'Cat\.Responses\.Abstractions\.CatResponseType\.NoContent') outcome and no value\.

```csharp
public static Cat.Responses.Abstractions.ICatResponse<TResponse> NoContent<TResponse>();
```
#### Type parameters

<a name='Cat.Responses.CatResponse.NoContent_TResponse_().TResponse'></a>

`TResponse`

The value type the response is typed to\.

#### Returns
[Cat\.Responses\.Abstractions\.ICatResponse&lt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[TResponse](CatResponse.md#Cat.Responses.CatResponse.NoContent_TResponse_().TResponse 'Cat\.Responses\.CatResponse\.NoContent\<TResponse\>\(\)\.TResponse')[&gt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')