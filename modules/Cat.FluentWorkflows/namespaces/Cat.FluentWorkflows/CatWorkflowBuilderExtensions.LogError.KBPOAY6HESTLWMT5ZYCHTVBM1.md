<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows\.Extensions](Cat.FluentWorkflows.Extensions.md 'Cat\.FluentWorkflows\.Extensions') > [CatWorkflowBuilderExtensions](CatWorkflowBuilderExtensions.md 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions')

## CatWorkflowBuilderExtensions\.LogError\<TWorkflowState\>\(this ICatWorkflowBuilder\<TWorkflowState\>, string, Func\<TWorkflowState,object\[\]\>\) Method

Adds a step that writes a log entry at the Error level\.

```csharp
public static void LogError<TWorkflowState>(this Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder<TWorkflowState> builder, string message, System.Func<TWorkflowState,object[]> getArgs)
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>;
```
#### Type parameters

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.LogError_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,string,System.Func_TWorkflowState,object[]_).TWorkflowState'></a>

`TWorkflowState`

The state of the workflow\.
#### Parameters

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.LogError_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,string,System.Func_TWorkflowState,object[]_).builder'></a>

`builder` [Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder&lt;](..\Cat.FluentWorkflows.Abstractions\ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')[TWorkflowState](CatWorkflowBuilderExtensions.LogError.KBPOAY6HESTLWMT5ZYCHTVBM1.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.LogError_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,string,System.Func_TWorkflowState,object[]_).TWorkflowState 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.LogError\<TWorkflowState\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, string, System\.Func\<TWorkflowState,object\[\]\>\)\.TWorkflowState')[&gt;](..\Cat.FluentWorkflows.Abstractions\ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')

The builder to add the step to\.

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.LogError_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,string,System.Func_TWorkflowState,object[]_).message'></a>

`message` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The message template, like `Order {orderId} failed`\.

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.LogError_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,string,System.Func_TWorkflowState,object[]_).getArgs'></a>

`getArgs` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TWorkflowState](CatWorkflowBuilderExtensions.LogError.KBPOAY6HESTLWMT5ZYCHTVBM1.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.LogError_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,string,System.Func_TWorkflowState,object[]_).TWorkflowState 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.LogError\<TWorkflowState\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, string, System\.Func\<TWorkflowState,object\[\]\>\)\.TWorkflowState')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

Gets the values for the placeholders from the workflow state\.