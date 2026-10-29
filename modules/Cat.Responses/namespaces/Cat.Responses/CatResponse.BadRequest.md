<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Responses](index.md 'index') > [Cat\.Responses](Cat.Responses.md 'Cat\.Responses') > [CatResponse](CatResponse.md 'Cat\.Responses\.CatResponse')

## CatResponse\.BadRequest Method

| Overloads | |
| :--- | :--- |
| [BadRequest\(ICatError\[\]\)](CatResponse.BadRequest.md#Cat.Responses.CatResponse.BadRequest(Cat.Responses.Abstractions.ICatError[]) 'Cat\.Responses\.CatResponse\.BadRequest\(Cat\.Responses\.Abstractions\.ICatError\[\]\)') | Creates a failed response with the [BadRequest](..\Cat.Responses.Abstractions\CatResponseType.BadRequest.md 'Cat\.Responses\.Abstractions\.CatResponseType\.BadRequest') outcome\. |
| [BadRequest&lt;TResponse&gt;\(ICatError\[\]\)](CatResponse.BadRequest.md#Cat.Responses.CatResponse.BadRequest_TResponse_(Cat.Responses.Abstractions.ICatError[]) 'Cat\.Responses\.CatResponse\.BadRequest\<TResponse\>\(Cat\.Responses\.Abstractions\.ICatError\[\]\)') | Creates a failed response with the [BadRequest](..\Cat.Responses.Abstractions\CatResponseType.BadRequest.md 'Cat\.Responses\.Abstractions\.CatResponseType\.BadRequest') outcome\. |

<a name='Cat.Responses.CatResponse.BadRequest(Cat.Responses.Abstractions.ICatError[])'></a>

## CatResponse\.BadRequest\(ICatError\[\]\) Method

Creates a failed response with the [BadRequest](..\Cat.Responses.Abstractions\CatResponseType.BadRequest.md 'Cat\.Responses\.Abstractions\.CatResponseType\.BadRequest') outcome\.

```csharp
public static Cat.Responses.Abstractions.ICatResponse BadRequest(params Cat.Responses.Abstractions.ICatError[] errors);
```
#### Parameters

<a name='Cat.Responses.CatResponse.BadRequest(Cat.Responses.Abstractions.ICatError[]).errors'></a>

`errors` [ICatError](..\Cat.Responses.Abstractions\ICatError.md 'Cat\.Responses\.Abstractions\.ICatError')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The errors that caused the request to be rejected\.

#### Returns
[ICatResponse](..\Cat.Responses.Abstractions\ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse')

<a name='Cat.Responses.CatResponse.BadRequest_TResponse_(Cat.Responses.Abstractions.ICatError[])'></a>

## CatResponse\.BadRequest\<TResponse\>\(ICatError\[\]\) Method

Creates a failed response with the [BadRequest](..\Cat.Responses.Abstractions\CatResponseType.BadRequest.md 'Cat\.Responses\.Abstractions\.CatResponseType\.BadRequest') outcome\.

```csharp
public static Cat.Responses.Abstractions.ICatResponse<TResponse> BadRequest<TResponse>(params Cat.Responses.Abstractions.ICatError[] errors);
```
#### Type parameters

<a name='Cat.Responses.CatResponse.BadRequest_TResponse_(Cat.Responses.Abstractions.ICatError[]).TResponse'></a>

`TResponse`

The value type the response is typed to\.
#### Parameters

<a name='Cat.Responses.CatResponse.BadRequest_TResponse_(Cat.Responses.Abstractions.ICatError[]).errors'></a>

`errors` [ICatError](..\Cat.Responses.Abstractions\ICatError.md 'Cat\.Responses\.Abstractions\.ICatError')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The errors that caused the request to be rejected\.

#### Returns
[Cat\.Responses\.Abstractions\.ICatResponse&lt;](..\Cat.Responses.Abstractions\ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[TResponse](CatResponse.md#Cat.Responses.CatResponse.BadRequest_TResponse_(Cat.Responses.Abstractions.ICatError[]).TResponse 'Cat\.Responses\.CatResponse\.BadRequest\<TResponse\>\(Cat\.Responses\.Abstractions\.ICatError\[\]\)\.TResponse')[&gt;](..\Cat.Responses.Abstractions\ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')