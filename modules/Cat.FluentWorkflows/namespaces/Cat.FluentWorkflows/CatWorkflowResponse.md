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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.FLUENTWORKFLOWS](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.FluentWorkflows Assembly](index.md 'index') >> [Cat\.FluentWorkflows Namespace](Cat.FluentWorkflows.md 'Cat\.FluentWorkflows')

## CatWorkflowResponse Class

Default [ICatWorkflowResponse](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowResponse.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowResponse')\. Create one with [Succeeded\(CatStepExecutionResult\)](CatWorkflowResponse.Succeeded.6G1DWSINROG6P566C8AAH0K1.md 'Cat\.FluentWorkflows\.CatWorkflowResponse\.Succeeded\(Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\)') or [Failed\(CatStepExecutionResult, ICatError\[\]\)](CatWorkflowResponse.Failed.md#Cat.FluentWorkflows.CatWorkflowResponse.Failed(Cat.FluentWorkflows.Abstractions.CatStepExecutionResult,Cat.Responses.Abstractions.ICatError[]) 'Cat\.FluentWorkflows\.CatWorkflowResponse\.Failed\(Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult, Cat\.Responses\.Abstractions\.ICatError\[\]\)')\.

```csharp
public class CatWorkflowResponse : Cat.FluentWorkflows.Abstractions.ICatWorkflowResponse
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatWorkflowResponse

Implements [ICatWorkflowResponse](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowResponse.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowResponse')

| Constructors | |
| :--- | :--- |
| [CatWorkflowResponse\(CatStepExecutionResult\)](CatWorkflowResponse.CatWorkflowResponse.md#Cat.FluentWorkflows.CatWorkflowResponse.CatWorkflowResponse(Cat.FluentWorkflows.Abstractions.CatStepExecutionResult) 'Cat\.FluentWorkflows\.CatWorkflowResponse\.CatWorkflowResponse\(Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\)') | |
| [CatWorkflowResponse\(CatStepExecutionResult, IReadOnlyList&lt;ICatError&gt;\)](CatWorkflowResponse.CatWorkflowResponse.md#Cat.FluentWorkflows.CatWorkflowResponse.CatWorkflowResponse(Cat.FluentWorkflows.Abstractions.CatStepExecutionResult,System.Collections.Generic.IReadOnlyList_Cat.Responses.Abstractions.ICatError_) 'Cat\.FluentWorkflows\.CatWorkflowResponse\.CatWorkflowResponse\(Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult, System\.Collections\.Generic\.IReadOnlyList\<Cat\.Responses\.Abstractions\.ICatError\>\)') | |

| Properties | |
| :--- | :--- |
| [ErrorList](CatWorkflowResponse.ErrorList.md 'Cat\.FluentWorkflows\.CatWorkflowResponse\.ErrorList') | The errors\. The list is empty when nothing failed\. |
| [WorkflowResult](CatWorkflowResponse.WorkflowResult.md 'Cat\.FluentWorkflows\.CatWorkflowResponse\.WorkflowResult') | What the step processor does next\. |

| Methods | |
| :--- | :--- |
| [ChangeWorkflowResult\(CatStepExecutionResult\)](CatWorkflowResponse.ChangeWorkflowResult.SLTTAVSE97M2BDZ8V5RTXSHRE.md 'Cat\.FluentWorkflows\.CatWorkflowResponse\.ChangeWorkflowResult\(Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\)') | Changes the result and keeps the errors\. |
| [Failed\(CatStepExecutionResult, ICatError\[\]\)](CatWorkflowResponse.Failed.md#Cat.FluentWorkflows.CatWorkflowResponse.Failed(Cat.FluentWorkflows.Abstractions.CatStepExecutionResult,Cat.Responses.Abstractions.ICatError[]) 'Cat\.FluentWorkflows\.CatWorkflowResponse\.Failed\(Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult, Cat\.Responses\.Abstractions\.ICatError\[\]\)') | Creates a response for a step that failed\. Use [BreakCascade](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/CatStepExecutionResult.md#Cat.FluentWorkflows.Abstractions.CatStepExecutionResult.BreakCascade 'Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\.BreakCascade') as the result to end the workflow on the failure\. With any other result the workflow goes on, and the errors are still part of the final response\. |
| [Failed\(CatStepExecutionResult, IReadOnlyList&lt;ICatError&gt;\)](CatWorkflowResponse.Failed.md#Cat.FluentWorkflows.CatWorkflowResponse.Failed(Cat.FluentWorkflows.Abstractions.CatStepExecutionResult,System.Collections.Generic.IReadOnlyList_Cat.Responses.Abstractions.ICatError_) 'Cat\.FluentWorkflows\.CatWorkflowResponse\.Failed\(Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult, System\.Collections\.Generic\.IReadOnlyList\<Cat\.Responses\.Abstractions\.ICatError\>\)') | Creates a response for a step that failed\. Use [BreakCascade](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/CatStepExecutionResult.md#Cat.FluentWorkflows.Abstractions.CatStepExecutionResult.BreakCascade 'Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\.BreakCascade') as the result to end the workflow on the failure\. With any other result the workflow goes on, and the errors are still part of the final response\. |
| [Succeeded\(CatStepExecutionResult\)](CatWorkflowResponse.Succeeded.6G1DWSINROG6P566C8AAH0K1.md 'Cat\.FluentWorkflows\.CatWorkflowResponse\.Succeeded\(Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\)') | Creates a response for a step that worked\. |
| [WithErrors\(ICatWorkflowResponse, List&lt;ICatError&gt;\)](CatWorkflowResponse.WithErrors.W0QND61FGE6VG26Y26FGZBUIA.md 'Cat\.FluentWorkflows\.CatWorkflowResponse\.WithErrors\(Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowResponse, System\.Collections\.Generic\.List\<Cat\.Responses\.Abstractions\.ICatError\>\)') | Gives a response all the errors that were collected on the way\. |
