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

## PostgreSQLBulkSql Class

Builds the SQL text of the bulk operations\. Every table and column name goes through [QuoteName\(string\)](PostgreSQLBulkSql.QuoteName.BTCXSMZ5IG7MGGZ4A39TGZAA1.md 'Cat\.Dapper\.PostgreSQL\.PostgreSQLBulkSql\.QuoteName\(string\)')\.

```csharp
internal static class PostgreSQLBulkSql
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → PostgreSQLBulkSql

| Fields | |
| :--- | :--- |
| [InsertedColumn](PostgreSQLBulkSql.InsertedColumn.md 'Cat\.Dapper\.PostgreSQL\.PostgreSQLBulkSql\.InsertedColumn') | |

| Methods | |
| :--- | :--- |
| [BuildCopy\(string, IEnumerable&lt;string&gt;\)](PostgreSQLBulkSql.BuildCopy.0P05SB6Z6FG5X44VBNFPOSQ83.md 'Cat\.Dapper\.PostgreSQL\.PostgreSQLBulkSql\.BuildCopy\(string, System\.Collections\.Generic\.IEnumerable\<string\>\)') | |
| [BuildCreateStaging\(string, string, IEnumerable&lt;string&gt;, bool\)](PostgreSQLBulkSql.BuildCreateStaging.B785O9RRQOU3C2VUEL7M1LX8C.md 'Cat\.Dapper\.PostgreSQL\.PostgreSQLBulkSql\.BuildCreateStaging\(string, string, System\.Collections\.Generic\.IEnumerable\<string\>, bool\)') | An empty temporary table with only the given columns\. The types come from the target table, and no identity or default is copied\. Inside a transaction the table drops on commit\. |
| [BuildDelete\(string, string, IReadOnlyList&lt;string&gt;\)](PostgreSQLBulkSql.BuildDelete.R7F59FHDYY9Y0BJJKRGFYHB31.md 'Cat\.Dapper\.PostgreSQL\.PostgreSQLBulkSql\.BuildDelete\(string, string, System\.Collections\.Generic\.IReadOnlyList\<string\>\)') | |
| [BuildDropStaging\(string\)](PostgreSQLBulkSql.BuildDropStaging.PZSNOCH0AUISS3SMXUMV51Z97.md 'Cat\.Dapper\.PostgreSQL\.PostgreSQLBulkSql\.BuildDropStaging\(string\)') | |
| [BuildMerge\(string, string, IReadOnlyList&lt;string&gt;, IReadOnlyList&lt;string&gt;, IReadOnlyList&lt;string&gt;\)](PostgreSQLBulkSql.BuildMerge.XOLTJ6XE6Q3XZGPGIAQM476K6.md 'Cat\.Dapper\.PostgreSQL\.PostgreSQLBulkSql\.BuildMerge\(string, string, System\.Collections\.Generic\.IReadOnlyList\<string\>, System\.Collections\.Generic\.IReadOnlyList\<string\>, System\.Collections\.Generic\.IReadOnlyList\<string\>\)') | An insert that updates the row when the keys already exist\. It returns one row for each inserted or updated row, with a flag that says whether the row was inserted\. The key columns need a unique constraint or a unique index\. |
| [BuildUpdate\(string, string, IReadOnlyList&lt;string&gt;, IReadOnlyList&lt;string&gt;\)](PostgreSQLBulkSql.BuildUpdate.R1220O1WDGM5DT4FH8SVRPQU6.md 'Cat\.Dapper\.PostgreSQL\.PostgreSQLBulkSql\.BuildUpdate\(string, string, System\.Collections\.Generic\.IReadOnlyList\<string\>, System\.Collections\.Generic\.IReadOnlyList\<string\>\)') | |
| [ColumnList\(IEnumerable&lt;string&gt;, string\)](PostgreSQLBulkSql.ColumnList.TP0WESOYXYQUXVL4GUGTBAE61.md 'Cat\.Dapper\.PostgreSQL\.PostgreSQLBulkSql\.ColumnList\(System\.Collections\.Generic\.IEnumerable\<string\>, string\)') | |
| [JoinOn\(IEnumerable&lt;string&gt;\)](PostgreSQLBulkSql.JoinOn.IGSVSYMFFV00XRQ9YA0BIRSHD.md 'Cat\.Dapper\.PostgreSQL\.PostgreSQLBulkSql\.JoinOn\(System\.Collections\.Generic\.IEnumerable\<string\>\)') | |
| [NewStagingName\(\)](PostgreSQLBulkSql.NewStagingName().md 'Cat\.Dapper\.PostgreSQL\.PostgreSQLBulkSql\.NewStagingName\(\)') | |
| [QuoteColumn\(string\)](PostgreSQLBulkSql.QuoteColumn.8G9ZBFTZMKL6OKDYQE3UXGGH5.md 'Cat\.Dapper\.PostgreSQL\.PostgreSQLBulkSql\.QuoteColumn\(string\)') | A column name has one part, so a dot is a mistake\. |
| [QuoteName\(string\)](PostgreSQLBulkSql.QuoteName.BTCXSMZ5IG7MGGZ4A39TGZAA1.md 'Cat\.Dapper\.PostgreSQL\.PostgreSQLBulkSql\.QuoteName\(string\)') | Wraps a table or column name in double quotes, exactly as given\. PostgreSQL treats a quoted name as case sensitive\. A table name may have up to three parts, such as `public.Orders`\. |
