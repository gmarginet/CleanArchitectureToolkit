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
  
##### >> [Cat\.Resilience\.Commands Assembly](index.md 'index') >> [Cat\.Resilience\.Commands Namespace](Cat.Resilience.Commands.md 'Cat\.Resilience\.Commands') >> [CatRetryRule Class](CatRetryRule.md 'Cat\.Resilience\.Commands\.CatRetryRule')

## CatRetryRule\.NeverRetryOn\<TFailure\>\(\) Method

Never tries again on this failed response type, and returns the response at once\.

```csharp
public Cat.Resilience.Commands.CatRetryRule NeverRetryOn<TFailure>()
    where TFailure : Cat.Responses.Abstractions.CatResponseType.Failed;
```
#### Type parameters

<a name='Cat.Resilience.Commands.CatRetryRule.NeverRetryOn_TFailure_().TFailure'></a>

`TFailure`

The failed response type, such as [InternalServerError](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.Failed.InternalServerError.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Failed\.InternalServerError')\.

#### Returns
[CatRetryRule](CatRetryRule.md 'Cat\.Resilience\.Commands\.CatRetryRule')  
The same rule, for chaining\.