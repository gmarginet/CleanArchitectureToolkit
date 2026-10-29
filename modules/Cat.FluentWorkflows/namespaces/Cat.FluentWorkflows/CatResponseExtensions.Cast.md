<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows\.Extensions](Cat.FluentWorkflows.Extensions.md 'Cat\.FluentWorkflows\.Extensions') > [CatResponseExtensions](CatResponseExtensions.md 'Cat\.FluentWorkflows\.Extensions\.CatResponseExtensions')

## CatResponseExtensions\.Cast Method

| Overloads | |
| :--- | :--- |
| [Cast\(this ICatResponse, CatStepExecutionResult\)](CatResponseExtensions.Cast.md#Cat.FluentWorkflows.Extensions.CatResponseExtensions.Cast(thisCat.Responses.Abstractions.ICatResponse,Cat.FluentWorkflows.Abstractions.CatStepExecutionResult) 'Cat\.FluentWorkflows\.Extensions\.CatResponseExtensions\.Cast\(this Cat\.Responses\.Abstractions\.ICatResponse, Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\)') | Turns a response into a workflow response\. The errors of a failed response come along\. |
| [Cast&lt;TSource&gt;\(this ICatResponse&lt;TSource&gt;, CatStepExecutionResult\)](CatResponseExtensions.Cast.md#Cat.FluentWorkflows.Extensions.CatResponseExtensions.Cast_TSource_(thisCat.Responses.Abstractions.ICatResponse_TSource_,Cat.FluentWorkflows.Abstractions.CatStepExecutionResult) 'Cat\.FluentWorkflows\.Extensions\.CatResponseExtensions\.Cast\<TSource\>\(this Cat\.Responses\.Abstractions\.ICatResponse\<TSource\>, Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\)') | Turns a response with a payload into a workflow response\. The payload is dropped and the errors of a failed response come along\. |

<a name='Cat.FluentWorkflows.Extensions.CatResponseExtensions.Cast(thisCat.Responses.Abstractions.ICatResponse,Cat.FluentWorkflows.Abstractions.CatStepExecutionResult)'></a>

## CatResponseExtensions\.Cast\(this ICatResponse, CatStepExecutionResult\) Method

Turns a response into a workflow response\. The errors of a failed response come along\.

```csharp
public static Cat.FluentWorkflows.Abstractions.ICatWorkflowResponse Cast(this Cat.Responses.Abstractions.ICatResponse source, Cat.FluentWorkflows.Abstractions.CatStepExecutionResult workflowResult);
```
#### Parameters

<a name='Cat.FluentWorkflows.Extensions.CatResponseExtensions.Cast(thisCat.Responses.Abstractions.ICatResponse,Cat.FluentWorkflows.Abstractions.CatStepExecutionResult).source'></a>

`source` [ICatResponse](../Cat.Responses.Abstractions/ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse')

The response to convert\.

<a name='Cat.FluentWorkflows.Extensions.CatResponseExtensions.Cast(thisCat.Responses.Abstractions.ICatResponse,Cat.FluentWorkflows.Abstractions.CatStepExecutionResult).workflowResult'></a>

`workflowResult` [CatStepExecutionResult](../Cat.FluentWorkflows.Abstractions/CatStepExecutionResult.md 'Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult')

The result for the step processor\. It is used whether the response succeeded or not\.

#### Returns
[ICatWorkflowResponse](../Cat.FluentWorkflows.Abstractions/ICatWorkflowResponse.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowResponse')  
The workflow response\.

<a name='Cat.FluentWorkflows.Extensions.CatResponseExtensions.Cast_TSource_(thisCat.Responses.Abstractions.ICatResponse_TSource_,Cat.FluentWorkflows.Abstractions.CatStepExecutionResult)'></a>

## CatResponseExtensions\.Cast\<TSource\>\(this ICatResponse\<TSource\>, CatStepExecutionResult\) Method

Turns a response with a payload into a workflow response\. The payload is dropped and the errors of a failed response come along\.

```csharp
public static Cat.FluentWorkflows.Abstractions.ICatWorkflowResponse Cast<TSource>(this Cat.Responses.Abstractions.ICatResponse<TSource> source, Cat.FluentWorkflows.Abstractions.CatStepExecutionResult workflowResult=Cat.FluentWorkflows.Abstractions.CatStepExecutionResult.Continue);
```
#### Type parameters

<a name='Cat.FluentWorkflows.Extensions.CatResponseExtensions.Cast_TSource_(thisCat.Responses.Abstractions.ICatResponse_TSource_,Cat.FluentWorkflows.Abstractions.CatStepExecutionResult).TSource'></a>

`TSource`

The type of the payload\.
#### Parameters

<a name='Cat.FluentWorkflows.Extensions.CatResponseExtensions.Cast_TSource_(thisCat.Responses.Abstractions.ICatResponse_TSource_,Cat.FluentWorkflows.Abstractions.CatStepExecutionResult).source'></a>

`source` [Cat\.Responses\.Abstractions\.ICatResponse&lt;](../Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[TSource](CatResponseExtensions.md#Cat.FluentWorkflows.Extensions.CatResponseExtensions.Cast_TSource_(thisCat.Responses.Abstractions.ICatResponse_TSource_,Cat.FluentWorkflows.Abstractions.CatStepExecutionResult).TSource 'Cat\.FluentWorkflows\.Extensions\.CatResponseExtensions\.Cast\<TSource\>\(this Cat\.Responses\.Abstractions\.ICatResponse\<TSource\>, Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\)\.TSource')[&gt;](../Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')

The response to convert\.

<a name='Cat.FluentWorkflows.Extensions.CatResponseExtensions.Cast_TSource_(thisCat.Responses.Abstractions.ICatResponse_TSource_,Cat.FluentWorkflows.Abstractions.CatStepExecutionResult).workflowResult'></a>

`workflowResult` [CatStepExecutionResult](../Cat.FluentWorkflows.Abstractions/CatStepExecutionResult.md 'Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult')

The result for the step processor\. It is used whether the response succeeded or not\.

#### Returns
[ICatWorkflowResponse](../Cat.FluentWorkflows.Abstractions/ICatWorkflowResponse.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowResponse')  
The workflow response\.