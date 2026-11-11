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
  
##### >> [Cat\.FluentWorkflows\.Commands Assembly](index.md 'index') >> [Cat\.FluentWorkflows\.Commands\.Steps Namespace](Cat.FluentWorkflows.Commands.Steps.md 'Cat\.FluentWorkflows\.Commands\.Steps') >> [CatProcessCommandStep&lt;TCommand,TResult&gt; Class](CatProcessCommandStep_TCommand,TResult_.md 'Cat\.FluentWorkflows\.Commands\.Steps\.CatProcessCommandStep\<TCommand,TResult\>')

## CatProcessCommandStep\(ICatCommandProcessor, ILogger\<CatProcessCommandStep\<TCommand,TResult\>\>\) Constructor

Creates the step and the command, using the parameterless constructor of the command\.

```csharp
public CatProcessCommandStep(Cat.Commands.Abstractions.ICatCommandProcessor commandProcessor, Microsoft.Extensions.Logging.ILogger<Cat.FluentWorkflows.Commands.Steps.CatProcessCommandStep<TCommand,TResult>> logger);
```
#### Parameters

<a name='Cat.FluentWorkflows.Commands.Steps.CatProcessCommandStep_TCommand,TResult_.CatProcessCommandStep(Cat.Commands.Abstractions.ICatCommandProcessor,Microsoft.Extensions.Logging.ILogger_Cat.FluentWorkflows.Commands.Steps.CatProcessCommandStep_TCommand,TResult__).commandProcessor'></a>

`commandProcessor` [ICatCommandProcessor](../../../Cat.Commands/namespaces/Cat.Commands.Abstractions/ICatCommandProcessor.md 'Cat\.Commands\.Abstractions\.ICatCommandProcessor')

Processes the command\.

<a name='Cat.FluentWorkflows.Commands.Steps.CatProcessCommandStep_TCommand,TResult_.CatProcessCommandStep(Cat.Commands.Abstractions.ICatCommandProcessor,Microsoft.Extensions.Logging.ILogger_Cat.FluentWorkflows.Commands.Steps.CatProcessCommandStep_TCommand,TResult__).logger'></a>

`logger` [Microsoft\.Extensions\.Logging\.ILogger&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')[Cat\.FluentWorkflows\.Commands\.Steps\.CatProcessCommandStep&lt;](CatProcessCommandStep_TCommand,TResult_.md 'Cat\.FluentWorkflows\.Commands\.Steps\.CatProcessCommandStep\<TCommand,TResult\>')[TCommand](CatProcessCommandStep_TCommand,TResult_.md#Cat.FluentWorkflows.Commands.Steps.CatProcessCommandStep_TCommand,TResult_.TCommand 'Cat\.FluentWorkflows\.Commands\.Steps\.CatProcessCommandStep\<TCommand,TResult\>\.TCommand')[,](CatProcessCommandStep_TCommand,TResult_.md 'Cat\.FluentWorkflows\.Commands\.Steps\.CatProcessCommandStep\<TCommand,TResult\>')[TResult](CatProcessCommandStep_TCommand,TResult_.md#Cat.FluentWorkflows.Commands.Steps.CatProcessCommandStep_TCommand,TResult_.TResult 'Cat\.FluentWorkflows\.Commands\.Steps\.CatProcessCommandStep\<TCommand,TResult\>\.TResult')[&gt;](CatProcessCommandStep_TCommand,TResult_.md 'Cat\.FluentWorkflows\.Commands\.Steps\.CatProcessCommandStep\<TCommand,TResult\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')

The logger the step can use\.