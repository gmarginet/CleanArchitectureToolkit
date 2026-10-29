<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Validators\.Abstractions](index.md 'index') > [Cat\.Validators\.Abstractions](Cat.Validators.Abstractions.md 'Cat\.Validators\.Abstractions') > [ICatValidatorPropertyRule&lt;TModel,TProperty&gt;](ICatValidatorPropertyRule_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRule\<TModel,TProperty\>')

## ICatValidatorPropertyRule\<TModel,TProperty\>\.ErrorMessage Property

Replaces the error message\. Leave it `null` to use the message of the rule\.

```csharp
string? ErrorMessage { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')