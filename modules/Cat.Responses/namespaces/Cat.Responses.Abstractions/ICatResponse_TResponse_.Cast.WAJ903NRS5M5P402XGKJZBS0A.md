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
  
##### >> [Cat\.Responses\.Abstractions Assembly](index.md 'index') >> [Cat\.Responses\.Abstractions Namespace](Cat.Responses.Abstractions.md 'Cat\.Responses\.Abstractions') >> [ICatResponse&lt;TResponse&gt; Interface](ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\<TResponse\>')

## ICatResponse\<TResponse\>\.Cast\<TTargetResponse\>\(Func\<TResponse,TTargetResponse\>\) Method

Converts this response's value to another type, keeping its type and errors\.

```csharp
Cat.Responses.Abstractions.ICatResponse<TTargetResponse> Cast<TTargetResponse>(System.Func<TResponse,TTargetResponse> convertValue);
```
#### Type parameters

<a name='Cat.Responses.Abstractions.ICatResponse_TResponse_.Cast_TTargetResponse_(System.Func_TResponse,TTargetResponse_).TTargetResponse'></a>

`TTargetResponse`

The value type of the resulting response\.
#### Parameters

<a name='Cat.Responses.Abstractions.ICatResponse_TResponse_.Cast_TTargetResponse_(System.Func_TResponse,TTargetResponse_).convertValue'></a>

`convertValue` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TResponse](ICatResponse_TResponse_.md#Cat.Responses.Abstractions.ICatResponse_TResponse_.TResponse 'Cat\.Responses\.Abstractions\.ICatResponse\<TResponse\>\.TResponse')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TTargetResponse](ICatResponse_TResponse_.Cast.WAJ903NRS5M5P402XGKJZBS0A.md#Cat.Responses.Abstractions.ICatResponse_TResponse_.Cast_TTargetResponse_(System.Func_TResponse,TTargetResponse_).TTargetResponse 'Cat\.Responses\.Abstractions\.ICatResponse\<TResponse\>\.Cast\<TTargetResponse\>\(System\.Func\<TResponse,TTargetResponse\>\)\.TTargetResponse')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

Converts [Value](ICatResponse_TResponse_.Value.md 'Cat\.Responses\.Abstractions\.ICatResponse\<TResponse\>\.Value') to [TTargetResponse](ICatResponse_TResponse_.Cast.WAJ903NRS5M5P402XGKJZBS0A.md#Cat.Responses.Abstractions.ICatResponse_TResponse_.Cast_TTargetResponse_(System.Func_TResponse,TTargetResponse_).TTargetResponse 'Cat\.Responses\.Abstractions\.ICatResponse\<TResponse\>\.Cast\<TTargetResponse\>\(System\.Func\<TResponse,TTargetResponse\>\)\.TTargetResponse')\. Only invoked when the response succeeded\.

#### Returns
[Cat\.Responses\.Abstractions\.ICatResponse&lt;](ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\<TResponse\>')[TTargetResponse](ICatResponse_TResponse_.Cast.WAJ903NRS5M5P402XGKJZBS0A.md#Cat.Responses.Abstractions.ICatResponse_TResponse_.Cast_TTargetResponse_(System.Func_TResponse,TTargetResponse_).TTargetResponse 'Cat\.Responses\.Abstractions\.ICatResponse\<TResponse\>\.Cast\<TTargetResponse\>\(System\.Func\<TResponse,TTargetResponse\>\)\.TTargetResponse')[&gt;](ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\<TResponse\>')  
A response of the same type, carrying the converted value if it succeeded\.