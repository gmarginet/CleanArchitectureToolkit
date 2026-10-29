<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators](Cat.Validators.md 'Cat\.Validators') > [CatValidatorBuilder&lt;TModel&gt;](CatValidatorBuilder_TModel_.md 'Cat\.Validators\.CatValidatorBuilder\<TModel\>')

## CatValidatorBuilder\(ICatCompiledMemberExpressionCache\<TModel\>, CatValidatorProcessor, bool\) Constructor

Default [ICatValidatorBuilder&lt;TModel&gt;](..\Cat.Validators.Abstractions\ICatValidatorBuilder_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorBuilder\`1')\.
Gathers the rules of one validator run\.

```csharp
public CatValidatorBuilder(Cat.Expressions.Abstractions.ICatCompiledMemberExpressionCache<TModel> compiledMemberExpressionCache, Cat.Validators.CatValidatorProcessor validatorProcessor, bool validatorRequired=true);
```
#### Parameters

<a name='Cat.Validators.CatValidatorBuilder_TModel_.CatValidatorBuilder(Cat.Expressions.Abstractions.ICatCompiledMemberExpressionCache_TModel_,Cat.Validators.CatValidatorProcessor,bool).compiledMemberExpressionCache'></a>

`compiledMemberExpressionCache` [Cat\.Expressions\.Abstractions\.ICatCompiledMemberExpressionCache&lt;](..\Cat.Expressions.Abstractions\ICatCompiledMemberExpressionCache_T_.md 'Cat\.Expressions\.Abstractions\.ICatCompiledMemberExpressionCache\`1')[TModel](CatValidatorBuilder_TModel_.md#Cat.Validators.CatValidatorBuilder_TModel_.TModel 'Cat\.Validators\.CatValidatorBuilder\<TModel\>\.TModel')[&gt;](..\Cat.Expressions.Abstractions\ICatCompiledMemberExpressionCache_T_.md 'Cat\.Expressions\.Abstractions\.ICatCompiledMemberExpressionCache\`1')

<a name='Cat.Validators.CatValidatorBuilder_TModel_.CatValidatorBuilder(Cat.Expressions.Abstractions.ICatCompiledMemberExpressionCache_TModel_,Cat.Validators.CatValidatorProcessor,bool).validatorProcessor'></a>

`validatorProcessor` [CatValidatorProcessor](CatValidatorProcessor.md 'Cat\.Validators\.CatValidatorProcessor')

<a name='Cat.Validators.CatValidatorBuilder_TModel_.CatValidatorBuilder(Cat.Expressions.Abstractions.ICatCompiledMemberExpressionCache_TModel_,Cat.Validators.CatValidatorProcessor,bool).validatorRequired'></a>

`validatorRequired` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')