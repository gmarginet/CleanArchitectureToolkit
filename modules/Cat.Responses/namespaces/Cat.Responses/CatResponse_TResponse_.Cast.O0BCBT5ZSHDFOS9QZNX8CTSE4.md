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
  
##### >> [Cat\.Responses Assembly](index.md 'index') >> [Cat\.Responses Namespace](Cat.Responses.md 'Cat\.Responses') >> [CatResponse&lt;TResponse&gt; Class](CatResponse_TResponse_.md 'Cat\.Responses\.CatResponse\<TResponse\>')

## CatResponse\<TResponse\>\.Cast\<TTargetResponse\>\(Func\<TResponse,TTargetResponse\>\) Method

Converts this response's value to another type, keeping its type and errors\.

```csharp
public Cat.Responses.Abstractions.ICatResponse<TTargetResponse> Cast<TTargetResponse>(System.Func<TResponse,TTargetResponse> convertValue);
```
#### Type parameters

<a name='Cat.Responses.CatResponse_TResponse_.Cast_TTargetResponse_(System.Func_TResponse,TTargetResponse_).TTargetResponse'></a>

`TTargetResponse`

The value type of the resulting response\.
#### Parameters

<a name='Cat.Responses.CatResponse_TResponse_.Cast_TTargetResponse_(System.Func_TResponse,TTargetResponse_).convertValue'></a>

`convertValue` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TResponse](CatResponse_TResponse_.md#Cat.Responses.CatResponse_TResponse_.TResponse 'Cat\.Responses\.CatResponse\<TResponse\>\.TResponse')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TTargetResponse](CatResponse_TResponse_.Cast.O0BCBT5ZSHDFOS9QZNX8CTSE4.md#Cat.Responses.CatResponse_TResponse_.Cast_TTargetResponse_(System.Func_TResponse,TTargetResponse_).TTargetResponse 'Cat\.Responses\.CatResponse\<TResponse\>\.Cast\<TTargetResponse\>\(System\.Func\<TResponse,TTargetResponse\>\)\.TTargetResponse')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

Converts [Value](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.Value.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1\.Value') to [TTargetResponse](CatResponse_TResponse_.Cast.O0BCBT5ZSHDFOS9QZNX8CTSE4.md#Cat.Responses.CatResponse_TResponse_.Cast_TTargetResponse_(System.Func_TResponse,TTargetResponse_).TTargetResponse 'Cat\.Responses\.CatResponse\<TResponse\>\.Cast\<TTargetResponse\>\(System\.Func\<TResponse,TTargetResponse\>\)\.TTargetResponse')\. Only invoked when the response succeeded\.

Implements [Cast&lt;TTargetResponse&gt;\(Func&lt;TResponse,TTargetResponse&gt;\)](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.Cast.WAJ903NRS5M5P402XGKJZBS0A.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1\.Cast\`\`1\(System\.Func\{\`0,\`\`0\}\)')

#### Returns
[Cat\.Responses\.Abstractions\.ICatResponse&lt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[TTargetResponse](CatResponse_TResponse_.Cast.O0BCBT5ZSHDFOS9QZNX8CTSE4.md#Cat.Responses.CatResponse_TResponse_.Cast_TTargetResponse_(System.Func_TResponse,TTargetResponse_).TTargetResponse 'Cat\.Responses\.CatResponse\<TResponse\>\.Cast\<TTargetResponse\>\(System\.Func\<TResponse,TTargetResponse\>\)\.TTargetResponse')[&gt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')  
A response of the same type, carrying the converted value if it succeeded\.