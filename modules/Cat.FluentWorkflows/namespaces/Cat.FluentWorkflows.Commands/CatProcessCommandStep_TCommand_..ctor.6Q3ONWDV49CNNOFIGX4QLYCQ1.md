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
  
##### >> [Cat\.FluentWorkflows\.Commands Assembly](index.md 'index') >> [Cat\.FluentWorkflows\.Commands\.Steps Namespace](Cat.FluentWorkflows.Commands.Steps.md 'Cat\.FluentWorkflows\.Commands\.Steps') >> [CatProcessCommandStep&lt;TCommand&gt; Class](CatProcessCommandStep_TCommand_.md 'Cat\.FluentWorkflows\.Commands\.Steps\.CatProcessCommandStep\<TCommand\>')

## CatProcessCommandStep\(ICatCommandProcessor, ILogger\<CatProcessCommandStep\<TCommand\>\>\) Constructor

Creates the step and the command, using the parameterless constructor of the command\.

```csharp
public CatProcessCommandStep(Cat.Commands.Abstractions.ICatCommandProcessor commandProcessor, Microsoft.Extensions.Logging.ILogger<Cat.FluentWorkflows.Commands.Steps.CatProcessCommandStep<TCommand>> logger);
```
#### Parameters

<a name='Cat.FluentWorkflows.Commands.Steps.CatProcessCommandStep_TCommand_.CatProcessCommandStep(Cat.Commands.Abstractions.ICatCommandProcessor,Microsoft.Extensions.Logging.ILogger_Cat.FluentWorkflows.Commands.Steps.CatProcessCommandStep_TCommand__).commandProcessor'></a>

`commandProcessor` [ICatCommandProcessor](../../../Cat.Commands/namespaces/Cat.Commands.Abstractions/ICatCommandProcessor.md 'Cat\.Commands\.Abstractions\.ICatCommandProcessor')

Processes the command\.

<a name='Cat.FluentWorkflows.Commands.Steps.CatProcessCommandStep_TCommand_.CatProcessCommandStep(Cat.Commands.Abstractions.ICatCommandProcessor,Microsoft.Extensions.Logging.ILogger_Cat.FluentWorkflows.Commands.Steps.CatProcessCommandStep_TCommand__).logger'></a>

`logger` [Microsoft\.Extensions\.Logging\.ILogger&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')[Cat\.FluentWorkflows\.Commands\.Steps\.CatProcessCommandStep&lt;](CatProcessCommandStep_TCommand_.md 'Cat\.FluentWorkflows\.Commands\.Steps\.CatProcessCommandStep\<TCommand\>')[TCommand](CatProcessCommandStep_TCommand_.md#Cat.FluentWorkflows.Commands.Steps.CatProcessCommandStep_TCommand_.TCommand 'Cat\.FluentWorkflows\.Commands\.Steps\.CatProcessCommandStep\<TCommand\>\.TCommand')[&gt;](CatProcessCommandStep_TCommand_.md 'Cat\.FluentWorkflows\.Commands\.Steps\.CatProcessCommandStep\<TCommand\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')

The logger the step can use\.