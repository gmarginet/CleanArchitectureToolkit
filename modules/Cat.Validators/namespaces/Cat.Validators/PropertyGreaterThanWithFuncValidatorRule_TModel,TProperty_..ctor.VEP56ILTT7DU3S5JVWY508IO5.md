<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules') > [PropertyGreaterThanWithFuncValidatorRule&lt;TModel,TProperty&gt;](PropertyGreaterThanWithFuncValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyGreaterThanWithFuncValidatorRule\<TModel,TProperty\>')

## PropertyGreaterThanWithFuncValidatorRule\(Expression\<Func\<TModel,TProperty\>\>\) Constructor

Passes when the value is greater than another property of the model\.
Fails with [GreaterThan](CatValidatorErrorDefinitions.GreaterThan.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.GreaterThan') otherwise\.

```csharp
public PropertyGreaterThanWithFuncValidatorRule(System.Linq.Expressions.Expression<System.Func<TModel,TProperty>> expression);
```
#### Parameters

<a name='Cat.Validators.Rules.PropertyGreaterThanWithFuncValidatorRule_TModel,TProperty_.PropertyGreaterThanWithFuncValidatorRule(System.Linq.Expressions.Expression_System.Func_TModel,TProperty__).expression'></a>

`expression` [System\.Linq\.Expressions\.Expression&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')[System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TModel](PropertyGreaterThanWithFuncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyGreaterThanWithFuncValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyGreaterThanWithFuncValidatorRule\<TModel,TProperty\>\.TModel')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TProperty](PropertyGreaterThanWithFuncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyGreaterThanWithFuncValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyGreaterThanWithFuncValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')