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
  
##### >> [Cat\.Api\.Client Assembly](index.md 'index') >> [Cat\.Api\.Client Namespace](Cat.Api.Client.md 'Cat\.Api\.Client') >> [CatApiException Class](CatApiException.md 'Cat\.Api\.Client\.CatApiException')

## CatApiException\(string, int, string, IReadOnlyDictionary\<string,IEnumerable\<string\>\>, Exception\) Constructor

Creates the exception with the details of the failed answer\.

```csharp
public CatApiException(string message, int statusCode, string? response, System.Collections.Generic.IReadOnlyDictionary<string,System.Collections.Generic.IEnumerable<string>> headers, System.Exception? innerException);
```
#### Parameters

<a name='Cat.Api.Client.CatApiException.CatApiException(string,int,string,System.Collections.Generic.IReadOnlyDictionary_string,System.Collections.Generic.IEnumerable_string__,System.Exception).message'></a>

`message` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

A short description of what went wrong\.

<a name='Cat.Api.Client.CatApiException.CatApiException(string,int,string,System.Collections.Generic.IReadOnlyDictionary_string,System.Collections.Generic.IEnumerable_string__,System.Exception).statusCode'></a>

`statusCode` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The HTTP status code of the answer\.

<a name='Cat.Api.Client.CatApiException.CatApiException(string,int,string,System.Collections.Generic.IReadOnlyDictionary_string,System.Collections.Generic.IEnumerable_string__,System.Exception).response'></a>

`response` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The body of the answer as text, or `null` when it has none\.

<a name='Cat.Api.Client.CatApiException.CatApiException(string,int,string,System.Collections.Generic.IReadOnlyDictionary_string,System.Collections.Generic.IEnumerable_string__,System.Exception).headers'></a>

`headers` [System\.Collections\.Generic\.IReadOnlyDictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlydictionary-2 'System\.Collections\.Generic\.IReadOnlyDictionary\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlydictionary-2 'System\.Collections\.Generic\.IReadOnlyDictionary\`2')[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlydictionary-2 'System\.Collections\.Generic\.IReadOnlyDictionary\`2')

The headers of the answer\.

<a name='Cat.Api.Client.CatApiException.CatApiException(string,int,string,System.Collections.Generic.IReadOnlyDictionary_string,System.Collections.Generic.IEnumerable_string__,System.Exception).innerException'></a>

`innerException` [System\.Exception](https://learn.microsoft.com/en-us/dotnet/api/system.exception 'System\.Exception')

The exception that caused this one, if any\.