<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules') > [PropertyStringLengthValidatorRule&lt;TModel&gt;](PropertyStringLengthValidatorRule_TModel_.md 'Cat\.Validators\.Rules\.PropertyStringLengthValidatorRule\<TModel\>')

## PropertyStringLengthValidatorRule\(int, int\) Constructor

Passes when the text length is between the minimum and the maximum\. A `null` string passes\.
Fails with [Length](CatValidatorErrorDefinitions.Length.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.Length') otherwise\.

```csharp
public PropertyStringLengthValidatorRule(int min, int max);
```
#### Parameters

<a name='Cat.Validators.Rules.PropertyStringLengthValidatorRule_TModel_.PropertyStringLengthValidatorRule(int,int).min'></a>

`min` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='Cat.Validators.Rules.PropertyStringLengthValidatorRule_TModel_.PropertyStringLengthValidatorRule(int,int).max'></a>

`max` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')