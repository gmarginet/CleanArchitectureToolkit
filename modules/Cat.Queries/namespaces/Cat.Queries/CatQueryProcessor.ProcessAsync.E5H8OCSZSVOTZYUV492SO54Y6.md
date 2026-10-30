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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.QUERIES](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Queries Assembly](index.md 'index') >> [Cat\.Queries Namespace](Cat.Queries.md 'Cat\.Queries') >> [CatQueryProcessor Class](CatQueryProcessor.md 'Cat\.Queries\.CatQueryProcessor')

## CatQueryProcessor\.ProcessAsync\<TQueryResult\>\(ICatQuery\<TQueryResult\>, CancellationToken\) Method

Runs a query\.

```csharp
public System.Threading.Tasks.Task<Cat.Responses.Abstractions.ICatResponse<TQueryResult>> ProcessAsync<TQueryResult>(Cat.Queries.Abstractions.ICatQuery<TQueryResult> catQuery, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Type parameters

<a name='Cat.Queries.CatQueryProcessor.ProcessAsync_TQueryResult_(Cat.Queries.Abstractions.ICatQuery_TQueryResult_,System.Threading.CancellationToken).TQueryResult'></a>

`TQueryResult`

The type of the data the query returns\.
#### Parameters

<a name='Cat.Queries.CatQueryProcessor.ProcessAsync_TQueryResult_(Cat.Queries.Abstractions.ICatQuery_TQueryResult_,System.Threading.CancellationToken).catQuery'></a>

`catQuery` [Cat\.Queries\.Abstractions\.ICatQuery&lt;](../../../Cat.Queries/namespaces/Cat.Queries.Abstractions/ICatQuery_TQueryResult_.md 'Cat\.Queries\.Abstractions\.ICatQuery\`1')[TQueryResult](CatQueryProcessor.ProcessAsync.E5H8OCSZSVOTZYUV492SO54Y6.md#Cat.Queries.CatQueryProcessor.ProcessAsync_TQueryResult_(Cat.Queries.Abstractions.ICatQuery_TQueryResult_,System.Threading.CancellationToken).TQueryResult 'Cat\.Queries\.CatQueryProcessor\.ProcessAsync\<TQueryResult\>\(Cat\.Queries\.Abstractions\.ICatQuery\<TQueryResult\>, System\.Threading\.CancellationToken\)\.TQueryResult')[&gt;](../../../Cat.Queries/namespaces/Cat.Queries.Abstractions/ICatQuery_TQueryResult_.md 'Cat\.Queries\.Abstractions\.ICatQuery\`1')

The query to run\.

<a name='Cat.Queries.CatQueryProcessor.ProcessAsync_TQueryResult_(Cat.Queries.Abstractions.ICatQuery_TQueryResult_,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Token to cancel the work\.

Implements [ProcessAsync&lt;TQueryResult&gt;\(ICatQuery&lt;TQueryResult&gt;, CancellationToken\)](../../../Cat.Queries/namespaces/Cat.Queries.Abstractions/ICatQueryProcessor.ProcessAsync.NXU8C22PI206ZIXUL4SR6VC55.md 'Cat\.Queries\.Abstractions\.ICatQueryProcessor\.ProcessAsync\`\`1\(Cat\.Queries\.Abstractions\.ICatQuery\{\`\`0\},System\.Threading\.CancellationToken\)')

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Cat\.Responses\.Abstractions\.ICatResponse&lt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[TQueryResult](CatQueryProcessor.ProcessAsync.E5H8OCSZSVOTZYUV492SO54Y6.md#Cat.Queries.CatQueryProcessor.ProcessAsync_TQueryResult_(Cat.Queries.Abstractions.ICatQuery_TQueryResult_,System.Threading.CancellationToken).TQueryResult 'Cat\.Queries\.CatQueryProcessor\.ProcessAsync\<TQueryResult\>\(Cat\.Queries\.Abstractions\.ICatQuery\<TQueryResult\>, System\.Threading\.CancellationToken\)\.TQueryResult')[&gt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The response of the handler, with the data when it succeeded\.