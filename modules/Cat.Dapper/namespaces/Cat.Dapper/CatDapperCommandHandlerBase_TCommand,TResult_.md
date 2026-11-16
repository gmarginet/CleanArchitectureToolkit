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
  
##### >> [Cat\.Dapper Assembly](index.md 'index') >> [Cat\.Dapper Namespace](Cat.Dapper.md 'Cat\.Dapper')

## CatDapperCommandHandlerBase\<TCommand,TResult\> Class

Base class for command handlers that change data with plain SQL and Dapper and return a result\.
It only gives the handler its [ICatDbSession](../../../Cat.Dapper/namespaces/Cat.Dapper.Abstractions/ICatDbSession.md 'Cat\.Dapper\.Abstractions\.ICatDbSession')\. The handler decides when to start a transaction and when to commit it\.

```csharp
public abstract class CatDapperCommandHandlerBase<TCommand,TResult> : Cat.Commands.Abstractions.ICatCommandHandler<TCommand, TResult>
    where TCommand : class, Cat.Commands.Abstractions.ICatCommand<TResult>
```
#### Type parameters

<a name='Cat.Dapper.CatDapperCommandHandlerBase_TCommand,TResult_.TCommand'></a>

`TCommand`

The command this handler can run\.

<a name='Cat.Dapper.CatDapperCommandHandlerBase_TCommand,TResult_.TResult'></a>

`TResult`

The type of the data the handler returns\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatDapperCommandHandlerBase\<TCommand,TResult\>

Implements [Cat\.Commands\.Abstractions\.ICatCommandHandler&lt;](../../../Cat.Commands/namespaces/Cat.Commands.Abstractions/ICatCommandHandler_TCommand,TResult_.md 'Cat\.Commands\.Abstractions\.ICatCommandHandler\`2')[TCommand](CatDapperCommandHandlerBase_TCommand,TResult_.md#Cat.Dapper.CatDapperCommandHandlerBase_TCommand,TResult_.TCommand 'Cat\.Dapper\.CatDapperCommandHandlerBase\<TCommand,TResult\>\.TCommand')[,](../../../Cat.Commands/namespaces/Cat.Commands.Abstractions/ICatCommandHandler_TCommand,TResult_.md 'Cat\.Commands\.Abstractions\.ICatCommandHandler\`2')[TResult](CatDapperCommandHandlerBase_TCommand,TResult_.md#Cat.Dapper.CatDapperCommandHandlerBase_TCommand,TResult_.TResult 'Cat\.Dapper\.CatDapperCommandHandlerBase\<TCommand,TResult\>\.TResult')[&gt;](../../../Cat.Commands/namespaces/Cat.Commands.Abstractions/ICatCommandHandler_TCommand,TResult_.md 'Cat\.Commands\.Abstractions\.ICatCommandHandler\`2')

| Constructors | |
| :--- | :--- |
| [CatDapperCommandHandlerBase\(ICatDbSession\)](CatDapperCommandHandlerBase_TCommand,TResult_..ctor.9SJYQLWKZIJ6L7DKASZ7NHRY9.md 'Cat\.Dapper\.CatDapperCommandHandlerBase\<TCommand,TResult\>\.CatDapperCommandHandlerBase\(Cat\.Dapper\.Abstractions\.ICatDbSession\)') | Creates the handler\. |

| Properties | |
| :--- | :--- |
| [Session](CatDapperCommandHandlerBase_TCommand,TResult_.Session.md 'Cat\.Dapper\.CatDapperCommandHandlerBase\<TCommand,TResult\>\.Session') | The session to change data with\. |

| Methods | |
| :--- | :--- |
| [HandleAsync\(TCommand, CancellationToken\)](CatDapperCommandHandlerBase_TCommand,TResult_.HandleAsync.B7UNI8HW2E0YPJ9OPRQY38SSD.md 'Cat\.Dapper\.CatDapperCommandHandlerBase\<TCommand,TResult\>\.HandleAsync\(TCommand, System\.Threading\.CancellationToken\)') | Runs the command\. |
