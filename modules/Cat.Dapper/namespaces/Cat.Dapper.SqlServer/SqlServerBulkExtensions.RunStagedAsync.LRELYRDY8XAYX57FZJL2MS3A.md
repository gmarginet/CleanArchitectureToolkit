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

## SqlServerBulkExtensions\.RunStagedAsync\<T,TResult\>\(ICatDbSession, IEnumerable\<T\>, IReadOnlyList\<BulkColumn\>, string, int, Nullable\<int\>, CancellationToken, Func\<string,string\>, Func\<SqlCommand,Task\<TResult\>\>\) Method

```csharp
private static System.Threading.Tasks.Task<TResult> RunStagedAsync<T,TResult>(Cat.Dapper.Abstractions.ICatDbSession session, System.Collections.Generic.IEnumerable<T> rows, System.Collections.Generic.IReadOnlyList<Cat.Dapper.BulkColumn> stagedColumns, string table, int batchSize, System.Nullable<int> timeoutSeconds, System.Threading.CancellationToken cancellationToken, System.Func<string,string> buildStatement, System.Func<SqlCommand,System.Threading.Tasks.Task<TResult>> execute);
```
#### Type parameters

<a name='Cat.Dapper.SqlServer.SqlServerBulkExtensions.RunStagedAsync_T,TResult_(Cat.Dapper.Abstractions.ICatDbSession,System.Collections.Generic.IEnumerable_T_,System.Collections.Generic.IReadOnlyList_Cat.Dapper.BulkColumn_,string,int,System.Nullable_int_,System.Threading.CancellationToken,System.Func_string,string_,System.Func_SqlCommand,System.Threading.Tasks.Task_TResult__).T'></a>

`T`

<a name='Cat.Dapper.SqlServer.SqlServerBulkExtensions.RunStagedAsync_T,TResult_(Cat.Dapper.Abstractions.ICatDbSession,System.Collections.Generic.IEnumerable_T_,System.Collections.Generic.IReadOnlyList_Cat.Dapper.BulkColumn_,string,int,System.Nullable_int_,System.Threading.CancellationToken,System.Func_string,string_,System.Func_SqlCommand,System.Threading.Tasks.Task_TResult__).TResult'></a>

`TResult`
#### Parameters

<a name='Cat.Dapper.SqlServer.SqlServerBulkExtensions.RunStagedAsync_T,TResult_(Cat.Dapper.Abstractions.ICatDbSession,System.Collections.Generic.IEnumerable_T_,System.Collections.Generic.IReadOnlyList_Cat.Dapper.BulkColumn_,string,int,System.Nullable_int_,System.Threading.CancellationToken,System.Func_string,string_,System.Func_SqlCommand,System.Threading.Tasks.Task_TResult__).session'></a>

`session` [ICatDbSession](../../../Cat.Dapper/namespaces/Cat.Dapper.Abstractions/ICatDbSession.md 'Cat\.Dapper\.Abstractions\.ICatDbSession')

<a name='Cat.Dapper.SqlServer.SqlServerBulkExtensions.RunStagedAsync_T,TResult_(Cat.Dapper.Abstractions.ICatDbSession,System.Collections.Generic.IEnumerable_T_,System.Collections.Generic.IReadOnlyList_Cat.Dapper.BulkColumn_,string,int,System.Nullable_int_,System.Threading.CancellationToken,System.Func_string,string_,System.Func_SqlCommand,System.Threading.Tasks.Task_TResult__).rows'></a>

`rows` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[T](SqlServerBulkExtensions.RunStagedAsync.LRELYRDY8XAYX57FZJL2MS3A.md#Cat.Dapper.SqlServer.SqlServerBulkExtensions.RunStagedAsync_T,TResult_(Cat.Dapper.Abstractions.ICatDbSession,System.Collections.Generic.IEnumerable_T_,System.Collections.Generic.IReadOnlyList_Cat.Dapper.BulkColumn_,string,int,System.Nullable_int_,System.Threading.CancellationToken,System.Func_string,string_,System.Func_SqlCommand,System.Threading.Tasks.Task_TResult__).T 'Cat\.Dapper\.SqlServer\.SqlServerBulkExtensions\.RunStagedAsync\<T,TResult\>\(Cat\.Dapper\.Abstractions\.ICatDbSession, System\.Collections\.Generic\.IEnumerable\<T\>, System\.Collections\.Generic\.IReadOnlyList\<Cat\.Dapper\.BulkColumn\>, string, int, System\.Nullable\<int\>, System\.Threading\.CancellationToken, System\.Func\<string,string\>, System\.Func\<SqlCommand,System\.Threading\.Tasks\.Task\<TResult\>\>\)\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

<a name='Cat.Dapper.SqlServer.SqlServerBulkExtensions.RunStagedAsync_T,TResult_(Cat.Dapper.Abstractions.ICatDbSession,System.Collections.Generic.IEnumerable_T_,System.Collections.Generic.IReadOnlyList_Cat.Dapper.BulkColumn_,string,int,System.Nullable_int_,System.Threading.CancellationToken,System.Func_string,string_,System.Func_SqlCommand,System.Threading.Tasks.Task_TResult__).stagedColumns'></a>

`stagedColumns` [System\.Collections\.Generic\.IReadOnlyList&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1 'System\.Collections\.Generic\.IReadOnlyList\`1')[BulkColumn](../../../Cat.Dapper/namespaces/Cat.Dapper/BulkColumn.md 'Cat\.Dapper\.BulkColumn')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1 'System\.Collections\.Generic\.IReadOnlyList\`1')

<a name='Cat.Dapper.SqlServer.SqlServerBulkExtensions.RunStagedAsync_T,TResult_(Cat.Dapper.Abstractions.ICatDbSession,System.Collections.Generic.IEnumerable_T_,System.Collections.Generic.IReadOnlyList_Cat.Dapper.BulkColumn_,string,int,System.Nullable_int_,System.Threading.CancellationToken,System.Func_string,string_,System.Func_SqlCommand,System.Threading.Tasks.Task_TResult__).table'></a>

`table` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='Cat.Dapper.SqlServer.SqlServerBulkExtensions.RunStagedAsync_T,TResult_(Cat.Dapper.Abstractions.ICatDbSession,System.Collections.Generic.IEnumerable_T_,System.Collections.Generic.IReadOnlyList_Cat.Dapper.BulkColumn_,string,int,System.Nullable_int_,System.Threading.CancellationToken,System.Func_string,string_,System.Func_SqlCommand,System.Threading.Tasks.Task_TResult__).batchSize'></a>

`batchSize` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='Cat.Dapper.SqlServer.SqlServerBulkExtensions.RunStagedAsync_T,TResult_(Cat.Dapper.Abstractions.ICatDbSession,System.Collections.Generic.IEnumerable_T_,System.Collections.Generic.IReadOnlyList_Cat.Dapper.BulkColumn_,string,int,System.Nullable_int_,System.Threading.CancellationToken,System.Func_string,string_,System.Func_SqlCommand,System.Threading.Tasks.Task_TResult__).timeoutSeconds'></a>

`timeoutSeconds` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='Cat.Dapper.SqlServer.SqlServerBulkExtensions.RunStagedAsync_T,TResult_(Cat.Dapper.Abstractions.ICatDbSession,System.Collections.Generic.IEnumerable_T_,System.Collections.Generic.IReadOnlyList_Cat.Dapper.BulkColumn_,string,int,System.Nullable_int_,System.Threading.CancellationToken,System.Func_string,string_,System.Func_SqlCommand,System.Threading.Tasks.Task_TResult__).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

<a name='Cat.Dapper.SqlServer.SqlServerBulkExtensions.RunStagedAsync_T,TResult_(Cat.Dapper.Abstractions.ICatDbSession,System.Collections.Generic.IEnumerable_T_,System.Collections.Generic.IReadOnlyList_Cat.Dapper.BulkColumn_,string,int,System.Nullable_int_,System.Threading.CancellationToken,System.Func_string,string_,System.Func_SqlCommand,System.Threading.Tasks.Task_TResult__).buildStatement'></a>

`buildStatement` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

<a name='Cat.Dapper.SqlServer.SqlServerBulkExtensions.RunStagedAsync_T,TResult_(Cat.Dapper.Abstractions.ICatDbSession,System.Collections.Generic.IEnumerable_T_,System.Collections.Generic.IReadOnlyList_Cat.Dapper.BulkColumn_,string,int,System.Nullable_int_,System.Threading.CancellationToken,System.Func_string,string_,System.Func_SqlCommand,System.Threading.Tasks.Task_TResult__).execute'></a>

`execute` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[Microsoft\.Data\.SqlClient\.SqlCommand](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlcommand 'Microsoft\.Data\.SqlClient\.SqlCommand')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[TResult](SqlServerBulkExtensions.RunStagedAsync.LRELYRDY8XAYX57FZJL2MS3A.md#Cat.Dapper.SqlServer.SqlServerBulkExtensions.RunStagedAsync_T,TResult_(Cat.Dapper.Abstractions.ICatDbSession,System.Collections.Generic.IEnumerable_T_,System.Collections.Generic.IReadOnlyList_Cat.Dapper.BulkColumn_,string,int,System.Nullable_int_,System.Threading.CancellationToken,System.Func_string,string_,System.Func_SqlCommand,System.Threading.Tasks.Task_TResult__).TResult 'Cat\.Dapper\.SqlServer\.SqlServerBulkExtensions\.RunStagedAsync\<T,TResult\>\(Cat\.Dapper\.Abstractions\.ICatDbSession, System\.Collections\.Generic\.IEnumerable\<T\>, System\.Collections\.Generic\.IReadOnlyList\<Cat\.Dapper\.BulkColumn\>, string, int, System\.Nullable\<int\>, System\.Threading\.CancellationToken, System\.Func\<string,string\>, System\.Func\<SqlCommand,System\.Threading\.Tasks\.Task\<TResult\>\>\)\.TResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[TResult](SqlServerBulkExtensions.RunStagedAsync.LRELYRDY8XAYX57FZJL2MS3A.md#Cat.Dapper.SqlServer.SqlServerBulkExtensions.RunStagedAsync_T,TResult_(Cat.Dapper.Abstractions.ICatDbSession,System.Collections.Generic.IEnumerable_T_,System.Collections.Generic.IReadOnlyList_Cat.Dapper.BulkColumn_,string,int,System.Nullable_int_,System.Threading.CancellationToken,System.Func_string,string_,System.Func_SqlCommand,System.Threading.Tasks.Task_TResult__).TResult 'Cat\.Dapper\.SqlServer\.SqlServerBulkExtensions\.RunStagedAsync\<T,TResult\>\(Cat\.Dapper\.Abstractions\.ICatDbSession, System\.Collections\.Generic\.IEnumerable\<T\>, System\.Collections\.Generic\.IReadOnlyList\<Cat\.Dapper\.BulkColumn\>, string, int, System\.Nullable\<int\>, System\.Threading\.CancellationToken, System\.Func\<string,string\>, System\.Func\<SqlCommand,System\.Threading\.Tasks\.Task\<TResult\>\>\)\.TResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')