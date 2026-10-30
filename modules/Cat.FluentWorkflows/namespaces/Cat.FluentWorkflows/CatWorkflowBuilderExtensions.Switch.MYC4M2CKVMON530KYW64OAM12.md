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
  
##### >> [Cat\.FluentWorkflows Assembly](index.md 'index') >> [Cat\.FluentWorkflows\.Extensions Namespace](Cat.FluentWorkflows.Extensions.md 'Cat\.FluentWorkflows\.Extensions') >> [CatWorkflowBuilderExtensions Class](CatWorkflowBuilderExtensions.md 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions')

## CatWorkflowBuilderExtensions\.Switch\<TWorkflowState,TSwitchValue\>\(this ICatWorkflowBuilder\<TWorkflowState\>, Func\<TWorkflowState,TSwitchValue\>, Action\<ICatSwitchCaseBuilder\<TWorkflowState,TSwitchValue\>\>\) Method

Adds a step that runs the list of steps of the case that matches a value\.

```csharp
public static void Switch<TWorkflowState,TSwitchValue>(this Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder<TWorkflowState> builder, System.Func<TWorkflowState,TSwitchValue> switchValue, System.Action<Cat.FluentWorkflows.Abstractions.ICatSwitchCaseBuilder<TWorkflowState,TSwitchValue>> buildSwitchCase)
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>
    where TSwitchValue : struct;
```
#### Type parameters

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Switch_TWorkflowState,TSwitchValue_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,TSwitchValue_,System.Action_Cat.FluentWorkflows.Abstractions.ICatSwitchCaseBuilder_TWorkflowState,TSwitchValue__).TWorkflowState'></a>

`TWorkflowState`

The state of the workflow\.

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Switch_TWorkflowState,TSwitchValue_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,TSwitchValue_,System.Action_Cat.FluentWorkflows.Abstractions.ICatSwitchCaseBuilder_TWorkflowState,TSwitchValue__).TSwitchValue'></a>

`TSwitchValue`

The type of the value, like an enum\.
#### Parameters

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Switch_TWorkflowState,TSwitchValue_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,TSwitchValue_,System.Action_Cat.FluentWorkflows.Abstractions.ICatSwitchCaseBuilder_TWorkflowState,TSwitchValue__).builder'></a>

`builder` [Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder&lt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')[TWorkflowState](CatWorkflowBuilderExtensions.Switch.MYC4M2CKVMON530KYW64OAM12.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Switch_TWorkflowState,TSwitchValue_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,TSwitchValue_,System.Action_Cat.FluentWorkflows.Abstractions.ICatSwitchCaseBuilder_TWorkflowState,TSwitchValue__).TWorkflowState 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.Switch\<TWorkflowState,TSwitchValue\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, System\.Func\<TWorkflowState,TSwitchValue\>, System\.Action\<Cat\.FluentWorkflows\.Abstractions\.ICatSwitchCaseBuilder\<TWorkflowState,TSwitchValue\>\>\)\.TWorkflowState')[&gt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')

The builder to add the step to\.

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Switch_TWorkflowState,TSwitchValue_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,TSwitchValue_,System.Action_Cat.FluentWorkflows.Abstractions.ICatSwitchCaseBuilder_TWorkflowState,TSwitchValue__).switchValue'></a>

`switchValue` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TWorkflowState](CatWorkflowBuilderExtensions.Switch.MYC4M2CKVMON530KYW64OAM12.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Switch_TWorkflowState,TSwitchValue_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,TSwitchValue_,System.Action_Cat.FluentWorkflows.Abstractions.ICatSwitchCaseBuilder_TWorkflowState,TSwitchValue__).TWorkflowState 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.Switch\<TWorkflowState,TSwitchValue\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, System\.Func\<TWorkflowState,TSwitchValue\>, System\.Action\<Cat\.FluentWorkflows\.Abstractions\.ICatSwitchCaseBuilder\<TWorkflowState,TSwitchValue\>\>\)\.TWorkflowState')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TSwitchValue](CatWorkflowBuilderExtensions.Switch.MYC4M2CKVMON530KYW64OAM12.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Switch_TWorkflowState,TSwitchValue_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,TSwitchValue_,System.Action_Cat.FluentWorkflows.Abstractions.ICatSwitchCaseBuilder_TWorkflowState,TSwitchValue__).TSwitchValue 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.Switch\<TWorkflowState,TSwitchValue\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, System\.Func\<TWorkflowState,TSwitchValue\>, System\.Action\<Cat\.FluentWorkflows\.Abstractions\.ICatSwitchCaseBuilder\<TWorkflowState,TSwitchValue\>\>\)\.TSwitchValue')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

Gets the value from the workflow state\.

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Switch_TWorkflowState,TSwitchValue_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,TSwitchValue_,System.Action_Cat.FluentWorkflows.Abstractions.ICatSwitchCaseBuilder_TWorkflowState,TSwitchValue__).buildSwitchCase'></a>

`buildSwitchCase` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[Cat\.FluentWorkflows\.Abstractions\.ICatSwitchCaseBuilder&lt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatSwitchCaseBuilder\`2')[TWorkflowState](CatWorkflowBuilderExtensions.Switch.MYC4M2CKVMON530KYW64OAM12.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Switch_TWorkflowState,TSwitchValue_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,TSwitchValue_,System.Action_Cat.FluentWorkflows.Abstractions.ICatSwitchCaseBuilder_TWorkflowState,TSwitchValue__).TWorkflowState 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.Switch\<TWorkflowState,TSwitchValue\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, System\.Func\<TWorkflowState,TSwitchValue\>, System\.Action\<Cat\.FluentWorkflows\.Abstractions\.ICatSwitchCaseBuilder\<TWorkflowState,TSwitchValue\>\>\)\.TWorkflowState')[,](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatSwitchCaseBuilder\`2')[TSwitchValue](CatWorkflowBuilderExtensions.Switch.MYC4M2CKVMON530KYW64OAM12.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Switch_TWorkflowState,TSwitchValue_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,TSwitchValue_,System.Action_Cat.FluentWorkflows.Abstractions.ICatSwitchCaseBuilder_TWorkflowState,TSwitchValue__).TSwitchValue 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.Switch\<TWorkflowState,TSwitchValue\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, System\.Func\<TWorkflowState,TSwitchValue\>, System\.Action\<Cat\.FluentWorkflows\.Abstractions\.ICatSwitchCaseBuilder\<TWorkflowState,TSwitchValue\>\>\)\.TSwitchValue')[&gt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatSwitchCaseBuilder\`2')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

Adds the cases\.