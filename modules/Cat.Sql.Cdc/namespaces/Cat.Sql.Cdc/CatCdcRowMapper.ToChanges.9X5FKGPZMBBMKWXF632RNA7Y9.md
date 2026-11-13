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
  
##### >> [Cat\.Sql\.Cdc Assembly](index.md 'index') >> [Cat\.Sql\.Cdc Namespace](Cat.Sql.Cdc.md 'Cat\.Sql\.Cdc') >> [CatCdcRowMapper Class](CatCdcRowMapper.md 'Cat\.Sql\.Cdc\.CatCdcRowMapper')

## CatCdcRowMapper\.ToChanges\(string, IReadOnlyList\<CatCdcRawRow\>, int, IReadOnlyList\<string\>\) Method

Turns raw rows, ordered by LSN and sequence value, into changes\. The two rows of an update become one change\.
It stops at an update whose second row is missing, so a batch that ends in the middle of one is read again next time\.

```csharp
public static System.Collections.Generic.IReadOnlyList<Cat.Sql.Cdc.Abstractions.CatChange> ToChanges(string table, System.Collections.Generic.IReadOnlyList<Cat.Sql.Cdc.CatCdcRawRow> rows, int batchSize, System.Collections.Generic.IReadOnlyList<string> keyColumns);
```
#### Parameters

<a name='Cat.Sql.Cdc.CatCdcRowMapper.ToChanges(string,System.Collections.Generic.IReadOnlyList_Cat.Sql.Cdc.CatCdcRawRow_,int,System.Collections.Generic.IReadOnlyList_string_).table'></a>

`table` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='Cat.Sql.Cdc.CatCdcRowMapper.ToChanges(string,System.Collections.Generic.IReadOnlyList_Cat.Sql.Cdc.CatCdcRawRow_,int,System.Collections.Generic.IReadOnlyList_string_).rows'></a>

`rows` [System\.Collections\.Generic\.IReadOnlyList&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1 'System\.Collections\.Generic\.IReadOnlyList\`1')[CatCdcRawRow](CatCdcRawRow.md 'Cat\.Sql\.Cdc\.CatCdcRawRow')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1 'System\.Collections\.Generic\.IReadOnlyList\`1')

<a name='Cat.Sql.Cdc.CatCdcRowMapper.ToChanges(string,System.Collections.Generic.IReadOnlyList_Cat.Sql.Cdc.CatCdcRawRow_,int,System.Collections.Generic.IReadOnlyList_string_).batchSize'></a>

`batchSize` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='Cat.Sql.Cdc.CatCdcRowMapper.ToChanges(string,System.Collections.Generic.IReadOnlyList_Cat.Sql.Cdc.CatCdcRawRow_,int,System.Collections.Generic.IReadOnlyList_string_).keyColumns'></a>

`keyColumns` [System\.Collections\.Generic\.IReadOnlyList&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1 'System\.Collections\.Generic\.IReadOnlyList\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1 'System\.Collections\.Generic\.IReadOnlyList\`1')

#### Returns
[System\.Collections\.Generic\.IReadOnlyList&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1 'System\.Collections\.Generic\.IReadOnlyList\`1')[CatChange](../../../Cat.Sql.Cdc/namespaces/Cat.Sql.Cdc.Abstractions/CatChange.md 'Cat\.Sql\.Cdc\.Abstractions\.CatChange')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1 'System\.Collections\.Generic\.IReadOnlyList\`1')