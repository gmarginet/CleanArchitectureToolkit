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
  
##### >> [Cat\.Caching Assembly](index.md 'index') >> [Cat\.Caching Namespace](Cat.Caching.md 'Cat\.Caching') >> [CatHybridQueryCache Class](CatHybridQueryCache.md 'Cat\.Caching\.CatHybridQueryCache')

## CatHybridQueryCache\.GetOrCreateAsync\<T\>\(string, Func\<CancellationToken,Task\<T\>\>, CatQueryCacheEntryOptions, CancellationToken\) Method

Returns the value of a key\. When the cache has none, it calls the factory and stores the result\.
A burst of calls for the same missing key should run the factory once\. The default implementation does that per instance\.
When the factory throws, nothing is stored and the exception goes to the caller\.

```csharp
public System.Threading.Tasks.Task<T> GetOrCreateAsync<T>(string key, System.Func<System.Threading.CancellationToken,System.Threading.Tasks.Task<T>> factory, Cat.Caching.Abstractions.CatQueryCacheEntryOptions options, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Type parameters

<a name='Cat.Caching.CatHybridQueryCache.GetOrCreateAsync_T_(string,System.Func_System.Threading.CancellationToken,System.Threading.Tasks.Task_T__,Cat.Caching.Abstractions.CatQueryCacheEntryOptions,System.Threading.CancellationToken).T'></a>

`T`

The type of the stored value\.
#### Parameters

<a name='Cat.Caching.CatHybridQueryCache.GetOrCreateAsync_T_(string,System.Func_System.Threading.CancellationToken,System.Threading.Tasks.Task_T__,Cat.Caching.Abstractions.CatQueryCacheEntryOptions,System.Threading.CancellationToken).key'></a>

`key` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The key of the entry\. It never holds the plain query or the user\.

<a name='Cat.Caching.CatHybridQueryCache.GetOrCreateAsync_T_(string,System.Func_System.Threading.CancellationToken,System.Threading.Tasks.Task_T__,Cat.Caching.Abstractions.CatQueryCacheEntryOptions,System.Threading.CancellationToken).factory'></a>

`factory` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[T](CatHybridQueryCache.GetOrCreateAsync.Y9UXTN7I3294FWIBBZEERPOWD.md#Cat.Caching.CatHybridQueryCache.GetOrCreateAsync_T_(string,System.Func_System.Threading.CancellationToken,System.Threading.Tasks.Task_T__,Cat.Caching.Abstractions.CatQueryCacheEntryOptions,System.Threading.CancellationToken).T 'Cat\.Caching\.CatHybridQueryCache\.GetOrCreateAsync\<T\>\(string, System\.Func\<System\.Threading\.CancellationToken,System\.Threading\.Tasks\.Task\<T\>\>, Cat\.Caching\.Abstractions\.CatQueryCacheEntryOptions, System\.Threading\.CancellationToken\)\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

Creates the value when the cache has none\.

<a name='Cat.Caching.CatHybridQueryCache.GetOrCreateAsync_T_(string,System.Func_System.Threading.CancellationToken,System.Threading.Tasks.Task_T__,Cat.Caching.Abstractions.CatQueryCacheEntryOptions,System.Threading.CancellationToken).options'></a>

`options` [CatQueryCacheEntryOptions](../../../Cat.Caching/namespaces/Cat.Caching.Abstractions/CatQueryCacheEntryOptions.md 'Cat\.Caching\.Abstractions\.CatQueryCacheEntryOptions')

How long the entry lives and which tags it gets\.

<a name='Cat.Caching.CatHybridQueryCache.GetOrCreateAsync_T_(string,System.Func_System.Threading.CancellationToken,System.Threading.Tasks.Task_T__,Cat.Caching.Abstractions.CatQueryCacheEntryOptions,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Token to cancel the work\.

Implements [GetOrCreateAsync&lt;T&gt;\(string, Func&lt;CancellationToken,Task&lt;T&gt;&gt;, CatQueryCacheEntryOptions, CancellationToken\)](../../../Cat.Caching/namespaces/Cat.Caching.Abstractions/ICatQueryCache.GetOrCreateAsync.332ALBIV4QS7ZHE84MUYAQQWC.md 'Cat\.Caching\.Abstractions\.ICatQueryCache\.GetOrCreateAsync\`\`1\(System\.String,System\.Func\{System\.Threading\.CancellationToken,System\.Threading\.Tasks\.Task\{\`\`0\}\},Cat\.Caching\.Abstractions\.CatQueryCacheEntryOptions,System\.Threading\.CancellationToken\)')

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[T](CatHybridQueryCache.GetOrCreateAsync.Y9UXTN7I3294FWIBBZEERPOWD.md#Cat.Caching.CatHybridQueryCache.GetOrCreateAsync_T_(string,System.Func_System.Threading.CancellationToken,System.Threading.Tasks.Task_T__,Cat.Caching.Abstractions.CatQueryCacheEntryOptions,System.Threading.CancellationToken).T 'Cat\.Caching\.CatHybridQueryCache\.GetOrCreateAsync\<T\>\(string, System\.Func\<System\.Threading\.CancellationToken,System\.Threading\.Tasks\.Task\<T\>\>, Cat\.Caching\.Abstractions\.CatQueryCacheEntryOptions, System\.Threading\.CancellationToken\)\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The cached or the new value\.