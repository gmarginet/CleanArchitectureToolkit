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
  
##### >> [Cat\.Dapper\.SqlServer Assembly](index.md 'index') >> [Cat\.Dapper\.SqlServer Namespace](Cat.Dapper.SqlServer.md 'Cat\.Dapper\.SqlServer') >> [SqlServerBulkExtensions Class](SqlServerBulkExtensions.md 'Cat\.Dapper\.SqlServer\.SqlServerBulkExtensions')

## SqlServerBulkExtensions\.CopyAsync\(SqlConnection, SqlTransaction, IDataReader, string, IEnumerable\<string\>, int, Nullable\<int\>, CancellationToken, Action\<int\>\) Method

```csharp
private static System.Threading.Tasks.Task CopyAsync(SqlConnection connection, SqlTransaction? transaction, System.Data.IDataReader reader, string table, System.Collections.Generic.IEnumerable<string> columns, int batchSize, System.Nullable<int> timeoutSeconds, System.Threading.CancellationToken cancellationToken, System.Action<int>? copied=null);
```
#### Parameters

<a name='Cat.Dapper.SqlServer.SqlServerBulkExtensions.CopyAsync(SqlConnection,SqlTransaction,System.Data.IDataReader,string,System.Collections.Generic.IEnumerable_string_,int,System.Nullable_int_,System.Threading.CancellationToken,System.Action_int_).connection'></a>

`connection` [Microsoft\.Data\.SqlClient\.SqlConnection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlconnection 'Microsoft\.Data\.SqlClient\.SqlConnection')

<a name='Cat.Dapper.SqlServer.SqlServerBulkExtensions.CopyAsync(SqlConnection,SqlTransaction,System.Data.IDataReader,string,System.Collections.Generic.IEnumerable_string_,int,System.Nullable_int_,System.Threading.CancellationToken,System.Action_int_).transaction'></a>

`transaction` [Microsoft\.Data\.SqlClient\.SqlTransaction](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqltransaction 'Microsoft\.Data\.SqlClient\.SqlTransaction')

<a name='Cat.Dapper.SqlServer.SqlServerBulkExtensions.CopyAsync(SqlConnection,SqlTransaction,System.Data.IDataReader,string,System.Collections.Generic.IEnumerable_string_,int,System.Nullable_int_,System.Threading.CancellationToken,System.Action_int_).reader'></a>

`reader` [System\.Data\.IDataReader](https://learn.microsoft.com/en-us/dotnet/api/system.data.idatareader 'System\.Data\.IDataReader')

<a name='Cat.Dapper.SqlServer.SqlServerBulkExtensions.CopyAsync(SqlConnection,SqlTransaction,System.Data.IDataReader,string,System.Collections.Generic.IEnumerable_string_,int,System.Nullable_int_,System.Threading.CancellationToken,System.Action_int_).table'></a>

`table` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='Cat.Dapper.SqlServer.SqlServerBulkExtensions.CopyAsync(SqlConnection,SqlTransaction,System.Data.IDataReader,string,System.Collections.Generic.IEnumerable_string_,int,System.Nullable_int_,System.Threading.CancellationToken,System.Action_int_).columns'></a>

`columns` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

<a name='Cat.Dapper.SqlServer.SqlServerBulkExtensions.CopyAsync(SqlConnection,SqlTransaction,System.Data.IDataReader,string,System.Collections.Generic.IEnumerable_string_,int,System.Nullable_int_,System.Threading.CancellationToken,System.Action_int_).batchSize'></a>

`batchSize` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='Cat.Dapper.SqlServer.SqlServerBulkExtensions.CopyAsync(SqlConnection,SqlTransaction,System.Data.IDataReader,string,System.Collections.Generic.IEnumerable_string_,int,System.Nullable_int_,System.Threading.CancellationToken,System.Action_int_).timeoutSeconds'></a>

`timeoutSeconds` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='Cat.Dapper.SqlServer.SqlServerBulkExtensions.CopyAsync(SqlConnection,SqlTransaction,System.Data.IDataReader,string,System.Collections.Generic.IEnumerable_string_,int,System.Nullable_int_,System.Threading.CancellationToken,System.Action_int_).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

<a name='Cat.Dapper.SqlServer.SqlServerBulkExtensions.CopyAsync(SqlConnection,SqlTransaction,System.Data.IDataReader,string,System.Collections.Generic.IEnumerable_string_,int,System.Nullable_int_,System.Threading.CancellationToken,System.Action_int_).copied'></a>

`copied` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

#### Returns
[System\.Threading\.Tasks\.Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task 'System\.Threading\.Tasks\.Task')