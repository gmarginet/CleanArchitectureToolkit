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
  
##### >> [Cat\.Caching Assembly](index.md 'index') >> [Cat\.Caching Namespace](Cat.Caching.md 'Cat\.Caching')

## CatQueryCacheKeys Class

Builds the key of a cache entry\. The key holds the query type name and a hash of the user and the query\.
The hash keeps personal data out of the key, and out of the distributed cache\. A key is never logged or used as a tag\.

```csharp
internal static class CatQueryCacheKeys
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatQueryCacheKeys

| Fields | |
| :--- | :--- |
| [NoUser](CatQueryCacheKeys.NoUser.md 'Cat\.Caching\.CatQueryCacheKeys\.NoUser') | |

| Methods | |
| :--- | :--- |
| [Build\(object, CatQueryCacheRule, string\)](CatQueryCacheKeys.Build.KOP5LCF346KZTE12ADWZVWU64.md 'Cat\.Caching\.CatQueryCacheKeys\.Build\(object, Cat\.Caching\.Abstractions\.CatQueryCacheRule, string\)') | |
| [Serialize\(object, Type\)](CatQueryCacheKeys.Serialize.F3DCD89MV4U9UREYJ6OPCSZA.md 'Cat\.Caching\.CatQueryCacheKeys\.Serialize\(object, System\.Type\)') | |
