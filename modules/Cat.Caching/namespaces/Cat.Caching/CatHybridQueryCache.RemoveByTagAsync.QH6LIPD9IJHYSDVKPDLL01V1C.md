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

## CatHybridQueryCache\.RemoveByTagAsync\(string, CancellationToken\) Method

Removes every entry that has the tag\.
A cache that is spread over several instances may keep the entry in the memory of the other instances
until its local lifetime ends\.

```csharp
public System.Threading.Tasks.Task RemoveByTagAsync(string tag, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Cat.Caching.CatHybridQueryCache.RemoveByTagAsync(string,System.Threading.CancellationToken).tag'></a>

`tag` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The tag to remove, as listed in the registration of the query type\.

<a name='Cat.Caching.CatHybridQueryCache.RemoveByTagAsync(string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Token to cancel the work\.

Implements [RemoveByTagAsync\(string, CancellationToken\)](../../../Cat.Caching/namespaces/Cat.Caching.Abstractions/ICatQueryCache.RemoveByTagAsync.Q4XVLUZIZAIKVFB9547OBLINC.md 'Cat\.Caching\.Abstractions\.ICatQueryCache\.RemoveByTagAsync\(System\.String,System\.Threading\.CancellationToken\)')

#### Returns
[System\.Threading\.Tasks\.Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task 'System\.Threading\.Tasks\.Task')  
A task that finishes when the tag is removed\.