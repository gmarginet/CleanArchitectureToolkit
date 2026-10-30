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
  
##### >> [Cat\.FluentWorkflows Assembly](index.md 'index') >> [Cat\.FluentWorkflows\.Extensions Namespace](Cat.FluentWorkflows.Extensions.md 'Cat\.FluentWorkflows\.Extensions') >> [CatResponseExtensions Class](CatResponseExtensions.md 'Cat\.FluentWorkflows\.Extensions\.CatResponseExtensions')

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

`source` [ICatResponse](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse')

The response to convert\.

<a name='Cat.FluentWorkflows.Extensions.CatResponseExtensions.Cast(thisCat.Responses.Abstractions.ICatResponse,Cat.FluentWorkflows.Abstractions.CatStepExecutionResult).workflowResult'></a>

`workflowResult` [CatStepExecutionResult](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/CatStepExecutionResult.md 'Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult')

The result for the step processor\. It is used whether the response succeeded or not\.

#### Returns
[ICatWorkflowResponse](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowResponse.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowResponse')  
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

`source` [Cat\.Responses\.Abstractions\.ICatResponse&lt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[TSource](CatResponseExtensions.Cast.md#Cat.FluentWorkflows.Extensions.CatResponseExtensions.Cast_TSource_(thisCat.Responses.Abstractions.ICatResponse_TSource_,Cat.FluentWorkflows.Abstractions.CatStepExecutionResult).TSource 'Cat\.FluentWorkflows\.Extensions\.CatResponseExtensions\.Cast\<TSource\>\(this Cat\.Responses\.Abstractions\.ICatResponse\<TSource\>, Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\)\.TSource')[&gt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')

The response to convert\.

<a name='Cat.FluentWorkflows.Extensions.CatResponseExtensions.Cast_TSource_(thisCat.Responses.Abstractions.ICatResponse_TSource_,Cat.FluentWorkflows.Abstractions.CatStepExecutionResult).workflowResult'></a>

`workflowResult` [CatStepExecutionResult](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/CatStepExecutionResult.md 'Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult')

The result for the step processor\. It is used whether the response succeeded or not\.

#### Returns
[ICatWorkflowResponse](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowResponse.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowResponse')  
The workflow response\.