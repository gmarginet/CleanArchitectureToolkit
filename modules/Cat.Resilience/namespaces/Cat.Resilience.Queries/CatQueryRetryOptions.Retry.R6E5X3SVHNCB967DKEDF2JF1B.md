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
  
##### >> [Cat\.Resilience\.Queries Assembly](index.md 'index') >> [Cat\.Resilience\.Queries Namespace](Cat.Resilience.Queries.md 'Cat\.Resilience\.Queries') >> [CatQueryRetryOptions Class](CatQueryRetryOptions.md 'Cat\.Resilience\.Queries\.CatQueryRetryOptions')

## CatQueryRetryOptions\.Retry\<TQuery\>\(string, Action\<CatRetryRule\>\) Method

Retries a query type through a resilience profile\. Every other query is called once\.

```csharp
public Cat.Resilience.Queries.CatQueryRetryOptions Retry<TQuery>(string profile="Internal", System.Action<Cat.Resilience.Queries.CatRetryRule>? configure=null)
    where TQuery : class;
```
#### Type parameters

<a name='Cat.Resilience.Queries.CatQueryRetryOptions.Retry_TQuery_(string,System.Action_Cat.Resilience.Queries.CatRetryRule_).TQuery'></a>

`TQuery`

The query type, which implements `ICatQuery<TQueryResult>`\.
#### Parameters

<a name='Cat.Resilience.Queries.CatQueryRetryOptions.Retry_TQuery_(string,System.Action_Cat.Resilience.Queries.CatRetryRule_).profile'></a>

`profile` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the profile\. The default is [Internal](../../../Cat.Resilience/namespaces/Cat.Resilience.Abstractions/CatResilienceProfile.Internal.md 'Cat\.Resilience\.Abstractions\.CatResilienceProfile\.Internal')\.

<a name='Cat.Resilience.Queries.CatQueryRetryOptions.Retry_TQuery_(string,System.Action_Cat.Resilience.Queries.CatRetryRule_).configure'></a>

`configure` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[CatRetryRule](CatRetryRule.md 'Cat\.Resilience\.Queries\.CatRetryRule')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

Changes which failed responses are tried again\. Optional\.

#### Returns
[CatQueryRetryOptions](CatQueryRetryOptions.md 'Cat\.Resilience\.Queries\.CatQueryRetryOptions')  
The same options, for chaining\.

#### Exceptions

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
The type is not a query\.