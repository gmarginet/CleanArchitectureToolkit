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
  
##### >> [Cat\.Dapper\.SqlServer Assembly](index.md 'index') >> [Cat\.Dapper\.SqlServer Namespace](Cat.Dapper.SqlServer.md 'Cat\.Dapper\.SqlServer')

## BulkDataReader\<T\> Class

Streams the rows of an enumerable to `SqlBulkCopy` one at a time, so the rows are never copied into a table in memory\.

```csharp
internal sealed class BulkDataReader<T> : System.Data.Common.DbDataReader
```
#### Type parameters

<a name='Cat.Dapper.SqlServer.BulkDataReader_T_.T'></a>

`T`

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [System\.MarshalByRefObject](https://learn.microsoft.com/en-us/dotnet/api/system.marshalbyrefobject 'System\.MarshalByRefObject') → [System\.Data\.Common\.DbDataReader](https://learn.microsoft.com/en-us/dotnet/api/system.data.common.dbdatareader 'System\.Data\.Common\.DbDataReader') → BulkDataReader\<T\>

| Constructors | |
| :--- | :--- |
| [BulkDataReader\(IEnumerable&lt;T&gt;, IReadOnlyList&lt;BulkColumn&gt;\)](BulkDataReader_T_..ctor.CQECQUQW9OTQZ4Q4PLQZNHYC9.md 'Cat\.Dapper\.SqlServer\.BulkDataReader\<T\>\.BulkDataReader\(System\.Collections\.Generic\.IEnumerable\<T\>, System\.Collections\.Generic\.IReadOnlyList\<Cat\.Dapper\.BulkColumn\>\)') | |

| Fields | |
| :--- | :--- |
| [\_closed](BulkDataReader_T_._closed.md 'Cat\.Dapper\.SqlServer\.BulkDataReader\<T\>\.\_closed') | |
| [\_columns](BulkDataReader_T_._columns.md 'Cat\.Dapper\.SqlServer\.BulkDataReader\<T\>\.\_columns') | |
| [\_rows](BulkDataReader_T_._rows.md 'Cat\.Dapper\.SqlServer\.BulkDataReader\<T\>\.\_rows') | |

| Properties | |
| :--- | :--- |
| [Depth](BulkDataReader_T_.Depth.md 'Cat\.Dapper\.SqlServer\.BulkDataReader\<T\>\.Depth') | |
| [FieldCount](BulkDataReader_T_.FieldCount.md 'Cat\.Dapper\.SqlServer\.BulkDataReader\<T\>\.FieldCount') | |
| [HasRows](BulkDataReader_T_.HasRows.md 'Cat\.Dapper\.SqlServer\.BulkDataReader\<T\>\.HasRows') | |
| [IsClosed](BulkDataReader_T_.IsClosed.md 'Cat\.Dapper\.SqlServer\.BulkDataReader\<T\>\.IsClosed') | |
| [RecordsAffected](BulkDataReader_T_.RecordsAffected.md 'Cat\.Dapper\.SqlServer\.BulkDataReader\<T\>\.RecordsAffected') | |
| [RowCount](BulkDataReader_T_.RowCount.md 'Cat\.Dapper\.SqlServer\.BulkDataReader\<T\>\.RowCount') | The number of rows that were read so far\. |
| [this\[int\]](BulkDataReader_T_.Item.MYDQOVV1WHG51S1MMVYSVY5L8.md 'Cat\.Dapper\.SqlServer\.BulkDataReader\<T\>\.this\[int\]') | |
| [this\[string\]](BulkDataReader_T_.Item.IMA3O31ATKIQUWMHQK3CVGO4F.md 'Cat\.Dapper\.SqlServer\.BulkDataReader\<T\>\.this\[string\]') | |

| Methods | |
| :--- | :--- |
| [Close\(\)](BulkDataReader_T_.Close().md 'Cat\.Dapper\.SqlServer\.BulkDataReader\<T\>\.Close\(\)') | |
| [Dispose\(bool\)](BulkDataReader_T_.Dispose.QEP8Q4UHF7ARH9S9YJK8UCY6.md 'Cat\.Dapper\.SqlServer\.BulkDataReader\<T\>\.Dispose\(bool\)') | |
| [GetBoolean\(int\)](BulkDataReader_T_.GetBoolean.BS5W3RWZQCVY0G9S4ZHZDRQS5.md 'Cat\.Dapper\.SqlServer\.BulkDataReader\<T\>\.GetBoolean\(int\)') | |
| [GetByte\(int\)](BulkDataReader_T_.GetByte.RD465E1G1CI6D6OHXOVTWNQF3.md 'Cat\.Dapper\.SqlServer\.BulkDataReader\<T\>\.GetByte\(int\)') | |
| [GetBytes\(int, long, byte\[\], int, int\)](BulkDataReader_T_.GetBytes.17W1CIUL87R399UQVYASRQ373.md 'Cat\.Dapper\.SqlServer\.BulkDataReader\<T\>\.GetBytes\(int, long, byte\[\], int, int\)') | |
| [GetChar\(int\)](BulkDataReader_T_.GetChar.YEL2WIN8VVOSCRADZZ5PZN53B.md 'Cat\.Dapper\.SqlServer\.BulkDataReader\<T\>\.GetChar\(int\)') | |
| [GetChars\(int, long, char\[\], int, int\)](BulkDataReader_T_.GetChars.GDUBCE0TNLEQNKLJCT57HRF96.md 'Cat\.Dapper\.SqlServer\.BulkDataReader\<T\>\.GetChars\(int, long, char\[\], int, int\)') | |
| [GetDataTypeName\(int\)](BulkDataReader_T_.GetDataTypeName.LD6RJJKDAMCS7CADO1I5ZR7UB.md 'Cat\.Dapper\.SqlServer\.BulkDataReader\<T\>\.GetDataTypeName\(int\)') | |
| [GetDateTime\(int\)](BulkDataReader_T_.GetDateTime.LAJ6DP1JDT2C77SBASHESTXDC.md 'Cat\.Dapper\.SqlServer\.BulkDataReader\<T\>\.GetDateTime\(int\)') | |
| [GetDecimal\(int\)](BulkDataReader_T_.GetDecimal.K43J5WHBRJV53YN4QAWHJ7AH8.md 'Cat\.Dapper\.SqlServer\.BulkDataReader\<T\>\.GetDecimal\(int\)') | |
| [GetDouble\(int\)](BulkDataReader_T_.GetDouble.MASUP0FXNK1OMYITA5EULYWLE.md 'Cat\.Dapper\.SqlServer\.BulkDataReader\<T\>\.GetDouble\(int\)') | |
| [GetEnumerator\(\)](BulkDataReader_T_.GetEnumerator().md 'Cat\.Dapper\.SqlServer\.BulkDataReader\<T\>\.GetEnumerator\(\)') | |
| [GetFieldType\(int\)](BulkDataReader_T_.GetFieldType.BKN41VHZYRXEAOOBNO9XZWWU8.md 'Cat\.Dapper\.SqlServer\.BulkDataReader\<T\>\.GetFieldType\(int\)') | |
| [GetFloat\(int\)](BulkDataReader_T_.GetFloat.0VPHFXOY1WJ5JW8ZTCPG6R7N1.md 'Cat\.Dapper\.SqlServer\.BulkDataReader\<T\>\.GetFloat\(int\)') | |
| [GetGuid\(int\)](BulkDataReader_T_.GetGuid.YKVQSEB16JXXPOREKJUZE9XI6.md 'Cat\.Dapper\.SqlServer\.BulkDataReader\<T\>\.GetGuid\(int\)') | |
| [GetInt16\(int\)](BulkDataReader_T_.GetInt16.X3Z00PKJOP1YU5QLBEYQH13G7.md 'Cat\.Dapper\.SqlServer\.BulkDataReader\<T\>\.GetInt16\(int\)') | |
| [GetInt32\(int\)](BulkDataReader_T_.GetInt32.85A6L29K8QUY9MP3N3P2C7MOC.md 'Cat\.Dapper\.SqlServer\.BulkDataReader\<T\>\.GetInt32\(int\)') | |
| [GetInt64\(int\)](BulkDataReader_T_.GetInt64.IXDYP7N1OT2U7LPPGFPNEL033.md 'Cat\.Dapper\.SqlServer\.BulkDataReader\<T\>\.GetInt64\(int\)') | |
| [GetName\(int\)](BulkDataReader_T_.GetName.MIF4UWXWHKDMLV1NDZG1KXAL3.md 'Cat\.Dapper\.SqlServer\.BulkDataReader\<T\>\.GetName\(int\)') | |
| [GetOrdinal\(string\)](BulkDataReader_T_.GetOrdinal.SVIRIOW0DSPIE53ASDV6D3H98.md 'Cat\.Dapper\.SqlServer\.BulkDataReader\<T\>\.GetOrdinal\(string\)') | |
| [GetString\(int\)](BulkDataReader_T_.GetString.03MIA6CDGQ7KSKQO1KASOF2V4.md 'Cat\.Dapper\.SqlServer\.BulkDataReader\<T\>\.GetString\(int\)') | |
| [GetValue\(int\)](BulkDataReader_T_.GetValue.JL7EMOLDVP16WZO5GARVRA9W8.md 'Cat\.Dapper\.SqlServer\.BulkDataReader\<T\>\.GetValue\(int\)') | |
| [GetValues\(object\[\]\)](BulkDataReader_T_.GetValues.VJU8SR867N01T3K7NQ8KP9G3.md 'Cat\.Dapper\.SqlServer\.BulkDataReader\<T\>\.GetValues\(object\[\]\)') | |
| [IsDBNull\(int\)](BulkDataReader_T_.IsDBNull.GLEJXPJ0ZOCUCKMBWBUT91VQ4.md 'Cat\.Dapper\.SqlServer\.BulkDataReader\<T\>\.IsDBNull\(int\)') | |
| [NextResult\(\)](BulkDataReader_T_.NextResult().md 'Cat\.Dapper\.SqlServer\.BulkDataReader\<T\>\.NextResult\(\)') | |
| [Read\(\)](BulkDataReader_T_.Read().md 'Cat\.Dapper\.SqlServer\.BulkDataReader\<T\>\.Read\(\)') | |
