<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows](Cat.FluentWorkflows.md 'Cat\.FluentWorkflows') > [CatStepBuilder&lt;TWorkflowState,TStepBody&gt;](CatStepBuilder_TWorkflowState,TStepBody_.md 'Cat\.FluentWorkflows\.CatStepBuilder\<TWorkflowState,TStepBody\>')

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

Implements [Input&lt;TInput&gt;\(Expression&lt;Func&lt;TWorkflowState,TInput&gt;&gt;, Expression&lt;Func&lt;TStepBody,TInput&gt;&gt;\)](../Cat.FluentWorkflows.Abstractions/ICatStepBuilder_TWorkflowState,TStepBody_.Input.UIKFPDN2N33G1RLIGKEATQGF5.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder\`2\.Input\`\`1\(System\.Linq\.Expressions\.Expression\{System\.Func\{\`0,\`\`0\}\},System\.Linq\.Expressions\.Expression\{System\.Func\{\`1,\`\`0\}\}\)')

#### Returns
[Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder&lt;](../Cat.FluentWorkflows.Abstractions/ICatStepBuilder_TWorkflowState,TStepBody_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder\`2')[TWorkflowState](CatStepBuilder_TWorkflowState,TStepBody_.md#Cat.FluentWorkflows.CatStepBuilder_TWorkflowState,TStepBody_.TWorkflowState 'Cat\.FluentWorkflows\.CatStepBuilder\<TWorkflowState,TStepBody\>\.TWorkflowState')[,](../Cat.FluentWorkflows.Abstractions/ICatStepBuilder_TWorkflowState,TStepBody_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder\`2')[TStepBody](CatStepBuilder_TWorkflowState,TStepBody_.md#Cat.FluentWorkflows.CatStepBuilder_TWorkflowState,TStepBody_.TStepBody 'Cat\.FluentWorkflows\.CatStepBuilder\<TWorkflowState,TStepBody\>\.TStepBody')[&gt;](../Cat.FluentWorkflows.Abstractions/ICatStepBuilder_TWorkflowState,TStepBody_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder\`2')  
The same builder, so calls can be chained\.