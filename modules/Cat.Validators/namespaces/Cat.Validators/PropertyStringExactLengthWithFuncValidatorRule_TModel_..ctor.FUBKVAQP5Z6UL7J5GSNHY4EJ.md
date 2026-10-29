<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules') > [PropertyStringExactLengthWithFuncValidatorRule&lt;TModel&gt;](PropertyStringExactLengthWithFuncValidatorRule_TModel_.md 'Cat\.Validators\.Rules\.PropertyStringExactLengthWithFuncValidatorRule\<TModel\>')

## PropertyStringExactLengthWithFuncValidatorRule\(Func\<TModel,int\>\) Constructor

Passes when the text has exactly the length taken from the model\. A `null` string passes\.
Fails with [ExactLength](CatValidatorErrorDefinitions.ExactLength.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.ExactLength') otherwise\.

```csharp
public PropertyStringExactLengthWithFuncValidatorRule(System.Func<TModel,int> exactLengthFunc);
```
#### Parameters

<a name='Cat.Validators.Rules.PropertyStringExactLengthWithFuncValidatorRule_TModel_.PropertyStringExactLengthWithFuncValidatorRule(System.Func_TModel,int_).exactLengthFunc'></a>

`exactLengthFunc` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TModel](PropertyStringExactLengthWithFuncValidatorRule_TModel_.md#Cat.Validators.Rules.PropertyStringExactLengthWithFuncValidatorRule_TModel_.TModel 'Cat\.Validators\.Rules\.PropertyStringExactLengthWithFuncValidatorRule\<TModel\>\.TModel')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')