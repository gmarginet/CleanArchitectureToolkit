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
  
##### >> [Cat\.FluentWorkflows Assembly](index.md 'index') >> [Cat\.FluentWorkflows\.Extensions Namespace](Cat.FluentWorkflows.Extensions.md 'Cat\.FluentWorkflows\.Extensions') >> [CatWorkflowBuilderExtensions Class](CatWorkflowBuilderExtensions.md 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions')

## CatWorkflowBuilderExtensions\.Parallel\<TWorkflowState\>\(this ICatWorkflowBuilder\<TWorkflowState\>, Action\<ICatParallelBuilder\<TWorkflowState\>\>, CatParallelRule\) Method

Adds a step that runs several branches on the same workflow state\.
The code steps of the branches run one after another, in the order you add the branches\. Only the waiting is parallel:
a branch that suspends waits while the other branches run\.
Two branches must not write the same property of the state\.

```csharp
public static void Parallel<TWorkflowState>(this Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder<TWorkflowState> builder, System.Action<Cat.FluentWorkflows.Abstractions.ICatParallelBuilder<TWorkflowState>> buildBranches, Cat.FluentWorkflows.Abstractions.CatParallelRule rule=Cat.FluentWorkflows.Abstractions.CatParallelRule.FailFast)
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>;
```
#### Type parameters

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Parallel_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Action_Cat.FluentWorkflows.Abstractions.ICatParallelBuilder_TWorkflowState__,Cat.FluentWorkflows.Abstractions.CatParallelRule).TWorkflowState'></a>

`TWorkflowState`

The state of the workflow\.
#### Parameters

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Parallel_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Action_Cat.FluentWorkflows.Abstractions.ICatParallelBuilder_TWorkflowState__,Cat.FluentWorkflows.Abstractions.CatParallelRule).builder'></a>

`builder` [Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder&lt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')[TWorkflowState](CatWorkflowBuilderExtensions.Parallel.KTJ6X1HDNTXAYSFDPTCG85HG7.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Parallel_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Action_Cat.FluentWorkflows.Abstractions.ICatParallelBuilder_TWorkflowState__,Cat.FluentWorkflows.Abstractions.CatParallelRule).TWorkflowState 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.Parallel\<TWorkflowState\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, System\.Action\<Cat\.FluentWorkflows\.Abstractions\.ICatParallelBuilder\<TWorkflowState\>\>, Cat\.FluentWorkflows\.Abstractions\.CatParallelRule\)\.TWorkflowState')[&gt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')

The builder to add the step to\.

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Parallel_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Action_Cat.FluentWorkflows.Abstractions.ICatParallelBuilder_TWorkflowState__,Cat.FluentWorkflows.Abstractions.CatParallelRule).buildBranches'></a>

`buildBranches` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[Cat\.FluentWorkflows\.Abstractions\.ICatParallelBuilder&lt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatParallelBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatParallelBuilder\`1')[TWorkflowState](CatWorkflowBuilderExtensions.Parallel.KTJ6X1HDNTXAYSFDPTCG85HG7.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Parallel_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Action_Cat.FluentWorkflows.Abstractions.ICatParallelBuilder_TWorkflowState__,Cat.FluentWorkflows.Abstractions.CatParallelRule).TWorkflowState 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.Parallel\<TWorkflowState\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, System\.Action\<Cat\.FluentWorkflows\.Abstractions\.ICatParallelBuilder\<TWorkflowState\>\>, Cat\.FluentWorkflows\.Abstractions\.CatParallelRule\)\.TWorkflowState')[&gt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatParallelBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatParallelBuilder\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

Adds the branches, like `p => p.Branch(b => ...).Branch(b => ...)`\.

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Parallel_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Action_Cat.FluentWorkflows.Abstractions.ICatParallelBuilder_TWorkflowState__,Cat.FluentWorkflows.Abstractions.CatParallelRule).rule'></a>

`rule` [CatParallelRule](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/CatParallelRule.md 'Cat\.FluentWorkflows\.Abstractions\.CatParallelRule')

What a failing or suspending branch does to the other branches\. The default is [FailFast](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/CatParallelRule.md#Cat.FluentWorkflows.Abstractions.CatParallelRule.FailFast 'Cat\.FluentWorkflows\.Abstractions\.CatParallelRule\.FailFast')\.