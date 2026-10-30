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
  
##### >> [Cat\.Validators Assembly](index.md 'index') >> [Cat\.Validators Namespace](Cat.Validators.md 'Cat\.Validators') >> [CatValidatorPropertyRuleBuilder&lt;TModel,TProperty&gt; Class](CatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBuilder\<TModel,TProperty\>')

## CatValidatorPropertyRuleBuilder\<TModel,TProperty\>\.AddPropertyRule\<TRule\>\(TRule\) Method

Adds a rule for the property\.

```csharp
public Cat.Validators.Abstractions.ICatValidatorPropertyRuleOptionsBuilder<TModel,TProperty> AddPropertyRule<TRule>(TRule newRule)
    where TRule : class, Cat.Validators.Abstractions.ICatValidatorPropertyRule<TModel, TProperty>;
```
#### Type parameters

<a name='Cat.Validators.CatValidatorPropertyRuleBuilder_TModel,TProperty_.AddPropertyRule_TRule_(TRule).TRule'></a>

`TRule`

The type of the rule\.
#### Parameters

<a name='Cat.Validators.CatValidatorPropertyRuleBuilder_TModel,TProperty_.AddPropertyRule_TRule_(TRule).newRule'></a>

`newRule` [TRule](CatValidatorPropertyRuleBuilder_TModel,TProperty_.AddPropertyRule.GJPYMYZ3CAG1DRPIAUGCEKR48.md#Cat.Validators.CatValidatorPropertyRuleBuilder_TModel,TProperty_.AddPropertyRule_TRule_(TRule).TRule 'Cat\.Validators\.CatValidatorPropertyRuleBuilder\<TModel,TProperty\>\.AddPropertyRule\<TRule\>\(TRule\)\.TRule')

The rule to add\. It must derive from [CatValidatorPropertyRuleAsyncBase&lt;TModel,TProperty&gt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')\.

Implements [AddPropertyRule&lt;TRule&gt;\(TRule\)](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.AddPropertyRule.92X4EQSWUEP0Q3JRVU99M1Z89.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2\.AddPropertyRule\`\`1\(\`\`0\)')

#### Returns
[Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder&lt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')[TModel](CatValidatorPropertyRuleBuilder_TModel,TProperty_.md#Cat.Validators.CatValidatorPropertyRuleBuilder_TModel,TProperty_.TModel 'Cat\.Validators\.CatValidatorPropertyRuleBuilder\<TModel,TProperty\>\.TModel')[,](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')[TProperty](CatValidatorPropertyRuleBuilder_TModel,TProperty_.md#Cat.Validators.CatValidatorPropertyRuleBuilder_TModel,TProperty_.TProperty 'Cat\.Validators\.CatValidatorPropertyRuleBuilder\<TModel,TProperty\>\.TProperty')[&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')  
A builder for the rule options, like a condition or a custom message\.

#### Exceptions

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
The rule doesn't derive from [CatValidatorPropertyRuleAsyncBase&lt;TModel,TProperty&gt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')\.