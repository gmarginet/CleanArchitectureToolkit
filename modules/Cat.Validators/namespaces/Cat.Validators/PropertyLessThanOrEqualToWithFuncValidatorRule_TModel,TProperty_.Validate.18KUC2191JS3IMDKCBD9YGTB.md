<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules') > [PropertyLessThanOrEqualToWithFuncValidatorRule&lt;TModel,TProperty&gt;](PropertyLessThanOrEqualToWithFuncValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyLessThanOrEqualToWithFuncValidatorRule\<TModel,TProperty\>')

## PropertyLessThanOrEqualToWithFuncValidatorRule\<TModel,TProperty\>\.Validate\(TProperty, string, TModel\) Method

```csharp
protected override System.Collections.Generic.List<Cat.Validators.Abstractions.ICatValidatorError> Validate(TProperty value, string fieldName, TModel model);
```
#### Parameters

<a name='Cat.Validators.Rules.PropertyLessThanOrEqualToWithFuncValidatorRule_TModel,TProperty_.Validate(TProperty,string,TModel).value'></a>

`value` [TProperty](PropertyLessThanOrEqualToWithFuncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyLessThanOrEqualToWithFuncValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyLessThanOrEqualToWithFuncValidatorRule\<TModel,TProperty\>\.TProperty')

<a name='Cat.Validators.Rules.PropertyLessThanOrEqualToWithFuncValidatorRule_TModel,TProperty_.Validate(TProperty,string,TModel).fieldName'></a>

`fieldName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='Cat.Validators.Rules.PropertyLessThanOrEqualToWithFuncValidatorRule_TModel,TProperty_.Validate(TProperty,string,TModel).model'></a>

`model` [TModel](PropertyLessThanOrEqualToWithFuncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyLessThanOrEqualToWithFuncValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyLessThanOrEqualToWithFuncValidatorRule\<TModel,TProperty\>\.TModel')

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[ICatValidatorError](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorError.md 'Cat\.Validators\.Abstractions\.ICatValidatorError')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')