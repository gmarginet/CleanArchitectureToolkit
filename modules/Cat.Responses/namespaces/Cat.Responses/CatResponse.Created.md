<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Responses](index.md 'index') > [Cat\.Responses](Cat.Responses.md 'Cat\.Responses') > [CatResponse](CatResponse.md 'Cat\.Responses\.CatResponse')

## CatResponse\.Created Method

| Overloads | |
| :--- | :--- |
| [Created\(\)](CatResponse.Created.md#Cat.Responses.CatResponse.Created() 'Cat\.Responses\.CatResponse\.Created\(\)') | Creates a succeeded response with the [Created](..\Cat.Responses.Abstractions\CatResponseType.Created.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Created') outcome and no value\. |
| [Created&lt;TResponse&gt;\(TResponse\)](CatResponse.Created.md#Cat.Responses.CatResponse.Created_TResponse_(TResponse) 'Cat\.Responses\.CatResponse\.Created\<TResponse\>\(TResponse\)') | Creates a succeeded response with the [Created](..\Cat.Responses.Abstractions\CatResponseType.Created.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Created') outcome, carrying the given value\. |

<a name='Cat.Responses.CatResponse.Created()'></a>

## CatResponse\.Created\(\) Method

Creates a succeeded response with the [Created](..\Cat.Responses.Abstractions\CatResponseType.Created.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Created') outcome and no value\.

```csharp
public static Cat.Responses.Abstractions.ICatResponse Created();
```

#### Returns
[ICatResponse](..\Cat.Responses.Abstractions\ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse')

<a name='Cat.Responses.CatResponse.Created_TResponse_(TResponse)'></a>

## CatResponse\.Created\<TResponse\>\(TResponse\) Method

Creates a succeeded response with the [Created](..\Cat.Responses.Abstractions\CatResponseType.Created.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Created') outcome, carrying the given value\.

```csharp
public static Cat.Responses.Abstractions.ICatResponse<TResponse> Created<TResponse>(TResponse value);
```
#### Type parameters

<a name='Cat.Responses.CatResponse.Created_TResponse_(TResponse).TResponse'></a>

`TResponse`

The type of value the response carries\.
#### Parameters

<a name='Cat.Responses.CatResponse.Created_TResponse_(TResponse).value'></a>

`value` [TResponse](CatResponse.md#Cat.Responses.CatResponse.Created_TResponse_(TResponse).TResponse 'Cat\.Responses\.CatResponse\.Created\<TResponse\>\(TResponse\)\.TResponse')

The value the response carries\.

#### Returns
[Cat\.Responses\.Abstractions\.ICatResponse&lt;](..\Cat.Responses.Abstractions\ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[TResponse](CatResponse.md#Cat.Responses.CatResponse.Created_TResponse_(TResponse).TResponse 'Cat\.Responses\.CatResponse\.Created\<TResponse\>\(TResponse\)\.TResponse')[&gt;](..\Cat.Responses.Abstractions\ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')