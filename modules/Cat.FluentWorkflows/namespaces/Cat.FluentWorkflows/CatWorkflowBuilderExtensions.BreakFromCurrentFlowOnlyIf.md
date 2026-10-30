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

## CatWorkflowBuilderExtensions\.BreakFromCurrentFlowOnlyIf Method

| Overloads | |
| :--- | :--- |
| [BreakFromCurrentFlowOnlyIf&lt;TWorkflowState&gt;\(this ICatWorkflowBuilder&lt;TWorkflowState&gt;, Func&lt;ILogger,TWorkflowState,bool&gt;\)](CatWorkflowBuilderExtensions.BreakFromCurrentFlowOnlyIf.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.BreakFromCurrentFlowOnlyIf_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_Microsoft.Extensions.Logging.ILogger,TWorkflowState,bool_) 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.BreakFromCurrentFlowOnlyIf\<TWorkflowState\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, System\.Func\<Microsoft\.Extensions\.Logging\.ILogger,TWorkflowState,bool\>\)') | Adds a step that ends the workflow when the check returns `true`, using a logger\. The caller of the workflow goes on as if it succeeded\. |
| [BreakFromCurrentFlowOnlyIf&lt;TWorkflowState&gt;\(this ICatWorkflowBuilder&lt;TWorkflowState&gt;, Func&lt;TWorkflowState,bool&gt;\)](CatWorkflowBuilderExtensions.BreakFromCurrentFlowOnlyIf.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.BreakFromCurrentFlowOnlyIf_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,bool_) 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.BreakFromCurrentFlowOnlyIf\<TWorkflowState\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, System\.Func\<TWorkflowState,bool\>\)') | Adds a step that ends the workflow when the check returns `true`\. The caller of the workflow goes on as if it succeeded\. |

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.BreakFromCurrentFlowOnlyIf_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_Microsoft.Extensions.Logging.ILogger,TWorkflowState,bool_)'></a>

## CatWorkflowBuilderExtensions\.BreakFromCurrentFlowOnlyIf\<TWorkflowState\>\(this ICatWorkflowBuilder\<TWorkflowState\>, Func\<ILogger,TWorkflowState,bool\>\) Method

Adds a step that ends the workflow when the check returns `true`, using a logger\.
The caller of the workflow goes on as if it succeeded\.

```csharp
public static void BreakFromCurrentFlowOnlyIf<TWorkflowState>(this Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder<TWorkflowState> builder, System.Func<Microsoft.Extensions.Logging.ILogger,TWorkflowState,bool> check)
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>;
```
#### Type parameters

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.BreakFromCurrentFlowOnlyIf_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_Microsoft.Extensions.Logging.ILogger,TWorkflowState,bool_).TWorkflowState'></a>

`TWorkflowState`

The state of the workflow\.
#### Parameters

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.BreakFromCurrentFlowOnlyIf_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_Microsoft.Extensions.Logging.ILogger,TWorkflowState,bool_).builder'></a>

`builder` [Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder&lt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')[TWorkflowState](CatWorkflowBuilderExtensions.BreakFromCurrentFlowOnlyIf.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.BreakFromCurrentFlowOnlyIf_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_Microsoft.Extensions.Logging.ILogger,TWorkflowState,bool_).TWorkflowState 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.BreakFromCurrentFlowOnlyIf\<TWorkflowState\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, System\.Func\<Microsoft\.Extensions\.Logging\.ILogger,TWorkflowState,bool\>\)\.TWorkflowState')[&gt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')

The builder to add the step to\.

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.BreakFromCurrentFlowOnlyIf_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_Microsoft.Extensions.Logging.ILogger,TWorkflowState,bool_).check'></a>

`check` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')[Microsoft\.Extensions\.Logging\.ILogger](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger 'Microsoft\.Extensions\.Logging\.ILogger')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')[TWorkflowState](CatWorkflowBuilderExtensions.BreakFromCurrentFlowOnlyIf.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.BreakFromCurrentFlowOnlyIf_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_Microsoft.Extensions.Logging.ILogger,TWorkflowState,bool_).TWorkflowState 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.BreakFromCurrentFlowOnlyIf\<TWorkflowState\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, System\.Func\<Microsoft\.Extensions\.Logging\.ILogger,TWorkflowState,bool\>\)\.TWorkflowState')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')

Gets the logger and the workflow state\.

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.BreakFromCurrentFlowOnlyIf_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,bool_)'></a>

## CatWorkflowBuilderExtensions\.BreakFromCurrentFlowOnlyIf\<TWorkflowState\>\(this ICatWorkflowBuilder\<TWorkflowState\>, Func\<TWorkflowState,bool\>\) Method

Adds a step that ends the workflow when the check returns `true`\.
The caller of the workflow goes on as if it succeeded\.

```csharp
public static void BreakFromCurrentFlowOnlyIf<TWorkflowState>(this Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder<TWorkflowState> builder, System.Func<TWorkflowState,bool> check)
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>;
```
#### Type parameters

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.BreakFromCurrentFlowOnlyIf_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,bool_).TWorkflowState'></a>

`TWorkflowState`

The state of the workflow\.
#### Parameters

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.BreakFromCurrentFlowOnlyIf_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,bool_).builder'></a>

`builder` [Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder&lt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')[TWorkflowState](CatWorkflowBuilderExtensions.BreakFromCurrentFlowOnlyIf.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.BreakFromCurrentFlowOnlyIf_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,bool_).TWorkflowState 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.BreakFromCurrentFlowOnlyIf\<TWorkflowState\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, System\.Func\<TWorkflowState,bool\>\)\.TWorkflowState')[&gt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')

The builder to add the step to\.

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.BreakFromCurrentFlowOnlyIf_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,bool_).check'></a>

`check` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TWorkflowState](CatWorkflowBuilderExtensions.BreakFromCurrentFlowOnlyIf.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.BreakFromCurrentFlowOnlyIf_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,bool_).TWorkflowState 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.BreakFromCurrentFlowOnlyIf\<TWorkflowState\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, System\.Func\<TWorkflowState,bool\>\)\.TWorkflowState')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

Gets the workflow state\.