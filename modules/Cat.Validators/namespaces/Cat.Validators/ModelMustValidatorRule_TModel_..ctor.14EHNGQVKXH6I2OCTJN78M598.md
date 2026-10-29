<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules') > [ModelMustValidatorRule&lt;TModel&gt;](ModelMustValidatorRule_TModel_.md 'Cat\.Validators\.Rules\.ModelMustValidatorRule\<TModel\>')

## ModelMustValidatorRule\(Func\<TModel,List\<ICatValidatorError\>\>\) Constructor

Checks the whole model with your own code\.

```csharp
public ModelMustValidatorRule(System.Func<TModel,System.Collections.Generic.List<Cat.Validators.Abstractions.ICatValidatorError>> predicate);
```
#### Parameters

<a name='Cat.Validators.Rules.ModelMustValidatorRule_TModel_.ModelMustValidatorRule(System.Func_TModel,System.Collections.Generic.List_Cat.Validators.Abstractions.ICatValidatorError__).predicate'></a>

`predicate` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TModel](ModelMustValidatorRule_TModel_.md#Cat.Validators.Rules.ModelMustValidatorRule_TModel_.TModel 'Cat\.Validators\.Rules\.ModelMustValidatorRule\<TModel\>\.TModel')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[ICatValidatorError](../Cat.Validators.Abstractions/ICatValidatorError.md 'Cat\.Validators\.Abstractions\.ICatValidatorError')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')