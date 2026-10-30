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
  
##### >> [Cat\.FluentWorkflows\.Abstractions Assembly](index.md 'index') >> [Cat\.FluentWorkflows\.Abstractions Namespace](Cat.FluentWorkflows.Abstractions.md 'Cat\.FluentWorkflows\.Abstractions') >> [ICatStepBuilder&lt;TWorkflowState,TStepBody&gt; Interface](ICatStepBuilder_TWorkflowState,TStepBody_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder\<TWorkflowState,TStepBody\>')

## ICatStepBuilder\<TWorkflowState,TStepBody\>\.Output\<TOutput\>\(Expression\<Func\<TStepBody,TOutput\>\>, Expression\<Func\<TWorkflowState,TOutput\>\>\) Method

Copies a value from a member of the step into the workflow state, right after the step ran\.

```csharp
Cat.FluentWorkflows.Abstractions.ICatStepBuilder<TWorkflowState,TStepBody> Output<TOutput>(System.Linq.Expressions.Expression<System.Func<TStepBody,TOutput>> source, System.Linq.Expressions.Expression<System.Func<TWorkflowState,TOutput>> target);
```
#### Type parameters

<a name='Cat.FluentWorkflows.Abstractions.ICatStepBuilder_TWorkflowState,TStepBody_.Output_TOutput_(System.Linq.Expressions.Expression_System.Func_TStepBody,TOutput__,System.Linq.Expressions.Expression_System.Func_TWorkflowState,TOutput__).TOutput'></a>

`TOutput`

The type of the value\.
#### Parameters

<a name='Cat.FluentWorkflows.Abstractions.ICatStepBuilder_TWorkflowState,TStepBody_.Output_TOutput_(System.Linq.Expressions.Expression_System.Func_TStepBody,TOutput__,System.Linq.Expressions.Expression_System.Func_TWorkflowState,TOutput__).source'></a>

`source` [System\.Linq\.Expressions\.Expression&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')[System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TStepBody](ICatStepBuilder_TWorkflowState,TStepBody_.md#Cat.FluentWorkflows.Abstractions.ICatStepBuilder_TWorkflowState,TStepBody_.TStepBody 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder\<TWorkflowState,TStepBody\>\.TStepBody')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TOutput](ICatStepBuilder_TWorkflowState,TStepBody_.Output.GL4EJ5MHMHDQM7R47T76EDI69.md#Cat.FluentWorkflows.Abstractions.ICatStepBuilder_TWorkflowState,TStepBody_.Output_TOutput_(System.Linq.Expressions.Expression_System.Func_TStepBody,TOutput__,System.Linq.Expressions.Expression_System.Func_TWorkflowState,TOutput__).TOutput 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder\<TWorkflowState,TStepBody\>\.Output\<TOutput\>\(System\.Linq\.Expressions\.Expression\<System\.Func\<TStepBody,TOutput\>\>, System\.Linq\.Expressions\.Expression\<System\.Func\<TWorkflowState,TOutput\>\>\)\.TOutput')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')

Reads the value from the step, like `step => step.Result`\.

<a name='Cat.FluentWorkflows.Abstractions.ICatStepBuilder_TWorkflowState,TStepBody_.Output_TOutput_(System.Linq.Expressions.Expression_System.Func_TStepBody,TOutput__,System.Linq.Expressions.Expression_System.Func_TWorkflowState,TOutput__).target'></a>

`target` [System\.Linq\.Expressions\.Expression&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')[System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TWorkflowState](ICatStepBuilder_TWorkflowState,TStepBody_.md#Cat.FluentWorkflows.Abstractions.ICatStepBuilder_TWorkflowState,TStepBody_.TWorkflowState 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder\<TWorkflowState,TStepBody\>\.TWorkflowState')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TOutput](ICatStepBuilder_TWorkflowState,TStepBody_.Output.GL4EJ5MHMHDQM7R47T76EDI69.md#Cat.FluentWorkflows.Abstractions.ICatStepBuilder_TWorkflowState,TStepBody_.Output_TOutput_(System.Linq.Expressions.Expression_System.Func_TStepBody,TOutput__,System.Linq.Expressions.Expression_System.Func_TWorkflowState,TOutput__).TOutput 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder\<TWorkflowState,TStepBody\>\.Output\<TOutput\>\(System\.Linq\.Expressions\.Expression\<System\.Func\<TStepBody,TOutput\>\>, System\.Linq\.Expressions\.Expression\<System\.Func\<TWorkflowState,TOutput\>\>\)\.TOutput')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')

Picks the property of the state to fill, like `s => s.Total`\. It must be a member access\.

#### Returns
[Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder&lt;](ICatStepBuilder_TWorkflowState,TStepBody_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder\<TWorkflowState,TStepBody\>')[TWorkflowState](ICatStepBuilder_TWorkflowState,TStepBody_.md#Cat.FluentWorkflows.Abstractions.ICatStepBuilder_TWorkflowState,TStepBody_.TWorkflowState 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder\<TWorkflowState,TStepBody\>\.TWorkflowState')[,](ICatStepBuilder_TWorkflowState,TStepBody_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder\<TWorkflowState,TStepBody\>')[TStepBody](ICatStepBuilder_TWorkflowState,TStepBody_.md#Cat.FluentWorkflows.Abstractions.ICatStepBuilder_TWorkflowState,TStepBody_.TStepBody 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder\<TWorkflowState,TStepBody\>\.TStepBody')[&gt;](ICatStepBuilder_TWorkflowState,TStepBody_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder\<TWorkflowState,TStepBody\>')  
The same builder, so calls can be chained\.