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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.RESPONSES](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Responses Assembly](index.md 'index') >> [Cat\.Responses Namespace](Cat.Responses.md 'Cat\.Responses') >> [CatResponse Class](CatResponse.md 'Cat\.Responses\.CatResponse')

## CatResponse\.Created Method

| Overloads | |
| :--- | :--- |
| [Created\(\)](CatResponse.Created.md#Cat.Responses.CatResponse.Created() 'Cat\.Responses\.CatResponse\.Created\(\)') | Creates a succeeded response with the [Created](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.Created.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Created') outcome and no value\. |
| [Created&lt;TResponse&gt;\(TResponse\)](CatResponse.Created.md#Cat.Responses.CatResponse.Created_TResponse_(TResponse) 'Cat\.Responses\.CatResponse\.Created\<TResponse\>\(TResponse\)') | Creates a succeeded response with the [Created](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.Created.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Created') outcome, carrying the given value\. |

<a name='Cat.Responses.CatResponse.Created()'></a>

## CatResponse\.Created\(\) Method

Creates a succeeded response with the [Created](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.Created.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Created') outcome and no value\.

```csharp
public static Cat.Responses.Abstractions.ICatResponse Created();
```

#### Returns
[ICatResponse](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse')

<a name='Cat.Responses.CatResponse.Created_TResponse_(TResponse)'></a>

## CatResponse\.Created\<TResponse\>\(TResponse\) Method

Creates a succeeded response with the [Created](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.Created.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Created') outcome, carrying the given value\.

```csharp
public static Cat.Responses.Abstractions.ICatResponse<TResponse> Created<TResponse>(TResponse value);
```
#### Type parameters

<a name='Cat.Responses.CatResponse.Created_TResponse_(TResponse).TResponse'></a>

`TResponse`

The type of value the response carries\.
#### Parameters

<a name='Cat.Responses.CatResponse.Created_TResponse_(TResponse).value'></a>

`value` [TResponse](CatResponse.Created.md#Cat.Responses.CatResponse.Created_TResponse_(TResponse).TResponse 'Cat\.Responses\.CatResponse\.Created\<TResponse\>\(TResponse\)\.TResponse')

The value the response carries\.

#### Returns
[Cat\.Responses\.Abstractions\.ICatResponse&lt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[TResponse](CatResponse.Created.md#Cat.Responses.CatResponse.Created_TResponse_(TResponse).TResponse 'Cat\.Responses\.CatResponse\.Created\<TResponse\>\(TResponse\)\.TResponse')[&gt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')