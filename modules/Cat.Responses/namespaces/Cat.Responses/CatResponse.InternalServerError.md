<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Responses](index.md 'index') > [Cat\.Responses](Cat.Responses.md 'Cat\.Responses') > [CatResponse](CatResponse.md 'Cat\.Responses\.CatResponse')

## CatResponse\.InternalServerError Method

| Overloads | |
| :--- | :--- |
| [InternalServerError\(ICatError\[\]\)](CatResponse.InternalServerError.md#Cat.Responses.CatResponse.InternalServerError(Cat.Responses.Abstractions.ICatError[]) 'Cat\.Responses\.CatResponse\.InternalServerError\(Cat\.Responses\.Abstractions\.ICatError\[\]\)') | Creates a failed response with the [InternalServerError](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.InternalServerError.md 'Cat\.Responses\.Abstractions\.CatResponseType\.InternalServerError') outcome\. |
| [InternalServerError&lt;TResponse&gt;\(ICatError\[\]\)](CatResponse.InternalServerError.md#Cat.Responses.CatResponse.InternalServerError_TResponse_(Cat.Responses.Abstractions.ICatError[]) 'Cat\.Responses\.CatResponse\.InternalServerError\<TResponse\>\(Cat\.Responses\.Abstractions\.ICatError\[\]\)') | Creates a failed response with the [InternalServerError](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.InternalServerError.md 'Cat\.Responses\.Abstractions\.CatResponseType\.InternalServerError') outcome\. |

<a name='Cat.Responses.CatResponse.InternalServerError(Cat.Responses.Abstractions.ICatError[])'></a>

## CatResponse\.InternalServerError\(ICatError\[\]\) Method

Creates a failed response with the [InternalServerError](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.InternalServerError.md 'Cat\.Responses\.Abstractions\.CatResponseType\.InternalServerError') outcome\.

```csharp
public static Cat.Responses.Abstractions.ICatResponse InternalServerError(params Cat.Responses.Abstractions.ICatError[] errors);
```
#### Parameters

<a name='Cat.Responses.CatResponse.InternalServerError(Cat.Responses.Abstractions.ICatError[]).errors'></a>

`errors` [ICatError](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatError.md 'Cat\.Responses\.Abstractions\.ICatError')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The errors describing what went wrong\.

#### Returns
[ICatResponse](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse')

<a name='Cat.Responses.CatResponse.InternalServerError_TResponse_(Cat.Responses.Abstractions.ICatError[])'></a>

## CatResponse\.InternalServerError\<TResponse\>\(ICatError\[\]\) Method

Creates a failed response with the [InternalServerError](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.InternalServerError.md 'Cat\.Responses\.Abstractions\.CatResponseType\.InternalServerError') outcome\.

```csharp
public static Cat.Responses.Abstractions.ICatResponse<TResponse> InternalServerError<TResponse>(params Cat.Responses.Abstractions.ICatError[] errors);
```
#### Type parameters

<a name='Cat.Responses.CatResponse.InternalServerError_TResponse_(Cat.Responses.Abstractions.ICatError[]).TResponse'></a>

`TResponse`

The value type the response is typed to\.
#### Parameters

<a name='Cat.Responses.CatResponse.InternalServerError_TResponse_(Cat.Responses.Abstractions.ICatError[]).errors'></a>

`errors` [ICatError](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatError.md 'Cat\.Responses\.Abstractions\.ICatError')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The errors describing what went wrong\.

#### Returns
[Cat\.Responses\.Abstractions\.ICatResponse&lt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[TResponse](CatResponse.InternalServerError.md#Cat.Responses.CatResponse.InternalServerError_TResponse_(Cat.Responses.Abstractions.ICatError[]).TResponse 'Cat\.Responses\.CatResponse\.InternalServerError\<TResponse\>\(Cat\.Responses\.Abstractions\.ICatError\[\]\)\.TResponse')[&gt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')