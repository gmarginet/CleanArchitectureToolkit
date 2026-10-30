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
  
##### >> [Cat\.Responses Assembly](index.md 'index')

## Cat\.Responses Namespace

Provides the default [ICatResponse](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse') implementation and its response
factory methods, along with the error and error\-definition types used to describe why a response failed\.

| Classes | |
| :--- | :--- |
| [CatError](CatError.md 'Cat\.Responses\.CatError') | The default [ICatError](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatError.md 'Cat\.Responses\.Abstractions\.ICatError') implementation\. Create instances through its static `Create` overloads, or build one from a reusable [CatErrorDefinition](CatErrorDefinition.md 'Cat\.Responses\.CatErrorDefinition') instead\. |
| [CatErrorDefinition](CatErrorDefinition.md 'Cat\.Responses\.CatErrorDefinition') | A reusable definition for one kind of error: a stable code and a message template\. Define these once, as static fields, and call [CreateCatError\(object\[\]\)](CatErrorDefinition.CreateCatError.5WX0CKR3WJOIDHOM83UIBF54.md 'Cat\.Responses\.CatErrorDefinition\.CreateCatError\(object\[\]\)') wherever that error needs to be raised with specific argument values\. |
| [CatGeneralErrorDefinitions](CatGeneralErrorDefinitions.md 'Cat\.Responses\.CatGeneralErrorDefinitions') | Common error definitions shared across CAT modules\. |
| [CatResponse](CatResponse.md 'Cat\.Responses\.CatResponse') | The default [ICatResponse](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse') implementation\. Create instances through its static factory methods, such as [Ok\(\)](CatResponse.Ok.md#Cat.Responses.CatResponse.Ok() 'Cat\.Responses\.CatResponse\.Ok\(\)') and [NotFound\(ICatError\[\]\)](CatResponse.NotFound.md#Cat.Responses.CatResponse.NotFound(Cat.Responses.Abstractions.ICatError[]) 'Cat\.Responses\.CatResponse\.NotFound\(Cat\.Responses\.Abstractions\.ICatError\[\]\)'), rather than its constructors directly\. |
| [CatResponse&lt;TResponse&gt;](CatResponse_TResponse_.md 'Cat\.Responses\.CatResponse\<TResponse\>') | An [ICatResponse&lt;TResponse&gt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1') implementation\. Created through the static factory methods on [CatResponse](CatResponse.md 'Cat\.Responses\.CatResponse') rather than its constructors directly\. |

| Enums | |
| :--- | :--- |
| [CatResponseStatus](CatResponseStatus.md 'Cat\.Responses\.CatResponseStatus') | Distinguishes a succeeded response from a failed one\. |
