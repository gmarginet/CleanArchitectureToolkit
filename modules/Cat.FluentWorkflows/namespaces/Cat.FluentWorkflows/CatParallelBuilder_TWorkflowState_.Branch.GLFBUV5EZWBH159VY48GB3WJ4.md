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
  
##### >> [Cat\.FluentWorkflows Assembly](index.md 'index') >> [Cat\.FluentWorkflows\.Steps Namespace](Cat.FluentWorkflows.Steps.md 'Cat\.FluentWorkflows\.Steps') >> [CatParallelBuilder&lt;TWorkflowState&gt; Class](CatParallelBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatParallelBuilder\<TWorkflowState\>')

## CatParallelBuilder\<TWorkflowState\>\.Branch\(Action\<ICatWorkflowBuilder\<TWorkflowState\>\>\) Method

Adds a branch\.

```csharp
public Cat.FluentWorkflows.Abstractions.ICatParallelBuilder<TWorkflowState> Branch(System.Action<Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder<TWorkflowState>> build);
```
#### Parameters

<a name='Cat.FluentWorkflows.Steps.CatParallelBuilder_TWorkflowState_.Branch(System.Action_Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState__).build'></a>

`build` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder&lt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')[TWorkflowState](CatParallelBuilder_TWorkflowState_.md#Cat.FluentWorkflows.Steps.CatParallelBuilder_TWorkflowState_.TWorkflowState 'Cat\.FluentWorkflows\.Steps\.CatParallelBuilder\<TWorkflowState\>\.TWorkflowState')[&gt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

Adds the steps of the branch\.

Implements [Branch\(Action&lt;ICatWorkflowBuilder&lt;TWorkflowState&gt;&gt;\)](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatParallelBuilder_TWorkflowState_.Branch.574FYEXETVJLFK7OA66SQF51A.md 'Cat\.FluentWorkflows\.Abstractions\.ICatParallelBuilder\`1\.Branch\(System\.Action\{Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\{\`0\}\}\)')

#### Returns
[Cat\.FluentWorkflows\.Abstractions\.ICatParallelBuilder&lt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatParallelBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatParallelBuilder\`1')[TWorkflowState](CatParallelBuilder_TWorkflowState_.md#Cat.FluentWorkflows.Steps.CatParallelBuilder_TWorkflowState_.TWorkflowState 'Cat\.FluentWorkflows\.Steps\.CatParallelBuilder\<TWorkflowState\>\.TWorkflowState')[&gt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatParallelBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatParallelBuilder\`1')  
The same builder, so calls can be chained\.