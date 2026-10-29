<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Validators\.Abstractions](index.md 'index') > [Cat\.Validators\.Abstractions](Cat.Validators.Abstractions.md 'Cat\.Validators\.Abstractions') > [ICatValidatorBuilder&lt;TModel&gt;](ICatValidatorBuilder_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorBuilder\<TModel\>')

## ICatValidatorBuilder\<TModel\>\.AddRules\(Action\<ICatValidatorModelRuleBuilder\<TModel\>\>\) Method

Adds rules that look at the whole model\.

```csharp
Cat.Validators.Abstractions.ICatValidatorBuilder<TModel> AddRules(System.Action<Cat.Validators.Abstractions.ICatValidatorModelRuleBuilder<TModel>> b);
```
#### Parameters

<a name='Cat.Validators.Abstractions.ICatValidatorBuilder_TModel_.AddRules(System.Action_Cat.Validators.Abstractions.ICatValidatorModelRuleBuilder_TModel__).b'></a>

`b` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[Cat\.Validators\.Abstractions\.ICatValidatorModelRuleBuilder&lt;](ICatValidatorModelRuleBuilder_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorModelRuleBuilder\<TModel\>')[TModel](ICatValidatorBuilder_TModel_.md#Cat.Validators.Abstractions.ICatValidatorBuilder_TModel_.TModel 'Cat\.Validators\.Abstractions\.ICatValidatorBuilder\<TModel\>\.TModel')[&gt;](ICatValidatorModelRuleBuilder_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorModelRuleBuilder\<TModel\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

Adds the rules to the given builder\.

#### Returns
[Cat\.Validators\.Abstractions\.ICatValidatorBuilder&lt;](ICatValidatorBuilder_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorBuilder\<TModel\>')[TModel](ICatValidatorBuilder_TModel_.md#Cat.Validators.Abstractions.ICatValidatorBuilder_TModel_.TModel 'Cat\.Validators\.Abstractions\.ICatValidatorBuilder\<TModel\>\.TModel')[&gt;](ICatValidatorBuilder_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorBuilder\<TModel\>')  
The same builder, so calls can be chained\.