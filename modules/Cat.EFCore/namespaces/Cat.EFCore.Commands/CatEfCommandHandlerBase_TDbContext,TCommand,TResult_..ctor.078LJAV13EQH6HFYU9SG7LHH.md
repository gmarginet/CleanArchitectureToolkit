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
  
##### >> [Cat\.EFCore\.Commands Assembly](index.md 'index') >> [Cat\.EFCore\.Commands Namespace](Cat.EFCore.Commands.md 'Cat\.EFCore\.Commands') >> [CatEfCommandHandlerBase&lt;TDbContext,TCommand,TResult&gt; Class](CatEfCommandHandlerBase_TDbContext,TCommand,TResult_.md 'Cat\.EFCore\.Commands\.CatEfCommandHandlerBase\<TDbContext,TCommand,TResult\>')

## CatEfCommandHandlerBase\(TDbContext\) Constructor

Creates the handler\.

```csharp
protected CatEfCommandHandlerBase(TDbContext dbContext);
```
#### Parameters

<a name='Cat.EFCore.Commands.CatEfCommandHandlerBase_TDbContext,TCommand,TResult_.CatEfCommandHandlerBase(TDbContext).dbContext'></a>

`dbContext` [TDbContext](CatEfCommandHandlerBase_TDbContext,TCommand,TResult_.md#Cat.EFCore.Commands.CatEfCommandHandlerBase_TDbContext,TCommand,TResult_.TDbContext 'Cat\.EFCore\.Commands\.CatEfCommandHandlerBase\<TDbContext,TCommand,TResult\>\.TDbContext')

The context to change data with\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
Thrown when [dbContext](CatEfCommandHandlerBase_TDbContext,TCommand,TResult_..ctor.078LJAV13EQH6HFYU9SG7LHH.md#Cat.EFCore.Commands.CatEfCommandHandlerBase_TDbContext,TCommand,TResult_.CatEfCommandHandlerBase(TDbContext).dbContext 'Cat\.EFCore\.Commands\.CatEfCommandHandlerBase\<TDbContext,TCommand,TResult\>\.CatEfCommandHandlerBase\(TDbContext\)\.dbContext') is `null`\.