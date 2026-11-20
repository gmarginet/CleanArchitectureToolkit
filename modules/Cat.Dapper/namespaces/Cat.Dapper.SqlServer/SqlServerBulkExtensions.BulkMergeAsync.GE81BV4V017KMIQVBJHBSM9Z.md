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

## SqlServerBulkExtensions\.BulkMergeAsync\<T\>\(this ICatDbSession, IEnumerable\<T\>, string, IEnumerable\<string\>, IEnumerable\<string\>, int, Nullable\<int\>, CancellationToken\) Method

Updates the rows that exist and inserts the rows that do not, with one `MERGE` statement that holds `HOLDLOCK`\.
Rows that are missing from the given set are left alone\.

```csharp
public static System.Threading.Tasks.Task<Cat.Dapper.CatBulkMergeResult> BulkMergeAsync<T>(this Cat.Dapper.Abstractions.ICatDbSession session, System.Collections.Generic.IEnumerable<T> rows, string table, System.Collections.Generic.IEnumerable<string> keyColumns, System.Collections.Generic.IEnumerable<string>? updateColumns=null, int batchSize=0, System.Nullable<int> timeoutSeconds=null, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Type parameters

<a name='Cat.Dapper.SqlServer.SqlServerBulkExtensions.BulkMergeAsync_T_(thisCat.Dapper.Abstractions.ICatDbSession,System.Collections.Generic.IEnumerable_T_,string,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,int,System.Nullable_int_,System.Threading.CancellationToken).T'></a>

`T`

The row class\. Its property names are the column names\.
#### Parameters

<a name='Cat.Dapper.SqlServer.SqlServerBulkExtensions.BulkMergeAsync_T_(thisCat.Dapper.Abstractions.ICatDbSession,System.Collections.Generic.IEnumerable_T_,string,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,int,System.Nullable_int_,System.Threading.CancellationToken).session'></a>

`session` [ICatDbSession](../../../Cat.Dapper/namespaces/Cat.Dapper.Abstractions/ICatDbSession.md 'Cat\.Dapper\.Abstractions\.ICatDbSession')

The session to run on\.

<a name='Cat.Dapper.SqlServer.SqlServerBulkExtensions.BulkMergeAsync_T_(thisCat.Dapper.Abstractions.ICatDbSession,System.Collections.Generic.IEnumerable_T_,string,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,int,System.Nullable_int_,System.Threading.CancellationToken).rows'></a>

`rows` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[T](SqlServerBulkExtensions.BulkMergeAsync.GE81BV4V017KMIQVBJHBSM9Z.md#Cat.Dapper.SqlServer.SqlServerBulkExtensions.BulkMergeAsync_T_(thisCat.Dapper.Abstractions.ICatDbSession,System.Collections.Generic.IEnumerable_T_,string,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,int,System.Nullable_int_,System.Threading.CancellationToken).T 'Cat\.Dapper\.SqlServer\.SqlServerBulkExtensions\.BulkMergeAsync\<T\>\(this Cat\.Dapper\.Abstractions\.ICatDbSession, System\.Collections\.Generic\.IEnumerable\<T\>, string, System\.Collections\.Generic\.IEnumerable\<string\>, System\.Collections\.Generic\.IEnumerable\<string\>, int, System\.Nullable\<int\>, System\.Threading\.CancellationToken\)\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The rows to merge\.

<a name='Cat.Dapper.SqlServer.SqlServerBulkExtensions.BulkMergeAsync_T_(thisCat.Dapper.Abstractions.ICatDbSession,System.Collections.Generic.IEnumerable_T_,string,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,int,System.Nullable_int_,System.Threading.CancellationToken).table'></a>

`table` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The target table, such as `dbo.Orders`\.

<a name='Cat.Dapper.SqlServer.SqlServerBulkExtensions.BulkMergeAsync_T_(thisCat.Dapper.Abstractions.ICatDbSession,System.Collections.Generic.IEnumerable_T_,string,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,int,System.Nullable_int_,System.Threading.CancellationToken).keyColumns'></a>

`keyColumns` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The columns that identify a row\.

<a name='Cat.Dapper.SqlServer.SqlServerBulkExtensions.BulkMergeAsync_T_(thisCat.Dapper.Abstractions.ICatDbSession,System.Collections.Generic.IEnumerable_T_,string,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,int,System.Nullable_int_,System.Threading.CancellationToken).updateColumns'></a>

`updateColumns` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The columns to change on a match, or `null` for every property that is not a key column\.

<a name='Cat.Dapper.SqlServer.SqlServerBulkExtensions.BulkMergeAsync_T_(thisCat.Dapper.Abstractions.ICatDbSession,System.Collections.Generic.IEnumerable_T_,string,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,int,System.Nullable_int_,System.Threading.CancellationToken).batchSize'></a>

`batchSize` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of rows in a batch of the copy to the temporary table\. 0 sends them all in one batch\.

<a name='Cat.Dapper.SqlServer.SqlServerBulkExtensions.BulkMergeAsync_T_(thisCat.Dapper.Abstractions.ICatDbSession,System.Collections.Generic.IEnumerable_T_,string,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,int,System.Nullable_int_,System.Threading.CancellationToken).timeoutSeconds'></a>

`timeoutSeconds` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The timeout in seconds, or `null` for the default\. 0 means no timeout\.

<a name='Cat.Dapper.SqlServer.SqlServerBulkExtensions.BulkMergeAsync_T_(thisCat.Dapper.Abstractions.ICatDbSession,System.Collections.Generic.IEnumerable_T_,string,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,int,System.Nullable_int_,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Token to cancel the work\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[CatBulkMergeResult](../../../Cat.Dapper/namespaces/Cat.Dapper/CatBulkMergeResult.md 'Cat\.Dapper\.CatBulkMergeResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The number of inserted and the number of updated rows\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
Thrown when [session](SqlServerBulkExtensions.BulkMergeAsync.GE81BV4V017KMIQVBJHBSM9Z.md#Cat.Dapper.SqlServer.SqlServerBulkExtensions.BulkMergeAsync_T_(thisCat.Dapper.Abstractions.ICatDbSession,System.Collections.Generic.IEnumerable_T_,string,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,int,System.Nullable_int_,System.Threading.CancellationToken).session 'Cat\.Dapper\.SqlServer\.SqlServerBulkExtensions\.BulkMergeAsync\<T\>\(this Cat\.Dapper\.Abstractions\.ICatDbSession, System\.Collections\.Generic\.IEnumerable\<T\>, string, System\.Collections\.Generic\.IEnumerable\<string\>, System\.Collections\.Generic\.IEnumerable\<string\>, int, System\.Nullable\<int\>, System\.Threading\.CancellationToken\)\.session'), [rows](SqlServerBulkExtensions.BulkMergeAsync.GE81BV4V017KMIQVBJHBSM9Z.md#Cat.Dapper.SqlServer.SqlServerBulkExtensions.BulkMergeAsync_T_(thisCat.Dapper.Abstractions.ICatDbSession,System.Collections.Generic.IEnumerable_T_,string,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,int,System.Nullable_int_,System.Threading.CancellationToken).rows 'Cat\.Dapper\.SqlServer\.SqlServerBulkExtensions\.BulkMergeAsync\<T\>\(this Cat\.Dapper\.Abstractions\.ICatDbSession, System\.Collections\.Generic\.IEnumerable\<T\>, string, System\.Collections\.Generic\.IEnumerable\<string\>, System\.Collections\.Generic\.IEnumerable\<string\>, int, System\.Nullable\<int\>, System\.Threading\.CancellationToken\)\.rows'), [table](SqlServerBulkExtensions.BulkMergeAsync.GE81BV4V017KMIQVBJHBSM9Z.md#Cat.Dapper.SqlServer.SqlServerBulkExtensions.BulkMergeAsync_T_(thisCat.Dapper.Abstractions.ICatDbSession,System.Collections.Generic.IEnumerable_T_,string,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,int,System.Nullable_int_,System.Threading.CancellationToken).table 'Cat\.Dapper\.SqlServer\.SqlServerBulkExtensions\.BulkMergeAsync\<T\>\(this Cat\.Dapper\.Abstractions\.ICatDbSession, System\.Collections\.Generic\.IEnumerable\<T\>, string, System\.Collections\.Generic\.IEnumerable\<string\>, System\.Collections\.Generic\.IEnumerable\<string\>, int, System\.Nullable\<int\>, System\.Threading\.CancellationToken\)\.table') or [keyColumns](SqlServerBulkExtensions.BulkMergeAsync.GE81BV4V017KMIQVBJHBSM9Z.md#Cat.Dapper.SqlServer.SqlServerBulkExtensions.BulkMergeAsync_T_(thisCat.Dapper.Abstractions.ICatDbSession,System.Collections.Generic.IEnumerable_T_,string,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,int,System.Nullable_int_,System.Threading.CancellationToken).keyColumns 'Cat\.Dapper\.SqlServer\.SqlServerBulkExtensions\.BulkMergeAsync\<T\>\(this Cat\.Dapper\.Abstractions\.ICatDbSession, System\.Collections\.Generic\.IEnumerable\<T\>, string, System\.Collections\.Generic\.IEnumerable\<string\>, System\.Collections\.Generic\.IEnumerable\<string\>, int, System\.Nullable\<int\>, System\.Threading\.CancellationToken\)\.keyColumns') is `null`\.

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
Thrown when a name is not valid or a column has no property\.

### Remarks
Every public property of the row class is a column that is inserted\. A key column that is an identity column needs `IDENTITY_INSERT`, so give the key values yourself, such as a `Guid`\.