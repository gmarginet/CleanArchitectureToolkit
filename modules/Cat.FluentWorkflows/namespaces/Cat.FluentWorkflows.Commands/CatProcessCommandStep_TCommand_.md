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
  
##### >> [Cat\.FluentWorkflows\.Commands Assembly](index.md 'index') >> [Cat\.FluentWorkflows\.Commands\.Steps Namespace](Cat.FluentWorkflows.Commands.Steps.md 'Cat\.FluentWorkflows\.Commands\.Steps')

## CatProcessCommandStep\<TCommand\> Class

Built\-in step behind `ProcessCommand`\. It processes a command with the command processor\.
A succeeded command continues the workflow\. A failed command ends it with BreakCascade and the errors\.

```csharp
public class CatProcessCommandStep<TCommand> : Cat.FluentWorkflows.CatStepBodyAsync
    where TCommand : class, Cat.Commands.Abstractions.ICatCommand
```
#### Type parameters

<a name='Cat.FluentWorkflows.Commands.Steps.CatProcessCommandStep_TCommand_.TCommand'></a>

`TCommand`

The command to process\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [CatStepBodyAsync](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows/CatStepBodyAsync.md 'Cat\.FluentWorkflows\.CatStepBodyAsync') → CatProcessCommandStep\<TCommand\>

| Constructors | |
| :--- | :--- |
| [CatProcessCommandStep\(ICatCommandProcessor, ILogger&lt;CatProcessCommandStep&lt;TCommand&gt;&gt;\)](CatProcessCommandStep_TCommand_..ctor.6Q3ONWDV49CNNOFIGX4QLYCQ1.md 'Cat\.FluentWorkflows\.Commands\.Steps\.CatProcessCommandStep\<TCommand\>\.CatProcessCommandStep\(Cat\.Commands\.Abstractions\.ICatCommandProcessor, Microsoft\.Extensions\.Logging\.ILogger\<Cat\.FluentWorkflows\.Commands\.Steps\.CatProcessCommandStep\<TCommand\>\>\)') | Creates the step and the command, using the parameterless constructor of the command\. |

| Fields | |
| :--- | :--- |
| [\_commandProcessor](CatProcessCommandStep_TCommand_._commandProcessor.md 'Cat\.FluentWorkflows\.Commands\.Steps\.CatProcessCommandStep\<TCommand\>\.\_commandProcessor') | |

| Properties | |
| :--- | :--- |
| [Command](CatProcessCommandStep_TCommand_.Command.md 'Cat\.FluentWorkflows\.Commands\.Steps\.CatProcessCommandStep\<TCommand\>\.Command') | The command to process\. Fill its members with `Input`\. |
| [Response](CatProcessCommandStep_TCommand_.Response.md 'Cat\.FluentWorkflows\.Commands\.Steps\.CatProcessCommandStep\<TCommand\>\.Response') | The response of the command\. Read it with `Output` after the step ran\. |

| Methods | |
| :--- | :--- |
| [RunAsync\(CancellationToken\)](CatProcessCommandStep_TCommand_.RunAsync.S01NTQHBKUJ7O8U3USSOSA8K.md 'Cat\.FluentWorkflows\.Commands\.Steps\.CatProcessCommandStep\<TCommand\>\.RunAsync\(System\.Threading\.CancellationToken\)') | Runs the step\. |
