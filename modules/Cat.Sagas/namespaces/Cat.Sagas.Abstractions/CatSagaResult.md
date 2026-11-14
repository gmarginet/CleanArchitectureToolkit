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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.SAGAS](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Sagas\.Abstractions Assembly](index.md 'index') >> [Cat\.Sagas\.Abstractions Namespace](Cat.Sagas.Abstractions.md 'Cat\.Sagas\.Abstractions')

## CatSagaResult Class

What a saga run came to: waiting for an answer, done, or failed\.

```csharp
public class CatSagaResult
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatSagaResult

| Constructors | |
| :--- | :--- |
| [CatSagaResult\(Guid, CatSagaStatus, IReadOnlyList&lt;ICatError&gt;\)](CatSagaResult..ctor.4ZYW3A9KJ90TQGCMK3UM7PNXC.md 'Cat\.Sagas\.Abstractions\.CatSagaResult\.CatSagaResult\(System\.Guid, Cat\.Sagas\.Abstractions\.CatSagaStatus, System\.Collections\.Generic\.IReadOnlyList\<Cat\.Responses\.Abstractions\.ICatError\>\)') | Creates the result\. |

| Properties | |
| :--- | :--- |
| [Errors](CatSagaResult.Errors.md 'Cat\.Sagas\.Abstractions\.CatSagaResult\.Errors') | The errors of the run\. Empty when nothing failed\. |
| [InstanceId](CatSagaResult.InstanceId.md 'Cat\.Sagas\.Abstractions\.CatSagaResult\.InstanceId') | The id of the instance\. It is the correlation id of the messages of the saga\. |
| [Status](CatSagaResult.Status.md 'Cat\.Sagas\.Abstractions\.CatSagaResult\.Status') | Where the instance is now\. |
