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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.API.CLIENT](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Api\.Client Assembly](index.md 'index') >> [Cat\.Api\.Client Namespace](Cat.Api.Client.md 'Cat\.Api\.Client')

## CatApiCall Class

Runs a call of a generated client and turns the outcome into an [ICatResponse](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse')\.
A failed call looks like any other failed use case, so the caller never needs to catch the exceptions of the client\.

```csharp
public static class CatApiCall
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatApiCall

| Methods | |
| :--- | :--- |
| [BodyOf\(CatApiException\)](CatApiCall.BodyOf.DH1XZGHU2W1DIO1VDKRZ56B9.md 'Cat\.Api\.Client\.CatApiCall\.BodyOf\(Cat\.Api\.Client\.CatApiException\)') | Gets the body of a failed answer as JSON text\. A generated client keeps the text only for a body it could not read, so a body that it did read comes back from the model it was read into\. |
| [ExecuteAsync\(Func&lt;Task&gt;, string, CancellationToken\)](CatApiCall.ExecuteAsync.md#Cat.Api.Client.CatApiCall.ExecuteAsync(System.Func_System.Threading.Tasks.Task_,string,System.Threading.CancellationToken) 'Cat\.Api\.Client\.CatApiCall\.ExecuteAsync\(System\.Func\<System\.Threading\.Tasks\.Task\>, string, System\.Threading\.CancellationToken\)') | Runs a call that returns nothing\. |
| [ExecuteAsync&lt;TResponse&gt;\(Func&lt;Task&lt;TResponse&gt;&gt;, string, CancellationToken\)](CatApiCall.ExecuteAsync.md#Cat.Api.Client.CatApiCall.ExecuteAsync_TResponse_(System.Func_System.Threading.Tasks.Task_TResponse__,string,System.Threading.CancellationToken) 'Cat\.Api\.Client\.CatApiCall\.ExecuteAsync\<TResponse\>\(System\.Func\<System\.Threading\.Tasks\.Task\<TResponse\>\>, string, System\.Threading\.CancellationToken\)') | Runs a call that returns a value\. |
| [Fail&lt;TResponse&gt;\(Exception, string\)](CatApiCall.Fail.Z5NPCRK1AV9XQ5EIO9BRLVAW3.md 'Cat\.Api\.Client\.CatApiCall\.Fail\<TResponse\>\(System\.Exception, string\)') | |
| [IsApiFailure\(Exception, CancellationToken\)](CatApiCall.IsApiFailure.42TWMR0QIINSDCTYJX460CXT3.md 'Cat\.Api\.Client\.CatApiCall\.IsApiFailure\(System\.Exception, System\.Threading\.CancellationToken\)') | |
| [ReadErrors\(string\)](CatApiCall.ReadErrors.36O4YDYQ2U5XRJ72RVR0CD289.md 'Cat\.Api\.Client\.CatApiCall\.ReadErrors\(string\)') | Reads the errors of a failed answer\. A body that is empty or has another shape gives no errors\. |
| [ToPlainValue\(object\)](CatApiCall.ToPlainValue.CVWKKUHR8K251C2XHFZ5MXPTB.md 'Cat\.Api\.Client\.CatApiCall\.ToPlainValue\(object\)') | The serializer reads an argument into a [System\.Text\.Json\.JsonElement](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.jsonelement 'System\.Text\.Json\.JsonElement')\. This turns it into a plain value\. |
| [Unexpected\(string\)](CatApiCall.Unexpected.1AO9S484S47UDSASVRXQY7KP.md 'Cat\.Api\.Client\.CatApiCall\.Unexpected\(string\)') | |
