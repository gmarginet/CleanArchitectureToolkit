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

## BulkRowSource Class

The rows that go to a `COPY`, one at a time\.

```csharp
internal abstract class BulkRowSource : System.IDisposable
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → BulkRowSource

Derived  
↳ [EnumerableRowSource&lt;T&gt;](EnumerableRowSource_T_.md 'Cat\.Dapper\.PostgreSQL\.EnumerableRowSource\<T\>')  
↳ [ReaderRowSource](ReaderRowSource.md 'Cat\.Dapper\.PostgreSQL\.ReaderRowSource')

Implements [System\.IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable 'System\.IDisposable')

| Properties | |
| :--- | :--- |
| [FieldCount](BulkRowSource.FieldCount.md 'Cat\.Dapper\.PostgreSQL\.BulkRowSource\.FieldCount') | |

| Methods | |
| :--- | :--- |
| [Dispose\(\)](BulkRowSource.Dispose().md 'Cat\.Dapper\.PostgreSQL\.BulkRowSource\.Dispose\(\)') | |
| [GetValue\(int\)](BulkRowSource.GetValue.89XXFC8ZFQJN15CH9XE990F3.md 'Cat\.Dapper\.PostgreSQL\.BulkRowSource\.GetValue\(int\)') | |
| [Read\(\)](BulkRowSource.Read().md 'Cat\.Dapper\.PostgreSQL\.BulkRowSource\.Read\(\)') | Moves to the next row\. False when there are no rows left\. |
