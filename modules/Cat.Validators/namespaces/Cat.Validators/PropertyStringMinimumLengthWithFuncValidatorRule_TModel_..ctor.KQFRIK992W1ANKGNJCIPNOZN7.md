<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules') > [PropertyStringMinimumLengthWithFuncValidatorRule&lt;TModel&gt;](PropertyStringMinimumLengthWithFuncValidatorRule_TModel_.md 'Cat\.Validators\.Rules\.PropertyStringMinimumLengthWithFuncValidatorRule\<TModel\>')

## PropertyStringMinimumLengthWithFuncValidatorRule\(Func\<TModel,int\>\) Constructor

Passes when the text is not shorter than the minimum taken from the model\. A `null` string passes\.
Fails with [MinimumLength](CatValidatorErrorDefinitions.MinimumLength.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.MinimumLength') otherwise\.

```csharp
public PropertyStringMinimumLengthWithFuncValidatorRule(System.Func<TModel,int> minimumLengthFunc);
```
#### Parameters

<a name='Cat.Validators.Rules.PropertyStringMinimumLengthWithFuncValidatorRule_TModel_.PropertyStringMinimumLengthWithFuncValidatorRule(System.Func_TModel,int_).minimumLengthFunc'></a>

`minimumLengthFunc` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TModel](PropertyStringMinimumLengthWithFuncValidatorRule_TModel_.md#Cat.Validators.Rules.PropertyStringMinimumLengthWithFuncValidatorRule_TModel_.TModel 'Cat\.Validators\.Rules\.PropertyStringMinimumLengthWithFuncValidatorRule\<TModel\>\.TModel')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')