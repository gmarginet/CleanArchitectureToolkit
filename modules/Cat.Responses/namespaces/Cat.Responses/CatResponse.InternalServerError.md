<link href="../../../../resources/styles/style.css" rel="stylesheet"/>
<table>
    <tr>
        <td colspan='6' style='text-align: center; font-weight: bold; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>
             Clean Architecture Toolkit for .NET
        </td>
    </tr>
    <tr>
        <td colspan='5' style='padding: 0; vertical-align: middle; border: none;'>
            Clean Architecture Toolkit is a clean, modular architecture foundation for .NET applications.<br>
            It embraces SOLID principles and focuses on maintainability, testability, and scalability through clear boundaries and pluggable design.</td>
        <td style='padding: 0; border: none;' width='220'>
            <img src='../../../../resources/logo/CatLogo.svg' alt='' width='200' style='padding: 15px; float: right; background: #121314; border-radius: 10px'/>
        </td>
    </tr>
    <tr>
        <td colspan='6' markdown='1' style='padding-left: 0; padding-right: 0; padding-top: 15px; padding-bottom: 0; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>

|&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[CAT.RESPONSES](../../README.md)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Responses Assembly](index.md 'index') >> [Cat\.Responses Namespace](Cat.Responses.md 'Cat\.Responses') >> [CatResponse Class](CatResponse.md 'Cat\.Responses\.CatResponse')

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