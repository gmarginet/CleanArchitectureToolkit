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

|&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[CAT.COMMANDS](../../README.md)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Commands\.Decorators\.Logging Assembly](index.md 'index') >> [Cat\.Commands\.Decorators\.Logging Namespace](Cat.Commands.Decorators.Logging.md 'Cat\.Commands\.Decorators\.Logging') >> [LoggingDecorator Class](LoggingDecorator.md 'Cat\.Commands\.Decorators\.Logging\.LoggingDecorator') >> [CatCommandHandler&lt;TCommand&gt; Class](LoggingDecorator.CatCommandHandler_TCommand_.md 'Cat\.Commands\.Decorators\.Logging\.LoggingDecorator\.CatCommandHandler\<TCommand\>')

## LoggingDecorator\.CatCommandHandler\<TCommand\>\.HandleAsync\(TCommand, CancellationToken\) Method

Runs the command\.

```csharp
public System.Threading.Tasks.Task<Cat.Responses.Abstractions.ICatResponse> HandleAsync(TCommand command, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Cat.Commands.Decorators.Logging.LoggingDecorator.CatCommandHandler_TCommand_.HandleAsync(TCommand,System.Threading.CancellationToken).command'></a>

`command` [TCommand](LoggingDecorator.CatCommandHandler_TCommand_.md#Cat.Commands.Decorators.Logging.LoggingDecorator.CatCommandHandler_TCommand_.TCommand 'Cat\.Commands\.Decorators\.Logging\.LoggingDecorator\.CatCommandHandler\<TCommand\>\.TCommand')

The command to handle\.

<a name='Cat.Commands.Decorators.Logging.LoggingDecorator.CatCommandHandler_TCommand_.HandleAsync(TCommand,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Token to cancel the work\.

Implements [HandleAsync\(TCommand, CancellationToken\)](../../../Cat.Commands/namespaces/Cat.Commands.Abstractions/ICatCommandHandler_TCommand_.HandleAsync.DOGO4I1C9KLZNF43493MH80JB.md 'Cat\.Commands\.Abstractions\.ICatCommandHandler\`1\.HandleAsync\(\`0,System\.Threading\.CancellationToken\)')

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[ICatResponse](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A response that tells whether the command succeeded, and why not if it failed\.