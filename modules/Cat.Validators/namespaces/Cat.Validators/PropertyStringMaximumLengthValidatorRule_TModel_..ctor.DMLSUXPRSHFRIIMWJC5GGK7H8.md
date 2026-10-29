<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules') > [PropertyStringMaximumLengthValidatorRule&lt;TModel&gt;](PropertyStringMaximumLengthValidatorRule_TModel_.md 'Cat\.Validators\.Rules\.PropertyStringMaximumLengthValidatorRule\<TModel\>')

## PropertyStringMaximumLengthValidatorRule\(int\) Constructor

Passes when the text is not longer than the maximum\. A `null` string passes\.
Fails with [MaximumLength](CatValidatorErrorDefinitions.MaximumLength.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.MaximumLength') otherwise\.

```csharp
public PropertyStringMaximumLengthValidatorRule(int maximumLength);
```
#### Parameters

<a name='Cat.Validators.Rules.PropertyStringMaximumLengthValidatorRule_TModel_.PropertyStringMaximumLengthValidatorRule(int).maximumLength'></a>

`maximumLength` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')