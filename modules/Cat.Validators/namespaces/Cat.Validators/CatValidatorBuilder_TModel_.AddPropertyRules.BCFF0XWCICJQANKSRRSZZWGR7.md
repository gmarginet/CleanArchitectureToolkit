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

## CatValidatorBuilder\<TModel\>\.AddPropertyRules\<TProperty\>\(Expression\<Func\<TModel,TProperty\>\>, Action\<ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>\>\) Method

Adds rules for one property of the model\.

```csharp
public Cat.Validators.Abstractions.ICatValidatorBuilder<TModel> AddPropertyRules<TProperty>(System.Linq.Expressions.Expression<System.Func<TModel,TProperty>> expression, System.Action<Cat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder<TModel,TProperty>> build);
```
#### Type parameters

<a name='Cat.Validators.CatValidatorBuilder_TModel_.AddPropertyRules_TProperty_(System.Linq.Expressions.Expression_System.Func_TModel,TProperty__,System.Action_Cat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty__).TProperty'></a>

`TProperty`

The type of the property\.
#### Parameters

<a name='Cat.Validators.CatValidatorBuilder_TModel_.AddPropertyRules_TProperty_(System.Linq.Expressions.Expression_System.Func_TModel,TProperty__,System.Action_Cat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty__).expression'></a>

`expression` [System\.Linq\.Expressions\.Expression&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')[System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TModel](CatValidatorBuilder_TModel_.md#Cat.Validators.CatValidatorBuilder_TModel_.TModel 'Cat\.Validators\.CatValidatorBuilder\<TModel\>\.TModel')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TProperty](CatValidatorBuilder_TModel_.AddPropertyRules.BCFF0XWCICJQANKSRRSZZWGR7.md#Cat.Validators.CatValidatorBuilder_TModel_.AddPropertyRules_TProperty_(System.Linq.Expressions.Expression_System.Func_TModel,TProperty__,System.Action_Cat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty__).TProperty 'Cat\.Validators\.CatValidatorBuilder\<TModel\>\.AddPropertyRules\<TProperty\>\(System\.Linq\.Expressions\.Expression\<System\.Func\<TModel,TProperty\>\>, System\.Action\<Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>\>\)\.TProperty')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')

Picks the property, like `m => m.Name`\.

<a name='Cat.Validators.CatValidatorBuilder_TModel_.AddPropertyRules_TProperty_(System.Linq.Expressions.Expression_System.Func_TModel,TProperty__,System.Action_Cat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty__).build'></a>

`build` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder&lt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[TModel](CatValidatorBuilder_TModel_.md#Cat.Validators.CatValidatorBuilder_TModel_.TModel 'Cat\.Validators\.CatValidatorBuilder\<TModel\>\.TModel')[,](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[TProperty](CatValidatorBuilder_TModel_.AddPropertyRules.BCFF0XWCICJQANKSRRSZZWGR7.md#Cat.Validators.CatValidatorBuilder_TModel_.AddPropertyRules_TProperty_(System.Linq.Expressions.Expression_System.Func_TModel,TProperty__,System.Action_Cat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty__).TProperty 'Cat\.Validators\.CatValidatorBuilder\<TModel\>\.AddPropertyRules\<TProperty\>\(System\.Linq\.Expressions\.Expression\<System\.Func\<TModel,TProperty\>\>, System\.Action\<Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>\>\)\.TProperty')[&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

Implements [AddPropertyRules&lt;TProperty&gt;\(Expression&lt;Func&lt;TModel,TProperty&gt;&gt;, Action&lt;ICatValidatorPropertyRuleBuilder&lt;TModel,TProperty&gt;&gt;\)](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorBuilder_TModel_.AddPropertyRules.4SGJLPHSDC95BLHV1D531FAK5.md 'Cat\.Validators\.Abstractions\.ICatValidatorBuilder\`1\.AddPropertyRules\`\`1\(System\.Linq\.Expressions\.Expression\{System\.Func\{\`0,\`\`0\}\},System\.Action\{Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\{\`0,\`\`0\}\}\)')

#### Returns
[Cat\.Validators\.Abstractions\.ICatValidatorBuilder&lt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorBuilder_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorBuilder\`1')[TModel](CatValidatorBuilder_TModel_.md#Cat.Validators.CatValidatorBuilder_TModel_.TModel 'Cat\.Validators\.CatValidatorBuilder\<TModel\>\.TModel')[&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorBuilder_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorBuilder\`1')  
The same builder, so calls can be chained\.