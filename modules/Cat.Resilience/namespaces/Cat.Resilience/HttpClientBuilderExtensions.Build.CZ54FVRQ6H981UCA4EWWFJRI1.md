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

## HttpClientBuilderExtensions\.Build\(ResiliencePipelineBuilder\<HttpResponseMessage\>, CatResilienceProfileOptions, TimeProvider\) Method

```csharp
private static void Build(ResiliencePipelineBuilder<System.Net.Http.HttpResponseMessage> pipeline, Cat.Resilience.Abstractions.CatResilienceProfileOptions profile, System.TimeProvider? timeProvider);
```
#### Parameters

<a name='Cat.Resilience.Extensions.HttpClientBuilderExtensions.Build(ResiliencePipelineBuilder_System.Net.Http.HttpResponseMessage_,Cat.Resilience.Abstractions.CatResilienceProfileOptions,System.TimeProvider).pipeline'></a>

`pipeline` [Polly\.ResiliencePipelineBuilder](https://learn.microsoft.com/en-us/dotnet/api/polly.resiliencepipelinebuilder 'Polly\.ResiliencePipelineBuilder')

<a name='Cat.Resilience.Extensions.HttpClientBuilderExtensions.Build(ResiliencePipelineBuilder_System.Net.Http.HttpResponseMessage_,Cat.Resilience.Abstractions.CatResilienceProfileOptions,System.TimeProvider).profile'></a>

`profile` [CatResilienceProfileOptions](../../../Cat.Resilience/namespaces/Cat.Resilience.Abstractions/CatResilienceProfileOptions.md 'Cat\.Resilience\.Abstractions\.CatResilienceProfileOptions')

<a name='Cat.Resilience.Extensions.HttpClientBuilderExtensions.Build(ResiliencePipelineBuilder_System.Net.Http.HttpResponseMessage_,Cat.Resilience.Abstractions.CatResilienceProfileOptions,System.TimeProvider).timeProvider'></a>

`timeProvider` [System\.TimeProvider](https://learn.microsoft.com/en-us/dotnet/api/system.timeprovider 'System\.TimeProvider')