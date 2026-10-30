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

|&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[CAT.FLUENTWORKFLOWS](../../README.md)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.FluentWorkflows\.Queries Assembly](index.md 'index') >> [Cat\.FluentWorkflows\.Queries\.Steps Namespace](Cat.FluentWorkflows.Queries.Steps.md 'Cat\.FluentWorkflows\.Queries\.Steps')

## CatProcessQueryStep\<TQuery,TResult\> Class

Built\-in step behind `ProcessQuery`\. It processes a query with the query processor\.
A succeeded query continues the workflow\. A failed query ends it with BreakCascade and the errors\.

```csharp
public class CatProcessQueryStep<TQuery,TResult> : Cat.FluentWorkflows.CatStepBodyAsync
    where TQuery : class, Cat.Queries.Abstractions.ICatQuery<TResult>
```
#### Type parameters

<a name='Cat.FluentWorkflows.Queries.Steps.CatProcessQueryStep_TQuery,TResult_.TQuery'></a>

`TQuery`

The query to process\.

<a name='Cat.FluentWorkflows.Queries.Steps.CatProcessQueryStep_TQuery,TResult_.TResult'></a>

`TResult`

The type of the data the query returns\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [CatStepBodyAsync](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows/CatStepBodyAsync.md 'Cat\.FluentWorkflows\.CatStepBodyAsync') → CatProcessQueryStep\<TQuery,TResult\>

| Constructors | |
| :--- | :--- |
| [CatProcessQueryStep\(ICatQueryProcessor, ILogger&lt;CatProcessQueryStep&lt;TQuery,TResult&gt;&gt;\)](CatProcessQueryStep_TQuery,TResult_..ctor.S1ZP809HZME140VRVUHNT3K17.md 'Cat\.FluentWorkflows\.Queries\.Steps\.CatProcessQueryStep\<TQuery,TResult\>\.CatProcessQueryStep\(Cat\.Queries\.Abstractions\.ICatQueryProcessor, Microsoft\.Extensions\.Logging\.ILogger\<Cat\.FluentWorkflows\.Queries\.Steps\.CatProcessQueryStep\<TQuery,TResult\>\>\)') | Creates the step and the query, using the parameterless constructor of the query\. |

| Fields | |
| :--- | :--- |
| [\_queryProcessor](CatProcessQueryStep_TQuery,TResult_._queryProcessor.md 'Cat\.FluentWorkflows\.Queries\.Steps\.CatProcessQueryStep\<TQuery,TResult\>\.\_queryProcessor') | |

| Properties | |
| :--- | :--- |
| [Query](CatProcessQueryStep_TQuery,TResult_.Query.md 'Cat\.FluentWorkflows\.Queries\.Steps\.CatProcessQueryStep\<TQuery,TResult\>\.Query') | The query to process\. Fill its members with `Input`\. |
| [Response](CatProcessQueryStep_TQuery,TResult_.Response.md 'Cat\.FluentWorkflows\.Queries\.Steps\.CatProcessQueryStep\<TQuery,TResult\>\.Response') | The response of the query\. Read it with `Output` after the step ran\. |

| Methods | |
| :--- | :--- |
| [RunAsync\(CancellationToken\)](CatProcessQueryStep_TQuery,TResult_.RunAsync.H6NR5NC8VYYIJ2M5DCA4498Q6.md 'Cat\.FluentWorkflows\.Queries\.Steps\.CatProcessQueryStep\<TQuery,TResult\>\.RunAsync\(System\.Threading\.CancellationToken\)') | Runs the step\. |
