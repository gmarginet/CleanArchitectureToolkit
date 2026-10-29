<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators\.Abstractions](index.md 'index') > [Cat\.Validators\.Abstractions](Cat.Validators.Abstractions.md 'Cat\.Validators\.Abstractions') > [ICatValidatorPropertyRule&lt;TModel,TProperty&gt;](ICatValidatorPropertyRule_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRule\<TModel,TProperty\>')

## ICatValidatorPropertyRule\<TModel,TProperty\>\.FieldName Property

Replaces the field name in the errors\. Leave it `null` to use the property name\.

```csharp
string? FieldName { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')