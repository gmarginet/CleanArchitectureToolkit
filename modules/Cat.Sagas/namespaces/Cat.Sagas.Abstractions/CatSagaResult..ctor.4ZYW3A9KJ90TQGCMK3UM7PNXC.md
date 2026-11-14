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
  
##### >> [Cat\.Sagas\.Abstractions Assembly](index.md 'index') >> [Cat\.Sagas\.Abstractions Namespace](Cat.Sagas.Abstractions.md 'Cat\.Sagas\.Abstractions') >> [CatSagaResult Class](CatSagaResult.md 'Cat\.Sagas\.Abstractions\.CatSagaResult')

## CatSagaResult\(Guid, CatSagaStatus, IReadOnlyList\<ICatError\>\) Constructor

Creates the result\.

```csharp
public CatSagaResult(System.Guid instanceId, Cat.Sagas.Abstractions.CatSagaStatus status, System.Collections.Generic.IReadOnlyList<Cat.Responses.Abstractions.ICatError> errors);
```
#### Parameters

<a name='Cat.Sagas.Abstractions.CatSagaResult.CatSagaResult(System.Guid,Cat.Sagas.Abstractions.CatSagaStatus,System.Collections.Generic.IReadOnlyList_Cat.Responses.Abstractions.ICatError_).instanceId'></a>

`instanceId` [System\.Guid](https://learn.microsoft.com/en-us/dotnet/api/system.guid 'System\.Guid')

The id of the instance\.

<a name='Cat.Sagas.Abstractions.CatSagaResult.CatSagaResult(System.Guid,Cat.Sagas.Abstractions.CatSagaStatus,System.Collections.Generic.IReadOnlyList_Cat.Responses.Abstractions.ICatError_).status'></a>

`status` [CatSagaStatus](CatSagaStatus.md 'Cat\.Sagas\.Abstractions\.CatSagaStatus')

Where the instance is now\.

<a name='Cat.Sagas.Abstractions.CatSagaResult.CatSagaResult(System.Guid,Cat.Sagas.Abstractions.CatSagaStatus,System.Collections.Generic.IReadOnlyList_Cat.Responses.Abstractions.ICatError_).errors'></a>

`errors` [System\.Collections\.Generic\.IReadOnlyList&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1 'System\.Collections\.Generic\.IReadOnlyList\`1')[ICatError](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatError.md 'Cat\.Responses\.Abstractions\.ICatError')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1 'System\.Collections\.Generic\.IReadOnlyList\`1')

The errors of the run\. Empty when nothing failed\.