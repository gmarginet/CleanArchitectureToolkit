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
  
##### >> [Cat\.Validators Assembly](index.md 'index') >> [Cat\.Validators Namespace](Cat.Validators.md 'Cat\.Validators')

## CatValidatorModelRuleAsyncBase\<TModel\> Class

Base class for a model rule that needs async work\.
Derive from it when you write your own rule\. Use [CatValidatorModelRuleBase&lt;TModel&gt;](CatValidatorModelRuleBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleBase\<TModel\>') for sync work\.

```csharp
public abstract class CatValidatorModelRuleAsyncBase<TModel> : Cat.Validators.Abstractions.ICatValidatorModelRule<TModel>
    where TModel : class
```
#### Type parameters

<a name='Cat.Validators.CatValidatorModelRuleAsyncBase_TModel_.TModel'></a>

`TModel`

The type being validated\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatValidatorModelRuleAsyncBase\<TModel\>

Derived  
↳ [CatValidatorModelRuleBase&lt;TModel&gt;](CatValidatorModelRuleBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleBase\<TModel\>')  
↳ [CatValidatorPropertyRuleAsyncBase&lt;TModel,TProperty&gt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')  
↳ [ModelMustAsyncValidatorRule&lt;TModel&gt;](ModelMustAsyncValidatorRule_TModel_.md 'Cat\.Validators\.Rules\.ModelMustAsyncValidatorRule\<TModel\>')

Implements [Cat\.Validators\.Abstractions\.ICatValidatorModelRule&lt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorModelRule_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorModelRule\`1')[TModel](CatValidatorModelRuleAsyncBase_TModel_.md#Cat.Validators.CatValidatorModelRuleAsyncBase_TModel_.TModel 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>\.TModel')[&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorModelRule_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorModelRule\`1')

| Properties | |
| :--- | :--- |
| [RulesConditionFuncAsyncList](CatValidatorModelRuleAsyncBase_TModel_.RulesConditionFuncAsyncList.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>\.RulesConditionFuncAsyncList') | Conditions that decide whether the rule runs\. The rule is skipped when any of them returns `false`\. |

| Methods | |
| :--- | :--- |
| [ValidateAsync\(TModel, CancellationToken\)](CatValidatorModelRuleAsyncBase_TModel_.ValidateAsync.SJ8T3ZY2PGV2DCY11AQNS4WO4.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>\.ValidateAsync\(TModel, System\.Threading\.CancellationToken\)') | Runs the rule\. |
