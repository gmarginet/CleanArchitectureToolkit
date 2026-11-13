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
  
##### >> [Cat\.Sql\.Cdc Assembly](index.md 'index') >> [Cat\.Sql\.Cdc Namespace](Cat.Sql.Cdc.md 'Cat\.Sql\.Cdc')

## CatCdcRowMapper Class

```csharp
internal static class CatCdcRowMapper
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatCdcRowMapper

| Methods | |
| :--- | :--- |
| [Create\(string, CatCdcRawRow, CatChangeOperation, IReadOnlyDictionary&lt;string,object&gt;, IReadOnlyDictionary&lt;string,object&gt;, IReadOnlyList&lt;string&gt;\)](CatCdcRowMapper.Create.LDTSHUQ455HEWMF3PUNXB79B6.md 'Cat\.Sql\.Cdc\.CatCdcRowMapper\.Create\(string, Cat\.Sql\.Cdc\.CatCdcRawRow, Cat\.Sql\.Cdc\.Abstractions\.CatChangeOperation, System\.Collections\.Generic\.IReadOnlyDictionary\<string,object\>, System\.Collections\.Generic\.IReadOnlyDictionary\<string,object\>, System\.Collections\.Generic\.IReadOnlyList\<string\>\)') | |
| [ToChanges\(string, IReadOnlyList&lt;CatCdcRawRow&gt;, int, IReadOnlyList&lt;string&gt;\)](CatCdcRowMapper.ToChanges.9X5FKGPZMBBMKWXF632RNA7Y9.md 'Cat\.Sql\.Cdc\.CatCdcRowMapper\.ToChanges\(string, System\.Collections\.Generic\.IReadOnlyList\<Cat\.Sql\.Cdc\.CatCdcRawRow\>, int, System\.Collections\.Generic\.IReadOnlyList\<string\>\)') | Turns raw rows, ordered by LSN and sequence value, into changes\. The two rows of an update become one change\. It stops at an update whose second row is missing, so a batch that ends in the middle of one is read again next time\. |
