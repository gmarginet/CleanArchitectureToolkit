<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules') > [PropertyModelMustValidatorRule&lt;TModel,TProperty&gt;](PropertyModelMustValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyModelMustValidatorRule\<TModel,TProperty\>')

## PropertyModelMustValidatorRule\(Func\<TProperty,string,TModel,List\<ICatValidatorError\>\>\) Constructor

Checks a property with your own code that can also look at the whole model\.

```csharp
public PropertyModelMustValidatorRule(System.Func<TProperty,string,TModel,System.Collections.Generic.List<Cat.Validators.Abstractions.ICatValidatorError>> predicate);
```
#### Parameters

<a name='Cat.Validators.Rules.PropertyModelMustValidatorRule_TModel,TProperty_.PropertyModelMustValidatorRule(System.Func_TProperty,string,TModel,System.Collections.Generic.List_Cat.Validators.Abstractions.ICatValidatorError__).predicate'></a>

`predicate` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-4 'System\.Func\`4')[TProperty](PropertyModelMustValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyModelMustValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyModelMustValidatorRule\<TModel,TProperty\>\.TProperty')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-4 'System\.Func\`4')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-4 'System\.Func\`4')[TModel](PropertyModelMustValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyModelMustValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyModelMustValidatorRule\<TModel,TProperty\>\.TModel')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-4 'System\.Func\`4')[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[ICatValidatorError](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorError.md 'Cat\.Validators\.Abstractions\.ICatValidatorError')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-4 'System\.Func\`4')