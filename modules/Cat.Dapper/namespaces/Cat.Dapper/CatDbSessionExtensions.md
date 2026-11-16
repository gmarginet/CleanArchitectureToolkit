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

## CatDbSessionExtensions Class

Runs plain SQL on a [ICatDbSession](../../../Cat.Dapper/namespaces/Cat.Dapper.Abstractions/ICatDbSession.md 'Cat\.Dapper\.Abstractions\.ICatDbSession') with Dapper\. Every method opens the connection when it is needed
and takes part in the transaction of the session, if one is running\.

```csharp
public static class CatDbSessionExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatDbSessionExtensions

### Remarks
Pass values only through `param`, never by building the SQL text from user input\. Dapper sends them as parameters\.

| Methods | |
| :--- | :--- |
| [ExecuteAsync\(this ICatDbSession, string, object, CancellationToken\)](CatDbSessionExtensions.ExecuteAsync.BC0KMCHH17BHLR5CMKS8EOZUD.md 'Cat\.Dapper\.CatDbSessionExtensions\.ExecuteAsync\(this Cat\.Dapper\.Abstractions\.ICatDbSession, string, object, System\.Threading\.CancellationToken\)') | Runs a statement that returns no rows, such as an insert, an update or a stored procedure\. |
| [ExecuteScalarAsync&lt;T&gt;\(this ICatDbSession, string, object, CancellationToken\)](CatDbSessionExtensions.ExecuteScalarAsync.K75890MCJHMZ9IKOQLFKI5VH4.md 'Cat\.Dapper\.CatDbSessionExtensions\.ExecuteScalarAsync\<T\>\(this Cat\.Dapper\.Abstractions\.ICatDbSession, string, object, System\.Threading\.CancellationToken\)') | Runs a statement and returns the first column of the first row, such as a count or a new id\. |
| [PrepareAsync\(this ICatDbSession, string, object, CancellationToken\)](CatDbSessionExtensions.PrepareAsync.XEAZ0FVE7R9S1QI3R4YUKHV7.md 'Cat\.Dapper\.CatDbSessionExtensions\.PrepareAsync\(this Cat\.Dapper\.Abstractions\.ICatDbSession, string, object, System\.Threading\.CancellationToken\)') | Builds the Dapper command for a piece of SQL, with the transaction of the session\. Use it to call Dapper directly, for example for `QueryMultipleAsync`\. |
| [QueryAsync&lt;T&gt;\(this ICatDbSession, string, object, CancellationToken\)](CatDbSessionExtensions.QueryAsync.W08URJB7Q2RX7FDXV3PYMVHF5.md 'Cat\.Dapper\.CatDbSessionExtensions\.QueryAsync\<T\>\(this Cat\.Dapper\.Abstractions\.ICatDbSession, string, object, System\.Threading\.CancellationToken\)') | Runs a query and returns every row\. |
| [QueryFirstOrDefaultAsync&lt;T&gt;\(this ICatDbSession, string, object, CancellationToken\)](CatDbSessionExtensions.QueryFirstOrDefaultAsync.78YZ37MSPG4NSHWPYVKMMMB77.md 'Cat\.Dapper\.CatDbSessionExtensions\.QueryFirstOrDefaultAsync\<T\>\(this Cat\.Dapper\.Abstractions\.ICatDbSession, string, object, System\.Threading\.CancellationToken\)') | Runs a query and returns the first row, or the default value when there is none\. |
| [QuerySingleOrDefaultAsync&lt;T&gt;\(this ICatDbSession, string, object, CancellationToken\)](CatDbSessionExtensions.QuerySingleOrDefaultAsync.XYSORTP92PMKR05SNXELY8YN9.md 'Cat\.Dapper\.CatDbSessionExtensions\.QuerySingleOrDefaultAsync\<T\>\(this Cat\.Dapper\.Abstractions\.ICatDbSession, string, object, System\.Threading\.CancellationToken\)') | Runs a query that has to return zero or one row\. |
