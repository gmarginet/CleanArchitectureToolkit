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

## CatWorkflowBuilderExtensions\.Foreach Method

| Overloads | |
| :--- | :--- |
| [Foreach&lt;TWorkflowState,TCollection,TForeachState&gt;\(this ICatWorkflowBuilder&lt;TWorkflowState&gt;, Func&lt;TWorkflowState,IEnumerable&lt;TCollection&gt;&gt;, Action&lt;ICatWorkflowBuilder&lt;TForeachState&gt;&gt;\)](CatWorkflowBuilderExtensions.Foreach.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Foreach_TWorkflowState,TCollection,TForeachState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,System.Collections.Generic.IEnumerable_TCollection__,System.Action_Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TForeachState__) 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.Foreach\<TWorkflowState,TCollection,TForeachState\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, System\.Func\<TWorkflowState,System\.Collections\.Generic\.IEnumerable\<TCollection\>\>, System\.Action\<Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TForeachState\>\>\)') | Adds a step that runs a list of steps for every item of a collection, on a state class of your own\. Use it when the inner steps need extra data next to the current item\. The class needs a parameterless constructor\. Give all three type arguments, like `builder.Foreach<OrderState, OrderLine, OrderLineState>(s => s.Lines, buildLoop)`\. |
| [Foreach&lt;TWorkflowState,TCollection&gt;\(this ICatWorkflowBuilder&lt;TWorkflowState&gt;, Func&lt;TWorkflowState,IEnumerable&lt;TCollection&gt;&gt;, Action&lt;ICatWorkflowBuilder&lt;ICatForeachState&lt;TCollection,TWorkflowState&gt;&gt;&gt;\)](CatWorkflowBuilderExtensions.Foreach.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Foreach_TWorkflowState,TCollection_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,System.Collections.Generic.IEnumerable_TCollection__,System.Action_Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_Cat.FluentWorkflows.Abstractions.ICatForeachState_TCollection,TWorkflowState___) 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.Foreach\<TWorkflowState,TCollection\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, System\.Func\<TWorkflowState,System\.Collections\.Generic\.IEnumerable\<TCollection\>\>, System\.Action\<Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<Cat\.FluentWorkflows\.Abstractions\.ICatForeachState\<TCollection,TWorkflowState\>\>\>\)') | Adds a step that runs a list of steps for every item of a collection\. The inner steps work on an [ICatForeachState&lt;TCollection,TWorkflowState&gt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatForeachState_TCollection,TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatForeachState\`2'), which holds the current item and the state of the workflow around the loop\. Let the compiler work out the type arguments, like `builder.Foreach(s => s.Lines, loop => loop.Run(item => Process(item)))`\. |

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Foreach_TWorkflowState,TCollection,TForeachState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,System.Collections.Generic.IEnumerable_TCollection__,System.Action_Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TForeachState__)'></a>

## CatWorkflowBuilderExtensions\.Foreach\<TWorkflowState,TCollection,TForeachState\>\(this ICatWorkflowBuilder\<TWorkflowState\>, Func\<TWorkflowState,IEnumerable\<TCollection\>\>, Action\<ICatWorkflowBuilder\<TForeachState\>\>\) Method

Adds a step that runs a list of steps for every item of a collection, on a state class of your own\.
Use it when the inner steps need extra data next to the current item\. The class needs a parameterless constructor\.
Give all three type arguments, like `builder.Foreach<OrderState, OrderLine, OrderLineState>(s => s.Lines, buildLoop)`\.

```csharp
public static void Foreach<TWorkflowState,TCollection,TForeachState>(this Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder<TWorkflowState> builder, System.Func<TWorkflowState,System.Collections.Generic.IEnumerable<TCollection>> collection, System.Action<Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder<TForeachState>> build)
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>
    where TForeachState : class, Cat.FluentWorkflows.Abstractions.ICatForeachState<TCollection, TWorkflowState>, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TForeachState>;
```
#### Type parameters

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Foreach_TWorkflowState,TCollection,TForeachState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,System.Collections.Generic.IEnumerable_TCollection__,System.Action_Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TForeachState__).TWorkflowState'></a>

`TWorkflowState`

The state of the workflow\.

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Foreach_TWorkflowState,TCollection,TForeachState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,System.Collections.Generic.IEnumerable_TCollection__,System.Action_Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TForeachState__).TCollection'></a>

`TCollection`

The type of the items\.

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Foreach_TWorkflowState,TCollection,TForeachState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,System.Collections.Generic.IEnumerable_TCollection__,System.Action_Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TForeachState__).TForeachState'></a>

`TForeachState`

Your state class for the loop\.
#### Parameters

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Foreach_TWorkflowState,TCollection,TForeachState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,System.Collections.Generic.IEnumerable_TCollection__,System.Action_Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TForeachState__).builder'></a>

`builder` [Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder&lt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')[TWorkflowState](CatWorkflowBuilderExtensions.Foreach.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Foreach_TWorkflowState,TCollection,TForeachState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,System.Collections.Generic.IEnumerable_TCollection__,System.Action_Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TForeachState__).TWorkflowState 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.Foreach\<TWorkflowState,TCollection,TForeachState\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, System\.Func\<TWorkflowState,System\.Collections\.Generic\.IEnumerable\<TCollection\>\>, System\.Action\<Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TForeachState\>\>\)\.TWorkflowState')[&gt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')

The builder to add the step to\.

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Foreach_TWorkflowState,TCollection,TForeachState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,System.Collections.Generic.IEnumerable_TCollection__,System.Action_Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TForeachState__).collection'></a>

`collection` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TWorkflowState](CatWorkflowBuilderExtensions.Foreach.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Foreach_TWorkflowState,TCollection,TForeachState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,System.Collections.Generic.IEnumerable_TCollection__,System.Action_Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TForeachState__).TWorkflowState 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.Foreach\<TWorkflowState,TCollection,TForeachState\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, System\.Func\<TWorkflowState,System\.Collections\.Generic\.IEnumerable\<TCollection\>\>, System\.Action\<Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TForeachState\>\>\)\.TWorkflowState')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[TCollection](CatWorkflowBuilderExtensions.Foreach.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Foreach_TWorkflowState,TCollection,TForeachState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,System.Collections.Generic.IEnumerable_TCollection__,System.Action_Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TForeachState__).TCollection 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.Foreach\<TWorkflowState,TCollection,TForeachState\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, System\.Func\<TWorkflowState,System\.Collections\.Generic\.IEnumerable\<TCollection\>\>, System\.Action\<Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TForeachState\>\>\)\.TCollection')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

Gets the collection from the workflow state\.

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Foreach_TWorkflowState,TCollection,TForeachState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,System.Collections.Generic.IEnumerable_TCollection__,System.Action_Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TForeachState__).build'></a>

`build` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder&lt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')[TForeachState](CatWorkflowBuilderExtensions.Foreach.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Foreach_TWorkflowState,TCollection,TForeachState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,System.Collections.Generic.IEnumerable_TCollection__,System.Action_Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TForeachState__).TForeachState 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.Foreach\<TWorkflowState,TCollection,TForeachState\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, System\.Func\<TWorkflowState,System\.Collections\.Generic\.IEnumerable\<TCollection\>\>, System\.Action\<Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TForeachState\>\>\)\.TForeachState')[&gt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

Adds the steps to run for each item\.

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Foreach_TWorkflowState,TCollection_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,System.Collections.Generic.IEnumerable_TCollection__,System.Action_Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_Cat.FluentWorkflows.Abstractions.ICatForeachState_TCollection,TWorkflowState___)'></a>

## CatWorkflowBuilderExtensions\.Foreach\<TWorkflowState,TCollection\>\(this ICatWorkflowBuilder\<TWorkflowState\>, Func\<TWorkflowState,IEnumerable\<TCollection\>\>, Action\<ICatWorkflowBuilder\<ICatForeachState\<TCollection,TWorkflowState\>\>\>\) Method

Adds a step that runs a list of steps for every item of a collection\.
The inner steps work on an [ICatForeachState&lt;TCollection,TWorkflowState&gt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatForeachState_TCollection,TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatForeachState\`2'), which holds the current item
and the state of the workflow around the loop\.
Let the compiler work out the type arguments, like `builder.Foreach(s => s.Lines, loop => loop.Run(item => Process(item)))`\.

```csharp
public static void Foreach<TWorkflowState,TCollection>(this Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder<TWorkflowState> builder, System.Func<TWorkflowState,System.Collections.Generic.IEnumerable<TCollection>> collection, System.Action<Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder<Cat.FluentWorkflows.Abstractions.ICatForeachState<TCollection,TWorkflowState>>> build)
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>;
```
#### Type parameters

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Foreach_TWorkflowState,TCollection_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,System.Collections.Generic.IEnumerable_TCollection__,System.Action_Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_Cat.FluentWorkflows.Abstractions.ICatForeachState_TCollection,TWorkflowState___).TWorkflowState'></a>

`TWorkflowState`

The state of the workflow\.

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Foreach_TWorkflowState,TCollection_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,System.Collections.Generic.IEnumerable_TCollection__,System.Action_Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_Cat.FluentWorkflows.Abstractions.ICatForeachState_TCollection,TWorkflowState___).TCollection'></a>

`TCollection`

The type of the items\.
#### Parameters

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Foreach_TWorkflowState,TCollection_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,System.Collections.Generic.IEnumerable_TCollection__,System.Action_Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_Cat.FluentWorkflows.Abstractions.ICatForeachState_TCollection,TWorkflowState___).builder'></a>

`builder` [Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder&lt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')[TWorkflowState](CatWorkflowBuilderExtensions.Foreach.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Foreach_TWorkflowState,TCollection_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,System.Collections.Generic.IEnumerable_TCollection__,System.Action_Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_Cat.FluentWorkflows.Abstractions.ICatForeachState_TCollection,TWorkflowState___).TWorkflowState 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.Foreach\<TWorkflowState,TCollection\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, System\.Func\<TWorkflowState,System\.Collections\.Generic\.IEnumerable\<TCollection\>\>, System\.Action\<Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<Cat\.FluentWorkflows\.Abstractions\.ICatForeachState\<TCollection,TWorkflowState\>\>\>\)\.TWorkflowState')[&gt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')

The builder to add the step to\.

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Foreach_TWorkflowState,TCollection_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,System.Collections.Generic.IEnumerable_TCollection__,System.Action_Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_Cat.FluentWorkflows.Abstractions.ICatForeachState_TCollection,TWorkflowState___).collection'></a>

`collection` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TWorkflowState](CatWorkflowBuilderExtensions.Foreach.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Foreach_TWorkflowState,TCollection_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,System.Collections.Generic.IEnumerable_TCollection__,System.Action_Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_Cat.FluentWorkflows.Abstractions.ICatForeachState_TCollection,TWorkflowState___).TWorkflowState 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.Foreach\<TWorkflowState,TCollection\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, System\.Func\<TWorkflowState,System\.Collections\.Generic\.IEnumerable\<TCollection\>\>, System\.Action\<Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<Cat\.FluentWorkflows\.Abstractions\.ICatForeachState\<TCollection,TWorkflowState\>\>\>\)\.TWorkflowState')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[TCollection](CatWorkflowBuilderExtensions.Foreach.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Foreach_TWorkflowState,TCollection_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,System.Collections.Generic.IEnumerable_TCollection__,System.Action_Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_Cat.FluentWorkflows.Abstractions.ICatForeachState_TCollection,TWorkflowState___).TCollection 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.Foreach\<TWorkflowState,TCollection\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, System\.Func\<TWorkflowState,System\.Collections\.Generic\.IEnumerable\<TCollection\>\>, System\.Action\<Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<Cat\.FluentWorkflows\.Abstractions\.ICatForeachState\<TCollection,TWorkflowState\>\>\>\)\.TCollection')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

Gets the collection from the workflow state\.

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Foreach_TWorkflowState,TCollection_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,System.Collections.Generic.IEnumerable_TCollection__,System.Action_Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_Cat.FluentWorkflows.Abstractions.ICatForeachState_TCollection,TWorkflowState___).build'></a>

`build` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder&lt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')[Cat\.FluentWorkflows\.Abstractions\.ICatForeachState&lt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatForeachState_TCollection,TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatForeachState\`2')[TCollection](CatWorkflowBuilderExtensions.Foreach.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Foreach_TWorkflowState,TCollection_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,System.Collections.Generic.IEnumerable_TCollection__,System.Action_Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_Cat.FluentWorkflows.Abstractions.ICatForeachState_TCollection,TWorkflowState___).TCollection 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.Foreach\<TWorkflowState,TCollection\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, System\.Func\<TWorkflowState,System\.Collections\.Generic\.IEnumerable\<TCollection\>\>, System\.Action\<Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<Cat\.FluentWorkflows\.Abstractions\.ICatForeachState\<TCollection,TWorkflowState\>\>\>\)\.TCollection')[,](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatForeachState_TCollection,TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatForeachState\`2')[TWorkflowState](CatWorkflowBuilderExtensions.Foreach.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Foreach_TWorkflowState,TCollection_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,System.Collections.Generic.IEnumerable_TCollection__,System.Action_Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_Cat.FluentWorkflows.Abstractions.ICatForeachState_TCollection,TWorkflowState___).TWorkflowState 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.Foreach\<TWorkflowState,TCollection\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, System\.Func\<TWorkflowState,System\.Collections\.Generic\.IEnumerable\<TCollection\>\>, System\.Action\<Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<Cat\.FluentWorkflows\.Abstractions\.ICatForeachState\<TCollection,TWorkflowState\>\>\>\)\.TWorkflowState')[&gt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatForeachState_TCollection,TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatForeachState\`2')[&gt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

Adds the steps to run for each item\.