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

## CatApiException\<TResult\> Class

A [CatApiException](CatApiException.md 'Cat\.Api\.Client\.CatApiException') that also carries the error body the generated client read from the answer\.

```csharp
public class CatApiException<TResult> : Cat.Api.Client.CatApiException
```
#### Type parameters

<a name='Cat.Api.Client.CatApiException_TResult_.TResult'></a>

`TResult`

The type of the error body, a generated model\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [System\.Exception](https://learn.microsoft.com/en-us/dotnet/api/system.exception 'System\.Exception') → [CatApiException](CatApiException.md 'Cat\.Api\.Client\.CatApiException') → CatApiException\<TResult\>

| Constructors | |
| :--- | :--- |
| [CatApiException\(string, int, string, IReadOnlyDictionary&lt;string,IEnumerable&lt;string&gt;&gt;, TResult, Exception\)](CatApiException_TResult_..ctor.YR6XG7BA4V3UL8ZAC8AYJ5FQE.md 'Cat\.Api\.Client\.CatApiException\<TResult\>\.CatApiException\(string, int, string, System\.Collections\.Generic\.IReadOnlyDictionary\<string,System\.Collections\.Generic\.IEnumerable\<string\>\>, TResult, System\.Exception\)') | Creates the exception with the details of the failed answer and its parsed body\. |

| Properties | |
| :--- | :--- |
| [Result](CatApiException_TResult_.Result.md 'Cat\.Api\.Client\.CatApiException\<TResult\>\.Result') | The body of the answer, read into the generated model\. |
