<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators\.Abstractions](index.md 'index') > [Cat\.Validators\.Abstractions](Cat.Validators.Abstractions.md 'Cat\.Validators\.Abstractions')

## ICatValidatorPropertyRuleOptionsBuilder\<TModel,TProperty\> Interface

Sets options on the rule you just added, like a condition, a field name or a message\.

```csharp
public interface ICatValidatorPropertyRuleOptionsBuilder<TModel,TProperty>
    where TModel : class
```
#### Type parameters

<a name='Cat.Validators.Abstractions.ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.TModel'></a>

`TModel`

The type being validated\.

<a name='Cat.Validators.Abstractions.ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.TProperty'></a>

`TProperty`

The type of the property\.

| Properties | |
| :--- | :--- |
| [Rule](ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.Rule.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\<TModel,TProperty\>\.Rule') | The rule the options apply to\. |
