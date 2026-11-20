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
  
##### >> [Cat\.Dapper\.SqlServer Assembly](index.md 'index') >> [Cat\.Dapper\.SqlServer Namespace](Cat.Dapper.SqlServer.md 'Cat\.Dapper\.SqlServer')

## SqlServerBulkExtensions Class

Bulk insert, update, delete and merge on SQL Server, on the connection and the transaction of the session\.

```csharp
public static class SqlServerBulkExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → SqlServerBulkExtensions

### Remarks
Rows are objects of the same classes you already use with Dapper\. A property name is a column name, and the optional column lists narrow the columns\.
Table and column names go into the SQL text, so the helpers wrap every name in brackets and refuse a name that holds a bracket\.
Even so, give them constants of your handler and never user input\.
The helpers use the transaction of the session when one is running, and none otherwise\.
A failure without a transaction leaves the batches that were already written\.
Update, delete and merge fill a temporary table on the connection with `SqlBulkCopy`, run one statement that joins it to the target, and drop it\.

| Methods | |
| :--- | :--- |
| [BulkDeleteAsync&lt;T&gt;\(this ICatDbSession, IEnumerable&lt;T&gt;, string, IEnumerable&lt;string&gt;, int, Nullable&lt;int&gt;, CancellationToken\)](SqlServerBulkExtensions.BulkDeleteAsync.md#Cat.Dapper.SqlServer.SqlServerBulkExtensions.BulkDeleteAsync_T_(thisCat.Dapper.Abstractions.ICatDbSession,System.Collections.Generic.IEnumerable_T_,string,System.Collections.Generic.IEnumerable_string_,int,System.Nullable_int_,System.Threading.CancellationToken) 'Cat\.Dapper\.SqlServer\.SqlServerBulkExtensions\.BulkDeleteAsync\<T\>\(this Cat\.Dapper\.Abstractions\.ICatDbSession, System\.Collections\.Generic\.IEnumerable\<T\>, string, System\.Collections\.Generic\.IEnumerable\<string\>, int, System\.Nullable\<int\>, System\.Threading\.CancellationToken\)') | Deletes the rows of the table that match the given rows on the key columns\. It covers a composite key\. |
| [BulkDeleteAsync&lt;TKey&gt;\(this ICatDbSession, IEnumerable&lt;TKey&gt;, string, string, int, Nullable&lt;int&gt;, CancellationToken\)](SqlServerBulkExtensions.BulkDeleteAsync.md#Cat.Dapper.SqlServer.SqlServerBulkExtensions.BulkDeleteAsync_TKey_(thisCat.Dapper.Abstractions.ICatDbSession,System.Collections.Generic.IEnumerable_TKey_,string,string,int,System.Nullable_int_,System.Threading.CancellationToken) 'Cat\.Dapper\.SqlServer\.SqlServerBulkExtensions\.BulkDeleteAsync\<TKey\>\(this Cat\.Dapper\.Abstractions\.ICatDbSession, System\.Collections\.Generic\.IEnumerable\<TKey\>, string, string, int, System\.Nullable\<int\>, System\.Threading\.CancellationToken\)') | Deletes the rows of the table whose key column holds one of the given values\. |
| [BulkInsertAsync\(this ICatDbSession, IDataReader, string, int, Nullable&lt;int&gt;, CancellationToken\)](SqlServerBulkExtensions.BulkInsertAsync.md#Cat.Dapper.SqlServer.SqlServerBulkExtensions.BulkInsertAsync(thisCat.Dapper.Abstractions.ICatDbSession,System.Data.IDataReader,string,int,System.Nullable_int_,System.Threading.CancellationToken) 'Cat\.Dapper\.SqlServer\.SqlServerBulkExtensions\.BulkInsertAsync\(this Cat\.Dapper\.Abstractions\.ICatDbSession, System\.Data\.IDataReader, string, int, System\.Nullable\<int\>, System\.Threading\.CancellationToken\)') | Copies the rows of a reader into the table with `SqlBulkCopy`\. The column names of the reader are the column names of the table\. |
| [BulkInsertAsync&lt;T&gt;\(this ICatDbSession, IEnumerable&lt;T&gt;, string, IEnumerable&lt;string&gt;, int, Nullable&lt;int&gt;, CancellationToken\)](SqlServerBulkExtensions.BulkInsertAsync.md#Cat.Dapper.SqlServer.SqlServerBulkExtensions.BulkInsertAsync_T_(thisCat.Dapper.Abstractions.ICatDbSession,System.Collections.Generic.IEnumerable_T_,string,System.Collections.Generic.IEnumerable_string_,int,System.Nullable_int_,System.Threading.CancellationToken) 'Cat\.Dapper\.SqlServer\.SqlServerBulkExtensions\.BulkInsertAsync\<T\>\(this Cat\.Dapper\.Abstractions\.ICatDbSession, System\.Collections\.Generic\.IEnumerable\<T\>, string, System\.Collections\.Generic\.IEnumerable\<string\>, int, System\.Nullable\<int\>, System\.Threading\.CancellationToken\)') | Copies the rows into the table with `SqlBulkCopy`\. Generated values, such as an identity, are not returned\. |
| [BulkMergeAsync&lt;T&gt;\(this ICatDbSession, IEnumerable&lt;T&gt;, string, IEnumerable&lt;string&gt;, IEnumerable&lt;string&gt;, int, Nullable&lt;int&gt;, CancellationToken\)](SqlServerBulkExtensions.BulkMergeAsync.GE81BV4V017KMIQVBJHBSM9Z.md 'Cat\.Dapper\.SqlServer\.SqlServerBulkExtensions\.BulkMergeAsync\<T\>\(this Cat\.Dapper\.Abstractions\.ICatDbSession, System\.Collections\.Generic\.IEnumerable\<T\>, string, System\.Collections\.Generic\.IEnumerable\<string\>, System\.Collections\.Generic\.IEnumerable\<string\>, int, System\.Nullable\<int\>, System\.Threading\.CancellationToken\)') | Updates the rows that exist and inserts the rows that do not, with one `MERGE` statement that holds `HOLDLOCK`\. Rows that are missing from the given set are left alone\. |
| [BulkUpdateAsync&lt;T&gt;\(this ICatDbSession, IEnumerable&lt;T&gt;, string, IEnumerable&lt;string&gt;, IEnumerable&lt;string&gt;, int, Nullable&lt;int&gt;, CancellationToken\)](SqlServerBulkExtensions.BulkUpdateAsync.5285D4H0R1YNA8R23HN0JXSC8.md 'Cat\.Dapper\.SqlServer\.SqlServerBulkExtensions\.BulkUpdateAsync\<T\>\(this Cat\.Dapper\.Abstractions\.ICatDbSession, System\.Collections\.Generic\.IEnumerable\<T\>, string, System\.Collections\.Generic\.IEnumerable\<string\>, System\.Collections\.Generic\.IEnumerable\<string\>, int, System\.Nullable\<int\>, System\.Threading\.CancellationToken\)') | Updates the rows of the table that match the given rows on the key columns\. |
| [CopyAsync\(SqlConnection, SqlTransaction, IDataReader, string, IEnumerable&lt;string&gt;, int, Nullable&lt;int&gt;, CancellationToken, Action&lt;int&gt;\)](SqlServerBulkExtensions.CopyAsync.I1UWSODXKQ176G6GSIC2DE237.md 'Cat\.Dapper\.SqlServer\.SqlServerBulkExtensions\.CopyAsync\(SqlConnection, SqlTransaction, System\.Data\.IDataReader, string, System\.Collections\.Generic\.IEnumerable\<string\>, int, System\.Nullable\<int\>, System\.Threading\.CancellationToken, System\.Action\<int\>\)') | |
| [GetSqlAsync\(ICatDbSession, CancellationToken\)](SqlServerBulkExtensions.GetSqlAsync.6Z0WZQH7MQD6AXZ9VCZJV6TR7.md 'Cat\.Dapper\.SqlServer\.SqlServerBulkExtensions\.GetSqlAsync\(Cat\.Dapper\.Abstractions\.ICatDbSession, System\.Threading\.CancellationToken\)') | |
| [RunStagedAsync&lt;T,TResult&gt;\(ICatDbSession, IEnumerable&lt;T&gt;, IReadOnlyList&lt;BulkColumn&gt;, string, int, Nullable&lt;int&gt;, CancellationToken, Func&lt;string,string&gt;, Func&lt;SqlCommand,Task&lt;TResult&gt;&gt;\)](SqlServerBulkExtensions.RunStagedAsync.LRELYRDY8XAYX57FZJL2MS3A.md 'Cat\.Dapper\.SqlServer\.SqlServerBulkExtensions\.RunStagedAsync\<T,TResult\>\(Cat\.Dapper\.Abstractions\.ICatDbSession, System\.Collections\.Generic\.IEnumerable\<T\>, System\.Collections\.Generic\.IReadOnlyList\<Cat\.Dapper\.BulkColumn\>, string, int, System\.Nullable\<int\>, System\.Threading\.CancellationToken, System\.Func\<string,string\>, System\.Func\<SqlCommand,System\.Threading\.Tasks\.Task\<TResult\>\>\)') | |
| [ValidateColumn\(string\)](SqlServerBulkExtensions.ValidateColumn.P0NQH2A7W1LYYKYBO92LSZY54.md 'Cat\.Dapper\.SqlServer\.SqlServerBulkExtensions\.ValidateColumn\(string\)') | |
| [ValidateColumns\(IEnumerable&lt;BulkColumn&gt;\)](SqlServerBulkExtensions.ValidateColumns.JJ1JGBKCGDI8TAU4NM196BQ6E.md 'Cat\.Dapper\.SqlServer\.SqlServerBulkExtensions\.ValidateColumns\(System\.Collections\.Generic\.IEnumerable\<Cat\.Dapper\.BulkColumn\>\)') | |
