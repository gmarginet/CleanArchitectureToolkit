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
            <img src='../../../../resources/logo/CatLogo-RoundedCorners-320x160.png' alt='' width='200' style='float: right;'/>
        </td>
    </tr>
    <tr>
        <td colspan='6' markdown='1' style='padding-left: 0; padding-right: 0; padding-top: 15px; padding-bottom: 0; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>

|&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[CAT.FLUENTWORKFLOWS](../../README.md)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.FluentWorkflows Assembly](index.md 'index') >> [Cat\.FluentWorkflows\.Steps Namespace](Cat.FluentWorkflows.Steps.md 'Cat\.FluentWorkflows\.Steps') >> [CatWhileStep&lt;TWorkflowState&gt; Class](CatWhileStep_TWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatWhileStep\<TWorkflowState\>')

## CatWhileStep\(ICatStepProcessor, ILogger\<CatWhileStep\<TWorkflowState\>\>\) Constructor

Creates the step\.

```csharp
public CatWhileStep(Cat.FluentWorkflows.Abstractions.ICatStepProcessor catStepProcessor, Microsoft.Extensions.Logging.ILogger<Cat.FluentWorkflows.Steps.CatWhileStep<TWorkflowState>> logger);
```
#### Parameters

<a name='Cat.FluentWorkflows.Steps.CatWhileStep_TWorkflowState_.CatWhileStep(Cat.FluentWorkflows.Abstractions.ICatStepProcessor,Microsoft.Extensions.Logging.ILogger_Cat.FluentWorkflows.Steps.CatWhileStep_TWorkflowState__).catStepProcessor'></a>

`catStepProcessor` [ICatStepProcessor](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatStepProcessor.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepProcessor')

Runs the inner steps\.

<a name='Cat.FluentWorkflows.Steps.CatWhileStep_TWorkflowState_.CatWhileStep(Cat.FluentWorkflows.Abstractions.ICatStepProcessor,Microsoft.Extensions.Logging.ILogger_Cat.FluentWorkflows.Steps.CatWhileStep_TWorkflowState__).logger'></a>

`logger` [Microsoft\.Extensions\.Logging\.ILogger&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')[Cat\.FluentWorkflows\.Steps\.CatWhileStep&lt;](CatWhileStep_TWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatWhileStep\<TWorkflowState\>')[TWorkflowState](CatWhileStep_TWorkflowState_.md#Cat.FluentWorkflows.Steps.CatWhileStep_TWorkflowState_.TWorkflowState 'Cat\.FluentWorkflows\.Steps\.CatWhileStep\<TWorkflowState\>\.TWorkflowState')[&gt;](CatWhileStep_TWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatWhileStep\<TWorkflowState\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')

The logger the step can use\.