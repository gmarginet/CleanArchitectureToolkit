<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators](Cat.Validators.md 'Cat\.Validators')

## CatValidatorBuilder\<TModel\> Class

Default [ICatValidatorBuilder&lt;TModel&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorBuilder_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorBuilder\`1')\.
Gathers the rules of one validator run\.

```csharp
internal class CatValidatorBuilder<TModel> : Cat.Validators.Abstractions.ICatValidatorBuilder<TModel>
    where TModel : class
```
#### Type parameters

<a name='Cat.Validators.CatValidatorBuilder_TModel_.TModel'></a>

`TModel`

The type being validated\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatValidatorBuilder\<TModel\>

Implements [Cat\.Validators\.Abstractions\.ICatValidatorBuilder&lt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorBuilder_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorBuilder\`1')[TModel](CatValidatorBuilder_TModel_.md#Cat.Validators.CatValidatorBuilder_TModel_.TModel 'Cat\.Validators\.CatValidatorBuilder\<TModel\>\.TModel')[&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorBuilder_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorBuilder\`1')

| Constructors | |
| :--- | :--- |
| [CatValidatorBuilder\(ICatCompiledMemberExpressionCache&lt;TModel&gt;, CatValidatorProcessor, bool\)](CatValidatorBuilder_TModel_..ctor.45CFD0LMO1NKNCOYKA5FTF127.md 'Cat\.Validators\.CatValidatorBuilder\<TModel\>\.CatValidatorBuilder\(Cat\.Expressions\.Abstractions\.ICatCompiledMemberExpressionCache\<TModel\>, Cat\.Validators\.CatValidatorProcessor, bool\)') | Default [ICatValidatorBuilder&lt;TModel&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorBuilder_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorBuilder\`1')\. Gathers the rules of one validator run\. |

| Properties | |
| :--- | :--- |
| [Rules](CatValidatorBuilder_TModel_.Rules.md 'Cat\.Validators\.CatValidatorBuilder\<TModel\>\.Rules') | The rules added so far\. |

| Methods | |
| :--- | :--- |
| [AddPropertyRules&lt;TProperty&gt;\(Expression&lt;Func&lt;TModel,TProperty&gt;&gt;, Action&lt;ICatValidatorPropertyRuleBuilder&lt;TModel,TProperty&gt;&gt;\)](CatValidatorBuilder_TModel_.AddPropertyRules.BCFF0XWCICJQANKSRRSZZWGR7.md 'Cat\.Validators\.CatValidatorBuilder\<TModel\>\.AddPropertyRules\<TProperty\>\(System\.Linq\.Expressions\.Expression\<System\.Func\<TModel,TProperty\>\>, System\.Action\<Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>\>\)') | Adds rules for one property of the model\. |
| [AddRules\(Action&lt;ICatValidatorModelRuleBuilder&lt;TModel&gt;&gt;\)](CatValidatorBuilder_TModel_.AddRules.UOGDP8BZ3SOGHRZZ9GY7ZRNW6.md 'Cat\.Validators\.CatValidatorBuilder\<TModel\>\.AddRules\(System\.Action\<Cat\.Validators\.Abstractions\.ICatValidatorModelRuleBuilder\<TModel\>\>\)') | Adds rules that look at the whole model\. |
