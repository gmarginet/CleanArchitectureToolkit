<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Responses](index.md 'index') > [Cat\.Responses](Cat.Responses.md 'Cat\.Responses') > [CatResponse](CatResponse.md 'Cat\.Responses\.CatResponse')

## CatResponse\.Unauthorized Method

| Overloads | |
| :--- | :--- |
| [Unauthorized\(ICatError\[\]\)](CatResponse.Unauthorized.md#Cat.Responses.CatResponse.Unauthorized(Cat.Responses.Abstractions.ICatError[]) 'Cat\.Responses\.CatResponse\.Unauthorized\(Cat\.Responses\.Abstractions\.ICatError\[\]\)') | Creates a failed response with the [Unauthorized](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.Unauthorized.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Unauthorized') outcome\. |
| [Unauthorized&lt;TResponse&gt;\(ICatError\[\]\)](CatResponse.Unauthorized.md#Cat.Responses.CatResponse.Unauthorized_TResponse_(Cat.Responses.Abstractions.ICatError[]) 'Cat\.Responses\.CatResponse\.Unauthorized\<TResponse\>\(Cat\.Responses\.Abstractions\.ICatError\[\]\)') | Creates a failed response with the [Unauthorized](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.Unauthorized.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Unauthorized') outcome\. |

<a name='Cat.Responses.CatResponse.Unauthorized(Cat.Responses.Abstractions.ICatError[])'></a>

## CatResponse\.Unauthorized\(ICatError\[\]\) Method

Creates a failed response with the [Unauthorized](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.Unauthorized.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Unauthorized') outcome\.

```csharp
public static Cat.Responses.Abstractions.ICatResponse Unauthorized(params Cat.Responses.Abstractions.ICatError[] errors);
```
#### Parameters

<a name='Cat.Responses.CatResponse.Unauthorized(Cat.Responses.Abstractions.ICatError[]).errors'></a>

`errors` [ICatError](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatError.md 'Cat\.Responses\.Abstractions\.ICatError')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The errors describing why the caller isn't authorized\.

#### Returns
[ICatResponse](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse')

<a name='Cat.Responses.CatResponse.Unauthorized_TResponse_(Cat.Responses.Abstractions.ICatError[])'></a>

## CatResponse\.Unauthorized\<TResponse\>\(ICatError\[\]\) Method

Creates a failed response with the [Unauthorized](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.Unauthorized.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Unauthorized') outcome\.

```csharp
public static Cat.Responses.Abstractions.ICatResponse<TResponse> Unauthorized<TResponse>(params Cat.Responses.Abstractions.ICatError[] errors);
```
#### Type parameters

<a name='Cat.Responses.CatResponse.Unauthorized_TResponse_(Cat.Responses.Abstractions.ICatError[]).TResponse'></a>

`TResponse`

The value type the response is typed to\.
#### Parameters

<a name='Cat.Responses.CatResponse.Unauthorized_TResponse_(Cat.Responses.Abstractions.ICatError[]).errors'></a>

`errors` [ICatError](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatError.md 'Cat\.Responses\.Abstractions\.ICatError')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The errors describing why the caller isn't authorized\.

#### Returns
[Cat\.Responses\.Abstractions\.ICatResponse&lt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[TResponse](CatResponse.md#Cat.Responses.CatResponse.Unauthorized_TResponse_(Cat.Responses.Abstractions.ICatError[]).TResponse 'Cat\.Responses\.CatResponse\.Unauthorized\<TResponse\>\(Cat\.Responses\.Abstractions\.ICatError\[\]\)\.TResponse')[&gt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')