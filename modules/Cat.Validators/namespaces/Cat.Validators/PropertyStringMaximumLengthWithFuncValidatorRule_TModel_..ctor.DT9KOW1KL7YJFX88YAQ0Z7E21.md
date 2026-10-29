<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules') > [PropertyStringMaximumLengthWithFuncValidatorRule&lt;TModel&gt;](PropertyStringMaximumLengthWithFuncValidatorRule_TModel_.md 'Cat\.Validators\.Rules\.PropertyStringMaximumLengthWithFuncValidatorRule\<TModel\>')

## PropertyStringMaximumLengthWithFuncValidatorRule\(Func\<TModel,int\>\) Constructor

Passes when the text is not longer than the maximum taken from the model\. A `null` string passes\.
Fails with [MaximumLength](CatValidatorErrorDefinitions.MaximumLength.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.MaximumLength') otherwise\.

```csharp
public PropertyStringMaximumLengthWithFuncValidatorRule(System.Func<TModel,int> maximumLengthFunc);
```
#### Parameters

<a name='Cat.Validators.Rules.PropertyStringMaximumLengthWithFuncValidatorRule_TModel_.PropertyStringMaximumLengthWithFuncValidatorRule(System.Func_TModel,int_).maximumLengthFunc'></a>

`maximumLengthFunc` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TModel](PropertyStringMaximumLengthWithFuncValidatorRule_TModel_.md#Cat.Validators.Rules.PropertyStringMaximumLengthWithFuncValidatorRule_TModel_.TModel 'Cat\.Validators\.Rules\.PropertyStringMaximumLengthWithFuncValidatorRule\<TModel\>\.TModel')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')