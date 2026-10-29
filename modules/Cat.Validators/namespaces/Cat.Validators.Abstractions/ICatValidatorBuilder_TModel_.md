<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators\.Abstractions](index.md 'index') > [Cat\.Validators\.Abstractions](Cat.Validators.Abstractions.md 'Cat\.Validators\.Abstractions')

## ICatValidatorBuilder\<TModel\> Interface

Collects the rules of a validator\. You get one in [Build\(ICatValidatorBuilder&lt;TModel&gt;\)](ICatValidator_TModel_.Build.KH5JMOMCH87CLWU32S59B0UE1.md 'Cat\.Validators\.Abstractions\.ICatValidator\<TModel\>\.Build\(Cat\.Validators\.Abstractions\.ICatValidatorBuilder\<TModel\>\)')\.

```csharp
public interface ICatValidatorBuilder<TModel>
    where TModel : class
```
#### Type parameters

<a name='Cat.Validators.Abstractions.ICatValidatorBuilder_TModel_.TModel'></a>

`TModel`

The type being validated\.

| Methods | |
| :--- | :--- |
| [AddPropertyRules&lt;TProperty&gt;\(Expression&lt;Func&lt;TModel,TProperty&gt;&gt;, Action&lt;ICatValidatorPropertyRuleBuilder&lt;TModel,TProperty&gt;&gt;\)](ICatValidatorBuilder_TModel_.AddPropertyRules.4SGJLPHSDC95BLHV1D531FAK5.md 'Cat\.Validators\.Abstractions\.ICatValidatorBuilder\<TModel\>\.AddPropertyRules\<TProperty\>\(System\.Linq\.Expressions\.Expression\<System\.Func\<TModel,TProperty\>\>, System\.Action\<Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>\>\)') | Adds rules for one property of the model\. |
| [AddRules\(Action&lt;ICatValidatorModelRuleBuilder&lt;TModel&gt;&gt;\)](ICatValidatorBuilder_TModel_.AddRules.7LVEP6J7EA1YDLNO2MIA8L6N1.md 'Cat\.Validators\.Abstractions\.ICatValidatorBuilder\<TModel\>\.AddRules\(System\.Action\<Cat\.Validators\.Abstractions\.ICatValidatorModelRuleBuilder\<TModel\>\>\)') | Adds rules that look at the whole model\. |
