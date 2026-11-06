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
  
##### >> [Cat\.Api\.Client Assembly](index.md 'index') >> [Cat\.Api\.Client Namespace](Cat.Api.Client.md 'Cat\.Api\.Client')

## CatApiException Class

Thrown by a generated client when a call fails or answers with something it did not expect\.
The generator settings point at this class, so the generated code needs no exception class of its own\.
Use [CatApiCall](CatApiCall.md 'Cat\.Api\.Client\.CatApiCall') to turn it into an `ICatResponse`\.

```csharp
public class CatApiException : System.Exception
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [System\.Exception](https://learn.microsoft.com/en-us/dotnet/api/system.exception 'System\.Exception') → CatApiException

Derived  
↳ [CatApiException&lt;TResult&gt;](CatApiException_TResult_.md 'Cat\.Api\.Client\.CatApiException\<TResult\>')

| Constructors | |
| :--- | :--- |
| [CatApiException\(string, int, string, IReadOnlyDictionary&lt;string,IEnumerable&lt;string&gt;&gt;, Exception\)](CatApiException..ctor.1G0QMZBOCX3YHJS31RJO8NL0F.md 'Cat\.Api\.Client\.CatApiException\.CatApiException\(string, int, string, System\.Collections\.Generic\.IReadOnlyDictionary\<string,System\.Collections\.Generic\.IEnumerable\<string\>\>, System\.Exception\)') | Creates the exception with the details of the failed answer\. |

| Properties | |
| :--- | :--- |
| [Headers](CatApiException.Headers.md 'Cat\.Api\.Client\.CatApiException\.Headers') | The headers of the answer\. |
| [Response](CatApiException.Response.md 'Cat\.Api\.Client\.CatApiException\.Response') | The body of the answer as text, or `null` when it has none\. |
| [ResultObject](CatApiException.ResultObject.md 'Cat\.Api\.Client\.CatApiException\.ResultObject') | The error body the generated client already read into its own model, or `null` when it did not\. A generated client keeps no body text for a body it can read, so [CatApiCall](CatApiCall.md 'Cat\.Api\.Client\.CatApiCall') uses this to find the errors\. |
| [StatusCode](CatApiException.StatusCode.md 'Cat\.Api\.Client\.CatApiException\.StatusCode') | The HTTP status code of the answer\. |
