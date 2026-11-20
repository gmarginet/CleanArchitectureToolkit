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
  
##### >> [Cat\.Dapper\.PostgreSQL Assembly](index.md 'index') >> [Cat\.Dapper\.PostgreSQL Namespace](Cat.Dapper.PostgreSQL.md 'Cat\.Dapper\.PostgreSQL') >> [PostgreSQLBulkExtensions Class](PostgreSQLBulkExtensions.md 'Cat\.Dapper\.PostgreSQL\.PostgreSQLBulkExtensions')

## PostgreSQLBulkExtensions\.GetNpgsqlAsync\(ICatDbSession, CancellationToken\) Method

```csharp
private static System.Threading.Tasks.Task<(Npgsql.NpgsqlConnection,Npgsql.NpgsqlTransaction?)> GetNpgsqlAsync(Cat.Dapper.Abstractions.ICatDbSession session, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='Cat.Dapper.PostgreSQL.PostgreSQLBulkExtensions.GetNpgsqlAsync(Cat.Dapper.Abstractions.ICatDbSession,System.Threading.CancellationToken).session'></a>

`session` [ICatDbSession](../../../Cat.Dapper/namespaces/Cat.Dapper.Abstractions/ICatDbSession.md 'Cat\.Dapper\.Abstractions\.ICatDbSession')

<a name='Cat.Dapper.PostgreSQL.PostgreSQLBulkExtensions.GetNpgsqlAsync(Cat.Dapper.Abstractions.ICatDbSession,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[Npgsql\.NpgsqlConnection](https://learn.microsoft.com/en-us/dotnet/api/npgsql.npgsqlconnection 'Npgsql\.NpgsqlConnection')[,](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[Npgsql\.NpgsqlTransaction](https://learn.microsoft.com/en-us/dotnet/api/npgsql.npgsqltransaction 'Npgsql\.NpgsqlTransaction')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')