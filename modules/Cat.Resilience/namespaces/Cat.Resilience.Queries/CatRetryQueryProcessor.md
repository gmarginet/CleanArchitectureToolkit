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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.RESILIENCE](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Resilience\.Queries Assembly](index.md 'index') >> [Cat\.Resilience\.Queries Namespace](Cat.Resilience.Queries.md 'Cat\.Resilience\.Queries')

## CatRetryQueryProcessor Class

Wraps the query processor\. A listed query type runs inside the pipeline of its profile, and every try calls the inner processor again,
which opens a new scope\. Every other type passes straight through\.
A failed response that the rule counts becomes an exception inside the pipeline, so the profile retries it and counts it for its circuit breaker\.
After the last retry the response of the last try comes back\. When the pipeline itself says no, for example because its circuit is open
or a try timed out, its exception comes through\.

```csharp
internal sealed class CatRetryQueryProcessor : Cat.Queries.Abstractions.ICatQueryProcessor
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatRetryQueryProcessor

Implements [ICatQueryProcessor](../../../Cat.Queries/namespaces/Cat.Queries.Abstractions/ICatQueryProcessor.md 'Cat\.Queries\.Abstractions\.ICatQueryProcessor')

| Constructors | |
| :--- | :--- |
| [CatRetryQueryProcessor\(ICatQueryProcessor, ICatResiliencePipelines, CatQueryRetryOptions\)](CatRetryQueryProcessor..ctor.MZ7A5DJ93GGP7MGJ7NFAF03U3.md 'Cat\.Resilience\.Queries\.CatRetryQueryProcessor\.CatRetryQueryProcessor\(Cat\.Queries\.Abstractions\.ICatQueryProcessor, Cat\.Resilience\.Abstractions\.ICatResiliencePipelines, Cat\.Resilience\.Queries\.CatQueryRetryOptions\)') | Wraps the query processor\. A listed query type runs inside the pipeline of its profile, and every try calls the inner processor again, which opens a new scope\. Every other type passes straight through\. A failed response that the rule counts becomes an exception inside the pipeline, so the profile retries it and counts it for its circuit breaker\. After the last retry the response of the last try comes back\. When the pipeline itself says no, for example because its circuit is open or a try timed out, its exception comes through\. |

| Methods | |
| :--- | :--- |
| [Process&lt;TQueryResult&gt;\(ICatQuery&lt;TQueryResult&gt;\)](CatRetryQueryProcessor.Process.KVIQUM54O8ZL5Y6AFNSHDT739.md 'Cat\.Resilience\.Queries\.CatRetryQueryProcessor\.Process\<TQueryResult\>\(Cat\.Queries\.Abstractions\.ICatQuery\<TQueryResult\>\)') | Runs a query and blocks until it finishes\. Prefer [ProcessAsync&lt;TQueryResult&gt;\(ICatQuery&lt;TQueryResult&gt;, CancellationToken\)](../../../Cat.Queries/namespaces/Cat.Queries.Abstractions/ICatQueryProcessor.ProcessAsync.NXU8C22PI206ZIXUL4SR6VC55.md 'Cat\.Queries\.Abstractions\.ICatQueryProcessor\.ProcessAsync\`\`1\(Cat\.Queries\.Abstractions\.ICatQuery\{\`\`0\},System\.Threading\.CancellationToken\)') when you can\. |
| [ProcessAsync&lt;TQueryResult&gt;\(ICatQuery&lt;TQueryResult&gt;, CancellationToken\)](CatRetryQueryProcessor.ProcessAsync.PSOI8XLFKXCTQITFRIPAS2ZV3.md 'Cat\.Resilience\.Queries\.CatRetryQueryProcessor\.ProcessAsync\<TQueryResult\>\(Cat\.Queries\.Abstractions\.ICatQuery\<TQueryResult\>, System\.Threading\.CancellationToken\)') | Runs a query\. |
