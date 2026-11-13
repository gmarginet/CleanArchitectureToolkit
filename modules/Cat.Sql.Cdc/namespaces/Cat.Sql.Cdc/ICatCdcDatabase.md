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

## ICatCdcDatabase Interface

Everything the reader needs from the database: the change tables, the position and the claim\.

```csharp
internal interface ICatCdcDatabase
```

Derived  
↳ [SqlServerCdcDatabase](SqlServerCdcDatabase.md 'Cat\.Sql\.Cdc\.SqlServerCdcDatabase')

| Methods | |
| :--- | :--- |
| [EnsureCreatedAsync\(string, CancellationToken\)](ICatCdcDatabase.EnsureCreatedAsync.8LPHK254QJCQA1PDL8ZY9YTN1.md 'Cat\.Sql\.Cdc\.ICatCdcDatabase\.EnsureCreatedAsync\(string, System\.Threading\.CancellationToken\)') | Creates the schema and the position table when they are missing, and the row of the capture instance\. |
| [GetKeyColumnsAsync\(string, CancellationToken\)](ICatCdcDatabase.GetKeyColumnsAsync.6GA8992H8RAEFXN1FS843KGK6.md 'Cat\.Sql\.Cdc\.ICatCdcDatabase\.GetKeyColumnsAsync\(string, System\.Threading\.CancellationToken\)') | The key columns of the capture instance, in order\. |
| [GetMaxLsnAsync\(CancellationToken\)](ICatCdcDatabase.GetMaxLsnAsync.7P5NQIJUS9DFNTE8VOM274UU2.md 'Cat\.Sql\.Cdc\.ICatCdcDatabase\.GetMaxLsnAsync\(System\.Threading\.CancellationToken\)') | The newest LSN the capture process has handled, or `null` when it has handled nothing yet\. |
| [GetMinLsnAsync\(string, CancellationToken\)](ICatCdcDatabase.GetMinLsnAsync.J2KE9Y0HBHCEF5W5VLW07WX5E.md 'Cat\.Sql\.Cdc\.ICatCdcDatabase\.GetMinLsnAsync\(string, System\.Threading\.CancellationToken\)') | The oldest LSN that is still in the change table, or `null` when the capture instance does not exist\. |
| [GetPositionAsync\(string, CancellationToken\)](ICatCdcDatabase.GetPositionAsync.DOQ8EHQDN6SFET66J5F8VD529.md 'Cat\.Sql\.Cdc\.ICatCdcDatabase\.GetPositionAsync\(string, System\.Threading\.CancellationToken\)') | |
| [ReadChangesAsync\(string, CatCdcPosition, byte\[\], int, IReadOnlyList&lt;string&gt;, CancellationToken\)](ICatCdcDatabase.ReadChangesAsync.B7JU9537MZZ4ALLFQHUSSBN3E.md 'Cat\.Sql\.Cdc\.ICatCdcDatabase\.ReadChangesAsync\(string, Cat\.Sql\.Cdc\.CatCdcPosition, byte\[\], int, System\.Collections\.Generic\.IReadOnlyList\<string\>, System\.Threading\.CancellationToken\)') | Reads the changes after the position, up to [toLsn](ICatCdcDatabase.ReadChangesAsync.B7JU9537MZZ4ALLFQHUSSBN3E.md#Cat.Sql.Cdc.ICatCdcDatabase.ReadChangesAsync(string,Cat.Sql.Cdc.CatCdcPosition,byte[],int,System.Collections.Generic.IReadOnlyList_string_,System.Threading.CancellationToken).toLsn 'Cat\.Sql\.Cdc\.ICatCdcDatabase\.ReadChangesAsync\(string, Cat\.Sql\.Cdc\.CatCdcPosition, byte\[\], int, System\.Collections\.Generic\.IReadOnlyList\<string\>, System\.Threading\.CancellationToken\)\.toLsn'), with at most [batchSize](ICatCdcDatabase.ReadChangesAsync.B7JU9537MZZ4ALLFQHUSSBN3E.md#Cat.Sql.Cdc.ICatCdcDatabase.ReadChangesAsync(string,Cat.Sql.Cdc.CatCdcPosition,byte[],int,System.Collections.Generic.IReadOnlyList_string_,System.Threading.CancellationToken).batchSize 'Cat\.Sql\.Cdc\.ICatCdcDatabase\.ReadChangesAsync\(string, Cat\.Sql\.Cdc\.CatCdcPosition, byte\[\], int, System\.Collections\.Generic\.IReadOnlyList\<string\>, System\.Threading\.CancellationToken\)\.batchSize') changes\. |
| [SavePositionAsync\(string, string, CatCdcPosition, CancellationToken\)](ICatCdcDatabase.SavePositionAsync.XFIFNRVP2CWJWS48U6RJXI1OE.md 'Cat\.Sql\.Cdc\.ICatCdcDatabase\.SavePositionAsync\(string, string, Cat\.Sql\.Cdc\.CatCdcPosition, System\.Threading\.CancellationToken\)') | Saves the position, only while the owner still holds the claim\. |
| [TryClaimAsync\(string, string, TimeSpan, CancellationToken\)](ICatCdcDatabase.TryClaimAsync.RF66YKBKC5FJKIPM76ZR4LX18.md 'Cat\.Sql\.Cdc\.ICatCdcDatabase\.TryClaimAsync\(string, string, System\.TimeSpan, System\.Threading\.CancellationToken\)') | Takes the table for [owner](ICatCdcDatabase.TryClaimAsync.RF66YKBKC5FJKIPM76ZR4LX18.md#Cat.Sql.Cdc.ICatCdcDatabase.TryClaimAsync(string,string,System.TimeSpan,System.Threading.CancellationToken).owner 'Cat\.Sql\.Cdc\.ICatCdcDatabase\.TryClaimAsync\(string, string, System\.TimeSpan, System\.Threading\.CancellationToken\)\.owner'), or renews the claim it already has\. |
