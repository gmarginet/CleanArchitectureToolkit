<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules') > [PropertyStringMinimumLengthValidatorRule&lt;TModel&gt;](PropertyStringMinimumLengthValidatorRule_TModel_.md 'Cat\.Validators\.Rules\.PropertyStringMinimumLengthValidatorRule\<TModel\>')

## PropertyStringMinimumLengthValidatorRule\(int\) Constructor

Passes when the text is not shorter than the minimum\. A `null` string passes\.
Fails with [MinimumLength](CatValidatorErrorDefinitions.MinimumLength.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.MinimumLength') otherwise\.

```csharp
public PropertyStringMinimumLengthValidatorRule(int minimumLength);
```
#### Parameters

<a name='Cat.Validators.Rules.PropertyStringMinimumLengthValidatorRule_TModel_.PropertyStringMinimumLengthValidatorRule(int).minimumLength'></a>

`minimumLength` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')