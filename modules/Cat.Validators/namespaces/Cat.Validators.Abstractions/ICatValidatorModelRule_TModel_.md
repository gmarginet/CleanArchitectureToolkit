<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators\.Abstractions](index.md 'index') > [Cat\.Validators\.Abstractions](Cat.Validators.Abstractions.md 'Cat\.Validators\.Abstractions')

## ICatValidatorModelRule\<TModel\> Interface

A rule that checks a model and returns the failures it finds\.

```csharp
public interface ICatValidatorModelRule<TModel>
    where TModel : class
```
#### Type parameters

<a name='Cat.Validators.Abstractions.ICatValidatorModelRule_TModel_.TModel'></a>

`TModel`

The type being validated\.

Derived  
&#8627; [ICatValidatorPropertyRule&lt;TModel,TProperty&gt;](ICatValidatorPropertyRule_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRule\<TModel,TProperty\>')

| Properties | |
| :--- | :--- |
| [RulesConditionFuncAsyncList](ICatValidatorModelRule_TModel_.RulesConditionFuncAsyncList.md 'Cat\.Validators\.Abstractions\.ICatValidatorModelRule\<TModel\>\.RulesConditionFuncAsyncList') | Conditions that decide whether the rule runs\. The rule is skipped when any of them returns `false`\. |

| Methods | |
| :--- | :--- |
| [ValidateAsync\(TModel, CancellationToken\)](ICatValidatorModelRule_TModel_.ValidateAsync.OP5PLME0CZWG5EGZ8QRKTRTC6.md 'Cat\.Validators\.Abstractions\.ICatValidatorModelRule\<TModel\>\.ValidateAsync\(TModel, System\.Threading\.CancellationToken\)') | Runs the rule\. |
