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
  
##### >> [Cat\.Validators\.Abstractions Assembly](index.md 'index') >> [Cat\.Validators\.Abstractions Namespace](Cat.Validators.Abstractions.md 'Cat\.Validators\.Abstractions') >> [ICatValidatorBuilder&lt;TModel&gt; Interface](ICatValidatorBuilder_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorBuilder\<TModel\>')

## ICatValidatorBuilder\<TModel\>\.AddPropertyRules\<TProperty\>\(Expression\<Func\<TModel,TProperty\>\>, Action\<ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>\>\) Method

Adds rules for one property of the model\.

```csharp
Cat.Validators.Abstractions.ICatValidatorBuilder<TModel> AddPropertyRules<TProperty>(System.Linq.Expressions.Expression<System.Func<TModel,TProperty>> expression, System.Action<Cat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder<TModel,TProperty>> b);
```
#### Type parameters

<a name='Cat.Validators.Abstractions.ICatValidatorBuilder_TModel_.AddPropertyRules_TProperty_(System.Linq.Expressions.Expression_System.Func_TModel,TProperty__,System.Action_Cat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty__).TProperty'></a>

`TProperty`

The type of the property\.
#### Parameters

<a name='Cat.Validators.Abstractions.ICatValidatorBuilder_TModel_.AddPropertyRules_TProperty_(System.Linq.Expressions.Expression_System.Func_TModel,TProperty__,System.Action_Cat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty__).expression'></a>

`expression` [System\.Linq\.Expressions\.Expression&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')[System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TModel](ICatValidatorBuilder_TModel_.md#Cat.Validators.Abstractions.ICatValidatorBuilder_TModel_.TModel 'Cat\.Validators\.Abstractions\.ICatValidatorBuilder\<TModel\>\.TModel')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TProperty](ICatValidatorBuilder_TModel_.AddPropertyRules.4SGJLPHSDC95BLHV1D531FAK5.md#Cat.Validators.Abstractions.ICatValidatorBuilder_TModel_.AddPropertyRules_TProperty_(System.Linq.Expressions.Expression_System.Func_TModel,TProperty__,System.Action_Cat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty__).TProperty 'Cat\.Validators\.Abstractions\.ICatValidatorBuilder\<TModel\>\.AddPropertyRules\<TProperty\>\(System\.Linq\.Expressions\.Expression\<System\.Func\<TModel,TProperty\>\>, System\.Action\<Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>\>\)\.TProperty')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')

Picks the property, like `m => m.Name`\.

<a name='Cat.Validators.Abstractions.ICatValidatorBuilder_TModel_.AddPropertyRules_TProperty_(System.Linq.Expressions.Expression_System.Func_TModel,TProperty__,System.Action_Cat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty__).b'></a>

`b` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder&lt;](ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>')[TModel](ICatValidatorBuilder_TModel_.md#Cat.Validators.Abstractions.ICatValidatorBuilder_TModel_.TModel 'Cat\.Validators\.Abstractions\.ICatValidatorBuilder\<TModel\>\.TModel')[,](ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>')[TProperty](ICatValidatorBuilder_TModel_.AddPropertyRules.4SGJLPHSDC95BLHV1D531FAK5.md#Cat.Validators.Abstractions.ICatValidatorBuilder_TModel_.AddPropertyRules_TProperty_(System.Linq.Expressions.Expression_System.Func_TModel,TProperty__,System.Action_Cat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty__).TProperty 'Cat\.Validators\.Abstractions\.ICatValidatorBuilder\<TModel\>\.AddPropertyRules\<TProperty\>\(System\.Linq\.Expressions\.Expression\<System\.Func\<TModel,TProperty\>\>, System\.Action\<Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>\>\)\.TProperty')[&gt;](ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

Adds the rules to the given builder\.

#### Returns
[Cat\.Validators\.Abstractions\.ICatValidatorBuilder&lt;](ICatValidatorBuilder_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorBuilder\<TModel\>')[TModel](ICatValidatorBuilder_TModel_.md#Cat.Validators.Abstractions.ICatValidatorBuilder_TModel_.TModel 'Cat\.Validators\.Abstractions\.ICatValidatorBuilder\<TModel\>\.TModel')[&gt;](ICatValidatorBuilder_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorBuilder\<TModel\>')  
The same builder, so calls can be chained\.