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

## CatCdcPosition Class

The place the reader has come to: everything up to and including this LSN and sequence value is handed over\.
A `null` sequence value means the whole LSN is still to be read\.

```csharp
internal sealed record CatCdcPosition : System.IEquatable<Cat.Sql.Cdc.CatCdcPosition>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatCdcPosition

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[CatCdcPosition](CatCdcPosition.md 'Cat\.Sql\.Cdc\.CatCdcPosition')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [CatCdcPosition\(byte\[\], byte\[\]\)](CatCdcPosition..ctor.KBT0NBEPJCE2EWAVHTQ7AHQL3.md 'Cat\.Sql\.Cdc\.CatCdcPosition\.CatCdcPosition\(byte\[\], byte\[\]\)') | The place the reader has come to: everything up to and including this LSN and sequence value is handed over\. A `null` sequence value means the whole LSN is still to be read\. |

| Properties | |
| :--- | :--- |
| [Lsn](CatCdcPosition.Lsn.md 'Cat\.Sql\.Cdc\.CatCdcPosition\.Lsn') | |
| [SequenceValue](CatCdcPosition.SequenceValue.md 'Cat\.Sql\.Cdc\.CatCdcPosition\.SequenceValue') | |
