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
  
##### >> [Cat\.FluentWorkflows Assembly](index.md 'index') >> [Cat\.FluentWorkflows Namespace](Cat.FluentWorkflows.md 'Cat\.FluentWorkflows') >> [CatWorkflowResponse Class](CatWorkflowResponse.md 'Cat\.FluentWorkflows\.CatWorkflowResponse')

## CatWorkflowResponse\.Failed Method

| Overloads | |
| :--- | :--- |
| [Failed\(CatStepExecutionResult, ICatError\[\]\)](CatWorkflowResponse.Failed.md#Cat.FluentWorkflows.CatWorkflowResponse.Failed(Cat.FluentWorkflows.Abstractions.CatStepExecutionResult,Cat.Responses.Abstractions.ICatError[]) 'Cat\.FluentWorkflows\.CatWorkflowResponse\.Failed\(Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult, Cat\.Responses\.Abstractions\.ICatError\[\]\)') | Creates a response for a step that failed\. Use [BreakCascade](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/CatStepExecutionResult.md#Cat.FluentWorkflows.Abstractions.CatStepExecutionResult.BreakCascade 'Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\.BreakCascade') as the result to end the workflow on the failure\. With any other result the workflow goes on, and the errors are still part of the final response\. |
| [Failed\(CatStepExecutionResult, IReadOnlyList&lt;ICatError&gt;\)](CatWorkflowResponse.Failed.md#Cat.FluentWorkflows.CatWorkflowResponse.Failed(Cat.FluentWorkflows.Abstractions.CatStepExecutionResult,System.Collections.Generic.IReadOnlyList_Cat.Responses.Abstractions.ICatError_) 'Cat\.FluentWorkflows\.CatWorkflowResponse\.Failed\(Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult, System\.Collections\.Generic\.IReadOnlyList\<Cat\.Responses\.Abstractions\.ICatError\>\)') | Creates a response for a step that failed\. Use [BreakCascade](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/CatStepExecutionResult.md#Cat.FluentWorkflows.Abstractions.CatStepExecutionResult.BreakCascade 'Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\.BreakCascade') as the result to end the workflow on the failure\. With any other result the workflow goes on, and the errors are still part of the final response\. |

<a name='Cat.FluentWorkflows.CatWorkflowResponse.Failed(Cat.FluentWorkflows.Abstractions.CatStepExecutionResult,Cat.Responses.Abstractions.ICatError[])'></a>

## CatWorkflowResponse\.Failed\(CatStepExecutionResult, ICatError\[\]\) Method

Creates a response for a step that failed\.
Use [BreakCascade](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/CatStepExecutionResult.md#Cat.FluentWorkflows.Abstractions.CatStepExecutionResult.BreakCascade 'Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\.BreakCascade') as the result to end the workflow on the failure\.
With any other result the workflow goes on, and the errors are still part of the final response\.

```csharp
public static Cat.FluentWorkflows.Abstractions.ICatWorkflowResponse Failed(Cat.FluentWorkflows.Abstractions.CatStepExecutionResult workflowResult, params Cat.Responses.Abstractions.ICatError[] errorList);
```
#### Parameters

<a name='Cat.FluentWorkflows.CatWorkflowResponse.Failed(Cat.FluentWorkflows.Abstractions.CatStepExecutionResult,Cat.Responses.Abstractions.ICatError[]).workflowResult'></a>

`workflowResult` [CatStepExecutionResult](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/CatStepExecutionResult.md 'Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult')

What the step processor does next\.

<a name='Cat.FluentWorkflows.CatWorkflowResponse.Failed(Cat.FluentWorkflows.Abstractions.CatStepExecutionResult,Cat.Responses.Abstractions.ICatError[]).errorList'></a>

`errorList` [ICatError](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatError.md 'Cat\.Responses\.Abstractions\.ICatError')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The errors\.

#### Returns
[ICatWorkflowResponse](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowResponse.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowResponse')  
The response, with the errors\.

<a name='Cat.FluentWorkflows.CatWorkflowResponse.Failed(Cat.FluentWorkflows.Abstractions.CatStepExecutionResult,System.Collections.Generic.IReadOnlyList_Cat.Responses.Abstractions.ICatError_)'></a>

## CatWorkflowResponse\.Failed\(CatStepExecutionResult, IReadOnlyList\<ICatError\>\) Method

Creates a response for a step that failed\.
Use [BreakCascade](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/CatStepExecutionResult.md#Cat.FluentWorkflows.Abstractions.CatStepExecutionResult.BreakCascade 'Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\.BreakCascade') as the result to end the workflow on the failure\.
With any other result the workflow goes on, and the errors are still part of the final response\.

```csharp
public static Cat.FluentWorkflows.Abstractions.ICatWorkflowResponse Failed(Cat.FluentWorkflows.Abstractions.CatStepExecutionResult workflowResult, System.Collections.Generic.IReadOnlyList<Cat.Responses.Abstractions.ICatError> errorList);
```
#### Parameters

<a name='Cat.FluentWorkflows.CatWorkflowResponse.Failed(Cat.FluentWorkflows.Abstractions.CatStepExecutionResult,System.Collections.Generic.IReadOnlyList_Cat.Responses.Abstractions.ICatError_).workflowResult'></a>

`workflowResult` [CatStepExecutionResult](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/CatStepExecutionResult.md 'Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult')

What the step processor does next\.

<a name='Cat.FluentWorkflows.CatWorkflowResponse.Failed(Cat.FluentWorkflows.Abstractions.CatStepExecutionResult,System.Collections.Generic.IReadOnlyList_Cat.Responses.Abstractions.ICatError_).errorList'></a>

`errorList` [System\.Collections\.Generic\.IReadOnlyList&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1 'System\.Collections\.Generic\.IReadOnlyList\`1')[ICatError](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatError.md 'Cat\.Responses\.Abstractions\.ICatError')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1 'System\.Collections\.Generic\.IReadOnlyList\`1')

The errors\.

#### Returns
[ICatWorkflowResponse](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowResponse.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowResponse')  
The response, with the errors\.