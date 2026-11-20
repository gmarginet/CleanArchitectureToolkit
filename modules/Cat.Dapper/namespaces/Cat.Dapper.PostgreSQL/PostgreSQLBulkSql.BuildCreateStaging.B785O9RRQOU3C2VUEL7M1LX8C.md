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
  
##### >> [Cat\.Dapper\.PostgreSQL Assembly](index.md 'index') >> [Cat\.Dapper\.PostgreSQL Namespace](Cat.Dapper.PostgreSQL.md 'Cat\.Dapper\.PostgreSQL') >> [PostgreSQLBulkSql Class](PostgreSQLBulkSql.md 'Cat\.Dapper\.PostgreSQL\.PostgreSQLBulkSql')

## PostgreSQLBulkSql\.BuildCreateStaging\(string, string, IEnumerable\<string\>, bool\) Method

An empty temporary table with only the given columns\. The types come from the target table, and no identity or default is copied\.
Inside a transaction the table drops on commit\.

```csharp
internal static string BuildCreateStaging(string staging, string table, System.Collections.Generic.IEnumerable<string> columns, bool dropOnCommit);
```
#### Parameters

<a name='Cat.Dapper.PostgreSQL.PostgreSQLBulkSql.BuildCreateStaging(string,string,System.Collections.Generic.IEnumerable_string_,bool).staging'></a>

`staging` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='Cat.Dapper.PostgreSQL.PostgreSQLBulkSql.BuildCreateStaging(string,string,System.Collections.Generic.IEnumerable_string_,bool).table'></a>

`table` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='Cat.Dapper.PostgreSQL.PostgreSQLBulkSql.BuildCreateStaging(string,string,System.Collections.Generic.IEnumerable_string_,bool).columns'></a>

`columns` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

<a name='Cat.Dapper.PostgreSQL.PostgreSQLBulkSql.BuildCreateStaging(string,string,System.Collections.Generic.IEnumerable_string_,bool).dropOnCommit'></a>

`dropOnCommit` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')