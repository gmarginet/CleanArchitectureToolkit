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
  
##### >> [Cat\.FluentWorkflows Assembly](index.md 'index') >> [Cat\.FluentWorkflows\.Steps Namespace](Cat.FluentWorkflows.Steps.md 'Cat\.FluentWorkflows\.Steps') >> [CatParallelStep&lt;TWorkflowState&gt; Class](CatParallelStep_TWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatParallelStep\<TWorkflowState\>')

## CatParallelStep\<TWorkflowState\>\.Suspended\(List\<CatParallelBranchFrame\>, List\<ICatError\>\) Method

```csharp
private static Cat.FluentWorkflows.Abstractions.ICatWorkflowResponse Suspended(System.Collections.Generic.List<Cat.FluentWorkflows.Abstractions.CatParallelBranchFrame> branchFrames, System.Collections.Generic.List<Cat.Responses.Abstractions.ICatError> errors);
```
#### Parameters

<a name='Cat.FluentWorkflows.Steps.CatParallelStep_TWorkflowState_.Suspended(System.Collections.Generic.List_Cat.FluentWorkflows.Abstractions.CatParallelBranchFrame_,System.Collections.Generic.List_Cat.Responses.Abstractions.ICatError_).branchFrames'></a>

`branchFrames` [System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[CatParallelBranchFrame](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/CatParallelBranchFrame.md 'Cat\.FluentWorkflows\.Abstractions\.CatParallelBranchFrame')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='Cat.FluentWorkflows.Steps.CatParallelStep_TWorkflowState_.Suspended(System.Collections.Generic.List_Cat.FluentWorkflows.Abstractions.CatParallelBranchFrame_,System.Collections.Generic.List_Cat.Responses.Abstractions.ICatError_).errors'></a>

`errors` [System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[ICatError](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatError.md 'Cat\.Responses\.Abstractions\.ICatError')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

#### Returns
[ICatWorkflowResponse](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowResponse.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowResponse')