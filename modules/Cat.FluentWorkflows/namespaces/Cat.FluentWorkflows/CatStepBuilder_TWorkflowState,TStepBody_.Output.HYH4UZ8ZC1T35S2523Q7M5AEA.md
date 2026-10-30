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
  
##### >> [Cat\.FluentWorkflows Assembly](index.md 'index') >> [Cat\.FluentWorkflows Namespace](Cat.FluentWorkflows.md 'Cat\.FluentWorkflows') >> [CatStepBuilder&lt;TWorkflowState,TStepBody&gt; Class](CatStepBuilder_TWorkflowState,TStepBody_.md 'Cat\.FluentWorkflows\.CatStepBuilder\<TWorkflowState,TStepBody\>')

## CatStepBuilder\<TWorkflowState,TStepBody\>\.Output\<TOutput\>\(Expression\<Func\<TStepBody,TOutput\>\>, Expression\<Func\<TWorkflowState,TOutput\>\>\) Method

Copies a value from a member of the step into the workflow state, right after the step ran\.

```csharp
public Cat.FluentWorkflows.Abstractions.ICatStepBuilder<TWorkflowState,TStepBody> Output<TOutput>(System.Linq.Expressions.Expression<System.Func<TStepBody,TOutput>> source, System.Linq.Expressions.Expression<System.Func<TWorkflowState,TOutput>> target);
```
#### Type parameters

<a name='Cat.FluentWorkflows.CatStepBuilder_TWorkflowState,TStepBody_.Output_TOutput_(System.Linq.Expressions.Expression_System.Func_TStepBody,TOutput__,System.Linq.Expressions.Expression_System.Func_TWorkflowState,TOutput__).TOutput'></a>

`TOutput`

The type of the value\.
#### Parameters

<a name='Cat.FluentWorkflows.CatStepBuilder_TWorkflowState,TStepBody_.Output_TOutput_(System.Linq.Expressions.Expression_System.Func_TStepBody,TOutput__,System.Linq.Expressions.Expression_System.Func_TWorkflowState,TOutput__).source'></a>

`source` [System\.Linq\.Expressions\.Expression&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')[System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TStepBody](CatStepBuilder_TWorkflowState,TStepBody_.md#Cat.FluentWorkflows.CatStepBuilder_TWorkflowState,TStepBody_.TStepBody 'Cat\.FluentWorkflows\.CatStepBuilder\<TWorkflowState,TStepBody\>\.TStepBody')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TOutput](CatStepBuilder_TWorkflowState,TStepBody_.Output.HYH4UZ8ZC1T35S2523Q7M5AEA.md#Cat.FluentWorkflows.CatStepBuilder_TWorkflowState,TStepBody_.Output_TOutput_(System.Linq.Expressions.Expression_System.Func_TStepBody,TOutput__,System.Linq.Expressions.Expression_System.Func_TWorkflowState,TOutput__).TOutput 'Cat\.FluentWorkflows\.CatStepBuilder\<TWorkflowState,TStepBody\>\.Output\<TOutput\>\(System\.Linq\.Expressions\.Expression\<System\.Func\<TStepBody,TOutput\>\>, System\.Linq\.Expressions\.Expression\<System\.Func\<TWorkflowState,TOutput\>\>\)\.TOutput')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')

Reads the value from the step, like `step => step.Result`\.

<a name='Cat.FluentWorkflows.CatStepBuilder_TWorkflowState,TStepBody_.Output_TOutput_(System.Linq.Expressions.Expression_System.Func_TStepBody,TOutput__,System.Linq.Expressions.Expression_System.Func_TWorkflowState,TOutput__).target'></a>

`target` [System\.Linq\.Expressions\.Expression&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')[System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TWorkflowState](CatStepBuilder_TWorkflowState,TStepBody_.md#Cat.FluentWorkflows.CatStepBuilder_TWorkflowState,TStepBody_.TWorkflowState 'Cat\.FluentWorkflows\.CatStepBuilder\<TWorkflowState,TStepBody\>\.TWorkflowState')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TOutput](CatStepBuilder_TWorkflowState,TStepBody_.Output.HYH4UZ8ZC1T35S2523Q7M5AEA.md#Cat.FluentWorkflows.CatStepBuilder_TWorkflowState,TStepBody_.Output_TOutput_(System.Linq.Expressions.Expression_System.Func_TStepBody,TOutput__,System.Linq.Expressions.Expression_System.Func_TWorkflowState,TOutput__).TOutput 'Cat\.FluentWorkflows\.CatStepBuilder\<TWorkflowState,TStepBody\>\.Output\<TOutput\>\(System\.Linq\.Expressions\.Expression\<System\.Func\<TStepBody,TOutput\>\>, System\.Linq\.Expressions\.Expression\<System\.Func\<TWorkflowState,TOutput\>\>\)\.TOutput')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')

Picks the property of the state to fill, like `s => s.Total`\. It must be a member access\.

Implements [Output&lt;TOutput&gt;\(Expression&lt;Func&lt;TStepBody,TOutput&gt;&gt;, Expression&lt;Func&lt;TWorkflowState,TOutput&gt;&gt;\)](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatStepBuilder_TWorkflowState,TStepBody_.Output.GL4EJ5MHMHDQM7R47T76EDI69.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder\`2\.Output\`\`1\(System\.Linq\.Expressions\.Expression\{System\.Func\{\`1,\`\`0\}\},System\.Linq\.Expressions\.Expression\{System\.Func\{\`0,\`\`0\}\}\)')

#### Returns
[Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder&lt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatStepBuilder_TWorkflowState,TStepBody_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder\`2')[TWorkflowState](CatStepBuilder_TWorkflowState,TStepBody_.md#Cat.FluentWorkflows.CatStepBuilder_TWorkflowState,TStepBody_.TWorkflowState 'Cat\.FluentWorkflows\.CatStepBuilder\<TWorkflowState,TStepBody\>\.TWorkflowState')[,](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatStepBuilder_TWorkflowState,TStepBody_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder\`2')[TStepBody](CatStepBuilder_TWorkflowState,TStepBody_.md#Cat.FluentWorkflows.CatStepBuilder_TWorkflowState,TStepBody_.TStepBody 'Cat\.FluentWorkflows\.CatStepBuilder\<TWorkflowState,TStepBody\>\.TStepBody')[&gt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatStepBuilder_TWorkflowState,TStepBody_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder\`2')  
The same builder, so calls can be chained\.