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

## BulkColumns Class

Finds the columns of a row class by reflection, once per type, and keeps them\.

```csharp
internal static class BulkColumns
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → BulkColumns

| Constructors | |
| :--- | :--- |
| [BulkColumns\(\)](BulkColumns.BulkColumns().md 'Cat\.Dapper\.BulkColumns\.BulkColumns\(\)') | |

| Fields | |
| :--- | :--- |
| [Cache](BulkColumns.Cache.md 'Cat\.Dapper\.BulkColumns\.Cache') | |

| Methods | |
| :--- | :--- |
| [Build\(Type\)](BulkColumns.Build.SVVGUBTYPP8ABGZQZQCHVOR19.md 'Cat\.Dapper\.BulkColumns\.Build\(System\.Type\)') | |
| [Create\(Type, PropertyInfo\)](BulkColumns.Create.O2W80KRXJ23L66O4G7NDGZ5I2.md 'Cat\.Dapper\.BulkColumns\.Create\(System\.Type, System\.Reflection\.PropertyInfo\)') | |
| [ForType\(Type\)](BulkColumns.ForType.YCO463D3TBVXQJ6QK7L4IZMYA.md 'Cat\.Dapper\.BulkColumns\.ForType\(System\.Type\)') | All public readable instance properties of the type, in declaration order\. |
| [Select\(Type, IEnumerable&lt;string&gt;, string\)](BulkColumns.Select.C6OFSBTLLDV69UMDYPOBYP0JE.md 'Cat\.Dapper\.BulkColumns\.Select\(System\.Type, System\.Collections\.Generic\.IEnumerable\<string\>, string\)') | The columns with the given names, in the order of the names\. All columns when [names](BulkColumns.Select.C6OFSBTLLDV69UMDYPOBYP0JE.md#Cat.Dapper.BulkColumns.Select(System.Type,System.Collections.Generic.IEnumerable_string_,string).names 'Cat\.Dapper\.BulkColumns\.Select\(System\.Type, System\.Collections\.Generic\.IEnumerable\<string\>, string\)\.names') is `null`\. The names match a property name without regard to case\. |
