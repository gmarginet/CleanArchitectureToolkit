<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators](Cat.Validators.md 'Cat\.Validators') > [CatValidatorProcessor](CatValidatorProcessor.md 'Cat\.Validators\.CatValidatorProcessor')

## CatValidatorProcessor\.Validate\<T\>\(T, bool\) Method

Validates a model and blocks until it finishes\.
Prefer [ValidateAsync&lt;TModel&gt;\(TModel, bool, CancellationToken\)](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorProcessor.ValidateAsync.YX1OQX8RMH8LA0B43AUVR45T5.md 'Cat\.Validators\.Abstractions\.ICatValidatorProcessor\.ValidateAsync\`\`1\(\`\`0,System\.Boolean,System\.Threading\.CancellationToken\)') when you can\.

```csharp
public Cat.Responses.Abstractions.ICatResponse Validate<T>(T model, bool validatorRequired=true)
    where T : class;
```
#### Type parameters

<a name='Cat.Validators.CatValidatorProcessor.Validate_T_(T,bool).T'></a>

`T`
#### Parameters

<a name='Cat.Validators.CatValidatorProcessor.Validate_T_(T,bool).model'></a>

`model` [T](CatValidatorProcessor.Validate.2H7PED1DKKQ4EEVWCZ5CLKUK8.md#Cat.Validators.CatValidatorProcessor.Validate_T_(T,bool).T 'Cat\.Validators\.CatValidatorProcessor\.Validate\<T\>\(T, bool\)\.T')

The model to validate\.

<a name='Cat.Validators.CatValidatorProcessor.Validate_T_(T,bool).validatorRequired'></a>

`validatorRequired` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

When `true`, a missing validator throws\. When `false`, the model counts as valid\.

Implements [Validate&lt;TModel&gt;\(TModel, bool\)](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorProcessor.Validate.52NC1J5TS1ISOCK1DV4W8K0P2.md 'Cat\.Validators\.Abstractions\.ICatValidatorProcessor\.Validate\`\`1\(\`\`0,System\.Boolean\)')

#### Returns
[ICatResponse](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse')  
An Ok response when the model is valid, or a BadRequest response with one error per failure\.