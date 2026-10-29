<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Validators\.Abstractions](index.md 'index') > [Cat\.Validators\.Abstractions](Cat.Validators.Abstractions.md 'Cat\.Validators\.Abstractions') > [ICatValidatorModelRuleBuilder&lt;TModel&gt;](ICatValidatorModelRuleBuilder_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorModelRuleBuilder\<TModel\>')

## ICatValidatorModelRuleBuilder\<TModel\>\.AddRule\<TRule\>\(TRule\) Method

Adds a rule to the validator\.

```csharp
void AddRule<TRule>(TRule rule)
    where TRule : class, Cat.Validators.Abstractions.ICatValidatorModelRule<TModel>;
```
#### Type parameters

<a name='Cat.Validators.Abstractions.ICatValidatorModelRuleBuilder_TModel_.AddRule_TRule_(TRule).TRule'></a>

`TRule`

The type of the rule\.
#### Parameters

<a name='Cat.Validators.Abstractions.ICatValidatorModelRuleBuilder_TModel_.AddRule_TRule_(TRule).rule'></a>

`rule` [TRule](ICatValidatorModelRuleBuilder_TModel_.AddRule.NTZUA8M66NHJI05PHAP0R47G7.md#Cat.Validators.Abstractions.ICatValidatorModelRuleBuilder_TModel_.AddRule_TRule_(TRule).TRule 'Cat\.Validators\.Abstractions\.ICatValidatorModelRuleBuilder\<TModel\>\.AddRule\<TRule\>\(TRule\)\.TRule')

The rule to add\.