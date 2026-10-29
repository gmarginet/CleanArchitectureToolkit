<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Validators\.Abstractions](index.md 'index') > [Cat\.Validators\.Abstractions](Cat.Validators.Abstractions.md 'Cat\.Validators\.Abstractions')

## ICatValidatorPropertyRuleBuilder\<TModel,TProperty\> Interface

Adds rules for one property\. The built\-in rules are extension methods on this interface\.

```csharp
public interface ICatValidatorPropertyRuleBuilder<TModel,TProperty>
    where TModel : class
```
#### Type parameters

<a name='Cat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_.TModel'></a>

`TModel`

The type being validated\.

<a name='Cat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_.TProperty'></a>

`TProperty`

The type of the property\.

| Methods | |
| :--- | :--- |
| [AddPropertyRule&lt;TRule&gt;\(TRule\)](ICatValidatorPropertyRuleBuilder_TModel,TProperty_.AddPropertyRule.92X4EQSWUEP0Q3JRVU99M1Z89.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>\.AddPropertyRule\<TRule\>\(TRule\)') | Adds a rule for the property\. |
