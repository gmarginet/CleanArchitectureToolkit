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
  
##### >> [Cat\.Sql\.Cdc Assembly](index.md 'index') >> [Cat\.Sql\.Cdc Namespace](Cat.Sql.Cdc.md 'Cat\.Sql\.Cdc') >> [CatCdcService Class](CatCdcService.md 'Cat\.Sql\.Cdc\.CatCdcService')

## CatCdcService\(IReadOnlyList\<CatCdcTable\>, ICatCdcDatabase, ICatChangeSink, CatCdcSettings, CatCdcStatus, ILogger\<CatCdcService\>\) Constructor

```csharp
public CatCdcService(System.Collections.Generic.IReadOnlyList<Cat.Sql.Cdc.CatCdcTable> tables, Cat.Sql.Cdc.ICatCdcDatabase database, Cat.Sql.Cdc.Abstractions.ICatChangeSink sink, Cat.Sql.Cdc.CatCdcSettings settings, Cat.Sql.Cdc.CatCdcStatus status, Microsoft.Extensions.Logging.ILogger<Cat.Sql.Cdc.CatCdcService> logger);
```
#### Parameters

<a name='Cat.Sql.Cdc.CatCdcService.CatCdcService(System.Collections.Generic.IReadOnlyList_Cat.Sql.Cdc.CatCdcTable_,Cat.Sql.Cdc.ICatCdcDatabase,Cat.Sql.Cdc.Abstractions.ICatChangeSink,Cat.Sql.Cdc.CatCdcSettings,Cat.Sql.Cdc.CatCdcStatus,Microsoft.Extensions.Logging.ILogger_Cat.Sql.Cdc.CatCdcService_).tables'></a>

`tables` [System\.Collections\.Generic\.IReadOnlyList&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1 'System\.Collections\.Generic\.IReadOnlyList\`1')[CatCdcTable](CatCdcTable.md 'Cat\.Sql\.Cdc\.CatCdcTable')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1 'System\.Collections\.Generic\.IReadOnlyList\`1')

<a name='Cat.Sql.Cdc.CatCdcService.CatCdcService(System.Collections.Generic.IReadOnlyList_Cat.Sql.Cdc.CatCdcTable_,Cat.Sql.Cdc.ICatCdcDatabase,Cat.Sql.Cdc.Abstractions.ICatChangeSink,Cat.Sql.Cdc.CatCdcSettings,Cat.Sql.Cdc.CatCdcStatus,Microsoft.Extensions.Logging.ILogger_Cat.Sql.Cdc.CatCdcService_).database'></a>

`database` [ICatCdcDatabase](ICatCdcDatabase.md 'Cat\.Sql\.Cdc\.ICatCdcDatabase')

<a name='Cat.Sql.Cdc.CatCdcService.CatCdcService(System.Collections.Generic.IReadOnlyList_Cat.Sql.Cdc.CatCdcTable_,Cat.Sql.Cdc.ICatCdcDatabase,Cat.Sql.Cdc.Abstractions.ICatChangeSink,Cat.Sql.Cdc.CatCdcSettings,Cat.Sql.Cdc.CatCdcStatus,Microsoft.Extensions.Logging.ILogger_Cat.Sql.Cdc.CatCdcService_).sink'></a>

`sink` [ICatChangeSink](../../../Cat.Sql.Cdc/namespaces/Cat.Sql.Cdc.Abstractions/ICatChangeSink.md 'Cat\.Sql\.Cdc\.Abstractions\.ICatChangeSink')

<a name='Cat.Sql.Cdc.CatCdcService.CatCdcService(System.Collections.Generic.IReadOnlyList_Cat.Sql.Cdc.CatCdcTable_,Cat.Sql.Cdc.ICatCdcDatabase,Cat.Sql.Cdc.Abstractions.ICatChangeSink,Cat.Sql.Cdc.CatCdcSettings,Cat.Sql.Cdc.CatCdcStatus,Microsoft.Extensions.Logging.ILogger_Cat.Sql.Cdc.CatCdcService_).settings'></a>

`settings` [CatCdcSettings](CatCdcSettings.md 'Cat\.Sql\.Cdc\.CatCdcSettings')

<a name='Cat.Sql.Cdc.CatCdcService.CatCdcService(System.Collections.Generic.IReadOnlyList_Cat.Sql.Cdc.CatCdcTable_,Cat.Sql.Cdc.ICatCdcDatabase,Cat.Sql.Cdc.Abstractions.ICatChangeSink,Cat.Sql.Cdc.CatCdcSettings,Cat.Sql.Cdc.CatCdcStatus,Microsoft.Extensions.Logging.ILogger_Cat.Sql.Cdc.CatCdcService_).status'></a>

`status` [CatCdcStatus](CatCdcStatus.md 'Cat\.Sql\.Cdc\.CatCdcStatus')

<a name='Cat.Sql.Cdc.CatCdcService.CatCdcService(System.Collections.Generic.IReadOnlyList_Cat.Sql.Cdc.CatCdcTable_,Cat.Sql.Cdc.ICatCdcDatabase,Cat.Sql.Cdc.Abstractions.ICatChangeSink,Cat.Sql.Cdc.CatCdcSettings,Cat.Sql.Cdc.CatCdcStatus,Microsoft.Extensions.Logging.ILogger_Cat.Sql.Cdc.CatCdcService_).logger'></a>

`logger` [Microsoft\.Extensions\.Logging\.ILogger&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')[CatCdcService](CatCdcService.md 'Cat\.Sql\.Cdc\.CatCdcService')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')