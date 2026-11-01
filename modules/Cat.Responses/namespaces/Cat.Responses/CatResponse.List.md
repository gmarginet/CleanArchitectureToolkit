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

## CatResponse\.List Class

Factory methods for responses that carry a list of items\.

```csharp
public static class CatResponse.List
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → List

| Methods | |
| :--- | :--- |
| [BadRequest&lt;TResponse&gt;\(ICatError\[\]\)](CatResponse.List.BadRequest.PNIPORT8GM5C3P6OK3RC43AQB.md 'Cat\.Responses\.CatResponse\.List\.BadRequest\<TResponse\>\(Cat\.Responses\.Abstractions\.ICatError\[\]\)') | Creates a failed response with the [BadRequest](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.BadRequest.md 'Cat\.Responses\.Abstractions\.CatResponseType\.BadRequest') outcome\. |
| [Conflict&lt;TResponse&gt;\(ICatError\[\]\)](CatResponse.List.Conflict.GZUMVJUW8TF3OGJM5QH6VLKG5.md 'Cat\.Responses\.CatResponse\.List\.Conflict\<TResponse\>\(Cat\.Responses\.Abstractions\.ICatError\[\]\)') | Creates a failed response with the [Conflict](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.Conflict.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Conflict') outcome\. |
| [Created&lt;TResponse&gt;\(IReadOnlyList&lt;TResponse&gt;\)](CatResponse.List.Created.78BGAF2PH01BZ5WYOXHVLQJH6.md 'Cat\.Responses\.CatResponse\.List\.Created\<TResponse\>\(System\.Collections\.Generic\.IReadOnlyList\<TResponse\>\)') | Creates a succeeded response with the [Created](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.Created.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Created') outcome, carrying the given list\. |
| [Forbidden&lt;TResponse&gt;\(ICatError\[\]\)](CatResponse.List.Forbidden.06K4P83PZTL9VWVIHKYV5N8PE.md 'Cat\.Responses\.CatResponse\.List\.Forbidden\<TResponse\>\(Cat\.Responses\.Abstractions\.ICatError\[\]\)') | Creates a failed response with the [Forbidden](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.Forbidden.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Forbidden') outcome\. |
| [InternalServerError&lt;TResponse&gt;\(ICatError\[\]\)](CatResponse.List.InternalServerError.U4WX6P2XYC2JX8YH774B7C7BC.md 'Cat\.Responses\.CatResponse\.List\.InternalServerError\<TResponse\>\(Cat\.Responses\.Abstractions\.ICatError\[\]\)') | Creates a failed response with the [InternalServerError](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.InternalServerError.md 'Cat\.Responses\.Abstractions\.CatResponseType\.InternalServerError') outcome\. |
| [NoContent&lt;TResponse&gt;\(\)](CatResponse.List.NoContent_TResponse_().md 'Cat\.Responses\.CatResponse\.List\.NoContent\<TResponse\>\(\)') | Creates a succeeded response with the [NoContent](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.NoContent.md 'Cat\.Responses\.Abstractions\.CatResponseType\.NoContent') outcome and no list\. |
| [NotFound&lt;TResponse&gt;\(ICatError\[\]\)](CatResponse.List.NotFound.L07O7V5DH1KOLUOATAA9BZD8C.md 'Cat\.Responses\.CatResponse\.List\.NotFound\<TResponse\>\(Cat\.Responses\.Abstractions\.ICatError\[\]\)') | Creates a failed response with the [NotFound](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.NotFound.md 'Cat\.Responses\.Abstractions\.CatResponseType\.NotFound') outcome\. |
| [Ok&lt;TResponse&gt;\(IReadOnlyList&lt;TResponse&gt;\)](CatResponse.List.Ok.LNQXCXSNFD6AHN88KPJ2GMP56.md 'Cat\.Responses\.CatResponse\.List\.Ok\<TResponse\>\(System\.Collections\.Generic\.IReadOnlyList\<TResponse\>\)') | Creates a succeeded response with the [Ok](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.Ok.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Ok') outcome, carrying the given list\. |
| [Unauthorized&lt;TResponse&gt;\(ICatError\[\]\)](CatResponse.List.Unauthorized.HGOAOFOB3QZ9FJ88LFOCIHFT9.md 'Cat\.Responses\.CatResponse\.List\.Unauthorized\<TResponse\>\(Cat\.Responses\.Abstractions\.ICatError\[\]\)') | Creates a failed response with the [Unauthorized](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.Unauthorized.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Unauthorized') outcome\. |
