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

|&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[CAT.VALIDATORS](../../README.md)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Validators\.Abstractions Assembly](index.md 'index') >> [Cat\.Validators\.Abstractions Namespace](Cat.Validators.Abstractions.md 'Cat\.Validators\.Abstractions') >> [ICatValidatorModelRuleBuilder&lt;TModel&gt; Interface](ICatValidatorModelRuleBuilder_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorModelRuleBuilder\<TModel\>')

## ICatValidatorModelRuleBuilder\<TModel\>\.AddRule\<TRule\>\(TRule\) Method

Adds a rule to the validator\.

```csharp
void AddRule<TRule>(TRule rule)
    where TRule : class, Cat.Validators.Abstractions.ICatValidatorModelRule<TModel>;
```
#### Type parameters

<a name='Cat.Validators.Abstractions.ICatValidatorModelRuleBuilder_TModel_.AddRule_TRule_(TRule).TRule'></a>

`TRule`

The type of the rule\.
#### Parameters

<a name='Cat.Validators.Abstractions.ICatValidatorModelRuleBuilder_TModel_.AddRule_TRule_(TRule).rule'></a>

`rule` [TRule](ICatValidatorModelRuleBuilder_TModel_.AddRule.NTZUA8M66NHJI05PHAP0R47G7.md#Cat.Validators.Abstractions.ICatValidatorModelRuleBuilder_TModel_.AddRule_TRule_(TRule).TRule 'Cat\.Validators\.Abstractions\.ICatValidatorModelRuleBuilder\<TModel\>\.AddRule\<TRule\>\(TRule\)\.TRule')

The rule to add\.