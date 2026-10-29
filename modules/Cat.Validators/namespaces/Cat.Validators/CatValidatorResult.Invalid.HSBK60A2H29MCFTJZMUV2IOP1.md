<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators](Cat.Validators.md 'Cat\.Validators') > [CatValidatorResult](CatValidatorResult.md 'Cat\.Validators\.CatValidatorResult')

## CatValidatorResult\.Invalid\(ICatValidatorError\[\]\) Method

Creates the outcome of a rule that found failures\.

```csharp
public static System.Collections.Generic.List<Cat.Validators.Abstractions.ICatValidatorError> Invalid(params Cat.Validators.Abstractions.ICatValidatorError[] errorDetails);
```
#### Parameters

<a name='Cat.Validators.CatValidatorResult.Invalid(Cat.Validators.Abstractions.ICatValidatorError[]).errorDetails'></a>

`errorDetails` [ICatValidatorError](..\Cat.Validators.Abstractions\ICatValidatorError.md 'Cat\.Validators\.Abstractions\.ICatValidatorError')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The failures found\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[ICatValidatorError](..\Cat.Validators.Abstractions\ICatValidatorError.md 'Cat\.Validators\.Abstractions\.ICatValidatorError')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
A list holding the failures\.