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

## BulkPlan Class

The checks and the column choices that the bulk operations of every database share\.

```csharp
internal static class BulkPlan
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → BulkPlan

| Methods | |
| :--- | :--- |
| [IsEmpty&lt;T&gt;\(IEnumerable&lt;T&gt;\)](BulkPlan.IsEmpty.AKCV9I9IYJDKHDPZ9SH094KK8.md 'Cat\.Dapper\.BulkPlan\.IsEmpty\<T\>\(System\.Collections\.Generic\.IEnumerable\<T\>\)') | True when the rows are a collection that is known to be empty\. An enumerable that cannot tell is never empty here\. |
| [Plan\(Type, IEnumerable&lt;string&gt;, IEnumerable&lt;string&gt;, bool, Action&lt;string&gt;\)](BulkPlan.Plan.9347788T91E29T7O7ITKSZ2S8.md 'Cat\.Dapper\.BulkPlan\.Plan\(System\.Type, System\.Collections\.Generic\.IEnumerable\<string\>, System\.Collections\.Generic\.IEnumerable\<string\>, bool, System\.Action\<string\>\)') | Chooses the key columns and the columns to change\. Every column goes through [validateColumn](BulkPlan.Plan.9347788T91E29T7O7ITKSZ2S8.md#Cat.Dapper.BulkPlan.Plan(System.Type,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,bool,System.Action_string_).validateColumn 'Cat\.Dapper\.BulkPlan\.Plan\(System\.Type, System\.Collections\.Generic\.IEnumerable\<string\>, System\.Collections\.Generic\.IEnumerable\<string\>, bool, System\.Action\<string\>\)\.validateColumn'), which is the check of the database for a name that is safe to put in the SQL text\. |
| [Require&lt;T&gt;\(ICatDbSession, IEnumerable&lt;T&gt;, string\)](BulkPlan.Require.LBA8MFNCTUWOIT6D799MVKAME.md 'Cat\.Dapper\.BulkPlan\.Require\<T\>\(Cat\.Dapper\.Abstractions\.ICatDbSession, System\.Collections\.Generic\.IEnumerable\<T\>, string\)') | |
| [Validate\(IEnumerable&lt;BulkColumn&gt;, Action&lt;string&gt;\)](BulkPlan.Validate.I5AXVRQA83ZYTZ93G111C3KH9.md 'Cat\.Dapper\.BulkPlan\.Validate\(System\.Collections\.Generic\.IEnumerable\<Cat\.Dapper\.BulkColumn\>, System\.Action\<string\>\)') | |
| [ValueColumn&lt;TKey&gt;\(string\)](BulkPlan.ValueColumn.1FM20G3UC8P7Q501MC3ECE238.md 'Cat\.Dapper\.BulkPlan\.ValueColumn\<TKey\>\(string\)') | The column for a list of single values, such as the ids of a bulk delete\. |
