<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules') > [PropertyStringLengthWithFuncValidatorRule&lt;TModel&gt;](PropertyStringLengthWithFuncValidatorRule_TModel_.md 'Cat\.Validators\.Rules\.PropertyStringLengthWithFuncValidatorRule\<TModel\>')

## PropertyStringLengthWithFuncValidatorRule\(Func\<TModel,int\>, Func\<TModel,int\>\) Constructor

Passes when the text length is between a minimum and a maximum taken from the model\. A `null` string passes\.
Fails with [Length](CatValidatorErrorDefinitions.Length.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.Length') otherwise\.

```csharp
public PropertyStringLengthWithFuncValidatorRule(System.Func<TModel,int> minFunc, System.Func<TModel,int> maxFunc);
```
#### Parameters

<a name='Cat.Validators.Rules.PropertyStringLengthWithFuncValidatorRule_TModel_.PropertyStringLengthWithFuncValidatorRule(System.Func_TModel,int_,System.Func_TModel,int_).minFunc'></a>

`minFunc` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TModel](PropertyStringLengthWithFuncValidatorRule_TModel_.md#Cat.Validators.Rules.PropertyStringLengthWithFuncValidatorRule_TModel_.TModel 'Cat\.Validators\.Rules\.PropertyStringLengthWithFuncValidatorRule\<TModel\>\.TModel')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

<a name='Cat.Validators.Rules.PropertyStringLengthWithFuncValidatorRule_TModel_.PropertyStringLengthWithFuncValidatorRule(System.Func_TModel,int_,System.Func_TModel,int_).maxFunc'></a>

`maxFunc` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TModel](PropertyStringLengthWithFuncValidatorRule_TModel_.md#Cat.Validators.Rules.PropertyStringLengthWithFuncValidatorRule_TModel_.TModel 'Cat\.Validators\.Rules\.PropertyStringLengthWithFuncValidatorRule\<TModel\>\.TModel')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')