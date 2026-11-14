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
  
##### >> [Cat\.Sagas Assembly](index.md 'index') >> [Cat\.Sagas\.Steps Namespace](Cat.Sagas.Steps.md 'Cat\.Sagas\.Steps') >> [CatSendAndWaitStep&lt;TRequest,TAnswer&gt; Class](CatSendAndWaitStep_TRequest,TAnswer_.md 'Cat\.Sagas\.Steps\.CatSendAndWaitStep\<TRequest,TAnswer\>')

## CatSendAndWaitStep\(CatSagaContext, ILogger\<CatSendAndWaitStep\<TRequest,TAnswer\>\>\) Constructor

Creates the step and the request, using the parameterless constructor of the request\.

```csharp
public CatSendAndWaitStep(Cat.Sagas.CatSagaContext context, Microsoft.Extensions.Logging.ILogger<Cat.Sagas.Steps.CatSendAndWaitStep<TRequest,TAnswer>> logger);
```
#### Parameters

<a name='Cat.Sagas.Steps.CatSendAndWaitStep_TRequest,TAnswer_.CatSendAndWaitStep(Cat.Sagas.CatSagaContext,Microsoft.Extensions.Logging.ILogger_Cat.Sagas.Steps.CatSendAndWaitStep_TRequest,TAnswer__).context'></a>

`context` [CatSagaContext](CatSagaContext.md 'Cat\.Sagas\.CatSagaContext')

The running saga\.

<a name='Cat.Sagas.Steps.CatSendAndWaitStep_TRequest,TAnswer_.CatSendAndWaitStep(Cat.Sagas.CatSagaContext,Microsoft.Extensions.Logging.ILogger_Cat.Sagas.Steps.CatSendAndWaitStep_TRequest,TAnswer__).logger'></a>

`logger` [Microsoft\.Extensions\.Logging\.ILogger&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')[Cat\.Sagas\.Steps\.CatSendAndWaitStep&lt;](CatSendAndWaitStep_TRequest,TAnswer_.md 'Cat\.Sagas\.Steps\.CatSendAndWaitStep\<TRequest,TAnswer\>')[TRequest](CatSendAndWaitStep_TRequest,TAnswer_.md#Cat.Sagas.Steps.CatSendAndWaitStep_TRequest,TAnswer_.TRequest 'Cat\.Sagas\.Steps\.CatSendAndWaitStep\<TRequest,TAnswer\>\.TRequest')[,](CatSendAndWaitStep_TRequest,TAnswer_.md 'Cat\.Sagas\.Steps\.CatSendAndWaitStep\<TRequest,TAnswer\>')[TAnswer](CatSendAndWaitStep_TRequest,TAnswer_.md#Cat.Sagas.Steps.CatSendAndWaitStep_TRequest,TAnswer_.TAnswer 'Cat\.Sagas\.Steps\.CatSendAndWaitStep\<TRequest,TAnswer\>\.TAnswer')[&gt;](CatSendAndWaitStep_TRequest,TAnswer_.md 'Cat\.Sagas\.Steps\.CatSendAndWaitStep\<TRequest,TAnswer\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')

The logger the step can use\.