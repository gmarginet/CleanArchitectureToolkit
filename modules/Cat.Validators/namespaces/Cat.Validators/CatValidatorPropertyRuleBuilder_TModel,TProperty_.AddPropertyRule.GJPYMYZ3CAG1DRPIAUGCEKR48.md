<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators](Cat.Validators.md 'Cat\.Validators') > [CatValidatorPropertyRuleBuilder&lt;TModel,TProperty&gt;](CatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBuilder\<TModel,TProperty\>')

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