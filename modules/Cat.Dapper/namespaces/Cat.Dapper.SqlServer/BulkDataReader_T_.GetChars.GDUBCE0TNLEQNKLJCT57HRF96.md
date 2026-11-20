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
  
##### >> [Cat\.Dapper\.SqlServer Assembly](index.md 'index') >> [Cat\.Dapper\.SqlServer Namespace](Cat.Dapper.SqlServer.md 'Cat\.Dapper\.SqlServer') >> [BulkDataReader&lt;T&gt; Class](BulkDataReader_T_.md 'Cat\.Dapper\.SqlServer\.BulkDataReader\<T\>')

## BulkDataReader\<T\>\.GetChars\(int, long, char\[\], int, int\) Method

```csharp
public override long GetChars(int ordinal, long dataOffset, char[]? buffer, int bufferOffset, int length);
```
#### Parameters

<a name='Cat.Dapper.SqlServer.BulkDataReader_T_.GetChars(int,long,char[],int,int).ordinal'></a>

`ordinal` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='Cat.Dapper.SqlServer.BulkDataReader_T_.GetChars(int,long,char[],int,int).dataOffset'></a>

`dataOffset` [System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')

<a name='Cat.Dapper.SqlServer.BulkDataReader_T_.GetChars(int,long,char[],int,int).buffer'></a>

`buffer` [System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

<a name='Cat.Dapper.SqlServer.BulkDataReader_T_.GetChars(int,long,char[],int,int).bufferOffset'></a>

`bufferOffset` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='Cat.Dapper.SqlServer.BulkDataReader_T_.GetChars(int,long,char[],int,int).length'></a>

`length` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

Implements [GetChars\(int, long, char\[\], int, int\)](https://learn.microsoft.com/en-us/dotnet/api/system.data.idatarecord.getchars#system-data-idatarecord-getchars(system-int32-system-int64-system-char[]-system-int32-system-int32) 'System\.Data\.IDataRecord\.GetChars\(System\.Int32,System\.Int64,System\.Char\[\],System\.Int32,System\.Int32\)')

#### Returns
[System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')