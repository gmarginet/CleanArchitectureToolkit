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

## CatCdcSettings Class

The settings of the reader\. Bind them from the configuration section `CatSqlCdc`\.

```csharp
public class CatCdcSettings
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatCdcSettings

| Fields | |
| :--- | :--- |
| [ConfigurationSectionName](CatCdcSettings.ConfigurationSectionName.md 'Cat\.Sql\.Cdc\.CatCdcSettings\.ConfigurationSectionName') | The name of the configuration section\. |

| Properties | |
| :--- | :--- |
| [BatchSize](CatCdcSettings.BatchSize.md 'Cat\.Sql\.Cdc\.CatCdcSettings\.BatchSize') | The most changes handed to the sink before the position is saved\. The default is 1000\. |
| [ClaimLease](CatCdcSettings.ClaimLease.md 'Cat\.Sql\.Cdc\.CatCdcSettings\.ClaimLease') | How long one instance owns a table after it claimed it\. A running reader renews the claim on every poll\. If the reader dies, another instance takes over when the lease has run out\. The default is 30 seconds\. |
| [ConnectionString](CatCdcSettings.ConnectionString.md 'Cat\.Sql\.Cdc\.CatCdcSettings\.ConnectionString') | The connection string of the captured database\. The module keeps its position in this database too\. |
| [OnRetentionGap](CatCdcSettings.OnRetentionGap.md 'Cat\.Sql\.Cdc\.CatCdcSettings\.OnRetentionGap') | What to do when the position is older than the oldest available change\. The default is [Fail](CatCdcGapBehavior.md#Cat.Sql.Cdc.CatCdcGapBehavior.Fail 'Cat\.Sql\.Cdc\.CatCdcGapBehavior\.Fail')\. |
| [PollInterval](CatCdcSettings.PollInterval.md 'Cat\.Sql\.Cdc\.CatCdcSettings\.PollInterval') | How long the reader waits after a poll that found nothing\. The default is 1 second\. |
| [Schema](CatCdcSettings.Schema.md 'Cat\.Sql\.Cdc\.CatCdcSettings\.Schema') | The schema in the captured database that holds the position table\. The default is `catcdc`\. |
