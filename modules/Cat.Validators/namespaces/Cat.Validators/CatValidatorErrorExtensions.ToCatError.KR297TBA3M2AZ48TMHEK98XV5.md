<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Extensions](Cat.Validators.Extensions.md 'Cat\.Validators\.Extensions') > [CatValidatorErrorExtensions](CatValidatorErrorExtensions.md 'Cat\.Validators\.Extensions\.CatValidatorErrorExtensions')

## CatValidatorErrorExtensions\.ToCatError\(this ICatValidatorError\) Method

Converts a validator error to a response error\.
The field name becomes the first argument, so the message placeholders line up\.

```csharp
public static Cat.Responses.Abstractions.ICatError ToCatError(this Cat.Validators.Abstractions.ICatValidatorError error);
```
#### Parameters

<a name='Cat.Validators.Extensions.CatValidatorErrorExtensions.ToCatError(thisCat.Validators.Abstractions.ICatValidatorError).error'></a>

`error` [ICatValidatorError](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorError.md 'Cat\.Validators\.Abstractions\.ICatValidatorError')

The error to convert\.

#### Returns
[ICatError](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatError.md 'Cat\.Responses\.Abstractions\.ICatError')  
The response error\.