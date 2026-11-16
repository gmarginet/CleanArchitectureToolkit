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
  
##### >> [Cat\.Dapper\.Abstractions Assembly](index.md 'index') >> [Cat\.Dapper\.Abstractions Namespace](Cat.Dapper.Abstractions.md 'Cat\.Dapper\.Abstractions')

## ICatDbSession Interface

One database connection for the length of one scope, such as one request or one message\.
The session takes the connection from [ICatDbConnectionFactory](ICatDbConnectionFactory.md 'Cat\.Dapper\.Abstractions\.ICatDbConnectionFactory') and opens it on first use,
so a handler never opens or closes a connection\. A session is not thread safe\.

```csharp
public interface ICatDbSession : System.IDisposable
```

Implements [System\.IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable 'System\.IDisposable')

| Properties | |
| :--- | :--- |
| [Transaction](ICatDbSession.Transaction.md 'Cat\.Dapper\.Abstractions\.ICatDbSession\.Transaction') | The transaction that is running, or `null` when there is none\. A transaction that was committed or rolled back is no longer running, so this is `null` after that\. |

| Methods | |
| :--- | :--- |
| [BeginTransactionAsync\(IsolationLevel, CancellationToken\)](ICatDbSession.BeginTransactionAsync.7WSCUI08F08O8F33PVKR3F9O5.md 'Cat\.Dapper\.Abstractions\.ICatDbSession\.BeginTransactionAsync\(System\.Data\.IsolationLevel, System\.Threading\.CancellationToken\)') | Starts a transaction on the connection of the session\. Commit it explicitly\. A transaction that is not committed rolls back when the session is disposed\. |
| [GetConnectionAsync\(CancellationToken\)](ICatDbSession.GetConnectionAsync.91NMK6W9ZQIM09GF15NP83IY3.md 'Cat\.Dapper\.Abstractions\.ICatDbSession\.GetConnectionAsync\(System\.Threading\.CancellationToken\)') | Gives the connection of the session\. It creates the connection and opens it on the first call\. |
