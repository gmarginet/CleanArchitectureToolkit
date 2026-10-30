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
  
##### >> [Cat\.Responses\.Abstractions Assembly](index.md 'index') >> [Cat\.Responses\.Abstractions Namespace](Cat.Responses.Abstractions.md 'Cat\.Responses\.Abstractions')

## ICatResponse\<TResponse\> Interface

An [ICatResponse](ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse') that carries a value when it succeeds\.

```csharp
public interface ICatResponse<TResponse> : Cat.Responses.Abstractions.ICatResponse
```
#### Type parameters

<a name='Cat.Responses.Abstractions.ICatResponse_TResponse_.TResponse'></a>

`TResponse`

The type of value the response carries\.

Implements [ICatResponse](ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse')

| Properties | |
| :--- | :--- |
| [Value](ICatResponse_TResponse_.Value.md 'Cat\.Responses\.Abstractions\.ICatResponse\<TResponse\>\.Value') | The value the operation produced\. Only meaningful when [IsSucceeded](ICatResponse.IsSucceeded.md 'Cat\.Responses\.Abstractions\.ICatResponse\.IsSucceeded') is `true`\. |

| Methods | |
| :--- | :--- |
| [Cast&lt;TTargetResponse&gt;\(Func&lt;TResponse,TTargetResponse&gt;\)](ICatResponse_TResponse_.Cast.WAJ903NRS5M5P402XGKJZBS0A.md 'Cat\.Responses\.Abstractions\.ICatResponse\<TResponse\>\.Cast\<TTargetResponse\>\(System\.Func\<TResponse,TTargetResponse\>\)') | Converts this response's value to another type, keeping its type and errors\. |
