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
  
##### >> [Cat\.EFCore\.Commands Assembly](index.md 'index')

## Cat\.EFCore\.Commands Namespace

Holds the base classes for command handlers that change data with Entity Framework Core\.
They give the handler its context and leave transactions and saving to the handler\.

| Classes | |
| :--- | :--- |
| [CatEfCommandHandlerBase&lt;TDbContext,TCommand,TResult&gt;](CatEfCommandHandlerBase_TDbContext,TCommand,TResult_.md 'Cat\.EFCore\.Commands\.CatEfCommandHandlerBase\<TDbContext,TCommand,TResult\>') | Base class for command handlers that change data with Entity Framework Core and return a result\. It only gives the handler its [DbContext](CatEfCommandHandlerBase_TDbContext,TCommand,TResult_.DbContext.md 'Cat\.EFCore\.Commands\.CatEfCommandHandlerBase\<TDbContext,TCommand,TResult\>\.DbContext')\. The handler decides when to start a transaction and when to call `SaveChanges`\. |
| [CatEfCommandHandlerBase&lt;TDbContext,TCommand&gt;](CatEfCommandHandlerBase_TDbContext,TCommand_.md 'Cat\.EFCore\.Commands\.CatEfCommandHandlerBase\<TDbContext,TCommand\>') | Base class for command handlers that change data with Entity Framework Core and return no result\. It only gives the handler its [DbContext](CatEfCommandHandlerBase_TDbContext,TCommand_.DbContext.md 'Cat\.EFCore\.Commands\.CatEfCommandHandlerBase\<TDbContext,TCommand\>\.DbContext')\. The handler decides when to start a transaction and when to call `SaveChanges`\. |
