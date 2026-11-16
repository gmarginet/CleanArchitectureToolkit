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
  
##### >> [Cat\.Dapper Assembly](index.md 'index') >> [Cat\.Dapper Namespace](Cat.Dapper.md 'Cat\.Dapper') >> [CatDbSessionExtensions Class](CatDbSessionExtensions.md 'Cat\.Dapper\.CatDbSessionExtensions')

## CatDbSessionExtensions\.ExecuteAsync\(this ICatDbSession, string, object, CancellationToken\) Method

Runs a statement that returns no rows, such as an insert, an update or a stored procedure\.

```csharp
public static System.Threading.Tasks.Task<int> ExecuteAsync(this Cat.Dapper.Abstractions.ICatDbSession session, string sql, object? param=null, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Cat.Dapper.CatDbSessionExtensions.ExecuteAsync(thisCat.Dapper.Abstractions.ICatDbSession,string,object,System.Threading.CancellationToken).session'></a>

`session` [ICatDbSession](../../../Cat.Dapper/namespaces/Cat.Dapper.Abstractions/ICatDbSession.md 'Cat\.Dapper\.Abstractions\.ICatDbSession')

The session to run the SQL on\.

<a name='Cat.Dapper.CatDbSessionExtensions.ExecuteAsync(thisCat.Dapper.Abstractions.ICatDbSession,string,object,System.Threading.CancellationToken).sql'></a>

`sql` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The SQL text\.

<a name='Cat.Dapper.CatDbSessionExtensions.ExecuteAsync(thisCat.Dapper.Abstractions.ICatDbSession,string,object,System.Threading.CancellationToken).param'></a>

`param` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

An object whose properties are the parameters of the SQL, or `null`\.

<a name='Cat.Dapper.CatDbSessionExtensions.ExecuteAsync(thisCat.Dapper.Abstractions.ICatDbSession,string,object,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Token to cancel the work\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The number of rows the statement changed\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
Thrown when [session](CatDbSessionExtensions.ExecuteAsync.BC0KMCHH17BHLR5CMKS8EOZUD.md#Cat.Dapper.CatDbSessionExtensions.ExecuteAsync(thisCat.Dapper.Abstractions.ICatDbSession,string,object,System.Threading.CancellationToken).session 'Cat\.Dapper\.CatDbSessionExtensions\.ExecuteAsync\(this Cat\.Dapper\.Abstractions\.ICatDbSession, string, object, System\.Threading\.CancellationToken\)\.session') or [sql](CatDbSessionExtensions.ExecuteAsync.BC0KMCHH17BHLR5CMKS8EOZUD.md#Cat.Dapper.CatDbSessionExtensions.ExecuteAsync(thisCat.Dapper.Abstractions.ICatDbSession,string,object,System.Threading.CancellationToken).sql 'Cat\.Dapper\.CatDbSessionExtensions\.ExecuteAsync\(this Cat\.Dapper\.Abstractions\.ICatDbSession, string, object, System\.Threading\.CancellationToken\)\.sql') is `null`\.