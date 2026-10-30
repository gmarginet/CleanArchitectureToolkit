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
  
##### >> [Cat\.FluentWorkflows Assembly](index.md 'index') >> [Cat\.FluentWorkflows\.Extensions Namespace](Cat.FluentWorkflows.Extensions.md 'Cat\.FluentWorkflows\.Extensions') >> [CatWorkflowBuilderExtensions Class](CatWorkflowBuilderExtensions.md 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions')

## CatWorkflowBuilderExtensions\.BreakFromCurrentFlowOnly\<TWorkflowState\>\(this ICatWorkflowBuilder\<TWorkflowState\>\) Method

Adds a step that ends the workflow\. The caller of the workflow goes on as if it succeeded\.

```csharp
public static void BreakFromCurrentFlowOnly<TWorkflowState>(this Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder<TWorkflowState> builder)
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>;
```
#### Type parameters

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.BreakFromCurrentFlowOnly_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_).TWorkflowState'></a>

`TWorkflowState`

The state of the workflow\.
#### Parameters

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.BreakFromCurrentFlowOnly_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_).builder'></a>

`builder` [Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder&lt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')[TWorkflowState](CatWorkflowBuilderExtensions.BreakFromCurrentFlowOnly.A7I36ODL7WA1CWODNQXB67Z7A.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.BreakFromCurrentFlowOnly_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_).TWorkflowState 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.BreakFromCurrentFlowOnly\<TWorkflowState\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>\)\.TWorkflowState')[&gt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')

The builder to add the step to\.