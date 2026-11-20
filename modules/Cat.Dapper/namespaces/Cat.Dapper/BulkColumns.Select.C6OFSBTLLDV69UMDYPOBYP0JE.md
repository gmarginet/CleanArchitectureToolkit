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
  
##### >> [Cat\.Dapper Assembly](index.md 'index') >> [Cat\.Dapper Namespace](Cat.Dapper.md 'Cat\.Dapper') >> [BulkColumns Class](BulkColumns.md 'Cat\.Dapper\.BulkColumns')

## BulkColumns\.Select\(Type, IEnumerable\<string\>, string\) Method

The columns with the given names, in the order of the names\. All columns when [names](BulkColumns.Select.C6OFSBTLLDV69UMDYPOBYP0JE.md#Cat.Dapper.BulkColumns.Select(System.Type,System.Collections.Generic.IEnumerable_string_,string).names 'Cat\.Dapper\.BulkColumns\.Select\(System\.Type, System\.Collections\.Generic\.IEnumerable\<string\>, string\)\.names') is `null`\.
The names match a property name without regard to case\.

```csharp
internal static System.Collections.Generic.IReadOnlyList<Cat.Dapper.BulkColumn> Select(System.Type type, System.Collections.Generic.IEnumerable<string>? names, string parameterName);
```
#### Parameters

<a name='Cat.Dapper.BulkColumns.Select(System.Type,System.Collections.Generic.IEnumerable_string_,string).type'></a>

`type` [System\.Type](https://learn.microsoft.com/en-us/dotnet/api/system.type 'System\.Type')

<a name='Cat.Dapper.BulkColumns.Select(System.Type,System.Collections.Generic.IEnumerable_string_,string).names'></a>

`names` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

<a name='Cat.Dapper.BulkColumns.Select(System.Type,System.Collections.Generic.IEnumerable_string_,string).parameterName'></a>

`parameterName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

#### Returns
[System\.Collections\.Generic\.IReadOnlyList&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1 'System\.Collections\.Generic\.IReadOnlyList\`1')[BulkColumn](BulkColumn.md 'Cat\.Dapper\.BulkColumn')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1 'System\.Collections\.Generic\.IReadOnlyList\`1')