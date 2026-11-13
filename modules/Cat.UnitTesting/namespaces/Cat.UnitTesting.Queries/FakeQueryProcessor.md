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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.UNITTESTING](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.UnitTesting\.Queries Assembly](index.md 'index') >> [Cat\.UnitTesting\.Queries Namespace](Cat.UnitTesting.Queries.md 'Cat\.UnitTesting\.Queries')

## FakeQueryProcessor Class

A query processor for unit tests\. It records every query and returns what the test says\.
A query without a set up response throws, because a fake cannot guess the data\.

```csharp
public class FakeQueryProcessor : Cat.Queries.Abstractions.ICatQueryProcessor
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → FakeQueryProcessor

Implements [ICatQueryProcessor](../../../Cat.Queries/namespaces/Cat.Queries.Abstractions/ICatQueryProcessor.md 'Cat\.Queries\.Abstractions\.ICatQueryProcessor')

| Fields | |
| :--- | :--- |
| [\_responses](FakeQueryProcessor._responses.md 'Cat\.UnitTesting\.Queries\.FakeQueryProcessor\.\_responses') | |

| Properties | |
| :--- | :--- |
| [Queries](FakeQueryProcessor.Queries.md 'Cat\.UnitTesting\.Queries\.FakeQueryProcessor\.Queries') | Every query that was processed, in order\. |

| Methods | |
| :--- | :--- |
| [Of&lt;T&gt;\(\)](FakeQueryProcessor.Of_T_().md 'Cat\.UnitTesting\.Queries\.FakeQueryProcessor\.Of\<T\>\(\)') | Gives the processed queries of one type, in order\. |
| [Process&lt;TQueryResult&gt;\(ICatQuery&lt;TQueryResult&gt;\)](FakeQueryProcessor.Process.UPS50FTBXDZAJK2OJIK3V4DTE.md 'Cat\.UnitTesting\.Queries\.FakeQueryProcessor\.Process\<TQueryResult\>\(Cat\.Queries\.Abstractions\.ICatQuery\<TQueryResult\>\)') | Runs a query and blocks until it finishes\. Prefer [ProcessAsync&lt;TQueryResult&gt;\(ICatQuery&lt;TQueryResult&gt;, CancellationToken\)](../../../Cat.Queries/namespaces/Cat.Queries.Abstractions/ICatQueryProcessor.ProcessAsync.NXU8C22PI206ZIXUL4SR6VC55.md 'Cat\.Queries\.Abstractions\.ICatQueryProcessor\.ProcessAsync\`\`1\(Cat\.Queries\.Abstractions\.ICatQuery\{\`\`0\},System\.Threading\.CancellationToken\)') when you can\. |
| [ProcessAsync&lt;TQueryResult&gt;\(ICatQuery&lt;TQueryResult&gt;, CancellationToken\)](FakeQueryProcessor.ProcessAsync.XFL2O6PZ3VD3IYI4511NPC0LA.md 'Cat\.UnitTesting\.Queries\.FakeQueryProcessor\.ProcessAsync\<TQueryResult\>\(Cat\.Queries\.Abstractions\.ICatQuery\<TQueryResult\>, System\.Threading\.CancellationToken\)') | Runs a query\. |
| [Reset\(\)](FakeQueryProcessor.Reset().md 'Cat\.UnitTesting\.Queries\.FakeQueryProcessor\.Reset\(\)') | Clears the recorded queries and the set up responses\. |
| [Respond&lt;TQuery,TQueryResult&gt;\(ICatResponse&lt;TQueryResult&gt;\)](FakeQueryProcessor.Respond.md#Cat.UnitTesting.Queries.FakeQueryProcessor.Respond_TQuery,TQueryResult_(Cat.Responses.Abstractions.ICatResponse_TQueryResult_) 'Cat\.UnitTesting\.Queries\.FakeQueryProcessor\.Respond\<TQuery,TQueryResult\>\(Cat\.Responses\.Abstractions\.ICatResponse\<TQueryResult\>\)') | Sets the response for a query type\. |
| [Respond&lt;TQuery,TQueryResult&gt;\(Func&lt;TQuery,ICatResponse&lt;TQueryResult&gt;&gt;\)](FakeQueryProcessor.Respond.md#Cat.UnitTesting.Queries.FakeQueryProcessor.Respond_TQuery,TQueryResult_(System.Func_TQuery,Cat.Responses.Abstractions.ICatResponse_TQueryResult__) 'Cat\.UnitTesting\.Queries\.FakeQueryProcessor\.Respond\<TQuery,TQueryResult\>\(System\.Func\<TQuery,Cat\.Responses\.Abstractions\.ICatResponse\<TQueryResult\>\>\)') | Sets the response for a query type, built from the query\. |
