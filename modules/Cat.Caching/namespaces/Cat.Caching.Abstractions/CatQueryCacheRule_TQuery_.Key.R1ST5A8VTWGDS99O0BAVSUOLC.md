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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.CACHING](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Caching\.Abstractions Assembly](index.md 'index') >> [Cat\.Caching\.Abstractions Namespace](Cat.Caching.Abstractions.md 'Cat\.Caching\.Abstractions') >> [CatQueryCacheRule&lt;TQuery&gt; Class](CatQueryCacheRule_TQuery_.md 'Cat\.Caching\.Abstractions\.CatQueryCacheRule\<TQuery\>')

## CatQueryCacheRule\<TQuery\>\.Key\(Func\<TQuery,string\>\) Method

Builds the part of the key that comes from the query, for a query where the serialized form is not right\.
The function must return the same text for queries that give the same answer, and a different text otherwise\.

```csharp
public Cat.Caching.Abstractions.CatQueryCacheRule<TQuery> Key(System.Func<TQuery,string> keyFunction);
```
#### Parameters

<a name='Cat.Caching.Abstractions.CatQueryCacheRule_TQuery_.Key(System.Func_TQuery,string_).keyFunction'></a>

`keyFunction` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TQuery](CatQueryCacheRule_TQuery_.md#Cat.Caching.Abstractions.CatQueryCacheRule_TQuery_.TQuery 'Cat\.Caching\.Abstractions\.CatQueryCacheRule\<TQuery\>\.TQuery')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

Builds the key part from the query\.

#### Returns
[Cat\.Caching\.Abstractions\.CatQueryCacheRule&lt;](CatQueryCacheRule_TQuery_.md 'Cat\.Caching\.Abstractions\.CatQueryCacheRule\<TQuery\>')[TQuery](CatQueryCacheRule_TQuery_.md#Cat.Caching.Abstractions.CatQueryCacheRule_TQuery_.TQuery 'Cat\.Caching\.Abstractions\.CatQueryCacheRule\<TQuery\>\.TQuery')[&gt;](CatQueryCacheRule_TQuery_.md 'Cat\.Caching\.Abstractions\.CatQueryCacheRule\<TQuery\>')  
The same rule, for chaining\.