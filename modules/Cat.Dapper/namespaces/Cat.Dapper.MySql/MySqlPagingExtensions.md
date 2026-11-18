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
  
##### >> [Cat\.Dapper\.MySql Assembly](index.md 'index') >> [Cat\.Dapper\.MySql Namespace](Cat.Dapper.MySql.md 'Cat\.Dapper\.MySql')

## MySqlPagingExtensions Class

Paging with plain SQL on MySQL, with the same result as the paging of `Cat.EFCore.Queries`\.

```csharp
public static class MySqlPagingExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → MySqlPagingExtensions

| Fields | |
| :--- | :--- |
| [SkipParameter](MySqlPagingExtensions.SkipParameter.md 'Cat\.Dapper\.MySql\.MySqlPagingExtensions\.SkipParameter') | |
| [TakeParameter](MySqlPagingExtensions.TakeParameter.md 'Cat\.Dapper\.MySql\.MySqlPagingExtensions\.TakeParameter') | |

| Methods | |
| :--- | :--- |
| [BuildSql\(string, string\)](MySqlPagingExtensions.BuildSql.QSNFF4PJAN4697UBLOWKC71P7.md 'Cat\.Dapper\.MySql\.MySqlPagingExtensions\.BuildSql\(string, string\)') | |
| [CalculateSkip\(int, int\)](MySqlPagingExtensions.CalculateSkip.G8JJC2RCN7M8GGFR3HQ22XUN5.md 'Cat\.Dapper\.MySql\.MySqlPagingExtensions\.CalculateSkip\(int, int\)') | |
| [QueryPagedAsync&lt;T&gt;\(this ICatDbSession, string, string, int, int, object, CancellationToken\)](MySqlPagingExtensions.QueryPagedAsync.LIQWHK08K54GFW3PNLY1LCH6D.md 'Cat\.Dapper\.MySql\.MySqlPagingExtensions\.QueryPagedAsync\<T\>\(this Cat\.Dapper\.Abstractions\.ICatDbSession, string, string, int, int, object, System\.Threading\.CancellationToken\)') | Counts all rows, then reads one page of them, in one round trip to the database\. |
