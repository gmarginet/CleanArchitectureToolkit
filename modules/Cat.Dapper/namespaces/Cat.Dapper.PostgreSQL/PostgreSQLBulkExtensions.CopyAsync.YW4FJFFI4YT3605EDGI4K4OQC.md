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

## PostgreSQLBulkExtensions\.CopyAsync\(NpgsqlConnection, BulkRowSource, string, IReadOnlyList\<string\>, int, Nullable\<int\>, CancellationToken\) Method

Writes the rows with one or more binary `COPY` operations\. A new `COPY` starts after every [batchSize](PostgreSQLBulkExtensions.CopyAsync.YW4FJFFI4YT3605EDGI4K4OQC.md#Cat.Dapper.PostgreSQL.PostgreSQLBulkExtensions.CopyAsync(Npgsql.NpgsqlConnection,Cat.Dapper.PostgreSQL.BulkRowSource,string,System.Collections.Generic.IReadOnlyList_string_,int,System.Nullable_int_,System.Threading.CancellationToken).batchSize 'Cat\.Dapper\.PostgreSQL\.PostgreSQLBulkExtensions\.CopyAsync\(Npgsql\.NpgsqlConnection, Cat\.Dapper\.PostgreSQL\.BulkRowSource, string, System\.Collections\.Generic\.IReadOnlyList\<string\>, int, System\.Nullable\<int\>, System\.Threading\.CancellationToken\)\.batchSize') rows\.

```csharp
private static System.Threading.Tasks.Task<int> CopyAsync(Npgsql.NpgsqlConnection connection, Cat.Dapper.PostgreSQL.BulkRowSource source, string table, System.Collections.Generic.IReadOnlyList<string> columns, int batchSize, System.Nullable<int> timeoutSeconds, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='Cat.Dapper.PostgreSQL.PostgreSQLBulkExtensions.CopyAsync(Npgsql.NpgsqlConnection,Cat.Dapper.PostgreSQL.BulkRowSource,string,System.Collections.Generic.IReadOnlyList_string_,int,System.Nullable_int_,System.Threading.CancellationToken).connection'></a>

`connection` [Npgsql\.NpgsqlConnection](https://learn.microsoft.com/en-us/dotnet/api/npgsql.npgsqlconnection 'Npgsql\.NpgsqlConnection')

<a name='Cat.Dapper.PostgreSQL.PostgreSQLBulkExtensions.CopyAsync(Npgsql.NpgsqlConnection,Cat.Dapper.PostgreSQL.BulkRowSource,string,System.Collections.Generic.IReadOnlyList_string_,int,System.Nullable_int_,System.Threading.CancellationToken).source'></a>

`source` [BulkRowSource](BulkRowSource.md 'Cat\.Dapper\.PostgreSQL\.BulkRowSource')

<a name='Cat.Dapper.PostgreSQL.PostgreSQLBulkExtensions.CopyAsync(Npgsql.NpgsqlConnection,Cat.Dapper.PostgreSQL.BulkRowSource,string,System.Collections.Generic.IReadOnlyList_string_,int,System.Nullable_int_,System.Threading.CancellationToken).table'></a>

`table` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='Cat.Dapper.PostgreSQL.PostgreSQLBulkExtensions.CopyAsync(Npgsql.NpgsqlConnection,Cat.Dapper.PostgreSQL.BulkRowSource,string,System.Collections.Generic.IReadOnlyList_string_,int,System.Nullable_int_,System.Threading.CancellationToken).columns'></a>

`columns` [System\.Collections\.Generic\.IReadOnlyList&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1 'System\.Collections\.Generic\.IReadOnlyList\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1 'System\.Collections\.Generic\.IReadOnlyList\`1')

<a name='Cat.Dapper.PostgreSQL.PostgreSQLBulkExtensions.CopyAsync(Npgsql.NpgsqlConnection,Cat.Dapper.PostgreSQL.BulkRowSource,string,System.Collections.Generic.IReadOnlyList_string_,int,System.Nullable_int_,System.Threading.CancellationToken).batchSize'></a>

`batchSize` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='Cat.Dapper.PostgreSQL.PostgreSQLBulkExtensions.CopyAsync(Npgsql.NpgsqlConnection,Cat.Dapper.PostgreSQL.BulkRowSource,string,System.Collections.Generic.IReadOnlyList_string_,int,System.Nullable_int_,System.Threading.CancellationToken).timeoutSeconds'></a>

`timeoutSeconds` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='Cat.Dapper.PostgreSQL.PostgreSQLBulkExtensions.CopyAsync(Npgsql.NpgsqlConnection,Cat.Dapper.PostgreSQL.BulkRowSource,string,System.Collections.Generic.IReadOnlyList_string_,int,System.Nullable_int_,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')