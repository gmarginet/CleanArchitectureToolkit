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

## CatCdcService Class

The hosted service\. It runs one loop for every captured table\.

```csharp
internal sealed class CatCdcService : Microsoft.Extensions.Hosting.BackgroundService
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [Microsoft\.Extensions\.Hosting\.BackgroundService](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.hosting.backgroundservice 'Microsoft\.Extensions\.Hosting\.BackgroundService') → CatCdcService

| Constructors | |
| :--- | :--- |
| [CatCdcService\(IReadOnlyList&lt;CatCdcTable&gt;, ICatCdcDatabase, ICatChangeSink, CatCdcSettings, CatCdcStatus, ILogger&lt;CatCdcService&gt;\)](CatCdcService..ctor.V7397PQLYZ0VMXXXMYK4A2QKE.md 'Cat\.Sql\.Cdc\.CatCdcService\.CatCdcService\(System\.Collections\.Generic\.IReadOnlyList\<Cat\.Sql\.Cdc\.CatCdcTable\>, Cat\.Sql\.Cdc\.ICatCdcDatabase, Cat\.Sql\.Cdc\.Abstractions\.ICatChangeSink, Cat\.Sql\.Cdc\.CatCdcSettings, Cat\.Sql\.Cdc\.CatCdcStatus, Microsoft\.Extensions\.Logging\.ILogger\<Cat\.Sql\.Cdc\.CatCdcService\>\)') | |

| Fields | |
| :--- | :--- |
| [\_database](CatCdcService._database.md 'Cat\.Sql\.Cdc\.CatCdcService\.\_database') | |
| [\_logger](CatCdcService._logger.md 'Cat\.Sql\.Cdc\.CatCdcService\.\_logger') | |
| [\_owner](CatCdcService._owner.md 'Cat\.Sql\.Cdc\.CatCdcService\.\_owner') | |
| [\_settings](CatCdcService._settings.md 'Cat\.Sql\.Cdc\.CatCdcService\.\_settings') | |
| [\_sink](CatCdcService._sink.md 'Cat\.Sql\.Cdc\.CatCdcService\.\_sink') | |
| [\_status](CatCdcService._status.md 'Cat\.Sql\.Cdc\.CatCdcService\.\_status') | |
| [\_tables](CatCdcService._tables.md 'Cat\.Sql\.Cdc\.CatCdcService\.\_tables') | |

| Methods | |
| :--- | :--- |
| [ExecuteAsync\(CancellationToken\)](CatCdcService.ExecuteAsync.FT9AU6UP1EXPCXPZWDG0BUKE2.md 'Cat\.Sql\.Cdc\.CatCdcService\.ExecuteAsync\(System\.Threading\.CancellationToken\)') | |
| [RunLoopAsync\(CatCdcTableReader, CancellationToken\)](CatCdcService.RunLoopAsync.XPXVLZYRD2DAZG1N2XHI8SWYD.md 'Cat\.Sql\.Cdc\.CatCdcService\.RunLoopAsync\(Cat\.Sql\.Cdc\.CatCdcTableReader, System\.Threading\.CancellationToken\)') | |
