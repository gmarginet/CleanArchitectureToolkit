<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules') > [PropertyGreaterThanOrEqualToWithFuncValidatorRule&lt;TModel,TProperty&gt;](PropertyGreaterThanOrEqualToWithFuncValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyGreaterThanOrEqualToWithFuncValidatorRule\<TModel,TProperty\>')

## PropertyGreaterThanOrEqualToWithFuncValidatorRule\(Expression\<Func\<TModel,TProperty\>\>\) Constructor

Passes when the value is greater than or equal to another property of the model\.
Fails with [GreaterThanOrEqualTo](CatValidatorErrorDefinitions.GreaterThanOrEqualTo.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.GreaterThanOrEqualTo') otherwise\.

```csharp
public PropertyGreaterThanOrEqualToWithFuncValidatorRule(System.Linq.Expressions.Expression<System.Func<TModel,TProperty>> expression);
```
#### Parameters

<a name='Cat.Validators.Rules.PropertyGreaterThanOrEqualToWithFuncValidatorRule_TModel,TProperty_.PropertyGreaterThanOrEqualToWithFuncValidatorRule(System.Linq.Expressions.Expression_System.Func_TModel,TProperty__).expression'></a>

`expression` [System\.Linq\.Expressions\.Expression&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')[System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TModel](PropertyGreaterThanOrEqualToWithFuncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyGreaterThanOrEqualToWithFuncValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyGreaterThanOrEqualToWithFuncValidatorRule\<TModel,TProperty\>\.TModel')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TProperty](PropertyGreaterThanOrEqualToWithFuncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyGreaterThanOrEqualToWithFuncValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyGreaterThanOrEqualToWithFuncValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')