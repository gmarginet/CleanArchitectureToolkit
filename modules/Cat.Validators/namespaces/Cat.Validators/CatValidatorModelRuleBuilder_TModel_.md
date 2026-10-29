<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators](Cat.Validators.md 'Cat\.Validators')

## CatValidatorModelRuleBuilder\<TModel\> Class

Default [ICatValidatorModelRuleBuilder&lt;TModel&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorModelRuleBuilder_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorModelRuleBuilder\`1')\.

```csharp
public class CatValidatorModelRuleBuilder<TModel> : Cat.Validators.Abstractions.ICatValidatorModelRuleBuilder<TModel>
    where TModel : class
```
#### Type parameters

<a name='Cat.Validators.CatValidatorModelRuleBuilder_TModel_.TModel'></a>

`TModel`

The type being validated\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; CatValidatorModelRuleBuilder\<TModel\>

Implements [Cat\.Validators\.Abstractions\.ICatValidatorModelRuleBuilder&lt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorModelRuleBuilder_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorModelRuleBuilder\`1')[TModel](CatValidatorModelRuleBuilder_TModel_.md#Cat.Validators.CatValidatorModelRuleBuilder_TModel_.TModel 'Cat\.Validators\.CatValidatorModelRuleBuilder\<TModel\>\.TModel')[&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorModelRuleBuilder_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorModelRuleBuilder\`1')

| Constructors | |
| :--- | :--- |
| [CatValidatorModelRuleBuilder\(ConcurrentQueue&lt;ICatValidatorModelRule&lt;TModel&gt;&gt;\)](CatValidatorModelRuleBuilder_TModel_..ctor.3674QXBRHOAWIEZDXKCT0JCQ.md 'Cat\.Validators\.CatValidatorModelRuleBuilder\<TModel\>\.CatValidatorModelRuleBuilder\(System\.Collections\.Concurrent\.ConcurrentQueue\<Cat\.Validators\.Abstractions\.ICatValidatorModelRule\<TModel\>\>\)') | Default [ICatValidatorModelRuleBuilder&lt;TModel&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorModelRuleBuilder_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorModelRuleBuilder\`1')\. |

| Methods | |
| :--- | :--- |
| [AddRule&lt;TRule&gt;\(TRule\)](CatValidatorModelRuleBuilder_TModel_.AddRule.PLYT02AZTLYKVXGLD1RU5XKVD.md 'Cat\.Validators\.CatValidatorModelRuleBuilder\<TModel\>\.AddRule\<TRule\>\(TRule\)') | Adds a rule to the validator\. |
