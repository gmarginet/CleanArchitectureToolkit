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
  
##### >> [Cat\.Validators Assembly](index.md 'index') >> [Cat\.Validators Namespace](Cat.Validators.md 'Cat\.Validators')

## CatValidatorPropertyRuleBuilder\<TModel,TProperty\> Class

Default [ICatValidatorPropertyRuleBuilder&lt;TModel,TProperty&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')\.
Hands each new rule the property expression, the expression cache and the processor\.

```csharp
public class CatValidatorPropertyRuleBuilder<TModel,TProperty> : Cat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder<TModel, TProperty>
    where TModel : class
```
#### Type parameters

<a name='Cat.Validators.CatValidatorPropertyRuleBuilder_TModel,TProperty_.TModel'></a>

`TModel`

The type being validated\.

<a name='Cat.Validators.CatValidatorPropertyRuleBuilder_TModel,TProperty_.TProperty'></a>

`TProperty`

The type of the property\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatValidatorPropertyRuleBuilder\<TModel,TProperty\>

Implements [Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder&lt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[TModel](CatValidatorPropertyRuleBuilder_TModel,TProperty_.md#Cat.Validators.CatValidatorPropertyRuleBuilder_TModel,TProperty_.TModel 'Cat\.Validators\.CatValidatorPropertyRuleBuilder\<TModel,TProperty\>\.TModel')[,](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[TProperty](CatValidatorPropertyRuleBuilder_TModel,TProperty_.md#Cat.Validators.CatValidatorPropertyRuleBuilder_TModel,TProperty_.TProperty 'Cat\.Validators\.CatValidatorPropertyRuleBuilder\<TModel,TProperty\>\.TProperty')[&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')

| Constructors | |
| :--- | :--- |
| [CatValidatorPropertyRuleBuilder\(ConcurrentQueue&lt;ICatValidatorModelRule&lt;TModel&gt;&gt;, Expression&lt;Func&lt;TModel,TProperty&gt;&gt;, ICatCompiledMemberExpressionCache&lt;TModel&gt;, CatValidatorProcessor, bool\)](CatValidatorPropertyRuleBuilder_TModel,TProperty_..ctor.O8USH1JIWMDDZ9EFQH9D80MG9.md 'Cat\.Validators\.CatValidatorPropertyRuleBuilder\<TModel,TProperty\>\.CatValidatorPropertyRuleBuilder\(System\.Collections\.Concurrent\.ConcurrentQueue\<Cat\.Validators\.Abstractions\.ICatValidatorModelRule\<TModel\>\>, System\.Linq\.Expressions\.Expression\<System\.Func\<TModel,TProperty\>\>, Cat\.Expressions\.Abstractions\.ICatCompiledMemberExpressionCache\<TModel\>, Cat\.Validators\.CatValidatorProcessor, bool\)') | Default [ICatValidatorPropertyRuleBuilder&lt;TModel,TProperty&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')\. Hands each new rule the property expression, the expression cache and the processor\. |

| Methods | |
| :--- | :--- |
| [AddPropertyRule&lt;TRule&gt;\(TRule\)](CatValidatorPropertyRuleBuilder_TModel,TProperty_.AddPropertyRule.GJPYMYZ3CAG1DRPIAUGCEKR48.md 'Cat\.Validators\.CatValidatorPropertyRuleBuilder\<TModel,TProperty\>\.AddPropertyRule\<TRule\>\(TRule\)') | Adds a rule for the property\. |
