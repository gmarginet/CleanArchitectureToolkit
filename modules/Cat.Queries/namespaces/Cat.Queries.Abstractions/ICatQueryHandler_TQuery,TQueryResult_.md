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

## ICatQueryHandler\<TQuery,TQueryResult\> Interface

Handles one kind of query\.
Implement it once per query type\. The module finds and registers it for you\.

```csharp
public interface ICatQueryHandler<in TQuery,TQueryResult>
    where TQuery : class, Cat.Queries.Abstractions.ICatQuery<TQueryResult>
```
#### Type parameters

<a name='Cat.Queries.Abstractions.ICatQueryHandler_TQuery,TQueryResult_.TQuery'></a>

`TQuery`

The query this handler can answer\.

<a name='Cat.Queries.Abstractions.ICatQueryHandler_TQuery,TQueryResult_.TQueryResult'></a>

`TQueryResult`

The type of the data the handler returns\.

| Methods | |
| :--- | :--- |
| [HandleAsync\(TQuery, CancellationToken\)](ICatQueryHandler_TQuery,TQueryResult_.HandleAsync.569S9MAD4IYXQV8MCHY5U72UA.md 'Cat\.Queries\.Abstractions\.ICatQueryHandler\<TQuery,TQueryResult\>\.HandleAsync\(TQuery, System\.Threading\.CancellationToken\)') | Runs the query\. |
