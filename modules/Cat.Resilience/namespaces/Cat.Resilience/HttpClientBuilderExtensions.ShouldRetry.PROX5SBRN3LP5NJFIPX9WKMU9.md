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
  
##### >> [Cat\.Resilience Assembly](index.md 'index') >> [Cat\.Resilience\.Extensions Namespace](Cat.Resilience.Extensions.md 'Cat\.Resilience\.Extensions') >> [HttpClientBuilderExtensions Class](HttpClientBuilderExtensions.md 'Cat\.Resilience\.Extensions\.HttpClientBuilderExtensions')

## HttpClientBuilderExtensions\.ShouldRetry\(RetryPredicateArguments\<HttpResponseMessage\>, CatRetryOptions\) Method

```csharp
private static bool ShouldRetry(RetryPredicateArguments<System.Net.Http.HttpResponseMessage> args, Cat.Resilience.Abstractions.CatRetryOptions retry);
```
#### Parameters

<a name='Cat.Resilience.Extensions.HttpClientBuilderExtensions.ShouldRetry(RetryPredicateArguments_System.Net.Http.HttpResponseMessage_,Cat.Resilience.Abstractions.CatRetryOptions).args'></a>

`args` [Polly\.Retry\.RetryPredicateArguments](https://learn.microsoft.com/en-us/dotnet/api/polly.retry.retrypredicatearguments 'Polly\.Retry\.RetryPredicateArguments')

<a name='Cat.Resilience.Extensions.HttpClientBuilderExtensions.ShouldRetry(RetryPredicateArguments_System.Net.Http.HttpResponseMessage_,Cat.Resilience.Abstractions.CatRetryOptions).retry'></a>

`retry` [CatRetryOptions](../../../Cat.Resilience/namespaces/Cat.Resilience.Abstractions/CatRetryOptions.md 'Cat\.Resilience\.Abstractions\.CatRetryOptions')

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')