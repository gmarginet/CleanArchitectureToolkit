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

## CatCdcTable Class

One captured table and what its changes become\.

```csharp
public sealed class CatCdcTable
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatCdcTable

| Constructors | |
| :--- | :--- |
| [CatCdcTable\(string, Func&lt;CatChange,object&gt;\)](CatCdcTable..ctor.0U0VDH1TN6F8P6OQ5HH91ADGA.md 'Cat\.Sql\.Cdc\.CatCdcTable\.CatCdcTable\(string, System\.Func\<Cat\.Sql\.Cdc\.Abstractions\.CatChange,object\>\)') | |

| Properties | |
| :--- | :--- |
| [CaptureInstance](CatCdcTable.CaptureInstance.md 'Cat\.Sql\.Cdc\.CatCdcTable\.CaptureInstance') | The name of the capture instance, such as `dbo_BookPrice`\. |
| [Map](CatCdcTable.Map.md 'Cat\.Sql\.Cdc\.CatCdcTable\.Map') | Makes the message of a change\. |
