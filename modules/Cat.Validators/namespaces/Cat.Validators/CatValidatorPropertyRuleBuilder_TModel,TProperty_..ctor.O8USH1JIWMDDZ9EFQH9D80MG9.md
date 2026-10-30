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
  
##### >> [Cat\.Validators Assembly](index.md 'index') >> [Cat\.Validators Namespace](Cat.Validators.md 'Cat\.Validators') >> [CatValidatorPropertyRuleBuilder&lt;TModel,TProperty&gt; Class](CatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBuilder\<TModel,TProperty\>')

## CatValidatorPropertyRuleBuilder\(ConcurrentQueue\<ICatValidatorModelRule\<TModel\>\>, Expression\<Func\<TModel,TProperty\>\>, ICatCompiledMemberExpressionCache\<TModel\>, CatValidatorProcessor, bool\) Constructor

Default [ICatValidatorPropertyRuleBuilder&lt;TModel,TProperty&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')\.
Hands each new rule the property expression, the expression cache and the processor\.

```csharp
public CatValidatorPropertyRuleBuilder(System.Collections.Concurrent.ConcurrentQueue<Cat.Validators.Abstractions.ICatValidatorModelRule<TModel>> rules, System.Linq.Expressions.Expression<System.Func<TModel,TProperty>> propertyExpression, Cat.Expressions.Abstractions.ICatCompiledMemberExpressionCache<TModel> compiledMemberExpressionCache, Cat.Validators.CatValidatorProcessor validatorProcessor, bool validatorRequired=true);
```
#### Parameters

<a name='Cat.Validators.CatValidatorPropertyRuleBuilder_TModel,TProperty_.CatValidatorPropertyRuleBuilder(System.Collections.Concurrent.ConcurrentQueue_Cat.Validators.Abstractions.ICatValidatorModelRule_TModel__,System.Linq.Expressions.Expression_System.Func_TModel,TProperty__,Cat.Expressions.Abstractions.ICatCompiledMemberExpressionCache_TModel_,Cat.Validators.CatValidatorProcessor,bool).rules'></a>

`rules` [System\.Collections\.Concurrent\.ConcurrentQueue&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.concurrent.concurrentqueue-1 'System\.Collections\.Concurrent\.ConcurrentQueue\`1')[Cat\.Validators\.Abstractions\.ICatValidatorModelRule&lt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorModelRule_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorModelRule\`1')[TModel](CatValidatorPropertyRuleBuilder_TModel,TProperty_.md#Cat.Validators.CatValidatorPropertyRuleBuilder_TModel,TProperty_.TModel 'Cat\.Validators\.CatValidatorPropertyRuleBuilder\<TModel,TProperty\>\.TModel')[&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorModelRule_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorModelRule\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.concurrent.concurrentqueue-1 'System\.Collections\.Concurrent\.ConcurrentQueue\`1')

<a name='Cat.Validators.CatValidatorPropertyRuleBuilder_TModel,TProperty_.CatValidatorPropertyRuleBuilder(System.Collections.Concurrent.ConcurrentQueue_Cat.Validators.Abstractions.ICatValidatorModelRule_TModel__,System.Linq.Expressions.Expression_System.Func_TModel,TProperty__,Cat.Expressions.Abstractions.ICatCompiledMemberExpressionCache_TModel_,Cat.Validators.CatValidatorProcessor,bool).propertyExpression'></a>

`propertyExpression` [System\.Linq\.Expressions\.Expression&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')[System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TModel](CatValidatorPropertyRuleBuilder_TModel,TProperty_.md#Cat.Validators.CatValidatorPropertyRuleBuilder_TModel,TProperty_.TModel 'Cat\.Validators\.CatValidatorPropertyRuleBuilder\<TModel,TProperty\>\.TModel')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TProperty](CatValidatorPropertyRuleBuilder_TModel,TProperty_.md#Cat.Validators.CatValidatorPropertyRuleBuilder_TModel,TProperty_.TProperty 'Cat\.Validators\.CatValidatorPropertyRuleBuilder\<TModel,TProperty\>\.TProperty')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')

<a name='Cat.Validators.CatValidatorPropertyRuleBuilder_TModel,TProperty_.CatValidatorPropertyRuleBuilder(System.Collections.Concurrent.ConcurrentQueue_Cat.Validators.Abstractions.ICatValidatorModelRule_TModel__,System.Linq.Expressions.Expression_System.Func_TModel,TProperty__,Cat.Expressions.Abstractions.ICatCompiledMemberExpressionCache_TModel_,Cat.Validators.CatValidatorProcessor,bool).compiledMemberExpressionCache'></a>

`compiledMemberExpressionCache` [Cat\.Expressions\.Abstractions\.ICatCompiledMemberExpressionCache&lt;](../../../Cat.Expressions/namespaces/Cat.Expressions.Abstractions/ICatCompiledMemberExpressionCache_T_.md 'Cat\.Expressions\.Abstractions\.ICatCompiledMemberExpressionCache\`1')[TModel](CatValidatorPropertyRuleBuilder_TModel,TProperty_.md#Cat.Validators.CatValidatorPropertyRuleBuilder_TModel,TProperty_.TModel 'Cat\.Validators\.CatValidatorPropertyRuleBuilder\<TModel,TProperty\>\.TModel')[&gt;](../../../Cat.Expressions/namespaces/Cat.Expressions.Abstractions/ICatCompiledMemberExpressionCache_T_.md 'Cat\.Expressions\.Abstractions\.ICatCompiledMemberExpressionCache\`1')

<a name='Cat.Validators.CatValidatorPropertyRuleBuilder_TModel,TProperty_.CatValidatorPropertyRuleBuilder(System.Collections.Concurrent.ConcurrentQueue_Cat.Validators.Abstractions.ICatValidatorModelRule_TModel__,System.Linq.Expressions.Expression_System.Func_TModel,TProperty__,Cat.Expressions.Abstractions.ICatCompiledMemberExpressionCache_TModel_,Cat.Validators.CatValidatorProcessor,bool).validatorProcessor'></a>

`validatorProcessor` [CatValidatorProcessor](CatValidatorProcessor.md 'Cat\.Validators\.CatValidatorProcessor')

<a name='Cat.Validators.CatValidatorPropertyRuleBuilder_TModel,TProperty_.CatValidatorPropertyRuleBuilder(System.Collections.Concurrent.ConcurrentQueue_Cat.Validators.Abstractions.ICatValidatorModelRule_TModel__,System.Linq.Expressions.Expression_System.Func_TModel,TProperty__,Cat.Expressions.Abstractions.ICatCompiledMemberExpressionCache_TModel_,Cat.Validators.CatValidatorProcessor,bool).validatorRequired'></a>

`validatorRequired` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')