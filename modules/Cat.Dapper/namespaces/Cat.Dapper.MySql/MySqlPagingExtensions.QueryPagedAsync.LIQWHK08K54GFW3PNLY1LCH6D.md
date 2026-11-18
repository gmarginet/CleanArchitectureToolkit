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
  
##### >> [Cat\.Dapper\.MySql Assembly](index.md 'index') >> [Cat\.Dapper\.MySql Namespace](Cat.Dapper.MySql.md 'Cat\.Dapper\.MySql') >> [MySqlPagingExtensions Class](MySqlPagingExtensions.md 'Cat\.Dapper\.MySql\.MySqlPagingExtensions')

## MySqlPagingExtensions\.QueryPagedAsync\<T\>\(this ICatDbSession, string, string, int, int, object, CancellationToken\) Method

Counts all rows, then reads one page of them, in one round trip to the database\.

```csharp
public static System.Threading.Tasks.Task<Cat.Responses.Abstractions.ICatPagedList<T>> QueryPagedAsync<T>(this Cat.Dapper.Abstractions.ICatDbSession session, string sql, string orderBy, int pageNumber, int pageSize, object? param=null, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Type parameters

<a name='Cat.Dapper.MySql.MySqlPagingExtensions.QueryPagedAsync_T_(thisCat.Dapper.Abstractions.ICatDbSession,string,string,int,int,object,System.Threading.CancellationToken).T'></a>

`T`

The result class\. Dapper maps the columns to its properties by name\.
#### Parameters

<a name='Cat.Dapper.MySql.MySqlPagingExtensions.QueryPagedAsync_T_(thisCat.Dapper.Abstractions.ICatDbSession,string,string,int,int,object,System.Threading.CancellationToken).session'></a>

`session` [ICatDbSession](../../../Cat.Dapper/namespaces/Cat.Dapper.Abstractions/ICatDbSession.md 'Cat\.Dapper\.Abstractions\.ICatDbSession')

The session to run the SQL on\.

<a name='Cat.Dapper.MySql.MySqlPagingExtensions.QueryPagedAsync_T_(thisCat.Dapper.Abstractions.ICatDbSession,string,string,int,int,object,System.Threading.CancellationToken).sql'></a>

`sql` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

A `SELECT` statement without an `ORDER BY`\.

<a name='Cat.Dapper.MySql.MySqlPagingExtensions.QueryPagedAsync_T_(thisCat.Dapper.Abstractions.ICatDbSession,string,string,int,int,object,System.Threading.CancellationToken).orderBy'></a>

`orderBy` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The columns to sort on, such as `CreatedAt DESC, Id`\. Make the order unique, otherwise the pages have no stable order\.

<a name='Cat.Dapper.MySql.MySqlPagingExtensions.QueryPagedAsync_T_(thisCat.Dapper.Abstractions.ICatDbSession,string,string,int,int,object,System.Threading.CancellationToken).pageNumber'></a>

`pageNumber` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of the page to read\. The first page is 1\.

<a name='Cat.Dapper.MySql.MySqlPagingExtensions.QueryPagedAsync_T_(thisCat.Dapper.Abstractions.ICatDbSession,string,string,int,int,object,System.Threading.CancellationToken).pageSize'></a>

`pageSize` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The maximum number of rows on a page\.

<a name='Cat.Dapper.MySql.MySqlPagingExtensions.QueryPagedAsync_T_(thisCat.Dapper.Abstractions.ICatDbSession,string,string,int,int,object,System.Threading.CancellationToken).param'></a>

`param` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

An object whose properties are the parameters of the SQL, or `null`\.

<a name='Cat.Dapper.MySql.MySqlPagingExtensions.QueryPagedAsync_T_(thisCat.Dapper.Abstractions.ICatDbSession,string,string,int,int,object,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Token to cancel the work\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Cat\.Responses\.Abstractions\.ICatPagedList&lt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatPagedList_TList_.md 'Cat\.Responses\.Abstractions\.ICatPagedList\`1')[T](MySqlPagingExtensions.QueryPagedAsync.LIQWHK08K54GFW3PNLY1LCH6D.md#Cat.Dapper.MySql.MySqlPagingExtensions.QueryPagedAsync_T_(thisCat.Dapper.Abstractions.ICatDbSession,string,string,int,int,object,System.Threading.CancellationToken).T 'Cat\.Dapper\.MySql\.MySqlPagingExtensions\.QueryPagedAsync\<T\>\(this Cat\.Dapper\.Abstractions\.ICatDbSession, string, string, int, int, object, System\.Threading\.CancellationToken\)\.T')[&gt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatPagedList_TList_.md 'Cat\.Responses\.Abstractions\.ICatPagedList\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The page, with the total row count of the whole statement\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
Thrown when [session](MySqlPagingExtensions.QueryPagedAsync.LIQWHK08K54GFW3PNLY1LCH6D.md#Cat.Dapper.MySql.MySqlPagingExtensions.QueryPagedAsync_T_(thisCat.Dapper.Abstractions.ICatDbSession,string,string,int,int,object,System.Threading.CancellationToken).session 'Cat\.Dapper\.MySql\.MySqlPagingExtensions\.QueryPagedAsync\<T\>\(this Cat\.Dapper\.Abstractions\.ICatDbSession, string, string, int, int, object, System\.Threading\.CancellationToken\)\.session'), [sql](MySqlPagingExtensions.QueryPagedAsync.LIQWHK08K54GFW3PNLY1LCH6D.md#Cat.Dapper.MySql.MySqlPagingExtensions.QueryPagedAsync_T_(thisCat.Dapper.Abstractions.ICatDbSession,string,string,int,int,object,System.Threading.CancellationToken).sql 'Cat\.Dapper\.MySql\.MySqlPagingExtensions\.QueryPagedAsync\<T\>\(this Cat\.Dapper\.Abstractions\.ICatDbSession, string, string, int, int, object, System\.Threading\.CancellationToken\)\.sql') or [orderBy](MySqlPagingExtensions.QueryPagedAsync.LIQWHK08K54GFW3PNLY1LCH6D.md#Cat.Dapper.MySql.MySqlPagingExtensions.QueryPagedAsync_T_(thisCat.Dapper.Abstractions.ICatDbSession,string,string,int,int,object,System.Threading.CancellationToken).orderBy 'Cat\.Dapper\.MySql\.MySqlPagingExtensions\.QueryPagedAsync\<T\>\(this Cat\.Dapper\.Abstractions\.ICatDbSession, string, string, int, int, object, System\.Threading\.CancellationToken\)\.orderBy') is `null`\.

[System\.ArgumentOutOfRangeException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception 'System\.ArgumentOutOfRangeException')  
Thrown when [pageNumber](MySqlPagingExtensions.QueryPagedAsync.LIQWHK08K54GFW3PNLY1LCH6D.md#Cat.Dapper.MySql.MySqlPagingExtensions.QueryPagedAsync_T_(thisCat.Dapper.Abstractions.ICatDbSession,string,string,int,int,object,System.Threading.CancellationToken).pageNumber 'Cat\.Dapper\.MySql\.MySqlPagingExtensions\.QueryPagedAsync\<T\>\(this Cat\.Dapper\.Abstractions\.ICatDbSession, string, string, int, int, object, System\.Threading\.CancellationToken\)\.pageNumber') or [pageSize](MySqlPagingExtensions.QueryPagedAsync.LIQWHK08K54GFW3PNLY1LCH6D.md#Cat.Dapper.MySql.MySqlPagingExtensions.QueryPagedAsync_T_(thisCat.Dapper.Abstractions.ICatDbSession,string,string,int,int,object,System.Threading.CancellationToken).pageSize 'Cat\.Dapper\.MySql\.MySqlPagingExtensions\.QueryPagedAsync\<T\>\(this Cat\.Dapper\.Abstractions\.ICatDbSession, string, string, int, int, object, System\.Threading\.CancellationToken\)\.pageSize') is less than 1\.

### Remarks
Give the statement without an `ORDER BY`, because the helper wraps it to count the rows and adds the order itself\.
Every column needs a name of its own, and the statement may not start with `WITH`\.
Pass values through [param](MySqlPagingExtensions.QueryPagedAsync.LIQWHK08K54GFW3PNLY1LCH6D.md#Cat.Dapper.MySql.MySqlPagingExtensions.QueryPagedAsync_T_(thisCat.Dapper.Abstractions.ICatDbSession,string,string,int,int,object,System.Threading.CancellationToken).param 'Cat\.Dapper\.MySql\.MySqlPagingExtensions\.QueryPagedAsync\<T\>\(this Cat\.Dapper\.Abstractions\.ICatDbSession, string, string, int, int, object, System\.Threading\.CancellationToken\)\.param')\. The [sql](MySqlPagingExtensions.QueryPagedAsync.LIQWHK08K54GFW3PNLY1LCH6D.md#Cat.Dapper.MySql.MySqlPagingExtensions.QueryPagedAsync_T_(thisCat.Dapper.Abstractions.ICatDbSession,string,string,int,int,object,System.Threading.CancellationToken).sql 'Cat\.Dapper\.MySql\.MySqlPagingExtensions\.QueryPagedAsync\<T\>\(this Cat\.Dapper\.Abstractions\.ICatDbSession, string, string, int, int, object, System\.Threading\.CancellationToken\)\.sql') and [orderBy](MySqlPagingExtensions.QueryPagedAsync.LIQWHK08K54GFW3PNLY1LCH6D.md#Cat.Dapper.MySql.MySqlPagingExtensions.QueryPagedAsync_T_(thisCat.Dapper.Abstractions.ICatDbSession,string,string,int,int,object,System.Threading.CancellationToken).orderBy 'Cat\.Dapper\.MySql\.MySqlPagingExtensions\.QueryPagedAsync\<T\>\(this Cat\.Dapper\.Abstractions\.ICatDbSession, string, string, int, int, object, System\.Threading\.CancellationToken\)\.orderBy') are added to the SQL text as they are,
so they must be constants of the handler and never come from user input\.