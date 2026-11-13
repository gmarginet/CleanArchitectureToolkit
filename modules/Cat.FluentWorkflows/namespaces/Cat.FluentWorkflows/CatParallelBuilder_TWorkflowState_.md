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
  
##### >> [Cat\.FluentWorkflows Assembly](index.md 'index') >> [Cat\.FluentWorkflows\.Steps Namespace](Cat.FluentWorkflows.Steps.md 'Cat\.FluentWorkflows\.Steps')

## CatParallelBuilder\<TWorkflowState\> Class

Default [ICatParallelBuilder&lt;TWorkflowState&gt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatParallelBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatParallelBuilder\`1')\.
Collects the branches of a parallel step\.

```csharp
public class CatParallelBuilder<TWorkflowState> : Cat.FluentWorkflows.Abstractions.ICatParallelBuilder<TWorkflowState>
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>
```
#### Type parameters

<a name='Cat.FluentWorkflows.Steps.CatParallelBuilder_TWorkflowState_.TWorkflowState'></a>

`TWorkflowState`

The state of the workflow\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatParallelBuilder\<TWorkflowState\>

Implements [Cat\.FluentWorkflows\.Abstractions\.ICatParallelBuilder&lt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatParallelBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatParallelBuilder\`1')[TWorkflowState](CatParallelBuilder_TWorkflowState_.md#Cat.FluentWorkflows.Steps.CatParallelBuilder_TWorkflowState_.TWorkflowState 'Cat\.FluentWorkflows\.Steps\.CatParallelBuilder\<TWorkflowState\>\.TWorkflowState')[&gt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatParallelBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatParallelBuilder\`1')

| Properties | |
| :--- | :--- |
| [Branches](CatParallelBuilder_TWorkflowState_.Branches.md 'Cat\.FluentWorkflows\.Steps\.CatParallelBuilder\<TWorkflowState\>\.Branches') | The branches added so far\. |

| Methods | |
| :--- | :--- |
| [Branch\(Action&lt;ICatWorkflowBuilder&lt;TWorkflowState&gt;&gt;\)](CatParallelBuilder_TWorkflowState_.Branch.GLFBUV5EZWBH159VY48GB3WJ4.md 'Cat\.FluentWorkflows\.Steps\.CatParallelBuilder\<TWorkflowState\>\.Branch\(System\.Action\<Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>\>\)') | Adds a branch\. |
