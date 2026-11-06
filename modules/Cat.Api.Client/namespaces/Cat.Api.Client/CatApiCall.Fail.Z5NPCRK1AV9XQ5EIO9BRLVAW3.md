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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.API.CLIENT](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Api\.Client Assembly](index.md 'index') >> [Cat\.Api\.Client Namespace](Cat.Api.Client.md 'Cat\.Api\.Client') >> [CatApiCall Class](CatApiCall.md 'Cat\.Api\.Client\.CatApiCall')

## CatApiCall\.Fail\<TResponse\>\(Exception, string\) Method

```csharp
private static Cat.Responses.Abstractions.ICatResponse<TResponse> Fail<TResponse>(System.Exception exception, string serviceName);
```
#### Type parameters

<a name='Cat.Api.Client.CatApiCall.Fail_TResponse_(System.Exception,string).TResponse'></a>

`TResponse`
#### Parameters

<a name='Cat.Api.Client.CatApiCall.Fail_TResponse_(System.Exception,string).exception'></a>

`exception` [System\.Exception](https://learn.microsoft.com/en-us/dotnet/api/system.exception 'System\.Exception')

<a name='Cat.Api.Client.CatApiCall.Fail_TResponse_(System.Exception,string).serviceName'></a>

`serviceName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

#### Returns
[Cat\.Responses\.Abstractions\.ICatResponse&lt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[TResponse](CatApiCall.Fail.Z5NPCRK1AV9XQ5EIO9BRLVAW3.md#Cat.Api.Client.CatApiCall.Fail_TResponse_(System.Exception,string).TResponse 'Cat\.Api\.Client\.CatApiCall\.Fail\<TResponse\>\(System\.Exception, string\)\.TResponse')[&gt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')