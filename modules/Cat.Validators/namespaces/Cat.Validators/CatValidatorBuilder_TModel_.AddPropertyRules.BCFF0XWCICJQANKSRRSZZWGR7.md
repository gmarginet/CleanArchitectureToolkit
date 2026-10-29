<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators](Cat.Validators.md 'Cat\.Validators') > [CatValidatorBuilder&lt;TModel&gt;](CatValidatorBuilder_TModel_.md 'Cat\.Validators\.CatValidatorBuilder\<TModel\>')

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

`build` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder&lt;](..\Cat.Validators.Abstractions\ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[TModel](CatValidatorBuilder_TModel_.md#Cat.Validators.CatValidatorBuilder_TModel_.TModel 'Cat\.Validators\.CatValidatorBuilder\<TModel\>\.TModel')[,](..\Cat.Validators.Abstractions\ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[TProperty](CatValidatorBuilder_TModel_.AddPropertyRules.BCFF0XWCICJQANKSRRSZZWGR7.md#Cat.Validators.CatValidatorBuilder_TModel_.AddPropertyRules_TProperty_(System.Linq.Expressions.Expression_System.Func_TModel,TProperty__,System.Action_Cat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty__).TProperty 'Cat\.Validators\.CatValidatorBuilder\<TModel\>\.AddPropertyRules\<TProperty\>\(System\.Linq\.Expressions\.Expression\<System\.Func\<TModel,TProperty\>\>, System\.Action\<Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>\>\)\.TProperty')[&gt;](..\Cat.Validators.Abstractions\ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

Implements [AddPropertyRules&lt;TProperty&gt;\(Expression&lt;Func&lt;TModel,TProperty&gt;&gt;, Action&lt;ICatValidatorPropertyRuleBuilder&lt;TModel,TProperty&gt;&gt;\)](..\Cat.Validators.Abstractions\ICatValidatorBuilder_TModel_.AddPropertyRules.4SGJLPHSDC95BLHV1D531FAK5.md 'Cat\.Validators\.Abstractions\.ICatValidatorBuilder\`1\.AddPropertyRules\`\`1\(System\.Linq\.Expressions\.Expression\{System\.Func\{\`0,\`\`0\}\},System\.Action\{Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\{\`0,\`\`0\}\}\)')

#### Returns
[Cat\.Validators\.Abstractions\.ICatValidatorBuilder&lt;](..\Cat.Validators.Abstractions\ICatValidatorBuilder_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorBuilder\`1')[TModel](CatValidatorBuilder_TModel_.md#Cat.Validators.CatValidatorBuilder_TModel_.TModel 'Cat\.Validators\.CatValidatorBuilder\<TModel\>\.TModel')[&gt;](..\Cat.Validators.Abstractions\ICatValidatorBuilder_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorBuilder\`1')  
The same builder, so calls can be chained\.