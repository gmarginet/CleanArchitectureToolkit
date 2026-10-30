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
  
##### >> [Cat\.Responses\.Abstractions Assembly](index.md 'index')

## Cat\.Responses\.Abstractions Namespace

Defines the contracts for representing an operation's outcome, its possible response types, and the errors
behind a failure, without depending on any concrete implementation\.

| Classes | |
| :--- | :--- |
| [CatResponseType](CatResponseType.md 'Cat\.Responses\.Abstractions\.CatResponseType') | Identifies the specific outcome of an operation, such as [Ok](CatResponseType.Ok.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Ok') or [NotFound](CatResponseType.NotFound.md 'Cat\.Responses\.Abstractions\.CatResponseType\.NotFound')\. Every outcome is either a [Succeeded](CatResponseType.Succeeded.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Succeeded') or a [Failed](CatResponseType.Failed.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Failed') variant, so matching on the base type tells you whether a response succeeded without inspecting the concrete outcome\. |
| [CatResponseType\.Failed](CatResponseType.Failed.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Failed') | Base type for every outcome that represents a failed operation\. |
| [CatResponseType\.Failed\.BadRequest](CatResponseType.Failed.BadRequest.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Failed\.BadRequest') | The response type for [BadRequest](CatResponseType.BadRequest.md 'Cat\.Responses\.Abstractions\.CatResponseType\.BadRequest')\. |
| [CatResponseType\.Failed\.InternalServerError](CatResponseType.Failed.InternalServerError.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Failed\.InternalServerError') | The response type for [InternalServerError](CatResponseType.InternalServerError.md 'Cat\.Responses\.Abstractions\.CatResponseType\.InternalServerError')\. |
| [CatResponseType\.Failed\.NotFound](CatResponseType.Failed.NotFound.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Failed\.NotFound') | The response type for [NotFound](CatResponseType.NotFound.md 'Cat\.Responses\.Abstractions\.CatResponseType\.NotFound')\. |
| [CatResponseType\.Failed\.Unauthorized](CatResponseType.Failed.Unauthorized.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Failed\.Unauthorized') | The response type for [Unauthorized](CatResponseType.Unauthorized.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Unauthorized')\. |
| [CatResponseType\.Succeeded](CatResponseType.Succeeded.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Succeeded') | Base type for every outcome that represents a successful operation\. |
| [CatResponseType\.Succeeded\.Created](CatResponseType.Succeeded.Created.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Succeeded\.Created') | The response type for [Created](CatResponseType.Created.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Created')\. |
| [CatResponseType\.Succeeded\.NoContent](CatResponseType.Succeeded.NoContent.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Succeeded\.NoContent') | The response type for [NoContent](CatResponseType.NoContent.md 'Cat\.Responses\.Abstractions\.CatResponseType\.NoContent')\. |
| [CatResponseType\.Succeeded\.Ok](CatResponseType.Succeeded.Ok.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Succeeded\.Ok') | The response type for [Ok](CatResponseType.Ok.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Ok')\. |

| Interfaces | |
| :--- | :--- |
| [ICatError](ICatError.md 'Cat\.Responses\.Abstractions\.ICatError') | Describes one error that caused a response to fail\. |
| [ICatResponse](ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse') | Represents the outcome of an operation: whether it succeeded or failed, its specific [CatResponseType](CatResponseType.md 'Cat\.Responses\.Abstractions\.CatResponseType'), and any errors that caused it to fail\. |
| [ICatResponse&lt;TResponse&gt;](ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\<TResponse\>') | An [ICatResponse](ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse') that carries a value when it succeeds\. |
