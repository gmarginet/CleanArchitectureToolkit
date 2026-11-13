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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.EFCORE](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.EFCore\.Commands Assembly](index.md 'index') >> [Cat\.EFCore\.Commands Namespace](Cat.EFCore.Commands.md 'Cat\.EFCore\.Commands')

## CatEfCommandHandlerBase\<TDbContext,TCommand,TResult\> Class

Base class for command handlers that change data with Entity Framework Core and return a result\.
It only gives the handler its [DbContext](CatEfCommandHandlerBase_TDbContext,TCommand,TResult_.DbContext.md 'Cat\.EFCore\.Commands\.CatEfCommandHandlerBase\<TDbContext,TCommand,TResult\>\.DbContext')\. The handler decides when to start a transaction
and when to call `SaveChanges`\.

```csharp
public abstract class CatEfCommandHandlerBase<TDbContext,TCommand,TResult> : Cat.Commands.Abstractions.ICatCommandHandler<TCommand, TResult>
    where TDbContext : Microsoft.EntityFrameworkCore.DbContext
    where TCommand : class, Cat.Commands.Abstractions.ICatCommand<TResult>
```
#### Type parameters

<a name='Cat.EFCore.Commands.CatEfCommandHandlerBase_TDbContext,TCommand,TResult_.TDbContext'></a>

`TDbContext`

The context type\. Any [Microsoft\.EntityFrameworkCore\.DbContext](https://learn.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbcontext 'Microsoft\.EntityFrameworkCore\.DbContext') works, also a scaffolded one\.

<a name='Cat.EFCore.Commands.CatEfCommandHandlerBase_TDbContext,TCommand,TResult_.TCommand'></a>

`TCommand`

The command this handler can run\.

<a name='Cat.EFCore.Commands.CatEfCommandHandlerBase_TDbContext,TCommand,TResult_.TResult'></a>

`TResult`

The type of the data the handler returns\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatEfCommandHandlerBase\<TDbContext,TCommand,TResult\>

Implements [Cat\.Commands\.Abstractions\.ICatCommandHandler&lt;](../../../Cat.Commands/namespaces/Cat.Commands.Abstractions/ICatCommandHandler_TCommand,TResult_.md 'Cat\.Commands\.Abstractions\.ICatCommandHandler\`2')[TCommand](CatEfCommandHandlerBase_TDbContext,TCommand,TResult_.md#Cat.EFCore.Commands.CatEfCommandHandlerBase_TDbContext,TCommand,TResult_.TCommand 'Cat\.EFCore\.Commands\.CatEfCommandHandlerBase\<TDbContext,TCommand,TResult\>\.TCommand')[,](../../../Cat.Commands/namespaces/Cat.Commands.Abstractions/ICatCommandHandler_TCommand,TResult_.md 'Cat\.Commands\.Abstractions\.ICatCommandHandler\`2')[TResult](CatEfCommandHandlerBase_TDbContext,TCommand,TResult_.md#Cat.EFCore.Commands.CatEfCommandHandlerBase_TDbContext,TCommand,TResult_.TResult 'Cat\.EFCore\.Commands\.CatEfCommandHandlerBase\<TDbContext,TCommand,TResult\>\.TResult')[&gt;](../../../Cat.Commands/namespaces/Cat.Commands.Abstractions/ICatCommandHandler_TCommand,TResult_.md 'Cat\.Commands\.Abstractions\.ICatCommandHandler\`2')

| Constructors | |
| :--- | :--- |
| [CatEfCommandHandlerBase\(TDbContext\)](CatEfCommandHandlerBase_TDbContext,TCommand,TResult_..ctor.078LJAV13EQH6HFYU9SG7LHH.md 'Cat\.EFCore\.Commands\.CatEfCommandHandlerBase\<TDbContext,TCommand,TResult\>\.CatEfCommandHandlerBase\(TDbContext\)') | Creates the handler\. |

| Properties | |
| :--- | :--- |
| [DbContext](CatEfCommandHandlerBase_TDbContext,TCommand,TResult_.DbContext.md 'Cat\.EFCore\.Commands\.CatEfCommandHandlerBase\<TDbContext,TCommand,TResult\>\.DbContext') | The context to change data with\. |

| Methods | |
| :--- | :--- |
| [HandleAsync\(TCommand, CancellationToken\)](CatEfCommandHandlerBase_TDbContext,TCommand,TResult_.HandleAsync.SI7HCBZ29G0U3MAWYEHWNE8QC.md 'Cat\.EFCore\.Commands\.CatEfCommandHandlerBase\<TDbContext,TCommand,TResult\>\.HandleAsync\(TCommand, System\.Threading\.CancellationToken\)') | |
