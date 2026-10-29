<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators](Cat.Validators.md 'Cat\.Validators')

## CatValidatorPropertyRuleBuilder\<TModel,TProperty\> Class

Default [ICatValidatorPropertyRuleBuilder&lt;TModel,TProperty&gt;](../Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')\.
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

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; CatValidatorPropertyRuleBuilder\<TModel,TProperty\>

Implements [Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder&lt;](../Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[TModel](CatValidatorPropertyRuleBuilder_TModel,TProperty_.md#Cat.Validators.CatValidatorPropertyRuleBuilder_TModel,TProperty_.TModel 'Cat\.Validators\.CatValidatorPropertyRuleBuilder\<TModel,TProperty\>\.TModel')[,](../Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[TProperty](CatValidatorPropertyRuleBuilder_TModel,TProperty_.md#Cat.Validators.CatValidatorPropertyRuleBuilder_TModel,TProperty_.TProperty 'Cat\.Validators\.CatValidatorPropertyRuleBuilder\<TModel,TProperty\>\.TProperty')[&gt;](../Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')

| Constructors | |
| :--- | :--- |
| [CatValidatorPropertyRuleBuilder\(ConcurrentQueue&lt;ICatValidatorModelRule&lt;TModel&gt;&gt;, Expression&lt;Func&lt;TModel,TProperty&gt;&gt;, ICatCompiledMemberExpressionCache&lt;TModel&gt;, CatValidatorProcessor, bool\)](CatValidatorPropertyRuleBuilder_TModel,TProperty_..ctor.O8USH1JIWMDDZ9EFQH9D80MG9.md 'Cat\.Validators\.CatValidatorPropertyRuleBuilder\<TModel,TProperty\>\.CatValidatorPropertyRuleBuilder\(System\.Collections\.Concurrent\.ConcurrentQueue\<Cat\.Validators\.Abstractions\.ICatValidatorModelRule\<TModel\>\>, System\.Linq\.Expressions\.Expression\<System\.Func\<TModel,TProperty\>\>, Cat\.Expressions\.Abstractions\.ICatCompiledMemberExpressionCache\<TModel\>, Cat\.Validators\.CatValidatorProcessor, bool\)') | Default [ICatValidatorPropertyRuleBuilder&lt;TModel,TProperty&gt;](../Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')\. Hands each new rule the property expression, the expression cache and the processor\. |

| Methods | |
| :--- | :--- |
| [AddPropertyRule&lt;TRule&gt;\(TRule\)](CatValidatorPropertyRuleBuilder_TModel,TProperty_.AddPropertyRule.GJPYMYZ3CAG1DRPIAUGCEKR48.md 'Cat\.Validators\.CatValidatorPropertyRuleBuilder\<TModel,TProperty\>\.AddPropertyRule\<TRule\>\(TRule\)') | Adds a rule for the property\. |
