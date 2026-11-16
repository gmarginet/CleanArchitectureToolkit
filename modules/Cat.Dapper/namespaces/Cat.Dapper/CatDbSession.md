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

## CatDbSession Class

The default [ICatDbSession](../../../Cat.Dapper/namespaces/Cat.Dapper.Abstractions/ICatDbSession.md 'Cat\.Dapper\.Abstractions\.ICatDbSession')\. It takes one connection from the factory, opens it on first use
and disposes it, and a transaction that was not committed, with the scope\.

```csharp
public sealed class CatDbSession : Cat.Dapper.Abstractions.ICatDbSession, System.IDisposable
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatDbSession

Implements [ICatDbSession](../../../Cat.Dapper/namespaces/Cat.Dapper.Abstractions/ICatDbSession.md 'Cat\.Dapper\.Abstractions\.ICatDbSession'), [System\.IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable 'System\.IDisposable')

| Constructors | |
| :--- | :--- |
| [CatDbSession\(ICatDbConnectionFactory\)](CatDbSession..ctor.CE9UN3B5T6D6ESZ0I7Q4NXY12.md 'Cat\.Dapper\.CatDbSession\.CatDbSession\(Cat\.Dapper\.Abstractions\.ICatDbConnectionFactory\)') | Creates the session\. |

| Fields | |
| :--- | :--- |
| [\_connection](CatDbSession._connection.md 'Cat\.Dapper\.CatDbSession\.\_connection') | |
| [\_connectionFactory](CatDbSession._connectionFactory.md 'Cat\.Dapper\.CatDbSession\.\_connectionFactory') | |
| [\_disposed](CatDbSession._disposed.md 'Cat\.Dapper\.CatDbSession\.\_disposed') | |
| [\_transaction](CatDbSession._transaction.md 'Cat\.Dapper\.CatDbSession\.\_transaction') | |

| Properties | |
| :--- | :--- |
| [Transaction](CatDbSession.Transaction.md 'Cat\.Dapper\.CatDbSession\.Transaction') | The transaction that is running, or `null` when there is none\. A transaction that was committed or rolled back is no longer running, so this is `null` after that\. |

| Methods | |
| :--- | :--- |
| [BeginTransactionAsync\(IsolationLevel, CancellationToken\)](CatDbSession.BeginTransactionAsync.1QSXZ67SA4YOZCJ1JQ75AWSDC.md 'Cat\.Dapper\.CatDbSession\.BeginTransactionAsync\(System\.Data\.IsolationLevel, System\.Threading\.CancellationToken\)') | Starts a transaction on the connection of the session\. Commit it explicitly\. A transaction that is not committed rolls back when the session is disposed\. |
| [Dispose\(\)](CatDbSession.Dispose().md 'Cat\.Dapper\.CatDbSession\.Dispose\(\)') | Disposes the transaction, which rolls it back when it is not committed, and then the connection\. |
| [GetConnectionAsync\(CancellationToken\)](CatDbSession.GetConnectionAsync.G4XSLBLZO3TR4VK38J5KJ7Q73.md 'Cat\.Dapper\.CatDbSession\.GetConnectionAsync\(System\.Threading\.CancellationToken\)') | Gives the connection of the session\. It creates the connection and opens it on the first call\. |
| [ThrowIfDisposed\(\)](CatDbSession.ThrowIfDisposed().md 'Cat\.Dapper\.CatDbSession\.ThrowIfDisposed\(\)') | |
