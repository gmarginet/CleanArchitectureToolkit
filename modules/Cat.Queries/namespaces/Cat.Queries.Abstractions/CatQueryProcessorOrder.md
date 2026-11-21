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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.QUERIES](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Queries\.Abstractions Assembly](index.md 'index') >> [Cat\.Queries\.Abstractions Namespace](Cat.Queries.Abstractions.md 'Cat\.Queries\.Abstractions')

## CatQueryProcessorOrder Class

The default order of the wrappers around [ICatQueryProcessor](ICatQueryProcessor.md 'Cat\.Queries\.Abstractions\.ICatQueryProcessor'), from the outside in\.
A lower number is further out\. It runs first on the way in and last on the way out\.
Every module that wraps the processor uses one of these numbers, so the order is the same
whatever the sequence of the registration lines\.
The numbers are spaced out in steps of 100, so a wrapper of your own can slot in between, for example 150\.

```csharp
public static class CatQueryProcessorOrder
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatQueryProcessorOrder

| Fields | |
| :--- | :--- |
| [Caching](CatQueryProcessorOrder.Caching.md 'Cat\.Queries\.Abstractions\.CatQueryProcessorOrder\.Caching') | The cache\. A hit answers at once and never starts a retry\. |
| [Retry](CatQueryProcessorOrder.Retry.md 'Cat\.Queries\.Abstractions\.CatQueryProcessorOrder\.Retry') | The retry\. It sits inside the cache, so only a miss reaches it\. |
