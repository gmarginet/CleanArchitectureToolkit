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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.VALIDATORS](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Validators Assembly](index.md 'index') >> [Cat\.Validators Namespace](Cat.Validators.md 'Cat\.Validators') >> [CatValidatorModelRuleBuilder&lt;TModel&gt; Class](CatValidatorModelRuleBuilder_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleBuilder\<TModel\>')

## CatValidatorModelRuleBuilder\(ConcurrentQueue\<ICatValidatorModelRule\<TModel\>\>\) Constructor

Default [ICatValidatorModelRuleBuilder&lt;TModel&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorModelRuleBuilder_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorModelRuleBuilder\`1')\.

```csharp
public CatValidatorModelRuleBuilder(System.Collections.Concurrent.ConcurrentQueue<Cat.Validators.Abstractions.ICatValidatorModelRule<TModel>> rules);
```
#### Parameters

<a name='Cat.Validators.CatValidatorModelRuleBuilder_TModel_.CatValidatorModelRuleBuilder(System.Collections.Concurrent.ConcurrentQueue_Cat.Validators.Abstractions.ICatValidatorModelRule_TModel__).rules'></a>

`rules` [System\.Collections\.Concurrent\.ConcurrentQueue&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.concurrent.concurrentqueue-1 'System\.Collections\.Concurrent\.ConcurrentQueue\`1')[Cat\.Validators\.Abstractions\.ICatValidatorModelRule&lt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorModelRule_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorModelRule\`1')[TModel](CatValidatorModelRuleBuilder_TModel_.md#Cat.Validators.CatValidatorModelRuleBuilder_TModel_.TModel 'Cat\.Validators\.CatValidatorModelRuleBuilder\<TModel\>\.TModel')[&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorModelRule_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorModelRule\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.concurrent.concurrentqueue-1 'System\.Collections\.Concurrent\.ConcurrentQueue\`1')