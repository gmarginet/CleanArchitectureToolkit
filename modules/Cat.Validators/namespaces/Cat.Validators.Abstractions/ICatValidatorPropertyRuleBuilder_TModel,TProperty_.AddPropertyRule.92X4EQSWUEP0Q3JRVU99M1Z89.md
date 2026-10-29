<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators\.Abstractions](index.md 'index') > [Cat\.Validators\.Abstractions](Cat.Validators.Abstractions.md 'Cat\.Validators\.Abstractions') > [ICatValidatorPropertyRuleBuilder&lt;TModel,TProperty&gt;](ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>')

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