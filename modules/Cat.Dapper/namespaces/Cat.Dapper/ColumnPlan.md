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
  
##### >> [Cat\.Dapper Assembly](index.md 'index') >> [Cat\.Dapper Namespace](Cat.Dapper.md 'Cat\.Dapper')

## ColumnPlan Class

The columns of an update, a delete or a merge: the key columns and the columns to change\.

```csharp
internal sealed class ColumnPlan
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → ColumnPlan

| Constructors | |
| :--- | :--- |
| [ColumnPlan\(IReadOnlyList&lt;BulkColumn&gt;, IReadOnlyList&lt;BulkColumn&gt;\)](ColumnPlan..ctor.FWWREXUT51EHLYDXHUBF2ZQ15.md 'Cat\.Dapper\.ColumnPlan\.ColumnPlan\(System\.Collections\.Generic\.IReadOnlyList\<Cat\.Dapper\.BulkColumn\>, System\.Collections\.Generic\.IReadOnlyList\<Cat\.Dapper\.BulkColumn\>\)') | |

| Properties | |
| :--- | :--- |
| [KeyNames](ColumnPlan.KeyNames.md 'Cat\.Dapper\.ColumnPlan\.KeyNames') | |
| [Keys](ColumnPlan.Keys.md 'Cat\.Dapper\.ColumnPlan\.Keys') | |
| [Update](ColumnPlan.Update.md 'Cat\.Dapper\.ColumnPlan\.Update') | |
| [UpdateNames](ColumnPlan.UpdateNames.md 'Cat\.Dapper\.ColumnPlan\.UpdateNames') | |
