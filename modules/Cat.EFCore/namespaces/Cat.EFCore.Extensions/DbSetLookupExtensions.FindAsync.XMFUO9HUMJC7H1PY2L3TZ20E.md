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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.EFCORE](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.EFCore\.Extensions Assembly](index.md 'index') >> [Cat\.EFCore\.Extensions Namespace](Cat.EFCore.Extensions.md 'Cat\.EFCore\.Extensions') >> [DbSetLookupExtensions Class](DbSetLookupExtensions.md 'Cat\.EFCore\.Extensions\.DbSetLookupExtensions')

## DbSetLookupExtensions\.FindAsync\<TEntity\>\(DbSet\<TEntity\>, string, object, Expression\<Func\<TEntity,bool\>\>, CancellationToken\) Method

```csharp
private static System.Threading.Tasks.ValueTask<TEntity?> FindAsync<TEntity>(Microsoft.EntityFrameworkCore.DbSet<TEntity> set, string propertyName, object value, System.Linq.Expressions.Expression<System.Func<TEntity,bool>> predicate, System.Threading.CancellationToken cancellationToken)
    where TEntity : Cat.EFCore.Entities.CatEntityBase;
```
#### Type parameters

<a name='Cat.EFCore.Extensions.DbSetLookupExtensions.FindAsync_TEntity_(Microsoft.EntityFrameworkCore.DbSet_TEntity_,string,object,System.Linq.Expressions.Expression_System.Func_TEntity,bool__,System.Threading.CancellationToken).TEntity'></a>

`TEntity`
#### Parameters

<a name='Cat.EFCore.Extensions.DbSetLookupExtensions.FindAsync_TEntity_(Microsoft.EntityFrameworkCore.DbSet_TEntity_,string,object,System.Linq.Expressions.Expression_System.Func_TEntity,bool__,System.Threading.CancellationToken).set'></a>

`set` [Microsoft\.EntityFrameworkCore\.DbSet&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbset-1 'Microsoft\.EntityFrameworkCore\.DbSet\`1')[TEntity](DbSetLookupExtensions.FindAsync.XMFUO9HUMJC7H1PY2L3TZ20E.md#Cat.EFCore.Extensions.DbSetLookupExtensions.FindAsync_TEntity_(Microsoft.EntityFrameworkCore.DbSet_TEntity_,string,object,System.Linq.Expressions.Expression_System.Func_TEntity,bool__,System.Threading.CancellationToken).TEntity 'Cat\.EFCore\.Extensions\.DbSetLookupExtensions\.FindAsync\<TEntity\>\(Microsoft\.EntityFrameworkCore\.DbSet\<TEntity\>, string, object, System\.Linq\.Expressions\.Expression\<System\.Func\<TEntity,bool\>\>, System\.Threading\.CancellationToken\)\.TEntity')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbset-1 'Microsoft\.EntityFrameworkCore\.DbSet\`1')

<a name='Cat.EFCore.Extensions.DbSetLookupExtensions.FindAsync_TEntity_(Microsoft.EntityFrameworkCore.DbSet_TEntity_,string,object,System.Linq.Expressions.Expression_System.Func_TEntity,bool__,System.Threading.CancellationToken).propertyName'></a>

`propertyName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='Cat.EFCore.Extensions.DbSetLookupExtensions.FindAsync_TEntity_(Microsoft.EntityFrameworkCore.DbSet_TEntity_,string,object,System.Linq.Expressions.Expression_System.Func_TEntity,bool__,System.Threading.CancellationToken).value'></a>

`value` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

<a name='Cat.EFCore.Extensions.DbSetLookupExtensions.FindAsync_TEntity_(Microsoft.EntityFrameworkCore.DbSet_TEntity_,string,object,System.Linq.Expressions.Expression_System.Func_TEntity,bool__,System.Threading.CancellationToken).predicate'></a>

`predicate` [System\.Linq\.Expressions\.Expression&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')[System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TEntity](DbSetLookupExtensions.FindAsync.XMFUO9HUMJC7H1PY2L3TZ20E.md#Cat.EFCore.Extensions.DbSetLookupExtensions.FindAsync_TEntity_(Microsoft.EntityFrameworkCore.DbSet_TEntity_,string,object,System.Linq.Expressions.Expression_System.Func_TEntity,bool__,System.Threading.CancellationToken).TEntity 'Cat\.EFCore\.Extensions\.DbSetLookupExtensions\.FindAsync\<TEntity\>\(Microsoft\.EntityFrameworkCore\.DbSet\<TEntity\>, string, object, System\.Linq\.Expressions\.Expression\<System\.Func\<TEntity,bool\>\>, System\.Threading\.CancellationToken\)\.TEntity')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')

<a name='Cat.EFCore.Extensions.DbSetLookupExtensions.FindAsync_TEntity_(Microsoft.EntityFrameworkCore.DbSet_TEntity_,string,object,System.Linq.Expressions.Expression_System.Func_TEntity,bool__,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

#### Returns
[System\.Threading\.Tasks\.ValueTask&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask-1 'System\.Threading\.Tasks\.ValueTask\`1')[TEntity](DbSetLookupExtensions.FindAsync.XMFUO9HUMJC7H1PY2L3TZ20E.md#Cat.EFCore.Extensions.DbSetLookupExtensions.FindAsync_TEntity_(Microsoft.EntityFrameworkCore.DbSet_TEntity_,string,object,System.Linq.Expressions.Expression_System.Func_TEntity,bool__,System.Threading.CancellationToken).TEntity 'Cat\.EFCore\.Extensions\.DbSetLookupExtensions\.FindAsync\<TEntity\>\(Microsoft\.EntityFrameworkCore\.DbSet\<TEntity\>, string, object, System\.Linq\.Expressions\.Expression\<System\.Func\<TEntity,bool\>\>, System\.Threading\.CancellationToken\)\.TEntity')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask-1 'System\.Threading\.Tasks\.ValueTask\`1')