<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows\.Extensions](Cat.FluentWorkflows.Extensions.md 'Cat\.FluentWorkflows\.Extensions') > [CatWorkflowBuilderExtensions](CatWorkflowBuilderExtensions.md 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions')

## CatWorkflowBuilderExtensions\.Set Method

| Overloads | |
| :--- | :--- |
| [Set&lt;TWorkflowState,TProperty&gt;\(this ICatWorkflowBuilder&lt;TWorkflowState&gt;, Expression&lt;Func&lt;TWorkflowState,TProperty&gt;&gt;, Func&lt;TWorkflowState,TProperty&gt;\)](CatWorkflowBuilderExtensions.Set.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Set_TWorkflowState,TProperty_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Linq.Expressions.Expression_System.Func_TWorkflowState,TProperty__,System.Func_TWorkflowState,TProperty_) 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.Set\<TWorkflowState,TProperty\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, System\.Linq\.Expressions\.Expression\<System\.Func\<TWorkflowState,TProperty\>\>, System\.Func\<TWorkflowState,TProperty\>\)') | Adds a step that sets a property of the state\. |
| [Set&lt;TWorkflowState,TProperty&gt;\(this ICatWorkflowBuilder&lt;TWorkflowState&gt;, Expression&lt;Func&lt;TWorkflowState,TProperty&gt;&gt;, Expression&lt;Func&lt;ILogger,TWorkflowState,TProperty&gt;&gt;\)](CatWorkflowBuilderExtensions.Set.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Set_TWorkflowState,TProperty_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Linq.Expressions.Expression_System.Func_TWorkflowState,TProperty__,System.Linq.Expressions.Expression_System.Func_Microsoft.Extensions.Logging.ILogger,TWorkflowState,TProperty__) 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.Set\<TWorkflowState,TProperty\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, System\.Linq\.Expressions\.Expression\<System\.Func\<TWorkflowState,TProperty\>\>, System\.Linq\.Expressions\.Expression\<System\.Func\<Microsoft\.Extensions\.Logging\.ILogger,TWorkflowState,TProperty\>\>\)') | Adds a step that sets a property of the state, using a logger to calculate the value\. |

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Set_TWorkflowState,TProperty_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Linq.Expressions.Expression_System.Func_TWorkflowState,TProperty__,System.Func_TWorkflowState,TProperty_)'></a>

## CatWorkflowBuilderExtensions\.Set\<TWorkflowState,TProperty\>\(this ICatWorkflowBuilder\<TWorkflowState\>, Expression\<Func\<TWorkflowState,TProperty\>\>, Func\<TWorkflowState,TProperty\>\) Method

Adds a step that sets a property of the state\.

```csharp
public static void Set<TWorkflowState,TProperty>(this Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder<TWorkflowState> builder, System.Linq.Expressions.Expression<System.Func<TWorkflowState,TProperty>> stateProperty, System.Func<TWorkflowState,TProperty> getPropertyValue)
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>;
```
#### Type parameters

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Set_TWorkflowState,TProperty_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Linq.Expressions.Expression_System.Func_TWorkflowState,TProperty__,System.Func_TWorkflowState,TProperty_).TWorkflowState'></a>

`TWorkflowState`

The state of the workflow\.

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Set_TWorkflowState,TProperty_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Linq.Expressions.Expression_System.Func_TWorkflowState,TProperty__,System.Func_TWorkflowState,TProperty_).TProperty'></a>

`TProperty`

The type of the property\.
#### Parameters

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Set_TWorkflowState,TProperty_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Linq.Expressions.Expression_System.Func_TWorkflowState,TProperty__,System.Func_TWorkflowState,TProperty_).builder'></a>

`builder` [Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder&lt;](..\Cat.FluentWorkflows.Abstractions\ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')[TWorkflowState](CatWorkflowBuilderExtensions.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Set_TWorkflowState,TProperty_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Linq.Expressions.Expression_System.Func_TWorkflowState,TProperty__,System.Func_TWorkflowState,TProperty_).TWorkflowState 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.Set\<TWorkflowState,TProperty\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, System\.Linq\.Expressions\.Expression\<System\.Func\<TWorkflowState,TProperty\>\>, System\.Func\<TWorkflowState,TProperty\>\)\.TWorkflowState')[&gt;](..\Cat.FluentWorkflows.Abstractions\ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')

The builder to add the step to\.

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Set_TWorkflowState,TProperty_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Linq.Expressions.Expression_System.Func_TWorkflowState,TProperty__,System.Func_TWorkflowState,TProperty_).stateProperty'></a>

`stateProperty` [System\.Linq\.Expressions\.Expression&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')[System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TWorkflowState](CatWorkflowBuilderExtensions.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Set_TWorkflowState,TProperty_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Linq.Expressions.Expression_System.Func_TWorkflowState,TProperty__,System.Func_TWorkflowState,TProperty_).TWorkflowState 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.Set\<TWorkflowState,TProperty\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, System\.Linq\.Expressions\.Expression\<System\.Func\<TWorkflowState,TProperty\>\>, System\.Func\<TWorkflowState,TProperty\>\)\.TWorkflowState')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TProperty](CatWorkflowBuilderExtensions.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Set_TWorkflowState,TProperty_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Linq.Expressions.Expression_System.Func_TWorkflowState,TProperty__,System.Func_TWorkflowState,TProperty_).TProperty 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.Set\<TWorkflowState,TProperty\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, System\.Linq\.Expressions\.Expression\<System\.Func\<TWorkflowState,TProperty\>\>, System\.Func\<TWorkflowState,TProperty\>\)\.TProperty')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')

Picks the property, like `s => s.Total`\.

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Set_TWorkflowState,TProperty_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Linq.Expressions.Expression_System.Func_TWorkflowState,TProperty__,System.Func_TWorkflowState,TProperty_).getPropertyValue'></a>

`getPropertyValue` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TWorkflowState](CatWorkflowBuilderExtensions.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Set_TWorkflowState,TProperty_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Linq.Expressions.Expression_System.Func_TWorkflowState,TProperty__,System.Func_TWorkflowState,TProperty_).TWorkflowState 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.Set\<TWorkflowState,TProperty\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, System\.Linq\.Expressions\.Expression\<System\.Func\<TWorkflowState,TProperty\>\>, System\.Func\<TWorkflowState,TProperty\>\)\.TWorkflowState')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TProperty](CatWorkflowBuilderExtensions.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Set_TWorkflowState,TProperty_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Linq.Expressions.Expression_System.Func_TWorkflowState,TProperty__,System.Func_TWorkflowState,TProperty_).TProperty 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.Set\<TWorkflowState,TProperty\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, System\.Linq\.Expressions\.Expression\<System\.Func\<TWorkflowState,TProperty\>\>, System\.Func\<TWorkflowState,TProperty\>\)\.TProperty')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

Calculates the new value from the state\.

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Set_TWorkflowState,TProperty_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Linq.Expressions.Expression_System.Func_TWorkflowState,TProperty__,System.Linq.Expressions.Expression_System.Func_Microsoft.Extensions.Logging.ILogger,TWorkflowState,TProperty__)'></a>

## CatWorkflowBuilderExtensions\.Set\<TWorkflowState,TProperty\>\(this ICatWorkflowBuilder\<TWorkflowState\>, Expression\<Func\<TWorkflowState,TProperty\>\>, Expression\<Func\<ILogger,TWorkflowState,TProperty\>\>\) Method

Adds a step that sets a property of the state, using a logger to calculate the value\.

```csharp
public static void Set<TWorkflowState,TProperty>(this Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder<TWorkflowState> builder, System.Linq.Expressions.Expression<System.Func<TWorkflowState,TProperty>> stateProperty, System.Linq.Expressions.Expression<System.Func<Microsoft.Extensions.Logging.ILogger,TWorkflowState,TProperty>> getPropertyValue)
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>;
```
#### Type parameters

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Set_TWorkflowState,TProperty_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Linq.Expressions.Expression_System.Func_TWorkflowState,TProperty__,System.Linq.Expressions.Expression_System.Func_Microsoft.Extensions.Logging.ILogger,TWorkflowState,TProperty__).TWorkflowState'></a>

`TWorkflowState`

The state of the workflow\.

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Set_TWorkflowState,TProperty_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Linq.Expressions.Expression_System.Func_TWorkflowState,TProperty__,System.Linq.Expressions.Expression_System.Func_Microsoft.Extensions.Logging.ILogger,TWorkflowState,TProperty__).TProperty'></a>

`TProperty`

The type of the property\.
#### Parameters

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Set_TWorkflowState,TProperty_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Linq.Expressions.Expression_System.Func_TWorkflowState,TProperty__,System.Linq.Expressions.Expression_System.Func_Microsoft.Extensions.Logging.ILogger,TWorkflowState,TProperty__).builder'></a>

`builder` [Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder&lt;](..\Cat.FluentWorkflows.Abstractions\ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')[TWorkflowState](CatWorkflowBuilderExtensions.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Set_TWorkflowState,TProperty_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Linq.Expressions.Expression_System.Func_TWorkflowState,TProperty__,System.Linq.Expressions.Expression_System.Func_Microsoft.Extensions.Logging.ILogger,TWorkflowState,TProperty__).TWorkflowState 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.Set\<TWorkflowState,TProperty\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, System\.Linq\.Expressions\.Expression\<System\.Func\<TWorkflowState,TProperty\>\>, System\.Linq\.Expressions\.Expression\<System\.Func\<Microsoft\.Extensions\.Logging\.ILogger,TWorkflowState,TProperty\>\>\)\.TWorkflowState')[&gt;](..\Cat.FluentWorkflows.Abstractions\ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')

The builder to add the step to\.

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Set_TWorkflowState,TProperty_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Linq.Expressions.Expression_System.Func_TWorkflowState,TProperty__,System.Linq.Expressions.Expression_System.Func_Microsoft.Extensions.Logging.ILogger,TWorkflowState,TProperty__).stateProperty'></a>

`stateProperty` [System\.Linq\.Expressions\.Expression&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')[System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TWorkflowState](CatWorkflowBuilderExtensions.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Set_TWorkflowState,TProperty_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Linq.Expressions.Expression_System.Func_TWorkflowState,TProperty__,System.Linq.Expressions.Expression_System.Func_Microsoft.Extensions.Logging.ILogger,TWorkflowState,TProperty__).TWorkflowState 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.Set\<TWorkflowState,TProperty\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, System\.Linq\.Expressions\.Expression\<System\.Func\<TWorkflowState,TProperty\>\>, System\.Linq\.Expressions\.Expression\<System\.Func\<Microsoft\.Extensions\.Logging\.ILogger,TWorkflowState,TProperty\>\>\)\.TWorkflowState')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TProperty](CatWorkflowBuilderExtensions.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Set_TWorkflowState,TProperty_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Linq.Expressions.Expression_System.Func_TWorkflowState,TProperty__,System.Linq.Expressions.Expression_System.Func_Microsoft.Extensions.Logging.ILogger,TWorkflowState,TProperty__).TProperty 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.Set\<TWorkflowState,TProperty\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, System\.Linq\.Expressions\.Expression\<System\.Func\<TWorkflowState,TProperty\>\>, System\.Linq\.Expressions\.Expression\<System\.Func\<Microsoft\.Extensions\.Logging\.ILogger,TWorkflowState,TProperty\>\>\)\.TProperty')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')

Picks the property, like `s => s.Total`\.

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Set_TWorkflowState,TProperty_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Linq.Expressions.Expression_System.Func_TWorkflowState,TProperty__,System.Linq.Expressions.Expression_System.Func_Microsoft.Extensions.Logging.ILogger,TWorkflowState,TProperty__).getPropertyValue'></a>

`getPropertyValue` [System\.Linq\.Expressions\.Expression&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')[System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')[Microsoft\.Extensions\.Logging\.ILogger](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger 'Microsoft\.Extensions\.Logging\.ILogger')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')[TWorkflowState](CatWorkflowBuilderExtensions.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Set_TWorkflowState,TProperty_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Linq.Expressions.Expression_System.Func_TWorkflowState,TProperty__,System.Linq.Expressions.Expression_System.Func_Microsoft.Extensions.Logging.ILogger,TWorkflowState,TProperty__).TWorkflowState 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.Set\<TWorkflowState,TProperty\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, System\.Linq\.Expressions\.Expression\<System\.Func\<TWorkflowState,TProperty\>\>, System\.Linq\.Expressions\.Expression\<System\.Func\<Microsoft\.Extensions\.Logging\.ILogger,TWorkflowState,TProperty\>\>\)\.TWorkflowState')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')[TProperty](CatWorkflowBuilderExtensions.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Set_TWorkflowState,TProperty_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Linq.Expressions.Expression_System.Func_TWorkflowState,TProperty__,System.Linq.Expressions.Expression_System.Func_Microsoft.Extensions.Logging.ILogger,TWorkflowState,TProperty__).TProperty 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.Set\<TWorkflowState,TProperty\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, System\.Linq\.Expressions\.Expression\<System\.Func\<TWorkflowState,TProperty\>\>, System\.Linq\.Expressions\.Expression\<System\.Func\<Microsoft\.Extensions\.Logging\.ILogger,TWorkflowState,TProperty\>\>\)\.TProperty')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')

Calculates the new value from the logger and the state\.