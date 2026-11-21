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

## CatQueryProcessorWrapperExtensions Class

Registers a wrapper around [ICatQueryProcessor](ICatQueryProcessor.md 'Cat\.Queries\.Abstractions\.ICatQueryProcessor'), such as a cache or a retry\.
Wrappers from different modules go in the order of their number, see [CatQueryProcessorOrder](CatQueryProcessorOrder.md 'Cat\.Queries\.Abstractions\.CatQueryProcessorOrder'),
and not in the order of the registration lines\.

```csharp
public static class CatQueryProcessorWrapperExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatQueryProcessorWrapperExtensions

| Methods | |
| :--- | :--- |
| [AddCatQueryProcessorWrapper\(this IServiceCollection, int, Func&lt;IServiceProvider,ICatQueryProcessor,ICatQueryProcessor&gt;, string\)](CatQueryProcessorWrapperExtensions.AddCatQueryProcessorWrapper.QG9ADDDSU4WC6RYGXCYYJUQYA.md 'Cat\.Queries\.Abstractions\.CatQueryProcessorWrapperExtensions\.AddCatQueryProcessorWrapper\(this Microsoft\.Extensions\.DependencyInjection\.IServiceCollection, int, System\.Func\<System\.IServiceProvider,Cat\.Queries\.Abstractions\.ICatQueryProcessor,Cat\.Queries\.Abstractions\.ICatQueryProcessor\>, string\)') | Wraps the registered [ICatQueryProcessor](ICatQueryProcessor.md 'Cat\.Queries\.Abstractions\.ICatQueryProcessor')\. The first call replaces the registration of the processor with one that builds the processor and all the wrappers\. Later calls add their wrapper to the same registration\. A wrapper with a lower order is further out\. Wrappers with the same order are kept in the order of the calls, and the last one is outside\. |
