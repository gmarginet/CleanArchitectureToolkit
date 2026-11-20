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

## PostgreSQLPagingExtensions Class

Paging with plain SQL on PostgreSQL, with the same result as the paging of `Cat.EFCore.Queries`\.

```csharp
public static class PostgreSQLPagingExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → PostgreSQLPagingExtensions

| Fields | |
| :--- | :--- |
| [SkipParameter](PostgreSQLPagingExtensions.SkipParameter.md 'Cat\.Dapper\.PostgreSQL\.PostgreSQLPagingExtensions\.SkipParameter') | |
| [TakeParameter](PostgreSQLPagingExtensions.TakeParameter.md 'Cat\.Dapper\.PostgreSQL\.PostgreSQLPagingExtensions\.TakeParameter') | |

| Methods | |
| :--- | :--- |
| [BuildSql\(string, string\)](PostgreSQLPagingExtensions.BuildSql.Q8L2K6CTVTGTCO9039IA9V9A8.md 'Cat\.Dapper\.PostgreSQL\.PostgreSQLPagingExtensions\.BuildSql\(string, string\)') | |
| [CalculateSkip\(int, int\)](PostgreSQLPagingExtensions.CalculateSkip.UQ0XXGNHB1C8D5CA6VHC11E22.md 'Cat\.Dapper\.PostgreSQL\.PostgreSQLPagingExtensions\.CalculateSkip\(int, int\)') | |
| [QueryPagedAsync&lt;T&gt;\(this ICatDbSession, string, string, int, int, object, CancellationToken\)](PostgreSQLPagingExtensions.QueryPagedAsync.18WEJMPYXTL0BUHYI2VAUT9L7.md 'Cat\.Dapper\.PostgreSQL\.PostgreSQLPagingExtensions\.QueryPagedAsync\<T\>\(this Cat\.Dapper\.Abstractions\.ICatDbSession, string, string, int, int, object, System\.Threading\.CancellationToken\)') | Counts all rows, then reads one page of them, in one round trip to the database\. |
