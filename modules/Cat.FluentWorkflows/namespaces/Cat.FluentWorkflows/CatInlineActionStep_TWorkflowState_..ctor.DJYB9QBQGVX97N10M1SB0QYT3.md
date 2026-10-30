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
  
##### >> [Cat\.FluentWorkflows Assembly](index.md 'index') >> [Cat\.FluentWorkflows\.Steps Namespace](Cat.FluentWorkflows.Steps.md 'Cat\.FluentWorkflows\.Steps') >> [CatInlineActionStep&lt;TWorkflowState&gt; Class](CatInlineActionStep_TWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatInlineActionStep\<TWorkflowState\>')

## CatInlineActionStep\(ILogger\<CatInlineActionStep\<TWorkflowState\>\>\) Constructor

Creates the step\.

```csharp
public CatInlineActionStep(Microsoft.Extensions.Logging.ILogger<Cat.FluentWorkflows.Steps.CatInlineActionStep<TWorkflowState>> logger);
```
#### Parameters

<a name='Cat.FluentWorkflows.Steps.CatInlineActionStep_TWorkflowState_.CatInlineActionStep(Microsoft.Extensions.Logging.ILogger_Cat.FluentWorkflows.Steps.CatInlineActionStep_TWorkflowState__).logger'></a>

`logger` [Microsoft\.Extensions\.Logging\.ILogger&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')[Cat\.FluentWorkflows\.Steps\.CatInlineActionStep&lt;](CatInlineActionStep_TWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatInlineActionStep\<TWorkflowState\>')[TWorkflowState](CatInlineActionStep_TWorkflowState_.md#Cat.FluentWorkflows.Steps.CatInlineActionStep_TWorkflowState_.TWorkflowState 'Cat\.FluentWorkflows\.Steps\.CatInlineActionStep\<TWorkflowState\>\.TWorkflowState')[&gt;](CatInlineActionStep_TWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatInlineActionStep\<TWorkflowState\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')

The logger the step passes to your code\.