<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators\.Abstractions](index.md 'index') > [Cat\.Validators\.Abstractions](Cat.Validators.Abstractions.md 'Cat\.Validators\.Abstractions') > [ICatValidatorProcessor](ICatValidatorProcessor.md 'Cat\.Validators\.Abstractions\.ICatValidatorProcessor')

## ICatValidatorProcessor\.Validate\<TModel\>\(TModel, bool\) Method

Validates a model and blocks until it finishes\.
Prefer [ValidateAsync&lt;TModel&gt;\(TModel, bool, CancellationToken\)](ICatValidatorProcessor.ValidateAsync.YX1OQX8RMH8LA0B43AUVR45T5.md 'Cat\.Validators\.Abstractions\.ICatValidatorProcessor\.ValidateAsync\<TModel\>\(TModel, bool, System\.Threading\.CancellationToken\)') when you can\.

```csharp
Cat.Responses.Abstractions.ICatResponse Validate<TModel>(TModel model, bool validatorRequired=true)
    where TModel : class;
```
#### Type parameters

<a name='Cat.Validators.Abstractions.ICatValidatorProcessor.Validate_TModel_(TModel,bool).TModel'></a>

`TModel`

The type being validated\.
#### Parameters

<a name='Cat.Validators.Abstractions.ICatValidatorProcessor.Validate_TModel_(TModel,bool).model'></a>

`model` [TModel](ICatValidatorProcessor.Validate.52NC1J5TS1ISOCK1DV4W8K0P2.md#Cat.Validators.Abstractions.ICatValidatorProcessor.Validate_TModel_(TModel,bool).TModel 'Cat\.Validators\.Abstractions\.ICatValidatorProcessor\.Validate\<TModel\>\(TModel, bool\)\.TModel')

The model to validate\.

<a name='Cat.Validators.Abstractions.ICatValidatorProcessor.Validate_TModel_(TModel,bool).validatorRequired'></a>

`validatorRequired` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

When `true`, a missing validator throws\. When `false`, the model counts as valid\.

#### Returns
[ICatResponse](..\Cat.Responses.Abstractions\ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse')  
An Ok response when the model is valid, or a BadRequest response with one error per failure\.