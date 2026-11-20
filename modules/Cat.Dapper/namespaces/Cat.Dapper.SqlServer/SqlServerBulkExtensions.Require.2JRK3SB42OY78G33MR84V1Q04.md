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
  
##### >> [Cat\.Dapper\.SqlServer Assembly](index.md 'index') >> [Cat\.Dapper\.SqlServer Namespace](Cat.Dapper.SqlServer.md 'Cat\.Dapper\.SqlServer') >> [SqlServerBulkExtensions Class](SqlServerBulkExtensions.md 'Cat\.Dapper\.SqlServer\.SqlServerBulkExtensions')

## SqlServerBulkExtensions\.Require\<T\>\(ICatDbSession, IEnumerable\<T\>, string\) Method

```csharp
private static void Require<T>(Cat.Dapper.Abstractions.ICatDbSession session, System.Collections.Generic.IEnumerable<T> rows, string table);
```
#### Type parameters

<a name='Cat.Dapper.SqlServer.SqlServerBulkExtensions.Require_T_(Cat.Dapper.Abstractions.ICatDbSession,System.Collections.Generic.IEnumerable_T_,string).T'></a>

`T`
#### Parameters

<a name='Cat.Dapper.SqlServer.SqlServerBulkExtensions.Require_T_(Cat.Dapper.Abstractions.ICatDbSession,System.Collections.Generic.IEnumerable_T_,string).session'></a>

`session` [ICatDbSession](../../../Cat.Dapper/namespaces/Cat.Dapper.Abstractions/ICatDbSession.md 'Cat\.Dapper\.Abstractions\.ICatDbSession')

<a name='Cat.Dapper.SqlServer.SqlServerBulkExtensions.Require_T_(Cat.Dapper.Abstractions.ICatDbSession,System.Collections.Generic.IEnumerable_T_,string).rows'></a>

`rows` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[T](SqlServerBulkExtensions.Require.2JRK3SB42OY78G33MR84V1Q04.md#Cat.Dapper.SqlServer.SqlServerBulkExtensions.Require_T_(Cat.Dapper.Abstractions.ICatDbSession,System.Collections.Generic.IEnumerable_T_,string).T 'Cat\.Dapper\.SqlServer\.SqlServerBulkExtensions\.Require\<T\>\(Cat\.Dapper\.Abstractions\.ICatDbSession, System\.Collections\.Generic\.IEnumerable\<T\>, string\)\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

<a name='Cat.Dapper.SqlServer.SqlServerBulkExtensions.Require_T_(Cat.Dapper.Abstractions.ICatDbSession,System.Collections.Generic.IEnumerable_T_,string).table'></a>

`table` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')