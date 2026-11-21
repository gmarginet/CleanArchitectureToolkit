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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.RESILIENCE](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Resilience\.Commands Assembly](index.md 'index') >> [Cat\.Resilience\.Commands Namespace](Cat.Resilience.Commands.md 'Cat\.Resilience\.Commands')

## CatRetryCommandProcessor Class

Wraps the command processor\. A listed command type runs inside the pipeline of its profile, and every try calls the inner processor again,
which opens a new scope\. Every other type passes straight through\.
A failed response that the rule counts becomes an exception inside the pipeline, so the profile retries it and counts it for its circuit breaker\.
After the last retry the response of the last try comes back\. When the pipeline itself says no, for example because its circuit is open
or a try timed out, its exception comes through\.

```csharp
internal sealed class CatRetryCommandProcessor : Cat.Commands.Abstractions.ICatCommandProcessor
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatRetryCommandProcessor

Implements [ICatCommandProcessor](../../../Cat.Commands/namespaces/Cat.Commands.Abstractions/ICatCommandProcessor.md 'Cat\.Commands\.Abstractions\.ICatCommandProcessor')

| Constructors | |
| :--- | :--- |
| [CatRetryCommandProcessor\(ICatCommandProcessor, ICatResiliencePipelines, CatCommandRetryOptions\)](CatRetryCommandProcessor..ctor.E3BPF6V69ZGXL7QKN7DGWO4S9.md 'Cat\.Resilience\.Commands\.CatRetryCommandProcessor\.CatRetryCommandProcessor\(Cat\.Commands\.Abstractions\.ICatCommandProcessor, Cat\.Resilience\.Abstractions\.ICatResiliencePipelines, Cat\.Resilience\.Commands\.CatCommandRetryOptions\)') | Wraps the command processor\. A listed command type runs inside the pipeline of its profile, and every try calls the inner processor again, which opens a new scope\. Every other type passes straight through\. A failed response that the rule counts becomes an exception inside the pipeline, so the profile retries it and counts it for its circuit breaker\. After the last retry the response of the last try comes back\. When the pipeline itself says no, for example because its circuit is open or a try timed out, its exception comes through\. |

| Methods | |
| :--- | :--- |
| [Process\(ICatCommand\)](CatRetryCommandProcessor.Process.md#Cat.Resilience.Commands.CatRetryCommandProcessor.Process(Cat.Commands.Abstractions.ICatCommand) 'Cat\.Resilience\.Commands\.CatRetryCommandProcessor\.Process\(Cat\.Commands\.Abstractions\.ICatCommand\)') | Runs a command and blocks until it finishes\. Prefer [ProcessAsync\(ICatCommand, CancellationToken\)](../../../Cat.Commands/namespaces/Cat.Commands.Abstractions/ICatCommandProcessor.ProcessAsync.md#Cat.Commands.Abstractions.ICatCommandProcessor.ProcessAsync(Cat.Commands.Abstractions.ICatCommand,System.Threading.CancellationToken) 'Cat\.Commands\.Abstractions\.ICatCommandProcessor\.ProcessAsync\(Cat\.Commands\.Abstractions\.ICatCommand,System\.Threading\.CancellationToken\)') when you can\. |
| [Process&lt;TResult&gt;\(ICatCommand&lt;TResult&gt;\)](CatRetryCommandProcessor.Process.md#Cat.Resilience.Commands.CatRetryCommandProcessor.Process_TResult_(Cat.Commands.Abstractions.ICatCommand_TResult_) 'Cat\.Resilience\.Commands\.CatRetryCommandProcessor\.Process\<TResult\>\(Cat\.Commands\.Abstractions\.ICatCommand\<TResult\>\)') | Runs a command that returns a result and blocks until it finishes\. Prefer [ProcessAsync&lt;TResult&gt;\(ICatCommand&lt;TResult&gt;, CancellationToken\)](../../../Cat.Commands/namespaces/Cat.Commands.Abstractions/ICatCommandProcessor.ProcessAsync.md#Cat.Commands.Abstractions.ICatCommandProcessor.ProcessAsync_TResult_(Cat.Commands.Abstractions.ICatCommand_TResult_,System.Threading.CancellationToken) 'Cat\.Commands\.Abstractions\.ICatCommandProcessor\.ProcessAsync\`\`1\(Cat\.Commands\.Abstractions\.ICatCommand\{\`\`0\},System\.Threading\.CancellationToken\)') when you can\. |
| [ProcessAsync\(ICatCommand, CancellationToken\)](CatRetryCommandProcessor.ProcessAsync.md#Cat.Resilience.Commands.CatRetryCommandProcessor.ProcessAsync(Cat.Commands.Abstractions.ICatCommand,System.Threading.CancellationToken) 'Cat\.Resilience\.Commands\.CatRetryCommandProcessor\.ProcessAsync\(Cat\.Commands\.Abstractions\.ICatCommand, System\.Threading\.CancellationToken\)') | Runs a command\. |
| [ProcessAsync&lt;TResult&gt;\(ICatCommand&lt;TResult&gt;, CancellationToken\)](CatRetryCommandProcessor.ProcessAsync.md#Cat.Resilience.Commands.CatRetryCommandProcessor.ProcessAsync_TResult_(Cat.Commands.Abstractions.ICatCommand_TResult_,System.Threading.CancellationToken) 'Cat\.Resilience\.Commands\.CatRetryCommandProcessor\.ProcessAsync\<TResult\>\(Cat\.Commands\.Abstractions\.ICatCommand\<TResult\>, System\.Threading\.CancellationToken\)') | Runs a command that returns a result\. |
| [RunAsync&lt;TResponse&gt;\(CatRetryRule, Func&lt;CancellationToken,Task&lt;TResponse&gt;&gt;, CancellationToken\)](CatRetryCommandProcessor.RunAsync.CQL9PKK0H5IW462N1PHT6LQMD.md 'Cat\.Resilience\.Commands\.CatRetryCommandProcessor\.RunAsync\<TResponse\>\(Cat\.Resilience\.Commands\.CatRetryRule, System\.Func\<System\.Threading\.CancellationToken,System\.Threading\.Tasks\.Task\<TResponse\>\>, System\.Threading\.CancellationToken\)') | |
