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

|&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[CAT.QUERIES](../../README.md)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Queries\.Abstractions Assembly](index.md 'index') >> [Cat\.Queries\.Abstractions Namespace](Cat.Queries.Abstractions.md 'Cat\.Queries\.Abstractions')

## ICatQueryProcessor Interface

Single entry point for running queries\.
It finds the handler for a query, runs it through the registered decorators and returns the response\.

```csharp
public interface ICatQueryProcessor
```

| Methods | |
| :--- | :--- |
| [Process&lt;TQueryResult&gt;\(ICatQuery&lt;TQueryResult&gt;\)](ICatQueryProcessor.Process.GLOZN4ERRH7J39W67F8ZXLTH6.md 'Cat\.Queries\.Abstractions\.ICatQueryProcessor\.Process\<TQueryResult\>\(Cat\.Queries\.Abstractions\.ICatQuery\<TQueryResult\>\)') | Runs a query and blocks until it finishes\. Prefer [ProcessAsync&lt;TQueryResult&gt;\(ICatQuery&lt;TQueryResult&gt;, CancellationToken\)](ICatQueryProcessor.ProcessAsync.NXU8C22PI206ZIXUL4SR6VC55.md 'Cat\.Queries\.Abstractions\.ICatQueryProcessor\.ProcessAsync\<TQueryResult\>\(Cat\.Queries\.Abstractions\.ICatQuery\<TQueryResult\>, System\.Threading\.CancellationToken\)') when you can\. |
| [ProcessAsync&lt;TQueryResult&gt;\(ICatQuery&lt;TQueryResult&gt;, CancellationToken\)](ICatQueryProcessor.ProcessAsync.NXU8C22PI206ZIXUL4SR6VC55.md 'Cat\.Queries\.Abstractions\.ICatQueryProcessor\.ProcessAsync\<TQueryResult\>\(Cat\.Queries\.Abstractions\.ICatQuery\<TQueryResult\>, System\.Threading\.CancellationToken\)') | Runs a query\. |
