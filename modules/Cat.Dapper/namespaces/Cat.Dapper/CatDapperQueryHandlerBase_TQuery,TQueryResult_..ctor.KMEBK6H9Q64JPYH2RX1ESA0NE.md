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
  
##### >> [Cat\.Dapper Assembly](index.md 'index') >> [Cat\.Dapper Namespace](Cat.Dapper.md 'Cat\.Dapper') >> [CatDapperQueryHandlerBase&lt;TQuery,TQueryResult&gt; Class](CatDapperQueryHandlerBase_TQuery,TQueryResult_.md 'Cat\.Dapper\.CatDapperQueryHandlerBase\<TQuery,TQueryResult\>')

## CatDapperQueryHandlerBase\(ICatDbSession\) Constructor

Creates the handler\.

```csharp
protected CatDapperQueryHandlerBase(Cat.Dapper.Abstractions.ICatDbSession session);
```
#### Parameters

<a name='Cat.Dapper.CatDapperQueryHandlerBase_TQuery,TQueryResult_.CatDapperQueryHandlerBase(Cat.Dapper.Abstractions.ICatDbSession).session'></a>

`session` [ICatDbSession](../../../Cat.Dapper/namespaces/Cat.Dapper.Abstractions/ICatDbSession.md 'Cat\.Dapper\.Abstractions\.ICatDbSession')

The session to read with\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
Thrown when [session](CatDapperQueryHandlerBase_TQuery,TQueryResult_..ctor.KMEBK6H9Q64JPYH2RX1ESA0NE.md#Cat.Dapper.CatDapperQueryHandlerBase_TQuery,TQueryResult_.CatDapperQueryHandlerBase(Cat.Dapper.Abstractions.ICatDbSession).session 'Cat\.Dapper\.CatDapperQueryHandlerBase\<TQuery,TQueryResult\>\.CatDapperQueryHandlerBase\(Cat\.Dapper\.Abstractions\.ICatDbSession\)\.session') is `null`\.