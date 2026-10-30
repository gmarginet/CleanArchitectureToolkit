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
  
##### >> [Cat\.Validators\.Abstractions Assembly](index.md 'index') >> [Cat\.Validators\.Abstractions Namespace](Cat.Validators.Abstractions.md 'Cat\.Validators\.Abstractions') >> [ICatValidatorPropertyRuleBuilder&lt;TModel,TProperty&gt; Interface](ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>')

## ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>\.AddPropertyRule\<TRule\>\(TRule\) Method

Adds a rule for the property\.

```csharp
Cat.Validators.Abstractions.ICatValidatorPropertyRuleOptionsBuilder<TModel,TProperty> AddPropertyRule<TRule>(TRule rule)
    where TRule : class, Cat.Validators.Abstractions.ICatValidatorPropertyRule<TModel, TProperty>;
```
#### Type parameters

<a name='Cat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_.AddPropertyRule_TRule_(TRule).TRule'></a>

`TRule`

The type of the rule\.
#### Parameters

<a name='Cat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_.AddPropertyRule_TRule_(TRule).rule'></a>

`rule` [TRule](ICatValidatorPropertyRuleBuilder_TModel,TProperty_.AddPropertyRule.92X4EQSWUEP0Q3JRVU99M1Z89.md#Cat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_.AddPropertyRule_TRule_(TRule).TRule 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>\.AddPropertyRule\<TRule\>\(TRule\)\.TRule')

The rule to add\.

#### Returns
[Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder&lt;](ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\<TModel,TProperty\>')[TModel](ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md#Cat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_.TModel 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>\.TModel')[,](ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\<TModel,TProperty\>')[TProperty](ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md#Cat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_.TProperty 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>\.TProperty')[&gt;](ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\<TModel,TProperty\>')  
A builder for the rule options, like a condition or a custom message\.