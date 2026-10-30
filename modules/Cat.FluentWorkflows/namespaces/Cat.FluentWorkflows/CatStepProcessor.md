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

## CatStepProcessor Class

Default [ICatStepProcessor](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatStepProcessor.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepProcessor')\.
For each step it gets the step body from the service provider, fills the inputs, runs the step and copies the outputs\.
It stops after a step that returns BreakCascade, BreakFromCurrentFlowOnly or BreakFromLoop\.
The result is the one of the last step that ran\. The errors of every step that ran are kept\.

```csharp
public class CatStepProcessor : Cat.FluentWorkflows.Abstractions.ICatStepProcessor
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatStepProcessor

Implements [ICatStepProcessor](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatStepProcessor.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepProcessor')

| Constructors | |
| :--- | :--- |
| [CatStepProcessor\(IServiceProvider, ILogger&lt;CatStepProcessor&gt;\)](CatStepProcessor..ctor.8E1HBRYL2U3SPN9WU6ATH8RC6.md 'Cat\.FluentWorkflows\.CatStepProcessor\.CatStepProcessor\(System\.IServiceProvider, Microsoft\.Extensions\.Logging\.ILogger\<Cat\.FluentWorkflows\.CatStepProcessor\>\)') | Creates the processor\. |

| Fields | |
| :--- | :--- |
| [\_logger](CatStepProcessor._logger.md 'Cat\.FluentWorkflows\.CatStepProcessor\.\_logger') | |
| [\_serviceProvider](CatStepProcessor._serviceProvider.md 'Cat\.FluentWorkflows\.CatStepProcessor\.\_serviceProvider') | |

| Methods | |
| :--- | :--- |
| [RunStepsAsync&lt;TWorkflowState&gt;\(ICatWorkflowBuilder&lt;TWorkflowState&gt;, TWorkflowState, CancellationToken\)](CatStepProcessor.RunStepsAsync.X9T5P5646TC85HDMBJ8KD0KQ2.md 'Cat\.FluentWorkflows\.CatStepProcessor\.RunStepsAsync\<TWorkflowState\>\(Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, TWorkflowState, System\.Threading\.CancellationToken\)') | Runs the steps of a builder in order\. It stops after a step that returns a break result\. |
