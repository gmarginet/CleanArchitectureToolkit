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
  
##### >> [Cat\.Sql\.Cdc Assembly](index.md 'index') >> [Cat\.Sql\.Cdc Namespace](Cat.Sql.Cdc.md 'Cat\.Sql\.Cdc') >> [ICatCdcDatabase Interface](ICatCdcDatabase.md 'Cat\.Sql\.Cdc\.ICatCdcDatabase')

## ICatCdcDatabase\.SavePositionAsync\(string, string, CatCdcPosition, CancellationToken\) Method

Saves the position, only while the owner still holds the claim\.

```csharp
System.Threading.Tasks.Task<bool> SavePositionAsync(string captureInstance, string owner, Cat.Sql.Cdc.CatCdcPosition position, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='Cat.Sql.Cdc.ICatCdcDatabase.SavePositionAsync(string,string,Cat.Sql.Cdc.CatCdcPosition,System.Threading.CancellationToken).captureInstance'></a>

`captureInstance` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='Cat.Sql.Cdc.ICatCdcDatabase.SavePositionAsync(string,string,Cat.Sql.Cdc.CatCdcPosition,System.Threading.CancellationToken).owner'></a>

`owner` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='Cat.Sql.Cdc.ICatCdcDatabase.SavePositionAsync(string,string,Cat.Sql.Cdc.CatCdcPosition,System.Threading.CancellationToken).position'></a>

`position` [CatCdcPosition](CatCdcPosition.md 'Cat\.Sql\.Cdc\.CatCdcPosition')

<a name='Cat.Sql.Cdc.ICatCdcDatabase.SavePositionAsync(string,string,Cat.Sql.Cdc.CatCdcPosition,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
`false` when the owner lost the claim\.