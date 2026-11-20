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

## SqlServerBulkSql Class

Builds the SQL text of the bulk operations\. Every table and column name goes through [QuoteName\(string\)](SqlServerBulkSql.QuoteName.YWQRMXMN2RQ1R9COJGRX9YWU9.md 'Cat\.Dapper\.SqlServer\.SqlServerBulkSql\.QuoteName\(string\)')\.

```csharp
internal static class SqlServerBulkSql
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → SqlServerBulkSql

| Fields | |
| :--- | :--- |
| [ActionColumn](SqlServerBulkSql.ActionColumn.md 'Cat\.Dapper\.SqlServer\.SqlServerBulkSql\.ActionColumn') | |

| Methods | |
| :--- | :--- |
| [BuildCreateStaging\(string, string, IEnumerable&lt;string&gt;\)](SqlServerBulkSql.BuildCreateStaging.2IU62K1XU522LJIWZ9JGLBPEE.md 'Cat\.Dapper\.SqlServer\.SqlServerBulkSql\.BuildCreateStaging\(string, string, System\.Collections\.Generic\.IEnumerable\<string\>\)') | An empty copy of the target with only the given columns\. The types come from the target table\. |
| [BuildDelete\(string, string, IReadOnlyList&lt;string&gt;\)](SqlServerBulkSql.BuildDelete.J3TATM06B4SI8I3Y2Q1GCS4G9.md 'Cat\.Dapper\.SqlServer\.SqlServerBulkSql\.BuildDelete\(string, string, System\.Collections\.Generic\.IReadOnlyList\<string\>\)') | |
| [BuildDropStaging\(string\)](SqlServerBulkSql.BuildDropStaging.PHXJNV51OQV12MFYLCSHE0N83.md 'Cat\.Dapper\.SqlServer\.SqlServerBulkSql\.BuildDropStaging\(string\)') | |
| [BuildMerge\(string, string, IReadOnlyList&lt;string&gt;, IReadOnlyList&lt;string&gt;, IReadOnlyList&lt;string&gt;\)](SqlServerBulkSql.BuildMerge.77C127N278O9QOXSVG68A0VN4.md 'Cat\.Dapper\.SqlServer\.SqlServerBulkSql\.BuildMerge\(string, string, System\.Collections\.Generic\.IReadOnlyList\<string\>, System\.Collections\.Generic\.IReadOnlyList\<string\>, System\.Collections\.Generic\.IReadOnlyList\<string\>\)') | |
| [BuildUpdate\(string, string, IReadOnlyList&lt;string&gt;, IReadOnlyList&lt;string&gt;\)](SqlServerBulkSql.BuildUpdate.0EBP7WKH8J4D8RE0D34T4NTH9.md 'Cat\.Dapper\.SqlServer\.SqlServerBulkSql\.BuildUpdate\(string, string, System\.Collections\.Generic\.IReadOnlyList\<string\>, System\.Collections\.Generic\.IReadOnlyList\<string\>\)') | |
| [ColumnList\(IEnumerable&lt;string&gt;, string\)](SqlServerBulkSql.ColumnList.JGDY9QQK8V2QOO3JIXO0BQE5A.md 'Cat\.Dapper\.SqlServer\.SqlServerBulkSql\.ColumnList\(System\.Collections\.Generic\.IEnumerable\<string\>, string\)') | |
| [JoinOn\(IEnumerable&lt;string&gt;\)](SqlServerBulkSql.JoinOn.TGNW1BBBELKDNZXZIJ2ONJQKC.md 'Cat\.Dapper\.SqlServer\.SqlServerBulkSql\.JoinOn\(System\.Collections\.Generic\.IEnumerable\<string\>\)') | |
| [NewStagingName\(\)](SqlServerBulkSql.NewStagingName().md 'Cat\.Dapper\.SqlServer\.SqlServerBulkSql\.NewStagingName\(\)') | |
| [QuoteColumn\(string\)](SqlServerBulkSql.QuoteColumn.V2EY4WZ39PU5E5YDE37DU4JH2.md 'Cat\.Dapper\.SqlServer\.SqlServerBulkSql\.QuoteColumn\(string\)') | A column name has one part, so a dot is a mistake\. |
| [QuoteName\(string\)](SqlServerBulkSql.QuoteName.YWQRMXMN2RQ1R9COJGRX9YWU9.md 'Cat\.Dapper\.SqlServer\.SqlServerBulkSql\.QuoteName\(string\)') | Wraps a table or column name in brackets\. A table name may have up to four parts, such as `dbo.Orders`\. |
