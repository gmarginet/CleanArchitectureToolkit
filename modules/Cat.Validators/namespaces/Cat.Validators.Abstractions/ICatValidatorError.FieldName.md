<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Validators\.Abstractions](index.md 'index') > [Cat\.Validators\.Abstractions](Cat.Validators.Abstractions.md 'Cat\.Validators\.Abstractions') > [ICatValidatorError](ICatValidatorError.md 'Cat\.Validators\.Abstractions\.ICatValidatorError')

## ICatValidatorError\.FieldName Property

The name of the field that failed\. Nested validation prefixes it, like `Todo.Title` or `Items[0].Title`\.

```csharp
string FieldName { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')