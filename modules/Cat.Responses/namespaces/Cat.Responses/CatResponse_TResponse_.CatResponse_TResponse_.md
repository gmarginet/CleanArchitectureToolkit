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
            <img src='../../../../resources/logo/CatLogo-RoundedCorners-320x160.png' alt='' width='200' style='float: right;'/>
        </td>
    </tr>
    <tr>
        <td colspan='6' markdown='1' style='padding-left: 0; padding-right: 0; padding-top: 15px; padding-bottom: 0; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>

|&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[CAT.RESPONSES](../../README.md)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Responses Assembly](index.md 'index') >> [Cat\.Responses Namespace](Cat.Responses.md 'Cat\.Responses') >> [CatResponse&lt;TResponse&gt; Class](CatResponse_TResponse_.md 'Cat\.Responses\.CatResponse\<TResponse\>')

## CatResponse\<TResponse\> Constructors

| Overloads | |
| :--- | :--- |
| [CatResponse\(Failed, IReadOnlyList&lt;ICatError&gt;\)](CatResponse_TResponse_.CatResponse_TResponse_.md#Cat.Responses.CatResponse_TResponse_.CatResponse(Cat.Responses.Abstractions.CatResponseType.Failed,System.Collections.Generic.IReadOnlyList_Cat.Responses.Abstractions.ICatError_) 'Cat\.Responses\.CatResponse\<TResponse\>\.CatResponse\(Cat\.Responses\.Abstractions\.CatResponseType\.Failed, System\.Collections\.Generic\.IReadOnlyList\<Cat\.Responses\.Abstractions\.ICatError\>\)') | Creates a failed response with the given errors\. |
| [CatResponse\(Succeeded\)](CatResponse_TResponse_.CatResponse_TResponse_.md#Cat.Responses.CatResponse_TResponse_.CatResponse(Cat.Responses.Abstractions.CatResponseType.Succeeded) 'Cat\.Responses\.CatResponse\<TResponse\>\.CatResponse\(Cat\.Responses\.Abstractions\.CatResponseType\.Succeeded\)') | Creates a succeeded response with no value\. |
| [CatResponse\(Succeeded, TResponse\)](CatResponse_TResponse_.CatResponse_TResponse_.md#Cat.Responses.CatResponse_TResponse_.CatResponse(Cat.Responses.Abstractions.CatResponseType.Succeeded,TResponse) 'Cat\.Responses\.CatResponse\<TResponse\>\.CatResponse\(Cat\.Responses\.Abstractions\.CatResponseType\.Succeeded, TResponse\)') | Creates a succeeded response carrying the given value\. |

<a name='Cat.Responses.CatResponse_TResponse_.CatResponse(Cat.Responses.Abstractions.CatResponseType.Failed,System.Collections.Generic.IReadOnlyList_Cat.Responses.Abstractions.ICatError_)'></a>

## CatResponse\(Failed, IReadOnlyList\<ICatError\>\) Constructor

Creates a failed response with the given errors\.

```csharp
internal CatResponse(Cat.Responses.Abstractions.CatResponseType.Failed type, System.Collections.Generic.IReadOnlyList<Cat.Responses.Abstractions.ICatError> errorList);
```
#### Parameters

<a name='Cat.Responses.CatResponse_TResponse_.CatResponse(Cat.Responses.Abstractions.CatResponseType.Failed,System.Collections.Generic.IReadOnlyList_Cat.Responses.Abstractions.ICatError_).type'></a>

`type` [Failed](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.Failed.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Failed')

The specific failed outcome\.

<a name='Cat.Responses.CatResponse_TResponse_.CatResponse(Cat.Responses.Abstractions.CatResponseType.Failed,System.Collections.Generic.IReadOnlyList_Cat.Responses.Abstractions.ICatError_).errorList'></a>

`errorList` [System\.Collections\.Generic\.IReadOnlyList&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1 'System\.Collections\.Generic\.IReadOnlyList\`1')[ICatError](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatError.md 'Cat\.Responses\.Abstractions\.ICatError')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1 'System\.Collections\.Generic\.IReadOnlyList\`1')

The errors that caused the operation to fail\.

<a name='Cat.Responses.CatResponse_TResponse_.CatResponse(Cat.Responses.Abstractions.CatResponseType.Succeeded)'></a>

## CatResponse\(Succeeded\) Constructor

Creates a succeeded response with no value\.

```csharp
internal CatResponse(Cat.Responses.Abstractions.CatResponseType.Succeeded type);
```
#### Parameters

<a name='Cat.Responses.CatResponse_TResponse_.CatResponse(Cat.Responses.Abstractions.CatResponseType.Succeeded).type'></a>

`type` [Succeeded](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.Succeeded.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Succeeded')

The specific succeeded outcome\.

<a name='Cat.Responses.CatResponse_TResponse_.CatResponse(Cat.Responses.Abstractions.CatResponseType.Succeeded,TResponse)'></a>

## CatResponse\(Succeeded, TResponse\) Constructor

Creates a succeeded response carrying the given value\.

```csharp
internal CatResponse(Cat.Responses.Abstractions.CatResponseType.Succeeded type, TResponse value);
```
#### Parameters

<a name='Cat.Responses.CatResponse_TResponse_.CatResponse(Cat.Responses.Abstractions.CatResponseType.Succeeded,TResponse).type'></a>

`type` [Succeeded](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.Succeeded.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Succeeded')

The specific succeeded outcome\.

<a name='Cat.Responses.CatResponse_TResponse_.CatResponse(Cat.Responses.Abstractions.CatResponseType.Succeeded,TResponse).value'></a>

`value` [TResponse](CatResponse_TResponse_.md#Cat.Responses.CatResponse_TResponse_.TResponse 'Cat\.Responses\.CatResponse\<TResponse\>\.TResponse')

The value the response carries\.