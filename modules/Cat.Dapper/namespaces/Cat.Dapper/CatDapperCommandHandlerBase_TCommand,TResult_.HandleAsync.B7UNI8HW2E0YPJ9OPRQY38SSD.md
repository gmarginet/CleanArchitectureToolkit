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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.DAPPER](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Dapper Assembly](index.md 'index') >> [Cat\.Dapper Namespace](Cat.Dapper.md 'Cat\.Dapper') >> [CatDapperCommandHandlerBase&lt;TCommand,TResult&gt; Class](CatDapperCommandHandlerBase_TCommand,TResult_.md 'Cat\.Dapper\.CatDapperCommandHandlerBase\<TCommand,TResult\>')

## CatDapperCommandHandlerBase\<TCommand,TResult\>\.HandleAsync\(TCommand, CancellationToken\) Method

Runs the command\.

```csharp
public abstract System.Threading.Tasks.Task<Cat.Responses.Abstractions.ICatResponse<TResult>> HandleAsync(TCommand command, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Cat.Dapper.CatDapperCommandHandlerBase_TCommand,TResult_.HandleAsync(TCommand,System.Threading.CancellationToken).command'></a>

`command` [TCommand](CatDapperCommandHandlerBase_TCommand,TResult_.md#Cat.Dapper.CatDapperCommandHandlerBase_TCommand,TResult_.TCommand 'Cat\.Dapper\.CatDapperCommandHandlerBase\<TCommand,TResult\>\.TCommand')

The command to handle\.

<a name='Cat.Dapper.CatDapperCommandHandlerBase_TCommand,TResult_.HandleAsync(TCommand,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Token to cancel the work\.

Implements [HandleAsync\(TCommand, CancellationToken\)](../../../Cat.Commands/namespaces/Cat.Commands.Abstractions/ICatCommandHandler_TCommand,TResult_.HandleAsync.TPIUUXKGIBWH7YKSVBFAZVUFD.md 'Cat\.Commands\.Abstractions\.ICatCommandHandler\`2\.HandleAsync\(\`0,System\.Threading\.CancellationToken\)')

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Cat\.Responses\.Abstractions\.ICatResponse&lt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[TResult](CatDapperCommandHandlerBase_TCommand,TResult_.md#Cat.Dapper.CatDapperCommandHandlerBase_TCommand,TResult_.TResult 'Cat\.Dapper\.CatDapperCommandHandlerBase\<TCommand,TResult\>\.TResult')[&gt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A response with the result when it succeeded, or the errors when it failed\.