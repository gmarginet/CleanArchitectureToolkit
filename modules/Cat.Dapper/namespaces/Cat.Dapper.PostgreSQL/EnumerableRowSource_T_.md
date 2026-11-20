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

## EnumerableRowSource\<T\> Class

Rows from a list of objects, read through the columns of the row class\.

```csharp
internal sealed class EnumerableRowSource<T> : Cat.Dapper.PostgreSQL.BulkRowSource
```
#### Type parameters

<a name='Cat.Dapper.PostgreSQL.EnumerableRowSource_T_.T'></a>

`T`

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [BulkRowSource](BulkRowSource.md 'Cat\.Dapper\.PostgreSQL\.BulkRowSource') → EnumerableRowSource\<T\>

| Constructors | |
| :--- | :--- |
| [EnumerableRowSource\(IEnumerable&lt;T&gt;, IReadOnlyList&lt;BulkColumn&gt;\)](EnumerableRowSource_T_..ctor.LKJ66ZZ15UA3TKSTQ09ZDWE09.md 'Cat\.Dapper\.PostgreSQL\.EnumerableRowSource\<T\>\.EnumerableRowSource\(System\.Collections\.Generic\.IEnumerable\<T\>, System\.Collections\.Generic\.IReadOnlyList\<Cat\.Dapper\.BulkColumn\>\)') | |

| Fields | |
| :--- | :--- |
| [\_columns](EnumerableRowSource_T_._columns.md 'Cat\.Dapper\.PostgreSQL\.EnumerableRowSource\<T\>\.\_columns') | |
| [\_rows](EnumerableRowSource_T_._rows.md 'Cat\.Dapper\.PostgreSQL\.EnumerableRowSource\<T\>\.\_rows') | |

| Properties | |
| :--- | :--- |
| [FieldCount](EnumerableRowSource_T_.FieldCount.md 'Cat\.Dapper\.PostgreSQL\.EnumerableRowSource\<T\>\.FieldCount') | |

| Methods | |
| :--- | :--- |
| [Dispose\(\)](EnumerableRowSource_T_.Dispose().md 'Cat\.Dapper\.PostgreSQL\.EnumerableRowSource\<T\>\.Dispose\(\)') | |
| [GetValue\(int\)](EnumerableRowSource_T_.GetValue.92X6FWBUQ2N3AF9GRJ69WLSV6.md 'Cat\.Dapper\.PostgreSQL\.EnumerableRowSource\<T\>\.GetValue\(int\)') | |
| [Read\(\)](EnumerableRowSource_T_.Read().md 'Cat\.Dapper\.PostgreSQL\.EnumerableRowSource\<T\>\.Read\(\)') | |
