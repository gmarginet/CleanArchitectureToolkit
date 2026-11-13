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

## CatCdcStatus Class

What the readers report: which table stopped for good, and which one failed on its last poll\.
The health check reads it\.

```csharp
internal sealed class CatCdcStatus
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatCdcStatus

| Fields | |
| :--- | :--- |
| [\_failing](CatCdcStatus._failing.md 'Cat\.Sql\.Cdc\.CatCdcStatus\.\_failing') | |
| [\_stopped](CatCdcStatus._stopped.md 'Cat\.Sql\.Cdc\.CatCdcStatus\.\_stopped') | |

| Properties | |
| :--- | :--- |
| [Failing](CatCdcStatus.Failing.md 'Cat\.Sql\.Cdc\.CatCdcStatus\.Failing') | |
| [FailingDescription](CatCdcStatus.FailingDescription.md 'Cat\.Sql\.Cdc\.CatCdcStatus\.FailingDescription') | |
| [Stopped](CatCdcStatus.Stopped.md 'Cat\.Sql\.Cdc\.CatCdcStatus\.Stopped') | |
| [StoppedDescription](CatCdcStatus.StoppedDescription.md 'Cat\.Sql\.Cdc\.CatCdcStatus\.StoppedDescription') | |

| Methods | |
| :--- | :--- |
| [Fail\(string, Exception\)](CatCdcStatus.Fail.RWKUS9ZA0ZIKQW1HKRGX8L0W8.md 'Cat\.Sql\.Cdc\.CatCdcStatus\.Fail\(string, System\.Exception\)') | |
| [Stop\(string, string\)](CatCdcStatus.Stop.UOJS0Z7KM2WTDHA0WB49VEILD.md 'Cat\.Sql\.Cdc\.CatCdcStatus\.Stop\(string, string\)') | |
| [Succeed\(string\)](CatCdcStatus.Succeed.4E426SMMDZUCHPRPGB9D7FY9E.md 'Cat\.Sql\.Cdc\.CatCdcStatus\.Succeed\(string\)') | |
