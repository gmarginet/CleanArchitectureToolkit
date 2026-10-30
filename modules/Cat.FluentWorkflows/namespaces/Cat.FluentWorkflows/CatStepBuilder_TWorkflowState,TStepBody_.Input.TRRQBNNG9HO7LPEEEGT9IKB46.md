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
  
##### >> [Cat\.FluentWorkflows Assembly](index.md 'index') >> [Cat\.FluentWorkflows Namespace](Cat.FluentWorkflows.md 'Cat\.FluentWorkflows') >> [CatStepBuilder&lt;TWorkflowState,TStepBody&gt; Class](CatStepBuilder_TWorkflowState,TStepBody_.md 'Cat\.FluentWorkflows\.CatStepBuilder\<TWorkflowState,TStepBody\>')

## CatStepBuilder\<TWorkflowState,TStepBody\>\.Input\<TInput\>\(Expression\<Func\<TWorkflowState,TInput\>\>, Expression\<Func\<TStepBody,TInput\>\>\) Method

Copies a value from the workflow state into a member of the step, right before the step runs\.

```csharp
public Cat.FluentWorkflows.Abstractions.ICatStepBuilder<TWorkflowState,TStepBody> Input<TInput>(System.Linq.Expressions.Expression<System.Func<TWorkflowState,TInput>> source, System.Linq.Expressions.Expression<System.Func<TStepBody,TInput>> target);
```
#### Type parameters

<a name='Cat.FluentWorkflows.CatStepBuilder_TWorkflowState,TStepBody_.Input_TInput_(System.Linq.Expressions.Expression_System.Func_TWorkflowState,TInput__,System.Linq.Expressions.Expression_System.Func_TStepBody,TInput__).TInput'></a>

`TInput`

The type of the value\.
#### Parameters

<a name='Cat.FluentWorkflows.CatStepBuilder_TWorkflowState,TStepBody_.Input_TInput_(System.Linq.Expressions.Expression_System.Func_TWorkflowState,TInput__,System.Linq.Expressions.Expression_System.Func_TStepBody,TInput__).source'></a>

`source` [System\.Linq\.Expressions\.Expression&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')[System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TWorkflowState](CatStepBuilder_TWorkflowState,TStepBody_.md#Cat.FluentWorkflows.CatStepBuilder_TWorkflowState,TStepBody_.TWorkflowState 'Cat\.FluentWorkflows\.CatStepBuilder\<TWorkflowState,TStepBody\>\.TWorkflowState')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TInput](CatStepBuilder_TWorkflowState,TStepBody_.Input.TRRQBNNG9HO7LPEEEGT9IKB46.md#Cat.FluentWorkflows.CatStepBuilder_TWorkflowState,TStepBody_.Input_TInput_(System.Linq.Expressions.Expression_System.Func_TWorkflowState,TInput__,System.Linq.Expressions.Expression_System.Func_TStepBody,TInput__).TInput 'Cat\.FluentWorkflows\.CatStepBuilder\<TWorkflowState,TStepBody\>\.Input\<TInput\>\(System\.Linq\.Expressions\.Expression\<System\.Func\<TWorkflowState,TInput\>\>, System\.Linq\.Expressions\.Expression\<System\.Func\<TStepBody,TInput\>\>\)\.TInput')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')

Reads the value from the state, like `s => s.Total`\.

<a name='Cat.FluentWorkflows.CatStepBuilder_TWorkflowState,TStepBody_.Input_TInput_(System.Linq.Expressions.Expression_System.Func_TWorkflowState,TInput__,System.Linq.Expressions.Expression_System.Func_TStepBody,TInput__).target'></a>

`target` [System\.Linq\.Expressions\.Expression&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')[System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TStepBody](CatStepBuilder_TWorkflowState,TStepBody_.md#Cat.FluentWorkflows.CatStepBuilder_TWorkflowState,TStepBody_.TStepBody 'Cat\.FluentWorkflows\.CatStepBuilder\<TWorkflowState,TStepBody\>\.TStepBody')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TInput](CatStepBuilder_TWorkflowState,TStepBody_.Input.TRRQBNNG9HO7LPEEEGT9IKB46.md#Cat.FluentWorkflows.CatStepBuilder_TWorkflowState,TStepBody_.Input_TInput_(System.Linq.Expressions.Expression_System.Func_TWorkflowState,TInput__,System.Linq.Expressions.Expression_System.Func_TStepBody,TInput__).TInput 'Cat\.FluentWorkflows\.CatStepBuilder\<TWorkflowState,TStepBody\>\.Input\<TInput\>\(System\.Linq\.Expressions\.Expression\<System\.Func\<TWorkflowState,TInput\>\>, System\.Linq\.Expressions\.Expression\<System\.Func\<TStepBody,TInput\>\>\)\.TInput')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')

Picks the member of the step to fill, like `step => step.Amount`\. It must be a member access\.

Implements [Input&lt;TInput&gt;\(Expression&lt;Func&lt;TWorkflowState,TInput&gt;&gt;, Expression&lt;Func&lt;TStepBody,TInput&gt;&gt;\)](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatStepBuilder_TWorkflowState,TStepBody_.Input.UIKFPDN2N33G1RLIGKEATQGF5.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder\`2\.Input\`\`1\(System\.Linq\.Expressions\.Expression\{System\.Func\{\`0,\`\`0\}\},System\.Linq\.Expressions\.Expression\{System\.Func\{\`1,\`\`0\}\}\)')

#### Returns
[Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder&lt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatStepBuilder_TWorkflowState,TStepBody_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder\`2')[TWorkflowState](CatStepBuilder_TWorkflowState,TStepBody_.md#Cat.FluentWorkflows.CatStepBuilder_TWorkflowState,TStepBody_.TWorkflowState 'Cat\.FluentWorkflows\.CatStepBuilder\<TWorkflowState,TStepBody\>\.TWorkflowState')[,](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatStepBuilder_TWorkflowState,TStepBody_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder\`2')[TStepBody](CatStepBuilder_TWorkflowState,TStepBody_.md#Cat.FluentWorkflows.CatStepBuilder_TWorkflowState,TStepBody_.TStepBody 'Cat\.FluentWorkflows\.CatStepBuilder\<TWorkflowState,TStepBody\>\.TStepBody')[&gt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatStepBuilder_TWorkflowState,TStepBody_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder\`2')  
The same builder, so calls can be chained\.