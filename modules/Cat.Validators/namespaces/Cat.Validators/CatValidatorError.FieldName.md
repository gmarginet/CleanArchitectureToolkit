<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators](Cat.Validators.md 'Cat\.Validators') > [CatValidatorError](CatValidatorError.md 'Cat\.Validators\.CatValidatorError')

## CatValidatorError\.FieldName Property

The name of the field that failed\. Nested validation prefixes it, like `Todo.Title` or `Items[0].Title`\.

```csharp
public string FieldName { get; set; }
```

Implements [FieldName](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorError.FieldName.md 'Cat\.Validators\.Abstractions\.ICatValidatorError\.FieldName')

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')