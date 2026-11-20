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
  
##### >> [Cat\.Dapper\.PostgreSQL Assembly](index.md 'index') >> [Cat\.Dapper\.PostgreSQL Namespace](Cat.Dapper.PostgreSQL.md 'Cat\.Dapper\.PostgreSQL')

## PostgreSQLBulkExtensions Class

Bulk insert, update, delete and merge on PostgreSQL, on the connection and the transaction of the session\.

```csharp
public static class PostgreSQLBulkExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → PostgreSQLBulkExtensions

### Remarks
Rows are objects of the same classes you already use with Dapper\. A property name is a column name, and the optional column lists narrow the columns\.
Table and column names go into the SQL text, so the helpers wrap every name in double quotes, exactly as given, and refuse a name that holds a quote\.
A quoted name is case sensitive on PostgreSQL\. Even so, give the helpers constants of your handler and never user input\.
The helpers use the transaction of the session when one is running, and none otherwise\.
A failure without a transaction leaves the batches that were already written\.
Insert streams the rows with a binary `COPY`\. The \.NET type of a property must match the type of the column, such as [System\.Guid](https://learn.microsoft.com/en-us/dotnet/api/system.guid 'System\.Guid') for `uuid`,
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32') for `integer` and a [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime') of kind Utc for `timestamptz`\. An enum is written as its number\.
Update, delete and merge fill a temporary table with `COPY` and run one statement that joins it to the target\.

| Methods | |
| :--- | :--- |
| [BulkDeleteAsync&lt;T&gt;\(this ICatDbSession, IEnumerable&lt;T&gt;, string, IEnumerable&lt;string&gt;, int, Nullable&lt;int&gt;, CancellationToken\)](PostgreSQLBulkExtensions.BulkDeleteAsync.md#Cat.Dapper.PostgreSQL.PostgreSQLBulkExtensions.BulkDeleteAsync_T_(thisCat.Dapper.Abstractions.ICatDbSession,System.Collections.Generic.IEnumerable_T_,string,System.Collections.Generic.IEnumerable_string_,int,System.Nullable_int_,System.Threading.CancellationToken) 'Cat\.Dapper\.PostgreSQL\.PostgreSQLBulkExtensions\.BulkDeleteAsync\<T\>\(this Cat\.Dapper\.Abstractions\.ICatDbSession, System\.Collections\.Generic\.IEnumerable\<T\>, string, System\.Collections\.Generic\.IEnumerable\<string\>, int, System\.Nullable\<int\>, System\.Threading\.CancellationToken\)') | Deletes the rows of the table that match the given rows on the key columns\. It covers a composite key\. |
| [BulkDeleteAsync&lt;TKey&gt;\(this ICatDbSession, IEnumerable&lt;TKey&gt;, string, string, int, Nullable&lt;int&gt;, CancellationToken\)](PostgreSQLBulkExtensions.BulkDeleteAsync.md#Cat.Dapper.PostgreSQL.PostgreSQLBulkExtensions.BulkDeleteAsync_TKey_(thisCat.Dapper.Abstractions.ICatDbSession,System.Collections.Generic.IEnumerable_TKey_,string,string,int,System.Nullable_int_,System.Threading.CancellationToken) 'Cat\.Dapper\.PostgreSQL\.PostgreSQLBulkExtensions\.BulkDeleteAsync\<TKey\>\(this Cat\.Dapper\.Abstractions\.ICatDbSession, System\.Collections\.Generic\.IEnumerable\<TKey\>, string, string, int, System\.Nullable\<int\>, System\.Threading\.CancellationToken\)') | Deletes the rows of the table whose key column holds one of the given values\. |
| [BulkInsertAsync\(this ICatDbSession, IDataReader, string, int, Nullable&lt;int&gt;, CancellationToken\)](PostgreSQLBulkExtensions.BulkInsertAsync.md#Cat.Dapper.PostgreSQL.PostgreSQLBulkExtensions.BulkInsertAsync(thisCat.Dapper.Abstractions.ICatDbSession,System.Data.IDataReader,string,int,System.Nullable_int_,System.Threading.CancellationToken) 'Cat\.Dapper\.PostgreSQL\.PostgreSQLBulkExtensions\.BulkInsertAsync\(this Cat\.Dapper\.Abstractions\.ICatDbSession, System\.Data\.IDataReader, string, int, System\.Nullable\<int\>, System\.Threading\.CancellationToken\)') | Copies the rows of a reader into the table with a binary `COPY`\. The column names of the reader are the column names of the table\. |
| [BulkInsertAsync&lt;T&gt;\(this ICatDbSession, IEnumerable&lt;T&gt;, string, IEnumerable&lt;string&gt;, int, Nullable&lt;int&gt;, CancellationToken\)](PostgreSQLBulkExtensions.BulkInsertAsync.md#Cat.Dapper.PostgreSQL.PostgreSQLBulkExtensions.BulkInsertAsync_T_(thisCat.Dapper.Abstractions.ICatDbSession,System.Collections.Generic.IEnumerable_T_,string,System.Collections.Generic.IEnumerable_string_,int,System.Nullable_int_,System.Threading.CancellationToken) 'Cat\.Dapper\.PostgreSQL\.PostgreSQLBulkExtensions\.BulkInsertAsync\<T\>\(this Cat\.Dapper\.Abstractions\.ICatDbSession, System\.Collections\.Generic\.IEnumerable\<T\>, string, System\.Collections\.Generic\.IEnumerable\<string\>, int, System\.Nullable\<int\>, System\.Threading\.CancellationToken\)') | Copies the rows into the table with a binary `COPY`\. Generated values, such as an identity, are not returned\. |
| [BulkMergeAsync&lt;T&gt;\(this ICatDbSession, IEnumerable&lt;T&gt;, string, IEnumerable&lt;string&gt;, IEnumerable&lt;string&gt;, int, Nullable&lt;int&gt;, CancellationToken\)](PostgreSQLBulkExtensions.BulkMergeAsync.CWVO1227XWE1FETOVQMZHB4R5.md 'Cat\.Dapper\.PostgreSQL\.PostgreSQLBulkExtensions\.BulkMergeAsync\<T\>\(this Cat\.Dapper\.Abstractions\.ICatDbSession, System\.Collections\.Generic\.IEnumerable\<T\>, string, System\.Collections\.Generic\.IEnumerable\<string\>, System\.Collections\.Generic\.IEnumerable\<string\>, int, System\.Nullable\<int\>, System\.Threading\.CancellationToken\)') | Updates the rows that exist and inserts the rows that do not, with one `INSERT ... ON CONFLICT DO UPDATE` statement\. Rows that are missing from the given set are left alone\. |
| [BulkUpdateAsync&lt;T&gt;\(this ICatDbSession, IEnumerable&lt;T&gt;, string, IEnumerable&lt;string&gt;, IEnumerable&lt;string&gt;, int, Nullable&lt;int&gt;, CancellationToken\)](PostgreSQLBulkExtensions.BulkUpdateAsync.89YTCMXP4DL8FRVBMCDE8IIW2.md 'Cat\.Dapper\.PostgreSQL\.PostgreSQLBulkExtensions\.BulkUpdateAsync\<T\>\(this Cat\.Dapper\.Abstractions\.ICatDbSession, System\.Collections\.Generic\.IEnumerable\<T\>, string, System\.Collections\.Generic\.IEnumerable\<string\>, System\.Collections\.Generic\.IEnumerable\<string\>, int, System\.Nullable\<int\>, System\.Threading\.CancellationToken\)') | Updates the rows of the table that match the given rows on the key columns\. |
| [CopyAsync\(NpgsqlConnection, BulkRowSource, string, IReadOnlyList&lt;string&gt;, int, Nullable&lt;int&gt;, CancellationToken\)](PostgreSQLBulkExtensions.CopyAsync.YW4FJFFI4YT3605EDGI4K4OQC.md 'Cat\.Dapper\.PostgreSQL\.PostgreSQLBulkExtensions\.CopyAsync\(Npgsql\.NpgsqlConnection, Cat\.Dapper\.PostgreSQL\.BulkRowSource, string, System\.Collections\.Generic\.IReadOnlyList\<string\>, int, System\.Nullable\<int\>, System\.Threading\.CancellationToken\)') | Writes the rows with one or more binary `COPY` operations\. A new `COPY` starts after every [batchSize](PostgreSQLBulkExtensions.CopyAsync.YW4FJFFI4YT3605EDGI4K4OQC.md#Cat.Dapper.PostgreSQL.PostgreSQLBulkExtensions.CopyAsync(Npgsql.NpgsqlConnection,Cat.Dapper.PostgreSQL.BulkRowSource,string,System.Collections.Generic.IReadOnlyList_string_,int,System.Nullable_int_,System.Threading.CancellationToken).batchSize 'Cat\.Dapper\.PostgreSQL\.PostgreSQLBulkExtensions\.CopyAsync\(Npgsql\.NpgsqlConnection, Cat\.Dapper\.PostgreSQL\.BulkRowSource, string, System\.Collections\.Generic\.IReadOnlyList\<string\>, int, System\.Nullable\<int\>, System\.Threading\.CancellationToken\)\.batchSize') rows\. |
| [GetNpgsqlAsync\(ICatDbSession, CancellationToken\)](PostgreSQLBulkExtensions.GetNpgsqlAsync.C9BZ7PFF9KJTUJUT0CV53ETR5.md 'Cat\.Dapper\.PostgreSQL\.PostgreSQLBulkExtensions\.GetNpgsqlAsync\(Cat\.Dapper\.Abstractions\.ICatDbSession, System\.Threading\.CancellationToken\)') | |
| [RunStagedAsync&lt;T,TResult&gt;\(ICatDbSession, IEnumerable&lt;T&gt;, IReadOnlyList&lt;BulkColumn&gt;, string, int, Nullable&lt;int&gt;, CancellationToken, Func&lt;string,string&gt;, Func&lt;NpgsqlCommand,Task&lt;TResult&gt;&gt;\)](PostgreSQLBulkExtensions.RunStagedAsync.ECH73ZIRA7NB5BGLGEGSXC6WD.md 'Cat\.Dapper\.PostgreSQL\.PostgreSQLBulkExtensions\.RunStagedAsync\<T,TResult\>\(Cat\.Dapper\.Abstractions\.ICatDbSession, System\.Collections\.Generic\.IEnumerable\<T\>, System\.Collections\.Generic\.IReadOnlyList\<Cat\.Dapper\.BulkColumn\>, string, int, System\.Nullable\<int\>, System\.Threading\.CancellationToken, System\.Func\<string,string\>, System\.Func\<Npgsql\.NpgsqlCommand,System\.Threading\.Tasks\.Task\<TResult\>\>\)') | |
| [ValidateColumn\(string\)](PostgreSQLBulkExtensions.ValidateColumn.CV7M7FQSHQCFBDBA2WV8CHX1.md 'Cat\.Dapper\.PostgreSQL\.PostgreSQLBulkExtensions\.ValidateColumn\(string\)') | |
| [ValidateColumns\(IEnumerable&lt;BulkColumn&gt;\)](PostgreSQLBulkExtensions.ValidateColumns.B6HP81J2VWWIY7VPQDO1TQV8D.md 'Cat\.Dapper\.PostgreSQL\.PostgreSQLBulkExtensions\.ValidateColumns\(System\.Collections\.Generic\.IEnumerable\<Cat\.Dapper\.BulkColumn\>\)') | |
