<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules') > [PropertyStringExactLengthValidatorRule&lt;TModel&gt;](PropertyStringExactLengthValidatorRule_TModel_.md 'Cat\.Validators\.Rules\.PropertyStringExactLengthValidatorRule\<TModel\>')

## PropertyStringExactLengthValidatorRule\(int\) Constructor

Passes when the text has exactly the given length\. A `null` string passes\.
Fails with [ExactLength](CatValidatorErrorDefinitions.ExactLength.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.ExactLength') otherwise\.

```csharp
public PropertyStringExactLengthValidatorRule(int exactLength);
```
#### Parameters

<a name='Cat.Validators.Rules.PropertyStringExactLengthValidatorRule_TModel_.PropertyStringExactLengthValidatorRule(int).exactLength'></a>

`exactLength` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')