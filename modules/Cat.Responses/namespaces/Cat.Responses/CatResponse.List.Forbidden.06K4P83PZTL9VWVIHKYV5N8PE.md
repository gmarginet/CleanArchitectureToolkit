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
  
##### >> [Cat\.Responses Assembly](index.md 'index') >> [Cat\.Responses Namespace](Cat.Responses.md 'Cat\.Responses') >> [CatResponse Class](CatResponse.md 'Cat\.Responses\.CatResponse') >> [List Class](CatResponse.List.md 'Cat\.Responses\.CatResponse\.List')

## CatResponse\.List\.Forbidden\<TResponse\>\(ICatError\[\]\) Method

Creates a failed response with the [Forbidden](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.Forbidden.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Forbidden') outcome\.

```csharp
public static Cat.Responses.Abstractions.ICatResponse<System.Collections.Generic.IReadOnlyList<TResponse>> Forbidden<TResponse>(params Cat.Responses.Abstractions.ICatError[] errors);
```
#### Type parameters

<a name='Cat.Responses.CatResponse.List.Forbidden_TResponse_(Cat.Responses.Abstractions.ICatError[]).TResponse'></a>

`TResponse`

The type of the items the response is typed to\.
#### Parameters

<a name='Cat.Responses.CatResponse.List.Forbidden_TResponse_(Cat.Responses.Abstractions.ICatError[]).errors'></a>

`errors` [ICatError](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatError.md 'Cat\.Responses\.Abstractions\.ICatError')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The errors describing why the caller isn't allowed\.

#### Returns
[Cat\.Responses\.Abstractions\.ICatResponse&lt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[System\.Collections\.Generic\.IReadOnlyList&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1 'System\.Collections\.Generic\.IReadOnlyList\`1')[TResponse](CatResponse.List.Forbidden.06K4P83PZTL9VWVIHKYV5N8PE.md#Cat.Responses.CatResponse.List.Forbidden_TResponse_(Cat.Responses.Abstractions.ICatError[]).TResponse 'Cat\.Responses\.CatResponse\.List\.Forbidden\<TResponse\>\(Cat\.Responses\.Abstractions\.ICatError\[\]\)\.TResponse')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1 'System\.Collections\.Generic\.IReadOnlyList\`1')[&gt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')