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

## SqlServerCdcDatabase Class

The SQL Server side of the reader\. It calls the change data capture functions and keeps the position in a table of its own\.
A capture instance name is part of a function name, so it is checked before it goes into the SQL text\.
Every other value goes in as a parameter\.

```csharp
internal sealed class SqlServerCdcDatabase
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → SqlServerCdcDatabase

| Constructors | |
| :--- | :--- |
| [SqlServerCdcDatabase\(CatCdcSettings\)](SqlServerCdcDatabase..ctor.G9A5PAGDSY8VM9CEVDP3JGO62.md 'Cat\.Sql\.Cdc\.SqlServerCdcDatabase\.SqlServerCdcDatabase\(Cat\.Sql\.Cdc\.CatCdcSettings\)') | |

| Fields | |
| :--- | :--- |
| [LsnLength](SqlServerCdcDatabase.LsnLength.md 'Cat\.Sql\.Cdc\.SqlServerCdcDatabase\.LsnLength') | |
| [NamePattern](SqlServerCdcDatabase.NamePattern.md 'Cat\.Sql\.Cdc\.SqlServerCdcDatabase\.NamePattern') | |
| [\_connectionString](SqlServerCdcDatabase._connectionString.md 'Cat\.Sql\.Cdc\.SqlServerCdcDatabase\.\_connectionString') | |
| [\_schema](SqlServerCdcDatabase._schema.md 'Cat\.Sql\.Cdc\.SqlServerCdcDatabase\.\_schema') | |

| Methods | |
| :--- | :--- |
| [BinaryParameter\(string, byte\[\]\)](SqlServerCdcDatabase.BinaryParameter.V7DLTULG5P72UGBG7RBHUSMYD.md 'Cat\.Sql\.Cdc\.SqlServerCdcDatabase\.BinaryParameter\(string, byte\[\]\)') | |
| [EnsureCreatedAsync\(string, CancellationToken\)](SqlServerCdcDatabase.EnsureCreatedAsync.L20U2DDQMOW2OTATFXPUV09B4.md 'Cat\.Sql\.Cdc\.SqlServerCdcDatabase\.EnsureCreatedAsync\(string, System\.Threading\.CancellationToken\)') | |
| [GetKeyColumnsAsync\(string, CancellationToken\)](SqlServerCdcDatabase.GetKeyColumnsAsync.7AEBA3GN5WWEAUJXUXK0C1S3A.md 'Cat\.Sql\.Cdc\.SqlServerCdcDatabase\.GetKeyColumnsAsync\(string, System\.Threading\.CancellationToken\)') | |
| [GetMaxLsnAsync\(CancellationToken\)](SqlServerCdcDatabase.GetMaxLsnAsync.HK2YLEJGJZ9L0VRRGDR031Q15.md 'Cat\.Sql\.Cdc\.SqlServerCdcDatabase\.GetMaxLsnAsync\(System\.Threading\.CancellationToken\)') | |
| [GetMinLsnAsync\(string, CancellationToken\)](SqlServerCdcDatabase.GetMinLsnAsync.V702W0GTPC3ZA0033CD5GK0D.md 'Cat\.Sql\.Cdc\.SqlServerCdcDatabase\.GetMinLsnAsync\(string, System\.Threading\.CancellationToken\)') | |
| [GetPositionAsync\(string, CancellationToken\)](SqlServerCdcDatabase.GetPositionAsync.ZF8RK5DFYG3RBAKV3VGO30FN1.md 'Cat\.Sql\.Cdc\.SqlServerCdcDatabase\.GetPositionAsync\(string, System\.Threading\.CancellationToken\)') | |
| [OpenAsync\(CancellationToken\)](SqlServerCdcDatabase.OpenAsync.L9CHPLNGGE7EUA6YCH77OTUNA.md 'Cat\.Sql\.Cdc\.SqlServerCdcDatabase\.OpenAsync\(System\.Threading\.CancellationToken\)') | |
| [ReadChangesAsync\(string, CatCdcPosition, byte\[\], int, IReadOnlyList&lt;string&gt;, CancellationToken\)](SqlServerCdcDatabase.ReadChangesAsync.6ZCUNAPIO5YPOBKHQ6R7T0QP3.md 'Cat\.Sql\.Cdc\.SqlServerCdcDatabase\.ReadChangesAsync\(string, Cat\.Sql\.Cdc\.CatCdcPosition, byte\[\], int, System\.Collections\.Generic\.IReadOnlyList\<string\>, System\.Threading\.CancellationToken\)') | |
| [SavePositionAsync\(string, string, CatCdcPosition, CancellationToken\)](SqlServerCdcDatabase.SavePositionAsync.W8ZGW0CGVAYT5KPPDZPX2B8SB.md 'Cat\.Sql\.Cdc\.SqlServerCdcDatabase\.SavePositionAsync\(string, string, Cat\.Sql\.Cdc\.CatCdcPosition, System\.Threading\.CancellationToken\)') | |
| [TryClaimAsync\(string, string, TimeSpan, CancellationToken\)](SqlServerCdcDatabase.TryClaimAsync.7TMN9135QJ9Y4HSBY3CNSDIX2.md 'Cat\.Sql\.Cdc\.SqlServerCdcDatabase\.TryClaimAsync\(string, string, System\.TimeSpan, System\.Threading\.CancellationToken\)') | |
