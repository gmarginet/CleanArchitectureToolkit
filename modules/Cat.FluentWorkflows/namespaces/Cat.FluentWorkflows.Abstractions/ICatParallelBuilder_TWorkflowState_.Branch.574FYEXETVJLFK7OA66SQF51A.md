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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.FLUENTWORKFLOWS](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.FluentWorkflows\.Abstractions Assembly](index.md 'index') >> [Cat\.FluentWorkflows\.Abstractions Namespace](Cat.FluentWorkflows.Abstractions.md 'Cat\.FluentWorkflows\.Abstractions') >> [ICatParallelBuilder&lt;TWorkflowState&gt; Interface](ICatParallelBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatParallelBuilder\<TWorkflowState\>')

## ICatParallelBuilder\<TWorkflowState\>\.Branch\(Action\<ICatWorkflowBuilder\<TWorkflowState\>\>\) Method

Adds a branch\.

```csharp
Cat.FluentWorkflows.Abstractions.ICatParallelBuilder<TWorkflowState> Branch(System.Action<Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder<TWorkflowState>> build);
```
#### Parameters

<a name='Cat.FluentWorkflows.Abstractions.ICatParallelBuilder_TWorkflowState_.Branch(System.Action_Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState__).build'></a>

`build` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder&lt;](ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>')[TWorkflowState](ICatParallelBuilder_TWorkflowState_.md#Cat.FluentWorkflows.Abstractions.ICatParallelBuilder_TWorkflowState_.TWorkflowState 'Cat\.FluentWorkflows\.Abstractions\.ICatParallelBuilder\<TWorkflowState\>\.TWorkflowState')[&gt;](ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

Adds the steps of the branch\.

#### Returns
[Cat\.FluentWorkflows\.Abstractions\.ICatParallelBuilder&lt;](ICatParallelBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatParallelBuilder\<TWorkflowState\>')[TWorkflowState](ICatParallelBuilder_TWorkflowState_.md#Cat.FluentWorkflows.Abstractions.ICatParallelBuilder_TWorkflowState_.TWorkflowState 'Cat\.FluentWorkflows\.Abstractions\.ICatParallelBuilder\<TWorkflowState\>\.TWorkflowState')[&gt;](ICatParallelBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatParallelBuilder\<TWorkflowState\>')  
The same builder, so calls can be chained\.