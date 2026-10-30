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
  
##### >> [Cat\.FluentWorkflows Assembly](index.md 'index') >> [Cat\.FluentWorkflows Namespace](Cat.FluentWorkflows.md 'Cat\.FluentWorkflows')

## CatStepBodyAsync Class

Base class for a step that works asynchronously and doesn't need the workflow state directly\.
Get its data through `Input` and hand results back through `Output`\. Implement [RunAsync\(CancellationToken\)](CatStepBodyAsync.RunAsync.NDIRNNFATTDGG9GCGGAU4GQP1.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\.RunAsync\(System\.Threading\.CancellationToken\)')\.

```csharp
public abstract class CatStepBodyAsync : Cat.FluentWorkflows.Abstractions.ICatStepBodyAsync
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatStepBodyAsync

Derived  
↳ [CatStepBody](CatStepBody.md 'Cat\.FluentWorkflows\.CatStepBody')  
↳ [CatStepBodyAsync&lt;TWorkflowState&gt;](CatStepBodyAsync_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\<TWorkflowState\>')

Implements [ICatStepBodyAsync](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatStepBodyAsync.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBodyAsync')

| Constructors | |
| :--- | :--- |
| [CatStepBodyAsync\(ILogger\)](CatStepBodyAsync..ctor.Q9L49J6VOF258D2X8RO30MX3D.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\.CatStepBodyAsync\(Microsoft\.Extensions\.Logging\.ILogger\)') | Creates the step\. |

| Fields | |
| :--- | :--- |
| [Logger](CatStepBodyAsync.Logger.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\.Logger') | The logger of the step\. |

| Methods | |
| :--- | :--- |
| [RunAsync\(CancellationToken\)](CatStepBodyAsync.RunAsync.NDIRNNFATTDGG9GCGGAU4GQP1.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\.RunAsync\(System\.Threading\.CancellationToken\)') | Runs the step\. |
