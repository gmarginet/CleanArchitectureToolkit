<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators\.Abstractions](index.md 'index') > [Cat\.Validators\.Abstractions](Cat.Validators.Abstractions.md 'Cat\.Validators\.Abstractions') > [ICatValidatorBuilder&lt;TModel&gt;](ICatValidatorBuilder_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorBuilder\<TModel\>')

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