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
            <img src='../../../../resources/logo/CatLogo-RoundedCorners-320x160.png' alt='' width='200' style='float: right;'/>
        </td>
    </tr>
    <tr>
        <td colspan='6' markdown='1' style='padding-left: 0; padding-right: 0; padding-top: 15px; padding-bottom: 0; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>

|&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[CAT.VALIDATORS](../../README.md)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Validators Assembly](index.md 'index') >> [Cat\.Validators Namespace](Cat.Validators.md 'Cat\.Validators') >> [CatValidatorBuilder&lt;TModel&gt; Class](CatValidatorBuilder_TModel_.md 'Cat\.Validators\.CatValidatorBuilder\<TModel\>')

## CatValidatorBuilder\<TModel\>\.AddRules\(Action\<ICatValidatorModelRuleBuilder\<TModel\>\>\) Method

Adds rules that look at the whole model\.

```csharp
public Cat.Validators.Abstractions.ICatValidatorBuilder<TModel> AddRules(System.Action<Cat.Validators.Abstractions.ICatValidatorModelRuleBuilder<TModel>> build);
```
#### Parameters

<a name='Cat.Validators.CatValidatorBuilder_TModel_.AddRules(System.Action_Cat.Validators.Abstractions.ICatValidatorModelRuleBuilder_TModel__).build'></a>

`build` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[Cat\.Validators\.Abstractions\.ICatValidatorModelRuleBuilder&lt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorModelRuleBuilder_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorModelRuleBuilder\`1')[TModel](CatValidatorBuilder_TModel_.md#Cat.Validators.CatValidatorBuilder_TModel_.TModel 'Cat\.Validators\.CatValidatorBuilder\<TModel\>\.TModel')[&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorModelRuleBuilder_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorModelRuleBuilder\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

Implements [AddRules\(Action&lt;ICatValidatorModelRuleBuilder&lt;TModel&gt;&gt;\)](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorBuilder_TModel_.AddRules.7LVEP6J7EA1YDLNO2MIA8L6N1.md 'Cat\.Validators\.Abstractions\.ICatValidatorBuilder\`1\.AddRules\(System\.Action\{Cat\.Validators\.Abstractions\.ICatValidatorModelRuleBuilder\{\`0\}\}\)')

#### Returns
[Cat\.Validators\.Abstractions\.ICatValidatorBuilder&lt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorBuilder_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorBuilder\`1')[TModel](CatValidatorBuilder_TModel_.md#Cat.Validators.CatValidatorBuilder_TModel_.TModel 'Cat\.Validators\.CatValidatorBuilder\<TModel\>\.TModel')[&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorBuilder_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorBuilder\`1')  
The same builder, so calls can be chained\.