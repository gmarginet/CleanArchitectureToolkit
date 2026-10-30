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

|&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[CAT.FLUENTWORKFLOWS](../../README.md)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.FluentWorkflows Assembly](index.md 'index') >> [Cat\.FluentWorkflows\.Steps Namespace](Cat.FluentWorkflows.Steps.md 'Cat\.FluentWorkflows\.Steps') >> [CatForeachStep&lt;TWorkflowState,TCollection,TForeachState&gt; Class](CatForeachStep_TWorkflowState,TCollection,TForeachState_.md 'Cat\.FluentWorkflows\.Steps\.CatForeachStep\<TWorkflowState,TCollection,TForeachState\>')

## CatForeachStep\(ICatStepProcessor, ILogger\<CatForeachStep\<TWorkflowState,TCollection,TForeachState\>\>\) Constructor

Creates the step\.

```csharp
public CatForeachStep(Cat.FluentWorkflows.Abstractions.ICatStepProcessor catStepProcessor, Microsoft.Extensions.Logging.ILogger<Cat.FluentWorkflows.Steps.CatForeachStep<TWorkflowState,TCollection,TForeachState>> logger);
```
#### Parameters

<a name='Cat.FluentWorkflows.Steps.CatForeachStep_TWorkflowState,TCollection,TForeachState_.CatForeachStep(Cat.FluentWorkflows.Abstractions.ICatStepProcessor,Microsoft.Extensions.Logging.ILogger_Cat.FluentWorkflows.Steps.CatForeachStep_TWorkflowState,TCollection,TForeachState__).catStepProcessor'></a>

`catStepProcessor` [ICatStepProcessor](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatStepProcessor.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepProcessor')

Runs the inner steps\.

<a name='Cat.FluentWorkflows.Steps.CatForeachStep_TWorkflowState,TCollection,TForeachState_.CatForeachStep(Cat.FluentWorkflows.Abstractions.ICatStepProcessor,Microsoft.Extensions.Logging.ILogger_Cat.FluentWorkflows.Steps.CatForeachStep_TWorkflowState,TCollection,TForeachState__).logger'></a>

`logger` [Microsoft\.Extensions\.Logging\.ILogger&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')[Cat\.FluentWorkflows\.Steps\.CatForeachStep&lt;](CatForeachStep_TWorkflowState,TCollection,TForeachState_.md 'Cat\.FluentWorkflows\.Steps\.CatForeachStep\<TWorkflowState,TCollection,TForeachState\>')[TWorkflowState](CatForeachStep_TWorkflowState,TCollection,TForeachState_.md#Cat.FluentWorkflows.Steps.CatForeachStep_TWorkflowState,TCollection,TForeachState_.TWorkflowState 'Cat\.FluentWorkflows\.Steps\.CatForeachStep\<TWorkflowState,TCollection,TForeachState\>\.TWorkflowState')[,](CatForeachStep_TWorkflowState,TCollection,TForeachState_.md 'Cat\.FluentWorkflows\.Steps\.CatForeachStep\<TWorkflowState,TCollection,TForeachState\>')[TCollection](CatForeachStep_TWorkflowState,TCollection,TForeachState_.md#Cat.FluentWorkflows.Steps.CatForeachStep_TWorkflowState,TCollection,TForeachState_.TCollection 'Cat\.FluentWorkflows\.Steps\.CatForeachStep\<TWorkflowState,TCollection,TForeachState\>\.TCollection')[,](CatForeachStep_TWorkflowState,TCollection,TForeachState_.md 'Cat\.FluentWorkflows\.Steps\.CatForeachStep\<TWorkflowState,TCollection,TForeachState\>')[TForeachState](CatForeachStep_TWorkflowState,TCollection,TForeachState_.md#Cat.FluentWorkflows.Steps.CatForeachStep_TWorkflowState,TCollection,TForeachState_.TForeachState 'Cat\.FluentWorkflows\.Steps\.CatForeachStep\<TWorkflowState,TCollection,TForeachState\>\.TForeachState')[&gt;](CatForeachStep_TWorkflowState,TCollection,TForeachState_.md 'Cat\.FluentWorkflows\.Steps\.CatForeachStep\<TWorkflowState,TCollection,TForeachState\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')

The logger the step can use\.