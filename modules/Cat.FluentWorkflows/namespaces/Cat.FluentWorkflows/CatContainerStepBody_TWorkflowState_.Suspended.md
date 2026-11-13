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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.FLUENTWORKFLOWS](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.FluentWorkflows Assembly](index.md 'index') >> [Cat\.FluentWorkflows Namespace](Cat.FluentWorkflows.md 'Cat\.FluentWorkflows') >> [CatContainerStepBody&lt;TWorkflowState&gt; Class](CatContainerStepBody_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatContainerStepBody\<TWorkflowState\>')

## CatContainerStepBody\<TWorkflowState\>\.Suspended Method

| Overloads | |
| :--- | :--- |
| [Suspended\(ICatWorkflowResponse, Action&lt;CatCheckpointFrame&gt;\)](CatContainerStepBody_TWorkflowState_.Suspended.md#Cat.FluentWorkflows.CatContainerStepBody_TWorkflowState_.Suspended(Cat.FluentWorkflows.Abstractions.ICatWorkflowResponse,System.Action_Cat.FluentWorkflows.Abstractions.CatCheckpointFrame_) 'Cat\.FluentWorkflows\.CatContainerStepBody\<TWorkflowState\>\.Suspended\(Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowResponse, System\.Action\<Cat\.FluentWorkflows\.Abstractions\.CatCheckpointFrame\>\)') | Creates the response of a container whose inner steps suspended\. It keeps the errors of the inner steps\. |
| [Suspended\(ICatWorkflowResponse, IReadOnlyList&lt;ICatError&gt;, Action&lt;CatCheckpointFrame&gt;\)](CatContainerStepBody_TWorkflowState_.Suspended.md#Cat.FluentWorkflows.CatContainerStepBody_TWorkflowState_.Suspended(Cat.FluentWorkflows.Abstractions.ICatWorkflowResponse,System.Collections.Generic.IReadOnlyList_Cat.Responses.Abstractions.ICatError_,System.Action_Cat.FluentWorkflows.Abstractions.CatCheckpointFrame_) 'Cat\.FluentWorkflows\.CatContainerStepBody\<TWorkflowState\>\.Suspended\(Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowResponse, System\.Collections\.Generic\.IReadOnlyList\<Cat\.Responses\.Abstractions\.ICatError\>, System\.Action\<Cat\.FluentWorkflows\.Abstractions\.CatCheckpointFrame\>\)') | Creates the response of a container whose inner steps suspended, with the errors collected over several passes\. |

<a name='Cat.FluentWorkflows.CatContainerStepBody_TWorkflowState_.Suspended(Cat.FluentWorkflows.Abstractions.ICatWorkflowResponse,System.Action_Cat.FluentWorkflows.Abstractions.CatCheckpointFrame_)'></a>

## CatContainerStepBody\<TWorkflowState\>\.Suspended\(ICatWorkflowResponse, Action\<CatCheckpointFrame\>\) Method

Creates the response of a container whose inner steps suspended\. It keeps the errors of the inner steps\.

```csharp
protected static Cat.FluentWorkflows.Abstractions.ICatWorkflowResponse Suspended(Cat.FluentWorkflows.Abstractions.ICatWorkflowResponse child, System.Action<Cat.FluentWorkflows.Abstractions.CatCheckpointFrame>? describe=null);
```
#### Parameters

<a name='Cat.FluentWorkflows.CatContainerStepBody_TWorkflowState_.Suspended(Cat.FluentWorkflows.Abstractions.ICatWorkflowResponse,System.Action_Cat.FluentWorkflows.Abstractions.CatCheckpointFrame_).child'></a>

`child` [ICatWorkflowResponse](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowResponse.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowResponse')

The response of the inner steps\. Its checkpoint becomes the child frame\.

<a name='Cat.FluentWorkflows.CatContainerStepBody_TWorkflowState_.Suspended(Cat.FluentWorkflows.Abstractions.ICatWorkflowResponse,System.Action_Cat.FluentWorkflows.Abstractions.CatCheckpointFrame_).describe'></a>

`describe` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[CatCheckpointFrame](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/CatCheckpointFrame.md 'Cat\.FluentWorkflows\.Abstractions\.CatCheckpointFrame')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

Writes what the container needs to find its place again, such as the branch\.

#### Returns
[ICatWorkflowResponse](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowResponse.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowResponse')  
A response with the result [Suspend](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/CatStepExecutionResult.md#Cat.FluentWorkflows.Abstractions.CatStepExecutionResult.Suspend 'Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\.Suspend')\.

<a name='Cat.FluentWorkflows.CatContainerStepBody_TWorkflowState_.Suspended(Cat.FluentWorkflows.Abstractions.ICatWorkflowResponse,System.Collections.Generic.IReadOnlyList_Cat.Responses.Abstractions.ICatError_,System.Action_Cat.FluentWorkflows.Abstractions.CatCheckpointFrame_)'></a>

## CatContainerStepBody\<TWorkflowState\>\.Suspended\(ICatWorkflowResponse, IReadOnlyList\<ICatError\>, Action\<CatCheckpointFrame\>\) Method

Creates the response of a container whose inner steps suspended, with the errors collected over several passes\.

```csharp
protected static Cat.FluentWorkflows.Abstractions.ICatWorkflowResponse Suspended(Cat.FluentWorkflows.Abstractions.ICatWorkflowResponse child, System.Collections.Generic.IReadOnlyList<Cat.Responses.Abstractions.ICatError> errors, System.Action<Cat.FluentWorkflows.Abstractions.CatCheckpointFrame>? describe=null);
```
#### Parameters

<a name='Cat.FluentWorkflows.CatContainerStepBody_TWorkflowState_.Suspended(Cat.FluentWorkflows.Abstractions.ICatWorkflowResponse,System.Collections.Generic.IReadOnlyList_Cat.Responses.Abstractions.ICatError_,System.Action_Cat.FluentWorkflows.Abstractions.CatCheckpointFrame_).child'></a>

`child` [ICatWorkflowResponse](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowResponse.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowResponse')

The response of the inner steps\. Its checkpoint becomes the child frame\.

<a name='Cat.FluentWorkflows.CatContainerStepBody_TWorkflowState_.Suspended(Cat.FluentWorkflows.Abstractions.ICatWorkflowResponse,System.Collections.Generic.IReadOnlyList_Cat.Responses.Abstractions.ICatError_,System.Action_Cat.FluentWorkflows.Abstractions.CatCheckpointFrame_).errors'></a>

`errors` [System\.Collections\.Generic\.IReadOnlyList&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1 'System\.Collections\.Generic\.IReadOnlyList\`1')[ICatError](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatError.md 'Cat\.Responses\.Abstractions\.ICatError')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1 'System\.Collections\.Generic\.IReadOnlyList\`1')

All the errors collected so far\.

<a name='Cat.FluentWorkflows.CatContainerStepBody_TWorkflowState_.Suspended(Cat.FluentWorkflows.Abstractions.ICatWorkflowResponse,System.Collections.Generic.IReadOnlyList_Cat.Responses.Abstractions.ICatError_,System.Action_Cat.FluentWorkflows.Abstractions.CatCheckpointFrame_).describe'></a>

`describe` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[CatCheckpointFrame](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/CatCheckpointFrame.md 'Cat\.FluentWorkflows\.Abstractions\.CatCheckpointFrame')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

Writes what the container needs to find its place again, such as the branch\.

#### Returns
[ICatWorkflowResponse](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowResponse.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowResponse')  
A response with the result [Suspend](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/CatStepExecutionResult.md#Cat.FluentWorkflows.Abstractions.CatStepExecutionResult.Suspend 'Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\.Suspend')\.