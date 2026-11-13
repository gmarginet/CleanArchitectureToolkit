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
  
##### >> [Cat\.UnitTesting\.Queries Assembly](index.md 'index') >> [Cat\.UnitTesting\.Queries Namespace](Cat.UnitTesting.Queries.md 'Cat\.UnitTesting\.Queries') >> [FakeQueryProcessor Class](FakeQueryProcessor.md 'Cat\.UnitTesting\.Queries\.FakeQueryProcessor')

## FakeQueryProcessor\.Respond Method

| Overloads | |
| :--- | :--- |
| [Respond&lt;TQuery,TQueryResult&gt;\(ICatResponse&lt;TQueryResult&gt;\)](FakeQueryProcessor.Respond.md#Cat.UnitTesting.Queries.FakeQueryProcessor.Respond_TQuery,TQueryResult_(Cat.Responses.Abstractions.ICatResponse_TQueryResult_) 'Cat\.UnitTesting\.Queries\.FakeQueryProcessor\.Respond\<TQuery,TQueryResult\>\(Cat\.Responses\.Abstractions\.ICatResponse\<TQueryResult\>\)') | Sets the response for a query type\. |
| [Respond&lt;TQuery,TQueryResult&gt;\(Func&lt;TQuery,ICatResponse&lt;TQueryResult&gt;&gt;\)](FakeQueryProcessor.Respond.md#Cat.UnitTesting.Queries.FakeQueryProcessor.Respond_TQuery,TQueryResult_(System.Func_TQuery,Cat.Responses.Abstractions.ICatResponse_TQueryResult__) 'Cat\.UnitTesting\.Queries\.FakeQueryProcessor\.Respond\<TQuery,TQueryResult\>\(System\.Func\<TQuery,Cat\.Responses\.Abstractions\.ICatResponse\<TQueryResult\>\>\)') | Sets the response for a query type, built from the query\. |

<a name='Cat.UnitTesting.Queries.FakeQueryProcessor.Respond_TQuery,TQueryResult_(Cat.Responses.Abstractions.ICatResponse_TQueryResult_)'></a>

## FakeQueryProcessor\.Respond\<TQuery,TQueryResult\>\(ICatResponse\<TQueryResult\>\) Method

Sets the response for a query type\.

```csharp
public Cat.UnitTesting.Queries.FakeQueryProcessor Respond<TQuery,TQueryResult>(Cat.Responses.Abstractions.ICatResponse<TQueryResult> response)
    where TQuery : Cat.Queries.Abstractions.ICatQuery<TQueryResult>;
```
#### Type parameters

<a name='Cat.UnitTesting.Queries.FakeQueryProcessor.Respond_TQuery,TQueryResult_(Cat.Responses.Abstractions.ICatResponse_TQueryResult_).TQuery'></a>

`TQuery`

The query type\.

<a name='Cat.UnitTesting.Queries.FakeQueryProcessor.Respond_TQuery,TQueryResult_(Cat.Responses.Abstractions.ICatResponse_TQueryResult_).TQueryResult'></a>

`TQueryResult`

The type of the data the query returns\.
#### Parameters

<a name='Cat.UnitTesting.Queries.FakeQueryProcessor.Respond_TQuery,TQueryResult_(Cat.Responses.Abstractions.ICatResponse_TQueryResult_).response'></a>

`response` [Cat\.Responses\.Abstractions\.ICatResponse&lt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[TQueryResult](FakeQueryProcessor.Respond.md#Cat.UnitTesting.Queries.FakeQueryProcessor.Respond_TQuery,TQueryResult_(Cat.Responses.Abstractions.ICatResponse_TQueryResult_).TQueryResult 'Cat\.UnitTesting\.Queries\.FakeQueryProcessor\.Respond\<TQuery,TQueryResult\>\(Cat\.Responses\.Abstractions\.ICatResponse\<TQueryResult\>\)\.TQueryResult')[&gt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')

The response every query of this type gets\.

#### Returns
[FakeQueryProcessor](FakeQueryProcessor.md 'Cat\.UnitTesting\.Queries\.FakeQueryProcessor')  
The fake, so calls can be chained\.

<a name='Cat.UnitTesting.Queries.FakeQueryProcessor.Respond_TQuery,TQueryResult_(System.Func_TQuery,Cat.Responses.Abstractions.ICatResponse_TQueryResult__)'></a>

## FakeQueryProcessor\.Respond\<TQuery,TQueryResult\>\(Func\<TQuery,ICatResponse\<TQueryResult\>\>\) Method

Sets the response for a query type, built from the query\.

```csharp
public Cat.UnitTesting.Queries.FakeQueryProcessor Respond<TQuery,TQueryResult>(System.Func<TQuery,Cat.Responses.Abstractions.ICatResponse<TQueryResult>> respond)
    where TQuery : Cat.Queries.Abstractions.ICatQuery<TQueryResult>;
```
#### Type parameters

<a name='Cat.UnitTesting.Queries.FakeQueryProcessor.Respond_TQuery,TQueryResult_(System.Func_TQuery,Cat.Responses.Abstractions.ICatResponse_TQueryResult__).TQuery'></a>

`TQuery`

The query type\.

<a name='Cat.UnitTesting.Queries.FakeQueryProcessor.Respond_TQuery,TQueryResult_(System.Func_TQuery,Cat.Responses.Abstractions.ICatResponse_TQueryResult__).TQueryResult'></a>

`TQueryResult`

The type of the data the query returns\.
#### Parameters

<a name='Cat.UnitTesting.Queries.FakeQueryProcessor.Respond_TQuery,TQueryResult_(System.Func_TQuery,Cat.Responses.Abstractions.ICatResponse_TQueryResult__).respond'></a>

`respond` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TQuery](FakeQueryProcessor.Respond.md#Cat.UnitTesting.Queries.FakeQueryProcessor.Respond_TQuery,TQueryResult_(System.Func_TQuery,Cat.Responses.Abstractions.ICatResponse_TQueryResult__).TQuery 'Cat\.UnitTesting\.Queries\.FakeQueryProcessor\.Respond\<TQuery,TQueryResult\>\(System\.Func\<TQuery,Cat\.Responses\.Abstractions\.ICatResponse\<TQueryResult\>\>\)\.TQuery')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[Cat\.Responses\.Abstractions\.ICatResponse&lt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[TQueryResult](FakeQueryProcessor.Respond.md#Cat.UnitTesting.Queries.FakeQueryProcessor.Respond_TQuery,TQueryResult_(System.Func_TQuery,Cat.Responses.Abstractions.ICatResponse_TQueryResult__).TQueryResult 'Cat\.UnitTesting\.Queries\.FakeQueryProcessor\.Respond\<TQuery,TQueryResult\>\(System\.Func\<TQuery,Cat\.Responses\.Abstractions\.ICatResponse\<TQueryResult\>\>\)\.TQueryResult')[&gt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

Builds the response from the query\.

#### Returns
[FakeQueryProcessor](FakeQueryProcessor.md 'Cat\.UnitTesting\.Queries\.FakeQueryProcessor')  
The fake, so calls can be chained\.