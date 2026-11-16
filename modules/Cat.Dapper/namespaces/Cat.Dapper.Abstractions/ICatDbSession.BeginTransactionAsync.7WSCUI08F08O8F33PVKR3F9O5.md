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
  
##### >> [Cat\.Dapper\.Abstractions Assembly](index.md 'index') >> [Cat\.Dapper\.Abstractions Namespace](Cat.Dapper.Abstractions.md 'Cat\.Dapper\.Abstractions') >> [ICatDbSession Interface](ICatDbSession.md 'Cat\.Dapper\.Abstractions\.ICatDbSession')

## ICatDbSession\.BeginTransactionAsync\(IsolationLevel, CancellationToken\) Method

Starts a transaction on the connection of the session\. Commit it explicitly\.
A transaction that is not committed rolls back when the session is disposed\.

```csharp
System.Threading.Tasks.Task<System.Data.Common.DbTransaction> BeginTransactionAsync(System.Data.IsolationLevel isolationLevel=System.Data.IsolationLevel.Unspecified, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Cat.Dapper.Abstractions.ICatDbSession.BeginTransactionAsync(System.Data.IsolationLevel,System.Threading.CancellationToken).isolationLevel'></a>

`isolationLevel` [System\.Data\.IsolationLevel](https://learn.microsoft.com/en-us/dotnet/api/system.data.isolationlevel 'System\.Data\.IsolationLevel')

The isolation level\. The default is the default of the database\.

<a name='Cat.Dapper.Abstractions.ICatDbSession.BeginTransactionAsync(System.Data.IsolationLevel,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Token to cancel the work\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Data\.Common\.DbTransaction](https://learn.microsoft.com/en-us/dotnet/api/system.data.common.dbtransaction 'System\.Data\.Common\.DbTransaction')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The new transaction\.

#### Exceptions

[System\.InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception 'System\.InvalidOperationException')  
Thrown when a transaction is already running\.