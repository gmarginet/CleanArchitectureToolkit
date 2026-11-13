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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.SQL.CDC](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Sql\.Cdc Assembly](index.md 'index') >> [Cat\.Sql\.Cdc Namespace](Cat.Sql.Cdc.md 'Cat\.Sql\.Cdc') >> [SqlServerCdcDatabase Class](SqlServerCdcDatabase.md 'Cat\.Sql\.Cdc\.SqlServerCdcDatabase')

## SqlServerCdcDatabase\.ReadChangesAsync\(string, CatCdcPosition, byte\[\], int, IReadOnlyList\<string\>, CancellationToken\) Method

```csharp
public System.Threading.Tasks.Task<System.Collections.Generic.IReadOnlyList<Cat.Sql.Cdc.Abstractions.CatChange>> ReadChangesAsync(string captureInstance, Cat.Sql.Cdc.CatCdcPosition after, byte[] toLsn, int batchSize, System.Collections.Generic.IReadOnlyList<string> keyColumns, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='Cat.Sql.Cdc.SqlServerCdcDatabase.ReadChangesAsync(string,Cat.Sql.Cdc.CatCdcPosition,byte[],int,System.Collections.Generic.IReadOnlyList_string_,System.Threading.CancellationToken).captureInstance'></a>

`captureInstance` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='Cat.Sql.Cdc.SqlServerCdcDatabase.ReadChangesAsync(string,Cat.Sql.Cdc.CatCdcPosition,byte[],int,System.Collections.Generic.IReadOnlyList_string_,System.Threading.CancellationToken).after'></a>

`after` [CatCdcPosition](CatCdcPosition.md 'Cat\.Sql\.Cdc\.CatCdcPosition')

<a name='Cat.Sql.Cdc.SqlServerCdcDatabase.ReadChangesAsync(string,Cat.Sql.Cdc.CatCdcPosition,byte[],int,System.Collections.Generic.IReadOnlyList_string_,System.Threading.CancellationToken).toLsn'></a>

`toLsn` [System\.Byte](https://learn.microsoft.com/en-us/dotnet/api/system.byte 'System\.Byte')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

<a name='Cat.Sql.Cdc.SqlServerCdcDatabase.ReadChangesAsync(string,Cat.Sql.Cdc.CatCdcPosition,byte[],int,System.Collections.Generic.IReadOnlyList_string_,System.Threading.CancellationToken).batchSize'></a>

`batchSize` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='Cat.Sql.Cdc.SqlServerCdcDatabase.ReadChangesAsync(string,Cat.Sql.Cdc.CatCdcPosition,byte[],int,System.Collections.Generic.IReadOnlyList_string_,System.Threading.CancellationToken).keyColumns'></a>

`keyColumns` [System\.Collections\.Generic\.IReadOnlyList&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1 'System\.Collections\.Generic\.IReadOnlyList\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1 'System\.Collections\.Generic\.IReadOnlyList\`1')

<a name='Cat.Sql.Cdc.SqlServerCdcDatabase.ReadChangesAsync(string,Cat.Sql.Cdc.CatCdcPosition,byte[],int,System.Collections.Generic.IReadOnlyList_string_,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Collections\.Generic\.IReadOnlyList&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1 'System\.Collections\.Generic\.IReadOnlyList\`1')[CatChange](../../../Cat.Sql.Cdc/namespaces/Cat.Sql.Cdc.Abstractions/CatChange.md 'Cat\.Sql\.Cdc\.Abstractions\.CatChange')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1 'System\.Collections\.Generic\.IReadOnlyList\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')