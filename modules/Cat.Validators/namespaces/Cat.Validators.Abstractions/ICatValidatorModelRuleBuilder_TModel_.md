<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Validators\.Abstractions](index.md 'index') > [Cat\.Validators\.Abstractions](Cat.Validators.Abstractions.md 'Cat\.Validators\.Abstractions')

## ICatValidatorModelRuleBuilder\<TModel\> Interface

Adds rules that look at the whole model\.

```csharp
public interface ICatValidatorModelRuleBuilder<TModel>
    where TModel : class
```
#### Type parameters

<a name='Cat.Validators.Abstractions.ICatValidatorModelRuleBuilder_TModel_.TModel'></a>

`TModel`

The type being validated\.

| Methods | |
| :--- | :--- |
| [AddRule&lt;TRule&gt;\(TRule\)](ICatValidatorModelRuleBuilder_TModel_.AddRule.NTZUA8M66NHJI05PHAP0R47G7.md 'Cat\.Validators\.Abstractions\.ICatValidatorModelRuleBuilder\<TModel\>\.AddRule\<TRule\>\(TRule\)') | Adds a rule to the validator\. |
