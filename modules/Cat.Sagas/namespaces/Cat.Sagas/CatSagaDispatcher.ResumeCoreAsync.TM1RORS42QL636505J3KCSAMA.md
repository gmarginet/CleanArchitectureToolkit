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
  
##### >> [Cat\.Sagas Assembly](index.md 'index') >> [Cat\.Sagas Namespace](Cat.Sagas.md 'Cat\.Sagas') >> [CatSagaDispatcher Class](CatSagaDispatcher.md 'Cat\.Sagas\.CatSagaDispatcher')

## CatSagaDispatcher\.ResumeCoreAsync\(CatSagaInstance, string, object, CancellationToken\) Method

```csharp
private System.Threading.Tasks.Task<Cat.Responses.Abstractions.ICatResponse> ResumeCoreAsync(Cat.Sagas.Abstractions.CatSagaInstance instance, string target, object answer, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='Cat.Sagas.CatSagaDispatcher.ResumeCoreAsync(Cat.Sagas.Abstractions.CatSagaInstance,string,object,System.Threading.CancellationToken).instance'></a>

`instance` [CatSagaInstance](../../../Cat.Sagas/namespaces/Cat.Sagas.Abstractions/CatSagaInstance.md 'Cat\.Sagas\.Abstractions\.CatSagaInstance')

<a name='Cat.Sagas.CatSagaDispatcher.ResumeCoreAsync(Cat.Sagas.Abstractions.CatSagaInstance,string,object,System.Threading.CancellationToken).target'></a>

`target` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='Cat.Sagas.CatSagaDispatcher.ResumeCoreAsync(Cat.Sagas.Abstractions.CatSagaInstance,string,object,System.Threading.CancellationToken).answer'></a>

`answer` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

<a name='Cat.Sagas.CatSagaDispatcher.ResumeCoreAsync(Cat.Sagas.Abstractions.CatSagaInstance,string,object,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[ICatResponse](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')