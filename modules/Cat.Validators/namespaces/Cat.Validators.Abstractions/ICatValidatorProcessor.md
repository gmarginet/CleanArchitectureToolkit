<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators\.Abstractions](index.md 'index') > [Cat\.Validators\.Abstractions](Cat.Validators.Abstractions.md 'Cat\.Validators\.Abstractions')

## ICatValidatorProcessor Interface

Single entry point for validating a model\.
It finds the validator for the model, runs its rules and returns the outcome as a response\.

```csharp
public interface ICatValidatorProcessor
```

| Methods | |
| :--- | :--- |
| [Validate&lt;TModel&gt;\(TModel, bool\)](ICatValidatorProcessor.Validate.52NC1J5TS1ISOCK1DV4W8K0P2.md 'Cat\.Validators\.Abstractions\.ICatValidatorProcessor\.Validate\<TModel\>\(TModel, bool\)') | Validates a model and blocks until it finishes\. Prefer [ValidateAsync&lt;TModel&gt;\(TModel, bool, CancellationToken\)](ICatValidatorProcessor.ValidateAsync.YX1OQX8RMH8LA0B43AUVR45T5.md 'Cat\.Validators\.Abstractions\.ICatValidatorProcessor\.ValidateAsync\<TModel\>\(TModel, bool, System\.Threading\.CancellationToken\)') when you can\. |
| [ValidateAsync&lt;TModel&gt;\(TModel, bool, CancellationToken\)](ICatValidatorProcessor.ValidateAsync.YX1OQX8RMH8LA0B43AUVR45T5.md 'Cat\.Validators\.Abstractions\.ICatValidatorProcessor\.ValidateAsync\<TModel\>\(TModel, bool, System\.Threading\.CancellationToken\)') | Validates a model\. |
