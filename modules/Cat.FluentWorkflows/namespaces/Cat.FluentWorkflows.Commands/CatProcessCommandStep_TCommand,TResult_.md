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
  
##### >> [Cat\.FluentWorkflows\.Commands Assembly](index.md 'index') >> [Cat\.FluentWorkflows\.Commands\.Steps Namespace](Cat.FluentWorkflows.Commands.Steps.md 'Cat\.FluentWorkflows\.Commands\.Steps')

## CatProcessCommandStep\<TCommand,TResult\> Class

Built\-in step behind `ProcessCommand` for a command that returns a result\. It processes the command with the command processor\.
A succeeded command continues the workflow\. A failed command ends it with BreakCascade and the errors\.

```csharp
public class CatProcessCommandStep<TCommand,TResult> : Cat.FluentWorkflows.CatStepBodyAsync
    where TCommand : class, Cat.Commands.Abstractions.ICatCommand<TResult>
```
#### Type parameters

<a name='Cat.FluentWorkflows.Commands.Steps.CatProcessCommandStep_TCommand,TResult_.TCommand'></a>

`TCommand`

The command to process\.

<a name='Cat.FluentWorkflows.Commands.Steps.CatProcessCommandStep_TCommand,TResult_.TResult'></a>

`TResult`

The type of the data the command returns\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [CatStepBodyAsync](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows/CatStepBodyAsync.md 'Cat\.FluentWorkflows\.CatStepBodyAsync') → CatProcessCommandStep\<TCommand,TResult\>

| Constructors | |
| :--- | :--- |
| [CatProcessCommandStep\(ICatCommandProcessor, ILogger&lt;CatProcessCommandStep&lt;TCommand,TResult&gt;&gt;\)](CatProcessCommandStep_TCommand,TResult_..ctor.Z8MW66ZONQFNYLQDSC3AP89CC.md 'Cat\.FluentWorkflows\.Commands\.Steps\.CatProcessCommandStep\<TCommand,TResult\>\.CatProcessCommandStep\(Cat\.Commands\.Abstractions\.ICatCommandProcessor, Microsoft\.Extensions\.Logging\.ILogger\<Cat\.FluentWorkflows\.Commands\.Steps\.CatProcessCommandStep\<TCommand,TResult\>\>\)') | Creates the step and the command, using the parameterless constructor of the command\. |

| Fields | |
| :--- | :--- |
| [\_commandProcessor](CatProcessCommandStep_TCommand,TResult_._commandProcessor.md 'Cat\.FluentWorkflows\.Commands\.Steps\.CatProcessCommandStep\<TCommand,TResult\>\.\_commandProcessor') | |

| Properties | |
| :--- | :--- |
| [Command](CatProcessCommandStep_TCommand,TResult_.Command.md 'Cat\.FluentWorkflows\.Commands\.Steps\.CatProcessCommandStep\<TCommand,TResult\>\.Command') | The command to process\. Fill its members with `Input`\. |
| [Response](CatProcessCommandStep_TCommand,TResult_.Response.md 'Cat\.FluentWorkflows\.Commands\.Steps\.CatProcessCommandStep\<TCommand,TResult\>\.Response') | The response of the command, with the result when it succeeded\. Read it with `Output` after the step ran\. |

| Methods | |
| :--- | :--- |
| [RunAsync\(CancellationToken\)](CatProcessCommandStep_TCommand,TResult_.RunAsync.MY9DI5MI0KTXLEC4VIRP0IPQB.md 'Cat\.FluentWorkflows\.Commands\.Steps\.CatProcessCommandStep\<TCommand,TResult\>\.RunAsync\(System\.Threading\.CancellationToken\)') | Runs the step\. |
