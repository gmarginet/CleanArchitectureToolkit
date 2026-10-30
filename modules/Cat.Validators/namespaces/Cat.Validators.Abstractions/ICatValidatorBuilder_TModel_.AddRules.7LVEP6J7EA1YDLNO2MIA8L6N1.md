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
  
##### >> [Cat\.Validators\.Abstractions Assembly](index.md 'index') >> [Cat\.Validators\.Abstractions Namespace](Cat.Validators.Abstractions.md 'Cat\.Validators\.Abstractions') >> [ICatValidatorBuilder&lt;TModel&gt; Interface](ICatValidatorBuilder_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorBuilder\<TModel\>')

## ICatValidatorBuilder\<TModel\>\.AddRules\(Action\<ICatValidatorModelRuleBuilder\<TModel\>\>\) Method

Adds rules that look at the whole model\.

```csharp
Cat.Validators.Abstractions.ICatValidatorBuilder<TModel> AddRules(System.Action<Cat.Validators.Abstractions.ICatValidatorModelRuleBuilder<TModel>> b);
```
#### Parameters

<a name='Cat.Validators.Abstractions.ICatValidatorBuilder_TModel_.AddRules(System.Action_Cat.Validators.Abstractions.ICatValidatorModelRuleBuilder_TModel__).b'></a>

`b` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[Cat\.Validators\.Abstractions\.ICatValidatorModelRuleBuilder&lt;](ICatValidatorModelRuleBuilder_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorModelRuleBuilder\<TModel\>')[TModel](ICatValidatorBuilder_TModel_.md#Cat.Validators.Abstractions.ICatValidatorBuilder_TModel_.TModel 'Cat\.Validators\.Abstractions\.ICatValidatorBuilder\<TModel\>\.TModel')[&gt;](ICatValidatorModelRuleBuilder_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorModelRuleBuilder\<TModel\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

Adds the rules to the given builder\.

#### Returns
[Cat\.Validators\.Abstractions\.ICatValidatorBuilder&lt;](ICatValidatorBuilder_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorBuilder\<TModel\>')[TModel](ICatValidatorBuilder_TModel_.md#Cat.Validators.Abstractions.ICatValidatorBuilder_TModel_.TModel 'Cat\.Validators\.Abstractions\.ICatValidatorBuilder\<TModel\>\.TModel')[&gt;](ICatValidatorBuilder_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorBuilder\<TModel\>')  
The same builder, so calls can be chained\.